Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class adminproductlist_class

    Inherits basepagelistadmin
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = "products"
        PageTitle = "Product List"
        ActionType = "PP"
        FieldUID = "pp_uid"
        FieldMerchantID = "products.custcode"
        FieldDefaultSort = " products.id desc,priority desc, ranking asc, pname, pcode"
        PageDetail = "admin-product.aspx"
        Call ConstructSearch()
        PageListsize = 9999
        Call PopulateTable()
        If Page.IsPostBack = False Then
            eventtype2.value = WebLib.ActionParamMMUID & ""
            WebLib.ActionParamMMUID = ""
            WebLib.ActionUID = ""
            Call loaddata(DBSQL)


        End If



    End Sub
    Protected Sub PopulateTable()
        Dim lcolwidth As String = ""

        lcolwidth = " <style type=""text/css"">" & Environment.NewLine & "@media screen and (max-width: 768px) {"
        lcolwidth = lcolwidth & ".row .cell:nth-child(1) {width: 20%;}" & Environment.NewLine
        lcolwidth = lcolwidth & ".row .cell:nth-child(2) {width: 20%;}" & Environment.NewLine
        lcolwidth = lcolwidth & ".row .cell:nth-child(3) {width: 19%;}" & Environment.NewLine
        lcolwidth = lcolwidth & ".row .cell:nth-child(4) {width: 20%;}" & Environment.NewLine
        lcolwidth = lcolwidth & ".row .cell:nth-child(5) {width: 5%;}" & Environment.NewLine
        lcolwidth = lcolwidth & ".row .cell:nth-child(6) {width: 5%;}" & Environment.NewLine
        lcolwidth = lcolwidth & ".row .cell:nth-child(7) {width: 5%;}" & Environment.NewLine
        lcolwidth = lcolwidth & ".row .cell:nth-child(8) {width: 5%;}" & Environment.NewLine
        lcolwidth = lcolwidth & ".row .cell:nth-child(9) {width: 1%;}" & Environment.NewLine
        lcolwidth = lcolwidth & "}" & Environment.NewLine & "</style>"
        litTableCSS.Text = lcolwidth


        Dim ldata As String = ""
        ldata = ldata & "<div class=""row header"">"
        ldata = ldata & "<div class=""cell"">Merchant</div>"
        ldata = ldata & "<div class=""cell"">Category</div>"
        ldata = ldata & "<div class=""cell"">Product Code</div>"
        ldata = ldata & "<div class=""cell"">Product Name</div>"
        ldata = ldata & "<div class=""cell"">Visible</div>"
        ldata = ldata & "<div class=""cell"">Valid</div>"
        ldata = ldata & "<div class=""cell"">Priority</div>"
        ldata = ldata & "<div class=""cell"">Featured</div>"
        ldata = ldata & "<div class=""cell""></div>"

        ldata = ldata & "</div>"
        litTableHeader.Text = ldata
    End Sub
    Protected Sub TakeAction()

        If eventtype.Value = "SEARCH" Then
            Call searchdata()
            Exit Sub
        End If

        WebLib.ActionType = ActionType
        WebLib.ActionUID = eventtype.Value
        WebLib.ActionParamMMUID = eventtype2.Value
        Server.Transfer(PageDetail)




    End Sub
    Protected Sub rep_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs)

    End Sub
    Protected Sub rep_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rep.ItemDataBound

        Dim drv As DataRowView
        drv = e.Item.DataItem

        Dim objdata As Literal = e.Item.FindControl("litTableRows")
        If Not objdata Is Nothing Then
            Dim lonclick As String = " onclick=""$('#" & eventtype2.ClientID & "').val('" & drv.Row("pro_mmuid").ToString.Trim & "');$('#" & eventtype.ClientID & "').val('" & drv.Row(FieldUID).ToString.Trim & "');$('[id*=" & eventfire.ClientID & "]').click();"""
            Dim ldata As String = ""
            Dim lphoto As String = ""
            If (drv.Row("filename").ToString.Trim & "").Trim <> "" Then
                lphoto = "<span><i class=""material-icons"" style=""font-size:20px"">insert_photo</i></span>"
            Else
                lphoto = ""

            End If


            Dim lmobileonlydata As String = "<div class=""tablecelldatamobileonly"">"
            lmobileonlydata = lmobileonlydata & "<b><font style=""font-size:1.1em"">" & drv.Row("mm_name").ToString.Trim & "</font></b><br>"
            lmobileonlydata = lmobileonlydata & "<font style=""font-size:1.1em"">" & drv.Row("category").ToString.Trim & "</font><br>"
            lmobileonlydata = lmobileonlydata & "<font style=""font-size:1.1em"">" & drv.Row("pcode").ToString.Trim & "</font><br>"
            lmobileonlydata = lmobileonlydata & "<font style=""font-size:1.1em"">" & drv.Row("pname").ToString.Trim & "</font><br>"
            lmobileonlydata = lmobileonlydata & "</div>"



            ldata = ldata & "<div class=""row""" & lonclick & ">"
            ldata = ldata & "<div class=""cell cellnonmobile"" data-title=""Merchant"">" & drv.Row("mm_name").ToString.Trim & "</div>"
            ldata = ldata & "<div class=""cell cellnonmobile"" data-title=""Parent"">" & drv.Row("category").ToString.Trim & "</div>"
            ldata = ldata & "<div class=""cell cellnonmobile"" data-title=""Code"">" & drv.Row("pcode").ToString.Trim & "</div>"
            ldata = ldata & "<div class=""cell cellnonmobile"" data-title=""Name"">" & drv.Row("pname").ToString.Trim & "</div>"
            ldata = ldata & "<div class=""cell cellnonmobile"" data-title=""Visible"">" & drv.Row("fvisible").ToString.Trim & "</div>"
            ldata = ldata & "<div class=""cell cellnonmobile"" data-title=""Valid"">" & drv.Row("pp_valid").ToString.Trim & "</div>"
            ldata = ldata & "<div class=""cell cellnonmobile"" data-title=""Priority"">" & drv.Row("priority").ToString.Trim & "</div>"
            ldata = ldata & "<div class=""cell cellnonmobile"" data-title=""Featured"">" & drv.Row("ffeature").ToString.Trim & "</div>"
            ldata = ldata & "<div class=""cell cellnonmobile"" data-title="""">" & lphoto & "</div>"

            ldata = ldata & lmobileonlydata
            ldata = ldata & "</div>"
            objdata.Text = ldata

        End If
    End Sub
    Private Function ConstructSearch()
        Dim objdata As Object = Master.FindControl("ContentArea").FindControl("ss_dosearch")
        Dim lsearch As String = ""
        If Not objdata Is Nothing Then
            If objdata.value = "Y" Then
                Dim objSearchBox As TextBox = Master.FindControl("ContentArea").FindControl("ss_mmname")
                If Not objSearchBox Is Nothing Then
                    lsearch = lsearch & " and mm_name like '%" & objSearchBox.Text.Replace("'", "''") & "%'"
                End If
                objSearchBox = Master.FindControl("ContentArea").FindControl("ss_pcodename")
                If Not objSearchBox Is Nothing Then
                    lsearch = lsearch & " and (pname like '%" & objSearchBox.Text.Replace("'", "''") & "%' or pcode like '%" & objSearchBox.Text.Replace("'", "''") & "%')"
                End If
            End If
        End If

        Dim lprefix As String
        If lsearch = "" Then
            lprefix = " top 20 "
        Else
            lprefix = ""

        End If


        DBSQL = "Select " & lprefix & " " & DBTableName & ".*,(pf_name + '-' + productcat.description) as category,mm_name from " & DBTableName & " left outer join productcat on isnull(catid,0) = productcat.id left outer join product_filter on productcat.pc_puid = pf_uid and productcat.custcode = products.custcode inner join Merchant_Multi on pro_mmuid = mm_uid and " & FieldMerchantID & "=mm_merchantid where " & FieldMerchantID & "='" & WebLib.MerchantID & "' " & lsearch & " order by " & FieldDefaultSort
        Return ""

    End Function
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

        cmdprev.Enabled = Not pgitems.IsFirstPage
        cmdnext.Enabled = Not pgitems.IsLastPage
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
        Response.Redirect(PageDetail)
    End Sub
    Public Sub searchdata()
        Call ConstructSearch()
        Call loaddata(DBSQL)
    End Sub
End Class

