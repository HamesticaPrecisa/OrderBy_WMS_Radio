Public Class Frm_Pedidos_Locales_Pallet_Trackeo_Preparar
    Dim fnc As New Funciones
    Public Ord As String = ""
    Public IdLoc As String = ""
    Public Soportante As String = ""
    Public Posicion As String = ""
    Public CajsPend As Integer = 0
    Public IntentosFallidos As Integer = 0
    Public CodUsu As String = ""

    Private Sub Frm_Pedidos_Locales_Pallet_Trackeo_Preparar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
                If (CInt(lblCan.Text.Trim) = 0) Then
                    MsgBox("No se requieren mas cajas.", MsgBoxStyle.Information, "Info")
                    txtEtiq.Text = ""
                    txtSal.Focus()
                    Exit Sub
                End If

                Dim caj As String = txtEtiq.Text.Trim

                If (caj = "") Then
                    txtEtiq.Focus()
                    Exit Sub
                End If

                Dim sqlCajOk As String = "SP_Pedidos_Locales_Trackeo_Validar_Caja '" & Soportante & "','" & caj & "'"
                Dim dtCajOk As DataTable = fnc.ListarTablasSQL(sqlCajOk)

                If (dtCajOk.Rows.Count > 0) Then
                    If (dtCajOk.Rows(0).Item(0).ToString.Trim = "1") Then
                        Dim exiCaj As Boolean = True

                        For i As Integer = 0 To lstCajs.Items.Count - 1
                            Dim cajLst As String = lstCajs.Items(0).ToString.Trim
                            If (cajLst = caj) Then
                                exiCaj = False
                            End If
                        Next

                        If (exiCaj) Then
                            lstCajs.Items.Add(caj)
                            lblCan.Text = (CInt(lblCan.Text.Trim) - 1).ToString
                            txtEtiq.Text = ""
                            txtEtiq.Focus()
                        Else
                            MsgBox("Esta caja ya esta en la lista", MsgBoxStyle.Information, "Info")
                            txtEtiq.Text = ""
                            txtEtiq.Focus()
                        End If

                        If (CInt(lblCan.Text.Trim) = 0) Then
                            txtSal.Focus()
                        End If
                    ElseIf (dtCajOk.Rows(0).Item(0).ToString.Trim = "-1") Then
                        MsgBox("La caja no corresponde al Soportante referenciado.", MsgBoxStyle.Critical, "Error")
                        txtEtiq.Text = ""
                        txtEtiq.Focus()
                    ElseIf (dtCajOk.Rows(0).Item(0).ToString.Trim = "-2") Then
                        MsgBox("Esta caja ya fue Trackeada anteriormente.", MsgBoxStyle.Critical, "Error")
                        txtEtiq.Text = ""
                        txtEtiq.Focus()
                    End If
                Else
                    MsgBox("No se encontró información de la Etiqueta.", MsgBoxStyle.Critical, "Error")
                    txtEtiq.Text = ""
                    txtEtiq.Focus()
                End If
            Else
                fnc.SoloNumeros(sender, e)
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al comprobar la Etiqueta, vuelva a intentar.", MsgBoxStyle.Critical, "Error")
            txtEtiq.Text = ""
            txtEtiq.Focus()
        End Try
    End Sub

    Private Sub txtSal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSal.KeyPress
        Try
            If (e.KeyChar = ChrW(13)) Then
                Dim Sopo As String = Soportante
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

                Dim CajsRet As Integer = lstCajs.Items.Count

                Dim Marcar As Boolean = True

                Dim sql As String = "SP_Pedidos_Locales_Validar_Saldo_Soportante '" & Sopo & "','" & Sald & "','" & CajsRet & "'"
                Dim dtResp As DataTable = fnc.ListarTablasSQL(sql)

                If (IntentosFallidos > 1) Then
                    Marcar = True
                    MsgBox("Se informara el Saldo ingresado para su revision posterior.", MsgBoxStyle.Information, "Info")

                    Dim sqlSalErr As String = "SP_Pedidos_Locales_Saldo_Incorrecto_Grabar '" & Ord & "','" & Sopo & "','" & CajsRet & "','" & Sald & "','S','" & CodUsu & "'"
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
                    Dim errTrack As Boolean = False

                    For i As Integer = 0 To lstCajs.Items.Count - 1
                        Dim CodCaj As String = lstCajs.Items(i).ToString.Trim

                        Dim sqlTrack As String = "SP_Pedidos_Locales_Trackeo_Grabar '" & Ord & "','" & Soportante & "','" & CodCaj & "'"
                        If (fnc.MovimientoSQL(sqlTrack) = 0) Then
                            errTrack = True
                        End If
                    Next

                    sql = "SP_Pedidos_Locales_Marcar_Soportante '" & Ord & "','" & IdLoc & "','" & Soportante & "','" & CajsRet & "'"
                    Dim dtRespMarc As DataTable = fnc.ListarTablasSQL(sql)

                    If (dtRespMarc.Rows.Count = 0) Then
                        MsgBox("Ocurrió un error al guardar la información del Soportante.", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If

                    Dim RespMarc As String = dtRespMarc.Rows(0).Item(0).ToString.Trim

                    If (RespMarc = "-1") Then
                        MsgBox("Ocurrió un error al registrar la información del Soportante.", MsgBoxStyle.Critical, "Error")
                    Else
                        Dim msg As String = "Información regsitrada correctamente."

                        If (errTrack) Then
                            msg = msg & vbCrLf & "Problema con Trackeo de Cajas. Favor informar al Departamento de Informatica."
                        End If

                        MsgBox(msg, MsgBoxStyle.Information, "Exito")
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
End Class