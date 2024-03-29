Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class trackingpoints_class

    Inherits basepagelist
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = "codemaster"
        PageTitle = "Tracking Points Administration"
        ActionType = "TP"
        FieldUID = "co_uid"
        FieldMerchantID = "co_merchantid"
        FieldDefaultSort = " co_codevalue asc"
        PageDetail = "product.aspx"


        DBSQL = "Select co_uid,co_codevalue,co_description from " & DBTableName & " " & _
                " where co_fieldname='tpoints' and " & FieldMerchantID & "='" & WebLib.MerchantID & "' order by " & FieldDefaultSort


        Dim DBSQL2 = "Select co_uid,co_codevalue,co_description from " & DBTableName & " " & _
                " where co_fieldname='branchcat' and " & FieldMerchantID & "='" & WebLib.MerchantID & "' order by " & FieldDefaultSort


        PageListsize = 50
        If Page.IsPostBack = False Then
            WebLib.ActionUID = ""
            Call initTables()
            Call initTables2()
            Call loaddata(DBSQL)
            Call loaddata2(DBSQL2)

        End If
        btnsave.CssClass = TableUtils.btnprimary

        btnback.CssClass = TableUtils.btnprimary4
    End Sub
    Protected Sub initTables()
        litthead.text = "<thead><tr>" & _
                        "<th>UID</th>" & _
                        "<th>Tracking Code</th>" & _
                        "<th>Description</th>" & _
                        "</tr></thead>"
        littfoot.Text = ""
        litsettings.Text = TableUtils.GetStandard("caishtb", False, False, False)
    End Sub
    Protected Sub initTables2()
        litthead2.Text = "<thead><tr>" & _
                        "<th>UID</th>" & _
                        "<th>Branch Class</th>" & _
                        "<th>Description</th>" & _
                        "</tr></thead>"
        littfoot2.Text = ""
        litsettings2.Text = TableUtils.GetStandard("caishtb2", False, False, False)

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
            sb.Append("<td>" & drv.Row("co_uid").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("co_codevalue").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("co_description").ToString.Trim & "</td>")
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
            sb.Append("<td>" & drv.Row("co_uid").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("co_codevalue").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("co_description").ToString.Trim & "</td>")
            sb.Append("</tr>")
            objdata.Text = sb.ToString()

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

        Dim dt As DataTable = ds.Tables("datarecords")
        Dim dv As New DataView(dt)

        Dim pgitems As New PagedDataSource()
        pgitems.DataSource = dv
        pgitems.AllowPaging = True

        rep.DataSource = pgitems
        rep.DataBind()
        cn.Dispose()
        cmd.Dispose()

        '   Catch ex As Exception

        '     ShowAlert("Error : " & ex.Message)
        '            lblmessage.text = ex.Message

        '        End Try


    End Sub

    Public Sub loaddata2(ByVal SQLQuery As String)
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

            rep2.DataSource = pgitems
            rep2.DataBind()
            cn.Dispose()
            cmd.Dispose()

        Catch ex As Exception
            ShowAlert("Error Loading Branch Class Data")

        End Try

    End Sub
    Public Sub eventfiresub(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If (table1sel.Value & "").Trim = "" Or (table2sel.Value & "").Trim = "" Then
            ShowAlert("Please select branch class and tracking points")
            Exit Sub
        End If
        Call TakeAction()
    End Sub
    Public Sub adddata(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WebLib.ActionUID = ""
        Response.Redirect(PageDetail)
    End Sub

    Public Sub backback(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WebLib.ActionUID = ""
        Response.Redirect("menudata.aspx")
    End Sub

End Class

