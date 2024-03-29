Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class branch_class


    Inherits basepage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = ""
        ActionType = "BRA"
        PageDetail = ""
        PageListing = "branchlist.aspx"
        EnableDelete = False
        PageTitle = "Branch Maintenance"
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
        Framework_MenuLeftCode = WebMenuGeneralSet.Warehouse("S")
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

        If (br_code.Text & "").Trim = "" Then
            ShowAlert("Branch Code is Mandatory")
            Return False
        End If
        If (br_name.Text & "").Trim = "" Then
            ShowAlert("Branch Name is Mandatory")
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
        sb.Append("""br_code"":""" + br_code.Text + """")
        sb.Append(",""br_name"":""" + br_name.Text + """")
        sb.Append(",""br_address1"":""" + br_address1.Text + """")
        sb.Append(",""br_address2"":""" + br_address2.Text + """")
        sb.Append(",""br_address3"":""" + br_address3.Text + """")
        sb.Append(",""br_address4"":""" + br_address4.Text + """")
        sb.Append(",""br_attention"":""" + br_attention.Text + """")
        sb.Append(",""br_telno"":""" + br_telno.Text + """")
        sb.Append(",""br_faxno"":""" + br_faxno.Text + """")
        sb.Append(",""br_email"":""" + br_email.Text + """")
        sb.Append(",""br_terms"":""" + br_terms.Text + """")
        sb.Append(",""br_channel"":""" + br_channel.Text + """")
        sb.Append(",""br_class"":""" + br_class.Text + """")
        sb.Append(",""br_currency"":""" + br_currency.Text + """")
        sb.Append(",""br_site"":""" + br_site.Text + """")
        sb.Append(",""br_dcode"":""" + br_destinationcode.Text + """")
        sb.Append(",""br_locationid"":""" + br_location.Text + """")
        sb.Append(",""br_locationq"":""" + br_locationq.Text + """")
        sb.Append(",""br_locationa"":""" + br_locationa.Text + """")
        sb.Append(",""br_locationr"":""" + br_locationr.Text + """")
        sb.Append(",""br_uid"":""" + uid.value & "" + """")
        sb.Append("}]}")
        theJSON = sb.ToString()

        Dim oo As New OfficeOne.WebServices.BLogic.Branch
        oo.ConnectionString = DBConnection
        oo.MerchantMerchantID = WebLib.MerchantID
        oo.MerchantFilter = WebLib.FilterCode

        Dim rtnobject As Boolean
        rtnobject = oo.SaveBranch(theJSON, WebLib.UserID)
        If rtnobject = False Then
            ShowAlert(oo.ErrorMsg)
        Else
            Response.Redirect(PageListing)
        End If

    End Sub

    Protected Function LoadSQLfromCloud() As DataSet
        Dim oo As New OfficeOne.WebServices.BLogic.Branch
        oo.ConnectionString = DBConnection
        oo.MerchantMerchantID = WebLib.MerchantID
        oo.MerchantFilter = WebLib.FilterCode

        If (uid.value.trim) <> "" Then

            Return oo.GetBranchDataV1(" br_uid='" & uid.value & "'", "")
        Else
            Return Nothing
        End If


    End Function
    Public Sub deleterec()
        Dim lError As String = ""



        If doValidation() = False Then
            Exit Sub
        End If

        Dim oo As New OfficeOne.WebServices.BLogic.GenericAction
        oo.ConnectionString = DBConnection
        oo.MerchantMerchantID = WebLib.MerchantID
        oo.MerchantFilter = WebLib.FilterCode

        Dim theJSON As String
        Dim ds As DataSet

        Dim ooCM As New OfficeOne.WebServices.BLogic.CodeMaster
        ds = ooCM.GetCodeMasterStructure()

        Dim newrow As DataRow
        newrow = ds.Tables(0).NewRow

        newrow("co_uid") = uid.Value
        newrow("co_description") = ""
        newrow("co_codevalue") = ""
        newrow("co_fieldname") = ""
        newrow("co_site") = ""
        newrow("co_para1") = ""
        newrow("co_para2") = ""
        newrow("mode") = "D"

        ds.Tables(0).Rows.Add(newrow)
        newrow = Nothing
        ds.AcceptChanges()


        Dim JSONXML As String = ""
        Dim oJson As New OfficeOne.Gen.Library.JSON
        theJSON = oJson.FromDS(ds)

        Dim rtnobject As Boolean
        rtnobject = oo.TakeActionBoolean("CREATECMASTER", "", "", "", "", "", , , theJSON, , "", WebLib.UserID)
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
                br_code.Text = dr("code") & ""
                br_name.Text = dr("name") & ""
                br_address1.Text = dr("address1") & ""
                br_address2.Text = dr("address2") & ""
                br_address3.Text = dr("address3") & ""
                br_address4.Text = dr("address4") & ""
                br_attention.Text = dr("attention") & ""
                br_class.Text = dr("br_class") & ""
                br_currency.Text = dr("br_currency") & ""
                br_destinationcode.Text = dr("br_dcode") & ""
                br_telno.Text = dr("telno") & ""
                br_faxno.Text = dr("faxno") & ""
                br_email.Text = dr("email") & ""
                br_terms.Text = dr("br_defaultterms") & ""
                br_channel.Text = dr("channel") & ""
                br_site.Text = dr("br_site") & ""
                br_location.Text = dr("locationid") & ""
                br_locationq.Text = dr("br_locationq") & ""
                br_locationa.Text = dr("br_locationa") & ""
                br_locationr.Text = dr("br_locationr") & ""
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

