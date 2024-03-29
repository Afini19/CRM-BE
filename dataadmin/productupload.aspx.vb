Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class productupload_class

    Inherits basepagelist
    Dim lpath As String = "temp/data/"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = ""
        PageTitle = "Product Upload"
        ActionType = "PROU"
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

        Return ooCM.PRODUCTGetTempData("temp_createby='" & WebLib.UserID & "'", "order by temp_id asc")


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
            sb.Append("<td>" & drv.Row("temp_partdesc1").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_partdesc2").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_partum").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_manuallot").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_mustlot").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_issuetype").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_att1").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_att2").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_cpitem").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_nonreturn").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_taxmethod").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_purtaxcode").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_salestaxcode").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_m2").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_m3").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_weight").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_expiryitem").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_minexpirydays").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_shelflife").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_owner").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_highfreq").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_bulkitem").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_crossdockitem").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_basewidth").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_baseheight").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_basethick").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_outerwidth").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_outerheight").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_outerthick").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_innerwidth").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_innerheight").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_innerthick").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_storagetype").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_tariffcode").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("temp_costingmethod").ToString.Trim & "</td>")

            lstyle = ""
            If (drv.Row("temp_partuid").ToString.Trim <> "") Then
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
        lColumnNames = lColumnNames & "{ name: 'desc2' },"
        lColumnNames = lColumnNames & "{ name: 'uom' },"
        lColumnNames = lColumnNames & "{ name: 'mlot' },"
        lColumnNames = lColumnNames & "{ name: 'lotc' },"
        lColumnNames = lColumnNames & "{ name: 'issuetype' },"
        lColumnNames = lColumnNames & "{ name: 'att1' },"
        lColumnNames = lColumnNames & "{ name: 'att2' },"
        lColumnNames = lColumnNames & "{ name: 'centralp' },"
        lColumnNames = lColumnNames & "{ name: 'nonreturn' },"
        lColumnNames = lColumnNames & "{ name: 'tax' },"
        lColumnNames = lColumnNames & "{ name: 'ptax' },"
        lColumnNames = lColumnNames & "{ name: 'stax' },"
        lColumnNames = lColumnNames & "{ name: 'm2' },"
        lColumnNames = lColumnNames & "{ name: 'm3' },"
        lColumnNames = lColumnNames & "{ name: 'weight' },"
        lColumnNames = lColumnNames & "{ name: 'exp' },"
        lColumnNames = lColumnNames & "{ name: 'minexp' },"
        lColumnNames = lColumnNames & "{ name: 'shelf' },"
        lColumnNames = lColumnNames & "{ name: 'owner' },"
        lColumnNames = lColumnNames & "{ name: 'hf' },"
        lColumnNames = lColumnNames & "{ name: 'bi' },"
        lColumnNames = lColumnNames & "{ name: 'cd' },"
        lColumnNames = lColumnNames & "{ name: 'bwidth' },"
        lColumnNames = lColumnNames & "{ name: 'bheight' },"
        lColumnNames = lColumnNames & "{ name: 'bthick' },"
        lColumnNames = lColumnNames & "{ name: 'owidth' },"
        lColumnNames = lColumnNames & "{ name: 'oheight' },"
        lColumnNames = lColumnNames & "{ name: 'othick' },"
        lColumnNames = lColumnNames & "{ name: 'iwidth' },"
        lColumnNames = lColumnNames & "{ name: 'iheight' },"
        lColumnNames = lColumnNames & "{ name: 'ithick' },"
        lColumnNames = lColumnNames & "{ name: 'stype' },"
        lColumnNames = lColumnNames & "{ name: 'tariffcode' },"
        lColumnNames = lColumnNames & "{ name: 'costing' },"
        lColumnNames = lColumnNames & "{ name: 'status' }"
        lColumnNames = lColumnNames & "],"


        litthead.Text = "<thead><tr>" & _
                         "<th>UID</th>" & _
                         "<th>Validated</th>" & _
                         "<th>Company</th>" & _
                         "<th>Product Code</th>" & _
                         "<th>Product Name</th>" & _
                         "<th>Product Desc</th>" & _
                         "<th>Base UOM</th>" & _
                         "<th>Manual Lot</th>" & _
                         "<th>Lot Compulsory</th>" & _
                         "<th>Issue Type</th>" & _
                         "<th>Attribute 1</th>" & _
                         "<th>Attribute 2</th>" & _
                         "<th>Central Purchase</th>" & _
                         "<th>Not Returnable</th>" & _
                         "<th>Tax Method</th>" & _
                         "<th>Purchase Tax Code</th>" & _
                         "<th>Sales Tax Code</th>" & _
                         "<th>M2</th>" & _
                         "<th>M3</th>" & _
                         "<th>Weight(kg)</th>" & _
                         "<th>Expiry Item</th>" & _
                         "<th>Min Expiry Days</th>" & _
                         "<th>Shelf Life</th>" & _
                         "<th>Product Owner</th>" & _
                         "<th>High Frequency Item</th>" & _
                         "<th>Bulk Item</th>" & _
                         "<th>Cross Dock Item</th>" & _
                         "<th>Base Width</th>" & _
                         "<th>Base Height</th>" & _
                         "<th>Base Thickness</th>" & _
                         "<th>Outer Width</th>" & _
                         "<th>Outer Height</th>" & _
                         "<th>Outer Thickness</th>" & _
                         "<th>Inner Width</th>" & _
                         "<th>Inner Height</th>" & _
                         "<th>Inner Thickness</th>" & _
                         "<th>Storage Type</th>" & _
                         "<th>Tariff Code</th>" & _
                         "<th>Costing Method</th>" & _
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

        If ooCM.PRODUCTValidateTempData(WebLib.UserID) = False Then
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

        If ooCM.PRODUCTConfirmTempData(WebLib.UserID) = False Then
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

        If ooCM.PRODUCTDeleteTempData(table1sel0.Value, WebLib.UserID) = False Then
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

        If ooCM.PRODUCTDeleteTempData("ALL", WebLib.UserID) = False Then
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

		dtHead = dt.DefaultView.ToTable(True, {"Company","Part No","Part Desc 1","Part Desc 2","Base UOM","Manual Lot", _
                                            "Lot Compulsory","Issue Type","Attribute 1","Attribute 2","CP Item","Non Return","Tax Method", _
                                            "Purchase Tax Code","Sales Tax Code","M2","M3","Weight","Expiry Item","Min Expiry Days", _
                                            "Shelf Life Days","Product Owner","High Frequency Item","Bulk Item","Cross Dock Item","Base Dimension Width","Base Dimension Height", _
                                            "Base Dimension Thinkness","Outer Dimension Width","Outer Dimension Height","Outer Dimension Thinkness","Inner Dimension Width", _
                                            "Inner Dimension Height","Inner Dimension Thinkness","Storage Type","Tariff Code","Costing Method"})
        For Each drHead As DataRow In dtHead.Rows

            If (drHead.Item("Part No").ToString()).Trim <> "" Then
                luid = ooo.GetUniqueGUID
                sqlVal = "INSERT INTO OfficeOneBI.dbo.zzzTEMPProduct(temp_companycode,temp_partno,temp_partdesc1,temp_partdesc2, temp_partum,"
                sqlVal += "temp_manuallot,temp_mustlot,temp_issuetype,temp_att1,temp_att2,temp_cpitem,temp_nonreturn,"
                sqlVal += "temp_taxmethod,temp_purtaxcode,temp_salestaxcode,temp_m2,temp_m3,temp_weight,temp_expiryitem,"
                sqlVal += "temp_minexpirydays,temp_shelflife,temp_owner,temp_highfreq,temp_bulkitem,temp_crossdockitem,temp_basewidth,"
                sqlVal += "temp_baseheight,temp_basethick,temp_outerwidth,temp_outerheight,temp_outerthick,temp_innerwidth,temp_innerheight,"
                sqlVal += "temp_innerthick,temp_storagetype,temp_tariffcode,temp_costingmethod,"
                sqlVal += "temp_uid,temp_createdt,temp_createby,temp_merchantid,temp_filter"
                sqlVal += ") Values("
                sqlVal += ""
                sqlVal += "'" + drHead.Item("Company").ToString() + "',"
                sqlVal += "'" + OfficeOne.Gen.Library.Utility.CheckText(drHead.Item("Part No").ToString()) + "',"
                sqlVal += "'" + OfficeOne.Gen.Library.Utility.CheckText(drHead.Item("Part Desc 1").ToString()) + "',"
                sqlVal += "'" + OfficeOne.Gen.Library.Utility.CheckText(drHead.Item("Part Desc 2").ToString()) + "',"
                sqlVal += "'" + drHead.Item("Base UOM").ToString() + "',"
                sqlVal += "'" + drHead.Item("Manual Lot").ToString() + "',"
                sqlVal += "'" + drHead.Item("Lot Compulsory").ToString() + "',"
                sqlVal += "'" + drHead.Item("Issue Type").ToString() + "',"
                sqlVal += "'" + drHead.Item("Attribute 1").ToString() + "',"
                sqlVal += "'" + drHead.Item("Attribute 2").ToString() + "',"
                sqlVal += "'" + drHead.Item("CP Item").ToString() + "',"
                sqlVal += "'" + drHead.Item("Non Return").ToString() + "',"
                sqlVal += "'" + drHead.Item("Tax Method").ToString() + "',"
                sqlVal += "'" + drHead.Item("Purchase Tax Code").ToString() + "',"
                sqlVal += "'" + drHead.Item("Sales Tax Code").ToString() + "',"
                sqlVal += "'" + drHead.Item("M2").ToString() + "',"
                sqlVal += "'" + drHead.Item("M3").ToString() + "',"
                sqlVal += "'" + drHead.Item("Weight").ToString() + "',"
                sqlVal += "'" + drHead.Item("Expiry Item").ToString() + "',"
                sqlVal += "'" + drHead.Item("Min Expiry Days").ToString() + "',"
                sqlVal += "'" + drHead.Item("Shelf Life Days").ToString() + "',"
                sqlVal += "'" + drHead.Item("Product Owner").ToString() + "',"
                sqlVal += "'" + drHead.Item("High Frequency Item").ToString() + "',"
                sqlVal += "'" + drHead.Item("Bulk Item").ToString() + "',"
                sqlVal += "'" + drHead.Item("Cross Dock Item").ToString() + "',"
                sqlVal += "'" + drHead.Item("Base Dimension Width").ToString() + "',"
                sqlVal += "'" + drHead.Item("Base Dimension Height").ToString() + "',"
                sqlVal += "'" + drHead.Item("Base Dimension Thinkness").ToString() + "',"
                sqlVal += "'" + drHead.Item("Outer Dimension Width").ToString() + "',"
                sqlVal += "'" + drHead.Item("Outer Dimension Height").ToString() + "',"
                sqlVal += "'" + drHead.Item("Outer Dimension Thinkness").ToString() + "',"
                sqlVal += "'" + drHead.Item("Inner Dimension Width").ToString() + "',"
                sqlVal += "'" + drHead.Item("Inner Dimension Height").ToString() + "',"
                sqlVal += "'" + drHead.Item("Inner Dimension Thinkness").ToString() + "',"
                sqlVal += "'" + drHead.Item("Storage Type").ToString() + "',"
                sqlVal += "'" + drHead.Item("Tariff Code").ToString() + "',"
                sqlVal += "'" + drHead.Item("Costing Method").ToString() + "',"
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

