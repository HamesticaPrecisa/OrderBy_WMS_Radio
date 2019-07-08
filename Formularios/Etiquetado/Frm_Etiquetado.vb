Public Class Frm_Etiquetado

    Dim fnc As New Funciones
    Public codigo As String = ""
    Public encargado As String = ""

    '********************** METODOS *******************

    Public Function TransformaPallet(ByVal pallet As String) As String
        TransformaPallet = ""
        For i As Integer = 11 To pallet.Length - 2
            TransformaPallet = TransformaPallet + pallet.Chars(i)
        Next
        Return TransformaPallet
    End Function

    '**************************************************

    Private Sub TxtFolio_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFolio.KeyPress
        If e.KeyChar = ChrW(13) Then
            Dim sql As String = "SELECT etiq_clirut, etiq_codcont, etiq_est, cli_nomb, cont_descr " & _
                                "FROM TMPFICHETIQ, Clientes, contrato WHERE etiq_codcont=cont_codi AND " & _
                                "cli_rut=etiq_clirut AND etiq_codi='" + CerosAnteriorString(TxtFolio.Text, 5) + "'"

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
            If tabla.Rows.Count > 0 Then

                Dim actualiza As String = "UPDATE TMPFICHETIQ SET ETIQ_EST='1' WHERE ETIQ_CODI='" + CerosAnteriorString(TxtFolio.Text, 5) + "'"
                fnc.MovimientoSQL(actualiza)

                If tabla.Rows(0)(2).ToString() = "2" Then
                    MsgBox("El proceso para el codigo ingresado ya termino de ingresar los soportantes", MsgBoxStyle.Critical, "Aviso")
                    Exit Sub

                ElseIf tabla.Rows(0)(2).ToString() = "1" Then
                    MsgBox("El proceso se encuentra tomado", MsgBoxStyle.Critical, "Aviso")
                    Exit Sub

                ElseIf tabla.Rows(0)(2).ToString() = "0" Then
                    TxtFolio.Text = CerosAnteriorString(TxtFolio.Text, 5)
                    TxtCliente.Text = tabla.Rows(0)(3).ToString()
                    TxtContrato.Text = tabla.Rows(0)(4).ToString()
                    lclie.Text = tabla.Rows(0)(0).ToString()
                    lcont.Text = tabla.Rows(0)(1).ToString()
                    TxtFolio.Enabled = False
                    Lector.Enabled = True
                    Lector.Focus()

                    Dim sqlLlenaGrilla As String = "SELECT ETIQ_SOPOPRE AS sp, ETIQ_DCOD AS sc FROM TMPDETAETIQ " & _
                                                   "WHERE ETIQ_CODI='" + TxtFolio.Text + "' ORDER BY etiq_sopopre "

                    ListBox1.DataSource = fnc.ListarTablasSQL(sqlLlenaGrilla)
                    ListBox1.ValueMember = "sc"
                    ListBox1.DisplayMember = "sp"
                    ok.BackColor = Color.Green
                End If
            Else
                MsgBox("El codigo ingresado no existe", MsgBoxStyle.Critical, "Aviso")
            End If
        Else
            SoloNumeros(sender, e)
        End If
    End Sub

    Private Sub Lector_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Lector.KeyPress
        If e.KeyChar = ChrW(13) Then
            If Lector.Text.Length = 21 Then
                Dim pallet As String = TransformaPallet(Lector.Text)

                Dim sql As String = "SELECT drec_codi, drec_sopocli, drec_codpro, drec_fecprod, FechaVencimiento, " & _
                                    "drec_unidades, drec_peso FROM detarece WHERE drec_codi='" + pallet + "'"

                Dim tablarece As DataTable = fnc.ListarTablasSQL(sql)


                Dim sql_verifica As String = "SELECT * FROM detadespa WHERE ddes_codrece='" + pallet + "'"
                Dim tabladespachado As DataTable = fnc.ListarTablasSQL(sql_verifica)

                If tabladespachado.Rows.Count = 0 Then
                    If tablarece.Rows.Count > 0 Then
                        Dim Maximo As String = "SELECT (isnull(MAX(ETIQ_DCOD),0)+1) FROM TMPDETAETIQ WHERE ETIQ_CODI='" + TxtFolio.Text + "'"
                        Dim tablaMaximo As DataTable = fnc.ListarTablasSQL(Maximo)
                        Maximo = CerosAnteriorString(tablaMaximo.Rows(0)(0).ToString(), 2)

                        Dim sqlverifica As String = "SELECT * FROM TMPDETAETIQ WHERE etiq_sopopre='" + pallet + "'"
                        Dim tabla As DataTable = fnc.ListarTablasSQL(sqlverifica)

                        If tabla.Rows.Count = 0 Then

                            Dim Guardar As String = "INSERT INTO TMPDETAETIQ(ETIQ_CODI, ETIQ_DCOD, ETIQ_SOPOPRE, ETIQ_SOPOCLI, " & _
                                                "ETIQ_CODPRO, ETIQ_FECPROD, ETIQ_FECVENC, ETIQ_CAJAS, ETIQ_KILOS, ETIQ_EST) " & _
                                                "VALUES('" + TxtFolio.Text + "','" + Maximo + "','" + tablarece.Rows(0)(0).ToString() + "'," & _
                                                "'" + tablarece.Rows(0)(1).ToString() + "','" + tablarece.Rows(0)(2).ToString() + "'," & _
                                                "'" + devuelve_fecha(Convert.ToDateTime(tablarece.Rows(0)(3).ToString())) + "','" + tablarece.Rows(0)(4).ToString() + "'," & _
                                                "'" + tablarece.Rows(0)(5).ToString() + "','" + tablarece.Rows(0)(6).ToString().Replace(",", ".") + "','0')"

                            If fnc.MovimientoSQL(Guardar) > 0 Then

                                Dim sqlLlenaGrilla As String = "SELECT ETIQ_SOPOPRE AS sp, ETIQ_DCOD AS sc FROM TMPDETAETIQ " & _
                                                               "WHERE ETIQ_CODI='" + TxtFolio.Text + "' ORDER BY etiq_sopopre "

                                ListBox1.DataSource = fnc.ListarTablasSQL(sqlLlenaGrilla)
                                ListBox1.ValueMember = "sc"
                                ListBox1.DisplayMember = "sp"
                                ok.BackColor = Color.Green
                                Lector.Text = ""
                            End If
                        Else
                            ok.BackColor = Color.Red
                            MsgBox("El soportante ya se encuentra etiquetado", MsgBoxStyle.Critical, "Aviso")
                            Lector.Text = ""
                        End If
                    Else
                        MsgBox("Ocurrio un error al rescatar la informacion del soportante", MsgBoxStyle.Critical, "Aviso")
                        Lector.Text = ""
                    End If
                Else
                    MsgBox("El soportante ingresado ya se ha despachado", MsgBoxStyle.Critical, "Aviso")
                    Lector.Text = ""
                End If
            End If
        Else
            SoloNumeros(sender, e)
        End If
    End Sub

    Private Sub BtnFinalizarLectura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFinalizarLectura.Click
        If MsgBox("¿Seguro de finalizar la lectura de soportantes?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = MsgBoxResult.Yes Then
            Dim actualiza As String = "UPDATE TMPFICHETIQ SET ETIQ_EST='2' WHERE ETIQ_CODI='" + CerosAnteriorString(TxtFolio.Text, 5) + "'"

            If fnc.MovimientoSQL(actualiza) > 0 Then
                MsgBox("Lectura de soportantes finalizada", MsgBoxStyle.Information, "Aviso")
                limpiarformulario()
            Else
                MsgBox("Error al finalizar la lectura, intente nuevamente", MsgBoxStyle.Critical, "Aviso")
            End If

        Else
            Lector.Focus()
        End If
    End Sub

    Private Sub Frm_Etiquetado_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If TxtFolio.Enabled = False Then
            If MsgBox("¿Seguro de salir sin finalizar la lectura de soportantes?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = MsgBoxResult.Yes Then
                Dim actualiza As String = "UPDATE TMPFICHETIQ SET ETIQ_EST='0' WHERE ETIQ_CODI='" + CerosAnteriorString(TxtFolio.Text, 5) + "'"
                fnc.MovimientoSQL(actualiza)

                'Dim elimina As String = "DELETE FROM TMPDETAETIQ  WHERE ETIQ_CODI='" + CerosAnteriorString(TxtFolio.Text, 5) + "'"
                'fnc.MovimientoSQL(elimina)
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Sub limpiarformulario()
        TxtFolio.Enabled = True
        TxtFolio.Text = ""

        TxtCliente.Text = ""
        TxtContrato.Text = ""
        lclie.Text = ""
        lcont.Text = ""

        Dim sqlLlenaGrilla As String = "SELECT ETIQ_SOPOPRE AS sp, ETIQ_DCOD AS sc FROM TMPDETAETIQ " & _
                                       "WHERE ETIQ_CODI='00000' ORDER BY etiq_sopopre "

        ListBox1.DataSource = fnc.ListarTablasSQL(sqlLlenaGrilla)
        ListBox1.ValueMember = "sc"
        ListBox1.DisplayMember = "sp"

        Lector.Enabled = False

        TxtFolio.Focus()
    End Sub
End Class