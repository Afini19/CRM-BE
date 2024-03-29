Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class event_class


    Inherits basepage
    Dim CODEFIELD As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = ""
        DBConnection = "Provider=SQLOLEDB;Data Source=(local)\SQLEXPRESS;Initial Catalog=storefrontsuite;User ID=sa;Password="

        ActionType = "VOA"
        PageDetail = ""
        PageListing = "eventlist.aspx"
        EnableDelete = False
        PageTitle = "Event Settings"
        FieldUID = ""
        FieldMerchantID = ""
        FieldDefaultSort = ""

        Framework_Back = PageListing
        GenRightBar()
        GetSideMenu()

        If Page.IsPostBack = False Then
            uid.Value = WebLib.ActionUID
            If (WebLib.ActionType <> ActionType) Then
                Response.Redirect(PageListing)
            End If
            initTables()
            initTables2()
            Call LoadData()
        End If


    End Sub
    Protected Sub GetSideMenu()
        Framework_MenuLeftBar = True
        Framework_MenuLeftCSS = WebMenuEnquiry.LeftBarSmallPaddingCSS
        Framework_MenuLeftCode = ""
    End Sub
    Protected Sub GenRightBar()
        Dim sb As New StringBuilder
        sb.AppendLine("<span style=""display:flex;"">")
        sb.AppendLine(TableUtils.GenBarOptions("save", "Save", "SAVE", eventtype.ClientID, eventfire.ClientID))
        sb.AppendLine(TableUtils.GenBarSeparator())
        sb.AppendLine(TableUtils.GenBarOptions("delete", "Delete Record", "DELETE", eventtype.ClientID, eventfire.ClientID))
        sb.AppendLine("</span>")
        Framework_RightNavBar = sb.ToString()
    End Sub

    Protected Function doValidation() As Boolean


        Return True
    End Function
    Public Sub savedata()



    End Sub
    Protected Sub initTables()
        Dim lColumnNames As String = ""
        lColumnNames = lColumnNames & "columns: ["
        lColumnNames = lColumnNames & "{ name: 'uid' },"
        lColumnNames = lColumnNames & "{ name: 'bcode' },"
        lColumnNames = lColumnNames & "{ name: 'bname' }"
        lColumnNames = lColumnNames & "],"

        litthead.Text = "<thead><tr>" & _
                        "<th>ID</th>" & _
                        "<th>" & "Branch Code" & "</th>" & _
                        "<th>" & "Branch Name" & "</th>" & _
                       "</tr></thead>"

        littfoot.Text = ""
        litsettings.Text = TableUtils.GetStandard("caishtb", False, False, False, True, , , "", lColumnNames, False, False, False)

    End Sub
    Protected Sub initTables2()
        Dim lColumnNames As String = ""
        lColumnNames = lColumnNames & "columns: ["
        lColumnNames = lColumnNames & "{ name: 'uid' },"
        lColumnNames = lColumnNames & "{ name: 'Source' },"
        lColumnNames = lColumnNames & "{ name: 'qr' }"
        lColumnNames = lColumnNames & "],"

        litthead2.Text = "<thead><tr>" & _
                        "<th>ID</th>" & _
                        "<th>" & "Source Description" & "</th>" & _
                        "<th>" & "QR URL" & "</th>" & _
                       "</tr></thead>"

        littfoot2.Text = ""
        litsettings2.Text = TableUtils.GetStandard("caishtb2", False, False, False, True, , , "", lColumnNames, False, False, False)

    End Sub
    Protected Function LoadSQLfromCloud() As DataSet
        Dim cn As New OleDb.OleDbConnection(DBConnection)
        Dim cmd As New OleDb.OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim ltemp As String = ""


        Try
            Dim lFilterstatement As String = " le_merchantid='Default' and le_Filter='Filter' and le_uid='" & uid.value & "'"
            cn.Open()
            cmd.CommandText = "select * from loyaltyevents where " & lFilterstatement & ""
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


    Public Sub deleterec()
        Dim lError As String = ""



    End Sub
    Protected Sub LoadData()


        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim templi As ListItem
        Try

            If (uid.Value & "").Trim = "" Then
                Exit Sub
            End If
            ds = LoadSQLfromCloud()
            If ds Is Nothing Then
                ShowAlert("Ooops... We are encoutering heavy access. Please try again")
                Exit Sub
            End If

            For Each dr In ds.Tables(0).Rows
                counter = counter + 1
                le_code.Text = dr("le_code") & ""
                le_name.Text = dr("le_name") & ""

                le_fromtime.Text = dr("le_fromtime") & ""
                le_totime.Text = dr("le_totime") & ""
                le_enabletime.Checked = WebUtils.BitToBoolean(dr("le_enabletime") & "")
                Exit For
            Next
        Catch ex As Exception
            ShowAlert("Ooops... We are encoutering heavy access. Please try again")
            Exit Sub
        End Try

    End Sub
    Public Sub eventfiresub(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If eventtype.Value = "SAVE" Then
            Call savedata()
        End If

        If eventtype.Value = "DELETE" Then
            Call deleterec()
        End If

    End Sub
End Class

