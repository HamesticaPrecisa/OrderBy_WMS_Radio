Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Data

Public Class Lst_AyudaAuditoria

    Dim fnc As New Funciones
    Dim sqlListar As String
    Dim tablaListar As DataTable
    Dim buscar As String
    Public IdPrincipal As String
    Public NombrePrincipal As String
    Public resultado As String
    Public filtro As String

    Private Sub Lst_AyudaAuditoria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        listar()
    End Sub

    'FUNCIONES OPERATIVAS DEL USUARIO'
    Private Sub listar()

        buscar = txt_buscar.Text.Trim

        If buscar <> "" Then
            sqlListar = "SELECT IdAuditoriaFicha, Descripcion,Cantidad,Tipo FROM ficha_auditoria WHERE (Estado='A'OR Estado='P') AND " & _
                        "Descripcion LIKE '%" + buscar + "%' ORDER BY IdAuditoriaFicha DESC"
        Else
            sqlListar = "SELECT IdAuditoriaFicha, Descripcion,Cantidad,Tipo FROM ficha_auditoria WHERE (Estado='A'OR Estado='P') ORDER BY IdAuditoriaFicha DESC"
        End If

        dtg_listado.DataSource = Nothing
        tablaListar = fnc.ListarTablasSQL(sqlListar)
        dtg_listado.DataSource = tablaListar

    End Sub

    'FUNCIONES OPERATIVAS DE CONTROLES'

    Private Sub dtg_listado_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtg_listado.CurrentCellChanged
        IdPrincipal = CStr(dtg_listado(dtg_listado.CurrentCell.RowNumber, 0))
        NombrePrincipal = CStr(dtg_listado(dtg_listado.CurrentCell.RowNumber, 1))
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

    Private Sub chk_sincamion_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub chk__CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_auditoria.CheckStateChanged
        If chk_auditoria.Checked = True Then
            If MsgBox("¿Desea comenzar una auditoria Libre?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                resultado = "OK"
                IdPrincipal = "NO"
                NombrePrincipal = ""
                Me.Close()
            End If
            chk_auditoria.Checked = False
        End If
    End Sub
End Class