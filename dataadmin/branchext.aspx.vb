Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class branchext_class


    Inherits basepage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = ""
        ActionType = "BRA"
        PageDetail = ""
        PageListing = "branchextlist.aspx"
        EnableDelete = False
        PageTitle = "Branch Extended Settings"
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
        sb.AppendLine("</span>")
        Framework_RightNavBar = sb.ToString()
    End Sub

    Protected Function doValidation() As Boolean

        Return True
    End Function
    Public Sub savedata()

        If doValidation() = False Then
            Exit Sub
        End If


        Dim theJSON As String


        Dim sb As New System.Text.StringBuilder
        sb.Append("{""DataSubmit"":[{")
        sb.Append("""br_locationid"":""" + br_location.Text + """")
        sb.Append(",""br_locationq"":""" + br_locationq.Text + """")
        sb.Append(",""br_locationa"":""" + br_locationa.Text + """")
        sb.Append(",""br_locationr"":""" + br_locationr.Text + """")
        sb.Append(",""br_itoinmode"":""" + br_itoinmode.checked.tostring() + """")
        sb.Append(",""br_enablepallet"":""" + br_enablepallet.checked.tostring() + """")
        sb.Append(",""br_lotcontrol"":""" + br_lotcontrol.checked.tostring() + """")
        sb.Append(",""br_grnvalidate"":""" + br_lotcontrol.checked.tostring() + """")
        sb.Append(",""br_grnblind"":""" + br_grnblind.checked.tostring() + """")
        sb.Append(",""br_strictarrival1"":""" + br_strictarrival1.checked.tostring() + """")
        sb.Append(",""br_strictarrival2"":""" + br_strictarrival2.checked.tostring() + """")
        sb.Append(",""br_grnnoexp"":""" + br_grnnoexp.checked.tostring() + """")
        sb.Append(",""br_actclass"":""" + br_actclass.checked.tostring() + """")
        sb.Append(",""br_uid"":""" + uid.value & "" + """")
        sb.Append("}]}")
        theJSON = sb.ToString()

        Dim oo As New OfficeOne.WebServices.BLogic.Branch
            oo.ConnectionString = DBConnection
            oo.MerchantMerchantID = WebLib.MerchantID
            oo.MerchantFilter = WebLib.FilterCode

            Dim rtnobject As Boolean
        rtnobject = oo.SaveBranchExt(theJSON, WebLib.UserID)
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
                br_location.Text = dr("locationid") & ""
                br_locationq.Text = dr("br_locationq") & ""
                br_locationa.Text = dr("br_locationa") & ""
                br_locationr.Text = dr("br_locationr") & ""


                If dr("br_itoinmode") & "" = "M" Then
                    br_itoinmode.checked = True
                End If
                br_enablepallet.checked = WebUtils.BitToBoolean(dr("br_enablepallet") & "")
                br_lotcontrol.checked = WebUtils.BitToBoolean(dr("br_lotcontrol") & "")

                br_grnvalidate.checked = WebUtils.BitToBoolean(dr("br_grnvalidate") & "")
                br_grnblind.checked = WebUtils.BitToBoolean(dr("br_grnblind") & "")
                br_recprompt.checked = WebUtils.BitToBoolean(dr("br_recprompt") & "")

                br_grnnoexp.checked = WebUtils.BitToBoolean(dr("br_grnnoexp") & "")
                br_actclass.checked = WebUtils.BitToBoolean(dr("br_actclass") & "")


                If dr("br_strictarrival") & "" = "A" Then
                    br_strictarrival1.checked = True
                    br_strictarrival2.checked = True
                End If
                If dr("br_strictarrival") & "" = "B" Then
                    br_strictarrival1.checked = True
                End If
                If dr("br_strictarrival") & "" = "C" Then
                    br_strictarrival2.checked = True
                End If

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


    End Sub
End Class

