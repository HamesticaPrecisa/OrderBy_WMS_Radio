Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Data

Public Class Frm_temperaturas

    Dim fnc As New Funciones
    Dim sqlListar As String
    Dim sqlActualizar As String
    Dim tablaListar As DataTable
    Dim buscar As String
    Public IdPrincipal As String
    Public NombrePrincipal As String
    Public resultado As String
    Public filtro As String
    Dim Temperaturas As String
    Dim Soportantes As String
    Dim promedio As Double

    Private Sub Frm_temperaturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        listar()
    End Sub

    'FUNCIONES OPERATIVAS DEL USUARIO'
    Private Sub listar()

        Try
            sqlListar = "SELECT frec_codi+drec_codi AS Soportante, isnull(drec_temp,'0.00') As Temperatura FROM TMPDETARECE  WHERE frec_codi='" + filtro + "' ORDER BY drec_codi"

            dtg_listado.DataSource = Nothing
            tablaListar = fnc.ListarTablasSQL(sqlListar)
            dtg_listado.DataSource = tablaListar

            sqlListar = "SELECT ISNULL(SUM(drec_temp),0) AS Temperatura FROM TMPDETARECE  WHERE frec_codi='" + filtro + "' AND drec_temp <> 0"
            tablaListar = fnc.ListarTablasSQL(sqlListar)

            If tablaListar.Rows.Count > 0 Then
                Temperaturas = tablaListar.Rows(0)(0).ToString.Replace(",", ".")
            Else
                Temperaturas = "0"
            End If

            sqlListar = "SELECT ISNULL(COUNT(frec_codi),0) AS Soportantes FROM TMPDETARECE  WHERE frec_codi='" + filtro + "' AND drec_temp <> 0"
            tablaListar = fnc.ListarTablasSQL(sqlListar)

            If tablaListar.Rows.Count > 0 Then
                Soportantes = tablaListar.Rows(0)(0).ToString
            Else
                Soportantes = "0"
            End If

            If Val(Soportantes) <> 0 And Val(Temperaturas) <> 0 Then
                promedio = Val(Temperaturas) / Val(Soportantes)
            Else
                promedio = 0
            End If

            lbl_cantidad.Text = Soportantes
            lbl_promedio.Text = promedio.ToString
        Catch ex As ArgumentException
            MessageBox.Show("Error en listar: " + ex.Message)
        End Try

    End Sub

    Private Sub limpiar()
        btn_actualizar.Enabled = False
        IdPrincipal = ""
        txt_temperatura.Text = ""
        txt_soportante.Text = ""
        txt_temperatura.Enabled = False
        btn_menos.Enabled = False
    End Sub

    'FUNCIONES OPERATIVAS DE CONTROLES'

    Private Sub btn_cerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cerrar.Click
        resultado = "OK"
        Me.Close()
    End Sub

    Private Sub dtg_listado_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtg_listado.CurrentCellChanged
        IdPrincipal = CStr(dtg_listado(dtg_listado.CurrentCell.RowNumber, 0))
        txt_soportante.Text = IdPrincipal
        txt_temperatura.Text = CStr(dtg_listado(dtg_listado.CurrentCell.RowNumber, 1))
        btn_actualizar.Enabled = True
        txt_temperatura.Enabled = True
        btn_menos.Enabled = True
        txt_temperatura.Focus()
    End Sub

    Private Sub txt_temperatura_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_temperatura.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub btn_menos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_menos.Click
        If IsNumeric(txt_temperatura.Text) Then
            txt_temperatura.Text = (Val(txt_temperatura.Text) * -1).ToString
        End If
    End Sub

    Private Sub btn_actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        If IdPrincipal <> "" Then
            sqlActualizar = "UPDATE TMPDETARECE SET drec_temp='" + txt_temperatura.Text.Trim + "' WHERE frec_codi+drec_codi='" + IdPrincipal + "'"
            If fnc.MovimientoSQL(sqlActualizar) > 0 Then
                'MsgBox("Registro guardado", MsgBoxStyle.Information, "Aviso")
                limpiar()
                listar()
                Exit Sub
            Else
                MsgBox("Ocurrio un error al aztualizar", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Frm_temperaturas_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        resultado = "OK"
        Me.Close()
    End Sub

    Private Sub btn_punto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_punto.Click
        txt_temperatura.Text = txt_temperatura.Text + "."
    End Sub
End Class