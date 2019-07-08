Imports System.Data.SqlClient
Imports System.Data

Public Class Conexion2

    Public conSQL As New SqlConnection
    Sub conectarSQL()
        If conSQL.State = 0 Then
            Try
                conSQL.ConnectionString = ("Data Source=192.168.1.90\PRECISABD; Initial Catalog=PRECISA_TRAKEO; User ID=sa; Password=precisa;")
                conSQL.Open()
            Catch ex As Exception
                MsgBox(ex.Message())
            End Try
        End If
    End Sub

    Sub cerrarSQL()
        conSQL.Close()
    End Sub
End Class
