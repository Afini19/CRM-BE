Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Partial Public Class imageuploader_class
    Inherits System.Web.UI.UserControl
    Protected _Width As String = "100px"
    Protected _Height As String = "120px"
    Protected _ImgWidth As String = "300px"
    Protected _ImgHeight As String = "300px"
    Protected lMaxFileSize As Long = 4096
    Protected _FileName As String = ""
    Public lblformnamespace, lblAppcode, lbluploadstatus, flddoc1, lblfilename, ltimage, btnupload, btndelete As Object

    Public Property ImgWidth() As String
        Get
            Return _ImgWidth
        End Get
        Set(ByVal value As String)
            _ImgWidth = value
            '            flddoc1.Width = _Width
        End Set
    End Property
    Public Property AllatOnceMode() As Boolean
        Get
            Return btnupload.visible
        End Get
        Set(ByVal value As Boolean)
            btnupload.visible = Not value
        End Set
    End Property

    Public Property Preview() As Boolean
        Get
            Return ltImage.visible
        End Get
        Set(ByVal value As Boolean)
            ltImage.visible = value
        End Set
    End Property

    Public Property ImgHeight() As String
        Get
            Return _ImgHeight
        End Get
        Set(ByVal value As String)
            _ImgHeight = value
            '            flddoc1.Width = _Width
        End Set
    End Property
    Public Property Width() As String
        Get
            Return _Width
        End Get
        Set(ByVal value As String)
            _Width = value
            '            flddoc1.Width = _Width
        End Set
    End Property
    Public Property FormNamespace() As String
        Get
            Return lblformnamespace.text
        End Get
        Set(ByVal value As String)
            lblformnamespace.text = value
        End Set
    End Property
    Public Property AppCode() As String
        Get
            Return lblAppcode.text
        End Get
        Set(ByVal value As String)
            lblAppcode.text = value
        End Set
    End Property
    Public Property Height() As String
        Get
            Return _Height
        End Get
        Set(ByVal value As String)
            _Height = value
            'flddoc1.Height = _Height
        End Set
    End Property

    Public Property text() As String
        Get
            Return lblfilename.text
        End Get
        Set(ByVal value As String)
            _FileName = value
            Call activatefile(_FileName)
            '            flddoc1.FileName = value
        End Set
    End Property
    Public Property FilePathHttp() As String
        Get
            If Filename.trim <> "" Then
                Return getPath(True)
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)

        End Set
    End Property
    Public Property FileName() As String
        Get
            Return lblfilename.text
        End Get
        Set(ByVal value As String)
            _FileName = value
            Call activatefile(_FileName)
            '            flddoc1.FileName = value
        End Set
    End Property
    Private Function getPath(Optional ByVal pForHttp As Boolean = False) As String
        If AppCode.Trim = "" Then
            lbluploadstatus.text = "Application not defined"
            Return ""
        End If

        If FormNamespace.Trim = "" Then
            lbluploadstatus.text = "Namespace not defined"
            Return ""
        End If
        If Weblib.MerchantID.Trim = "" Then
            lbluploadstatus.text = "Merchant ID"
            Return ""
        End If

        If (System.Configuration.ConfigurationSettings.AppSettings("filespath") & "").Trim = "" Then
            lbluploadstatus.text = "Document storage not defined"
            Return ""
        End If


        If pForHttp = False Then
            Return System.Configuration.ConfigurationSettings.AppSettings("filespath") & "\" & Weblib.MerchantID & "\" & AppCode & "\" & FormNamespace & "\"

        Else
            Return WebLib.ClientURL(System.Configuration.ConfigurationSettings.AppSettings("filespathhttp") & WebLib.MerchantID & "/" & AppCode & "/" & FormNamespace & "/")

        End If


    End Function
    Private Sub UploadFile()
        Dim counter As Integer = 0
        Dim ldocno As String = ""
        Dim strpath As String = getPath()
        Dim fileExt As String = ""
        Dim lfilename As String = ""
        Dim sSQL As String = ""
        lbluploadstatus.text = ""


        If strpath.Trim = "" Then Exit Sub


        If (flddoc1.HasFile) = True Then


            Select Case Path.GetExtension(flddoc1.PostedFile.FileName).ToLower()
                Case ".png"

                Case ".jpg"

                Case ".gif"

                Case Else
                    lbluploadstatus.text = "Please upload a proper image format"
                    Exit Sub
            End Select

            '          If Path.GetExtension(flddoc1.PostedFile.FileName).ToLower() <> ".pdf" Then
            'lbluploadstatus.text = "Please upload format in .pdf"
            'Exit Sub
            '        End If
        Else
            lbluploadstatus.text = "Please upload a document"
            Exit Sub
        End If
        Try

            If (flddoc1.HasFile) Then
                '                strpath = System.Configuration.ConfigurationSettings.AppSettings("filespath")
                fileExt = System.IO.Path.GetExtension(flddoc1.FileName)
                lfilename = flddoc1.FileName  '"text" & fileExt
                lfilename = WebLib.getUniqueKey() & fileExt

                If Directory.Exists(strpath) = False Then
                    Directory.CreateDirectory(strpath)


                End If

                '                If flddoc1.PostedFile.ContentLength <= lMaxFileSize Then

                    flddoc1.PostedFile.SaveAs(strpath + lfilename)
                '               Else
                'lbluploadstatus.text = "File Size Over Limit. Max File Size 4Mb"
                'Exit Sub

                '                End If

            End If
            Call activatefile(lfilename)

        Catch Err As Exception
            lbluploadstatus.text = Err.Message
        Finally

        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Page.IsPostBack = True Then
            If (flddoc1.HasFile) = True Then
                '                Call uploadfile()
            End If
        Else
            Call activatefile(FileName)

            '            btnupload.visible = False
        End If

    End Sub
    Public Sub uc_file1_click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Call uploadfile()
    End Sub
    Public Sub DeleteDoc(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim counter As Integer = 0
        Dim ldocno As String = ""
        Dim strpath As String = getPath()
        Dim fileExt As String = ""
        Dim lfilename As String = ""
        Dim sSQL As String = ""

        If strpath.Trim = "" Then Exit Sub

        lbluploadstatus.text = ""
        lfilename = FileName


        '        strpath = System.Configuration.ConfigurationSettings.AppSettings("filespath")

        Try


            If lfilename <> "" Then
                If File.Exists(strpath + lfilename) = True Then
                    File.Delete(strpath + lfilename)
                    lbluploadstatus.text = "File Deleted"
                    Call activatefile("")
                Else
                    lbluploadstatus.text = "File cannot be found "
                    Call activatefile("")
                End If

            Else
                lbluploadstatus.text = "No File Exists"
            End If

        Catch Err As Exception

            lbluploadstatus.text = Err.Message

        Finally

        End Try
    End Sub
    Private Sub activatefile(ByVal _p_FileName As String)
        ltimage.text = ""

        If (_p_FileName & "").Trim = "" Then
            lblfilename.text = ""
            btndelete.visible = False

            '            If AllatOnceMode = False Then
            btnupload.visible = True
            '        Else
            '           btnupload.visible = False

            '        End If

        flddoc1.visible = True
        ltimage.text = "<div style=""overflow:hidden;height:" & Height & ";width:" & Width & """><img src=""" & Weblib.DefaultBlankPng & """ width=""" & Width & """ height=""" & Height & """></div>"

        Else
        lblfilename.text = "" & _p_FileName & ""
        btndelete.visible = True
        btnupload.visible = False
        flddoc1.visible = False
        If Preview = True Then

            Dim strpath As String = FilePathHttp
            If strpath.Trim <> "" Then
                'ltimage.Text = "<div style=""overflow:hidden;height:" & Height & ";width:" & Width & """><img src=""" & strpath & lblfilename.Text & """ width=""" & Width & """></div>"
                ltimage.Text = "<div style=""overflow:hidden;height:" & Height & ";width:" & Width & """><img src=""" & strpath & lblfilename.Text & """ height=""" & Height & """></div>"

            Else
                'ltimage.Text = "<div style=""overflow:hidden;height:" & Height & ";width:" & Width & """><img src=""" & WebLib.DefaultBlankPng & """ width=""" & Width & """ height=""" & Height & """></div>"
                ltimage.Text = "<div style=""overflow:hidden;height:" & Height & ";width:" & Width & """><img src=""" & WebLib.DefaultBlankPng & """ height=""" & Height & """></div>"

            End If
        End If
        End If
    End Sub

End Class

