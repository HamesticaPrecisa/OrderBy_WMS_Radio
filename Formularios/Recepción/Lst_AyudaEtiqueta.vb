Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Data

Public Class Lst_AyudaEtiqueta

    Dim fnc As New Funciones
    Dim sqlListar As String
    Dim tablaListar As DataTable
    Dim buscar As String
    Public IdPrincipal As String
    Public NombrePrincipal As String
    Public resultado As String
    Public filtro As String

    Private Sub Lst_AyudaEtiqueta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        listar()
    End Sub

    'FUNCIONES OPERATIVAS DEL USUARIO'
    Private Sub listar()

        buscar = txt_buscar.Text.Trim

        If buscar <> "" Then
            sqlListar = " SELECT etiq_id, LEN(etiq_muestra) AS etiq_largo, etiq_descripcion FROM EtiquetaCliente WHERE  etiq_rutclie='" + filtro + "'  AND (etiq_muestra LIKE '" + buscar + "' OR etiq_descripcion LIKE '" + buscar + "' OR LEN(etiq_muestra) LIKE '" + buscar + "') "
        Else
            sqlListar = " SELECT etiq_id, LEN(etiq_muestra) AS etiq_largo, etiq_descripcion FROM EtiquetaCliente WHERE  etiq_rutclie='" + filtro + "'"
        End If

        dtg_listado.DataSource = Nothing
        tablaListar = fnc.ListarTablasSQL(sqlListar)
        dtg_listado.DataSource = tablaListar

    End Sub

    'FUNCIONES OPERATIVAS DE CONTROLES'

    Private Sub dtg_listado_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtg_listado.CurrentCellChanged
        IdPrincipal = CStr(dtg_listado(dtg_listado.CurrentCell.RowNumber, 0))
        NombrePrincipal = CStr(dtg_listado(dtg_listado.CurrentCell.RowNumber, 2))
        btn_seleccionar.Enabled = True
    End Sub

    Private Sub txt_buscar_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_buscar.KeyPress
        listar()
    End Sub

    Private Sub btn_cerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cerrar.Click
        resultado = "NO"
        Me.Close()
    End Sub

    Private Sub btn_seleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_seleccionar.Click
        resultado = "OK"
        Me.Close()
    End Sub
End Class