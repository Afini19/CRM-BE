Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System

Partial Public Class membereventcategorylistme_class

    Inherits basepagelist
    Dim CODEFIELD As String = ""
    Dim theMerchantID As String = System.Configuration.ConfigurationSettings.AppSettings("themerchantid")
    Dim theFilter As String = System.Configuration.ConfigurationSettings.AppSettings("thefilter")
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = ""
        DBConnection = System.Configuration.ConfigurationSettings.AppSettings("ConnStrCRM")


        PageTitle = "Event Member Points Settings"
        ActionType = "PPMCE"
        FieldUID = ""
        FieldMerchantID = ""
        FieldDefaultSort = ""
        PageDetail = "membereventcategoryme.aspx"
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
            AssignDefaultValues()
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
        sb.AppendLine(TableUtils.GenBarSeparator())
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


        Dim pFieldNames As String = "LoyaltyEventDiscCat.*,cc_name as cc_name"
        Dim pJoinFields As String = " left outer join customercat on lec_mcode = cc_code "


        Try
            Dim lFilterstatement As String = " lec_merchantid='" & theMerchantID & "' and lec_Filter='" & theFilter & "'"
            If FilterStatement.Trim <> "" Then
                lFilterstatement = lFilterstatement & " and " & FilterStatement
            End If

            cn.Open()
            cmd.CommandText = "select " & pFieldNames & " from LoyaltyEventDiscCat " & pJoinFields & " where " & lFilterstatement & ""
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            LogtheAudit(cmd.CommandText)

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

    Protected Sub AssignDefaultValues()
        Dim theObject As Object = Nothing

        theObject = Page.Master.FindControl("ContentArea").FindControl("sbefffromdate")
        If theObject IsNot Nothing Then
            theObject.Value = DateTime.Now.ToString("dd/MM/yyyy")
        End If

        theObject = Page.Master.FindControl("ContentArea").FindControl("sbefftodate")
        If theObject IsNot Nothing Then
            theObject.Value = DateTime.Now.ToString("dd/MM/yyyy")
        End If

        theObject = Page.Master.FindControl("ContentArea").FindControl("sbfromdate")
        If theObject IsNot Nothing Then
            theObject.Value = DateTime.Now.ToString("dd/MM/yyyy")
        End If

        theObject = Page.Master.FindControl("ContentArea").FindControl("sbtodate")
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
                sb.Append("<td>" & drv.Row("lec_id").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("lec_mcode").ToString.Trim & "</td>")


                sb.Append("<td>" & WebUtils.FormatDateDMY(drv.Row("lec_fromdate")) & "</td>")
                sb.Append("<td>" & WebUtils.FormatDateDMY(drv.Row("lec_todate")) & "</td>")
                sb.Append("<td>" & drv.Row("lec_transtype").ToString.Trim & "</td>")

                sb.Append("<td>" & drv.Row("lec_discount").ToString.Trim & "</td>")

                Dim lExplanation As String = "Points Rate : Every <b>" & drv.Row("lec_pointbase").ToString.Trim & "</b> Dollar Value = <b>" & drv.Row("lec_pointrate").ToString.Trim & "</b> Point(s)<br>"

                sb.Append("<td>" & lExplanation & "</td>")
                sb.Append("<td>" & drv.Row("lec_updateby").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("lec_updatedt").ToString.Trim & "</td>")
                sb.Append("</tr>")

                objdata.Text = sb.ToString()
            Catch ex As Exception
                Response.Write("ERROR : " & WebUtils.GetErrorMessage(ex.message))
                Response.End()
            End Try
        End If
    End Sub
    Protected Sub initTables()

        Dim lColumnNames As String = ""

        lColumnNames = lColumnNames & "columns: ["
        lColumnNames = lColumnNames & "{ name: 'uid' },"
        lColumnNames = lColumnNames & "{ name: 'category' },"
        lColumnNames = lColumnNames & "{ name: 'fromdate' },"
        lColumnNames = lColumnNames & "{ name: 'todate' },"
        lColumnNames = lColumnNames & "{ name: 'transtype' },"
        lColumnNames = lColumnNames & "{ name: 'discate' },"
        lColumnNames = lColumnNames & "{ name: 'exp' },"
        lColumnNames = lColumnNames & "{ name: 'updateby' },"
        lColumnNames = lColumnNames & "{ name: 'updateon' }"
        lColumnNames = lColumnNames & "],"



        litthead.Text = "<thead><tr>" &
                        "<th>ID</th>" &
                        "<th>" & "Category" & "</th>" &
                        "<th>" & "Effective From" & "</th>" &
                        "<th>" & "Effective To" & "</th>" &
                        "<th>" & "Transaction Type" & "</th>" &
                        "<th>" & "Discount Rate" & "</th>" &
                        "<th>" & "Points Conversion" & "</th>" &
                        "<th>" & "Last Updated By" & "</th>" &
                        "<th>" & "Last Updated On" & "</th>" &
                        "</tr></thead>"
        littfoot.Text = ""
        litsettings.Text = TableUtils.GetStandard("caishtb", True, True, False, True, , , "", lColumnNames, True, True, True)
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

    Protected Sub SearchtheData()
        Dim lFilterStatement As String = ""
        Dim theObject As Object = Nothing
        Dim oo As New WebSearchMemberEventCategoryMe

        theObject = Page.Master.FindControl("ContentArea").FindControl("sbcategory")
        If theObject IsNot Nothing Then
            If (theObject.Value & "").Trim <> "" Then
                If (lFilterStatement & "").Trim <> "" Then
                    lFilterStatement = lFilterStatement & " and "
                End If
                lFilterStatement = lFilterStatement & oo.Category(theObject.Value)
            End If
        End If

        theObject = Page.Master.FindControl("ContentArea").FindControl("sbtranstype")
        If theObject IsNot Nothing Then
            If (theObject.Value & "").Trim <> "" Then
                If (lFilterStatement & "").Trim <> "" Then
                    lFilterStatement = lFilterStatement & " and "
                End If
                lFilterStatement = lFilterStatement & oo.TransactionType(theObject.Value)
            End If
        End If

        Dim lefffromdate As String = ""
        theObject = Page.Master.FindControl("ContentArea").FindControl("sbefffromdate")
        If theObject IsNot Nothing Then
            If (theObject.Value & "").Trim <> "" Then
                Dim thedate As String = WebUtils.FormatDateDDMMYYYYtoYYYYMMDD(theObject.Value)
                lefffromdate = WebUtils.FormatDateFullFormatDDMMYYYYtoYYYYMMDD(theObject.Value.ToString())
            End If
        End If

        Dim lefftodate As String = ""
        theObject = Page.Master.FindControl("ContentArea").FindControl("sbefftodate")
        If theObject IsNot Nothing Then
            If (theObject.Value & "").Trim <> "" Then
                Dim thedate As String = WebUtils.FormatDateDDMMYYYYtoYYYYMMDD(theObject.Value)
                lefftodate = WebUtils.FormatDateFullFormatDDMMYYYYtoYYYYMMDD(theObject.Value.ToString())
            End If
        End If

        If IsNumeric(lefffromdate) = True And IsNumeric(lefftodate) = False Then
            lefftodate = lefffromdate
        End If
        If IsNumeric(lefftodate) = True And IsNumeric(lefffromdate) = False Then
            lefffromdate = lefftodate
        End If

        If IsNumeric(lefffromdate) = False Or IsNumeric(lefftodate) = False Then
            'Not Compulsory
        Else

            If (lFilterStatement & "").Trim <> "" Then
                lFilterStatement = lFilterStatement & " and "
            End If
            lFilterStatement = lFilterStatement & "(" & oo.EffectiveDateFrom(lefffromdate, 0, , ">=") & " and " & oo.EffectiveDateTo(lefftodate, 0, , "<=") & ")"

        End If

        Dim lfromdate As String = ""
        theObject = Page.Master.FindControl("ContentArea").FindControl("sbfromdate")
        If theObject IsNot Nothing Then
            If (theObject.Value & "").Trim <> "" Then
                Dim thedate As String = WebUtils.FormatDateDDMMYYYYtoYYYYMMDD(theObject.Value)
                lfromdate = WebUtils.FormatDateFullFormatDDMMYYYYtoYYYYMMDD(theObject.Value.ToString())
            End If
        End If

        Dim ltodate As String = ""
        theObject = Page.Master.FindControl("ContentArea").FindControl("sbtodate")
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
            lFilterStatement = lFilterStatement & "(" & oo.CreateDate(lfromdate, 0, , ">=") & " and " & oo.CreateDate(ltodate, 0, , "<=") & ")"

        End If

        If lFilterStatement.Trim <> "" Then
            FilterStatement = lFilterStatement
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


