Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class namec_add_class
    Inherits basepage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = "namec"
        caishAPP = "NAMEC"
        If page.ispostback = False Then
            If (caishUID).Trim <> "" Then
                uid.Value = caishUID
                Call LoadData()
            End If
        End If

        If CanDelete() = True Then
            btndelete.Visible = True
        End If

    End Sub
    Protected Function doValidation() As Boolean

        If (nc_name.Text & "").Trim = "" Then
            ShowAlert("Contact Name is Mandatory")
            Return False
        End If
        If (nc_company.Text & "").Trim = "" Then
            ShowAlert("Company Name is Mandatory")
            Return False
        End If

        Return True
    End Function
    Public Sub deletedata(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim updatedelwhere As String = "nc_uid='" & uid.Value & "' and nc_merchantid='" & WebLib.MerchantID.replace("'", "''") & "'"
        Dim lError As String = ""

        Try

            If SaveDBData("D", DBTableName, "", "", updatedelwhere, lError, "") = True Then
                ShowPrompt("Record Deleted", "menu.aspx")
            Else

                ShowAlert("Error Saving Record. Please Retry")
            End If

        Catch Err As Exception
            ShowAlert("Error: " & Err.Message)
        Finally

        End Try
    End Sub

    Public Sub savedata(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim insertfields, insertvalues, updatedelwhere As String
        Dim ldocno As String = ""
        Dim luid As String = ""
        Dim lType As String = ""
        Dim lError As String = ""

        insertfields = ""
        insertvalues = ""
        updatedelwhere = ""

        If doValidation() = False Then
            Exit Sub
        End If




        Try
            Dim lisprivate As Boolean = False
            lisprivate = WebUtils.AnythingToBoolean(nc_private.Value)


            If uid.Value.Trim = "" Then
                lType = "A"
                luid = GetUID()
                If luid.Trim = "" Then
                    ShowAlert("There is a problem saving data. Please retry")
                    Exit Sub
                End If

                insertfields = insertfields & "nc_merchantid"
                insertvalues = insertvalues & "'" & WebLib.MerchantID.replace("'", "''") & "'"
                insertfields = insertfields & ",nc_filter"
                insertvalues = insertvalues & ",'" & WebLib.FilterCode.replace("'", "''") & "'"
                insertfields = insertfields & ",nc_name"
                insertvalues = insertvalues & ",'" & nc_name.Text.Replace("'", "''") & "'"
                insertfields = insertfields & ",nc_company"
                insertvalues = insertvalues & ",'" & nc_company.Text.Replace("'", "''") & "'"
                insertfields = insertfields & ",nc_email"
                insertvalues = insertvalues & ",'" & nc_email.Text.Replace("'", "''") & "'"
                insertfields = insertfields & ",nc_companyreg"
                insertvalues = insertvalues & ",'" & nc_companyreg.Text.Replace("'", "''") & "'"
                insertfields = insertfields & ",nc_private"
                insertvalues = insertvalues & "," & WebUtils.BooleanToBit(lisprivate)
                insertfields = insertfields & ",nc_mobileno"
                insertvalues = insertvalues & ",'" & nc_mobileno.Text.Replace("'", "''") & "'"
                insertfields = insertfields & ",nc_createdt"
                insertvalues = insertvalues & ",getdate()"
                insertfields = insertfields & ",nc_uid"
                insertvalues = insertvalues & ",'" & luid & "'"
                insertfields = insertfields & ",nc_createby"
                insertvalues = insertvalues & ",'" & WebLib.UserCode.replace("'", "''") & "'"
                insertfields = insertfields & ",nc_updateby"
                insertvalues = insertvalues & ",'" & WebLib.UserCode.replace("'", "''") & "'"
                insertfields = insertfields & ",nc_updatedt"
                insertvalues = insertvalues & ",getdate()"
            Else
                lType = "E"
                insertfields = ""
                insertvalues = insertvalues & "nc_name='" & nc_name.Text.Replace("'", "''") & "'"
                insertvalues = insertvalues & ",nc_company='" & nc_company.Text.Replace("'", "''") & "'"
                insertvalues = insertvalues & ",nc_email='" & nc_email.Text.Replace("'", "''") & "'"
                insertvalues = insertvalues & ",nc_companyreg='" & nc_companyreg.Text.Replace("'", "''") & "'"
                insertvalues = insertvalues & ",nc_mobileno='" & nc_mobileno.Text.Replace("'", "''") & "'"
                insertvalues = insertvalues & ",nc_private=" & WebUtils.BooleanToBit(lisprivate)
                insertvalues = insertvalues & ",nc_updateby='" & WebLib.UserCode.replace("'", "''") & "'"
                insertvalues = insertvalues & ",nc_updatedt=getdate()"
                updatedelwhere = "nc_uid='" & uid.Value & "' and nc_merchantid='" & WebLib.MerchantID.replace("'", "''") & "'"
            End If

            If SaveDBData(lType, DBTableName, insertfields, insertvalues, updatedelwhere, lError, "") = True Then
                ' Response.Write(WebLib.DebugData)
                ShowPrompt("Record Saved", "menu.aspx")
            Else

                ShowAlert("Error Saving Record. Please Retry")
            End If

        Catch Err As Exception
            ShowAlert("Error: " & Err.Message)
        Finally

        End Try

    End Sub
    Public Sub backpage(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Response.Redirect("menu.aspx")
    End Sub
    Protected Sub LoadData()

        Dim cn As New OleDbConnection(DBConnection)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow


        Try
            cmd.CommandText = "Select * from " & DBTableName & " where nc_uid='" & uid.Value & "'"
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows
                counter = counter + 1

                nc_name.Text = dr("nc_name") & ""
                nc_company.Text = dr("nc_company") & ""
                nc_email.Text = dr("nc_email") & ""
                nc_mobileno.Text = dr("nc_mobileno") & ""
                nc_companyreg.Text = dr("nc_companyreg") & ""


                If WebUtils.BitToBoolean(dr("nc_private") & "") = True Then
                    CheckAControl("isprivateyes", True)
                End If

                Exit For
            Next
            cn.Close()
            cmd.Dispose()
            cn.Dispose()
        Catch ex As Exception
            ShowAlert("Ooops... We are encoutering heavy access. Please try again")
            Exit Sub
        End Try




    End Sub
End Class

