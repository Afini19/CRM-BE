Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class product_class


    Inherits basepage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = ""
        ActionType = "PRO"
        PageDetail = ""
        PageListing = "productlist.aspx"
        EnableDelete = False
        PageTitle = "Product Maintenance"
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


        Return True
    End Function
    Public Sub savedata()

        If doValidation() = False Then
            Exit Sub
        End If


        Dim theJSON As String



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

