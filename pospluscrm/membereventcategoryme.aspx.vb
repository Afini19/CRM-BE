Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class merbereventcategoryme_class


    Inherits basepage
    Dim CODEFIELD As String = ""
    Dim theMerchantID As String = System.Configuration.ConfigurationSettings.AppSettings("themerchantid")
    Dim theFilter As String = System.Configuration.ConfigurationSettings.AppSettings("thefilter")
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = ""
        DBConnection = System.Configuration.ConfigurationSettings.AppSettings("ConnStrCRM")

        ActionType = "PPMCE"
        PageDetail = ""
        PageListing = "membereventcategorylistme.aspx"
        EnableDelete = False
        PageTitle = "Event Based - Member Category Settings"
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


        If (doValidation() = False) Then
            Exit Sub
        End If
        Dim lsql As String = ""


        If (uid.value & "").trim = "" Then


            lsql = "Insert Into LoyaltyEventDiscCat (lec_discount,lec_fromdate,lec_todate,lec_transtype" & _
        ",lec_mcode,lec_pointrate,lec_eventcode,lec_pointbase,lec_active,lec_merchantid,lec_filter" & _
        ") values (" & _
         "" & WebUtils.NumericOrNull(lec_discount.Text) & "" & _
         ",'" & WebUtils.FormatDateYYYYMMDD(CDate(lec_fromdate.text)) & "'" & _
         ",'" & WebUtils.FormatDateYYYYMMDD(CDate(lec_todate.text)) & "'" & _
        ",'" & lec_transtype.Text & "'" & _
        ",'" & lec_mcode.Text & "'" & _
        ",'" & lec_pointrate.Text & "'" & _
        ",'" & lec_eventcode.Text & "'" & _
        ",'" & lec_pointbase.Text & "'" & _
        "," & WebUtils.BooleanToBit(chkactive.checked) & "" & _
        ",'" & theMerchantID & "','" & theFilter & "')"

        Else
            lsql = "Update LoyaltyEventDiscCat set " & _
                    "lec_discount=" & WebUtils.NumericOrNull(lec_discount.Text) & "" & _
                    ",lec_fromdate='" & WebUtils.FormatDateYYYYMMDD(CDate(lec_fromdate.text)) & "'" & _
                    ",lec_todate='" & WebUtils.FormatDateYYYYMMDD(CDate(lec_todate.text)) & "'" & _
                    ",lec_transtype='" & lec_transtype.Text & "'" & _
                    ",lec_mcode='" & lec_mcode.Text & "'" & _
                    ",lec_pointrate='" & lec_pointrate.Text & "'" & _
                    ",lec_eventcode='" & lec_eventcode.Text & "'" & _
                    ",lec_pointbase='" & lec_pointbase.Text & "'" & _
                     ",lec_active=" & WebUtils.BooleanToBit(chkactive.checked) & "" & _
                    " where lec_id=" & uid.value & " and lec_merchantid='" & theMerchantID & "' and lec_filter='" & theFilter & "'"

        End If


        If (WebUtils.ExecuteSQL(lsql, DBConnection) = False) Then
            ShowAlert("Error Saving, Please Retry")
        Else
            Response.Redirect(PageListing)
        End If



    End Sub

    Protected Function LoadSQLfromCloud() As DataSet
        Dim cn As New OleDb.OleDbConnection(DBConnection)
        Dim cmd As New OleDb.OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim ltemp As String = ""


        Try
            Dim lFilterstatement As String = " lec_merchantid='" & theMerchantID & "' and lec_Filter='" & theFilter & "' and lec_id=" & uid.value
            cn.Open()
            cmd.CommandText = "select * from LoyaltyEventDiscCat where " & lFilterstatement & ""
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


                lec_fromdate.Text = dr("lec_fromdate") & ""
                lec_todate.Text = dr("lec_todate") & ""


                lec_discount.Text = dr("lec_discount") & ""

                lec_transtype.Text = dr("lec_transtype") & ""


                lec_pointbase.Text = dr("lec_pointbase") & ""
                lec_pointrate.Text = dr("lec_pointrate") & ""
                lec_mcode.text = dr("lec_mcode") & ""

                chkactive.Checked = WebUtils.BitToBoolean(dr("lec_active") & "")

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

