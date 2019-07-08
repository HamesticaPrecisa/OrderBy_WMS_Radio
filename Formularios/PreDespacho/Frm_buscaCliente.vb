Public Class Frm_buscaCliente

    Public cliente As String = ""
    Public nombrecliente As String = ""
    Dim fnc As New Funciones

    Private Sub Frm_buscaCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT cli_rut, cli_nomb FROM clientes "
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        DataGrid1.DataSource = tabla
    End Sub

    Private Sub DataGrid1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.CurrentCellChanged
        cliente = CStr(DataGrid1(DataGrid1.CurrentCell.RowNumber, 0))
        nombrecliente = CStr(DataGrid1(DataGrid1.CurrentCell.RowNumber, 1))
        btn_ok.Visible = True
    End Sub

    Private Sub Btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ok.Click
        Me.Close()
    End Sub

    Private Sub txtbusca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbusca.TextChanged
        Dim sql As String = "SELECT cli_rut, cli_nomb FROM clientes WHERE cli_nomb LIKE '%" + txtbusca.Text + "%'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        DataGrid1.DataSource = tabla
    End Sub
End Class