Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class secrolelist_class

    Inherits basepagelist
    Dim CODEFIELD As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = ""
        PageTitle = "9.9.1 - User Role"
        ActionType = "USR"
        FieldUID = ""
        FieldMerchantID = ""
        FieldDefaultSort = ""
        PageDetail = "secrole.aspx"
        PageListing = "menusys.aspx"
        PageListsize = 1000

        Framework_PageOption = True
        Framework_SearchGrid = True
        Framework_Back = PageListing
        Framework_StatsPage = Page.ResolveClientUrl("~/stats/gencount.aspx")

        If Page.IsPostBack = False Then
            WebLib.ActionUID = ""
            Call initTables()
            Call Refresh()
        End If
    End Sub
    Protected Sub Refresh()
        loaddata("")

    End Sub
    Protected Function LoadSQLfromCloud() As DataSet
        Dim oo As New OfficeOne.WebServices.BLogic.GenericAction
        oo.ConnectionString = DBConnection
        oo.MerchantMerchantID = Weblib.MErchantID
        oo.MerchantFilter = Weblib.FilterCode


        Dim rtnobject As String
        rtnobject = oo.TakeActionRetrievalData("GENCLASS", "getlicenserole", "", "", "", "")

        If rtnobject = "" Then
            Return Nothing
        Else

            Dim ooo As New OfficeOne.Gen.Library.JSON
            Return ooo.ToDS(rtnobject)
            ooo = Nothing
        End If


    End Function
    Protected Sub TakeAction()


        If eventtype.Value = "ADD" Then
            Call adddata()
        End If

        If eventtype.Value = "EDIT" Then
            Call editdata()
        End If

        If eventtype.Value = "BACK" Then
            Call gotoTheback()
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
            sb.Append("<td>" & drv.Row("alr_uid").ToString.Trim & "</td>")
            sb.Append("<td>" & TableUtils.GetGridOptions(drv.Row("alr_uid").ToString.Trim, "") & "</td>")
            sb.Append("<td>" & drv.Row("alr_code").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("alr_name").ToString.Trim & "</td>")

            sb.Append("<td class=""center-align"">")
            If WebUtils.BitToBoolean(drv.Row("alr_archive").ToString.Trim) = True Then
                sb.Append("<i class=""material-icons"" style=""color:black"">check_box</i></a>")
            End If
            sb.Append("</td>")

            sb.Append("<td class=""center-align"">")
            If WebUtils.BitToBoolean(drv.Row("alr_active").ToString.Trim) = False Then
                sb.Append("<i class=""material-icons"" style=""color:red"">check_box</i></a>")
            End If
            sb.Append("</td>")

            sb.Append("<td>" & drv.Row("alr_createby").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("alr_createdt").ToString.Trim & "</td>")
            sb.Append("</tr>")
            objdata.Text = sb.ToString()

        End If
    End Sub
    Protected Sub initTables()
        Dim lColumnNames As String = ""

        lColumnNames = lColumnNames & "columns: ["
        lColumnNames = lColumnNames & "{name: 'uid'},"
        lColumnNames = lColumnNames & "{ name: 'rowopt' },"
        lColumnNames = lColumnNames & "{ name: 'alrcode' },"
        lColumnNames = lColumnNames & "{ name: 'alrname' },"
        lColumnNames = lColumnNames & "{ name: 'alrarchive' },"
        lColumnNames = lColumnNames & "{ name: 'alractive' },"
        lColumnNames = lColumnNames & "{ name: 'createby' },"
        lColumnNames = lColumnNames & "{ name: 'createon' }"
        lColumnNames = lColumnNames & "],"

        litthead.Text = "<thead><tr>" & _
                        "<th>uid</th>" & _
                        "<th></th>" & _
                        "<th>" & "Role Code" & "</th>" & _
                        "<th>" & "Role Name" & "</th>" & _
                        "<th class=""center-align"">" & "Archived" & "</th>" & _
                        "<th class=""center-align"">" & "In-Active" & "</th>" & _
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
    Protected Sub adddata()
        WebLib.ActionUID = ""
        WebLib.ActionType = "USE"
        WebLib.ActionParam1 = ""
        Response.Redirect(PageDetail)
    End Sub
    Public Sub editdata()
        WebLib.ActionUID = table1sel.Value
        WebLib.ActionType = "USE"
        WebLib.ActionParam1 = ""
        Response.Redirect(PageDetail)
    End Sub
    Public Sub gotoTheback()
        Response.Redirect(PageListing)
    End Sub
End Class

