Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class zonesupload_class

    Inherits basepagelist
    Dim lpath As String = "temp/data/"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = ""
        PageTitle = "Warehouse Setup Upload"
        ActionType = "WSU"
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

        Return ooCM.BRANCHSetupTempData("temp_createby='" & WebLib.UserID & "'", "order by temp_id asc")


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
        Dim lstyle As String = ""

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


            lstyle = ""
            If (drv.Row("temp_bssuid").ToString.Trim <> "") Then
                lstyle = " style=""background-color:" & TableUtils.ErrorBGColor & ";"" "
                sb.Append("<td" & lstyle & ">" & "Existing" & "</td>")
            Else
                sb.Append("<td><b>" & "New" & "</b></td>")

            End If


            sb.Append("<td>" & drv.Row("temp_companycode").ToString.Trim & "</td>")

            lstyle = ""
            If (drv.Row("temp_branchid").ToString.Trim = "") Then
                lstyle = " style=""background-color:" & TableUtils.ErrorBGColor & ";"" "
            End If

            sb.Append("<td" & lstyle & ">" & drv.Row("temp_branchcode").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("br_name").ToString.Trim & "</td>")



            lstyle = ""
            If (drv.Row("temp_storageuid").ToString.Trim = "" And drv.Row("temp_storage").ToString.Trim <> "") Then
                lstyle = " style=""background-color:" & TableUtils.ErrorBGColor & ";"" "
            End If

            sb.Append("<td" & lstyle & ">" & drv.Row("temp_storage").ToString.Trim & "</td>")



            lstyle = ""
            If (drv.Row("temp_zoneuid").ToString.Trim = "" And drv.Row("temp_zone").ToString.Trim <> "") Then
                lstyle = " style=""background-color:" & TableUtils.ErrorBGColor & ";"" "
            End If
            sb.Append("<td" & lstyle & ">" & drv.Row("temp_zone").ToString.Trim & "</td>")


            lstyle = ""
            If (drv.Row("temp_locationuid").ToString.Trim = "") Then
                lstyle = " style=""background-color:" & TableUtils.ErrorBGColor & ";"" "
            End If
            sb.Append("<td" & lstyle & ">" & drv.Row("temp_location").ToString.Trim & "</td>")


            sb.Append("<td>" & drv.Row("temp_row").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_level").ToString.Trim & "</td>")

            sb.Append("<td>" & drv.Row("temp_forbulk").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_forhighf").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_forhighv").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_forcrossdock").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_ranking").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_size").ToString.Trim & "</td>")
            sb.Append("</tr>")
            objdata.Text = sb.ToString()

        End If
    End Sub
    Protected Sub initTables()
        Dim lColumnNames As String = ""

        lColumnNames = lColumnNames & "columns: ["
        lColumnNames = lColumnNames & "{ name: 'uid' },"
        lColumnNames = lColumnNames & "{ name: 'validated' },"
        lColumnNames = lColumnNames & "{ name: 'status' },"
        lColumnNames = lColumnNames & "{ name: 'company' },"
        lColumnNames = lColumnNames & "{ name: 'branch' },"
        lColumnNames = lColumnNames & "{ name: 'branchname' },"
        lColumnNames = lColumnNames & "{ name: 'storage' },"
        lColumnNames = lColumnNames & "{ name: 'zone' },"
        lColumnNames = lColumnNames & "{ name: 'loc' },"
        lColumnNames = lColumnNames & "{ name: 'row' },"
        lColumnNames = lColumnNames & "{ name: 'level' },"
        lColumnNames = lColumnNames & "{ name: 'bulk' },"
        lColumnNames = lColumnNames & "{ name: 'highf' },"
        lColumnNames = lColumnNames & "{ name: 'highv' },"
        lColumnNames = lColumnNames & "{ name: 'crossdock' },"
        lColumnNames = lColumnNames & "{ name: 'ranking' },"
        lColumnNames = lColumnNames & "{ name: 'size' }"
        lColumnNames = lColumnNames & "],"


        litthead.Text = "<thead><tr>" & _
                         "<th>UID</th>" & _
                         "<th>Validated</th>" & _
                         "<th>Status</th>" & _
                         "<th>Company</th>" & _
                         "<th>Branch Code</th>" & _
                         "<th>Branch Name</th>" & _
                         "<th>Storage Type</th>" & _
                         "<th>Zone</th>" & _
                         "<th>Location</th>" & _
                         "<th>Row</th>" & _
                         "<th>Level</th>" & _
                         "<th>For Bulk Item</th>" & _
                         "<th>For High Frequency</th>" & _
                         "<th>For High Value</th>" & _
                         "<th>For Cross Dock</th>" & _
                         "<th>Priority</th>" & _
                         "<th>Size M3</th>" & _
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

        If ooCM.BRANCHSetupValidateTempData(WebLib.UserID) = False Then
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

        If ooCM.BRANCHSetupConfirmTempData(WebLib.UserID) = False Then
            ShowPromptV2("Error Processing Data. Please retry")
        Else
            ShowPromptV2("Import Successful")
            Call loaddata("")
        End If

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

        If ooCM.BRANCHSetupDeleteTempData(table1sel0.Value, WebLib.UserID) = False Then
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

        If ooCM.BranchSetupDeleteTempData("ALL", WebLib.UserID) = False Then
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

		dtHead = dt.DefaultView.ToTable(True, {"Company","Branch Code","Branch Name","Storage Type","Zone","Location","Row","Level", _
                                            "For Bulk","For High Frequency","For High Value","For Cross Dock","Priority","Storage Size M3"})
        For Each drHead As DataRow In dtHead.Rows


            Dim lSize As String

            Try
                lsize = drHead.Item("Storage Size M3") & ""
            Catch ex As Exception
                lsize = ""
            End Try
            If isnumeric(lSize) = False Then
                lsize = "NULL"
            Else
                lsize = "'" & lsize & "'"
            End If

            Dim lrow As String

            Try
                lrow = drHead.Item("Row") & ""
            Catch ex As Exception
                lrow = ""
            End Try
            If (lrow.TRIM) = "" Then
                lrow = "NULL"
            Else
                lrow = "'" & lrow & "'"
            End If

            Dim llevel As String
            Try
                llevel = drHead.Item("Level") & ""

            Catch ex As Exception
                llevel = ""
            End Try
            If (llevel.TRIM) = "" Then
                llevel = "NULL"
            Else
                LLEVEL = "'" & LLEVEL & "'"
            End If

            If (drHead.Item("Location").ToString()).Trim <> "" And (drHead.Item("Branch Code").ToString()).Trim <> "" Then
                luid = ooo.GetUniqueGUID
                sqlVal = "INSERT INTO OfficeOneBI.dbo.zzzTEMPBranchSetup(temp_companycode,temp_branchcode,temp_zone,temp_location,temp_storage,"
                sqlVal += "temp_forbulk,temp_forhighf,temp_forhighv,temp_forcrossdock,temp_ranking,temp_size,temp_row,temp_level,"
                sqlVal += "temp_uid,temp_createdt,temp_createby,temp_merchantid,temp_filter"
                sqlVal += ") Values("
                sqlVal += ""
                sqlVal += "'" + drHead.Item("Company").ToString() + "',"
                sqlVal += "'" + OfficeOne.Gen.Library.Utility.CheckText(drHead.Item("Branch Code").ToString()) + "',"
                sqlVal += "'" + OfficeOne.Gen.Library.Utility.CheckText(drHead.Item("Zone").ToString()) + "',"
                sqlVal += "'" + OfficeOne.Gen.Library.Utility.CheckText(drHead.Item("Location").ToString()) + "',"
                sqlVal += "'" + drHead.Item("Storage Type").ToString() + "',"
                sqlVal += "'" + drHead.Item("For Bulk").ToString() + "',"
                sqlVal += "'" + drHead.Item("For High Frequency").ToString() + "',"
                sqlVal += "'" + drHead.Item("For High Value").ToString() + "',"
                sqlVal += "'" + drHead.Item("For Cross Dock").ToString() + "',"
                sqlVal += "'" + drHead.Item("Priority").ToString() + "',"
                sqlVal += "" + lsize + ","
                sqlVal += "" + lrow + ","
                sqlVal += "" + llevel + ","
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

