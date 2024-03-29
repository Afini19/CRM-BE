Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class uomupload_class

    Inherits basepagelist
    Dim lpath As String = "temp/data/"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = ""
        PageTitle = "UOM Upload"
        ActionType = "UOMU"
        FieldUID = ""
        FieldMerchantID = ""
        FieldDefaultSort = ""
        PageDetail = ""
        PageListing = "menudata.aspx"
        PageListsize = 1000

        PageListsize = 1000
        Framework_Back = PageListing
        Framework_SearchGrid = True
        Framework_DBSearch = True

        GenLeftBar()

        If Page.IsPostBack = False Then
            WebLib.ActionUID = ""
            Call initTables()
            Call loaddata(DBSQL)
        End If

        uploadbutton.CssClass = TableUtils.btnprimary
        btnstep2.CssClass = TableUtils.btnprimary2
        btnstep3.CssClass = TableUtils.btnprimary3

    End Sub

    Protected Sub GenLeftBar()
        Dim sb As New StringBuilder
        sb.AppendLine("<span style=""display:flex;"">")
        sb.AppendLine(TableUtils.GenBarOptions("delete", "Delete Selected", "DELETE", eventtype.ClientID, eventfirenorm.ClientID, "", ""))
        sb.AppendLine(TableUtils.GenBarSeparator())
        sb.AppendLine(TableUtils.GenBarOptions("clear", "Clear All", "CLEAR", eventtype.ClientID, eventfirenorm.ClientID, "", ""))
        sb.AppendLine("</span>")

        Framework_LeftNavBar = sb.ToString()
    End Sub
    Protected Function LoadSQLfromCloud() As DataSet

        Dim ooCM As New OfficeOne.WebServices.BLogic.DataAdmin
        ooCM.ConnectionString = DBConnection
        ooCM.MerchantMerchantID = WebLib.MerchantID
        ooCM.MerchantFilter = WebLib.FilterCode

        Return ooCM.UOMGetTempData("temp_createby='" & WebLib.UserID & "'", "order by temp_id asc")


    End Function
    Protected Sub TakeAction()
        If eventtype.Value = "CLEAR" Then
            Call clearall()
        End If
        If eventtype.Value = "DELETE" Then
            Call deleteline()
        End If
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
            sb.Append("<td>" & drv.Row("temp_uid").ToString.Trim & "</td>")

            Dim lValidated As String = ""

            If OfficeOne.Gen.Library.Utility.BitToBoolean(drv.Row("temp_validated").ToString.Trim) = True Then
                lValidated = "<span style=""color:blue"">Yes</span>"
            Else
                lValidated = "<span style=""color:red"">No</span>"

            End If
            sb.Append("<td>" & lValidated & "</td>")


            Dim lstyle As String = ""


            sb.Append("<td>" & drv.Row("temp_companycode").ToString.Trim & "</td>")


            lstyle = ""
            If (drv.Row("temp_partuid").ToString.Trim = "") Then
                lstyle = " style=""background-color:" & TableUtils.ErrorBGColor & ";"" "
            End If

            sb.Append("<td" & lstyle & ">" & drv.Row("temp_partno").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("pt_desc1").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_uom").ToString.Trim & "</td>")

            lstyle = ""
            If IsNumeric(drv.Row("temp_factor").ToString) = False Then
                lstyle = " style=""background-color:" & TableUtils.ErrorBGColor & ";"" "
            End If


            sb.Append("<td" & lstyle & ">" & drv.Row("temp_factor").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_iuom").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_forsales").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_forpurchase").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_forassembly").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_forissue").ToString.Trim & "</td>")
            lstyle = ""
            If (drv.Row("temp_uomuid").ToString.Trim <> "") Then
                lstyle = " style=""background-color:" & TableUtils.ErrorBGColor & ";"" "
                sb.Append("<td" & lstyle & ">" & "Existing" & "</td>")
            Else
                sb.Append("<td><b>" & "New" & "</b></td>")

            End If


            sb.Append("</tr>")
            objdata.Text = sb.ToString()

        End If
    End Sub
    Protected Sub initTables()
        Dim lColumnNames As String = ""

        lColumnNames = lColumnNames & "columns: ["
        lColumnNames = lColumnNames & "{ name: 'uid' },"
        lColumnNames = lColumnNames & "{ name: 'validated' },"
        lColumnNames = lColumnNames & "{ name: 'company' },"
        lColumnNames = lColumnNames & "{ name: 'product' },"
        lColumnNames = lColumnNames & "{ name: 'productname' },"
        lColumnNames = lColumnNames & "{ name: 'uom' },"
        lColumnNames = lColumnNames & "{ name: 'factor' },"
        lColumnNames = lColumnNames & "{ name: 'baseuom' },"
        lColumnNames = lColumnNames & "{ name: 'sales' },"
        lColumnNames = lColumnNames & "{ name: 'purchase' },"
        lColumnNames = lColumnNames & "{ name: 'assembly' },"
        lColumnNames = lColumnNames & "{ name: 'issue' },"
        lColumnNames = lColumnNames & "{ name: 'status' }"
        lColumnNames = lColumnNames & "],"

        litthead.Text = "<thead><tr>" & _
                         "<th>UID</th>" & _
                         "<th>Validated</th>" & _
                         "<th>Company</th>" & _
                         "<th>Product Code</th>" & _
                         "<th>Product Name</th>" & _
                         "<th>UOM</th>" & _
                         "<th>Factor</th>" & _
                         "<th>Base UOM</th>" & _
                         "<th>For Sales</th>" & _
                         "<th>For Purchase</th>" & _
                         "<th>For Assembly</th>" & _
                         "<th>For Distribute</th>" & _
                         "<th>Status</th>" & _
                         "</tr></thead>"
        littfoot.Text = ""
        litsettings.Text = TableUtils.GetStandard("caishtb", False, False, False, , , , , lColumnNames)
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


        Dim ooCM As New OfficeOne.WebServices.BLogic.DataAdmin
        ooCM.ConnectionString = DBConnection
        ooCM.MerchantMerchantID = WebLib.MerchantID
        ooCM.MerchantFilter = WebLib.FilterCode

        Try

            If ooCM.UOMValidateTempData(WebLib.UserID) = False Then
                ShowPromptV2("Error Processing Data. Please retry")
            Else
                Call loaddata("")
            End If

        Catch ex As Exception
            ShowPromptV2("Error Processing Data. Please retry : " & ex.Message)

        End Try

    End Sub
    Public Sub confirmdata(ByVal sender As System.Object, ByVal e As System.EventArgs)


        Dim ooCM As New OfficeOne.WebServices.BLogic.DataAdmin
        ooCM.ConnectionString = DBConnection
        ooCM.MerchantMerchantID = WebLib.MerchantID
        ooCM.MerchantFilter = WebLib.FilterCode

        Try

            If ooCM.UOMConfirmTempData(WebLib.UserID) = False Then
                ShowPromptV2("Error Processing Data. Please retry")
            Else
                ShowPromptV2("Import Successful")
                Call loaddata("")
            End If
        Catch ex As Exception
            ShowPromptV2("Error Processing Data. Please retry : " & ex.Message)

        End Try

    End Sub
    Public Sub deleteline()

        If (table1sel0.Value & "").Trim = "" Then
            ShowAlert("Please Select a Record")
            Exit Sub
        End If


        Dim ooCM As New OfficeOne.WebServices.BLogic.DataAdmin
        ooCM.ConnectionString = DBConnection
        ooCM.MerchantMerchantID = WebLib.MerchantID
        ooCM.MerchantFilter = WebLib.FilterCode

        If ooCM.UOMDeleteTempData(table1sel0.Value, WebLib.UserID) = False Then
            ShowPromptV2("Error Processing Data. Please retry")
        Else
            Call loaddata("")
        End If
    End Sub
    Public Sub clearall()
        Dim ooCM As New OfficeOne.WebServices.BLogic.DataAdmin
        ooCM.ConnectionString = DBConnection
        ooCM.MerchantMerchantID = WebLib.MerchantID
        ooCM.MerchantFilter = WebLib.FilterCode

        If ooCM.UOMDeleteTempData("ALL", WebLib.UserID) = False Then
            ShowPromptV2("Error Processing Data. Please retry")
        Else
            Call loaddata("")
        End If
    End Sub
    Public Sub eventfiresub(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call TakeAction()
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

                    If File.Exists(FilePath) = True Then
                        Call UpdateToDB(WebUtils.ExcelToDT(FilePath, Extension, "Yes"))

                        Try
                            Kill(FilePath)
                        Catch ex As Exception

                        End Try

                    End If
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
        Dim luid As String = ""
        Dim ooo As New OfficeOne.Gen.Library.Utility
        Dim dtHead As New DataTable

		dtHead = dt.DefaultView.ToTable(True, {"Company","Part No","UOM","Factor","Base UOM","For Sales","For Purchase","For Assembly","For Distribute"})
        For Each drHead As DataRow In dtHead.Rows

            If (drHead.Item("UOM").ToString()).Trim <> "" Then
                luid = ooo.GetUniqueGUID
                sqlVal = "INSERT INTO OfficeOneBI.dbo.zzzTEMPProductUOM(temp_companycode,temp_partno,temp_uom,temp_factor, temp_iuom, temp_forsales,temp_forpurchase,temp_forassembly,temp_forissue,temp_uid,temp_createdt,temp_createby,temp_merchantid,temp_filter) Values("
                sqlVal += ""
                sqlVal += "'" + drHead.Item("Company").ToString() + "',"
                sqlVal += "'" + drHead.Item("Part No").ToString() + "',"
                sqlVal += "'" + drHead.Item("UOM").ToString() + "',"
                sqlVal += "'" + drHead.Item("Factor").ToString() + "',"
                sqlVal += "'" + drHead.Item("Base UOM").ToString() + "',"
                sqlVal += "'" + drHead.Item("For Sales").ToString() + "',"
                sqlVal += "'" + drHead.Item("For Purchase").ToString() + "',"
                sqlVal += "'" + drHead.Item("For Assembly").ToString() + "',"
                sqlVal += "'" + drHead.Item("For Distribute").ToString() + "',"
                sqlVal += "'" & luid & "',"
                sqlVal += "GETDATE(),'" & WebLib.UserID & "','" & WebLib.MerchantID & "','" & WebLib.FilterCode & "')"

                cmd.CommandText = sqlVal
                cmd.ExecuteNonQuery()
            End If
        Next

        conn.Close()
        conn.Dispose()
        cmd.Dispose()

        Call loaddata("")
    End Sub
End Class

