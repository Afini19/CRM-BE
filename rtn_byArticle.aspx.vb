Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class rtn_byarticle_class

    Inherits basepagelist
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = ""
        PageTitle = "Purchase Return / Search by Article"
        ActionType = "PRS"
        FieldUID = ""
        FieldMerchantID = ""
        FieldDefaultSort = ""
        PageDetail = ""

        PageListsize = 1000


        LoadSQLfromCloud()

        If Page.IsPostBack = False Then
            Call initTables()
            Call loaddata(DBSQL)
        End If
    End Sub
    Protected Sub LoadSQLfromCloud()

        If (partno.Text & "").Trim = "" Then
            DBSQL = ""
        End If

        Dim oo As New OfficeOne.WebServices.BLogic.GenericAction
        oo.ConnectionString = DBConnection
        oo.MerchantMerchantID = Weblib.MErchantID
        oo.MerchantFilter = Weblib.FilterCode

        Dim strresult As String = oo.TakeActionRetrieval("SQL_STOCKLOOKUPV2")
        Dim strAddfield As String = ""
        Dim strJoin As String = ""
        Dim DBPrefix As String = ""
        Dim strWhere As String = ""
        Dim strOrderby As String = ""
        Dim strDBPrefix As String = ""

        strWhere = " where pt_desc1 like '%" & partno.Text & "%' or pt_part like '%" & partno.Text & "%'"

        strresult = OfficeOne.Gen.Library.Utility.WhiteListSQL(strresult, "", strAddfield, strJoin, strOrderby, strWhere, strOrderby)


        DBSQL = strresult


    End Sub
    Protected Sub TakeAction()
        WebLib.ActionType = "IE"
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
            sb.Append("<td>" & drv.Row("pt_uid").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("pt_part").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("pt_desc1").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("pt_um").ToString.Trim & "</td>")
            sb.Append("</tr>")
            objdata.Text = sb.ToString()

        End If
    End Sub
    Protected Sub initTables()
        litthead.Text = "<thead><tr>" & _
                        "<th>UID</th>" & _
                        "<th>" & OfficeOne.Gen.Library.Messages.StockCode & "</th>" & _
                        "<th>" & OfficeOne.Gen.Library.Messages.StockName & "</th>" & _
                        "<th>" & OfficeOne.Gen.Library.Messages.UOM & "</th>" & _
                       "</tr></thead>"
        littfoot.text = ""
        litsettings.Text = TableUtils.GetStandard("caishtb", False, False, False, False)

    End Sub
    Public Sub loaddata(ByVal SQLQuery As String)
        Dim cn As New OleDbConnection(DBConnection)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()

        Try
            cn.Open()
            cmd.CommandText = SQLQuery
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")


            Dim dt As DataTable = ds.Tables("datarecords")
            Dim dv As New DataView(dt)

            Dim pgitems As New PagedDataSource()
            pgitems.DataSource = dv
            pgitems.AllowPaging = False

            cmdPrev.Enabled = Not pgitems.IsFirstPage
            cmdNext.Enabled = Not pgitems.IsLastPage
            rep.DataSource = pgitems
            rep.DataBind()
            cn.Dispose()
            cmd.Dispose()

        Catch ex As Exception

            ShowAlert("Error : " & ex.Message)

        End Try

    End Sub
    Public Sub eventfiresub(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call TakeAction()
    End Sub
    Public Sub gotoback(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GotoTheBack()
    End Sub
    Public Sub gotonext(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call GotoTheNext()
    End Sub

    Public Sub adddata(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Public Sub searchdata(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call LoadSQLfromCloud()
        Call loaddata(DBSQL)
    End Sub


    Public Sub savedata(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Public Sub ResetEntry()

        table1sel.Value = ""
        table1sel0.Value = ""
        table1sel2.Value = ""
        txtqty.Text = ""
    End Sub
    Public Sub GotoTheBack()
        Weblib.ActionUID = ""
        WebLib.ActionType = ""
        Response.redirect("menureturn.aspx")
    End Sub
    Public Sub GotoTheNext()

    End Sub
    Public Sub GotoPO()
 
    End Sub
End Class

