Imports System.Data.SqlClient

' VES Sep 2019
' Contiene el resultado de una llamada a runSqlCmd
'
Public Class sqlCmdResult
    Public result As Boolean = False
    Public data As DataTable

    Private _errorMsg As String
    Public Property errorMsg() As String
        Get
            Return _errorMsg
        End Get
        Set(ByVal value As String)
            _errorMsg = value
            lastSqlError = value
        End Set
    End Property
End Class
