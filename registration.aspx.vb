Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class registration_class
    Inherits basepage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = "merchant_multi"
        ActionType = "MM"
        EnableDelete = True

        If Page.IsPostBack = False Then


            btnDelete.Visible = False

            Call WebLib.setListItemsTable(mm_area, "mac_name", "mac_code", "merchant_areacode", "mac_name", "", "mac_merchantid", "", " isnull(mac_valid,1)<>0 ", , "Please Select")
            Call WebLib.setListItemsTable(mm_state, "ms_name", "ms_code", "merchant_state", "ms_name", "", "ms_merchantid", "", " isnull(ms_valid,1)<>0 ", , "Please Select")

            Call WebLib.setListItemsTable(mm_bnkuid, "bnk_name", "bnk_uid", "merchant_bank", "bnk_name", "", "bnk_merchantid", "", " isnull(bnk_valid,1)<>0 ", , "Please Select")

            If WebLib.ActionUID.trim <> "" And WebLib.ActionType = ActionType Then
                uid.Value = WebLib.ActionUID.trim
                Call LoadData()
            End If


        End If

        If WebLib.UserIsFullAdmin = False Then
            response.redirect("loginmain.aspx")
        End If

      
    End Sub
    Protected Function doValidation() As Boolean

        If (mm_name.Text & "").Trim = "" Then
            ShowAlert("Name is Mandatory")
            Return False
        End If

        If (mm_email.Text & "").Trim = "" Then
            ShowAlert("Email is Mandatory")
            Return False
        End If
        If WebUtils.isEmailFormat(mm_email.Text) Then

        Else
            ShowAlert("Invalid Email Address")
            Return False
        End If

        If (mm_area.SelectedValue = "") Then
            ShowAlert("Area Code is Mandatory")
            Return False
        End If
        If (mm_state.SelectedValue = "") Then
            ShowAlert("State is Mandatory")
            Return False
        End If

        If IsNumeric(mm_zipcode.Text) = False Then
            ShowAlert("Post Code is Mandatory")
            Return False
        End If

        If IsNumeric(mm_hpno.Text) = False And (mm_hpno.Text <> "") Then
            ShowAlert("Invalid HP Number")
            Return False
        End If

        If WebLib.HasDuplicateData(DBConnection, DBTableName, "mm_loginid", mm_loginid.Text, "mm_uid", uid.Value, "mm_merchantid", WebLib.MerchantID) = True Then
            ShowAlert("Login ID Taken, Please Re-Enter")
            Return False
        End If



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
                lType = "A"
                luid = GetUID()
                If luid.Trim = "" Then
                    ShowAlert("There is a problem saving data. Please retry")
                    Exit Sub
                End If

                insertfields = insertfields & "mm_uid"
                insertvalues = insertvalues & "'" & luid & "'"
                insertfields = insertfields & ",mm_merchantid"
                insertvalues = insertvalues & ",'" & WebLib.MerchantID & "'"
                insertfields = insertfields & ",mm_name"
                insertvalues = insertvalues & ",'" & mm_name.Text.Replace("'", "''") & "'"
                insertfields = insertfields & ",mm_address1"
                insertvalues = insertvalues & ",'" & mm_address1.Text.Replace("'", "''") & "'"
                insertfields = insertfields & ",mm_address2"
                insertvalues = insertvalues & ",'" & mm_address2.Text.Replace("'", "''") & "'"
                insertfields = insertfields & ",mm_address3"
                insertvalues = insertvalues & ",'" & mm_address3.Text.Replace("'", "''") & "'"
                insertfields = insertfields & ",mm_address4"
                insertvalues = insertvalues & ",'" & mm_address4.Text.Replace("'", "''") & "'"
                insertfields = insertfields & ",mm_area"
                insertvalues = insertvalues & ",'" & mm_area.SelectedValue.Replace("'", "''") & "'"
                insertfields = insertfields & ",mm_state"
                insertvalues = insertvalues & ",'" & mm_state.SelectedValue.Replace("'", "''") & "'"
                insertfields = insertfields & ",mm_zipcode"
                insertvalues = insertvalues & ",'" & mm_zipcode.Text.Replace("'", "''") & "'"
                insertfields = insertfields & ",mm_password"
                insertvalues = insertvalues & ",'" & mm_password.Text.Replace("'", "''") & "'"
                insertfields = insertfields & ",mm_loginid"
                insertvalues = insertvalues & ",'" & mm_loginid.Text.Replace("'", "''") & "'"
                insertfields = insertfields & ",mm_long"
                insertvalues = insertvalues & ",'" & mm_long.Text.Replace("'", "''") & "'"
                insertfields = insertfields & ",mm_lat"
                insertvalues = insertvalues & ",'" & mm_lat.Text.Replace("'", "''") & "'"
                insertfields = insertfields & ",mm_email"
                insertvalues = insertvalues & ",'" & mm_email.Text.Replace("'", "''") & "'"

                insertfields = insertfields & ",mm_bnkaccno"
                insertvalues = insertvalues & ",'" & mm_bnkaccno.Text.Replace("'", "''") & "'"

                insertfields = insertfields & ",mm_bnkaccname"
                insertvalues = insertvalues & ",'" & mm_bnkaccname.Text.Replace("'", "''") & "'"

                insertfields = insertfields & ",mm_contactname"
                insertvalues = insertvalues & ",'" & mm_contactname.Text.Replace("'", "''") & "'"


                insertfields = insertfields & ",mm_hpno"
                insertvalues = insertvalues & ",'" & mm_hpno.Text.Replace("'", "''") & "'"

                insertfields = insertfields & ",mm_bnkuid"
                insertvalues = insertvalues & ",'" & mm_bnkuid.SelectedValue.Replace("'", "''") & "'"



                insertfields = insertfields & ",mm_createdt"
                insertvalues = insertvalues & ",getdate()"
                insertfields = insertfields & ",mm_createby"
                insertvalues = insertvalues & ",'" & WebLib.UserCode.replace("'", "''") & "'"
                insertfields = insertfields & ",mm_updateby"
                insertvalues = insertvalues & ",'" & WebLib.UserCode.replace("'", "''") & "'"
                insertfields = insertfields & ",mm_updatedt"
                insertvalues = insertvalues & ",getdate()"
                insertfields = insertfields & ",mm_active"
                insertvalues = insertvalues & "," & WebUtils.BooleanToBit(chkactive.Checked)


                insertfields = insertfields & ",mm_workmon"
                insertvalues = insertvalues & "," & WebUtils.BooleanToBit(mm_workmon.Checked)
                insertfields = insertfields & ",mm_worktue"
                insertvalues = insertvalues & "," & WebUtils.BooleanToBit(mm_worktue.Checked)
                insertfields = insertfields & ",mm_workwed"
                insertvalues = insertvalues & "," & WebUtils.BooleanToBit(mm_workwed.Checked)
                insertfields = insertfields & ",mm_workthur"
                insertvalues = insertvalues & "," & WebUtils.BooleanToBit(mm_workthur.Checked)
                insertfields = insertfields & ",mm_workfri"
                insertvalues = insertvalues & "," & WebUtils.BooleanToBit(mm_workfri.Checked)
                insertfields = insertfields & ",mm_worksat"
                insertvalues = insertvalues & "," & WebUtils.BooleanToBit(mm_worksat.Checked)
                insertfields = insertfields & ",mm_worksun"
                insertvalues = insertvalues & "," & WebUtils.BooleanToBit(mm_worksun.Checked)
                insertfields = insertfields & ",mm_shut"
                insertvalues = insertvalues & "," & WebUtils.BooleanToBit(mm_shut.Checked)
                insertfields = insertfields & ",mm_shutmsg"
                insertvalues = insertvalues & ",'" & mm_shutmsg.Text.Replace("'", "''") & "'"

            Else

                lType = "E"
                insertfields = ""
                insertvalues = insertvalues & "mm_name='" & mm_name.Text.Replace("'", "''") & "'"
                insertvalues = insertvalues & ",mm_email='" & mm_email.Text.Replace("'", "''") & "'"
                insertvalues = insertvalues & ",mm_address1='" & mm_address1.Text.Replace("'", "''") & "'"
                insertvalues = insertvalues & ",mm_address2='" & mm_address2.Text.Replace("'", "''") & "'"
                insertvalues = insertvalues & ",mm_address3='" & mm_address3.Text.Replace("'", "''") & "'"
                insertvalues = insertvalues & ",mm_address4='" & mm_address4.Text.Replace("'", "''") & "'"
                insertvalues = insertvalues & ",mm_area='" & mm_area.SelectedValue.Replace("'", "''") & "'"
                insertvalues = insertvalues & ",mm_state='" & mm_state.SelectedValue.Replace("'", "''") & "'"
                insertvalues = insertvalues & ",mm_lat='" & mm_lat.Text.Replace("'", "''") & "'"
                insertvalues = insertvalues & ",mm_long='" & mm_long.Text.Replace("'", "''") & "'"
                insertvalues = insertvalues & ",mm_loginid='" & mm_loginid.Text.Replace("'", "''") & "'"
                insertvalues = insertvalues & ",mm_password='" & mm_password.Text.Replace("'", "''") & "'"
                insertvalues = insertvalues & ",mm_zipcode='" & mm_zipcode.Text.Replace("'", "''") & "'"

                insertvalues = insertvalues & ",mm_bnkaccno='" & mm_bnkaccno.Text.Replace("'", "''") & "'"
                insertvalues = insertvalues & ",mm_bnkaccname='" & mm_bnkaccname.Text.Replace("'", "''") & "'"
                insertvalues = insertvalues & ",mm_contactname='" & mm_contactname.Text.Replace("'", "''") & "'"
                insertvalues = insertvalues & ",mm_hpno='" & mm_hpno.Text.Replace("'", "''") & "'"
                insertvalues = insertvalues & ",mm_bnkuid='" & mm_area.SelectedValue.Replace("'", "''") & "'"

                insertvalues = insertvalues & ",mm_updateby='" & WebLib.UserCode.replace("'", "''") & "'"
                insertvalues = insertvalues & ",mm_updatedt=getdate()"
                insertvalues = insertvalues & ",mm_active=" & WebUtils.BooleanToBit(chkactive.Checked)
                insertvalues = insertvalues & ",mm_shut=" & WebUtils.BooleanToBit(mm_shut.Checked) & ""
                insertvalues = insertvalues & ",mm_shutmsg='" & mm_shutmsg.text.replace("'", "''") & "'"
                insertvalues = insertvalues & ",mm_workmon=" & WebUtils.BooleanToBit(mm_workmon.Checked) & ""
                insertvalues = insertvalues & ",mm_worktue=" & WebUtils.BooleanToBit(mm_worktue.Checked) & ""
                insertvalues = insertvalues & ",mm_workwed=" & WebUtils.BooleanToBit(mm_workwed.Checked) & ""
                insertvalues = insertvalues & ",mm_workthur=" & WebUtils.BooleanToBit(mm_workthur.Checked) & ""
                insertvalues = insertvalues & ",mm_workfri=" & WebUtils.BooleanToBit(mm_workfri.Checked) & ""
                insertvalues = insertvalues & ",mm_worksat=" & WebUtils.BooleanToBit(mm_worksat.Checked) & ""
                insertvalues = insertvalues & ",mm_worksun=" & WebUtils.BooleanToBit(mm_worksun.Checked) & ""


                updatedelwhere = "mm_uid='" & uid.Value & "'"
            End If

            If SaveDBData(lType, DBTableName, insertfields, insertvalues, updatedelwhere, lError, "") = True Then

                If (lType = "E") Then
                    ShowPrompt("Record Updated ", "registrationlist.aspx")
                Else
                    ShowPrompt("Record Saved ", "registration.aspx")
                End If
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
        Response.Redirect("registrationlist.aspx")
    End Sub
    Public Sub deleterec(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim lError As String = ""

        If SaveDBData("D", DBTableName, "", "", " mm_uid='" & uid.Value & "'", lError, "") = True Then
            WebLib.ActionUID = ""
            Call gotoTheback()
        Else
            ShowAlert("Error Submitting. Please Retry ")
        End If
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
            cmd.CommandText = "Select *,isnull(mm_workmon,1) as mm_workmon1,isnull(mm_worktue,1) as mm_worktue1,isnull(mm_workwed,1) as mm_workwed1,isnull(mm_workthur,1) as mm_workthur1,isnull(mm_workfri,1) as mm_workfri1,isnull(mm_worksat,1) as mm_worksat1,isnull(mm_worksun,1) as mm_worksun1 from " & DBTableName & " where mm_uid='" & uid.Value & "' and mm_merchantid='" & WebLib.MerchantID & "'"
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows
                counter = counter + 1

                mm_name.Text = dr("mm_name") & ""
                mm_address1.Text = dr("mm_address1") & ""
                mm_address2.Text = dr("mm_address2") & ""
                mm_address3.Text = dr("mm_address3") & ""
                mm_address4.Text = dr("mm_address4") & ""
                mm_area.Text = dr("mm_area") & ""
                mm_state.Text = dr("mm_state") & ""
                mm_email.Text = dr("mm_email") & ""
                mm_lat.Text = dr("mm_lat") & ""
                mm_long.Text = dr("mm_long") & ""
                mm_loginid.Text = dr("mm_loginid") & ""
                mm_password.Text = dr("mm_password") & ""
                mm_zipcode.Text = dr("mm_zipcode") & ""

                mm_bnkaccno.Text = dr("mm_bnkaccno") & ""
                mm_bnkaccname.Text = dr("mm_bnkaccname") & ""
                mm_contactname.Text = dr("mm_contactname") & ""
                mm_hpno.Text = dr("mm_hpno") & ""
                mm_bnkuid.Text = dr("mm_bnkuid") & ""

                mm_workmon.Checked = WebUtils.BitToBoolean(dr("mm_workmon1") & "")
                mm_worktue.Checked = WebUtils.BitToBoolean(dr("mm_worktue1") & "")
                mm_workwed.Checked = WebUtils.BitToBoolean(dr("mm_workwed1") & "")
                mm_workthur.Checked = WebUtils.BitToBoolean(dr("mm_workthur1") & "")
                mm_workfri.Checked = WebUtils.BitToBoolean(dr("mm_workfri1") & "")
                mm_worksat.Checked = WebUtils.BitToBoolean(dr("mm_worksat1") & "")
                mm_worksun.Checked = WebUtils.BitToBoolean(dr("mm_worksun1") & "")
                mm_shut.Checked = WebUtils.BitToBoolean(dr("mm_shut") & "")
                mm_shutmsg.text = dr("mm_shutmsg") & ""

                chkactive.Checked = WebUtils.BitToBoolean(dr("mm_active") & "")

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

