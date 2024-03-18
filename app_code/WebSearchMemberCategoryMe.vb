Imports System
Imports System.Data
Imports System.IO

Public Class WebSearchMemberCategoryMe

    Private _filter As String
    Public Property filter() As String
        Get
            Return _filter
        End Get
        Set(value As String)
            _filter = value
        End Set
    End Property

    Public Function Category(ByVal theValue As String, Optional ByVal SearchAccuracy As Integer = 1) As String

        If (SearchAccuracy = 1) Then
            Return "cc_name like '%" + theValue.Replace("'", "''") + "%'"
        End If

        Return "cc_name = '" + theValue.Replace("'", "''") + "'"
    End Function

    Public Function DiscountRate(ByVal theValue As String, Optional ByVal SearchAccuracy As Integer = 1) As String

        If (SearchAccuracy = 1) Then
            Return "ldc_discount like '%" + theValue.Replace("'", "''") + "%'"
        End If

        Return "ldc_discount = '" + theValue.Replace("'", "''") + "'"
    End Function

    Public Function SpendingFrom(ByVal theValue As String, Optional ByVal SearchAccuracy As Integer = 1) As String

        If (SearchAccuracy = 1) Then
            Return "ldc_from >= " + theValue.Replace("'", "''") + ""
        End If

        Return "ldc_from = " + theValue.Replace("'", "''") + ""
    End Function

    Public Function SpendingTo(ByVal theValue As String, Optional ByVal SearchAccuracy As Integer = 1) As String

        If (SearchAccuracy = 1) Then
            Return "ldc_to <= " + theValue.Replace("'", "''") + ""
        End If

        Return "ldc_to = " + theValue.Replace("'", "''") + ""
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