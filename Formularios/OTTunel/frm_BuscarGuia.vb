' VES Sep 2019
Public Class frm_BuscarGuia

    Dim fnc As Funciones = New Funciones()
    Public frec_guiades As String = ""
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
        frec_guiades = CStr(DataGrid1(DataGrid1.CurrentCell.RowNumber, 0))
        cli_nomb = CStr(DataGrid1(DataGrid1.CurrentCell.RowNumber, 1))
        frec_unica = DataGrid1(DataGrid1.CurrentCell.RowNumber, 2)
        btn_ok.Visible = True
    End Sub

    Private Function buscarGuias(ByVal pista As String) As DataTable
        Dim sql As String = "SELECT frec_guiades, frec_fecrec, cli_nomb, frec_unica" & _
                            "  FROM fichrece " & _
                            "  LEFT JOIN clientes ON cli_rut = frec_rutcli"
        If pista.Length > 0 Then
            sql = sql + " WHERE frec_guiades LIKE '%" + pista + "%' " & _
                        "    OR cli_nomb LIKE '%" + pista + "%'"
        End If
        Dim result As DataTable = fnc.ListarTablasSQL(sql)
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