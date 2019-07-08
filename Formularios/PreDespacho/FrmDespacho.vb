Imports System.Windows.Forms.TabControl

Public Class FrmDespacho

    Dim filaSeleccionada As String = ""
    Dim fnc As New Funciones
    Dim cliente As String = ""
    Public CODIENCA As String = ""
    '-----------------------

    Function TransformaPallet(ByVal pallet As String) As String
        Dim separado As String = ""
        For i As Integer = 11 To pallet.Length - 2
            separado = separado + pallet.Chars(i)
        Next
        Return separado
    End Function

    Private Sub txtrut_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtrut.KeyUp
        If Len(txtrut.Text) = 8 Then
            verificador.Focus()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cliente.Click
        Dim frm As New Frm_buscaCliente
        Dim res As DialogResult = frm.ShowDialog()

        If res = Windows.Forms.DialogResult.OK Then
            If frm.cliente.Length >= 9 Then
                Me.txtrut.Text = frm.cliente.Chars(0) & _
                frm.cliente.Chars(1) & _
                frm.cliente.Chars(2) & _
                frm.cliente.Chars(3) & _
                frm.cliente.Chars(4) & _
                frm.cliente.Chars(5) & _
                frm.cliente.Chars(6) & _
                frm.cliente.Chars(7)

                Me.verificador.Text = frm.cliente.Chars(8)
                Me.txtclinombre.Text = frm.nombrecliente
                If LblCodigo.Text = "0000000" Then
                    Dim tabla As DataTable = fnc.ListarTablasSQL("SELECT Cor_correact FROM correlat WHERE cor_codi='007'")

                    If tabla.Rows.Count > 0 Then
                        LblCodigo.Text = CerosAnteriorString(tabla.Rows(0)(0).ToString(), 7).ToString()
                        Dim sqlActualiza As String = "UPDATE correlat SET Cor_correact='" + (Convert.ToInt32(LblCodigo.Text) + 1).ToString() + "' " & _
                        "WHERE cor_codi='007'"
                        fnc.MovimientoSQL(sqlActualiza)
                    End If
                End If
            End If
        End If



    End Sub

    Private Sub txtpallet_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpallet.KeyPress

        If e.KeyChar = ChrW(13) Then
            If txtpallet.Text.Length = 21 Then

                Dim valor_pallet As String = txtpallet.Text.Remove(0, 11)
                valor_pallet = valor_pallet.Remove(9, 1)

                If fnc.verificaExistencia("DetaRece", "drec_codi", valor_pallet) = True Then

                    '10017800000-0000158028

                    If fnc.verificaExistencia("rackdeta", "racd_codi", valor_pallet.ToString()) = True Then

                        Dim sql_esta_bloqueado As String = "SELECT racd_estado FROM rackdeta WHERE racd_codi='" + valor_pallet.ToString() + "'"
                        Dim tabla_bloqueado As DataTable = fnc.ListarTablasSQL(sql_esta_bloqueado)

                        If tabla_bloqueado.Rows.Count > 0 Then
                            If tabla_bloqueado.Rows(0)(0).ToString() <> "0" Then
                                MsgBox("Este soportante se encuentra bloqueado", MsgBoxStyle.Information, "Aviso")
                                txtpallet.Text = ""
                                txtpallet.Focus()
                                Exit Sub
                            End If
                        End If

                        Dim sqlvalidapallet As String = "SELECT drec_codpro, drec_codsopo, drec_sopocli, racd_unidades, racd_peso, " & _
                                                        "drec_rutcli, drec_contcli, drec_fecprod, drec_camara, " & _
                                                        "drec_banda, drec_colum, drec_piso, drec_nivel, drec_almacen, drec_dcaja " & _
                                                        "FROM detarece INNER JOIN rackdeta ON racd_codi=drec_codi WHERE drec_codi='" + valor_pallet + "' AND " & _
                                                        "drec_rutcli='" + txtrut.Text + verificador.Text + "'"

                        Dim tabla As DataTable = fnc.ListarTablasSQL(sqlvalidapallet)

                        If tabla.Rows.Count > 0 Then

                            Dim sqlNumero As String = "SELECT MAX( CONVERT(NUMERIC(18,0),dpre_codi)) FROM TMPDETAPRED WHERE fpre_codi='" + LblCodigo.Text + "'"
                            Dim tablaNumero As DataTable = fnc.ListarTablasSQL(sqlNumero)

                            Dim numeropallet As String = "01"

                            If IsNumeric(tablaNumero.Rows(0)(0).ToString()) Then
                                numeropallet = (Convert.ToInt32(tablaNumero.Rows(0)(0).ToString()) + 1).ToString()
                            End If

                            Dim frm_menu As New Frm_Menu
                            Dim usu_cod As String = frm_menu.codigo.ToString()

                            If fnc.verificaExistencia("TMPDETAPRED", "dpre_folio", valor_pallet.ToString()) = True Then
                                MsgBox("El pallet seleccionado se encuentra ingresado en un PRE-DESPACHO", MsgBoxStyle.Information, "Aviso")
                                txtpallet.Text = ""
                                Exit Sub
                            End If

                            Dim sql As String = "INSERT INTO TMPDETAPRED (fpre_codi, dpre_codi, dpre_codpro, dpre_codsopo, dpre_sopocli, " & _
                                                "dpre_unidades, dpre_peso, dpre_fecdes, dpre_rutcli, dpre_contcli, dpre_fecprod, " & _
                                                "dpre_camara, dpre_banda, dpre_colum, dpre_piso, dpre_nivel, dpre_almacen, " & _
                                                "dpre_folio, dpre_activa, dpre_radio, dpre_track, dpre_codvig, dpre_pallet, " & _
                                                "dpre_slot, dpre_TS, dpre_TM, dpre_TI, dpre_Ptr, dpre_Pick, dpre_CodPer, dpre_Hora, " & _
                                                "dpre_fecn, dpre_ActUni, dpre_TotUni)" & _
                                                "VALUES('" + LblCodigo.Text + "','" + CerosAnteriorString(numeropallet.ToString(), 2).ToString() + "','" + tabla.Rows(0)(0).ToString() + "'," & _
                                                "'" + tabla.Rows(0)(1).ToString() + "','" + tabla.Rows(0)(2).ToString() + "','" + tabla.Rows(0)(3).ToString() + "', " & _
                                                "'" + tabla.Rows(0)(4).ToString().Replace(",", ".") + "','" + devuelve_fecha(fnc.DevuelveFechaServidor()) + "','" + tabla.Rows(0)(5).ToString() + "', " & _
                                                "'" + tabla.Rows(0)(6).ToString() + "','" + tabla.Rows(0)(7).ToString() + "','" + tabla.Rows(0)(8).ToString() + "', " & _
                                                "'" + tabla.Rows(0)(9).ToString() + "','" + tabla.Rows(0)(10).ToString() + "','" + tabla.Rows(0)(11).ToString() + "', " & _
                                                "'" + tabla.Rows(0)(12).ToString() + "','" + tabla.Rows(0)(13).ToString() + "','" + valor_pallet.ToString() + "', " & _
                                                "'0','0','0','0','1','000','0','0','0','" + Val(numeropallet).ToString + "','0','" + usu_cod + "','" + DevuelveHora().ToString() + "','" + devuelve_fecha(fnc.DevuelveFechaServidor()) + "'," & _
                                                "'" + tabla.Rows(0)(3).ToString() + "','" + tabla.Rows(0)(3).ToString() + "')"

                            If fnc.MovimientoSQL(sql) > 0 Then
                                cargaListbox()
                                txtpallet.Text = ""
                            End If

                        Else
                            MsgBox("El pallet ingresado no es del cliente seleccionado", MsgBoxStyle.Information, "Aviso")
                            txtpallet.Text = ""
                        End If
                    Else
                        MsgBox("El pallet ya se despacho con anterioridad", MsgBoxStyle.Information, "Aviso")
                        txtpallet.Text = ""
                    End If
                Else
                    MsgBox("El numero de pallet no existe", MsgBoxStyle.Critical, "Aviso")
                    txtpallet.Text = ""
                End If

            End If

        Else
            fnc.SoloNumeros(sender, e)
        End If


    End Sub

    Private Sub FrmDespacho_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Enabled = True

        Dim sqlCombo As String = "SELECT IdTipoDescripcion, TipoDescripcion FROM P_TipoDescripcion ORDER BY IdTipoDescripcion DESC"
        CmboCarga.DataSource = fnc.ListarTablasSQL(sqlCombo)
        CmboCarga.DisplayMember = "TipoDescripcion"
        CmboCarga.ValueMember = "IdTipoDescripcion"

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtpallet.Enabled = True
        txtpallet.Focus()
    End Sub

    Sub cargaListbox()
        Dim sql As String = "SELECT dpre_folio AS f1, dpre_folio AS f2 FROM TMPDETAPRED WHERE fpre_codi='" + LblCodigo.Text + "'"
        Lst_pallets.DataSource = fnc.ListarTablasSQL(sql)
        Lst_pallets.DisplayMember = "f1"
        Lst_pallets.ValueMember = "f2"

        Dim sqlTotales As String = "SELECT SUM(dpre_unidades) AS Unidades, SUM(dpre_peso) AS Peso FROM TMPDETAPRED WHERE fpre_codi='" + LblCodigo.Text + "'"
        Dim tablatotales As DataTable = fnc.ListarTablasSQL(sqlTotales)

        If tablatotales.Rows.Count > 0 Then
            Btn_Cliente.Enabled = False
            txtsoportantes.Text = Lst_pallets.Items.Count.ToString()
            txtcajas.Text = tablatotales.Rows(0)(0).ToString()
            txtkilos.Text = tablatotales.Rows(0)(1).ToString()
            txtpallet.Text = ""
            txtpallet.Focus()
        End If
    End Sub

    Private Sub FrmDespacho_Closing(ByVal sender As System.Object, _
                                    ByVal e As System.ComponentModel.CancelEventArgs, _
                                    Optional ByVal op As String = "NO") Handles MyBase.Closing
        Dim contador As Integer = 0

        If fnc.verificaExistencia("fichpred", "fpre_codi", LblCodigo.Text) = False AndAlso LblCodigo.Text <> "0000000" Then
            If MsgBox("Desea salir sin guardar el Predespacho?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = MsgBoxResult.No Then
                e.Cancel = True
            Else
                Timer1.Enabled = False

                Dim sqlDeta As String = "DELETE FROM TMPDETAPRED WHERE dpre_codi LIKE '%" + LblCodigo.Text + "__%'"
                If fnc.MovimientoSQL(sqlDeta) > 0 Then
                    contador += 1
                End If

                Dim sqlFich As String = "DELETE FROM TMPFICHPRED WHERE fpre_codi='" + LblCodigo.Text + "'"
                If fnc.MovimientoSQL(sqlFich) > 0 Then
                    contador += 1
                End If

                If contador = 2 Then
                    MsgBox("Temporales Borrados exitosamente", MsgBoxStyle.Information, "Aviso")
                End If

            End If
        Else
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnLimpiaPallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiaPallet.Click
        txtpallet.Text = ""
        txtpallet.Focus()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim fecha As New DateTime
        fecha = fnc.buscaHoraServidor()
        Try
            If fnc.verificaExistencia("FICHPRED", "fpre_codi", LblCodigo.Text) = True Then
                Exit Sub
            End If
            If txtrut.Text.Length = 8 AndAlso verificador.Text.Length = 1 AndAlso CmboCarga.SelectedValue.ToString() <> "3" _
            AndAlso IsNumeric(Temp1.Text) AndAlso IsNumeric(Temp2.Text) AndAlso IsNumeric(Temp3.Text) Then

                Dim cincuenta As String = ""
                If Cb1.Checked = True Then
                    cincuenta = "True"
                Else
                    cincuenta = "False"
                End If

                If fnc.verificaExistencia("cincuenta", "folio", LblCodigo.Text) = False Then

                    Dim GuardaCincuenta As String = "INSERT INTO cincuenta(folio, despacho, cliente, carga, cincuenta, fecha)VALUES" & _
                                                                   "('" + LblCodigo.Text + "','','" + txtrut.Text + "" + verificador.Text + "', " & _
                                                                   "'" + (Val(CmboCarga.SelectedValue) - 1).ToString() + "','" + cincuenta + "','" + fecha.ToString() + "')"

                    fnc.MovimientoSQL(GuardaCincuenta)
                Else

                    Dim ActualizaCincuenta As String = "UPDATE cincuenta SET  cliente='" + txtrut.Text + "" + verificador.Text + "', " & _
                                                    "carga='" + (Val(CmboCarga.SelectedValue) - 1).ToString() + "', " & _
                                                    "cincuenta='" + cincuenta + "' WHERE folio='" + LblCodigo.Text + "'"

                    fnc.MovimientoSQL(ActualizaCincuenta)

                End If

                Dim PromTemp As Double = ((Convert.ToDouble(Temp1.Text.Replace(",", ".")) + _
                                         Convert.ToDouble(Temp2.Text.Replace(",", ".")) + _
                                         Convert.ToDouble(Temp3.Text.Replace(",", "."))) / 3)

                PromTemp = Math.Round(PromTemp, 1)

                If fnc.verificaExistencia("TMPFICHPRED", "fpre_codi", LblCodigo.Text) = False Then

                    Dim sql As String = "INSERT INTO TMPFICHPRED(fpre_codi, fpre_rutcli, fpre_horades, fpre_fecdes, " & _
                    "fpre_totsopo, fpre_totunidad, fpre_totpeso, fpre_codienca, fpre_activa, fpre_fechact, fpre_codvig, " & _
                    "fpre_radio, fpre_tipo, fpre_proceso, fpre_sello, fpre_tem, fpre_TS, fpre_TM, fpre_TI, fpre_rutcond, fpre_gdespa, fpre_anden )" & _
                    "VALUES('" + LblCodigo.Text + "','" + txtrut.Text + "" + verificador.Text + "','" + DevuelveHora().ToString() + "', " & _
                    "'" + devuelve_fecha(fecha) + "','" + txtsoportantes.Text + "','" + txtcajas.Text + "','" + txtkilos.Text.Replace(",", ".") + "', " & _
                    "'" + CerosAnteriorString(CODIENCA.ToString(), 3) + "','1','" + devuelve_fecha(fecha) + "','0','0','0','0','" + TxtSello.Text + "', " & _
                    "'" + PromTemp.ToString().Replace(",", ".") + "','" + Temp1.Text.Replace(",", ".") + "','" + Temp2.Text.Replace(",", ".") + "', " & _
                    "'" + Temp3.Text.Replace(",", ".") + "','000000000','0','0')"

                    fnc.MovimientoSQL(sql)

                Else

                    Dim SqlModifica As String = "UPDATE TMPFICHPRED SET  fpre_rutcli='" + txtrut.Text + "" + verificador.Text + "', " & _
                    "fpre_fecdes='" + devuelve_fecha(fecha) + "', " & _
                    "fpre_totsopo='" + txtsoportantes.Text + "', fpre_totunidad='" + txtcajas.Text + "', fpre_totpeso='" + txtkilos.Text.Replace(",", ".") + "', " & _
                    "fpre_codienca='" + CerosAnteriorString(CODIENCA.ToString(), 3) + "', fpre_sello='" + TxtSello.Text + "', fpre_tem='" + PromTemp.ToString.Replace(",", ".") + "', " & _
                    "fpre_TS='" + Temp1.Text.Replace(",", ".") + "', fpre_TM='" + Temp2.Text.Replace(",", ".") + "', fpre_TI='" + Temp3.Text.Replace(",", ".") + "',fpre_nped='0', fpre_etiq='0' " & _
                    "WHERE fpre_codi='" + LblCodigo.Text + "'"

                    fnc.MovimientoSQL(SqlModifica)
                End If

                txtpallet.Enabled = True

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListBox1_SelectedIndexChanged()
        If Lst_pallets.Items.Count > 0 Then
            filaSeleccionada = CerosAnteriorString(Lst_pallets.SelectedValue.ToString(), 9)
        End If
    End Sub

    Private Sub Lst_pallets_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Lst_pallets.KeyPress
        ListBox1_SelectedIndexChanged()
        If e.KeyChar = ChrW(13) AndAlso filaSeleccionada <> "" Then
            If MsgBox("Desea Eliminar la caja seleccionada", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = MsgBoxResult.Yes Then

                Dim sql As String = "DELETE FROM TMPDETAPRED WHERE dpre_folio='" + filaSeleccionada + "'"
                If fnc.MovimientoSQL(sql) > 0 Then
                    MsgBox("Pallet eliminado", MsgBoxStyle.Information, "Aviso")
                    filaSeleccionada = ""
                    cargaListbox()
                End If

            End If
        End If
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Dim contadordetapred As Integer = 0

        If validacioningreso() = False Then
            Exit Sub
        End If

        ' Guardar Pre - Despacho
        If fnc.verificaExistencia("fichpred", "fpre_codi", LblCodigo.Text) = True Then
            MsgBox("El predespacho ya se guardo, si desea modificarlo tiene que eliminarlo y luego hacerlo nuevamente", MsgBoxStyle.Information, "Aviso")
            Exit Sub
        End If

        Dim PromTemp As Double = (Convert.ToDouble(Temp1.Text.Replace(",", ".")) + _
                                         Convert.ToDouble(Temp2.Text.Replace(",", ".")) + _
                                         Convert.ToDouble(Temp3.Text.Replace(",", "."))) / 3
        PromTemp = Math.Round(PromTemp, 1)

        Dim SQLTMPPRED As String = "SELECT fpre_rutcli, fpre_horades, fpre_fecdes, fpre_totsopo, " & _
        "fpre_totunidad, fpre_totpeso, fpre_codienca, fpre_activa, fpre_fechact, fpre_codvig, fpre_radio,  " & _
        "fpre_tipo, fpre_proceso, fpre_sello, fpre_tem, fpre_TS, fpre_TM, fpre_TI  FROM TMPFICHPRED WHERE fpre_codi='" + LblCodigo.Text + "'"


        Dim tabla As DataTable = fnc.ListarTablasSQL(SQLTMPPRED)

        If tabla.Rows.Count > 0 Then
            Dim sqlPred As String = "INSERT INTO fichpred(fpre_codi, fpre_rutcli, fpre_horades, fpre_horater, fpre_fecdes, fpre_totsopo, fpre_totunidad, fpre_totpeso,  fpre_codienca, " & _
                     "fpre_activa, fpre_fechact, fpre_codvig, fpre_radio, fpre_tipo, fpre_proceso, fpre_sello, fpre_tem, FPRE_USUCRE, fpre_contenedor, fpre_rampla, fpre_destino, fpre_Observacion, fpre_gdespa, fpre_anden, fpre_rutcond)" & _
                     "VALUES('" + LblCodigo.Text + "', " & _
                     "'" + tabla.Rows(0)(0).ToString() + "' , " & _
                     "'" + tabla.Rows(0)(1).ToString() + "' , " & _
                     "'" + DevuelveHora.ToString() + "' , " & _
                     "'" + tabla.Rows(0)(2).ToString() + "' , " & _
                     "'" + tabla.Rows(0)(3).ToString() + "' , " & _
                     "'" + tabla.Rows(0)(4).ToString() + "' , " & _
                     "'" + tabla.Rows(0)(5).ToString().Replace(",", ".") + "' , " & _
                     "'" + CerosAnteriorString(CODIENCA.ToString(), 3) + "' , " & _
                     "'0' , " & _
                     "'" + tabla.Rows(0)(8).ToString() + "' , " & _
                     "'" + tabla.Rows(0)(9).ToString() + "' , " & _
                     "'" + tabla.Rows(0)(10).ToString() + "' , " & _
                     "'" + tabla.Rows(0)(11).ToString() + "' , " & _
                     "'" + tabla.Rows(0)(12).ToString() + "' , " & _
                     "'" + TxtSello.Text.ToUpper() + "' , " & _
                     "'" + PromTemp.ToString().Replace(",", ".") + "' , " & _
                     "'" + CerosAnteriorString(CODIENCA.ToString(), 3) + "' , " & _
                     "'" + TxtContenedor.Text.ToUpper() + "' , " & _
                     "'" + Txtrampla.Text.ToUpper() + "' , " & _
                     "'" + Txtdestino.Text.ToUpper() + "' , " & _
                     "'" + TxtObs.Text.ToUpper() + "','0','0','000000000')"


            If fnc.MovimientoSQL(sqlPred) > 0 Then


                Dim SQLTEMPPRED As String = "SELECT fpre_codi, dpre_codi, dpre_codpro, dpre_codsopo, dpre_sopocli, dpre_unidades, dpre_peso, dpre_fecdes, dpre_rutcli, dpre_contcli, " & _
                "dpre_fecprod, dpre_camara, dpre_banda, dpre_colum, dpre_piso, dpre_nivel, dpre_almacen, dpre_folio, dpre_activa, dpre_radio, " & _
                "dpre_track, dpre_codvig, dpre_pallet, dpre_slot,  dpre_TS, dpre_TM, dpre_TI, dpre_Ptr , dpre_CodPer, " & _
                "dpre_Hora, dpre_fecn, dpre_ActUni, dpre_TotUni FROM TMPDETAPRED WHERE fpre_codi='" + LblCodigo.Text + "'"

                Dim tablaTmpPred As DataTable = fnc.ListarTablasSQL(SQLTEMPPRED)

                If tablaTmpPred.Rows.Count > 0 Then


                    For i As Integer = 0 To Lst_pallets.Items.Count - 1


                        Dim SqlMovPallet As String = "INSERT  INTO movpallet(mov_folio, mov_codper, mov_ca, mov_ba, mov_co, " & _
                                                 "mov_pi, mov_ni, mov_fecha, mov_tipo, mov_hora, mov_TS, mov_TM, mov_TI, mov_Doc, " & _
                                                 "mov_RecepTunel, Mov_Despacho, Mov_Saldo)VALUES(" & _
                                                 "'" + tablaTmpPred.Rows(i)(17).ToString() + "','" + CerosAnteriorString(CODIENCA.ToString(), 3) + "', " & _
                                                 "'" + tablaTmpPred.Rows(i)(11).ToString() + "','" + tablaTmpPred.Rows(i)(12).ToString() + "', " & _
                                                 "'" + tablaTmpPred.Rows(i)(13).ToString() + "','" + tablaTmpPred.Rows(i)(14).ToString() + "', " & _
                                                 "'" + tablaTmpPred.Rows(i)(15).ToString() + "','" + devuelve_fecha(fnc.buscaHoraServidor()) + "', " & _
                                                 "'PD','" + DevuelveHora().ToString() + "','" + Temp1.Text.Replace(",", ".") + "', " & _
                                                 "'" + Temp2.Text.Replace(",", ".") + "','" + Temp3.Text.Replace(",", ".") + "', " & _
                                                 "'" + LblCodigo.Text + "','1','" + txtsoportantes.Text + "','" + txtsoportantes.Text + "')"

                        fnc.MovimientoSQL(SqlMovPallet)



                        Dim sqlTmpInsert As String = "INSERT INTO detapred(dpre_codi, dpre_codpro, dpre_codsopo, dpre_sopocli, " & _
                                          "dpre_unidades, dpre_peso, dpre_fecdes, dpre_rutcli, dpre_contcli, dpre_fecprod, dpre_camara, dpre_banda, dpre_colum, " & _
                                          "dpre_piso, dpre_nivel, dpre_almacen, dpre_folio, dpre_activa, dpre_radio, dpre_track, dpre_codvig, dpre_pallet, " & _
                                          "dpre_slot, dpre_TS, dpre_TM, dpre_TI , dpre_CodPer, dpre_Hora, dpre_fecn, dpre_dcaja) VALUES (" & _
                                          "'" + tablaTmpPred.Rows(i)(0).ToString() + "" + tablaTmpPred.Rows(i)(1).ToString() + "', " & _
                                          "'" + tablaTmpPred.Rows(i)(2).ToString() + "', " & _
                                          "'" + tablaTmpPred.Rows(i)(3).ToString() + "', " & _
                                          "'" + tablaTmpPred.Rows(i)(4).ToString() + "', " & _
                                          "'" + tablaTmpPred.Rows(i)(5).ToString() + "', " & _
                                          "'" + tablaTmpPred.Rows(i)(6).ToString().Replace(",", ".") + "', " & _
                                          "'" + tablaTmpPred.Rows(i)(7).ToString() + "', " & _
                                          "'" + tablaTmpPred.Rows(i)(8).ToString() + "', " & _
                                          "'" + tablaTmpPred.Rows(i)(9).ToString() + "', " & _
                                          "'" + tablaTmpPred.Rows(i)(10).ToString() + "', " & _
                                          "'" + tablaTmpPred.Rows(i)(11).ToString() + "', " & _
                                          "'" + tablaTmpPred.Rows(i)(12).ToString() + "', " & _
                                          "'" + tablaTmpPred.Rows(i)(13).ToString() + "', " & _
                                          "'" + tablaTmpPred.Rows(i)(14).ToString() + "', " & _
                                          "'" + tablaTmpPred.Rows(i)(15).ToString() + "', " & _
                                          "'" + tablaTmpPred.Rows(i)(16).ToString() + "', " & _
                                          "'" + tablaTmpPred.Rows(i)(17).ToString() + "', " & _
                                          "'" + tablaTmpPred.Rows(i)(18).ToString() + "', " & _
                                          "'" + tablaTmpPred.Rows(i)(19).ToString() + "', " & _
                                          "'" + tablaTmpPred.Rows(i)(20).ToString() + "', " & _
                                          "'" + tablaTmpPred.Rows(i)(21).ToString() + "', " & _
                                          "'" + tablaTmpPred.Rows(i)(22).ToString() + "', " & _
                                          "'" + tablaTmpPred.Rows(i)(23).ToString() + "', " & _
                                          "'" + Temp1.Text.Replace(",", ".") + "', " & _
                                          "'" + Temp2.Text.Replace(",", ".") + "', " & _
                                          "'" + Temp3.Text.Replace(",", ".") + "', " & _
                                          "'" + CerosAnteriorString(CODIENCA.ToString(), 3) + "', " & _
                                          "'" + tablaTmpPred.Rows(i)(28).ToString() + "', " & _
                                          "'" + tablaTmpPred.Rows(i)(29).ToString() + "','0') "

                        If fnc.MovimientoSQL(sqlTmpInsert) > 0 Then
                            contadordetapred += 1
                        End If
                    Next
                End If
            End If

            If contadordetapred = Lst_pallets.Items.Count Then
                Dim contador As Integer = 0

                MsgBox("Grabacion exitosa", MsgBoxStyle.Information, "Aviso")

                Dim sqlDeta As String = "DELETE FROM TMPDETAPRED WHERE fpre_codi='" + LblCodigo.Text + "'"

                If fnc.MovimientoSQL(sqlDeta) > 0 Then
                    contador += 1
                End If

                Dim sqlFich As String = "DELETE FROM TMPFICHPRED WHERE fpre_codi='" + LblCodigo.Text + "'"
                If fnc.MovimientoSQL(sqlFich) > 0 Then
                    contador += 1
                End If

                If contador = 2 Then
                    MsgBox("Temporales Borrados exitosamente", MsgBoxStyle.Information, "Aviso")
                End If

            Else
                MsgBox("Error al grabar el predespacho", MsgBoxStyle.Critical, "Aviso")
            End If

        End If


    End Sub

    Function validacioningreso() As Boolean

        validacioningreso = True
        Dim mensaje As String = ""

        If txtrut.Text.Length <> 8 AndAlso verificador.Text.Length <> 1 Then
            mensaje = mensaje + "Ingresar rut cliente" + vbCrLf
            validacioningreso = False
        End If

        If CmboCarga.SelectedValue.ToString() = "3" Then
            mensaje = mensaje + "Seleccionar tipo de carga" + vbCrLf
            validacioningreso = False
        End If

        If TxtSello.Text = "" Then
            mensaje = mensaje + "Ingresar sello" + vbCrLf
            validacioningreso = False
        End If

        If Not IsNumeric(Temp1.Text) Then
            mensaje = mensaje + "Ingresar temperatura 1 valida" + vbCrLf
            validacioningreso = False
        End If

        If Not IsNumeric(Temp1.Text) Then
            mensaje = mensaje + "Ingresar temperatura 2 valida" + vbCrLf
            validacioningreso = False
        End If

        If Not IsNumeric(Temp1.Text) Then
            mensaje = mensaje + "Ingresar temperatura 3 valida" + vbCrLf
            validacioningreso = False
        End If

        If Lst_pallets.Items.Count = 0 Then
            mensaje = mensaje + "Ingresar pallet al predespacho" + vbCrLf
            validacioningreso = False
        End If
        If validacioningreso = False Then
            MsgBox("Error al guardar debe ingresar" + vbCrLf + mensaje, MsgBoxStyle.Critical, "Aviso")
        End If

        Return validacioningreso
    End Function

    Private Sub Btn_Pendientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Pendientes.Click
        Dim codigo As String = InputBox("Ingrese Pre-Despacho", "N° :")
        If IsNumeric(codigo) Then
            If fnc.verificaExistencia("TMPFICHPRED", "fpre_codi", CerosAnteriorString(codigo.ToString(), 7)) = True Then
                RescataPreDespacho(CerosAnteriorString(codigo.ToString(), 7))
            Else
                MsgBox("El Folio no existe", MsgBoxStyle.Critical, "Aviso")
            End If
        Else
            MsgBox("No es numero", MsgBoxStyle.Critical, "Aviso")
        End If
    End Sub

    Sub RescataPreDespacho(ByVal codigopredespacho As String)

        Dim sqlFich As String = "SELECT fpre_rutcli, carga, cincuenta, cli_nomb, fpre_TS, fpre_TM, fpre_TI, fpre_sello " & _
        "FROM TMPFICHPRED, clientes, cincuenta WHERE fpre_codi='" + codigopredespacho.ToString() + "' AND fpre_rutcli=cli_rut AND folio=fpre_codi"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sqlFich)

        If tabla.Rows.Count > 0 Then
            LblCodigo.Text = codigopredespacho.ToString()
            txtrut.Text = tabla.Rows(0)(0).ToString().Remove(8, 1)
            verificador.Text = tabla.Rows(0)(0).ToString().Chars(8)
            CmboCarga.SelectedValue = Convert.ToInt32(tabla.Rows(0)(1).ToString()) + 1

            If tabla.Rows(0)(2).ToString() = "True" Then
                Cb1.Checked = True
            Else
                Cb1.Checked = False
            End If

            txtclinombre.Text = tabla.Rows(0)(3).ToString()

            Temp1.Text = tabla.Rows(0)(4).ToString()
            Temp2.Text = tabla.Rows(0)(5).ToString()
            Temp3.Text = tabla.Rows(0)(6).ToString()

            cargaListbox()

        End If

    End Sub
 
    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        LblCodigo.Text = "0000000"
        txtrut.Text = ""
        verificador.Text = ""
        txtclinombre.Text = ""
        CmboCarga.SelectedValue = 3
        Temp1.Text = ""
        Temp2.Text = ""
        Temp3.Text = ""
        TxtContenedor.Text = ""
        Txtrampla.Text = ""
        TxtSello.Text = ""
        Txtdestino.Text = ""
        cargaListbox()
        txtsoportantes.Text = "0"
        txtcajas.Text = "0"
        txtkilos.Text = "0"
        Btn_Cliente.Enabled = True
        Cb1.Checked = False
    End Sub

    Private Sub verificador_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles verificador.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtrut.Text.Length = 8 AndAlso verificador.Text.Length = 1 Then
                If fnc.verificaExistencia("clientes", "cli_rut", txtrut.Text + "" + verificador.Text) = True Then

                    Dim sql As String = "SELECT cli_nomb FROM clientes WHERE cli_rut='" + txtrut.Text + "" + verificador.Text + "'"
                    Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

                    If tabla.Rows.Count > 0 Then
                        txtclinombre.Text = tabla.Rows(0)(0).ToString()
                    End If


                Else
                    MsgBox("El rut ingresado no esta ingresado", MsgBoxStyle.Critical, "Aviso")
                End If

            Else
                MsgBox("Rut incompleto", MsgBoxStyle.Information, "Aviso")

            End If
        End If
    End Sub

End Class