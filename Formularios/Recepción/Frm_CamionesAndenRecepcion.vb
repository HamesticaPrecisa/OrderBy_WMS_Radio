Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Data

Public Class Frm_CamionesAndenRecepcion

    Dim fnc As New Funciones
    Dim sqlListar As String
    Dim tablaListar As DataTable
    Dim buscar As String
    Public IdPrincipal As String
    Public NombrePrincipal As String
    Public resultado As String
    Public filtro As String

    Private Sub frm_Frm_CamionesAndenRecepcion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        listar()
    End Sub
    'FUNCIONES OPERATIVAS DEL USUARIO'
    Private Sub listar()

        buscar = txt_buscar.Text.Trim

        If buscar <> "" Then
            sqlListar = " SELECT cl_fol, cl_rutcli, cli_nomb, cl_chorut, cho_nombre " & _
                        " FROM clientes, choferes, zchecklist WHERE cl_rutcli=cli_rut " & _
                        " AND cl_chorut=cho_rut AND cl_estpor<>'0' AND cl_estfrigo='0' " & _
                        " AND cl_mov<>'1' AND (cl_des is null OR convert(date,Cl_Lleg,103)" & _
                        " >=convert(date,DATEADD(day,-1,GETDATE()),103) AND Cl_Estfrigo=0) AND " & _
                        " cli_nomb LIKE '%" + buscar + "%'"
        Else
            sqlListar = " SELECT cl_fol, cl_rutcli, cli_nomb, cl_chorut, cho_nombre " & _
                        " FROM clientes, choferes, zchecklist WHERE cl_rutcli=cli_rut " & _
                        " AND cl_chorut=cho_rut AND cl_estpor<>'0' AND cl_estfrigo='0' " & _
                        " AND cl_mov<>'1' AND (cl_des is null OR convert(date,Cl_Lleg,103)" & _
                        " >=convert(date,DATEADD(day,-1,GETDATE()),103) AND Cl_Estfrigo=0)"
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

    Private Sub chk_sincamion_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_sincamion.CheckStateChanged
        If chk_sincamion.Checked = True Then
            If MsgBox("Comenzar la recepción con un camion no registrado", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                resultado = "OK"
                IdPrincipal = "NO"
                Me.Close()
            End If
            chk_sincamion.Checked = False
        End If
    End Sub
End Class