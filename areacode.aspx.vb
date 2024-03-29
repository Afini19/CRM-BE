Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class areacode_class
    Inherits basepage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = "merchant_areacode"
        ActionType = "MAC"
        PageDetail = "areacode.aspx"
        PageListing = "areacodelist.aspx"
        EnableDelete = True

        If Page.IsPostBack = False Then
            btnDelete.Visible = False
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

        If (mac_code.Text & "").Trim = "" Then
            ShowAlert("Area Code is Mandatory")
            Return False
        End If

        If (mac_name.Text & "").Trim = "" Then
            ShowAlert("Area Name is Mandatory")
            Return False
        End If

        If WebLib.HasDuplicateData(DBConnection, DBTableName, "mac_code", mac_code.Text, "mac_uid", uid.Value, "mac_merchantid", WebLib.MerchantID) = True Then
            ShowAlert("Duplicate Code Exist. Please Retry")
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

                insertfields = insertfields & "mac_uid"
                insertvalues = insertvalues & "'" & luid & "'"
                insertfields = insertfields & ",mac_merchantid"
                insertvalues = insertvalues & ",'" & WebLib.MerchantID & "'"
                insertfields = insertfields & ",mac_code"
                insertvalues = insertvalues & ",'" & mac_code.Text.Replace("'", "''") & "'"
                insertfields = insertfields & ",mac_name"
                insertvalues = insertvalues & ",'" & mac_name.Text.Replace("'", "''") & "'"

                insertfields = insertfields & ",mac_valid"
                insertvalues = insertvalues & "," & WebUtils.BooleanToBit(chkactive.Checked)

                insertfields = insertfields & ",mac_createdt"
                insertvalues = insertvalues & ",getdate()"
                insertfields = insertfields & ",mac_createby"
                insertvalues = insertvalues & ",'" & WebLib.UserCode.replace("'", "''") & "'"
                insertfields = insertfields & ",mac_updateby"
                insertvalues = insertvalues & ",'" & WebLib.UserCode.replace("'", "''") & "'"
                insertfields = insertfields & ",mac_updatedt"
                insertvalues = insertvalues & ",getdate()"
            Else

                lType = "E"
                insertfields = ""
                insertvalues = insertvalues & "mac_name='" & mac_name.Text.Replace("'", "''") & "'"
                insertvalues = insertvalues & ",mac_code='" & mac_code.Text.Replace("'", "''") & "'"
                insertvalues = insertvalues & ",mac_valid=" & WebUtils.BooleanToBit(chkactive.Checked)
                insertvalues = insertvalues & ",mac_updateby='" & WebLib.UserCode.replace("'", "''") & "'"
                insertvalues = insertvalues & ",mac_updatedt=getdate()"

                updatedelwhere = "mac_uid='" & uid.Value & "'"
            End If

            If SaveDBData(lType, DBTableName, insertfields, insertvalues, updatedelwhere, lError, "") = True Then

                If (lType = "E") Then
                    ShowPrompt("Record Updated ", PageListing)
                Else
                    ShowPrompt("Record Saved ", PageDetail)
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
        Response.Redirect(PageListing)
    End Sub
    Public Sub deleterec(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim lError As String = ""

        If SaveDBData("D", DBTableName, "", "", " mac_uid='" & uid.Value & "'", lError, "") = True Then
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
            cmd.CommandText = "Select * from " & DBTableName & " where mac_uid='" & uid.Value & "' and mac_merchantid='" & WebLib.MerchantID & "'"
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows
                counter = counter + 1
                mac_code.Text = dr("mac_code") & ""
                mac_name.Text = dr("mac_name") & ""
                chkactive.Checked = WebUtils.BitToBoolean(dr("mac_valid") & "")
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

