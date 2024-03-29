Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class exrate_class


    Inherits basepage
    Dim CODEFIELD As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = ""
        ActionType = "ERM"
        PageDetail = ""
        PageListing = "exratelist.aspx"
        EnableDelete = False
        PageTitle = "Exchange Rate Maintenance"
        FieldUID = ""
        FieldMerchantID = ""
        FieldDefaultSort = ""

        Framework_Back = PageListing
        GenRightBar()
        GetSideMenu()

        If Page.IsPostBack = False Then
            uid.Value = WebLib.ActionUID
            If (WebLib.ActionType <> ActionType) Then
                Response.Redirect(PageListing)
            End If
 
            Call LoadData()
        End If


    End Sub
    Protected Sub GetSideMenu()
        Framework_MenuLeftBar = True
        Framework_MenuLeftCSS = WebMenuEnquiry.LeftBarPaddingCSS
        Framework_MenuLeftCode = WebMenuFinance.Finance("S")
    End Sub
    Protected Sub GenRightBar()
        Dim sb As New StringBuilder
        sb.AppendLine("<span style=""display:flex;"">")
        sb.AppendLine(TableUtils.GenBarOptions("save", "Save", "SAVE", eventtype.ClientID, eventfire.ClientID))
        sb.AppendLine(TableUtils.GenBarSeparator())
        sb.AppendLine(TableUtils.GenBarOptions("delete", "Delete Record", "DELETE", eventtype.ClientID, eventfire.ClientID))
        sb.AppendLine("</span>")
        Framework_RightNavBar = sb.ToString()
    End Sub

    Protected Function doValidation() As Boolean

        If (exr_curr1.Text & "").Trim = "" Then
            ShowAlert("From Currency is Mandatory")
            Return False
        End If
        If (exr_curr2.Text & "").Trim = "" Then
            ShowAlert("To Currency is Mandatory")
            Return False
        End If
        Return True
    End Function

    Private Function ConstructJSON(ByVal Mode) As String


        Dim theJSON As String
        Dim sb As New System.Text.StringBuilder
        sb.Append("{""DataSubmit"":[{")
        sb.Append("""exr_curr1"":""" + exr_curr1.Text + """")
        sb.Append(",""exr_curr2"":""" + exr_curr2.Text + """")
        sb.Append(",""exr_start_date"":""" + WebUtils.FormatDateFullFormatDDMMYYYYtoYYYYMMDD(exr_start_date.value) + """")
        sb.Append(",""exr_end_date"":""" + WebUtils.FormatDateFullFormatDDMMYYYYtoYYYYMMDD(exr_end_date.value) + """")
        sb.Append(",""exr_rate"":""" + exr_rate.text + """")
        sb.Append(",""exr_rate2"":""" + exr_rate2.text + """")
        sb.Append(",""mode"":""" + Mode + """")
        sb.Append(",""uid"":""" + uid.value & "" + """")
        sb.Append("}]}")
        theJSON = sb.ToString()

        Return theJSON
    End Function

    Public Sub savedata()

        If doValidation() = False Then
            Exit Sub
        End If
        Dim theJSON As String
        Dim lError As String = ""
        If (uid.Value & "").Trim <> "" Then
            theJSON = ConstructJSON("E")
        Else
            theJSON = ConstructJSON("")
        End If

        Dim oo As New OfficeOne.WebServices.BLogic.Currency
        oo.ConnectionString = DBConnection
        oo.MerchantMerchantID = WebLib.MerchantID
        oo.MerchantFilter = WebLib.FilterCode

        Dim rtnobject As Boolean
        rtnobject = oo.SAVE_CURRData(theJSON, WebLib.UserID)
        If rtnobject = False Then
            ShowAlert(oo.ErrorMsg)
        Else
            WebLib.ActionUID = ""
            WebLib.ActionType = ActionType
            Response.Redirect(PageListing)
        End If


    End Sub

    Protected Function LoadSQLfromCloud() As DataSet
        Dim oo As New OfficeOne.WebServices.BLogic.Currency
        oo.ConnectionString = DBConnection
        oo.MerchantMerchantID = WebLib.MerchantID
        oo.MerchantFilter = WebLib.FilterCode

        Return oo.GetExchangeRateByCriteria(" exr_uid='" & uid.value & "'", "")

    End Function
    Public Sub deleterec()
        Dim lError As String = ""
        Dim theJSON As String

        theJSON = ConstructJSON("D")

        Dim oo As New OfficeOne.WebServices.BLogic.Currency
        oo.ConnectionString = DBConnection
        oo.MerchantMerchantID = WebLib.MerchantID
        oo.MerchantFilter = WebLib.FilterCode

        Dim rtnobject As Boolean
        rtnobject = oo.SAVE_CURRData(theJSON, WebLib.UserID)
        If rtnobject = False Then
            ShowAlert(oo.ErrorMsg)
        Else
            WebLib.ActionUID = ""
            WebLib.ActionType = ActionType
            Response.Redirect(PageListing)
        End If

    End Sub
    Protected Sub LoadData()


        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim templi As ListItem

        Try

            If (uid.Value & "").Trim = "" Then
                Exit Sub
            End If
            ds = LoadSQLfromCloud()
            If ds Is Nothing Then
                ShowAlert("Ooops... We are encoutering heavy access. Please try again")
                Exit Sub
            End If

            For Each dr In ds.Tables(0).Rows
                counter = counter + 1
                exr_curr1.Text = dr("exr_curr1") & ""
                exr_curr2.Text = dr("exr_curr2") & ""
                exr_rate.Text = dr("exr_rate") & ""
                exr_rate2.Text = dr("exr_rate2") & ""


                exr_start_date.value = WebUtils.FormatDateDMY(dr("exr_start_date"))
                exr_end_date.value = WebUtils.FormatDateDMY(dr("exr_end_date"))
                Exit For
            Next
        Catch ex As Exception
            ShowAlert("Ooops... We are encoutering heavy access. Please try again")
            Exit Sub
        End Try

    End Sub
    Public Sub eventfiresub(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If eventtype.Value = "SAVE" Then
            Call savedata()
        End If

        If eventtype.Value = "DELETE" Then
            Call deleterec()
        End If

    End Sub



End Class

