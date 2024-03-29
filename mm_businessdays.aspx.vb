Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class mmbusinessdays_class
    Inherits basepage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = "merchant_multi"
        ActionType = "MMD"
        PageDetail = "mm_businessdays.aspx"
        PageListing = "menusplash.aspx"
        EnableDelete = False
        btnDelete.Visible = False
        If Page.IsPostBack = False Then
            Call LoadData()
        End If

        If (WebLib.ActionParamMMUID & "").trim = "" Then
            Response.Redirect("loginmerchant.aspx")
        End If

        If (mm_shutmsg.text & "").trim = "" Then
            mm_shutmsg.text = "We will be closed starting (Starting Date) through (End Date) returning(Date of Return). Thank you for your support "
        End If

    End Sub
    Protected Function doValidation() As Boolean
        Return True
    End Function
    Public Sub savedata(ByVal sender As System.Object, ByVal e As System.EventArgs)



        Dim insertfields, insertvalues, updatedelwhere As String
        Dim ldocno As String = ""
        Dim luid As String = ""
        Dim lType As String = ""
        Dim lError As String = ""
        Dim _logincode As String = ""

        insertfields = ""
        insertvalues = ""
        updatedelwhere = ""

        If doValidation() = False Then
            Exit Sub
        End If


        Try

            If uid.Value.Trim = "" Then
                ShowAlert("Invalid User. Cannot change password")
                Exit Sub
            Else

                lType = "E"
                insertfields = ""
                insertvalues = insertvalues & "mm_shut=" & WebUtils.BooleanToBit(mm_shut.Checked) & ""
                insertvalues = insertvalues & ",mm_shutmsg='" & mm_shutmsg.text.replace("'", "''") & "'"
                insertvalues = insertvalues & ",mm_workmon=" & WebUtils.BooleanToBit(mm_workmon.Checked) & ""
                insertvalues = insertvalues & ",mm_worktue=" & WebUtils.BooleanToBit(mm_worktue.Checked) & ""
                insertvalues = insertvalues & ",mm_workwed=" & WebUtils.BooleanToBit(mm_workwed.Checked) & ""
                insertvalues = insertvalues & ",mm_workthur=" & WebUtils.BooleanToBit(mm_workthur.Checked) & ""
                insertvalues = insertvalues & ",mm_workfri=" & WebUtils.BooleanToBit(mm_workfri.Checked) & ""
                insertvalues = insertvalues & ",mm_worksat=" & WebUtils.BooleanToBit(mm_worksat.Checked) & ""
                insertvalues = insertvalues & ",mm_worksun=" & WebUtils.BooleanToBit(mm_worksun.Checked) & ""

                updatedelwhere = "mm_uid='" & uid.Value & "' and mm_merchantid='" & WebLib.MerchantID & "'"
            End If

            If SaveDBData(lType, DBTableName, insertfields, insertvalues, updatedelwhere, lError, "") = True Then

                ShowPrompt("Record Updated ", PageListing)
            Else
                ShowAlert("Error Submitting. Please Retry ")
            End If

        Catch Err As Exception
            ShowAlert("Error: " & Err.Message)
        Finally

        End Try


    End Sub
    Public Sub backpage(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call gotoTheback()

    End Sub
    Public Sub gotoTheback()
        Response.Redirect(PageListing)
    End Sub
    Public Sub deleterec(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub LoadData()
        Dim cn As New OleDbConnection(DBConnection)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow

        Try
            cn.Open()
            cmd.CommandText = "Select isnull(mm_workmon,1) as mm_workmon,isnull(mm_worktue,1) as mm_worktue,isnull(mm_workwed,1) as mm_workwed,isnull(mm_workthur,1) as mm_workthur,isnull(mm_workfri,1) as mm_workfri,isnull(mm_worksat,1) as mm_worksat,isnull(mm_worksun,1) as mm_worksun,mm_shut,mm_uid,mm_shutmsg from " & DBTableName & " where mm_uid='" & WebLib.ActionParamMMUID.trim & "' and mm_merchantid='" & WebLib.MerchantID & "'"
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows
                counter = counter + 1
                uid.value = dr("mm_uid") & ""
                mm_workmon.Checked = WebUtils.BitToBoolean(dr("mm_workmon") & "")
                mm_worktue.Checked = WebUtils.BitToBoolean(dr("mm_worktue") & "")
                mm_workwed.Checked = WebUtils.BitToBoolean(dr("mm_workwed") & "")
                mm_workthur.Checked = WebUtils.BitToBoolean(dr("mm_workthur") & "")
                mm_workfri.Checked = WebUtils.BitToBoolean(dr("mm_workfri") & "")
                mm_worksat.Checked = WebUtils.BitToBoolean(dr("mm_worksat") & "")
                mm_worksun.Checked = WebUtils.BitToBoolean(dr("mm_worksun") & "")
                mm_shut.Checked = WebUtils.BitToBoolean(dr("mm_shut") & "")
                mm_shutmsg.text = dr("mm_shutmsg") & ""
                Exit For
            Next

            cn.Close()
            cmd.Dispose()
            cn.Dispose()


            If EnableDelete = True Then
                btnDelete.Visible = True
            End If
        Catch ex As Exception
            ShowAlert("Ooops... We are encoutering heavy access. Please try again")
            Exit Sub
        End Try




    End Sub



End Class

