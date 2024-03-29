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
Partial Public Class popupprintcountlist_class

    Inherits basepagelist
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = ""
        PageTitle = "Print GRN Count List"
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
            loaddata("")
        End If

    End Sub
    Protected Sub GenRightBar()

    End Sub
     Protected Function LoadSQLfromCloud() As DataSet

   
        Dim oo As New OfficeOne.WebServices.BLogic.GenericAction
        oo.ConnectionString = DBConnection
        oo.MerchantMerchantID = WebLib.MerchantID
        oo.MerchantFilter = WebLib.FilterCode

        Dim rtndata As String
        rtndata = oo.TakeActionRetrievalData("GENCLASS", "mobileitemssummdatascandatawhereclausepl", "", "moi.moi_puid='" + Request("p1") + "'", "order by moi_id desc", "")

        If rtndata = "" Then
            Return Nothing
        Else
            Dim ooo As New OfficeOne.Gen.Library.JSON
            Return ooo.ToDS(rtndata)
            ooo = Nothing
        End If
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

        Dim oo2 As New OfficeOne.WebServices.BLogic.DeliveryData
        oo2.ConnectionString = DBConnection
        oo2.MerchantMerchantID = WebLib.MerchantID
        oo2.MerchantFilter = WebLib.FilterCode
        Dim ds As New DataSet
        ds = oo2.LoadIncomingData(" dda_uid='" & Request("p1") & "'", "")
        If Not ds Is Nothing Then
            For Each dr In ds.Tables(0).Rows
                ldocdate = System.DateTime.Now
                lfromname = dr("dda_name") & ""
                lfromcode = dr("dda_code") & ""
                ldocno = (dr("dda_doctype") & "").trim & " " & dr("dda_docno")
                ldrivername = dr("dda_drivername") & ""
                lvehicleno = dr("dda_vehicleno") & ""
                ldriverref = dr("dda_driverref") & ""
                Exit For
            Next
        End If
        ds = Nothing
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

        Dim dsData As New DataSet()
        Dim counter As Integer = 0
        Try
            dsData = LoadSQLfromCloud()


            If dsData Is Nothing Then
                ShowPromptV2("Unable to Load Data")
                Exit Sub
            End If

            For Each dr In dsData.Tables(0).Rows
                counter = counter + 1
                Dim newrow As DataRow
                newrow = dt.NewRow
                newrow("POLineNumber") = counter
                newrow("BusinessUnitName") = WebLib.MerchantName
                newrow("PartnerName") = lfromname
                newrow("PartnerCode") = lfromcode
                newrow("PartnerAddress1") = ""
                newrow("PartnerAddress2") = ""
                newrow("PartnerAddress3") = ""

                newrow("DocumentNumber") = ldocno
                newrow("DocumentDate") = ldocdate
                newrow("DriverName") = ldrivername
                newrow("VehicleNo") = lvehicleno
                newrow("DriverIC") = ldriverref

                newrow("ItemCode") = dr("pt_part") & ""
                newrow("ItemName") = dr("pt_desc1") & ""
                newrow("ItemQuantity") = dr("moi_qty") & ""
                newrow("ItemUOM") = dr("moi_uomid") & ""

                If (dr("moi_uomid") & "").ToString.ToLower = (dr("moi_inuom") & "").ToString.ToLower Then
                    newrow("ItemPackingSize") = ""
                Else
                    Dim ltotal As String = CDbl(dr("moi_inrate")) * CDbl(dr("moi_qty"))
                    newrow("ItemPackingSize") = ltotal & " " & dr("moi_inuom") & ""

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
        Dim path = Server.MapPath("Reports/grncountlist.mrt")
        report.Load(path)

        report.dictionary.databases.clear()
        report.regData(ds)
        report.dictionary.synchronize()

        e.Report = report

    End Sub

    Public Sub loaddata(ByVal SQLQuery As String)
      

    End Sub
    Public Sub savedata()


    End Sub
    Public Sub eventfiresub(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub





End Class

