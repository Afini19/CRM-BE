Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class membercategorylistme_class

    Inherits basepagelist
    Dim CODEFIELD As String = ""
    Dim theMerchantID As String = System.Configuration.ConfigurationSettings.AppSettings("themerchantid")
    Dim theFilter As String = System.Configuration.ConfigurationSettings.AppSettings("thefilter")
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = ""
        DBConnection = System.Configuration.ConfigurationSettings.AppSettings("ConnStrCRM")


        PageTitle = "Members Category Settings"
        ActionType = "PPMCE"
        FieldUID = ""
        FieldMerchantID = ""
        FieldDefaultSort = ""
        PageDetail = "membercategoryme.aspx"
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


        Dim pFieldNames As String = "ldc_id,cc_name as ldc_catid,ldc_discount,ldc_from,ldc_to,ldc_createby,ldc_createdt,ldc_updateby,ldc_updatedt,ldc_Active,ldc_pointrate,ldc_pointbase,ldc_paypointsfrom,ldc_paypointsto"
        Dim pJoinFields As String = " inner join customercat on ldc_catid = cc_id "


        Try
            Dim lFilterstatement As String = "ldc_merchantid='" & theMerchantID & "' and ldc_Filter='" & theFilter & "'"
            If FilterStatement.Trim <> "" Then
                lFilterstatement = lFilterstatement & " and " & FilterStatement
            End If

            cn.Open()
            cmd.CommandText = "select " & pFieldNames & " from LoyaltyDiscCat " & pJoinFields & " where " & lFilterstatement & ""

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
                sb.Append("<td>" & drv.Row("ldc_id").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("ldc_catid").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("ldc_discount").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("ldc_from").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("ldc_to").ToString.Trim & "</td>")

                Dim lExplanation As String = ""

                If isnumeric(drv.Row("ldc_pointbase") & "") And isnumeric(drv.Row("ldc_pointrate") & "") Then

                    lExplanation = "Every <b>" & drv.Row("ldc_pointbase").ToString.Trim & "</b> Dollar Value = <b>" & drv.Row("ldc_pointrate").ToString.Trim & "</b> Point(s)<br>"
                Else
                    lExplanation = "- NOT APPLICABLE -"
                End If
                sb.Append("<td>" & lExplanation & "</td>")

                If isnumeric(drv.Row("ldc_paypointsfrom") & "") And isnumeric(drv.Row("ldc_paypointsto") & "") Then
                    lExplanation = "Every <b>" & drv.Row("ldc_paypointsfrom").ToString.Trim & "</b> Points Value = <b>" & drv.Row("ldc_paypointsto").ToString.Trim & "</b> Dollar Value<br>"
                Else
                    lExplanation = "- NOT APPLICABLE -"
                End If

                sb.Append("<td>" & lExplanation & "</td>")

                sb.Append("<td>" & drv.Row("ldc_updateby").ToString.Trim & "</td>")
                sb.Append("<td>" & drv.Row("ldc_updatedt").ToString.Trim & "</td>")
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
        lColumnNames = lColumnNames & "{ name: 'Category' },"
        lColumnNames = lColumnNames & "{ name: 'discate' },"
        lColumnNames = lColumnNames & "{ name: 'from' },"
        lColumnNames = lColumnNames & "{ name: 'to' },"
        lColumnNames = lColumnNames & "{ name: 'exp' },"
        lColumnNames = lColumnNames & "{ name: 'exp2' },"
        lColumnNames = lColumnNames & "{ name: 'updateby' },"
        lColumnNames = lColumnNames & "{ name: 'updateon' }"
        lColumnNames = lColumnNames & "],"



        litthead.Text = "<thead><tr>" &
                        "<th>ID</th>" &
                        "<th>" & "Category" & "</th>" &
                        "<th>" & "Discount Rate" & "</th>" &
                        "<th>" & "Spending From" & "</th>" &
                        "<th>" & "Spending To" & "</th>" &
                        "<th>" & "Points Collection Rate" & "</th>" &
                        "<th>" & "Points to Payment Rate" & "</th>" &
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
        Dim oo As New WebSearchMemberCategoryMe

        theObject = Page.Master.FindControl("ContentArea").FindControl("sbcategory")
        If theObject IsNot Nothing Then
            If (theObject.Value & "").Trim <> "" Then
                If (lFilterStatement & "").Trim <> "" Then
                    lFilterStatement = lFilterStatement & " and "
                End If
                lFilterStatement = lFilterStatement & oo.Category(theObject.Value)
            End If
        End If

        theObject = Page.Master.FindControl("ContentArea").FindControl("sbdiscrate")
        If theObject IsNot Nothing Then
            If (theObject.Value & "").Trim <> "" Then
                If (lFilterStatement & "").Trim <> "" Then
                    lFilterStatement = lFilterStatement & " and "
                End If
                lFilterStatement = lFilterStatement & oo.DiscountRate(theObject.Value)
            End If
        End If

        theObject = Page.Master.FindControl("ContentArea").FindControl("sbspendingfrom")
        If theObject IsNot Nothing Then
            If (theObject.Value & "").Trim <> "" Then
                If (lFilterStatement & "").Trim <> "" Then
                    lFilterStatement = lFilterStatement & " and "
                End If
                lFilterStatement = lFilterStatement & oo.SpendingFrom(theObject.Value)
            End If
        End If

        theObject = Page.Master.FindControl("ContentArea").FindControl("sbspendingto")
        If theObject IsNot Nothing Then
            If (theObject.Value & "").Trim <> "" Then
                If (lFilterStatement & "").Trim <> "" Then
                    lFilterStatement = lFilterStatement & " and "
                End If
                lFilterStatement = lFilterStatement & oo.SpendingTo(theObject.Value)
            End If
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


