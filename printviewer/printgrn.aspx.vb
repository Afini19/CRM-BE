Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Stimulsoft.Report
Imports Stimulsoft.Report.Dictionary
Imports Stimulsoft.Report.Web
Imports Stimulsoft.Base


Partial Public Class printgrn_class


    Inherits basepage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PageTitle = "Enquiry"
        If Page.IsPostBack = False Then


        End If


    End Sub
    Protected Function doValidation() As Boolean
        Return True
    End Function


    Protected Sub StiWebViewer1_GetReport(ByVal sender As Object, ByVal e As StiReportDataEventArgs)
        Dim report = StiReport.CreateNewReport()
        Dim path = Server.MapPath("Reports/grn.mrt")
        report.Load(path)


        '        Dim data As DataSet = StiJsonToDataSetConverterV2.GetDataSetFromFile(Server.MapPath("~/printviewer/reports/grn.json"))

        Dim ds As New DataSet("sp_GetTransactionData")
        ds.Namespace = "sp_GetTransactionData"
        Dim dt As New DataTable("sp_GetTransactionData")
        Dim colitem As DataColumn
        colitem = New DataColumn("PartnerName")
        dt.Columns.Add(colitem)
        colitem = New DataColumn("PartnerCode")
        dt.Columns.Add(colitem)
        colitem = New DataColumn("PartnerAddress1")
        dt.Columns.Add(colitem)
        colitem = New DataColumn("PartnerAddress2")
        dt.Columns.Add(colitem)
        colitem = New DataColumn("PartnerAddress3")
        dt.Columns.Add(colitem)
        colitem = New DataColumn("ItemCode")
        dt.Columns.Add(colitem)
        colitem = New DataColumn("ItemName")
        dt.Columns.Add(colitem)
        colitem = New DataColumn("ItemQuantity")
        dt.Columns.Add(colitem)
        colitem = New DataColumn("ItemUOM")
        dt.Columns.Add(colitem)

        ds.Tables.Add(dt)

        Dim newrow As DataRow
        newrow = dt.NewRow
        newrow("PartnerName") = "TEST SUPPLIER 1"
        newrow("PartnerCode") = "JWD"
        newrow("PartnerAddress1") = "Address1"
        newrow("PartnerAddress2") = "Address2"
        newrow("PartnerAddress3") = "Address3"
        newrow("ItemCode") = "L-AWS-GN00100"
        newrow("ItemName") = "GLENFIDDICH 12YO SINGLE MALT SCOTCH WHISKY TEST	"
        newrow("ItemQuantity") = "10"
        newrow("ItemUOM") = "BTL"
        dt.Rows.Add(newrow)
        newrow = Nothing

        newrow = dt.NewRow
        newrow("PartnerName") = "TEST SUPPLIER 1"
        newrow("PartnerCode") = "JWD"
        newrow("PartnerAddress1") = "Address1"
        newrow("PartnerAddress2") = "Address2"
        newrow("PartnerAddress3") = "Address3"
        newrow("ItemCode") = "L-BFM-AW00100GP"
        newrow("ItemName") = "AMERICAN WHISKEY FAMILY OF BRANDS (50MLX4)	"
        newrow("ItemQuantity") = "10"
        newrow("ItemUOM") = "PACK"
        dt.Rows.Add(newrow)
        newrow = Nothing

        ds.AcceptChanges()
        report.dictionary.databases.clear()
        report.regData(ds)
        report.dictionary.synchronize()

        e.Report = report

        'e.Report.RegData(data);

        '        Dim dtset As New Stimulsoft.System.Data.DataSet("sp_GetTransactionData")

        '       Dim dtset = StiJsonToDataSetConverter.GetDataSetFromFile("grn.json")
        '

        '      dtset.readJsonFile("grn.json")
        '     report.dictionary.databases.clear()
        '    report.regData("sp_GetTransactionData", "sp_GetTransactionData", dtset)
        '   report.dictionary.synchronize()

        '        e.Report = report
    End Sub


End Class

