Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class taxcode_class


    Inherits basepage
    Dim CODEFIELD As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = ""
        ActionType = "TAX"
        PageDetail = ""
        PageListing = "taxcodelist.aspx"
        EnableDelete = False
        PageTitle = "Tax Code Maintenance"
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
            Dim ooo As New OfficeOne.WebServices.BLogic.FinanceValidation
            Call WebUtils.CreateDropDownFromDS(ooo.MASTER_TAXTYPE(), tx_type, "name", "code", "")
            ooo = Nothing

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

        If (tx_taxcode.Text & "").Trim = "" Then
            ShowAlert("Tax Code is Mandatory")
            Return False
        End If
        If isnumeric(tx_percent.Text & "") = False Then
            ShowAlert("Tax Percent is Mandatory")
            Return False
        End If
        Return True
    End Function

    Private Function ConstructJSON(ByVal Mode) As String


        Dim theJSON As String
        Dim sb As New System.Text.StringBuilder
        sb.Append("{""DataSubmit"":[{")
        sb.Append("""tx_taxcode"":""" + tx_taxcode.Text + """")
        sb.Append(",""tx_description"":""" + tx_description.Text + """")
        sb.Append(",""tx_percent"":""" + tx_percent.text + """")
        sb.Append(",""tx_accno"":""" + tx_accno.text + """")
        sb.Append(",""tx_type"":""" + tx_type.Selectedvalue + """")
        sb.Append(",""tx_govttaxcode"":""" + tx_govttaxcode.text + """")
        sb.Append(",""tx_zerorate"":""" & tx_zerorate.checked & """")
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

        Dim oo As New OfficeOne.WebServices.BLogic.FinanceValidation
        oo.ConnectionString = DBConnection
        oo.MerchantMerchantID = WebLib.MerchantID
        oo.MerchantFilter = WebLib.FilterCode

        Dim rtnobject As Boolean
        rtnobject = oo.SAVE_TaxData(theJSON, WebLib.UserID)
        If rtnobject = False Then
            ShowAlert(oo.ErrorMsg)
        Else
            WebLib.ActionUID = ""
            WebLib.ActionType = ActionType
            Response.Redirect(PageListing)
        End If


    End Sub

    Protected Function LoadSQLfromCloud() As DataSet
        Dim oo As New OfficeOne.WebServices.BLogic.FinanceValidation
        oo.ConnectionString = DBConnection
        oo.MerchantMerchantID = WebLib.MerchantID
        oo.MerchantFilter = WebLib.FilterCode

        Return oo.GetTaxDetailsByCriteria(" tx_uid='" & uid.value & "'", "")

    End Function
    Public Sub deleterec()
        Dim lError As String = ""
        Dim theJSON As String

        theJSON = ConstructJSON("D")

        Dim oo As New OfficeOne.WebServices.BLogic.FinanceValidation
        oo.ConnectionString = DBConnection
        oo.MerchantMerchantID = WebLib.MerchantID
        oo.MerchantFilter = WebLib.FilterCode

        Dim rtnobject As Boolean
        rtnobject = oo.SAVE_TaxData(theJSON, WebLib.UserID)
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
                tx_taxcode.Text = dr("tx_taxcode") & ""
                tx_description.Text = dr("tx_description") & ""
                tx_percent.Text = dr("tx_percent") & ""
                tx_accno.Text = dr("tx_accno") & ""

                tx_govttaxcode.Text = dr("tx_govttaxcode") & ""
                tx_zerorate.checked = OfficeOne.Gen.Library.Utility.BitToBoolean(dr("tx_zerorate") & "")

                templi = tx_type.Items.FindByValue(dr("tx_type") & "")
                tx_type.SelectedIndex = tx_type.Items.IndexOf(templi)

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

