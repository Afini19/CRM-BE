Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class emenulist_class

    Inherits basepagelist
    Dim CODEFIELD As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = ""
        DBConnection = "Provider=SQLOLEDB;Data Source=(local)\SQLEXPRESS;Initial Catalog=storefront2u_app;User ID=sa;Password="


        PageTitle = "eMenu Maintenance"
        ActionType = "EMENU"
        FieldUID = ""
        FieldMerchantID = ""
        FieldDefaultSort = ""
        PageDetail = "emenu.aspx"
        PageListing = ""
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
        Framework_MenuLeftCSS = WebMenuEnquiry.LeftBarSmallPaddingCSS
        Framework_MenuLeftCode = ""
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
        Dim cn As New OleDb.OleDbConnection(DBConnection)
        Dim cmd As New OleDb.OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim ltemp As String = ""
        Dim FieldDefaultSort As String = " priority desc, ranking asc, pname, pcode"
        Dim DBSQL As String = "Select products.*,(pf_name + '-' + productcat.description) as category from products left outer join productcat on isnull(catid,0) = productcat.id left outer join product_filter on productcat.pc_puid = pf_uid and productcat.custcode = products.custcode where " & FieldMerchantID & "='" & WebLib.MerchantID & "' order by " & FieldDefaultSort

        Try

            Dim lFilterstatement As String = ""
            cn.Open()
            cmd.CommandText = "select * from products " & lFilterstatement & ""


            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")



            cn.Close()
            cmd.Dispose()
            cn.Dispose()

            Return ds
        Catch ex As Exception
            ShowPromptV2(ex.Message)
            Return Nothing
        End Try

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


            Try

                sb = New System.Text.StringBuilder
                sb.Append("<tr>")
                sb.Append("<td>" & drv.Row("pp_uid").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("pcode").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("pname").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("sprice1").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("fvisible").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("pp_valid").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("fnew").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("ffeature").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("fpromo").ToString.Trim & "</td>")
                sb.Append("</tr>")
                objdata.Text = sb.ToString()
            Catch ex As Exception
                Response.Write(WebUtils.GetErrorMessage(ex.message))
                Response.End()
            End Try
        End If
    End Sub
    Protected Sub initTables()

        Dim lColumnNames As String = ""

        lColumnNames = lColumnNames & "columns: ["
        lColumnNames = lColumnNames & "{ name: 'uid' },"
        lColumnNames = lColumnNames & "{ name: 'code' },"
        lColumnNames = lColumnNames & "{ name: 'name' },"
        lColumnNames = lColumnNames & "{ name: 'sprice1' },"
        lColumnNames = lColumnNames & "{ name: 'visible' },"
        lColumnNames = lColumnNames & "{ name: 'valid' },"
        lColumnNames = lColumnNames & "{ name: 'fnew' },"
        lColumnNames = lColumnNames & "{ name: 'ffeature' },"
        lColumnNames = lColumnNames & "{ name: 'fpromo' }"
        lColumnNames = lColumnNames & "],"



        litthead.Text = "<thead><tr>" & _
                        "<th>ID</th>" & _
                         "<th>" & "Menu Code" & "</th>" & _
                        "<th>" & "Menu Name" & "</th>" & _
                        "<th>" & "Menu Price" & "</th>" & _
                       "<th>" & "Visible ?" & "</th>" & _
             "<th>" & "Valid ?" & "</th>" & _
                       "<th>" & "New Menu ?" & "</th>" & _
             "<th>" & "Featured Menu ?" & "</th>" & _
                       "<th>" & "Promotion ?" & "</th>" & _
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
            Response.Write(ex.message)
            Response.End()
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


