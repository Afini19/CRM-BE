Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class pluupload_class

    Inherits basepagelist
    Dim lpath As String = "temp/data/"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = ""
        PageTitle = "PLU Upload"
        ActionType = "PLUU"
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

        Return ooCM.PLUGetTempData("temp_createby='" & WebLib.UserID & "'", "order by temp_id asc")


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
            sb.Append("<td>" & drv.Row("temp_plu").ToString.Trim & "</td>")

            lstyle = ""
            If (drv.Row("temp_uomuid").ToString.Trim = "") Then
                lstyle = " style=""background-color:" & TableUtils.ErrorBGColor & ";"" "
            End If

            sb.Append("<td" & lstyle & ">" & drv.Row("temp_uom").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_att1").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_att2").ToString.Trim & "</td>")

            lstyle = ""
            If (drv.Row("temp_pluuid").ToString.Trim <> "") Then
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
        lColumnNames = lColumnNames & "{ name: 'plu' },"
        lColumnNames = lColumnNames & "{ name: 'pluuom' },"
        lColumnNames = lColumnNames & "{ name: 'att1' },"
        lColumnNames = lColumnNames & "{ name: 'att2' },"
        lColumnNames = lColumnNames & "{ name: 'status' }"
        lColumnNames = lColumnNames & "],"

        litthead.Text = "<thead><tr>" & _
                         "<th>UID</th>" & _
                         "<th>Validated</th>" & _
                         "<th>Company</th>" & _
                         "<th>Product Code</th>" & _
                         "<th>Product Name</th>" & _
                         "<th>PLU</th>" & _
                         "<th>PLU UOM</th>" & _
                         "<th>Attribute 1</th>" & _
                         "<th>Attribute 2</th>" & _
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

        If ooCM.PLUValidateTempData(WebLib.UserID) = False Then
            ShowPromptV2("Error Processing Data. Please retry")
        Else
            Call loaddata("")
        End If

    End Sub
    Public Sub confirmdata(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim ooCM As New OfficeOne.WebServices.BLogic.DataAdmin
        ooCM.ConnectionString = DBConnection
        ooCM.MerchantMerchantID = WebLib.MerchantID
        ooCM.MerchantFilter = WebLib.FilterCode

        Try

            If ooCM.PLUConfirmTempData(WebLib.UserID) = False Then
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

        If ooCM.PLUDeleteTempData(table1sel0.Value, WebLib.UserID) = False Then
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

        If ooCM.PLUDeleteTempData("ALL", WebLib.UserID) = False Then
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

		dtHead = dt.DefaultView.ToTable(True, {"Company","Part No","Barcode","UOM","Attribute 1","Attribute 2"})
        For Each drHead As DataRow In dtHead.Rows

            If (drHead.Item("Barcode").ToString()).trim <> "" Then
                luid = ooo.GetUniqueGUID
                sqlVal = "INSERT INTO OfficeOneBI.dbo.zzzTEMPProductPLU(temp_companycode,temp_partno,temp_plu,temp_uom, temp_att1, temp_att2,temp_uid,temp_createdt,temp_createby,temp_merchantid,temp_filter) Values("
                sqlVal += ""
                sqlVal += "'" + drHead.Item("Company").ToString() + "',"
                sqlVal += "'" + drHead.Item("Part No").ToString() + "',"
                sqlVal += "'" + drHead.Item("Barcode").ToString() + "',"
                sqlVal += "'" + drHead.Item("UOM").ToString() + "',"
                sqlVal += "'" + drHead.Item("Attribute 1").ToString() + "',"
                sqlVal += "'" + drHead.Item("Attribute 2").ToString() + "',"
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

