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
Partial Public Class popupprintgrn_class

    Inherits basepagelist
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = ""
        PageTitle = "Print GRN"
        PageListing = ""
        ActionType = "PGCL"
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
            puid.Value = Request("p1") & ""
            partuid.Value = Request("p2") & ""
            uomuid.Value = Request("p3") & ""
            '  loaddata("")
        End If

    End Sub
    Protected Sub GenRightBar()

    End Sub
    Protected Function LoadSQLfromCloud() As DataSet


        Dim strWhere As String = ""
        Dim theBranchID As String = WebLib.BranchID
        strWhere = FilterStatement

        Dim oo As New OfficeOne.WebServices.BLogic.GenericAction
        oo.ConnectionString = DBConnection
        oo.MerchantMerchantID = WebLib.MerchantID
        oo.MerchantFilter = WebLib.FilterCode


        Dim strresult As String = oo.TakeActionRetrieval("PLUGINS_GRNDAILY")
        Dim strAddfield As String = ""
        Dim strJoin As String = ""
        Dim DBPrefix As String = ""
        Dim strOrderby As String = " order by grn_date,grn_docno,grni_id"
        Dim strDBPrefix As String = ""

        strWhere = " and grn_uid='" & Request("p1") & "'"


        strresult = OfficeOne.Gen.Library.Utility.WhiteListSQL(strresult, "", strAddfield, strJoin, strOrderby, strWhere, strOrderby)

   

        Dim cn As New OleDbConnection(DBConnection)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()

        Try


            cn.Open()
            cmd.CommandText = strresult
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            Return ds
        Catch ex As Exception
            ShowAlert("Error Loading Data")
            Return Nothing
        End Try

    End Function

    Protected Sub StiWebViewer1_GetReport(ByVal sender As Object, ByVal e As StiReportDataEventArgs)
 

        Dim ldrivername As String = ""
        Dim lvehicleno As String = ""
        Dim ldriverref As String = ""
        Dim ldocno As String = ""
        Dim ldocdate As DateTime
        Dim lfromname As String = ""
        Dim lfromcode As String = ""
        Dim dr As DataRow


        Dim ds As New DataSet
        ds = New DataSet("sp_GetTransactionData")
        ds.Namespace = "sp_GetTransactionData"
        Dim dt As New DataTable("sp_GetTransactionData")
        Dim colitem As DataColumn
        colitem = New DataColumn("BusinessUnitName")
        dt.Columns.Add(colitem)
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
        colitem = New DataColumn("DocumentNumber")
        dt.Columns.Add(colitem)
        colitem = New DataColumn("DocumentDate")
        dt.Columns.Add(colitem)
        colitem = New DataColumn("DriverName")
        dt.Columns.Add(colitem)
        colitem = New DataColumn("VehicleNo")
        dt.Columns.Add(colitem)
        colitem = New DataColumn("DriverIC")
        dt.Columns.Add(colitem)
        colitem = New DataColumn("POLineNumber")
        dt.Columns.Add(colitem)
        colitem = New DataColumn("ItemCode")
        dt.Columns.Add(colitem)
        colitem = New DataColumn("ItemName")
        dt.Columns.Add(colitem)
        colitem = New DataColumn("ItemQuantity")
        dt.Columns.Add(colitem)
        colitem = New DataColumn("ItemUOM")
        dt.Columns.Add(colitem)
        colitem = New DataColumn("ItemPackingSize")
        dt.Columns.Add(colitem)
        ds.Tables.Add(dt)

        Dim dsData As DataSet = Nothing
        Dim counter As Integer = 0
        Try
            dsData = LoadSQLfromCloud()

            If dsData Is Nothing Then
                ShowAlert("Unable to Load Data")
                Exit Sub
            End If


            For Each dr In dsData.Tables(0).Rows
                counter = counter + 1
                Dim newrow As DataRow
                newrow = dt.NewRow
                newrow("POLineNumber") = counter
                newrow("BusinessUnitName") = WebLib.MerchantName
                newrow("PartnerName") = dr("grn_suppname") & ""
                newrow("PartnerCode") = dr("grn_suppcode") & ""
                newrow("PartnerAddress1") = ""
                newrow("PartnerAddress2") = ""
                newrow("PartnerAddress3") = ""
                newrow("DocumentNumber") = dr("grn_docno") & ""
                newrow("DocumentDate") = dr("grn_date")
                newrow("ItemCode") = dr("grni_stockcode") & ""
                newrow("ItemName") = dr("grni_stockname") & ""
                newrow("ItemQuantity") = dr("grni_transqty") & ""
                newrow("ItemUOM") = dr("grni_transum") & ""

                If (dr("grni_uomid") & "").ToString.ToLower = (dr("grni_transum") & "").ToString.ToLower Then
                    newrow("ItemPackingSize") = ""
                Else
                    newrow("ItemPackingSize") = "" 'dr("umdesc") & ""
                End If
                dt.Rows.Add(newrow)
                newrow = Nothing
            Next
        Catch ex As Exception
            Response.Write("ERROR" & WebUtils.GetErrorMessage(ex.message))

            Exit Sub

        End Try

        ds.AcceptChanges()

        Dim report = StiReport.CreateNewReport()
        Dim path = Server.MapPath("Reports/grn.mrt")
        report.Load(path)

        report.dictionary.databases.clear()
        report.regData(ds)
        report.dictionary.synchronize()

        e.Report = report

    End Sub

    Public Sub loaddata(ByVal SQLQuery As String)

        Dim dsData As DataSet = Nothing
        Dim counter As Integer = 0
        '  Try
        dsData = LoadSQLfromCloud()

        If dsData Is Nothing Then
            ShowAlert("Unable to Load Data")
            Exit Sub
        End If

        Response.Write("sdfd" & dsData.Tables(0).Rows.Count)
        Response.End()
    End Sub
    Public Sub savedata()


    End Sub
    Public Sub eventfiresub(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub





End Class

