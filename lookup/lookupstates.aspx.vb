Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class lookupstates_class
    Inherits basepage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call loaddata()
    End Sub
    Protected Function LoadSQLfromCloud(Optional ByVal Searchkey As String = "") As DataSet
        Dim oo As New OfficeOne.WebServices.BLogic.GenericAction
        oo.ConnectionString = DBConnection
        oo.MerchantMerchantID = WebLib.MerchantID
        oo.MerchantFilter = WebLib.FilterCode


        Dim lWhere As String = ""

        If Searchkey.Trim <> "" Then
            lWhere = " and (co_codevalue like '%" & Searchkey & "%' or co_description like '%" & Searchkey & "%')"
        End If


        Dim rtnobject As String
        rtnobject = oo.TakeActionRetrievalData("GENCLASS", "getcodemasterlist", "", " co_fieldname='" & "state" & "' " & lWhere, "", "")

        If rtnobject = "" Then
            Return Nothing
        Else

            Dim ooo As New OfficeOne.Gen.Library.JSON
            Return ooo.ToDS(rtnobject)
            ooo = Nothing
        End If




    End Function
    Public Sub loaddata()

        Dim lInstanceID As String = Request("IID") & ""
        Dim Searchkey As String = Request("sk") & ""


        Response.ClearHeaders()
        Response.ClearContent()
        Response.Clear()
        Response.ContentType = "text/html"

        Dim ds As New DataSet()
        Dim sb As New StringBuilder
        Dim dr As DataRow

        sb.Append("<table id=""tblsearchpro" & lInstanceID & """ class=""Compact hover stripe cell-border nowrap order-column"" width=""100%"">")
        sb.Append("<thead><tr><th>UID</th><th>State Code</th><th>State Name</th></tr></thead>")
        sb.Append("<tbody>")

        Try

            ds = LoadSQLfromCloud(Searchkey)


            For Each dr In ds.Tables(0).Rows
                sb.Append("<tr><td>" & dr("co_uid") & "</td><td>" & dr("co_codevalue") & "</td><td>" & dr("co_description") & "</td></tr>")

            Next


        Catch ex As Exception

        End Try

        sb.Append("</tbody></table>")
        Response.Write(sb.ToString())
        Response.End()

    End Sub
End Class

