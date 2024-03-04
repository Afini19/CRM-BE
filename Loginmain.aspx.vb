Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

 Public Class loginmain_class
    Inherits basepageblank




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Page.IsPostBack = False Then
            WebLib.UserUID = ""
            WebLib.Branchid = ""
            WebLib.UserID = ""
            WebLib.UserCode = ""
            WebLib.UserName = ""
            WebLib.UserEmail = ""
            WebLib.MerchantID = ""
            WebLib.ActionParamMMUID = ""
            WebLib.UserIsFullAdmin = False
            Weblib.Branchid = "0"
            WebLib.BranchName = ""


        End If

    End Sub

    Public Sub loginpage(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        WebLib.MerchantID = ""
        WebLib.MerchantName = ""
        Try

            If loginid.Text.Trim = "" Then
                lblmessage.Text = "Please Enter Login ID"
                Exit Sub
            End If
            If loginpassword.Text.Trim = "" Then
                lblmessage.Text = "Please Enter Password"
                Exit Sub
            End If
            If loginpassword.Text.Trim <> "0000" Then
                lblmessage.Text = "Login Failed"
                Exit Sub
            End If


            WebLib.UserID = "ADMIN"
            WebLib.UserCode = "ADMIN"
            WebLib.UserName = "ADMINISTRATOR"
            WebLib.UserEmail = ""
            WebLib.MerchantID = "POSPLUS"
            WebLib.ActionParamMMUID = ""
            WebLib.UserIsFullAdmin = True
            Weblib.Branchid = "1"
            WebLib.BranchName = "OBRIEN HQ"

            

            Response.Redirect("menusplash.aspx")
 
        Catch ex As Exception
            lblmessage.Text = ex.Message
        End Try
    End Sub

End Class

