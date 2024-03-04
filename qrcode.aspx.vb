Imports System.Data
Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Web.UI
Partial Class qrcode
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If (request("c") & "").trim = "" Then
            Exit Sub
        End If

        Dim obj As New WebQr
        Dim img As System.Drawing.Image = obj.getqrcode(Request("c"))


        Dim stream = New MemoryStream()
        img.Save(stream, System.Drawing.Imaging.ImageFormat.Png)
        Dim byteArray As Byte() = stream.ToArray()
        stream.Flush()
        stream.Close()
        Response.Clear()
        Response.AddHeader("Content-Length", byteArray.Length.ToString())
        Response.ContentType = "image/png"
        Response.BinaryWrite(byteArray)
        Response.End()


        Exit Sub
    End Sub
End Class
