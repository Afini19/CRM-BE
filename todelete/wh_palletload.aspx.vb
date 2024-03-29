Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class wh_palletload_class

    Inherits basepage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = ""
        ActionType = "PLO"
        PageDetail = ""
        PageListing = ""
        EnableDelete = False
        PageTitle = "Pallet Loading"
        FieldUID = ""
        FieldMerchantID = ""
        FieldDefaultSort = ""

        If Page.IsPostBack = False Then
            uid.Value = Weblib.ActionUID
            If weblib.ActionType <> ActionType Then
                gotoTheback()
            End If

            If (uid.Value & "").Trim = "" Then
                gotoTheback()
            End If
            Call LoadData()
        End If

        littitle.Text = PageTitle

    End Sub
    Protected Function doValidation() As Boolean


        Return True
    End Function
    Public Sub savedata(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If doValidation() = False Then
            Exit Sub
        End If



    End Sub
    Public Sub backpage(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call gotoTheback()

    End Sub
    Public Sub gotoTheback()
        Response.Redirect("menudc.aspx")
    End Sub
    Protected Function LoadSQLfromCloud() As DataSet
        Dim oo As New OfficeOne.WebServices.BLogic.GenericAction
        oo.ConnectionString = DBConnection
        oo.MerchantMerchantID = Weblib.MErchantID
        oo.MerchantFilter = Weblib.FilterCode

        Return oo.TakeActionRetrievalDataDS("GENCLASSV2", "GetPalletDetailByCriteria", "", " zldp_branchid=" & weblib.branchid & " and zldp_uid='" & uid.Value & "'", "", "")


    End Function
    Protected Sub LoadData()

        Dim ds As New DataSet
        Dim dr As DataRow
        ds = LoadSQLfromCloud()
        If ds IsNot Nothing Then
            For Each dr In ds.Tables(0).Rows
                litpalletno.Text = dr("zldp_pn") & ""
                litlocation.Text = dr("zldp_loc") & ""
                Exit For
            Next
        End If

    End Sub
    Protected Sub rep_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs)

    End Sub
    Protected Sub rep_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rep.ItemDataBound

        Dim drv As DataRowView
        drv = e.Item.DataItem
        Dim sb As System.Text.StringBuilder
        Dim objdata As Literal = e.Item.FindControl("litTableRows")
        If Not objdata Is Nothing Then
            Dim ldata As String = ""

            sb = New System.Text.StringBuilder
            sb.Append("<tr>")
            sb.Append("<td>" & drv.Row("zldp_uid").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("zldp_pn").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("zldp_loc").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("itemcount").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("zldp_createby").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("zldp_createdt").ToString.Trim & "</td>")
            sb.Append("</tr>")
            objdata.Text = sb.ToString()

        End If
    End Sub
    Public Sub backback(ByVal sender As System.Object, ByVal e As System.EventArgs)
        response.redirect("menudc.aspx")
    End Sub
    Public Sub eventfiresub(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub
End Class

