Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class merbercategoryme_class


    Inherits basepage
    Dim CODEFIELD As String = ""
    Dim theMerchantID As String = System.Configuration.ConfigurationSettings.AppSettings("themerchantid")
    Dim theFilter As String = System.Configuration.ConfigurationSettings.AppSettings("thefilter")
    Public ImageMainPath As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = ""
        DBConnection = System.Configuration.ConfigurationSettings.AppSettings("ConnStrCRM")
        ImageMainPath = "Documents/" & WebLib.MerchantID & "/" & "LODISCAT" & "/"



        ActionType = "PPMCE"
        PageDetail = ""
        PageListing = "membercategorylistme.aspx"
        EnableDelete = False
        PageTitle = "Member Category Settings"
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


        ldc_mcode.LookupAssign = ";;" & ldc_mcode.MyClientIDHidden & "!!0"

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
        Dim lcatid As String = ""

        lcatid = ldc_mcode.TextHidden
        If isnumeric(lcatid) = False Then
            ShowAlert("Member Category Invalid")
            Exit Sub
        End If

        If (uid.value & "").trim = "" Then

            lsql = "Insert Into LoyaltyDiscCat (ldc_catid,ldc_mcode," & _
                  "ldc_discount,ldc_from,ldc_to,ldc_from1,ldc_to1,ldc_pointbase,ldc_pointrate,ldc_byamt,ldc_byfreq,ldc_byamt1,ldc_byfreq1,ldc_active,ldc_maintain,ldc_merchantid,ldc_filter" & _
                  ") values (" & _
                   "" & lcatid & "" & _
                   ",'" & ldc_mcode.text & "'" & _
                  "," & WebUtils.NumericOrNull(ldc_discount.text) & "" & _
                  "," & WebUtils.NumericOrNull(ldc_from.Text) & "" & _
                  "," & WebUtils.NumericOrNull(ldc_to.Text) & "" & _
                  "," & WebUtils.NumericOrNull(ldc_from1.Text) & "" & _
                  "," & WebUtils.NumericOrNull(ldc_to1.Text) & "" & _
                  "," & WebUtils.NumericOrNull(ldc_pointbase.Text) & "" & _
                  "," & WebUtils.NumericOrNull(ldc_pointrate.Text) & "" & _
                  "," & WebUtils.BooleanToBit(chkbyamt1.checked) & "" & _
                  "," & WebUtils.BooleanToBit(chkbyfreq.checked) & "" & _
                  "," & WebUtils.BooleanToBit(chkbyamt1.checked) & "" & _
                  "," & WebUtils.BooleanToBit(chkbyfreq1.checked) & "" & _
                  "," & WebUtils.BooleanToBit(chkactive.checked) & "" & _
                  "," & WebUtils.BooleanToBit(chkmaintain.checked) & "" & _
                  ",'" & theMerchantID & "','" & theFilter & "')"
        Else
            lsql = "Update LoyaltyDiscCat set ldc_discount=" & ldc_discount.Text & "" & _
                    ",ldc_catid=" & lcatid & "" & _
                    ",ldc_mcode='" & ldc_mcode.text & "'" & _
                    ",ldc_from=" & WebUtils.NumericOrNull(ldc_from.Text) & "" & _
                    ",ldc_to=" & WebUtils.NumericOrNull(ldc_to.Text) & "" & _
                    ",ldc_from1=" & WebUtils.NumericOrNull(ldc_from1.Text) & "" & _
                    ",ldc_to1=" & WebUtils.NumericOrNull(ldc_to1.Text) & "" & _
                    ",ldc_pointbase=" & WebUtils.NumericOrNull(ldc_pointbase.Text) & "" & _
                    ",ldc_pointrate=" & WebUtils.NumericOrNull(ldc_pointrate.Text) & "" & _
                    ",ldc_byamt=" & WebUtils.BooleanToBit(chkbyamt.checked) & "" & _
                    ",ldc_byfreq=" & WebUtils.BooleanToBit(chkbyfreq.checked) & "" & _
                     ",ldc_byamt1=" & WebUtils.BooleanToBit(chkbyamt1.checked) & "" & _
                    ",ldc_byfreq1=" & WebUtils.BooleanToBit(chkbyfreq1.checked) & "" & _
                    ",ldc_active=" & WebUtils.BooleanToBit(chkactive.checked) & "" & _
                    ",ldc_maintain=" & WebUtils.BooleanToBit(chkmaintain.checked) & "" & _
                    " where ldc_id=" & uid.value & " and ldc_merchantid='" & theMerchantID & "' and ldc_filter='" & theFilter & "'"
        End If

        If (WebUtils.ExecuteSQL(lsql, DBConnection) = False) Then
            ShowPrompt("Error Saving, Please Retry", "")
        Else
            response.redirect(PageListing)
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
            Dim lFilterstatement As String = " ldc_merchantid='" & theMerchantID & "' and ldc_Filter='" & theFilter & "' and ldc_id=" & uid.value
            cn.Open()
            cmd.CommandText = "select * from LoyaltyDiscCat where " & lFilterstatement & ""
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
                ldc_discount.Text = dr("ldc_discount") & ""
                ldc_from.Text = dr("ldc_from") & ""
                '  litpreview.text = "<img src=""../sample/" & dr("ldc_cardimg") & "" & """ style=""width:100%"" />"

                ldc_pointbase.Text = dr("ldc_pointbase") & ""
                ldc_pointrate.Text = dr("ldc_pointrate") & ""


                ldc_to.Text = dr("ldc_to") & ""
   
                ldc_mcode.Text = dr("ldc_mcode") & ""
                ldc_mcode.TextHidden = dr("ldc_catid") & ""

                ldc_to1.Text = dr("ldc_to1") & ""
                ldc_from1.Text = dr("ldc_from1") & ""

                chkactive.Checked = WebUtils.BitToBoolean(dr("ldc_active") & "")

                chkbyamt.checked = WebUtils.BitToBoolean(dr("ldc_byamt") & "")
                chkbyfreq.checked = WebUtils.BitToBoolean(dr("ldc_byfreq") & "")

                chkbyamt1.checked = WebUtils.BitToBoolean(dr("ldc_byamt1") & "")
                chkbyfreq1.checked = WebUtils.BitToBoolean(dr("ldc_byfreq1") & "")

                chkmaintain.checked = WebUtils.BitToBoolean(dr("ldc_maintain") & "")


                litpreview.text = "<img src=""../" & ImageMainPath & dr("ldc_cardimg") & """ stlye=""width:100%"">"


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

                    If WebUtils.ExecuteSQL("Update LoyaltyDisCat set ldc_cardimg='" & webutils.RetrieveFileName(UploadedFile) & "' where ldc_id=" & uid.Value & " and ldc_merchantid='" & WebLib.MerchantID & "'", DBConnection) Then



                    End If

                    response.write("Update LoyaltyDisCat set ldc_cardimg='" & webutils.RetrieveFileName(UploadedFile) & "' where ldc_id=" & uid.Value & " and ldc_merchantid='" & WebLib.MerchantID & "'")
                    response.write(Server.MapPath(lpath & webutils.RetrieveFileName(UploadedFile)))
                    responee.end()
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

