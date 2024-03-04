Imports Stimulsoft.Report
Imports Stimulsoft.Report.Dictionary
Imports Stimulsoft.Report.Web

Partial Public Class _Default
	Inherits Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

	End Sub

	Protected Sub StiWebViewer1_GetReport(ByVal sender As Object, ByVal e As StiReportDataEventArgs)
		Dim report = StiReport.CreateNewReport()
		Dim path = Server.MapPath("Reports/grn.mrt")
		report.Load(path)

		e.Report = report
	End Sub
End Class