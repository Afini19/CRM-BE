Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class voucher_class
    Inherits basepage
    Dim CODEFIELD As String = ""
    Dim theMerchantID As String = System.Configuration.ConfigurationSettings.AppSettings("themerchantid")
    Dim theFilter As String = System.Configuration.ConfigurationSettings.AppSettings("thefilter")
    Public ImageMainPath As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = ""
        DBConnection = System.Configuration.ConfigurationSettings.AppSettings("ConnStrCRM")
        ImageMainPath = "../Documents/" & WebLib.MerchantID & "/" & "VOUCHER" & "/"

        ActionType = "VOA"
        PageDetail = ""
        PageListing = "voucherlist.aspx"
        EnableDelete = False
        PageTitle = "Voucher Settings"
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
            lsql = "Insert Into eVoucher (" & _
            "vo_type,vo_qty,vo_amt,vo_code,vo_name,vo_active,vo_createby,vo_createdt,vo_updateby,vo_updatedt,vo_merchantid,vo_filter" & _
            ") values (" & _
            "'" & vo_type.SelectedValue & "'" & _
            "," & vo_qty.Text & "" & _
            "," & vo_amt.Text & "" & _
            ",'" & vo_code.Text & "'" & _
            ",'" & vo_name.Text & "'" & _
            "," & WebUtils.BooleanToBit(chkactive.checked) & "" & _
            ",'" & Weblib.UserCode & "'" & _
            ",getdate()" & _
            ",'" & Weblib.UserCode & "'" & _
            ",getdate()" & _
            ",'" & theMerchantID & "','" & theFilter & "')"
        Else
            lsql = "Update eVoucher set " & _
                    "vo_type='" & vo_type.SelectedValue & "'" & _
                    ",vo_qty=" & vo_qty.Text & "" & _
                    ",vo_amt=" & vo_amt.Text & "" & _
                    ",vo_code='" & vo_code.Text & "'" & _
                    ",vo_name='" & vo_name.Text & "'" & _
                    ",vo_active=" & WebUtils.BooleanToBit(chkactive.checked) & "" & _
                    ",vo_updateby='" & Weblib.UserCode & "'" & _
                    ",vo_updatedt=getdate()" & _
                    " where vo_id=" & uid.value & " and vo_merchantid='" & theMerchantID & "' and vo_filter='" & theFilter & "'"
        End If

        If (WebUtils.ExecuteSQL(lsql, DBConnection) = False) Then
            ShowPrompt("Error Saving, Please Retry", "")
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
            cmd.CommandText = "select * from eVoucher where " & lFilterstatement & ""
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
        If (doValidation() = False) Then
            Exit Sub
        End If
        Dim lsql As String = ""
        If (uid.value & "").trim = "" Then
            ShowPromptV2("Error Saving, Please Retry", "")
            Exit Sub
        Else
            lsql = "Delete from eVoucher where vo_id=" & uid.value & " and vo_merchantid='" & theMerchantID & "' and vo_filter='" & theFilter & "'"
        End If
        If (WebUtils.ExecuteSQL(lsql, DBConnection) = False) Then
            ShowPromptV2("Error Saving, Please Retry", "")
        Else
            Response.Redirect(PageListing)
        End If

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
                templi = vo_type.Items.FindByValue(dr("vo_type") & "")
                vo_type.SelectedIndex = vo_type.Items.IndexOf(templi)
                vo_qty.Text = dr("vo_qty") & ""
                vo_amt.Text = dr("vo_amt") & ""
                vo_code.Text = dr("vo_code") & ""
                vo_name.Text = dr("vo_name") & ""
                ' litpreview.text = "<img src=""../sample/" & dr("vo_image") & "" & """ style=""width:100%"" />"
                filename1.Value = dr("vo_image") & ""
                litpreview.text = "<img src=""" & ImageMainPath & dr("vo_image") & """ stlye=""width:100%;max-width:400px"">"

                chkactive.Checked = WebUtils.BitToBoolean(dr("vo_active") & "")

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


    Public Sub deletebutton_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If filename1.Value.Trim <> "" Then
            Try


                Try
                    If File.Exists(Server.MapPath(ImageMainPath & "") & filename1.Value) Then
                        Kill(Server.MapPath(ImageMainPath & "") & filename1.Value)
                    End If
                Catch ex As Exception
                    ShowAlert("Unable to Delete File. Please Retry")
                    Exit Sub
                End Try


                If WebUtils.ExecuteSQL("Update eVoucher set vo_image='" & "" & "' where vo_id=" & uid.Value & " and vo_merchantid='" & WebLib.MerchantID & "'", DBConnection) Then
                    Call loaddata()



                End If


            Catch ex As Exception
                ShowAlert("Unable to Delete File. Please Retry")
            End Try

        Else


        End If

    End Sub
    Public Sub uploadbutton_click(ByVal sender As System.Object, ByVal e As System.EventArgs)



        If (uid.Value & "").Trim = "" Then
            ShowAlert("Please save record before uploading images")
            Exit Sub
        End If

        If Page.IsPostBack = True Then
            Dim str1 As String = UploadedFile.PostedFile.FileName
            Dim lpath As String = ImageMainPath
            If uid.Value.ToString.Trim = "" Then
                ShowAlert("Please Select a Stock before upload")
                Exit Sub
            End If

            If webutils.FileFieldSelected(UploadedFile) = False Then
                ShowAlert("No file selected or the file is 0 bytes")
                Exit Sub
            Else

                Try

                    WebUtils.inituploads(Server.MapPath(lpath))



                    UploadedFile.PostedFile.SaveAs(Server.MapPath(lpath & webutils.RetrieveFileName(UploadedFile)))

                    If WebUtils.ExecuteSQL("Update eVoucher set vo_image='" & webutils.RetrieveFileName(UploadedFile) & "' where vo_id=" & uid.Value & " and vo_merchantid='" & WebLib.MerchantID & "'", DBConnection) Then

                        Call loaddata()

                    End If


                Catch ex As SystemException
                    Response.Write(ex.Message)
                    Response.End()
                    ShowPromptV2("Your browser security has blocked you from uploading", "")
                    Exit Sub
                End Try

            End If
            '            Call LoadData()
        End If


    End Sub

End Class

