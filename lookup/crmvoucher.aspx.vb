Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class crmvoucher_class
    Inherits basepage
    Dim theMerchantID As String = System.Configuration.ConfigurationSettings.AppSettings("themerchantid")
    Dim theFilter As String = System.Configuration.ConfigurationSettings.AppSettings("thefilter")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Call loaddata()
    End Sub
    Protected Function LoadSQLfromCloud(Optional ByVal Searchkey As String = "") As DataSet

        DBConnection = System.Configuration.ConfigurationSettings.AppSettings("ConnStrCRM")

        Dim cn As New OleDb.OleDbConnection(DBConnection)
        Dim cmd As New OleDb.OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0

        Dim ltemp As String = ""
        Dim lWhere As String = ""

        If Searchkey.Trim <> "" Then
            lWhere = " and (vo_code like '%" & Searchkey & "%' or vo_name like '%" & Searchkey & "%')"
        End If

        Try
            Dim lFilterstatement As String = " vo_merchantid='" & theMerchantID & "' and vo_Filter='" & theFilter & "' " & lWhere
            cn.Open()
            cmd.CommandText = "select * from eVoucher where " & lFilterstatement & ""
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            cn.Close()
            cmd.Dispose()
            cn.Dispose()

            Return ds
        Catch ex As Exception
            ShowPromptV2(ex.Message, "")
            Return Nothing
        End Try

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
        sb.Append("<thead><tr><th>UID</th><th>Event Code</th><th>Event Name</th></tr></thead>")
        sb.Append("<tbody>")

        Try

            ds = LoadSQLfromCloud(Searchkey)


            For Each dr In ds.Tables(0).Rows
                sb.Append("<tr><td>" & dr("vo_id") & "</td><td>" & dr("vo_code") & "</td><td>" & dr("vo_name") & "</td></tr>")

            Next


        Catch ex As Exception

        End Try

        sb.Append("</tbody></table>")
        Response.Write(sb.ToString())
        Response.End()

    End Sub
End Class

