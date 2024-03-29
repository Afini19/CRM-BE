Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class site_class


    Inherits basepage
    Dim CODEFIELD As String = "site"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = ""
        ActionType = "SITE"
        PageDetail = ""
        PageListing = "sitelist.aspx"
        EnableDelete = False
        PageTitle = "Site Maintenance"
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

        If (co_codevalue.Text & "").Trim = "" Then
            ShowAlert("Code is Mandatory")
            Return False
        End If
        If (co_description.Text & "").Trim = "" Then
            ShowAlert("Description is Mandatory")
            Return False
        End If
        Return True
    End Function
    Public Sub savedata()

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
        newrow("co_description") = co_description.Text
        newrow("co_codevalue") = co_codevalue.Text
        newrow("co_fieldname") = CODEFIELD
        newrow("co_site") = ""
        newrow("co_para1") = ""
        newrow("co_para2") = ""

        If (uid.Value & "").Trim <> "" Then
            newrow("mode") = "E"
        Else
            newrow("mode") = ""
        End If

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

    Protected Function LoadSQLfromCloud() As DataSet
        Dim oo As New OfficeOne.WebServices.BLogic.GenericAction
        oo.ConnectionString = DBConnection
        oo.MerchantMerchantID = WebLib.MerchantID
        oo.MerchantFilter = WebLib.FilterCode




        If (uid.Value & "").Trim = "" Then
            Return Nothing
        End If

        Dim rtnobject As String
        rtnobject = oo.TakeActionRetrievalData("GENCLASS", "getcodemasterlist", "", " co_fieldname='" & CODEFIELD & "' and co_uid='" & uid.Value & "'", "", "")

        If rtnobject = "" Then
            Return Nothing
        Else

            Dim ooo As New OfficeOne.Gen.Library.JSON
            Return ooo.ToDS(rtnobject)
            ooo = Nothing
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
        newrow("co_fieldname") = CODEFIELD
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
                co_codevalue.Text = dr("co_codevalue") & ""
                co_description.Text = dr("co_description") & ""
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

