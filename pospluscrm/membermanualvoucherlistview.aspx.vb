Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class membermanualvoucherlistview_class

    Inherits basepagelist
    Dim CODEFIELD As String = "schannel"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = ""
        DBConnection = "Provider=SQLOLEDB;Data Source=(local)\SQLEXPRESS;Initial Catalog=storefrontsuite;User ID=sa;Password="


        PageTitle = "Voucher Issuance List"
        ActionType = "VOA"
        FieldUID = ""
        FieldMerchantID = ""
        FieldDefaultSort = ""
        PageDetail = "membermanualvoucher.aspx"
        PageListing = "membermanualvoucherlist.aspx"
        PageListsize = 1000

        Framework_Back = PageListing
        Framework_SearchGrid = True
        Framework_DBSearch = True
  

        GetSideMenu()

        GenLeftBar()
        GenRightBar()

        If Page.IsPostBack = False Then

            uid.value = WebLib.ActionUID

            If isnumeric(uid.value) = False Then
                uid.value = 0
            End If

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
        sb.AppendLine(TableUtils.GenBarOptions("delete", "Cancel Voucher", "CANCEL", eventtype.ClientID, eventfirenorm.ClientID, "", ""))
        sb.AppendLine(TableUtils.GenBarSeparator())
        sb.AppendLine(TableUtils.GenBarOptions("event_available", "Remind Selected", "REMIND", eventtype.ClientID, eventfirenorm.ClientID, "", ""))
        sb.AppendLine(TableUtils.GenBarSeparator())
        sb.AppendLine(TableUtils.GenBarOptions("event_note", "Remind All", "EDIT", eventtype.ClientID, eventfirenorm.ClientID, "", ""))

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


        Dim JoinFields As String = ""
        Dim Orderby As String = ""

        Try
            Dim lFilterstatement As String = " mv_merchantid='Default' and mv_Filter='Filter'"
            cn.Open()
            cmd.CommandText = "select *" & _
                               " from evouchersmy " & JoinFields & " where mv_voucherid=" & uid.value & " " & Orderby




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
                sb.Append("<td>" & drv.Row("mv_id").ToString.Trim & "</td>")


                If (drv.Row("mv_voucherno").ToString.Trim = "") Then

                    sb.Append("<td>" & "-Non Physical-" & "</td>")
                Else
                    sb.Append("<td>" & drv.Row("mv_voucherno").ToString.Trim & "</td>")

                End If

                sb.Append("<td>" & drv.Row("mv_memberid").ToString.Trim & "</td>")

                If ((drv.Row("mv_createdt") & "").trim = "") Then

                    sb.Append("<td>" & " " & "</td>")
                Else
                    sb.Append("<td>" & WebUtils.FormatDateDMY(drv.Row("mv_createdt")) & "</td>")

                End If

                If ((drv.Row("mv_viewdt") & "").trim = "") Then

                    sb.Append("<td>" & " " & "</td>")
                Else
                    sb.Append("<td>" & WebUtils.FormatDateDMY(drv.Row("mv_viewdt")) & "</td>")

                End If

       


                sb.Append("<td>" & WebUtils.FormatDateDMY(drv.Row("mv_expiry")) & "</td>")
                sb.Append("<td>" & drv.Row("mv_status").ToString.Trim & "</td>")
                If ((drv.Row("mv_statusdt") & "").trim = "") Then

                    sb.Append("<td>" & " " & "</td>")
                Else
                    sb.Append("<td>" & drv.Row("mv_createdt").ToString.Trim & "</td>")

                End If

                sb.Append("</tr>")
                objdata.Text = sb.ToString()
            Catch ex As Exception
                Response.Write(WebUtils.GetErrorMessage(ex.message))
                Response.End()
            End Try
        End If
    End Sub
    Function GetDesc(ByVal thecode) As String

        Select Case thecode

            Case "C"
                Return "Cash Discount"


            Case "P"
                Return "Discount Percent"


            Case Else
                Return "Non Value"

        End Select
    End Function

    Protected Sub initTables()

        Dim lColumnNames As String = ""

        lColumnNames = lColumnNames & "columns: ["
        lColumnNames = lColumnNames & "{ name: 'uid' },"
        lColumnNames = lColumnNames & "{ name: 'code' },"
        lColumnNames = lColumnNames & "{ name: 'member' },"
        lColumnNames = lColumnNames & "{ name: 'issuedt' },"
        lColumnNames = lColumnNames & "{ name: 'vuewdt' },"
        lColumnNames = lColumnNames & "{ name: 'expiry' },"
        lColumnNames = lColumnNames & "{ name: 'status' },"
        lColumnNames = lColumnNames & "{ name: 'redeemdt' }"
        lColumnNames = lColumnNames & "],"

        litthead.Text = "<thead><tr>" & _
                        "<th>ID</th>" & _
                        "<th>" & "Voucher No" & "</th>" & _
                        "<th>" & "Assigned to Member" & "</th>" & _
    "<th>" & "Issue Date " & "</th>" & _
    "<th>" & "View Date " & "</th>" & _
                        "<th>" & "Expiry " & "</th>" & _
                        "<th>" & "Status " & "</th>" & _
      "<th>" & "Redeemed Date " & "</th>" & _
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


