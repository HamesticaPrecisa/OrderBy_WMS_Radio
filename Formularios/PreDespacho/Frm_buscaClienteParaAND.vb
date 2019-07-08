Public Class Frm_buscaClienteParaAND

    Public cliente As String = ""
    Public nombrecliente As String = ""
    Public folio As String = ""
    Dim fnc As New Funciones

    Private Sub Frm_buscaClienteParaAND_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT cl_rutcli, cli_nomb,cho_nombre,cl_chorut,cl_fol,Anden FROM VG_ANDENES_GRILLA"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        DataGrid1.DataSource = tabla

        For i As Integer = 0 To tabla.Rows.Count - 1


            If tabla.Rows(i)(4).ToString() <> "null" Then

                DataGrid1.BackColor = Color.Green
                DataGrid1.ForeColor = Color.White

                '      MsgBox("paso ")

                'tabla.Rows(1).Cells(0).Style.BackColor = Color.Red
            End If

        Next
    End Sub

    Private Sub DataGrid1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.CurrentCellChanged
        cliente = CStr(DataGrid1(DataGrid1.CurrentCell.RowNumber, 0))
        nombrecliente = CStr(DataGrid1(DataGrid1.CurrentCell.RowNumber, 1))
        folio = CStr(DataGrid1(DataGrid1.CurrentCell.RowNumber, 4))
        btn_ok.Visible = True
    End Sub

    Private Sub Btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ok.Click
        Me.Close()
    End Sub

    Private Sub txtbusca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbusca.TextChanged
        Dim sql As String = "SELECT cl_rutcli, cli_nomb,cho_nombre,cl_chorut,cl_fol,Anden FROM VG_ANDENES_GRILLA WHERE cli_nomb LIKE '%" + txtbusca.Text + "%'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        DataGrid1.DataSource = tabla
    End Sub
End Class