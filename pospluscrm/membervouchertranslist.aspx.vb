Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System

Partial Public Class membervouchertranslist_class

    Inherits basepagelist
    Dim CODEFIELD As String = ""
    Dim theMerchantID As String = System.Configuration.ConfigurationSettings.AppSettings("themerchantid")
    Dim theFilter As String = System.Configuration.ConfigurationSettings.AppSettings("thefilter")
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = ""
        DBConnection = System.Configuration.ConfigurationSettings.AppSettings("ConnStrCRM")

        PageTitle = "Member Voucher Transaction"
        ActionType = "MVT"
        FieldUID = ""
        FieldMerchantID = ""
        FieldDefaultSort = ""
        PageDetail = "membervouchertranslist.aspx"
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
            eventtype.Value = "TODAY"
            Call TakeAction()
            Call AssignDefaultValues()
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
        'sb.AppendLine(TableUtils.GenBarOptions("add", "Add New", "ADD", eventtype.ClientID, eventfirenorm.ClientID, "", ""))
        'sb.AppendLine(TableUtils.GenBarSeparator())
        'sb.AppendLine(TableUtils.GenBarOptions("edit", "Edit Selected", "EDIT", eventtype.ClientID, eventfirenorm.ClientID, "", ""))
        'sb.AppendLine(TableUtils.GenBarSeparator())
        sb.AppendLine(TableUtils.GenBarOptions("search", "Advance Search", "", eventtype.ClientID, eventfirenorm.ClientID, "", "triggersearch()", "2"))
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

        Dim pFieldNames As String = "ll_id, ll_branch, ll_casher, ll_type, ll_date, ll_amount, ll_memberid, ll_billno, ll_reverse, ll_remarks, ml_Name, ml_membertype, vo_type, vo_code, vo_name, mv_refcode"
        Dim pJoinFields As String = "left join [storefront2u].[dbo].[Members_list] on ll_memberid = ml_login left join [storefront2u_app].[dbo].[evouchersmy] on ll_muid = mv_ref left join [storefront2u_app].[dbo].[evoucher] on mv_voucherid = vo_id"

        Try
            Dim lFilterstatement As String = "ll_merchantid='" & theMerchantID & "' and ll_type = 'V'"
            If FilterStatement.Trim <> "" Then
                lFilterstatement = lFilterstatement & " and " & FilterStatement
            End If

            cn.Open()
            cmd.CommandText = "select " & pFieldNames & " from [storefront2u_app].[dbo].[loyaltylog] " & pJoinFields & " where " & lFilterstatement & ""
            LogtheAudit(cmd.CommandText)
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
        If eventtype.Value = "NAVSEARCH" Then
            Call SearchtheData()
        End If
        If eventtype.Value = "TODAY" Then
            titleaddon.Value = " (Today : " & WebUtils.FormatDateDMY(DateTime.Now) & ")"
            FilterStatement = "ll_date = getdate() "
            Call loaddata("")
        End If

    End Sub

    Protected Sub ChangeTitle()
        PageTitle = PageTitle & titleaddon.Value
    End Sub

    Protected Sub AssignDefaultValues()
        Dim theObject As Object = Nothing

        theObject = Page.Master.FindControl("ContentArea").FindControl("sbtransfromdate")
        If theObject IsNot Nothing Then
            theObject.Value = DateTime.Now.ToString("dd/MM/yyyy")
        End If

        theObject = Page.Master.FindControl("ContentArea").FindControl("sbtranstodate")
        If theObject IsNot Nothing Then
            theObject.Value = DateTime.Now.ToString("dd/MM/yyyy")
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
                sb.Append("<td>" & drv.Row("ll_id").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("ll_memberid").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("ml_Name").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("ml_membertype").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("ll_branch").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("ll_casher").ToString.Trim & "</td>")
                sb.Append("<td>" & "Voucher" & "</td>")
                sb.Append("<td>" & drv.Row("ll_date").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("ll_amount").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("ll_billno").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("ll_reverse").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("ll_remarks").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("vo_code").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("vo_name").ToString.Trim & "</td>")
                'sb.Append("<td>" & drv.Row("vo_type").ToString.Trim & "</td>")
                If drv.Row("vo_type").ToString.Trim = "C" Then
                    sb.Append("<td>" & "Cash Voucher" & "</td>")
                ElseIf drv.Row("vo_type").ToString.Trim = "N" Then
                    sb.Append("<td>" & "Product Voucher" & "</td>")
                Else
                    sb.Append("<td>" & "" & "</td>")
                End If
                sb.Append("<td>" & drv.Row("mv_refcode").ToString.Trim & "</td>")
                sb.Append("</tr>")

                objdata.Text = sb.ToString()
            Catch ex As Exception
                Response.Write("ERROR : " & WebUtils.GetErrorMessage(ex.Message))
                Response.End()
            End Try
        End If
    End Sub
    Protected Sub initTables()

        Dim lColumnNames As String = ""

        lColumnNames = lColumnNames & "columns: ["
        lColumnNames = lColumnNames & "{ name: 'uid' },"
        lColumnNames = lColumnNames & "{ name: 'memberid' },"
        lColumnNames = lColumnNames & "{ name: 'membername' },"
        lColumnNames = lColumnNames & "{ name: 'membertype' },"
        lColumnNames = lColumnNames & "{ name: 'branch' },"
        lColumnNames = lColumnNames & "{ name: 'casher' },"
        lColumnNames = lColumnNames & "{ name: 'type' },"
        lColumnNames = lColumnNames & "{ name: 'date' },"
        lColumnNames = lColumnNames & "{ name: 'amount' },"
        lColumnNames = lColumnNames & "{ name: 'billno' },"
        lColumnNames = lColumnNames & "{ name: 'reverse' },"
        lColumnNames = lColumnNames & "{ name: 'remarks' },"
        lColumnNames = lColumnNames & "{ name: 'vouchercode' },"
        lColumnNames = lColumnNames & "{ name: 'vouchername' },"
        lColumnNames = lColumnNames & "{ name: 'vouchertype' },"
        lColumnNames = lColumnNames & "{ name: 'refcode' }"
        lColumnNames = lColumnNames & "],"



        litthead.Text = "<thead><tr>" &
                        "<th>ID</th>" &
                        "<th>" & "Member ID" & "</th>" &
                        "<th>" & "Member Name" & "</th>" &
                        "<th>" & "Member Type" & "</th>" &
                        "<th>" & "Branch" & "</th>" &
                        "<th>" & "Casher" & "</th>" &
                        "<th>" & "Type" & "</th>" &
                        "<th>" & "Date" & "</th>" &
                        "<th>" & "Amount" & "</th>" &
                        "<th>" & "Bill Number" & "</th>" &
                        "<th>" & "Reverse" & "</th>" &
                        "<th>" & "Remarks" & "</th>" &
                        "<th>" & "Voucher Code" & "</th>" &
                        "<th>" & "Voucher Name" & "</th>" &
                        "<th>" & "Voucher Type" & "</th>" &
                        "<th>" & "Reference Code" & "</th>" &
                        "</tr></thead>"
        littfoot.Text = ""
        litsettings.Text = TableUtils.GetStandard("caishtb", True, True, False, True, , , "", lColumnNames, True, True, True)
    End Sub
    Public Sub loaddata(ByVal SQLQuery As String)

        Dim ds As New DataSet()

        Call ChangeTitle()

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
            Response.Write(ex.Message)
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

    Public Sub AdvanceSearchDate()
        Dim theObject As Object = Nothing
        Dim lFilterStatement As String = ""

        Dim lfromdate As String = ""
        theObject = Page.Master.FindControl("ContentArea").FindControl("sbtransfromdate")
        If theObject IsNot Nothing Then
            If (theObject.Value & "").Trim <> "" Then
                Dim thedate As String = WebUtils.FormatDateDDMMYYYYtoYYYYMMDD(theObject.Value)
                lfromdate = WebUtils.FormatDateDMY(theObject.Value.ToString())
            End If
        End If

        Dim ltodate As String = ""
        theObject = Page.Master.FindControl("ContentArea").FindControl("sbtranstodate")
        If theObject IsNot Nothing Then
            If (theObject.Value & "").Trim <> "" Then
                Dim thedate As String = WebUtils.FormatDateDDMMYYYYtoYYYYMMDD(theObject.Value)
                ltodate = WebUtils.FormatDateDMY(theObject.Value.ToString())
            End If
        End If

        titleaddon.Value = " (" + lfromdate + " - " + ltodate + ")"

    End Sub

    Protected Sub SearchtheData()
        Dim lFilterStatement As String = ""
        Dim theObject As Object = Nothing
        Dim oo As New WebSearchMemberVoucherTrans

        theObject = Page.Master.FindControl("ContentArea").FindControl("sbbranch")
        If theObject IsNot Nothing Then
            If (theObject.Value & "").Trim <> "" Then
                If (lFilterStatement & "").Trim <> "" Then
                    lFilterStatement = lFilterStatement & " and "
                End If
                lFilterStatement = lFilterStatement & oo.Branch(theObject.Value)
            End If
        End If

        theObject = Page.Master.FindControl("ContentArea").FindControl("sbcasher")
        If theObject IsNot Nothing Then
            If (theObject.Value & "").Trim <> "" Then
                If (lFilterStatement & "").Trim <> "" Then
                    lFilterStatement = lFilterStatement & " and "
                End If
                lFilterStatement = lFilterStatement & oo.Casher(theObject.Value)
            End If
        End If

        theObject = Page.Master.FindControl("ContentArea").FindControl("sbtype")
        If theObject IsNot Nothing Then
            If (theObject.Value & "").Trim <> "" Then
                If (lFilterStatement & "").Trim <> "" Then
                    lFilterStatement = lFilterStatement & " and "
                End If
                lFilterStatement = lFilterStatement & oo.Type(theObject.Value)
            End If
        End If

        theObject = Page.Master.FindControl("ContentArea").FindControl("sbmemberid")
        If theObject IsNot Nothing Then
            If (theObject.Value & "").Trim <> "" Then
                If (lFilterStatement & "").Trim <> "" Then
                    lFilterStatement = lFilterStatement & " and "
                End If
                lFilterStatement = lFilterStatement & oo.MemberId(theObject.Value)
            End If
        End If

        theObject = Page.Master.FindControl("ContentArea").FindControl("sbmembername")
        If theObject IsNot Nothing Then
            If (theObject.Value & "").Trim <> "" Then
                If (lFilterStatement & "").Trim <> "" Then
                    lFilterStatement = lFilterStatement & " and "
                End If
                lFilterStatement = lFilterStatement & oo.MemberName(theObject.Value)
            End If
        End If

        theObject = Page.Master.FindControl("ContentArea").FindControl("sbmembertype")
        If theObject IsNot Nothing Then
            If (theObject.Value & "").Trim <> "" Then
                If (lFilterStatement & "").Trim <> "" Then
                    lFilterStatement = lFilterStatement & " and "
                End If
                lFilterStatement = lFilterStatement & oo.MemberType(theObject.Value)
            End If
        End If

        theObject = Page.Master.FindControl("ContentArea").FindControl("sbvouchercode")
        If theObject IsNot Nothing Then
            If (theObject.Value & "").Trim <> "" Then
                If (lFilterStatement & "").Trim <> "" Then
                    lFilterStatement = lFilterStatement & " and "
                End If
                lFilterStatement = lFilterStatement & oo.VoucherCode(theObject.Value)
            End If
        End If

        theObject = Page.Master.FindControl("ContentArea").FindControl("sbvouchername")
        If theObject IsNot Nothing Then
            If (theObject.Value & "").Trim <> "" Then
                If (lFilterStatement & "").Trim <> "" Then
                    lFilterStatement = lFilterStatement & " and "
                End If
                lFilterStatement = lFilterStatement & oo.VoucherName(theObject.Value)
            End If
        End If

        theObject = Page.Master.FindControl("ContentArea").FindControl("sbvouchertype")
        If theObject IsNot Nothing Then
            If (theObject.Value & "").Trim <> "" Then
                If (lFilterStatement & "").Trim <> "" Then
                    lFilterStatement = lFilterStatement & " and "
                End If
                lFilterStatement = lFilterStatement & oo.VoucherType(theObject.Value)
            End If
        End If

        Dim lfromdate As String = ""
        theObject = Page.Master.FindControl("ContentArea").FindControl("sbtransfromdate")
        If theObject IsNot Nothing Then
            If (theObject.Value & "").Trim <> "" Then
                Dim thedate As String = WebUtils.FormatDateDDMMYYYYtoYYYYMMDD(theObject.Value)
                lfromdate = WebUtils.FormatDateFullFormatDDMMYYYYtoYYYYMMDD(theObject.Value.ToString())
            End If
        End If

        Dim ltodate As String = ""
        theObject = Page.Master.FindControl("ContentArea").FindControl("sbtranstodate")
        If theObject IsNot Nothing Then
            If (theObject.Value & "").Trim <> "" Then
                Dim thedate As String = WebUtils.FormatDateDDMMYYYYtoYYYYMMDD(theObject.Value)
                ltodate = WebUtils.FormatDateFullFormatDDMMYYYYtoYYYYMMDD(theObject.Value.ToString())
            End If
        End If

        If IsNumeric(lfromdate) = True And IsNumeric(ltodate) = False Then
            ltodate = lfromdate
        End If
        If IsNumeric(ltodate) = True And IsNumeric(lfromdate) = False Then
            lfromdate = ltodate
        End If

        If IsNumeric(lfromdate) = False Or IsNumeric(ltodate) = False Then
            'Not Compulsory
        Else

            If (lFilterStatement & "").Trim <> "" Then
                lFilterStatement = lFilterStatement & " and "
            End If
            lFilterStatement = lFilterStatement & "(" & oo.TransDate(lfromdate, 0, , ">=") & " and " & oo.TransDate(ltodate, 0, , "<=") & ")"

        End If

        If lFilterStatement.Trim <> "" Then
            FilterStatement = lFilterStatement
            Call AdvanceSearchDate()
            Call loaddata(DBSQL)
        End If

    End Sub

    Public Sub LogtheAudit(ByVal theMessage As String)
        Dim strFile As String = "c:\officeonelog\ErrorLogCRM.txt"
        Dim fileExists As Boolean = File.Exists(strFile)

        Try

            Using sw As New StreamWriter(File.Open(strFile, FileMode.Append))
                sw.WriteLine(DateTime.Now & " - " & theMessage)
            End Using
        Catch ex As Exception

        End Try

    End Sub
End Class


