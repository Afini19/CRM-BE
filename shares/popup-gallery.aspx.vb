Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class popupgallery_class

    Inherits basepagelist
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = ""
        PageTitle = "Image Gallery"
        PageListing = ""
        ActionType = "IGC"
        FieldUID = ""
        FieldMerchantID = ""
        FieldDefaultSort = ""
        PageDetail = ""

        PageListsize = 1000

        Framework_Back = ""
        Framework_SearchGrid = False

        GenRightBar()

        If Page.IsPostBack = False Then
            popupparam1.Value = Request("p1") & ""
            uid.Value = popupparam1.Value
            Call initTables()
            Call loaddata()
        End If



    End Sub
    Protected Sub GenRightBar()


    End Sub
    Protected Function doValidation() As Boolean



        Return True
    End Function
    Public Sub savedata()




    End Sub

    Protected Function LoadSQLfromCloud() As DataSet

    End Function
    Protected Sub initTables()

    End Sub
    Protected Sub TakeAction()

    End Sub
    Public Sub loaddata()

        Dim ooo As New WebUtils
        Dim ds As DataSet
        ds = ooo.GetImageList(DBConnection, popupparam1.value, popupparam2.value, popupparam3.value, popupparam4.value)
        If ds IsNot Nothing Then
            For Each dr As DataRow In ds.Tables(0).Rows


            Next

        End If

    End Sub


    Public Sub savedata(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If doValidation() = True Then
            Call savedata()
        End If
    End Sub

    Public Sub eventfiresub(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call TakeAction()
    End Sub

    Public Sub adddata(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WebLib.ActionUID = ""
        Response.Redirect(PageDetail)
    End Sub
End Class

