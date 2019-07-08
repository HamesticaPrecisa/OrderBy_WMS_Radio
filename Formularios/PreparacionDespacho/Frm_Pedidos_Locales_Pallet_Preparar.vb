Public Class Frm_Pedidos_Locales_Pallet_Preparar
    Dim fnc As New Funciones
    Public Ord As String = ""
    Public IdLoc As String = ""
    Public Soportante As String = ""
    Public Posicion As String = ""
    Public CajsPend As Integer = 0
    Public IntentosFallidos As Integer = 0
    Public CodUsu As String = ""

    Private Sub Frm_Pedidos_Locales_Pallet_Preparar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblOrd.Text = Ord
        lblIdLoc.Text = IdLoc
        lblSop.Text = Soportante
        lblPos.Text = Posicion
        lblCan.Text = CajsPend.ToString
        txtEtiq.Focus()
    End Sub

    Private Sub txtEtiq_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEtiq.KeyPress
        Try
            If (e.KeyChar = ChrW(13)) Then
                Dim Sopo As String = txtEtiq.Text.Trim

                If (Sopo = "") Then
                    txtEtiq.Focus()
                    Exit Sub
                End If

                'If (Sopo.Length <> 20) Then
                '    MsgBox("Código incorrecto", MsgBoxStyle.Critical, "Aviso")
                '    txtEtiq.Text = ""
                '    txtEtiq.Focus()
                '    Exit Sub
                'End If

                If (Sopo.Substring(Sopo.Length - 10, 9) <> Soportante) Then
                    MsgBox("El soportante marcado no corresponde al solicitado.", MsgBoxStyle.Critical, "Error")
                    txtEtiq.Text = ""
                    txtEtiq.Focus()
                Else
                    txtCajs.Focus()
                End If
            Else
                fnc.SoloNumeros(sender, e)
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al leer Etiqueta.", MsgBoxStyle.Critical, "Error")
            txtEtiq.Text = ""
            txtEtiq.Focus()
        End Try
    End Sub

    Private Sub txtSal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSal.KeyPress
        Try
            If (e.KeyChar = ChrW(13)) Then
                Dim Sopo As String = txtEtiq.Text.Trim

                If (Sopo = "") Then
                    txtEtiq.Focus()
                    Exit Sub
                End If

                Dim Sald As String = txtSal.Text.Trim

                If (Sald = "") Then
                    txtSal.Focus()
                    Exit Sub
                End If

                If (Not IsNumeric(Sald)) Then
                    MsgBox("Debe ingresar un Saldo valido.", MsgBoxStyle.Critical, "Error")
                    txtSal.Text = ""
                    txtSal.Focus()
                    Exit Sub
                End If

                If (Integer.Parse(Sald) < 0) Then
                    MsgBox("El Saldo ingresado debe ser mayor o igual a cero.", MsgBoxStyle.Critical, "Error")
                    txtSal.Text = ""
                    txtSal.Focus()
                    Exit Sub
                End If

                Dim CajsRet As Integer = Integer.Parse(txtCajs.Text.Trim)

                Dim Marcar As Boolean = True

                Dim SopFrm As String = Sopo.Substring(Sopo.Length - 10, 9)
                Dim sql As String = "SP_Pedidos_Locales_Validar_Saldo_Soportante '" & SopFrm & "','" & Sald & "','" & CajsRet & "'"
                Dim dtResp As DataTable = fnc.ListarTablasSQL(sql)

                If (IntentosFallidos > 1) Then
                    Marcar = True
                    MsgBox("Se informara el Saldo ingresado para su revision posterior.", MsgBoxStyle.Information, "Info")

                    Dim sqlSalErr As String = "SP_Pedidos_Locales_Saldo_Incorrecto_Grabar '" & Ord & "','" & SopFrm & "','" & CajsRet & "','" & Sald & "','N','" & CodUsu & "'"
                    fnc.MovimientoSQL(sqlSalErr)
                Else
                    If (dtResp.Rows.Count = 0) Then
                        Marcar = False
                        IntentosFallidos += 1
                        MsgBox("No se encontro detalle de saldo del Soportante." & vbCrLf & vbCrLf & "Intentos Restantes = " & 3 - IntentosFallidos & "", MsgBoxStyle.Critical, "Error")
                        txtSal.Text = ""
                        txtSal.Focus()
                        Exit Sub
                    End If

                    Dim resp As String = dtResp.Rows(0).Item(0).ToString.Trim

                    If (resp = "-1") Then
                        Marcar = False
                        IntentosFallidos += 1
                        MsgBox("El Saldo ingresado no corresponde al saldo según sistema WMS." & vbCrLf & vbCrLf & "Favor corroborar saldo Soportante." & vbCrLf & vbCrLf & "Intentos Restantes = " & 3 - IntentosFallidos & "", MsgBoxStyle.Information, "Info")
                        txtSal.Text = ""
                        txtSal.Focus()
                        Exit Sub
                    End If
                End If

                If (Marcar) Then
                    sql = "SP_Pedidos_Locales_Marcar_Soportante '" & Ord & "','" & IdLoc & "','" & SopFrm & "','" & CajsRet & "'"
                    Dim dtRespMarc As DataTable = fnc.ListarTablasSQL(sql)

                    If (dtRespMarc.Rows.Count = 0) Then
                        MsgBox("Ocurrió un error al guardar la información del Soportante.", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If

                    Dim RespMarc As String = dtRespMarc.Rows(0).Item(0).ToString.Trim

                    If (RespMarc = "-1") Then
                        MsgBox("Ocurrió un error al registrar la información del Soportante.", MsgBoxStyle.Critical, "Error")
                    Else
                        MsgBox("Información regsitrada correctamente.", MsgBoxStyle.Information, "Exito")
                        Me.Close()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al validar Saldo del soportante.", MsgBoxStyle.Critical, "Error")
            txtSal.Text = ""
            txtSal.Focus()
        End Try
    End Sub

    Private Sub btnVol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVol.Click
        Me.Close()
    End Sub

    Private Sub txtCajs_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCajs.KeyPress
        If (e.KeyChar = ChrW(13)) Then
            Dim Sopo As String = txtEtiq.Text.Trim

            If (Sopo = "") Then
                txtEtiq.Focus()
                Exit Sub
            End If

            Dim Cajs As String = txtCajs.Text.Trim
            If (Cajs = "") Then
                txtCajs.Focus()
                Exit Sub
            End If

            If (Not IsNumeric(Cajs)) Then
                MsgBox("Debe ingresar un numero de Cajas valido.", MsgBoxStyle.Critical, "Error")
                txtCajs.Text = ""
                txtCajs.Focus()
                Exit Sub
            End If

            If (Integer.Parse(Cajs) < 1) Then
                MsgBox("Debe retirar al menos una Caja.", MsgBoxStyle.Critical, "Error")
                txtCajs.Text = ""
                txtCajs.Focus()
                Exit Sub
            End If

            If (Integer.Parse(Cajs) > CajsPend) Then
                MsgBox("Debe ingresar una cantidad de Cajas menor a las pendientes.", MsgBoxStyle.Critical, "Error")
                txtCajs.Text = ""
                txtCajs.Focus()
                Exit Sub
            End If

            txtSal.Focus()
        End If
    End Sub
End Class