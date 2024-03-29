Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class branchextlist_class

    Inherits basepagelist
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = ""
        PageTitle = "Branch Extended Settings"
        ActionType = "BRA"
        FieldUID = ""
        FieldMerchantID = ""
        FieldDefaultSort = ""
        PageDetail = "branchext.aspx"
        PageListing = "menudata.aspx"
        PageListsize = 1000

        Framework_Back = PageListing
        Framework_SearchGrid = True
        Framework_DBSearch = True

        GenLeftBar()
        GenRightBar()

        If Page.IsPostBack = False Then
            WebLib.ActionUID = ""
            Call initTables()
            Call Refresh()
        End If

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

        Return oo.GetBranchDataV1("br_merchantid='" & WebLib.MerchantID & "' and br_filter='" & WebLib.FilterCode & "'", "order by code")

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
            sb.Append("<tr>")
            sb.Append("<td>" & drv.Row("br_uid").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("code").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("name").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("Locationid").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("br_locationa").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("br_locationq").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("br_locationr").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("br_lotcontrol").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("br_enablepallet").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("br_itoinmode").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("br_grnblind").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("br_grnnoexp").ToString.Trim & "</td>")
            sb.Append("</tr>")
            objdata.Text = sb.ToString()

        End If
    End Sub
    Protected Sub initTables()

        Dim lColumnNames As String = ""

        lColumnNames = lColumnNames & "columns: ["
        lColumnNames = lColumnNames & "{ name: 'uid' },"
        lColumnNames = lColumnNames & "{ name: 'code' },"
        lColumnNames = lColumnNames & "{ name: 'name' },"
        lColumnNames = lColumnNames & "{ name: 'locrec'},"
        lColumnNames = lColumnNames & "{ name: 'locdamage'},"
        lColumnNames = lColumnNames & "{ name: 'locq'},"
        lColumnNames = lColumnNames & "{ name: 'locr'},"
        lColumnNames = lColumnNames & "{ name: 'Lotc'},"
        lColumnNames = lColumnNames & "{ name: 'pallet'},"
        lColumnNames = lColumnNames & "{ name: 'recmode'},"
        lColumnNames = lColumnNames & "{ name: 'grnblind'},"
        lColumnNames = lColumnNames & "{ name: 'disableexp'}"
        lColumnNames = lColumnNames & "],"



        litthead.Text = "<thead><tr>" & _
                        "<th>ID</th>" & _
                        "<th>" & "Branch Code" & "</th>" & _
                        "<th>" & "Branch Name" & "</th>" & _
                        "<th>" & "Staging Location" & "</th>" & _
                        "<th>" & "Damage Location" & "</th>" & _
                        "<th>" & "Quarantine Location" & "</th>" & _
                        "<th>" & "Return Location" & "</th>" & _
                        "<th>" & "Lot Control" & "</th>" & _
                        "<th>" & "Enable Pallet Feature" & "</th>" & _
                        "<th>" & "ITO Receiving Mode" & "</th>" & _
                        "<th>" & "GRN Blind Receiving" & "</th>" & _
                        "<th>" & "Disable Receiving Expiry" & "</th>" & _
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

