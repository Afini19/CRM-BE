Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class productpluadminlist_class

    Inherits basepagelist
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = ""
        PageTitle = "Product PLU/UPC Admin"
        PageListing = "menudata.aspx"
        ActionType = "PPUA"
        FieldUID = ""
        FieldMerchantID = ""
        FieldDefaultSort = ""
        PageDetail = ""

        PageListsize = 1000

        Framework_Back = PageListing
        Framework_SearchGrid = True
        Framework_DBSearch = True

        GenLeftBar()
        GenRightBar()

        If Page.IsPostBack = False Then
            WebLib.ActionUID = ""
            Call initTables()
        End If
    End Sub
    Protected Sub GenLeftBar()
        Dim sb As New StringBuilder
        sb.AppendLine("<span style=""display:flex;"">")
        sb.AppendLine(TableUtils.GenBarOptions("edit", "Edit Selected", "", eventtype.ClientID, eventfirenorm.ClientID, "", "performdrill()"))
        sb.AppendLine(TableUtils.GenBarSeparator())
        sb.AppendLine("</span>")

        Framework_LeftNavBar = sb.ToString()
    End Sub
    Protected Sub GenRightBar()
        Dim sb As New StringBuilder
        sb.AppendLine("<span style=""display:flex;"">")
        sb.AppendLine(TableUtils.GenBarOptions("search", "Advance Search", "", eventtype.ClientID, eventfirenorm.ClientID, "", "triggersearch()", "2"))
        sb.AppendLine("</span>")

        Framework_RightNavBar = sb.ToString()
    End Sub
    Protected Function LoadSQLfromCloud() As DataSet

        Dim strWhere As String = ""
        If FilterStatement.Trim <> "" Then
            strWhere = FilterStatement
        End If
        Dim ooCM As New OfficeOne.WebServices.BLogic.ProductPLU
        ooCM.ConnectionString = DBConnection
        ooCM.MerchantMerchantID = WebLib.MerchantID
        ooCM.MerchantFilter = WebLib.FilterCode


        Return ooCM.LoadPLUData(strWhere, "order by pt_desc1,plu_sn asc")

    End Function
    Protected Sub TakeAction()
        If eventtype.Value = "NAVSEARCH" Then
            Call SearchtheData()
        End If
    End Sub
    Protected Sub SearchtheData()
        Dim lFilterStatement As String = ""
        Dim theObject As Object = Nothing

        theObject = Page.Master.FindControl("ContentArea").FindControl("sbstockcode")
        If theObject IsNot Nothing Then
            If (theObject.Value & "").Trim <> "" Then
                If (lFilterStatement & "").Trim <> "" Then
                    lFilterStatement = lFilterStatement & " and "
                End If
                lFilterStatement = lFilterStatement & WebSearchProductPLU.ProductCode(theObject.Value)
            End If
        End If

        theObject = Page.Master.FindControl("ContentArea").FindControl("sbstockname")
        If theObject IsNot Nothing Then
            If (theObject.Value & "").Trim <> "" Then
                If (lFilterStatement & "").Trim <> "" Then
                    lFilterStatement = lFilterStatement & " and "
                End If
                lFilterStatement = lFilterStatement & WebSearchProductPLU.ProductName(theObject.Value)
            End If
        End If

        theObject = Page.Master.FindControl("ContentArea").FindControl("sbplusn")
        If theObject IsNot Nothing Then
            If (theObject.Value & "").Trim <> "" Then
                If (lFilterStatement & "").Trim <> "" Then
                    lFilterStatement = lFilterStatement & " and "
                End If
                lFilterStatement = lFilterStatement & WebSearchProductPLU.PLUSN(theObject.Value)
            End If
        End If


        theObject = Page.Master.FindControl("ContentArea").FindControl("sbpluname")
        If theObject IsNot Nothing Then
            If (theObject.Value & "").Trim <> "" Then
                If (lFilterStatement & "").Trim <> "" Then
                    lFilterStatement = lFilterStatement & " and "
                End If
                lFilterStatement = lFilterStatement & WebSearchProductPLU.ProductName(theObject.Value)
            End If
        End If


        If lFilterStatement.Trim <> "" Then
            FilterStatement = lFilterStatement
            Call loaddata(DBSQL)
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
            sb.Append("<td>" & drv.Row("plu_uid").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("pt_part").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("pt_desc1").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("pt_um").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("plu_sn").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("plu_name").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("plu_uom").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("plu_att1").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("plu_att2").ToString.Trim & "</td>")
            sb.Append("<td>" & drv.Row("plu_att3").ToString.Trim & "</td>")
            sb.Append("</tr>")
            objdata.Text = sb.ToString()
        End If
    End Sub
    Protected Sub initTables()
        Dim lColumnNames As String = ""

        lColumnNames = lColumnNames & "columns: ["
        lColumnNames = lColumnNames & "{ name: 'uid' },"
        lColumnNames = lColumnNames & "{ name: 'stockcode' },"
        lColumnNames = lColumnNames & "{ name: 'stockname' },"
        lColumnNames = lColumnNames & "{ name: 'uom' },"
        lColumnNames = lColumnNames & "{ name: 'plusn' },"
        lColumnNames = lColumnNames & "{ name: 'pluname' },"
        lColumnNames = lColumnNames & "{ name: 'pluuom' },"
        lColumnNames = lColumnNames & "{ name: 'pluatt1' },"
        lColumnNames = lColumnNames & "{ name: 'pluatt2' },"
        lColumnNames = lColumnNames & "{ name: 'pluatt3' }"
        lColumnNames = lColumnNames & "],"

        litthead.Text = "<thead><tr>" & _
                        "<th>ID</th>" & _
                        "<th>" & OfficeOne.Gen.Library.Messages.StockCode & "</th>" & _
                        "<th>" & OfficeOne.Gen.Library.Messages.StockName & "</th>" & _
                        "<th>" & OfficeOne.Gen.Library.Messages.UOM & "</th>" & _
                       "<th>" & "PLU/UPC Code" & "</th>" & _
                       "<th>" & "Variant Name" & "</th>" & _
                       "<th>" & "Variant UOM" & "</th>" & _
                       "<th>" & "Attribute 1" & "</th>" & _
                       "<th>" & "Attribute 2" & "</th>" & _
                       "<th>" & "Attribute 3" & "</th>" & _
                       "</tr></thead>"
        littfoot.Text = ""
        litsettings.Text = TableUtils.GetStandard("caishtb", False, False, False, , , , , lColumnNames)

    End Sub
    Public Sub loaddata(ByVal SQLQuery As String)
        Dim ds As New DataSet()

        Try
            ds = LoadSQLfromCloud()
            If ds Is Nothing Then


                Exit Sub
            End If



            Dim dt As DataTable = ds.Tables(0)
            Dim dv As New DataView(dt)

            Dim pgitems As New PagedDataSource()
            pgitems.DataSource = dv
            pgitems.AllowPaging = False

            rep.DataSource = pgitems
            rep.DataBind()

        Catch ex As Exception
            ShowAlert("Error : Loading Data")
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

