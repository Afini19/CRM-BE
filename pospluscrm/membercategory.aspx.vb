Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class merbercategory_class


    Inherits basepage
    Dim CODEFIELD As String = ""
    Dim theMerchantID As String = System.Configuration.ConfigurationSettings.AppSettings("themerchantid")
    Dim theFilter As String = System.Configuration.ConfigurationSettings.AppSettings("thefilter")
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = ""
        DBConnection = System.Configuration.ConfigurationSettings.AppSettings("ConnStrCRM")

        ActionType = "PPMC"
        PageDetail = ""
        PageListing = "membercategorylist.aspx"
        EnableDelete = False
        PageTitle = "Member Category"
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
        Framework_MenuLeftCSS = WebMenuEnquiry.LeftBarSmallPaddingCSS
        Framework_MenuLeftCode = ""
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

        If (cc_code.Text & "").Trim = "" Then
            ShowAlert("Code is Mandatory")
            Return False
        End If
        If (cc_name.Text & "").Trim = "" Then
            ShowAlert("Description is Mandatory")
            Return False
        End If
        Return True
    End Function
    Public Sub savedata()

        If (doValidation() = False) Then
            Exit Sub
        End If
        Dim lsql As String = ""
        If (uid.value & "").trim = "" Then
            lsql = "Insert Into CustomerCat (cc_code,cc_name,cc_merchantid,cc_filter,cc_createby,cc_createdt,cc_updateby,cc_updatedt) values ('" & cc_code.Text & "','" & cc_name.Text & "','" & themerchantid & "','" & theFilter & "','" & weblib.UserCode & "',getdate(),'" & weblib.UserCode & "',getdate())"
        Else
            lsql = "Update CustomerCat set cc_code='" & cc_code.Text & "',cc_name='" & cc_name.Text & "',cc_updateby='" & weblib.UserCode & "',cc_updatedt=getdate() where cc_id=" & uid.value & " and cc_merchantid='" & themerchantid & "' and cc_filter='" & theFilter & "'"
        End If
        If (WebUtils.ExecuteSQL(lsql, DBConnection) = False) Then
            ShowPromptV2("Error Saving, Please Retry", "")
        Else
            response.redirect(PageListing)
        End If

    End Sub

    Protected Function LoadSQLfromCloud() As DataSet
        Dim cn As New OleDb.OleDbConnection(DBConnection)
        Dim cmd As New OleDb.OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim ltemp As String = ""


        Try
            Dim lFilterstatement As String = " cc_merchantid='" & theMerchantID & "' and cc_Filter='" & theFilter & "' and cc_id=" & uid.value
            cn.Open()
            cmd.CommandText = "select * from CustomerCat where " & lFilterstatement & ""
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            cn.Close()
            cmd.Dispose()
            cn.Dispose()

            Return ds
        Catch ex As Exception
            ShowPromptV2(ex.Message, "")
            Return Nothing
        End Try
    End Function
    Public Sub deleterec()
        Dim lError As String = ""
        If (doValidation() = False) Then
            Exit Sub
        End If
        Dim lsql As String = ""
        If (uid.value & "").trim = "" Then
            ShowPromptV2("Error Saving, Please Retry", "")
            Exit Sub
        Else
            lsql = "Delete from CustomerCat where cc_id=" & uid.value & " and cc_merchantid='" & themerchantid & "' and cc_filter='" & theFilter & "'"
        End If
        If (WebUtils.ExecuteSQL(lsql, DBConnection) = False) Then
            ShowPromptV2("Error Saving, Please Retry", "")
        Else
            response.redirect(PageListing)
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
                cc_code.Text = dr("cc_code") & ""
                cc_name.Text = dr("cc_name") & ""
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

