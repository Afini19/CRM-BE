Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class menusplash_class


    Inherits basepage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PageTitle = "Performance Dashboard"
        If Page.IsPostBack = False Then


        End If


        Response.Redirect("pospluscrm/membereventcategorylistme.aspx")

    End Sub
    Protected Function doValidation() As Boolean
        Return True
    End Function




End Class

