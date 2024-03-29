Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class selectbranch_class

    Inherits basepagelist
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = ""
        PageTitle = "Please Select Branch"
        PageListing = ""
        ActionType = "PSB"
        FieldUID = ""
        FieldMerchantID = ""
        FieldDefaultSort = ""
        PageDetail = ""

        PageListsize = 1000

        Framework_Back = PageListing
        Framework_SearchGrid = True

        GenRightBar()

        If Page.IsPostBack = False Then
            WebLib.ActionUID = ""
            popupparam1.value = Request("p1") & ""
            Call initTables()
            Call loaddata("")
        End If
    End Sub
    Protected Sub GenRightBar()


    End Sub
    Protected Function LoadDatafromCloud() As DataSet

        Dim ds As DataSet
        Dim oo As New OfficeOne.WebServices.BLogic.Branch
        oo.ConnectionString = DBConnection
        oo.MerchantMerchantID = WebLib.MerchantID
        oo.MerchantFilter = WebLib.FilterCode
        ds = oo.GetBranchDataV2withRights(WebUtils.GroupKey, WebLib.UserCode, " order by me_merchantid,br_code,br_name ", True)

        Return ds

    End Function
    Protected Sub TakeAction()


        LoginNewBranch()


    End Sub
    Private Sub LoginNewBranch()

        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow

        If (table1sel0.Value & "").Trim = "" Then
            Exit Sub
        End If

        Try

            Dim oo As New OfficeOne.WebServices.BLogic.Branch
            oo.ConnectionString = DBConnection
            oo.MerchantMerchantID = WebLib.MerchantID
            oo.MerchantFilter = WebLib.FilterCode

            ds = oo.GetBranchDataV2("br_uid='" & table1sel0.Value & "'", "", True, True)
            If ds IsNot Nothing Then
                For Each dr In ds.Tables(0).Rows
                    counter = counter + 1
                    WebLib.MerchantID = dr("me_merchantid").ToString.ToUpper
                    WebLib.ActionParamMMUID = ""
                    WebLib.BranchID = dr("br_id") & ""
                    WebLib.BranchName = dr("br_name") & ""
                    WebLib.MerchantName = dr("me_name") & ""
                    Exit For
                Next
            End If

        Catch ex As Exception
            Response.Write("ERROR " & ex.Message)
        End Try


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
            sb.Append("<td>" & drv.Row("br_uid").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("me_merchantid").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("br_code").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("br_name").ToString.Trim & "</td>")
            sb.Append("</tr>")
            objdata.Text = sb.ToString()


        End If
    End Sub
    Protected Sub initTables()
        Dim lColumnNames As String = ""

        lColumnNames = lColumnNames & "columns: ["
        lColumnNames = lColumnNames & "{ name: 'uid' },"
        lColumnNames = lColumnNames & "{ name: 'company' },"
        lColumnNames = lColumnNames & "{ name: 'branchcode' },"
        lColumnNames = lColumnNames & "{ name: 'branchname' }"
        lColumnNames = lColumnNames & "],"


        litthead.Text = "<thead><tr>" & _
                        "<th>ID</th>" & _
                        "<th>" & OfficeOne.Gen.Library.Messages.Company & "</th>" & _
                        "<th>" & OfficeOne.Gen.Library.Messages.Branch & " " & OfficeOne.Gen.Library.Messages.Code & "</th>" & _
                        "<th>" & OfficeOne.Gen.Library.Messages.Branch & " " & OfficeOne.Gen.Library.Messages.word_name & "</th>" & _
                       "</tr></thead>"
        littfoot.Text = ""
        litsettings.Text = TableUtils.GetStandard("caishtb", False, False, False, , , , , lColumnNames)

    End Sub
    Public Sub loaddata(ByVal SQLQuery As String)
        Dim cn As New OleDbConnection(DBConnection)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()

        Try

            ds = LoadDatafromCloud()


            Dim dt As DataTable = ds.Tables(0)
            Dim dv As New DataView(dt)

            Dim pgitems As New PagedDataSource()
            pgitems.DataSource = dv
            pgitems.AllowPaging = False
            rep.DataSource = pgitems
            rep.DataBind()
            cn.Dispose()
            cmd.Dispose()

        Catch ex As Exception
            ShowAlert("Error : " & ex.Message)
        End Try

    End Sub
    Public Sub eventfiresub(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call TakeAction()
    End Sub

    Public Sub adddata(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WebLib.ActionUID = ""
        Response.Redirect(PageDetail)
    End Sub

End Class

