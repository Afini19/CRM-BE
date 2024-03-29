Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class changepwd_class
    Inherits basepage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = "merchant_multi"
        ActionType = "MML"
        PageDetail = "changepwd.aspx"
        PageListing = "menusplash.aspx"
        EnableDelete = False
        btnDelete.Visible = False
        If Page.IsPostBack = False Then

            Call LoadData()

        End If



        If (WebLib.ActionParamMMUID & "").trim = "" Then
            Response.Redirect("loginmerchant.aspx")
        End If
    End Sub
    Protected Function doValidation() As Boolean

        If (mm_loginpwdold.Text & "").Trim = "" Then
            ShowAlert("Current Password is Mandatory")
            Return False
        End If

        If (mm_loginpwdnew.Text & "").Trim = "" Then
            ShowAlert("New Password is Mandatory")
            Return False
        End If
        If (mm_loginpwdnew.Text.Length) < 6 Then
            ShowAlert("Minimum 6 characters for password")
            Return False
        End If


        If (mm_loginpwdnew2.Text & "").Trim = "" Then
            ShowAlert("Confirm New Password is Mandatory")
            Return False
        End If

        If (mm_loginpwdnew.Text & "").Trim <> (mm_loginpwdnew2.Text & "").Trim Then
            ShowAlert("Confirm New Password not matched")
            Return False
        End If



        If WebLib.HasRecord(DBConnection, DBTableName, "mm_uid", "mm_password='" & mm_loginpwdnew.Text.Replace("'", "''") & "' and mm_uid='" & WebLib.ActionParamMMUID & "' and mm_loginid='" & WebLib.UserID & "'", "mm_merchantid", WebLib.MerchantID) = True Then
            ShowAlert("Wrong Current Password")
            Return False
        End If


        Return True
    End Function
    Public Sub savedata(ByVal sender As System.Object, ByVal e As System.EventArgs)



        Dim insertfields, insertvalues, updatedelwhere As String
        Dim ldocno As String = ""
        Dim luid As String = ""
        Dim lType As String = ""
        Dim lError As String = ""
        Dim _logincode As String = ""

        insertfields = ""
        insertvalues = ""
        updatedelwhere = ""

        If doValidation() = False Then
            Exit Sub
        End If


        Try

            If uid.Value.Trim = "" Then
                ShowAlert("Invalid User. Cannot change password")
                Exit Sub
            Else

                lType = "E"
                insertfields = ""
                insertvalues = insertvalues & "mm_password='" & mm_loginpwdnew.text.Replace("'", "''") & "'"
                insertvalues = insertvalues & ",mm_updateby='" & WebLib.UserCode.replace("'", "''") & "'"
                insertvalues = insertvalues & ",mm_updatedt=getdate()"

                updatedelwhere = "mm_uid='" & uid.Value & "' and mm_loginid='" & WebLib.UserID & "' and mm_merchantid='" & WebLib.MerchantID & "'"
            End If

            If SaveDBData(lType, DBTableName, insertfields, insertvalues, updatedelwhere, lError, "") = True Then

                ShowPrompt("Password Updated ", PageListing)
            Else
                ShowAlert("Error Submitting. Please Retry ")
            End If

        Catch Err As Exception
            ShowAlert("Error: " & Err.Message)
        Finally

        End Try


    End Sub
    Public Sub backpage(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call gotoTheback()

    End Sub
    Public Sub gotoTheback()
        Response.Redirect(PageListing)
    End Sub
    Public Sub deleterec(ByVal sender As System.Object, ByVal e As System.EventArgs)
 
    End Sub

    Protected Sub LoadData()
        Dim cn As New OleDbConnection(DBConnection)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow

        Try
            cn.Open()
            cmd.CommandText = "Select mm_password,mm_uid from " & DBTableName & " where mm_loginid='" & WebLib.UserID & "' and mm_uid='" & WebLib.ActionParamMMUID.trim & "' and mm_merchantid='" & WebLib.MerchantID & "'"
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows
                counter = counter + 1
                uid.value = dr("mm_uid") & ""
                Exit For
            Next

            cn.Close()
            cmd.Dispose()
            cn.Dispose()


            If EnableDelete = True Then
                btnDelete.Visible = True
            End If
        Catch ex As Exception
            ShowAlert("Ooops... We are encoutering heavy access. Please try again")
            Exit Sub
        End Try




    End Sub



End Class

