Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class upload_class
    Inherits basepage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = ""


        If (WebLib.UserCode & "").trim = "" Then
            Response.Redirect("loginmain.aspx")
        End If

    End Sub

    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If FileUpload1.HasFile Then
            Dim FileName As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
            Dim Extension As String = Path.GetExtension(FileUpload1.PostedFile.FileName)
            Dim FolderPath As String = ConfigurationManager.AppSettings("FolderPath")

            Dim FilePath As String = Server.MapPath(FolderPath + FileName)
            FileUpload1.SaveAs(FilePath)
            Import_To_Grid(FilePath, Extension, rbHDR.SelectedItem.Text)
        End If
    End Sub

    Private Sub Import_To_Grid(ByVal FilePath As String, ByVal Extension As String, ByVal isHDR As String)
        Dim conStr As String = ""
        Select Case Extension
            Case ".xls"
                'Excel 97-03 
                conStr = ConfigurationManager.ConnectionStrings("Excel03ConString").ConnectionString
                Exit Select
            Case ".xlsx"
                'Excel 07 
                conStr = ConfigurationManager.ConnectionStrings("Excel07ConString").ConnectionString
                Exit Select
        End Select
        conStr = String.Format(conStr, FilePath, isHDR)

        Dim connExcel As New OleDbConnection(conStr)
        Dim cmdExcel As New OleDbCommand()
        Dim oda As New OleDbDataAdapter()
        Dim dt As New DataTable()

        cmdExcel.Connection = connExcel

        'Get the name of First Sheet 
        connExcel.Open()
        Dim dtExcelSchema As DataTable
        dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
        Dim SheetName As String = dtExcelSchema.Rows(0)("TABLE_NAME").ToString()
        connExcel.Close()

        'Read Data from First Sheet 
        connExcel.Open()
        cmdExcel.CommandText = "SELECT * From [" & SheetName & "]"
        oda.SelectCommand = cmdExcel
        oda.Fill(dt)
        connExcel.Close()

        'Bind Data to GridView 

        Update_To_DB(dt)

    End Sub

    Private Sub Update_To_DB(ByVal dt As DataTable)
        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("SQLServer").ConnectionString)
        Dim cmd As New SqlCommand()
        Dim sql As String = ""
        Dim sqlVal As String = ""

        Dim curHeadCnt As Integer = 0, OrderHeadId As Integer = 0

        conn.Open()
        cmd.Connection = conn

        Dim dtHead As New DataTable, drDtls() As DataRow

		dtHead = dt.DefaultView.ToTable(True, {"CustomerCode", "OrderDate","ShipTo"})

        For Each drHead As DataRow In dtHead.Rows
            curHeadCnt = GetCurrentOrderHeadCount()

            sql = "INSERT INTO OrderHead(OrderNum, CustomerCode, OrderDate, ShipTo, CreationDate, Status,CreationBy,Curr) Values("

            sqlVal = "'" + (curHeadCnt + 1).ToString("00000#") + "',"
            sqlVal += "'" + drHead.Item("CustomerCode") + "',"
            sqlVal += "CONVERT(datetime, '" + drHead.Item("OrderDate") + "', 102),"
            sqlVal += "'" & drHead.Item("ShipTo") & "',"
            sqlVal += "GETDATE(),"
            sqlVal += "'PENDING','" & WebLib.UserCode & "','" & WebLib.UserCurrency & "'"

            sql += sqlVal + "); SELECT SCOPE_IDENTITY()"

            cmd.CommandType = CommandType.Text
            cmd.CommandText = sql
            OrderHeadId = cmd.ExecuteScalar()

            drDtls = dt.Select("CustomerCode = '" & drHead.Item("CustomerCode") + "' AND OrderDate = '" & drHead.Item("OrderDate") & "'")

            For Each drDtl As DataRow In drDtls
                sql = "INSERT INTO OrderDtl(OrderHeadID, ItemCode, ItemDesc, Qty, UOM, Colour, Size, CreationDate) Values("

                sqlVal = OrderHeadId.ToString() + ","
                sqlVal += "'" + drDtl.Item("ItemCode") + "',"
                sqlVal += "'" + drDtl.Item("ItemDesc") + "',"
                sqlVal += drDtl.Item("Qty").ToString() + ","
                sqlVal += "'" + drDtl.Item("UOM") + "',"
                sqlVal += "'" + drDtl.Item("Colour") + "',"
                sqlVal += "'" + drDtl.Item("Size").ToString() + "',"
                sqlVal += "GETDATE()"

                sql += sqlVal + ")"

                cmd.CommandType = CommandType.Text
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
            Next

        Next

        conn.Close()
        conn.Dispose()
        cmd.Dispose()

        Response.Redirect("MyAccounts.aspx")

    End Sub

    Private Function GetCurrentOrderHeadCount() As Integer
        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("SQLServer").ConnectionString)
        Dim cmd As New SqlCommand()
        Dim sql As String = ""
        Dim counter As Integer = 0

        conn.Open()
        cmd.Connection = conn

        sql = "SELECT ISNULL(MAX(OrderNum), 0) FROM OrderHead"

        cmd.CommandText = sql
        counter = cmd.ExecuteScalar()

        conn.Close()
        conn.Dispose()
        cmd.Dispose()

        Return counter

    End Function




End Class

