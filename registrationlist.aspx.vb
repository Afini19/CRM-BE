Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class registrationlist_class

    Inherits basepagelist
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = "merchant_multi"
        ActionType = "MM"
        DBSQL = "Select * from " & DBTableName & " where mm_merchantid='" & WebLib.MerchantID & "' order by mm_name"

        PageListsize = 50
        Call PopulateTable()
        If Page.IsPostBack = False Then
            Call loaddata(DBSQL)
        End If

        If WebLib.UserIsFullAdmin = False Then
            response.redirect("loginmain.aspx")
        End If
    End Sub
    Protected Sub PopulateTable()
        Dim lcolwidth As String = ""

        lcolwidth = " <style type=""text/css"">" & Environment.NewLine & "@media screen and (max-width: 768px) {"
        lcolwidth = lcolwidth & ".row .cell:nth-child(1) {width: 25%;}" & Environment.NewLine
        lcolwidth = lcolwidth & ".row .cell:nth-child(2) {width: 10%;}" & Environment.NewLine
        lcolwidth = lcolwidth & ".row .cell:nth-child(3) {width: 15%;}" & Environment.NewLine
        lcolwidth = lcolwidth & ".row .cell:nth-child(4) {width: 25%;}" & Environment.NewLine
        lcolwidth = lcolwidth & ".row .cell:nth-child(5) {width: 5%;}" & Environment.NewLine
        lcolwidth = lcolwidth & ".row .cell:nth-child(6) {width: 10%;}" & Environment.NewLine
        lcolwidth = lcolwidth & "}" & Environment.NewLine & "</style>"
        litTableCSS.Text = lcolwidth


        Dim ldata As String = ""
        ldata = ldata & "<div class=""row header"">"
        ldata = ldata & "<div class=""cell"">Name</div>"
        ldata = ldata & "<div class=""cell"">Area</div>"
        ldata = ldata & "<div class=""cell"">State</div>"
        ldata = ldata & "<div class=""cell"">Postal Code</div>"
        ldata = ldata & "<div class=""cell"">Email</div>"
        ldata = ldata & "<div class=""cell"">Valid</div>"
        ldata = ldata & "</div>"
        litTableHeader.Text = ldata
    End Sub
    Protected Sub TakeAction()
        WebLib.ActionType = ActionType
        WebLib.ActionUID = eventtype.Value
        Server.Transfer("registration.aspx")
    End Sub
    Protected Sub rep_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs)

    End Sub
    Protected Sub rep_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rep.ItemDataBound

        Dim drv As DataRowView
        drv = e.Item.DataItem

        Dim objdata As Literal = e.Item.FindControl("litTableRows")
        If Not objdata Is Nothing Then
            Dim lonclick As String = " onclick=""$('#" & eventtype.ClientID & "').val('" & drv.Row("mm_uid").ToString.Trim & "');$('[id*=" & eventfire.ClientID & "]').click();"""
            Dim ldata As String = ""
        
            Dim lmobileonlydata As String = "<div class=""tablecelldatamobileonly"">"
            lmobileonlydata = lmobileonlydata & "<b><font style=""font-size:1.1em"">" & drv.Row("mm_name").ToString.Trim & "</font></b><br>"
            lmobileonlydata = lmobileonlydata & "Area : <font style=""color:silver"">" & drv.Row("mm_area").ToString.Trim & "</font><br>"
            lmobileonlydata = lmobileonlydata & "State : <font style=""color:silver"">" & drv.Row("mm_state").ToString.Trim & "</font><br>"
            lmobileonlydata = lmobileonlydata & "</div>"

            ldata = ldata & "<div class=""row""" & lonclick & ">"
            ldata = ldata & "<div class=""cell cellnonmobile"" data-title=""Name"">" & drv.Row("mm_name").ToString.Trim & "</div>"
            ldata = ldata & "<div class=""cell cellnonmobile"" data-title=""Area Code"">" & drv.Row("mm_area").ToString.Trim & "</div>"
            ldata = ldata & "<div class=""cell cellnonmobile"" data-title=""State"">" & drv.Row("mm_state").ToString.Trim & "</div>"
            ldata = ldata & "<div class=""cell cellnonmobile"" data-title=""Postal Code"">" & drv.Row("mm_zipcode").ToString.Trim & "</div>"
            ldata = ldata & "<div class=""cell cellnonmobile"" data-title=""Email"">" & drv.Row("mm_email").ToString.Trim & "</div>"
            ldata = ldata & "<div class=""cell cellnonmobile"" data-title=""Valid ?"">" & drv.Row("mm_active").ToString.Trim & "</div>"
            ldata = ldata & lmobileonlydata
            ldata = ldata & "</div>"
            objdata.Text = ldata

        End If
    End Sub
    Public Sub loaddata(ByVal SQLQuery As String)
        Dim cn As New OleDbConnection(DBConnection)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()

        '    Try
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

        cmdPrev.Enabled = Not pgitems.IsFirstPage
        cmdNext.Enabled = Not pgitems.IsLastPage
        '            Exit Sub
        rep.DataSource = pgitems
        rep.DataBind()
        cn.Dispose()
        cmd.Dispose()

        '   Catch ex As Exception

        '     ShowAlert("Error : " & ex.Message)
        '            lblmessage.text = ex.Message

        '        End Try

    End Sub
    Public Sub eventfiresub(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call TakeAction()
    End Sub

    Public Sub adddata(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WebLib.ActionUID = ""
        Response.Redirect("registration.aspx")
    End Sub

End Class

