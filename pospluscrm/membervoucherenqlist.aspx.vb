Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System

Partial Public Class membervoucherenqlist_class

    Inherits basepagelist
    Dim CODEFIELD As String = ""
    Dim theMerchantID As String = System.Configuration.ConfigurationSettings.AppSettings("themerchantid")
    Dim theFilter As String = System.Configuration.ConfigurationSettings.AppSettings("thefilter")
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = ""
        DBConnection = System.Configuration.ConfigurationSettings.AppSettings("ConnStrCRM")

        PageTitle = "Member Voucher Enquiry"
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
            Call Refresh()
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

    Protected Sub AssignDefaultValues()
        Dim theObject As Object = Nothing

        theObject = Page.Master.FindControl("ContentArea").FindControl("sbdobfromdate")
        If theObject IsNot Nothing Then
            theObject.Value = DateTime.Now.ToString("dd/MM/yyyy")
        End If

        theObject = Page.Master.FindControl("ContentArea").FindControl("sbdobtodate")
        If theObject IsNot Nothing Then
            theObject.Value = DateTime.Now.ToString("dd/MM/yyyy")
        End If

        'theObject = Page.Master.FindControl("ContentArea").FindControl("sbjoinfromdate")
        'If theObject IsNot Nothing Then
        '    theObject.Value = DateTime.Now.ToString("dd/MM/yyyy")
        'End If

        'theObject = Page.Master.FindControl("ContentArea").FindControl("sbjointodate")
        'If theObject IsNot Nothing Then
        '    theObject.Value = DateTime.Now.ToString("dd/MM/yyyy")
        'End If

    End Sub

    Protected Function LoadSQLfromCloud(Optional includeTop As Boolean = True) As DataSet
        Dim cn As New OleDb.OleDbConnection(DBConnection)
        Dim cmd As New OleDb.OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim ltemp As String = ""

        Dim pFieldNames As String = "ml_id,ml_login, ml_Name, ml_membertype, ml_hpno, ml_email, ml_dob, ml_createdt, vo_amt,vo_type, vo_code, vo_name, mv_refcode, mv_status"
        Dim pJoinFields As String = "left join [storefront2u_app].[dbo].[evouchersmy] on ml_login = mv_memberid left join [storefront2u_app].[dbo].[evoucher] on mv_voucherid = vo_id"
        Dim pOrderBy As String = "order by ml_id desc"
        Dim pTopClause As String = If(includeTop, "TOP (100) ", "")

        Try
            Dim lFilterstatement As String = "ml_merchantid='" & theMerchantID & "'"
            If FilterStatement.Trim <> "" Then
                lFilterstatement = lFilterstatement & " and " & FilterStatement
            End If

            cn.Open()
            cmd.CommandText = "select " & pTopClause & pFieldNames & " from [storefront2u].[dbo].[Members_list] " & pJoinFields & " where " & lFilterstatement & " " & pOrderBy
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
                sb.Append("<td>" & drv.Row("ml_login").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("ml_Name").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("ml_membertype").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("ml_hpno").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("ml_email").ToString.Trim & "</td>")
                sb.Append("<td>" & WebUtils.FormatDateDMY(drv.Row("ml_dob").ToString.Trim) & "</td>")
                sb.Append("<td>" & WebUtils.FormatDateDMY(drv.Row("ml_createdt").ToString.Trim) & "</td>")
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
                sb.Append("<td>" & drv.Row("vo_amt").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("mv_refcode").ToString.Trim & "</td>")
                'sb.Append("<td>" & drv.Row("mv_status").ToString.Trim & "</td>")
                If drv.Row("mv_status").ToString.Trim = "Used" Then
                    sb.Append("<td>" & "Used" & "</td>")
                Else
                    sb.Append("<td>" & "Unused" & "</td>")
                End If
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
        lColumnNames = lColumnNames & "{ name: 'membername' },"
        lColumnNames = lColumnNames & "{ name: 'membertype' },"
        lColumnNames = lColumnNames & "{ name: 'memberphoneno' },"
        lColumnNames = lColumnNames & "{ name: 'memberemail' },"
        lColumnNames = lColumnNames & "{ name: 'memberdob' },"
        lColumnNames = lColumnNames & "{ name: 'memberjoindt' },"
        lColumnNames = lColumnNames & "{ name: 'vouchercode' },"
        lColumnNames = lColumnNames & "{ name: 'vouchername' },"
        lColumnNames = lColumnNames & "{ name: 'vouchertype' },"
        lColumnNames = lColumnNames & "{ name: 'voucheramount' },"
        lColumnNames = lColumnNames & "{ name: 'refcode' },"
        lColumnNames = lColumnNames & "{ name: 'status' }"
        lColumnNames = lColumnNames & "],"

        litthead.Text = "<thead><tr>" &
                        "<th>ID</th>" &
                        "<th>" & "Name" & "</th>" &
                        "<th>" & "Type" & "</th>" &
                        "<th>" & "Phone Number" & "</th>" &
                        "<th>" & "Email" & "</th>" &
                        "<th>" & "Date of Birth" & "</th>" &
                        "<th>" & "Join Date" & "</th>" &
                        "<th>" & "Voucher Code" & "</th>" &
                        "<th>" & "Voucher Name" & "</th>" &
                        "<th>" & "Voucher Type" & "</th>" &
                        "<th>" & "Voucher Amount" & "</th>" &
                        "<th>" & "Reference Code" & "</th>" &
                        "<th>" & "Status" & "</th>" &
                        "</tr></thead>"
        littfoot.Text = ""
        litsettings.Text = TableUtils.GetStandard("caishtb", True, True, False, True, , , "", lColumnNames, True, True, True)
    End Sub
    Public Sub loaddata(ByVal SQLQuery As String, Optional ByVal includeTop As Boolean = True)

        Dim ds As New DataSet()


        Try

            ds = LoadSQLfromCloud(includeTop)

            Dim dt As DataTable = ds.Tables(0)
            Dim dv As New DataView(dt)

            Dim pgitems As New PagedDataSource()
            pgitems.DataSource = dv
            pgitems.AllowPaging = False


            rep.DataSource = pgitems
            rep.DataBind()


        Catch ex As Exception
            Response.Write(ex.Message)
            LogtheAudit(ex.Message)
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

    Protected Sub SearchtheData()
        Dim lFilterStatement As String = ""
        Dim theObject As Object = Nothing
        Dim oo As New WebSearchMemberVoucherEnquiry

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

        theObject = Page.Master.FindControl("ContentArea").FindControl("sbphoneno")
        If theObject IsNot Nothing Then
            If (theObject.Value & "").Trim <> "" Then
                If (lFilterStatement & "").Trim <> "" Then
                    lFilterStatement = lFilterStatement & " and "
                End If
                lFilterStatement = lFilterStatement & oo.MemberPhoneNo(theObject.Value)
            End If
        End If

        theObject = Page.Master.FindControl("ContentArea").FindControl("sbemail")
        If theObject IsNot Nothing Then
            If (theObject.Value & "").Trim <> "" Then
                If (lFilterStatement & "").Trim <> "" Then
                    lFilterStatement = lFilterStatement & " and "
                End If
                lFilterStatement = lFilterStatement & oo.MemberEmail(theObject.Value)
            End If
        End If

        theObject = Page.Master.FindControl("ContentArea").FindControl("sbstatus")
        If theObject IsNot Nothing Then
            If (theObject.Value & "").Trim <> "" Then
                If (lFilterStatement & "").Trim <> "" Then
                    lFilterStatement = lFilterStatement & " and "
                End If
                lFilterStatement = lFilterStatement & oo.Status(theObject.Value)
            End If
        End If

        Dim ldobmonthfrom As Integer = 0
        theObject = Page.Master.FindControl("ContentArea").FindControl("sbdobmonthfrom")
        If theObject IsNot Nothing Then
            If (theObject.Value.ToString() <> 0) Then
                ldobmonthfrom = theObject.Value
            End If
        End If

        Dim ldobmonthto As Integer = 0
        theObject = Page.Master.FindControl("ContentArea").FindControl("sbdobmonthto")
        If theObject IsNot Nothing Then
            If (theObject.Value.ToString() <> 0) Then
                ldobmonthto = theObject.Value
            End If
        End If

        If IsNumeric(ldobmonthfrom) = True And IsNumeric(ldobmonthto) = False Then
            ldobmonthto = ldobmonthfrom
        End If
        If IsNumeric(ldobmonthto) = True And IsNumeric(ldobmonthfrom) = False Then
            ldobmonthfrom = ldobmonthto
        End If

        If IsNumeric(ldobmonthfrom) = False Or IsNumeric(ldobmonthto) = False Then
            'Not Compulsory
        Else

            If (lFilterStatement & "").Trim <> "" Then
                lFilterStatement = lFilterStatement & " and "
            End If
            lFilterStatement = lFilterStatement & oo.DOBMonth(ldobmonthfrom, ldobmonthto)

        End If

        Dim ljoinfromdate As String = ""
        theObject = Page.Master.FindControl("ContentArea").FindControl("sbjoinfromdate")
        If theObject IsNot Nothing Then
            If (theObject.Value & "").Trim <> "" Then
                Dim thedate As String = WebUtils.FormatDateDDMMYYYYtoYYYYMMDD(theObject.Value)
                ljoinfromdate = WebUtils.FormatDateFullFormatDDMMYYYYtoYYYYMMDD(theObject.Value.ToString())
            End If
        End If

        Dim ljointodate As String = ""
        theObject = Page.Master.FindControl("ContentArea").FindControl("sbjointodate")
        If theObject IsNot Nothing Then
            If (theObject.Value & "").Trim <> "" Then
                Dim thedate As String = WebUtils.FormatDateDDMMYYYYtoYYYYMMDD(theObject.Value)
                ljointodate = WebUtils.FormatDateFullFormatDDMMYYYYtoYYYYMMDD(theObject.Value.ToString())
            End If
        End If

        If IsNumeric(ljoinfromdate) = True And IsNumeric(ljointodate) = False Then
            ljointodate = ljoinfromdate
        End If
        If IsNumeric(ljointodate) = True And IsNumeric(ljoinfromdate) = False Then
            ljoinfromdate = ljointodate
        End If

        If IsNumeric(ljoinfromdate) = False Or IsNumeric(ljointodate) = False Then
            'Not Compulsory
        Else

            If (lFilterStatement & "").Trim <> "" Then
                lFilterStatement = lFilterStatement & " and "
            End If
            lFilterStatement = lFilterStatement & "(" & oo.JoinDate(ljoinfromdate, 0, , ">=") & " and " & oo.JoinDate(ljointodate, 0, , "<=") & ")"

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

        If lFilterStatement.Trim <> "" Then
            FilterStatement = lFilterStatement
            Call loaddata(DBSQL, False) ' Call without TOP 100 for advanced search
        Else
            Call loaddata(DBSQL, True) ' Call with TOP 100 for initial view
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


