Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class lookupsupplier_class



    Inherits basepage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call loaddata()
    End Sub
    Protected Function LoadSQLfromCloud() As DataSet
        Dim oo As New OfficeOne.WebServices.BLogic.GenericAction
        oo.ConnectionString = DBConnection
        oo.MerchantMerchantID = Weblib.MErchantID
        oo.MerchantFilter = Weblib.FilterCode

        Return oo.TakeActionRetrievalDataDS("GENCLASSV2", "supplierdatawhereclause", "", " sp_id<>-1 ", "", "")

    End Function
    Public Sub loaddata()

        Dim lInstanceID As String = Request("IID")
        Response.ClearHeaders()
        Response.ClearContent()
        Response.Clear()
        Response.ContentType = "text/html"

        Dim ds As New DataSet()
        Dim sb As New StringBuilder
        Dim dr As DataRow

        sb.Append("<table id=""tblsearchpro" & lInstanceID & """ class=""Compact hover stripe cell-border nowrap order-column"" width=""100%"">")
        sb.Append("<thead><tr><th>UID</th><th>Supplier Code</th><th>Supplier Name</th></tr></thead>")
        sb.Append("<tbody>")

        Try

            ds = LoadSQLfromCloud()


            For Each dr In ds.Tables(0).Rows
                sb.Append("<tr><td>" & dr("sp_uid") & "</td><td>" & dr("sp_code") & "</td><td>" & dr("sp_name") & "</td></tr>")

            Next


        Catch ex As Exception

        End Try

        sb.Append("</tbody></table>")
        Response.Write(sb.ToString())
        Response.End()

    End Sub
End Class

