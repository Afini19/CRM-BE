Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class branchclassitemlist_class

    Inherits basepagelist
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = ""
        PageTitle = "Items by Branch Class"
        ActionType = "IBC"
        FieldUID = ""
        FieldMerchantID = ""
        FieldDefaultSort = " "
        PageDetail = ""
        If Page.IsPostBack = False Then
            WebLib.ActionUID = ""
            Call initTables()
            Call initTables2()
            Call loaddata(DBSQL)
        End If

        btnview.CssClass = TableUtils.btnprimary
        btnmanage.CssClass = TableUtils.btnprimary2

    End Sub
    Protected Function LoadSQLfromCloud() As DataSet
        Dim oo As New OfficeOne.WebServices.BLogic.GenericAction
        oo.ConnectionString = DBConnection
        oo.MerchantMerchantID = Weblib.MErchantID
        oo.MerchantFilter = Weblib.FilterCode

        Return oo.TakeActionRetrievalDataDS("GENCLASSV2", "getcodemaster", "", "co_fieldname='branchcat'", "", "")


    End Function
    Protected Function LoadSQLfromCloud2() As DataSet
        Dim oo As New OfficeOne.WebServices.BLogic.GenericAction
        oo.ConnectionString = DBConnection
        oo.MerchantMerchantID = Weblib.MErchantID
        oo.MerchantFilter = Weblib.FilterCode

        Return oo.TakeActionRetrievalDataDS("GENCLASSV2", "getstocksbybranchclass", "", "bs_type='" & table1sel.Value & "'", "", "")


    End Function
    Protected Sub initTables()
        litthead.Text = "<thead><tr>" & _
                        "<th>ID</th>" & _
                        "<th>Branch Class</th>" & _
                        "</tr></thead>"
        littfoot.Text = ""
        litsettings.Text = TableUtils.GetStandard("caishtb", False, False, True, False)
    End Sub
    Protected Sub initTables2()
        litthead2.Text = "<thead><tr>" & _
                        "<th>UID</th>" & _
                        "<th>Part No</th>" & _
                        "<th>Part Name</th>" & _
                        "<th>Base UOM</th>" & _
                       "</tr></thead>"
        littfoot2.Text = ""
        litsettings2.Text = TableUtils.GetStandard("caishtb2", True, False, True)

    End Sub
    Protected Sub TakeAction()
        WebLib.ActionType = "PP"
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
            sb.Append("<td>" & drv.Row("co_codevalue").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("co_codevalue").ToString.Trim & " - " & drv.Row("co_description").ToString.Trim & "</td>")
            sb.Append("</tr>")
            objdata.Text = sb.ToString()

        End If
    End Sub
    Protected Sub rep_ItemDataBound2(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rep2.ItemDataBound

        Dim drv As DataRowView
        drv = e.Item.DataItem
        Dim sb As System.Text.StringBuilder
        Dim objdata As Literal = e.Item.FindControl("litTableRows2")
        If Not objdata Is Nothing Then
            Dim ldata As String = ""

            sb = New System.Text.StringBuilder
            sb.Append("<tr>")
            sb.Append("<td>" & drv.Row("bs_uid").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("pt_part").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("pt_desc1").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("pt_um").ToString.Trim & "</td>")
            sb.Append("</tr>")
            objdata.Text = sb.ToString()
        End If
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

    Public Sub loaddata2(ByVal SQLQuery As String)

        Dim ds As New DataSet()


        Try

            ds = LoadSQLfromCloud2()


            Dim dt As DataTable = ds.Tables(0)
            Dim dv As New DataView(dt)

            Dim pgitems As New PagedDataSource()
            pgitems.DataSource = dv
            pgitems.AllowPaging = False


            rep2.DataSource = pgitems
            rep2.DataBind()


        Catch ex As Exception
            ShowAlert("Error Loading Data")

        End Try

    End Sub

    Public Sub eventfiresub(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If (table1sel.Value & "").Trim = "" Then
            ShowAlert("Please select a template")
            Exit Sub
        End If
        Call TakeAction()
    End Sub


    Public Sub viewdata(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If (table1sel.Value & "").Trim = "" Then
            ShowAlert("Please select a template")
            Exit Sub
        End If
        Call loaddata2("")
    End Sub
    Public Sub managedata(ByVal sender As System.Object, ByVal e As System.EventArgs)

        response.redirect("branchclassitemlistupload.aspx")
    End Sub
End Class

