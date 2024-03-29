Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class branchclassitemlistupload_class

    Inherits basepagelist
    Dim lpath As String = "temp/bclass/"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = "branchstockstemp"
        PageTitle = "Manage Article by Branch Class"
        ActionType = "ID"
        FieldUID = ""
        FieldMerchantID = ""
        FieldDefaultSort = ""
        PageDetail = ""

        PageListsize = 1000

        If Page.IsPostBack = False Then
            WebLib.ActionUID = ""
            Call initTables()
            Call loaddata(DBSQL)
        End If

        uploadbutton.CssClass = TableUtils.btnprimary
        btnstep2.CssClass = TableUtils.btnprimary2
        btnstep3.CssClass = TableUtils.btnprimary3
        btnback.CssClass = TableUtils.btnprimary4
    End Sub
    Protected Function LoadSQLfromCloud() As DataSet

        Dim oo As New OfficeOne.WebServices.BLogic.GenericAction
        oo.ConnectionString = DBConnection
        oo.MerchantMerchantID = Weblib.MErchantID
        oo.MerchantFilter = Weblib.FilterCode

        Return oo.TakeActionRetrievalDataDS("GENCLASSV2", "getstocksbybranchclasstemp", "", "bs_createby='" & weblib.UserID & "'", "", "")



    End Function
    Protected Sub TakeAction()
        WebLib.ActionType = "BC"
        WebLib.ActionUID = ""
        WebLib.ActionParam1 = eventtype.Value
        Server.Transfer(PageDetail)
    End Sub
    Protected Sub rep_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs)

    End Sub
    Protected Sub rep_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rep.ItemDataBound

        Dim drv As DataRowView
        drv = e.Item.DataItem
        Dim sb As System.Text.StringBuilder
        Dim objdata As Literal = e.Item.FindControl("litTableRows")
        If Not objdata Is Nothing Then
            Dim ldata As String = ""

            sb = New System.Text.StringBuilder
            sb.Append("<tr>")
            sb.Append("<td>" & drv.Row("bs_uid").ToString.Trim & "</td>")

            Dim lValidated As String = ""

            If OfficeOne.Gen.Library.Utility.BitToBoolean(drv.Row("bs_validated").ToString.Trim) = True Then
                lValidated = "<span style=""color:blue"">Yes</span>"
            Else
                lValidated = "<span style=""color:red"">No</span>"

            End If
            sb.Append("<td>" & lValidated & "</td>")
            sb.Append("<td>" & drv.Row("bs_companycode").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("bs_type").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("bs_partno").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("pt_desc1").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("bs_uom").ToString.Trim & "</td>")
            sb.Append("</tr>")
            objdata.Text = sb.ToString()

        End If
    End Sub
    Protected Sub initTables()
        litthead.Text = "<thead><tr>" & _
                         "<th>UID</th>" & _
                         "<th>Validated</th>" & _
                         "<th>Company</th>" & _
                         "<th>Branch Class</th>" & _
                         "<th>Article Number</th>" & _
                         "<th>Article Name</th>" & _
                         "<th>Base UOM</th>" & _
                         "</tr></thead>"
        littfoot.text = ""
        litsettings.Text = TableUtils.GetStandard("caishtb", True, False)
    End Sub
    Public Sub loaddata(ByVal SQLQuery As String)
        Dim ds As New DataSet()


        Try
            ds = LoadSQLfromCloud()
            If ds Is Nothing Then
                Exit Sub
            End If

            Dim dt As DataTable = ds.Tables(0)
            Dim dv As New DataView(dt)

            Dim pgitems As New PagedDataSource()
            pgitems.DataSource = dv
            pgitems.AllowPaging = False

            rep.DataSource = pgitems
            rep.DataBind()

        Catch ex As Exception
            ShowAlert("Error : Loading Data")
        End Try

    End Sub
    Public Sub validatedata(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim oo As New OfficeOne.WebServices.BLogic.GenericAction
        oo.ConnectionString = DBConnection
        oo.MerchantMerchantID = Weblib.MErchantID
        oo.MerchantFilter = Weblib.FilterCode

        Dim rtnobject As Boolean
        rtnobject = oo.TakeActionBoolean("VALIDATEBRANCHCLASSITEMTEMP", "", "", "", "", "", , , "", , "", weblib.UserID)
        If rtnobject = False Then
            ShowPromptV2("Error Processing Data. Please retry")
        Else
            Call loaddata("")
        End If

    End Sub
    Public Sub confirmdata(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim oo As New OfficeOne.WebServices.BLogic.GenericAction
        oo.ConnectionString = DBConnection
        oo.MerchantMerchantID = Weblib.MErchantID
        oo.MerchantFilter = Weblib.FilterCode

        Dim rtnobject As Boolean
        rtnobject = oo.TakeActionBoolean("CONFIRMBRANCHCLASSITEMTEMP", "", "", "", "", "", , , "", , "", weblib.UserID)
        If rtnobject = False Then
            ShowPromptV2("Error Processing Data. Please retry")
        Else
            Call loaddata("")
        End If

    End Sub
    Public Sub deleteline(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oo As New OfficeOne.WebServices.BLogic.GenericAction
        oo.ConnectionString = DBConnection
        oo.MerchantMerchantID = Weblib.MErchantID
        oo.MerchantFilter = Weblib.FilterCode

        Dim rtnobject As Boolean
        rtnobject = oo.TakeActionBoolean("DELETEBRANCHCLASSITEMTEMPLINE", table1sel.Value, "", "", "", "", , , "", , "", weblib.UserID)
        If rtnobject = False Then
            ShowPromptV2("Error Processing Data. Please retry")
        Else
            Call loaddata("")
        End If
    End Sub
    Public Sub eventfiresub(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call TakeAction()
    End Sub
    Public Sub backback(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Response.Redirect("branchclassitemlist.aspx")
    End Sub
    Public Sub editdelivery(ByVal sender As System.Object, ByVal e As System.EventArgs)

        WebLib.ActionUID = table1sel.Value
        WebLib.ActionType = ActionType
        '        response.redirect("DeliveryIncomingEdit.aspx")

    End Sub
    Public Sub UploadFile(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Page.IsPostBack = True Then
            Dim str1 As String = UploadedFile.PostedFile.FileName
            If WebUtils.FileFieldSelected(UploadedFile) = False Then
                ShowAlert("No file selected or the file is 0 bytes")
                Exit Sub
            Else

                Dim FilePath As String = Server.MapPath(lpath & Webutils.RetrieveFileName(UploadedFile))
                Dim Extension As String = Path.GetExtension(Webutils.RetrieveFileName(UploadedFile))

                Try
                    WebUtils.inituploads(Server.MapPath(lpath))
                    UploadedFile.PostedFile.SaveAs(FilePath)
                    Call UpdateToDB(webUtils.ExcelToDT(FilePath, Extension, "Yes"))

                Catch ex As SystemException
                    Response.Write(ex.Message)
                    Response.End()
                    ShowPromptV2("Your browser security has blocked you from uploading")
                    Exit Sub
                End Try

            End If
        End If


    End Sub


    Private Sub UpdateToDB(ByVal dt As DataTable)
        Dim conn As New OleDbConnection(DBConnection)
        Dim cmd As New OleDbCommand
        Dim sql As String = ""
        Dim sqlVal As String = ""

        conn.Open()
        cmd.Connection = conn

        cmd.CommandType = CommandType.Text

        cmd.CommandText = "Delete from " & DBTableName & " where bs_createby='" & weblib.UserID & "' and  bs_merchantid='" & weblib.merchantid & "' and bs_filter='" & weblib.filtercode & "'"
        cmd.ExecuteNonQuery()

        Dim luid As String = ""
        Dim ooo As New OfficeOne.Gen.Library.Utility
        Dim dtHead As New DataTable

		dtHead = dt.DefaultView.ToTable(True, {"Company", "Type","Article Number","Article Description","UOM"})



        For Each drHead As DataRow In dtHead.Rows

            luid = ooo.GetUniqueGUID
            sqlVal = "INSERT INTO  " & DBTableName & " (bs_companycode,bs_type,bs_partno,bs_uid,bs_uom,bs_createdt,bs_createby,bs_merchantid,bs_filter) Values("
            sqlVal += ""
            sqlVal += "'" + drHead.Item("Company").ToString() + "',"
            sqlVal += "'" + drHead.Item("Type").ToString() + "',"
            sqlVal += "'" + drHead.Item("Article Number").ToString() + "',"
            sqlVal += "'" & luid & "',"
            sqlVal += "'" & drHead.Item("UOM").ToString() & "',"
            sqlVal += "GETDATE(),'" & weblib.UserID & "','" & weblib.merchantid & "','" & weblib.filtercode & "')"

            cmd.CommandText = sqlVal
            cmd.ExecuteNonQuery()

        Next

        conn.Close()
        conn.Dispose()
        cmd.Dispose()

        Call loaddata("")
    End Sub

End Class

