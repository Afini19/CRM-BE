Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class menuproductgroup_class


    Inherits basepage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PageTitle = "Product Categorisation"
        If Page.IsPostBack = False Then


        End If


    End Sub
    Protected Function doValidation() As Boolean
        Return True
    End Function




End Class

