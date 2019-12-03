Imports System.Data.SqlClient
Imports System.Data.SqlServerCe


Public Class frm_ejemplo

    Dim fnc As New Funciones

    Public conSQL As New SqlConnection


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If conSQL.State = 0 Then
            Try
                conSQL.ConnectionString = TextBox1.Text '"Data Source=192.168.1.90\PRECISABD; Initial Catalog=PRECISA; Uid=sa; PWD=precisa; "
                'conSQL.ConnectionString = "Data Source=192.168.1.7\PRECISA; initial catalog=precisa; Uid=sa; PWD=precisa; Integrated Security = false;"
                conSQL.Open()
                MsgBox("Conecto")
            Catch ex As SqlException
                MsgBox("menssaje" + ex.Errors(0).Message _
                       & vbCrLf & " Nº Error :" & ex.Errors(0).Number _
                       & vbCrLf & " Nº Procedure :" & ex.Errors(0).Procedure)
            End Try
        End If

        Dim sql As String = "SELECT TOP (10) cl_fol FROM zchecklist"

        Dim dt As DataTable = fnc.ListarTablasSQL(sql)

        For i As Integer = 0 To dt.Rows.Count - 1
            TextBox2.Text += dt.Rows(i)(0).ToString() + vbNewLine
        Next
    
    End Sub
End Class