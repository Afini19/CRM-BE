Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class branchlist_class

    Inherits basepagelist
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = ""
        PageTitle = "Branch Maintenance"
        ActionType = "BRA"
        FieldUID = ""
        FieldMerchantID = ""
        FieldDefaultSort = ""
        PageDetail = "branch.aspx"
        PageListing = "menudata.aspx"
        PageListsize = 1000

        Framework_Back = PageListing
        Framework_SearchGrid = True
        Framework_DBSearch = True

        GetSideMenu()

        GenLeftBar()
        GenRightBar()

        If Page.IsPostBack = False Then
            WebLib.ActionUID = ""
            Call initTables()
            Call Refresh()
        End If

    End Sub
    Protected Sub GetSideMenu()
        Framework_MenuLeftBar = True
        Framework_MenuLeftCSS = WebMenuEnquiry.LeftBarPaddingCSS
        Framework_MenuLeftCode = WebMenuGeneralSet.Warehouse("S")
    End Sub
    Protected Sub GenLeftBar()
        Dim sb As New StringBuilder
        sb.AppendLine("<span style=""display:flex;"">")
        sb.AppendLine(TableUtils.GenBarOptions("add", "Add New", "ADD", eventtype.ClientID, eventfirenorm.ClientID, "", ""))
        sb.AppendLine(TableUtils.GenBarSeparator())
        sb.AppendLine(TableUtils.GenBarOptions("edit", "Edit Selected", "EDIT", eventtype.ClientID, eventfirenorm.ClientID, "", ""))
        sb.AppendLine("</span>")

        Framework_LeftNavBar = sb.ToString()
    End Sub
    Protected Sub GenRightBar()
    End Sub
    Protected Sub Refresh()
        loaddata("")
    End Sub
    Protected Function LoadSQLfromCloud() As DataSet
        Dim oo As New OfficeOne.WebServices.BLogic.Branch
        oo.ConnectionString = DBConnection
        oo.MerchantMerchantID = WebLib.MerchantID
        oo.MerchantFilter = WebLib.FilterCode


        Return oo.GetBranchDataV1("", "order by name, code")

    End Function
    Protected Sub TakeAction()
        If eventtype.Value = "ADD" Then
            Call adddata()
        End If
        If eventtype.Value = "EDIT" Then
            Call editdata()
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
            Try

                sb.Append("<tr>")
                sb.Append("<td>" & drv.Row("br_uid").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("code").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("name").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("br_class").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("channel").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("br_site").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("br_currency").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("locationid").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("br_locationq").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("br_locationr").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("br_locationa").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("br_updateby").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("br_updatedt").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("br_createby").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("br_createdt").ToString.Trim & "</td>")

                sb.Append("</tr>")
            Catch ex As Exception
                Response.Write(WebUtils.GetErrorMessage(ex.message))
                Response.End()
            End Try


            objdata.Text = sb.ToString()

        End If
    End Sub
    Protected Sub initTables()

        Dim lColumnNames As String = ""

        lColumnNames = lColumnNames & "columns: ["
        lColumnNames = lColumnNames & "{ name: 'uid' },"
        lColumnNames = lColumnNames & "{ name: 'code' },"
        lColumnNames = lColumnNames & "{ name: 'name' },"
        lColumnNames = lColumnNames & "{ name: 'class' },"
        lColumnNames = lColumnNames & "{ name: 'channel' },"
        lColumnNames = lColumnNames & "{ name: 'site' },"
        lColumnNames = lColumnNames & "{ name: 'currency' },"
        lColumnNames = lColumnNames & "{ name: 'loc' },"
        lColumnNames = lColumnNames & "{ name: 'locq' },"
        lColumnNames = lColumnNames & "{ name: 'locr' },"
        lColumnNames = lColumnNames & "{ name: 'loca' },"
        lColumnNames = lColumnNames & "{ name: 'updateby' },"
        lColumnNames = lColumnNames & "{ name: 'updateon' },"
        lColumnNames = lColumnNames & "{ name: 'createby' },"
        lColumnNames = lColumnNames & "{ name: 'createon' }"

        lColumnNames = lColumnNames & "],"



        litthead.Text = "<thead><tr>" & _
                        "<th>ID</th>" & _
                        "<th>" & "Branch Code" & "</th>" & _
                        "<th>" & "Branch Name" & "</th>" & _
                        "<th>" & "BranchClass" & "</th>" & _
                        "<th>" & "Sales Channel" & "</th>" & _
                        "<th>" & "Default Site" & "</th>" & _
                        "<th>" & "Default Currency" & "</th>" & _
                        "<th>" & "Default Location" & "</th>" & _
                        "<th>" & "Quarantine Loc" & "</th>" & _
                        "<th>" & "Return Loc" & "</th>" & _
                        "<th>" & "Damage Loc" & "</th>" & _
                        "<th>" & "Last UpdateBy" & "</th>" & _
                       "<th>" & "Last Update On" & "</th>" & _
                        "<th>" & "Create By" & "</th>" & _
                       "<th>" & "Create On" & "</th>" & _
                       "</tr></thead>"
        littfoot.Text = ""
        litsettings.Text = TableUtils.GetStandard("caishtb", False, False, False, , , , , lColumnNames)
    End Sub
    Public Sub loaddata(ByVal SQLQuery As String)

        Dim ds As New DataSet()


        Try

            ds = LoadSQLfromCloud()

            Dim dt As DataTable = ds.Tables(0)
            Dim dv As New DataView(dt)

            Dim pgitems As New PagedDataSource()
            pgitems.DataSource = dv
            pgitems.AllowPaging = False


            rep.DataSource = pgitems
            rep.DataBind()


        Catch ex As Exception
            ShowAlert("Error Loading Data")

        End Try

    End Sub
    Public Sub eventfiresub(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call TakeAction()
    End Sub

    Public Sub adddata()
        WebLib.ActionUID = ""
        WebLib.ActionType = ActionType
        WebLib.ActionParam1 = ""
        Response.Redirect(PageDetail)
    End Sub
    Public Sub editdata()
        WebLib.ActionUID = table1sel0.Value

        If (WebLib.ActionUID & "").TRIM = "" Then
            ShowAlert("Please select a record")
            Exit Sub
        End If


        WebLib.ActionType = ActionType
        WebLib.ActionParam1 = ""
        Response.Redirect(PageDetail)
    End Sub

End Class

