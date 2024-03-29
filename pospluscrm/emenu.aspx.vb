Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class emenu_class


    Inherits basepage
    Dim CODEFIELD As String = ""
    Public ImageMainPath As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = ""
        DBConnection = "Provider=SQLOLEDB;Data Source=(local)\SQLEXPRESS;Initial Catalog=storefront2u_app;User ID=sa;Password="


        ImageMainPath = "Documents/" & WebLib.MerchantID & "/" & WebLib.ActionParamMMUID & "/"


        ActionType = "EMENU"
        PageDetail = ""
        PageListing = "emenulist.aspx"
        EnableDelete = False
        PageTitle = "eMenu Maintenance"
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


        If (pcode.Text & "").Trim = "" Then
            ShowAlert("Product Code is Mandatory")
            Return False
        End If

        If (pname.Text & "").Trim = "" Then
            ShowAlert("Product Name is Mandatory")
            Return False
        End If

        If (catid.SelectedValue = "") Then
            ShowAlert("Category is Mandatory")
            Return False
        End If
        If IsNumeric(catid.SelectedValue) = False Then
            ShowAlert("Category is Mandatory")
            Return False
        End If
        If WebLib.HasDuplicateData(DBConnection, DBTableName, "pcode", pcode.Text, "pp_uid", uid.Value, "custcode", WebLib.MerchantID) = True Then
            ShowAlert("Product Code is Taken, Please Re-Enter")
            Return False
        End If

        If IsNumeric(sprice1.Text) = False Then
            ShowAlert("Retail Price is Mandatory")
            Return False
        End If

        If IsNumeric(sprice2.Text) = False Then
            sprice2.Text = WebUtils.FormatDecimal2Digit("0")
        End If

        If IsNumeric(sprice3.Text) = False Then
            sprice3.Text = WebUtils.FormatDecimal2Digit("0")
        End If


        If IsNumeric(sprice4.Text) = False Then
            sprice4.Text = WebUtils.FormatDecimal2Digit("0")
        End If

        If IsNumeric(pp_qty.Text) = False Then
            pp_qty.Text = "0"
        End If

        If IsNumeric(weight.Text) = False And (weight.Text & "").Trim <> "" Then
            ShowAlert("Weight must be numeric")
            Return False
        End If


        If IsNumeric(v2_deliverydays.Text) = False And (v2_deliverydays.Text & "").Trim <> "" Then
            ShowAlert("Lead Time must be numeric")
            Return False
        End If
        Return True
    End Function
    Public Sub savedata()



    End Sub
    Public Function FileFieldSelected(ByVal FileField As System.Web.UI.HtmlControls.HtmlInputFile) As Boolean
        If FileField.PostedFile Is Nothing Then Return False
        If FileField.PostedFile.ContentLength = 0 Then Return False
        Return True
    End Function
    Protected Function LoadSQLfromCloud() As DataSet
        Dim cn As New OleDb.OleDbConnection(DBConnection)
        Dim cmd As New OleDb.OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim ltemp As String = ""


        Try
            cn.Open()

            cmd.CommandText = "Select * from " & "Products" & " where pp_uid='" & uid.Value & "'" ' and custcode='" & WebLib.MerchantID & "'"
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
    Public Sub uploadbuttong_click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim lUploadedFile As String

        PageTabSelection("tab2")
        If (uid.Value & "").Trim = "" Then

            ShowAlert("Please save record before uploading images")
            Exit Sub
        End If

        If Page.IsPostBack = True Then
            Dim str1 As String = UploadedFileG.PostedFile.FileName
            If FileFieldSelected(UploadedFileG) = False Then
                ShowAlert("No file selected or the file is 0 bytes")
                Exit Sub
            Else

                lUploadedFile = Server.MapPath(ImageMainPath & "/" & uid.Value)
                Dim lobjDB As New VIImageEngine.ImageControl
                lobjDB.folderpath = lUploadedFile
                If lobjDB.checkfolder("", False) = False Then
                    ShowAlert("Unable to Save File. Please Retry")
                    Exit Sub
                End If
                lobjDB = Nothing
                UploadedFileG.PostedFile.SaveAs(lUploadedFile & "\" & WebUtils.file_cleansname(RetrieveFileName(UploadedFileG)))
                If WebLib.GallerySave("PGALLERY", uid.Value, WebUtils.file_cleansname(RetrieveFileName(UploadedFileG)), ImageMainPath & "/" & uid.Value & "/", , False) = False Then
                    ShowAlert("Unable to Upload File. Please Retry")
                    Exit Sub
                Else
                    LoadGallery()
                End If
            End If
        End If
    End Sub
    Public Sub deletebutton_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If filename1.Value.Trim <> "" Then
            Try

                Try
                    If File.Exists(Server.MapPath(ImageMainPath & "thumb/1/") & filename1.Value) Then
                        Kill(Server.MapPath(ImageMainPath & "/thumb/1/") & filename1.Value)
                    End If
                Catch ex As Exception
                    ShowAlert("Unable to Delete File. Please Retry")
                    Exit Sub
                End Try
                Try
                    If File.Exists(Server.MapPath(ImageMainPath & "thumb/2/") & filename1.Value) Then
                        Kill(Server.MapPath(ImageMainPath & "/thumb/2/") & filename1.Value)
                    End If
                Catch ex As Exception
                    ShowAlert("Unable to Delete File. Please Retry")
                    Exit Sub
                End Try
                Try
                    If File.Exists(Server.MapPath(ImageMainPath & "") & filename1.Value) Then
                        Kill(Server.MapPath(ImageMainPath & "") & filename1.Value)
                    End If
                Catch ex As Exception
                    ShowAlert("Unable to Delete File. Please Retry")
                    Exit Sub
                End Try

                If WebUtils.ExecuteSQL("Update Products set FileName='" & "" & "' where pp_uid='" & uid.Value & "' and custcode='" & WebLib.MerchantID & "' and pro_mmuid='" & WebLib.ActionParamMMUID & "'", DBConnection) Then
                    filename1.Value = ""
                    showImage("")
                End If
                If WebLib.GalleryDelete("PMAIN", uid.Value, "") Then

                End If

            Catch ex As Exception
                ShowAlert("Unable to Delete File. Please Retry")
            End Try

        Else


        End If
        PageTabSelection("tab2")
    End Sub
    Public Sub videolink_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PageTabSelection("tab2")
        If (uid.Value & "").Trim = "" Then
            ShowAlert("Please save record saving media files")
            Exit Sub
        End If

        If Page.IsPostBack = True Then

            Try

                If WebUtils.ExecuteSQL("Update Products set pp_videolink='" & txtvideolink.text.Replace("'", "''") & "' where pp_uid='" & uid.Value & "' and custcode='" & WebLib.MerchantID & "' and pro_mmuid='" & WebLib.ActionParamMMUID & "'", DBConnection) Then
                    Call showvideo()
                End If


            Catch ex As SystemException
                ShowPromptV2("Error saving video embed link. Please retry", "")
                Exit Sub
            End Try

        End If


    End Sub
    Sub deletebuttong_click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        PageTabSelection("tab2")
        If (guuid.Value & "").Trim = "" Then
            Exit Sub
        End If


        Try

            If WebLib.GalleryFullDeleteByUID(guuid.Value, uid.Value, WebLib.MerchantID, WebLib.ActionParamMMUID) = False Then
                ShowAlert("Error Deletion. Please Retry")
                Exit Sub

            End If
            guuid.Value = ""
            Call LoadGallery()
        Catch ex As Exception
            Response.Write(ex.Message)
            Response.End()
        End Try


    End Sub
    Public Sub uploadbutton_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PageTabSelection("tab2")
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

            If FileFieldSelected(UploadedFile) = False Then
                ShowAlert("No file selected or the file is 0 bytes")
                Exit Sub
            Else

                Try

                    WebUtils.inituploads(Server.MapPath(lpath))
                    WebUtils.inituploads(Server.MapPath(lpath & "thumb/1/"))
                    WebUtils.inituploads(Server.MapPath(lpath & "thumb/2/"))

                    UploadedFile.PostedFile.SaveAs(Server.MapPath(lpath & RetrieveFileName(UploadedFile)))

                    If WebUtils.ExecuteSQL("Update Products set FileName='" & RetrieveFileName(UploadedFile) & "' where pp_uid='" & uid.Value & "' and custcode='" & WebLib.MerchantID & "' and pro_mmuid='" & WebLib.ActionParamMMUID & "'", DBConnection) Then

                        If WebLib.GallerySave("PMAIN", uid.Value, RetrieveFileName(UploadedFile), lpath) = False Then
                            ShowPromptV2("Product Upload Fail. Please Retry", "")
                            PageTabSelection("tab2")
                            Exit Sub
                        End If

                        Dim ooo As New Utilsthumb

                        Call ooo.createthumbnail(Server.MapPath(lpath), RetrieveFileName(UploadedFile), "1")
                        Call ooo.createthumbnail(Server.MapPath(lpath), RetrieveFileName(UploadedFile), "2")
                        Call showImage(RetrieveFileName(UploadedFile))
                        PageTabSelection("tab2")

                        ooo = Nothing

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

                Try

              
                    pname.Text = dr("pname") & ""
                    pcode.Text = dr("pcode") & ""
                    description.Text = dr("description") & ""

                    catid.Text = dr("catid") & ""
                    priority.Text = dr("priority") & ""
                    ranking.Text = dr("ranking") & ""
                    productcat3.Text = dr("productcat3") & ""

                    sprice1.Text = WebUtils.FormatDecimal2Digit(dr("sprice1") & "")
                    sprice2.Text = WebUtils.FormatDecimal2Digit(dr("sprice2") & "")
                    sprice3.Text = WebUtils.FormatDecimal2Digit(dr("sprice3") & "")
                    sprice4.Text = WebUtils.FormatDecimal2Digit(dr("sprice4") & "")

                    fvisible.Checked = WebUtils.AnythingToBoolean(dr("fvisible") & "")
                    ffeature.Checked = WebUtils.AnythingToBoolean(dr("ffeature") & "")
                    fnew.Checked = WebUtils.AnythingToBoolean(dr("fnew") & "")
                    fpromo.Checked = WebUtils.AnythingToBoolean(dr("fpromo") & "")
                    fsoldout.Checked = WebUtils.AnythingToBoolean(dr("fsoldout") & "")
                    fcomingsoon.Checked = WebUtils.AnythingToBoolean(dr("fcomingsoon") & "")
                    pp_fnondeliveryitem.Checked = WebUtils.AnythingToBoolean(dr("pp_fnondeliveryitem") & "")
                    pp_fallowselfpickup.Checked = WebUtils.AnythingToBoolean(dr("pp_fallowselfpickup") & "")

                    chkactive.Checked = WebUtils.BitToBoolean(dr("pp_valid") & "")

                    weight.Text = WebUtils.FormatDecimal2Digit(dr("weight") & "")

                    v2_deliverydays.Text = dr("v2_deliverydays") & ""
                    v2_packagingdesc.Text = dr("v2_packagingdesc") & ""

                    filename1.Value = (dr("FileName") & "").trim()

                    txtvideolink.Text = (dr("pp_videolink") & "").trim()

                    pp_qtyc.Text = (dr("pp_qtyc") & "").trim()
                    pp_qty.Text = (dr("pp_qty") & "").trim()

                    descriptionadd.Text = dr("DescriptionAdd") & ""

                    showImage(filename1.Value)
                    showvideo()
                    LoadGallery()
                    Exit For
                Catch ex As Exception
                    Response.Write(WebUtils.GetErrorMessage(ex.message))
                    Response.End()
                End Try

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

    Public Function RetrieveFileName(ByVal FileField As System.Web.UI.HtmlControls.HtmlInputFile) As String
        If Not FileField.PostedFile Is Nothing Then

            Try

                Return Replace(FileField.PostedFile.FileName, StrReverse(Mid(StrReverse(FileField.PostedFile.FileName), InStr(1, StrReverse(FileField.PostedFile.FileName), "\"))), "")

            Catch
                Return FileField.PostedFile.FileName
            End Try

        Else
            Return ""
        End If

    End Function
    Public Sub showImage(ByVal ImageName As String)



        If ImageName.Trim = "" Then
            litpreview.Text = ""
        Else
            litpreview.Text = "<img src=""" & ImageMainPath & "thumb/1/" & ImageName & """ height=""100%"" />"
            '            litpreview.Text = "<img src=""" & ImageMainPath & "/thumb/1/" & ImageName & """ width=""100%"" />"
        End If

        filename1.Value = ImageName

        If filename1.Value.Trim <> "" Then
            uploadbutton.Visible = False
            deletebutton.Visible = True
        Else
            uploadbutton.Visible = True
            deletebutton.Visible = False

        End If

    End Sub
    Protected Sub LoadGallery()
        Dim cn As New OleDbConnection(DBConnection)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim sb As New StringBuilder

        btngdelete.Visible = False
        Try
            cn.Open()
            cmd.CommandText = "Select * from Image_gallery where ig_type like 'PGALLERY%' and ig_puid='" & uid.Value & "' and ig_merchantid='" & WebLib.MerchantID & "' and ig_mmuid='" & WebLib.ActionParamMMUID & "'"
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows
                counter = counter + 1


                sb.Append("<div class=""row"">")

                sb.Append("<div class=""col s6 m6""><img src=""" & dr("ig_filepath") & dr("ig_filename") & """ class=""materialboxed responsive-img"" /></div>")
                sb.Append("<div class=""col s6 m6""><label><input class=""with-gap"" name=""gallery" & dr("ig_puid") & """ id=""chk" & dr("ig_uid") & """ type=""radio"" onclick=""javascript:_deleteGallery('" & dr("ig_uid") & "');"" /><span style=""font-size:1em;color:Black;"">" & "" & "</span></label></div>")
                sb.Append("</div>")
            Next

            cn.Close()
            cmd.Dispose()
            cn.Dispose()

            litg.Text = sb.ToString


            If counter > 0 Then
                btngdelete.Visible = True
            End If


        Catch ex As Exception


        End Try




    End Sub
    Public Sub showvideo()
        lityoutube.Text = WebUtils.EmbedYoutube(txtvideolink.text)
    End Sub

End Class

