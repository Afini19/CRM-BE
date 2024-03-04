Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class namec_list_class
    Inherits basepagelist
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = "namec"
        DBSQL = "Select * from " & DBTableName
        PageListsize = 50
        Call PopulateTable()
        If Page.IsPostBack = False Then
            Call loaddata(DBSQL)
        End If
    End Sub
    Protected Sub PopulateTable()
        Dim lcolwidth As String = ""

        lcolwidth = " <style type=""text/css"">" & Environment.NewLine & "@media screen and (max-width: 768px) {"
        lcolwidth = lcolwidth & ".row .cell:nth-child(1) {width: 30%;}" & Environment.NewLine
        lcolwidth = lcolwidth & ".row .cell:nth-child(2) {width: 20%;}" & Environment.NewLine
        lcolwidth = lcolwidth & ".row .cell:nth-child(3) {width: 20%;}" & Environment.NewLine
        lcolwidth = lcolwidth & ".row .cell:nth-child(4) {width: 20%;}" & Environment.NewLine
        lcolwidth = lcolwidth & ".row .cell:nth-child(5) {width: 5%;}" & Environment.NewLine
        lcolwidth = lcolwidth & "}" & Environment.NewLine & "</style>"
        litTableCSS.Text = lcolwidth


        Dim ldata As String = ""
        ldata = ldata & "<div class=""row header"">"
        ldata = ldata & "<div class=""cell"">Contact Person</div>"
        ldata = ldata & "<div class=""cell"">Company</div>"
        ldata = ldata & "<div class=""cell"">Mobile No</div>"
        ldata = ldata & "<div class=""cell"">Email</div>"
        ldata = ldata & "<div class=""cell"">Private ?</div>"
        ldata = ldata & "</div>"
        litTableHeader.Text = ldata
    End Sub
    Protected Sub TakeAction()
        Server.Transfer("proxy.aspx?np=add.aspx&uid=" & eventtype.Value)
    End Sub
    Protected Sub rep_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs)
        If e.CommandName = "Edit" Then

        End If
        If e.CommandName = "Del" Then

        End If
    End Sub
    Protected Sub rep_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rep.ItemDataBound

        Dim drv As DataRowView
        drv = e.Item.DataItem

        Dim objdata As Literal = e.Item.FindControl("litTableRows")
        If Not objdata Is Nothing Then
            Dim lonclick As String = " onclick=""$('#" & eventtype.ClientID & "').val('" & drv.Row("nc_uid").ToString.Trim & "');$('[id*=" & eventfire.ClientID & "]').click();"""         
            Dim ldata As String = ""
            ldata = ldata & "<div class=""row""" & lonclick & ">"
            ldata = ldata & "<div class=""cell"" data-title=""Contact Person"">" & drv.Row("nc_name").ToString.Trim & "</div>"
            ldata = ldata & "<div class=""cell"" data-title=""Company"">" & drv.Row("nc_company").ToString.Trim & "</div>"
            ldata = ldata & "<div class=""cell"" data-title=""Mobile No"">" & drv.Row("nc_mobileno").ToString.Trim & "</div>"
            ldata = ldata & "<div class=""cell"" data-title=""Email"">" & drv.Row("nc_email").ToString.Trim & "</div>"
            ldata = ldata & "<div class=""cell"" data-title=""Private ?"">" & webutils.anythingtoyesno(drv.Row("nc_private").ToString.Trim) & "</div>"

            ldata = ldata & "</div>"
            objdata.Text = ldata

        End If
    End Sub

    Public Sub loaddata(ByVal SQLQuery As String)
        Dim cn As New OleDbConnection(DBConnection)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()

        '  Try
        cn.Open()
        cmd.CommandText = SQLQuery
        cmd.Connection = cn
        ad.SelectCommand = cmd
        ad.Fill(ds, "datarecords")

        If IsNumeric(PageListindex) = False Then
            PageListindex = 0
        End If
        If IsNumeric(PageListindex) = False Then
            PageListNumber = 0
        End If

        Dim dt As DataTable = ds.Tables("datarecords")
        Dim dv As New DataView(dt)

        Dim pgitems As New PagedDataSource()
        pgitems.DataSource = dv
        pgitems.AllowPaging = True

        pgitems.PageSize = PageListsize
        pgitems.CurrentPageIndex = PageListNumber

        If pgitems.PageCount > 1 Then


            rptPaging.Visible = True
            Dim pages As New ArrayList()
            For i As Integer = 0 To pgitems.PageCount - 1
                pages.Add((i + 1).ToString())
            Next
            rptPaging.DataSource = pages
            rptPaging.DataBind()
        Else

            rptPaging.Visible = False
        End If

        '            lblCurrentPage.Text = "Page: " + (PageListNumber + 1).ToString() & " of " & pgitems.PageCount.ToString()

        cmdPrev.Enabled = Not pgitems.IsFirstPage
                   cmdNext.Enabled = Not pgitems.IsLastPage
        '            Exit Sub
        rep.DataSource = pgitems
        rep.DataBind()
        cn.Dispose()
        cmd.Dispose()

        '  Catch ex As Exception

        '     ShowAlert("Error : " & ex.Message)
        '            lblmessage.text = ex.Message

        '        End Try

    End Sub
    Public Sub eventfiresub(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call TakeAction()
    End Sub




End Class

