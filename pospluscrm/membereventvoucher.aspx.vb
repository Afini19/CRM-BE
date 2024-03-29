Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class membereventvoucher_class
    Inherits basepage
    Dim CODEFIELD As String = ""
    Dim theMerchantID As String = System.Configuration.ConfigurationSettings.AppSettings("themerchantid")
    Dim theFilter As String = System.Configuration.ConfigurationSettings.AppSettings("thefilter")
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = ""
        DBConnection = System.Configuration.ConfigurationSettings.AppSettings("ConnStrCRM")

        ActionType = "VOA"
        PageDetail = ""
        PageListing = "membereventvoucherlist.aspx"
        EnableDelete = False
        PageTitle = "Voucher Event Based"
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

        vo_code.LookupAssign = ";;" & vo_name.MyClientID & "!!2;;" & vo_name.MyClientIDHidden & "!!2;;" & vo_code.MyClientIDHidden & "!!0"

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


        Dim lvDateFrom As String = vo_vdatefrom.text
        Dim lvDateTo As String = vo_vdateto.text

        If isdate(vo_vdatefrom.text) = True Then
            lvDateFrom = "'" & WebUtils.FormatDateYYYYMMDD(CDate(vo_vdatefrom.text)) & "'"
        Else
            lvDateFrom = "NULL"
        End If
        If isdate(vo_vdateto.text) = True Then
            lvDateTo = "'" & WebUtils.FormatDateYYYYMMDD(CDate(vo_vdateto.text)) & "'"
        Else
            lvDateTo = "NULL"
        End If



        Dim lvoid As String = vo_code.textHidden
        If isnumeric(lvoid) = False Then
            ShowAlert("Invalid Voucher Selection")
            Exit Sub
        End If

        If (uid.value & "").trim = "" Then


            lsql = "Insert Into loyaltyeventeVoucher (vo_qty,vo_fromdays,vo_source,vo_void" & _
             ",vo_todays,vo_points,vo_datefrom,vo_dateto,vo_code,vo_eventcode,vo_name,vo_redeembysignup,vo_canredeem,vo_validate1" & _
             ",vo_validate2,vo_validate3,vo_validate4,vo_bday,vo_cancollect,vo_anniversary,vo_christmas,vo_valentines,vo_vdatefrom,vo_vdateto,vo_active,vo_merchantid,vo_filter" & _
             ") values (" & _
              "" & WebUtils.NumericOrNull(vo_qty.Text) & "" & _
              "," & WebUtils.NumericOrNull(vo_fromdays.Text) & "" & _
              ",'E'" & _
             "," & lvoid & "" & _
             "," & WebUtils.NumericOrNull(vo_todays.Text) & "" & _
             "," & WebUtils.NumericOrNull(vo_points.Text) & "" & _
             ",'" & WebUtils.FormatDateYYYYMMDD(CDate(vo_datefrom.text)) & "'" & _
             ",'" & WebUtils.FormatDateYYYYMMDD(CDate(vo_dateto.text)) & "'" & _
             ",'" & vo_code.Text & "'" & _
             ",'" & Eventcode.Text & "'" & _
             ",'" & vo_name.TextHidden & "'" & _
             "," & WebUtils.BooleanToBit(vo_redeembysignup.checked) & "" & _
             "," & WebUtils.BooleanToBit(vo_canredeem.checked) & "" & _
             "," & WebUtils.BooleanToBit(vo_validate1.checked) & "" & _
             "," & WebUtils.BooleanToBit(vo_validate2.checked) & "" & _
             "," & WebUtils.BooleanToBit(vo_validate3.checked) & "" & _
             "," & WebUtils.BooleanToBit(vo_validate4.checked) & "" & _
             "," & WebUtils.BooleanToBit(vo_bday.checked) & "" & _
            "," & WebUtils.BooleanToBit(vo_cancollect.checked) & "" & _
            "," & WebUtils.BooleanToBit(vo_anniversary.checked) & "" & _
            "," & WebUtils.BooleanToBit(vo_christmas.checked) & "" & _
            "," & WebUtils.BooleanToBit(vo_valentines.checked) & "" & _
            "," & lvDateFrom & "" & _
            "," & lvDateTo & "" & _
             "," & WebUtils.BooleanToBit(chkactive.checked) & "" & _
             ",'" & theMerchantID & "','" & theFilter & "')"

        Else
            lsql = "Update loyaltyeventeVoucher set " & _
                    "vo_qty=" & WebUtils.NumericOrNull(vo_qty.Text) & "" & _
                    ",vo_void=" & lvoid & "" & _
                    ",vo_fromdays=" & WebUtils.NumericOrNull(vo_fromdays.Text) & "" & _
                    ",vo_todays=" & WebUtils.NumericOrNull(vo_todays.Text) & "" & _
                    ",vo_points=" & WebUtils.NumericOrNull(vo_points.Text) & "" & _
                    ",vo_datefrom='" & WebUtils.FormatDateYYYYMMDD(CDate(vo_datefrom.text)) & "'" & _
                    ",vo_dateto='" & WebUtils.FormatDateYYYYMMDD(CDate(vo_dateto.text)) & "'" & _
                    ",vo_code='" & vo_code.Text & "'" & _
                    ",vo_eventcode='" & Eventcode.Text & "'" & _
                    ",vo_name='" & vo_name.TextHidden & "'" & _
                    ",vo_redeembysignup=" & WebUtils.BooleanToBit(vo_redeembysignup.checked) & "" & _
                    ",vo_canredeem=" & WebUtils.BooleanToBit(vo_canredeem.checked) & "" & _
                    ",vo_validate1=" & WebUtils.BooleanToBit(vo_validate1.checked) & "" & _
                    ",vo_validate2=" & WebUtils.BooleanToBit(vo_validate2.checked) & "" & _
                    ",vo_validate3=" & WebUtils.BooleanToBit(vo_validate3.checked) & "" & _
                    ",vo_validate4=" & WebUtils.BooleanToBit(vo_validate4.checked) & "" & _
                    ",vo_bday=" & WebUtils.BooleanToBit(vo_bday.checked) & "" & _
                    ",vo_cancollect=" & WebUtils.BooleanToBit(vo_cancollect.checked) & "" & _
                    ",vo_anniversary=" & WebUtils.BooleanToBit(vo_anniversary.checked) & "" & _
                    ",vo_christmas=" & WebUtils.BooleanToBit(vo_christmas.checked) & "" & _
                    ",vo_valentines=" & WebUtils.BooleanToBit(vo_valentines.checked) & "" & _
                    ",vo_active=" & WebUtils.BooleanToBit(chkactive.checked) & "" & _
                    ",vo_vdatefrom=" & lvDateFrom & "" & _
                    ",vo_vdateto=" & lvDateTo & _
                    " where vo_id=" & uid.value & " and vo_merchantid='" & theMerchantID & "' and vo_filter='" & theFilter & "'"
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
            Dim lFilterstatement As String = " vo_merchantid='" & theMerchantID & "' and vo_Filter='" & theFilter & "' and vo_id=" & uid.value
            cn.Open()
            cmd.CommandText = "select * from loyaltyeventeVoucher where " & lFilterstatement & ""
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
  
                vo_qty.Text = dr("vo_qty") & ""

                vo_datefrom.Text = dr("vo_datefrom") & ""
                vo_dateto.Text = dr("vo_dateto") & ""

                If (isdate(dr("vo_vdateto") & "")) = True Then
                    vo_vdateto.Text = dr("vo_vdateto") & ""
                End If
                If (isdate(dr("vo_vdatefrom") & "")) = True Then
                    vo_vdatefrom.Text = dr("vo_vdatefrom") & ""
                End If

                vo_code.Text = dr("vo_code") & ""
                vo_code.TextHidden = dr("vo_void") & ""
                vo_name.Text = dr("vo_name") & ""
                vo_name.TextHidden = dr("vo_name") & ""
                vo_points.Text = dr("vo_points") & ""
                chkactive.Checked = WebUtils.BitToBoolean(dr("vo_active") & "")
                vo_redeembysignup.Checked = WebUtils.BitToBoolean(dr("vo_redeembysignup") & "")
                vo_canredeem.Checked = WebUtils.BitToBoolean(dr("vo_canredeem") & "")
                Eventcode.text = dr("vo_eventcode") & ""
                vo_validate1.Checked = WebUtils.BitToBoolean(dr("vo_validate1") & "")
                vo_validate2.Checked = WebUtils.BitToBoolean(dr("vo_validate2") & "")
                vo_validate3.Checked = WebUtils.BitToBoolean(dr("vo_validate3") & "")
                vo_validate4.Checked = WebUtils.BitToBoolean(dr("vo_validate4") & "")
                eventurl.text = "https://crm.posplus-crm.com/?c=" & dr("vo_url") & ""
                vo_bday.Checked = WebUtils.BitToBoolean(dr("vo_bday") & "")
                vo_anniversary.Checked = WebUtils.BitToBoolean(dr("vo_anniversary") & "")
                vo_christmas.Checked = WebUtils.BitToBoolean(dr("vo_christmas") & "")
                vo_valentines.Checked = WebUtils.BitToBoolean(dr("vo_valentines") & "")
                vo_cancollect.Checked = WebUtils.BitToBoolean(dr("vo_cancollect") & "")
                vo_fromdays.Text = dr("vo_fromdays") & ""
                vo_todays.Text = dr("vo_todays") & ""
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

