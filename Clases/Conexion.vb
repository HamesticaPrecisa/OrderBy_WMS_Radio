Imports System.Data.SqlClient
Imports System.Data

Public Class Conexion
    Dim intentos As Integer = 0
    Public conSQL As New SqlConnection
    Public conSQLEtiquetado As New SqlConnection

    Sub conectarSQL()
        If conSQL.State = 0 Then
            Try
                conSQL.ConnectionString = "Data Source=192.168.1.90\PRECISABD; Initial Catalog=PRECISA; Uid=sa; PWD=precisa; "
                'conSQL.ConnectionString = "Data Source=192.168.1.90\PRECISABD; Initial Catalog=Precisa_Backup; Uid=sa; PWD=precisa; "
                conSQL.Open()
                intentos = 0
            Catch ex As SqlException
                intentos = intentos + 1

                If intentos = 5 Then
                    If MsgBox("Se perdio la conexión quiere volver a intentar conectarse?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = MsgBoxResult.Yes Then
                        conectarSQL()
                    Else
                        Application.Exit()
                    End If
                Else
                    conectarSQL()
                End If
            End Try

        End If
    End Sub


    Sub cerrarSQL()
        conSQL.Close()
    End Sub

    Sub conectarSQLEtiquetado()
        If conSQLEtiquetado.State = 0 Then
            Try
                conSQLEtiquetado.ConnectionString = "Data Source=192.168.1.90\PRECISABD; Initial Catalog=Etiquetado; Uid=sa; PWD=precisa; "
                conSQLEtiquetado.Open()
            Catch ex As SqlException
                MsgBox("menssaje" + ex.Errors(0).Message _
                       & vbCrLf & " Nº Error :" & ex.Errors(0).Number _
                       & vbCrLf & " Nº Procedure :" & ex.Errors(0).Procedure)
            End Try
        End If
    End Sub

    Sub cerrarSQLEtiquetado()
        conSQLEtiquetado.Close()
    End Sub
End Class
