Imports System
Imports System.Data
Imports System.IO

Public Class WebSearchMemberPointEnquiry

    Private _filter As String
    Public Property filter() As String
        Get
            Return _filter
        End Get
        Set(value As String)
            _filter = value
        End Set
    End Property

    Public Function MemberName(ByVal theValue As String, Optional ByVal SearchAccuracy As Integer = 1) As String

        If (SearchAccuracy = 1) Then
            Return "ml_Name like '%" + theValue.Replace("'", "''") + "%'"
        End If

        Return "ml_Name = '" + theValue.Replace("'", "''") + "'"
    End Function

    Public Function MemberType(ByVal theValue As String, Optional ByVal SearchAccuracy As Integer = 1) As String

        If (SearchAccuracy = 1) Then
            Return "ml_membertype like '%" + theValue.Replace("'", "''") + "%'"
        End If

        Return "ml_membertype = '" + theValue.Replace("'", "''") + "'"
    End Function

    Public Function MemberPhoneNo(ByVal theValue As String, Optional ByVal SearchAccuracy As Integer = 1) As String

        If (SearchAccuracy = 1) Then
            Return "ml_hpno like '%" + theValue.Replace("'", "''") + "%'"
        End If

        Return "ml_hpno = '" + theValue.Replace("'", "''") + "'"
    End Function

    Public Function MemberEmail(ByVal theValue As String, Optional ByVal SearchAccuracy As Integer = 1) As String

        If (SearchAccuracy = 1) Then
            Return "ml_email like '%" + theValue.Replace("'", "''") + "%'"
        End If

        Return "ml_email = '" + theValue.Replace("'", "''") + "'"
    End Function

    Public Sub LogtheAudit(ByVal theMessage As String)
        Dim strFile As String = "c:\officeonelog\ErrorLogCRM.txt"
        Dim fileExists As Boolean = File.Exists(strFile)

        Try

            Using sw As New StreamWriter(File.Open(strFile, FileMode.Append))
                sw.WriteLine(DateTime.Now & " - " & theMessage)
            End Using
        Catch ex As Exception

        End Try

    End Sub

End Class