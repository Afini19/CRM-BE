Imports System
Imports System.Data
Imports System.IO

Public Class WebSearchVoucher

    Private _filter As String
    Public Property filter() As String
        Get
            Return _filter
        End Get
        Set(value As String)
            _filter = value
        End Set
    End Property

    Public Function VoucherCode(ByVal theValue As String, Optional ByVal SearchAccuracy As Integer = 1) As String

        If (SearchAccuracy = 1) Then
            Return "vo_code like '%" + theValue.Replace("'", "''") + "%'"
        End If

        Return "vo_code = '" + theValue.Replace("'", "''") + "'"
    End Function

    Public Function VoucherName(ByVal theValue As String, Optional ByVal SearchAccuracy As Integer = 1) As String

        If (SearchAccuracy = 1) Then
            Return "vo_name like '%" + theValue.Replace("'", "''") + "%'"
        End If

        Return "vo_name = '" + theValue.Replace("'", "''") + "'"
    End Function

    Public Function VoucherType(ByVal theValue As String, Optional ByVal SearchAccuracy As Integer = 1) As String

        If (SearchAccuracy = 1) Then
            Return "vo_type like '%" + theValue.Replace("'", "''") + "%'"
        End If

        Return "vo_type = '" + theValue.Replace("'", "''") + "'"
    End Function

    Public Function Value(ByVal theValue As String, Optional ByVal SearchAccuracy As Integer = 1) As String

        If (SearchAccuracy = 1) Then
            Return "vo_amt like '%" + theValue.Replace("'", "''") + "%'"
        End If

        Return "vo_amt = '" + theValue.Replace("'", "''") + "'"
    End Function

    Public Function CreateDate(ByVal theDatainYYYYMMDD As String, ByVal theValue As String, Optional ByVal SearchAccuracy As Integer = 1, Optional ByVal OverrideOperator As String = "")

        If (String.Compare(OverrideOperator.Trim(), "", False) <> 0) Then
            Return (" datediff(d,'" + theDatainYYYYMMDD + "',vo_createdt) " + OverrideOperator + " " + theValue.Replace("'", "''")) + ""
        End If

        Return (" datediff(d,'" + theDatainYYYYMMDD + "',vo_createdt) = " + theValue.Replace("'", "''")) + ""

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