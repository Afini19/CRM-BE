Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class exratelist_class

    Inherits basepagelist
    Dim CODEFIELD As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = ""
        PageTitle = "Exchange Rate Maintenance"
        ActionType = "ERM"
        FieldUID = ""
        FieldMerchantID = ""
        FieldDefaultSort = ""
        PageDetail = "exrate.aspx"
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
        Framework_MenuLeftCode = WebMenuFinance.Finance("S")
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
        Dim oo As New OfficeOne.WebServices.BLogic.Currency
        oo.ConnectionString = DBConnection
        oo.MerchantMerchantID = WebLib.MerchantID
        oo.MerchantFilter = WebLib.FilterCode

        Return oo.GetExchangeRateByCriteria("", "order by exr_curr1,exr_start_date")

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


                Dim oo As New OfficeOne.WebServices.BLogic.FinanceValidation

                sb.Append("<tr>")
                sb.Append("<td>" & drv.Row("exr_uid").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("exr_curr1").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("exr_curr2").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("exr_rate").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("exr_rate2").ToString.Trim & "</td>")
                sb.Append("<td>" & WebUtils.FormatDateDMY(drv.Row("exr_start_date")) & "</td>")
                sb.Append("<td>" & WebUtils.FormatDateDMY(drv.Row("exr_end_date")) & "</td>")
                sb.Append("<td>" & drv.Row("exr_createby").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("exr_createdt").ToString.Trim & "</td>")
                sb.Append("</tr>")

                oo = Nothing

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
        lColumnNames = lColumnNames & "{ name: 'from' },"
        lColumnNames = lColumnNames & "{ name: 'to' },"
        lColumnNames = lColumnNames & "{ name: 'ratefrom' },"
        lColumnNames = lColumnNames & "{ name: 'rateto' },"
        lColumnNames = lColumnNames & "{ name: 'datefrom' },"
        lColumnNames = lColumnNames & "{ name: 'dateto' },"
        lColumnNames = lColumnNames & "{ name: 'createby' },"
        lColumnNames = lColumnNames & "{ name: 'createon' }"
        lColumnNames = lColumnNames & "],"

        litthead.Text = "<thead><tr>" & _
                        "<th>ID</th>" & _
                        "<th>" & "From Currency" & "</th>" & _
                        "<th>" & "To Currency" & "</th>" & _
                        "<th>" & "From Rate" & "</th>" & _
                        "<th>" & "To Rate" & "</th>" & _
                        "<th>" & "Effective From" & "</th>" & _
                        "<th>" & "Effective To" & "</th>" & _
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

            If ds Is Nothing Then
                ShowAlert("Unable to Retrieve Data")
                Exit Sub
            End If


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

