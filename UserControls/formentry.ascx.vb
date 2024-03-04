Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Partial Public Class formentry_class
    Inherits System.Web.UI.UserControl
    Protected Friend _Required As Boolean = False
    Protected Friend ariarequired As String = "false"
    Protected Friend entrytype As String = "text"
    Protected Friend _Height As String = ""
    Protected Friend _Lookup As String = ""
    Protected Friend _LookupAssign As String = ""

    Public WriteOnly Property FieldType() As String
        Set(ByVal value As String)
            entrytype = value
            SetType()
        End Set
    End Property
    Private Sub SetType()
        If entrytype = "date" Then
            axvalue.Attributes.Add("type", "text".ToString.ToLower)
            axvalue.Attributes.Add("class", "datepicker")
        Else
            axvalue.Attributes.Add("type", entrytype.ToString.ToLower)
        End If
    End Sub
    Public WriteOnly Property Lookup() As String
        Set(ByVal value As String)
            _Lookup = value
        End Set
    End Property
    Public WriteOnly Property LookupAssign() As String
        Set(ByVal value As String)
            _LookupAssign = value
        End Set
    End Property
    Public Function MyClientID() As String
        Return axvalue.clientid
    End Function
    Public Function MyClientIDHidden() As String
        Return axvaluehidden.clientid
    End Function
    Private Sub GetMyScript()
        Dim sb As New StringBuilder
        sb.Append("<script language=""javascript"">")
        sb.Append("document.getElementById('" & axvalue.ClientID & "').onkeypress = function(e){")
        sb.Append("if (!e) e = window.event;")
        sb.Append("var keyCode = e.code || e.key;")
        sb.Append("if (keyCode == 'Enter'){")
        sb.Append(GetLookupScript())
        sb.Append("}")
        sb.Append("}")
        sb.Append(Environment.NewLine)
        sb.Append("$(""#" & axvalue.ClientID & """).blur(function() {")
        sb.Append("if (($('#" & axvalue.ClientID & "').val() != $('#" & axvalueorg.ClientID & "').val()) && ($('#" & axvalue.ClientID & "').val().length > 0)){" & Environment.NewLine)
        sb.Append("$('#" & axvalue.ClientID & "').val($('#" & axvalueorg.ClientID & "').val());" & Environment.NewLine)
        sb.Append("} else ")
        sb.Append("{")
        sb.Append("if ($('#" & axvalue.ClientID & "').val().length == 0){$('#" & axvalueorg.ClientID & "').val('');}")
        sb.Append("}")
        sb.Append("});")
        sb.Append("</script>")

        Dim ooo As New LookupUtils
        sb.Append(ooo.GetLookup(_Lookup, Me.ID, axvalueorg.ClientID & "!!1;;" & MyClientID() & "!!1" & _LookupAssign))
        ooo = Nothing

        myscripts.Text = sb.ToString()
    End Sub
    Private Function GetLookupScript() As String
        Return "$('#txtsearch-" + Me.ID + "').val($('#" + axvalue.ClientID + "').val());$('#searchbox-" + Me.ID + "').modal('open', {dismissible : false});"
    End Function

    Public Property Caption() As String
        Get
            Return litcaption.Text

        End Get
        Set(ByVal value As String)
            litcaption.Text = value
        End Set
    End Property
    Public Property UID() As String
        Get
            '            Return qid.Value
            Return ""

        End Get
        Set(ByVal value As String)
            '           qid.Value = value
        End Set
    End Property
    Public Property Enabled() As Boolean
        Get
            Return axvalue.Enabled

        End Get
        Set(ByVal value As Boolean)
            axvalue.Enabled = value
            entryicon.Text = ""

            If value = False Then
                axvalue.BackColor = System.Drawing.Color.LavenderBlush
            End If

        End Set
    End Property
    Public WriteOnly Property Required() As Boolean
        Set(ByVal value As Boolean)

            If value = True Then
                axvalue.Attributes.Add("aria-required", value.ToString.ToLower)
                axvalue.Attributes.Add("required", "")
            End If
            If value = True Then
                litrequired.Text = "<span style=""color:red"">*</span>"
            End If

        End Set
    End Property
    Public Property Text() As String
        Get
            Return axvalue.Text
        End Get
        Set(ByVal value As String)

            axvalue.Text = value

            If _Lookup.Trim <> "" Then
                axvalueorg.value = value
            End If
        End Set
    End Property
    Public Property TextHidden() As String
        Get
            Return axvaluehidden.value
        End Get
        Set(ByVal value As String)
            axvaluehidden.value = value
        End Set
    End Property
    Public Property cssclass() As String
        Get
            Return axvalue.CssClass
        End Get
        Set(ByVal value As String)
            axvalue.CssClass = value
        End Set
    End Property
    Public Property Multiline() As Boolean
        Get
            If axvalue.TextMode = TextBoxMode.MultiLine Then
                Return True
            Else
                Return False
            End If

        End Get
        Set(ByVal value As Boolean)
            If value = True Then
                axvalue.TextMode = TextBoxMode.MultiLine
            Else
                axvalue.TextMode = TextBoxMode.SingleLine
            End If
        End Set
    End Property
    Public Property Height() As String
        Get
            Return _Height
        End Get
        Set(ByVal value As String)
            _Height = value
            If _Height.Trim <> "" Then
                axvalue.Style.Remove("height")
                axvalue.Style.Add("height", _Height)

            End If

        End Set
    End Property
    Protected Overrides Sub OnPreRender(ByVal e As System.EventArgs)
        MyBase.OnPreRender(e)


        If (_Lookup & "").Trim <> "" And Enabled <> False Then
            entryicon.Text = "<i class=""material-icons black-text right clickable"" onclick=""" & GetLookupScript() & """>search</i>"
            Call GetMyScript()
        End If

    End Sub
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub
End Class

