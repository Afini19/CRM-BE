Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class creditterms_class


    Inherits basepage
    Dim CODEFIELD As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = ""
        ActionType = "CTM"
        PageDetail = ""
        PageListing = "credittermslist.aspx"
        EnableDelete = False
        PageTitle = "Credit Terms Maintenance"
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
            Call WebUtils.CreateDropDownFromDS(ooo.MASTER_TERMSPERIOD(), theperiod, "name", "code", "")
            Call WebUtils.CreateDropDownFromDS(ooo.MASTER_TERMSDATE(), thedate, "name", "code", "")
            ooo = Nothing
            Call LoadData()
        End If


    End Sub
    Protected Sub GetSideMenu()
        Framework_MenuLeftBar = True
        Framework_MenuLeftCSS = WebMenuEnquiry.LeftBarPaddingCSS
        Framework_MenuLeftCode = WebMenuGeneralSet.Sales("S")
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

        If (termscode.Text & "").Trim = "" Then
            ShowAlert("Terms Code is Mandatory")
            Return False
        End If
        If (termsname.Text & "").Trim = "" Then
            ShowAlert("Terms Name is Mandatory")
            Return False
        End If
        Return True
    End Function
    Public Sub savedata()

        If doValidation() = False Then
            Exit Sub
        End If

        Dim theJSON As String

        Dim sb As New System.Text.StringBuilder
        sb.Append("{""DataSubmit"":[{")
        sb.Append("""code"":""" + termscode.Text + """")
        sb.Append(",""description"":""" + termsname.Text + """")
        sb.Append(",""days"":""" + thedays.Text + """")
        sb.Append(",""months"":""" + themonths.Text + """")
        sb.Append(",""duetype"":""" + theperiod.selectedvalue + """")
        sb.Append(",""datetype"":""" + thedate.selectedvalue + """")
        If (uid.Value & "").Trim <> "" Then
            sb.Append(",""mode"":""" + "E" + """")
        Else
            sb.Append(",""mode"":""" + "" + """")
        End If
        sb.Append(",""uid"":""" + uid.value & "" + """")
        sb.Append("}]}")
        theJSON = sb.ToString()


        Dim oo As New OfficeOne.WebServices.BLogic.FinanceValidation
        oo.ConnectionString = DBConnection
        oo.MerchantMerchantID = WebLib.MerchantID
        oo.MerchantFilter = WebLib.FilterCode


        Dim rtnobject As Boolean
        rtnobject = oo.SAVE_TERMSData(theJSON, WebLib.UserID)
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




        Return oo.GetTermsDetailsByCriteria(" tm_uid='" & uid.value & "'", "")



    End Function
    Public Sub deleterec()
        Dim lError As String = ""

        Dim theJSON As String

        Dim sb As New System.Text.StringBuilder
        sb.Append("{""DataSubmit"":[{")
        sb.Append("""code"":""" + termscode.Text + """")
        sb.Append(",""description"":""" + termsname.Text + """")
        sb.Append(",""days"":""" + thedays.Text + """")
        sb.Append(",""months"":""" + themonths.Text + """")
        sb.Append(",""duetype"":""" + theperiod.selectedvalue + """")
        sb.Append(",""datetype"":""" + thedate.selectedvalue + """")
        If (uid.Value & "").Trim <> "" Then
            sb.Append(",""mode"":""" + "D" + """")
        Else
            sb.Append(",""mode"":""" + "" + """")
        End If
        sb.Append(",""uid"":""" + uid.value & "" + """")
        sb.Append("}]}")
        theJSON = sb.ToString()


        Dim oo As New OfficeOne.WebServices.BLogic.FinanceValidation
        oo.ConnectionString = DBConnection
        oo.MerchantMerchantID = WebLib.MerchantID
        oo.MerchantFilter = WebLib.FilterCode


        Dim rtnobject As Boolean
        rtnobject = oo.SAVE_TERMSData(theJSON, WebLib.UserID)
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
                termscode.Text = dr("code") & ""
                termsname.Text = dr("description") & ""
                thedays.Text = dr("days") & ""
                themonths.Text = dr("months") & ""


                templi = theperiod.Items.FindByValue(dr("DueType") & "")
                theperiod.SelectedIndex = theperiod.Items.IndexOf(templi)

                templi = thedate.Items.FindByValue(dr("DateType") & "")
                thedate.SelectedIndex = thedate.Items.IndexOf(templi)


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

