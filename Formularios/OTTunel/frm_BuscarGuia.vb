' VES Sep 2019
Imports System.Data.SqlClient

Public Class frm_BuscarGuia

    Dim fnc As Funciones = New Funciones()
    Public frec_guiades As String = ""
    Public frec_codi As String = ""
    Public cli_nomb As String = ""
    Public frec_unica As Object

    Private Sub frm_BuscarGuia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGrid1.DataSource = buscarGuias()
    End Sub

    Private Sub txtbusca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbusca.TextChanged
        Dim pista As String = txtbusca.Text.Trim()
        If pista.Length >= 3 Then
            DataGrid1.DataSource = buscarGuias(pista)
        End If
    End Sub

    Private Sub Btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_salir.Click
        Me.Close()
    End Sub
    Private Sub btn_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ok.Click
        Me.Close()
    End Sub


    Private Sub DataGrid1_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.CurrentCellChanged
        frec_codi = CStr(DataGrid1(DataGrid1.CurrentCell.RowNumber, 0))
        cli_nomb = CStr(DataGrid1(DataGrid1.CurrentCell.RowNumber, 2))
        frec_guiades = CStr(DataGrid1(DataGrid1.CurrentCell.RowNumber, 3))
        frec_unica = DataGrid1(DataGrid1.CurrentCell.RowNumber, 4)
        btn_ok.Visible = True
    End Sub

    Private Function buscarGuias(ByVal pista As String) As DataTable
        Dim sql As String = "SELECT frec_codi, hpt, cli_nomb, frec_guiades, frec_unica" & _
                            "  FROM vwGuiasPendTunel " & _
                            " ORDER BY hpt"

        If pista.Length > 0 Then
            sql = sql + " AND (frec_guiades LIKE @pista OR frec_codi LIKE %pista OR cli_nomb LIKE @pista)"
        End If
        Dim result As DataTable = fnc.ListarTablasSQL(sql, New SqlParameter() {New SqlParameter("@pista", "%" & pista & "%")})
        If lastSQLError IsNot Nothing Then
            MessageBox.Show(lastSQLError, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Me.Close()
            Return result
        End If
        Return result
    End Function
    Private Function buscarGuias() As DataTable
        Return buscarGuias("")
    End Function
End Class