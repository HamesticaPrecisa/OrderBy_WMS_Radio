Public Class Lst_AyudaSoportantes
    Dim fnc As New Funciones
    Dim sqlListar As String
    Dim tablaListar As DataTable
    Dim buscar As String
    Public IdPrincipalsop As String
    Public NombrePrincipalsop As String
    Public resultadosop As String
    Public filtro As String
    Private Sub btn_cerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub dtg_listado_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub btn_seleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub txt_buscar_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

    End Sub

    Private Sub txt_buscar_KeyPress_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_buscar.KeyPress
        listar()
    End Sub
    Private Sub listar()

        buscar = txt_buscar.Text.Trim

        If buscar <> "" Then
            sqlListar = " SELECT  tsop_codi,tsop_descr FROM tiposopo " & _
                        " WHERE (tsop_codi LIKE '%" + buscar + "%' OR tsop_descr LIKE '%" + buscar + "%') "
        Else
            sqlListar = " SELECT  tsop_codi,tsop_descr FROM tiposopo "
        End If

        dtg_listado.DataSource = Nothing
        tablaListar = fnc.ListarTablasSQL(sqlListar)
        dtg_listado.DataSource = tablaListar

    End Sub

    Private Sub dtg_listado_CurrentCellChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtg_listado.CurrentCellChanged
        IdPrincipalsop = CStr(dtg_listado(dtg_listado.CurrentCell.RowNumber, 0))
        NombrePrincipalsop = CStr(dtg_listado(dtg_listado.CurrentCell.RowNumber, 1))
        btn_seleccionar.Enabled = True
    End Sub

    Private Sub btn_seleccionar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_seleccionar.Click
        resultadosop = "OK"
        Me.Close()
    End Sub

    Private Sub btn_cerrar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cerrar.Click
        resultadosop = "NO"
        Me.Close()
    End Sub

    Private Sub Lst_AyudaSoportantes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        listar()
    End Sub

End Class