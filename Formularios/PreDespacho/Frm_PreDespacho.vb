Imports System.Data.SqlClient
Imports System.Data

Public Class Frm_PreDespacho

    Dim filaSeleccionada As String = ""
    Dim fnc As New Funciones
    Dim palletoriginal As String = ""
    Dim cantidadpick As String = ""
    '-----------------------
    Dim cliente As String = ""
    Dim estcheck As Boolean = True
    Public codusu As String = ""
    Dim numeroordenconjunta As String = ""
    Dim ordenconjunta As String
    Dim sql_Pertenece As String
    Dim entro As String = ""
    Dim frm As New Frm_Menu

    Function validacioningreso() As Boolean

        validacioningreso = True
        Dim mensaje As String = ""

        If txtrut.Text.Length <> 8 AndAlso verificador.Text.Length <> 1 Then
            mensaje = mensaje + "Ingresar rut cliente" + vbCrLf
            validacioningreso = False
        End If

        If IsNothing(CmboCarga.SelectedValue.ToString()) Then
            mensaje = mensaje + "Seleccionar tipo de carga" + vbCrLf
            validacioningreso = False
        End If

        'If TxtSello.Text = "" Then
        '    mensaje = mensaje + "Ingresar sello" + vbCrLf
        '    validacioningreso = False
        'End If

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

        If DgvSoportantes.VisibleRowCount = 0 Then
            mensaje = mensaje + "Ingresar pallet al predespacho" + vbCrLf
            validacioningreso = False
        End If

        'VALIDAR TODOS LOS SOPORTANTES DEL PEDIDO
        Dim tabla As DataTable = New DataTable
        tabla = fnc.ListarTablasSQL("SELECT COUNT (*) FROM Pedidos_detalle pd INNER JOIN Pedidos_ficha pf ON pd.pedido=pf.pedido WHERE Orden='" + TxtNped.Text + "'")

        If tabla.Rows.Count > 0 Then
            If Val(tabla.Rows(0)(0).ToString()) > Val(txtsoportantes.Text) Then
                MsgBox("Faltan agregar soportantes de este pedido", MsgBoxStyle.Critical, "Aviso")
                Return False
                Exit Function
            End If
        End If

        If validacioningreso = False Then
            MsgBox("Error al guardar debe ingresar " + vbCrLf + mensaje, MsgBoxStyle.Critical, "Aviso")
        End If

        Return validacioningreso
    End Function

    Private Sub verificapick()
        'VALIDAR TODOS LOS SOPORTANTES DEL PEDIDO
        Dim tabla As DataTable = New DataTable
        tabla = fnc.ListarTablasSQL("SELECT * FROM PALLETPICK WHERE pedido='" + TxtNped.Text + "' and palletpick='" + txtpallet.Text.Trim() + "'")

        If tabla.Rows.Count > 0 Then
            palletoriginal = tabla.Rows(0)(0).ToString().Trim()
            cantidadpick = tabla.Rows(0)(3).ToString().Trim()
        End If
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Dim contadordetapred As Integer = 0

        If validacioningreso() = False Then
            Exit Sub
        End If

        If MsgBox("¿Desea Terminar el pre-despacho?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbNo Then
            Exit Sub
        End If

        Dim con As New Conexion

        Try
            con.conectarSQL()

            Dim olor As String = ""
            Dim higiene As String = ""
            Dim cond As String = ""
            If CHKOLOR.Checked = True Then
                olor = "SI"
            Else
                olor = "NO"
            End If
            If CHKHIG.Checked = True Then
                higiene = "SI"
            Else
                higiene = "NO"
            End If
            If CHKCOND.Checked = True Then
                cond = "SI"
            Else
                cond = "NO"
            End If
            Dim SUCURSALGLO As String = "1"

            Dim _cmd As SqlCommand = New SqlCommand("PAG_INGPREDESPACHO", con.conSQL)
            _cmd.CommandType = CommandType.StoredProcedure
            _cmd.Parameters.AddWithValue("@fpre_codi", lblcodigo.Text)
            _cmd.Parameters.AddWithValue("@fpre_rutcli", txtrut.Text + "" + verificador.Text)
            _cmd.Parameters.AddWithValue("@fpre_totsopo", txtsoportantes.Text)
            _cmd.Parameters.AddWithValue("@fpre_totunidad", txtcajas.Text)
            _cmd.Parameters.AddWithValue("@fpre_totpeso", txtkilos.Text.Replace(",", "."))
            _cmd.Parameters.AddWithValue("@fpre_codienca", CerosAnteriorString(codusu, 3))
            _cmd.Parameters.AddWithValue("@fpre_sello", TxtSello.Text)
            _cmd.Parameters.AddWithValue("@fpre_contenedor", TxtContenedor.Text)
            _cmd.Parameters.AddWithValue("@fpre_rampla", Txtrampla.Text)
            _cmd.Parameters.AddWithValue("@fpre_destino", Txtdestino.Text)
            _cmd.Parameters.AddWithValue("@fpre_observacion", TxtObs.Text)
            _cmd.Parameters.AddWithValue("@fpre_nped", TxtNped.Text)
            _cmd.Parameters.AddWithValue("@fpre_etiq", Convert.ToInt32(CbEtiq.CheckState).ToString())
            _cmd.Parameters.AddWithValue("@tipo", "PR")
            _cmd.Parameters.AddWithValue("@TS", Temp1.Text.Replace(",", "."))
            _cmd.Parameters.AddWithValue("@TM", Temp2.Text.Replace(",", "."))
            _cmd.Parameters.AddWithValue("@TI", Temp3.Text.Replace(",", "."))
            _cmd.Parameters.AddWithValue("@olor", olor)
            _cmd.Parameters.AddWithValue("@hig", higiene)
            _cmd.Parameters.AddWithValue("@cond", cond)
            _cmd.Parameters.AddWithValue("@codbod", sucursalglo.Trim())
            Dim resp As Integer = 0
            Try
                resp = Convert.ToInt32(_cmd.ExecuteScalar())
            Catch ex As Exception
                resp = 1
            End Try

            If resp = 0 Then
                Dim sqlFich As String = "DELETE FROM FICHPREDFOLIO "

                fnc.MovimientoSQL(sqlFich)
                MsgBox("Grabación exitosa", MsgBoxStyle.Information, "Aviso")
            ElseIf resp < 4 Then
                MsgBox("Error esperado al grabar la información", MsgBoxStyle.Critical, "Aviso")
            ElseIf resp = 4 Then
                MsgBox("El Pre-despacho ya esta grabado", MsgBoxStyle.Information, "Aviso")
            Else
                MsgBox("Error inesperado al grabar la información", MsgBoxStyle.Critical, "Aviso")
            End If

            con.cerrarSQL()
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub Frm_PreDespacho_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs, Optional ByVal op As String = "") Handles MyBase.Closing
        Dim contador As Integer = 0
        If lblcodigo.Text = "" Then
            'f_addPredespacho = False
            Exit Sub
        End If

        If fnc.verificaExistencia("fichpred", "fpre_codi", lblcodigo.Text) = False Then
            If MsgBox("Desea salir sin guardar el Predespacho?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = MsgBoxResult.No Then
                op = "NO"
            Else
                op = "SI"
                Timer1.Enabled = False
                Dim sqlDeta As String = "DELETE FROM TMPDETAPRED WHERE fpre_codi='" + lblcodigo.Text + "'"
                If fnc.MovimientoSQL(sqlDeta) > 0 Then
                    contador += 1
                End If

                Dim sqlFich As String = "DELETE FROM TMPFICHPRED WHERE fpre_codi='" + lblcodigo.Text + "'"
                If fnc.MovimientoSQL(sqlFich) > 0 Then
                    contador += 1
                End If

                Dim sqlFichFOL As String = "DELETE FROM FICHPREDFOLIO"
                fnc.MovimientoSQL(sqlFichFOL)

                If contador = 2 Then
                    If CbPedido.CheckState = 1 Then
                        'cambia estado pedcaja
                        'Dim sql_Actualiza As String = "UPDATE pedidos_ficha SET Ped_EstPred='0' " & _
                        '                              "WHERE orden='" + TxtNped.Text + "'"
                        Dim sql_Actualiza As String = "SP_Pedidos_Estados_Actualizar '" & TxtNped.Text.Trim & "','P','0'"
                        fnc.MovimientoSQL(sql_Actualiza)
                    End If

                    'DESBLOQUEAR DE RACKDETA 
                    Dim _DESBLOQUEA_SOPORTANTE As String = "UPDATE rackdeta SET racd_estado='0', racd_pred='' WHERE racd_pred='" + lblcodigo.Text + "'"
                    fnc.MovimientoSQL(_DESBLOQUEA_SOPORTANTE)
                    MsgBox("Temporales borrados exitosamente", MsgBoxStyle.Information, "Aviso")
                End If
            End If
        End If

        If op = "NO" Then
            e.Cancel = True
        ElseIf op = "SI" Then
            'f_addPredespacho = False
            CancelaCorrelativo("007", lblcodigo.Text)
            Timer2.Enabled = False
        End If
    End Sub

    Private Sub btn_BuscaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_BuscaCliente.Click
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

                Me.verificador.Enabled = False
                Me.txtclinombre.Enabled = False
                Me.txtrut.Enabled = False

                btn_BuscaCliente.Enabled = False
                Temp1.Focus()
            End If
        End If
    End Sub

    Private Sub Frm_GuiaPreDespacho_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim frm As New Frm_Menu
        Dim sqlCombo As String = "SELECT  tcar_codi, tcar_descr FROM P_TipoCargaDescarga ORDER BY tcar_codi ASC"
        CmboCarga.DataSource = fnc.ListarTablasSQL(sqlCombo)
        CmboCarga.DisplayMember = "tcar_descr"
        CmboCarga.ValueMember = "tcar_codi"
        Timer1.Enabled = True
        Dt_fecha.Value = fnc.DevuelveFechaServidor()
        Timer2.Enabled = False
    End Sub

    'Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick

    '    If e.RowIndex > -1 AndAlso e.ColumnIndex = 0 AndAlso Lbl_EstadoGuia.Text <> "DESPACHADO" AndAlso _
    '        fnc.verificaExistenciaCondicional("TMPdetapred", "dpre_folio='" + Me.DataGridView1.Rows(e.RowIndex).Cells("pallet").Value.ToString() + "'") = True Then

    '        If MsgBox("Desea Eliminar el pallet seleccionado", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = MsgBoxResult.Yes Then

    '            Dim sql As String = "DELETE FROM TMPDETAPRED WHERE dpre_folio='" + Me.DataGridView1.Rows(e.RowIndex).Cells("pallet").Value.ToString() + "'"
    '            If fnc.MovimientoSQL(sql) > 0 Then
    '                MsgBox("Pallet eliminado", MsgBoxStyle.Information, "Aviso")
    '                filaSeleccionada = ""
    '                CargaGrilla()
    '            End If
    '        End If
    '    End If
    'End Sub

    Sub RescataTMPPreDespacho(ByVal codigopredespacho As String)
        Dim sqlFich As String = "SELECT fpre_rutcli, carga, cincuenta, cli_nomb, fpre_TS, fpre_TM, fpre_TI, fpre_sello, fpre_nped, fpre_etiq " & _
                "FROM TMPFICHPRED, clientes, cincuenta WHERE fpre_codi='" + codigopredespacho.ToString() + "' AND fpre_rutcli=cli_rut AND folio=fpre_codi"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sqlFich)

        If tabla.Rows.Count > 0 Then
            lblcodigo.Text = codigopredespacho.ToString()
            txtrut.Text = tabla.Rows(0)(0).ToString().Remove(8, 1)
            verificador.Text = tabla.Rows(0)(0).ToString().Chars(8)
            CmboCarga.SelectedValue = Convert.ToInt32(tabla.Rows(0)(1).ToString())

            If tabla.Rows(0)(2).ToString() = "True" Then
                Cb1.Checked = True
            Else
                Cb1.Checked = False
            End If

            txtclinombre.Text = tabla.Rows(0)(3).ToString()
            Temp1.Text = tabla.Rows(0)(4).ToString()
            Temp2.Text = tabla.Rows(0)(5).ToString()
            Temp3.Text = tabla.Rows(0)(6).ToString()

            If Convert.ToInt32(tabla.Rows(0)(8).ToString()) > 0 Then
                estcheck = False
                CbPedido.Checked = True
                TxtNped.Text = tabla.Rows(0)(8).ToString()
                estcheck = True
            Else
                CbPedido.Checked = False
                TxtNped.Text = "0"
            End If

            If tabla.Rows(0)(9).ToString() = "1" Then
                CbEtiq.Checked = True
            End If

            CbPedido.Visible = True
            CbPedido.Enabled = False
            Timer1.Enabled = True
            CargaGrilla()
            lblcodigo.Enabled = False
            GroupBox1.Enabled = True
        Else
            lblcodigo.Text = ""
            lblcodigo.Focus()
        End If

    End Sub

    Sub RescataPreDespacho(ByVal codigopredespacho As String)

        Dim sqlFich As String = "SELECT fpre_rutcli, carga, cincuenta, cli_nomb, fpre_sello, fpre_contenedor, fpre_rampla, " & _
            "fpre_destino, fpre_observacion, fpre_fecdes , mov_ts, mov_tm, mov_ti , fpre_tem, fpre_codvig, fpre_totsopo, fpre_totunidad, fpre_totpeso, fpre_nped " & _
            "FROM FICHPRED, clientes, cincuenta , movpallet " & _
            "WHERE fpre_rutcli=cli_rut AND folio=fpre_codi AND mov_doc=fpre_codi AND (mov_tipo='PD' OR mov_tipo='PR') AND fpre_codi='" + codigopredespacho + "' "

        Dim tabla As DataTable = fnc.ListarTablasSQL(sqlFich)

        If tabla.Rows.Count > 0 Then
            lblcodigo.Text = codigopredespacho.ToString()
            txtrut.Text = tabla.Rows(0)(0).ToString().Remove(8, 1)
            verificador.Text = tabla.Rows(0)(0).ToString().Chars(8)
            CmboCarga.SelectedValue = Convert.ToInt32(tabla.Rows(0)(1).ToString())

            If tabla.Rows(0)(2).ToString() = "True" Then
                Cb1.Checked = True
            Else
                Cb1.Checked = False
            End If

            txtclinombre.Text = tabla.Rows(0)(3).ToString()
            TxtSello.Text = tabla.Rows(0)(4).ToString()
            TxtContenedor.Text = tabla.Rows(0)(5).ToString()
            Txtrampla.Text = tabla.Rows(0)(6).ToString()
            Txtdestino.Text = tabla.Rows(0)(7).ToString()
            TxtObs.Text = tabla.Rows(0)(8).ToString()

            If IsDate(tabla.Rows(0)(9).ToString()) Then
                Dt_fecha.Value = Convert.ToDateTime(devuelve_fecha(Convert.ToDateTime(tabla.Rows(0)(9).ToString())))
            End If

            Temp1.Text = tabla.Rows(0)(10).ToString()
            Temp2.Text = tabla.Rows(0)(11).ToString()
            Temp3.Text = tabla.Rows(0)(12).ToString()
            tempprom.Text = tabla.Rows(0)(13).ToString()

            If tabla.Rows(0)(14).ToString() = "0" Then
                Lbl_EstadoGuia.Text = "ACTIVA"
                Lbl_EstadoGuia.ForeColor = Color.Blue
            ElseIf tabla.Rows(0)(14).ToString() = "1" Then
                Lbl_EstadoGuia.Text = "NULA"
                Lbl_EstadoGuia.ForeColor = Color.Red
            ElseIf tabla.Rows(0)(14).ToString() = "2" Then
                Lbl_EstadoGuia.Text = "DESPACHADO"
                Lbl_EstadoGuia.ForeColor = Color.Blue
            End If
            txtsoportantes.Text = tabla.Rows(0)(15).ToString()
            txtcajas.Text = tabla.Rows(0)(16).ToString()
            txtkilos.Text = tabla.Rows(0)(17).ToString()

            If Convert.ToInt32(tabla.Rows(0)(18).ToString()) > 0 Then
                estcheck = False
                CbPedido.Checked = True
                TxtNped.Text = tabla.Rows(0)(18).ToString()
                estcheck = True
            Else
                CbPedido.Checked = False
                TxtNped.Text = "0"
            End If

            CbPedido.Visible = True
            CbPedido.Enabled = False

            CargaGrillaPred()
            lblcodigo.Enabled = False
            txtpallet.Enabled = False
            BtnGuardar.Enabled = False
        Else
            MsgBox("El codigo ingresado no existe", MsgBoxStyle.Critical, "Aviso")
            lblcodigo.Text = ""
            lblcodigo.Focus()
        End If

    End Sub

    Private Sub txtcodigo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lblcodigo.KeyPress

        If e.KeyChar = ChrW(13) Then
            If lblcodigo.Text = "" Then
                lblcodigo.Text = BuscaCorrelativo("007")

                Dim Guarda As String = "INSERT INTO fichpredfolio(foliopre)VALUES" & _
                                                                  "('" + lblcodigo.Text + "')"

                If fnc.MovimientoSQL(Guarda) > 0 Then

                Else
                    lblcodigo.Text = ""
                    lblcodigo.Enabled = True
                    lblcodigo.Focus()

                End If


                Dim sqlActualiza As String = "UPDATE correlat SET Cor_correact='" + (Convert.ToInt32(lblcodigo.Text) + 1).ToString() + "' " & _
                "WHERE cor_codi='007'"

                fnc.MovimientoSQL(sqlActualiza)
                'BtnBuscar.Enabled = False
                lblcodigo.Enabled = False
                GroupBox1.Enabled = True
                BtnGuardar.Enabled = True
                btn_BuscaCliente.Enabled = True
                CbPedido.Visible = True
            Else
                lblcodigo.Text = CerosAnteriorString(lblcodigo.Text, 7)
                If fnc.verificaExistencia("fichpred", "fpre_codi", lblcodigo.Text) = False Then
                    RescataTMPPreDespacho(lblcodigo.Text)
                Else
                    RescataPreDespacho(lblcodigo.Text)
                End If
            End If
            btn_BuscaCliente.Focus()
        Else
            SoloNumeros(sender, e)
        End If
    End Sub

    Private Sub verificador_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles verificador.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtrut.Text.Length = 8 AndAlso verificador.Text.Length = 1 Then
                If fnc.verificaExistencia("clientes", "cli_rut", txtrut.Text + "" + verificador.Text) = True Then

                    Dim sql As String = "SELECT cli_nomb, cli_estado FROM clientes WHERE cli_rut='" + txtrut.Text + "" + verificador.Text + "'"
                    Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

                    If tabla.Rows.Count > 0 Then
                        If tabla.Rows(0)(1).ToString() = "N" Then
                            MsgBox("El rut ingresado se encuentra bloqueado", MsgBoxStyle.Critical, "Aviso")
                            Exit Sub
                        End If
                        txtclinombre.Text = tabla.Rows(0)(0).ToString()
                        txtrut.Enabled = False
                        verificador.Enabled = False
                        btn_BuscaCliente.Enabled = False
                        CbPedido.Visible = True
                    End If


                Else
                    MsgBox("El rut ingresado no esta ingresado", MsgBoxStyle.Critical, "Aviso")
                End If

            Else
                MsgBox("Rut incompleto", MsgBoxStyle.Information, "Aviso")

            End If
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
 
        Try

            If txtrut.Text.Length >= 8 AndAlso verificador.Text.Length = 1 AndAlso CmboCarga.SelectedValue.ToString() <> Nothing _
            AndAlso IsNumeric(Temp1.Text) AndAlso IsNumeric(Temp2.Text) AndAlso IsNumeric(Temp3.Text) Then

                If fnc.verificaExistencia("fichpred", "fpre_codi", lblcodigo.Text) = True Then
                    Exit Sub
                End If

                Dim cincuenta As String = ""
                If Cb1.Checked = True Then
                    cincuenta = "True"
                Else
                    cincuenta = "False"
                End If

                If fnc.verificaExistencia("cincuenta", "folio", lblcodigo.Text) = False Then

                    Dim GuardaCincuenta As String = "INSERT INTO cincuenta(folio, despacho, cliente, carga, cincuenta, fecha)VALUES" & _
                                                                   "('" + lblcodigo.Text + "','','" + txtrut.Text + "" + verificador.Text + "', " & _
                                                                   "'" + CmboCarga.SelectedValue.ToString() + "','" + cincuenta + "',GETDATE())"

                    fnc.MovimientoSQL(GuardaCincuenta)
                Else

                    Dim ActualizaCincuenta As String = "UPDATE cincuenta SET  cliente='" + txtrut.Text + "" + verificador.Text + "', " & _
                                                    "carga='" + CmboCarga.SelectedValue.ToString() + "', " & _
                                                    "cincuenta='" + cincuenta + "' WHERE folio='" + lblcodigo.Text + "'"

                    fnc.MovimientoSQL(ActualizaCincuenta)

                End If


                If fnc.verificaExistencia("TMPFICHPRED", "fpre_codi", lblcodigo.Text) = False Then




                    Dim sql As String = "INSERT INTO TMPFICHPRED(fpre_codi, fpre_rutcli, fpre_horades, fpre_fecdes, " & _
                    "fpre_totsopo, fpre_totunidad, fpre_totpeso, fpre_codienca, fpre_activa, fpre_fechact, fpre_codvig, " & _
                    "fpre_radio, fpre_tipo, fpre_proceso, fpre_sello, fpre_tem, fpre_TS, fpre_TM, fpre_TI, fpre_rutcond, fpre_gdespa, fpre_anden, fpre_nped )" & _
                    "VALUES('" + lblcodigo.Text + "','" + txtrut.Text + "" + verificador.Text + "','" + DevuelveHora() + "', " & _
                    "'" + devuelve_fecha(Dt_fecha.Value) + "','" + txtsoportantes.Text + "','" + txtcajas.Text + "','" + txtkilos.Text.Replace(",", ".") + "', " & _
                    "'" + CerosAnteriorString(frm.codigo.ToString, 3) + "','1','" + devuelve_fecha(Dt_fecha.Value) + "','0','0','0','0','" + TxtSello.Text + "', " & _
                    "'" + tempprom.Text.Replace(",", ".") + "','" + Temp1.Text.Replace(",", ".") + "','" + Temp2.Text.Replace(",", ".") + "', " & _
                    "'" + Temp3.Text.Replace(",", ".") + "','000000000','0','0','" + TxtNped.Text + "')"

                    fnc.MovimientoSQL(sql)

                Else
                    Timer1.Interval = 100000
                    Dim SqlModifica As String = "UPDATE TMPFICHPRED SET  fpre_rutcli='" + txtrut.Text + "" + verificador.Text + "', " & _
                    "fpre_fecdes='" + devuelve_fecha(Dt_fecha.Value) + "', " & _
                    "fpre_totsopo='" + txtsoportantes.Text + "', fpre_totunidad='" + txtcajas.Text + "', fpre_totpeso='" + txtkilos.Text.Replace(",", ".") + "', " & _
                    "fpre_codienca='" + CerosAnteriorString(frm.codigo.ToString, 3) + "', fpre_sello='" + TxtSello.Text + "', fpre_tem='" + tempprom.Text.Replace(",", ".") + "', " & _
                    "fpre_TS='" + Temp1.Text.Replace(",", ".") + "', fpre_TM='" + Temp2.Text.Replace(",", ".") + "', fpre_TI='" + Temp3.Text.Replace(",", ".") + "', fpre_nped='" + TxtNped.Text + "', " & _
                    "fpre_etiq='" + Convert.ToInt32(CbEtiq.CheckState).ToString() + "' WHERE fpre_codi='" + lblcodigo.Text + "'"

                    If fnc.MovimientoSQL(SqlModifica) = 0 Then
                        MsgBox("No actualiza fichpred", MsgBoxStyle.Information, "Aviso")
                    End If
                End If

                txtpallet.Enabled = True

            End If

            If IsNumeric(Temp1.Text) AndAlso IsNumeric(Temp2.Text) AndAlso IsNumeric(Temp3.Text) Then
                Try
                    Dim Prom As Double = (((Convert.ToDouble(Temp1.Text.Replace(".", ","))) + (Convert.ToDouble(Temp2.Text.Replace(".", ","))) + (Convert.ToDouble(Temp3.Text.Replace(".", ",")))) / 3)
                    tempprom.Text = Math.Round(Prom, 1).ToString()
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception

        End Try
         
    End Sub

    Sub CargaGrilla()
        Dim sql As String = "SELECT dpre_folio ,mae_descr , dpre_unidades, dpre_peso FROM TMPDETAPRED, maeprod WHERE mae_codi=dpre_codpro AND " & _
                            "fpre_codi='" + lblcodigo.Text + "'"

        DgvSoportantes.DataSource = fnc.ListarTablasSQL(sql)

        Dim sqlTotales As String = "SELECT SUM(dpre_unidades) AS Unidades, SUM(dpre_peso) AS Peso FROM TMPDETAPRED WHERE fpre_codi='" + lblcodigo.Text + "'"
        Dim tablatotales As DataTable = fnc.ListarTablasSQL(sqlTotales)

        If tablatotales.Rows.Count > 0 Then
            txtsoportantes.Text = (CType(DgvSoportantes.DataSource, DataTable).Rows.Count).ToString()
            txtcajas.Text = tablatotales.Rows(0)(0).ToString()
            txtkilos.Text = tablatotales.Rows(0)(1).ToString()
            txtpallet.Text = ""
            txtpallet.Focus()
        End If
    End Sub

    Sub CargaGrillaPred()
        Dim sql As String = "SELECT dpre_folio, mae_descr AS prod, dpre_unidades, dpre_peso  FROM DETAPRED, maeprod WHERE mae_codi=dpre_codpro AND " & _
                            "dpre_codi LIKE '%" + lblcodigo.Text + "__%'"

        DgvSoportantes.DataSource = fnc.ListarTablasSQL(sql)

    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        Dim contador As Integer = 0
        Lbl_EstadoGuia.Text = "ACTIVA"
        If lblcodigo.Text = "" Then
            lblcodigo.Focus()
            Exit Sub
        End If

        If fnc.verificaExistencia("fichpred", "fpre_codi", lblcodigo.Text) = False Then

            If MsgBox("Desea salir sin guardar el predespacho?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = MsgBoxResult.Yes Then
                Dim sqlDeta As String = "DELETE FROM TMPDETAPRED WHERE fpre_codi='" + lblcodigo.Text + "'"

                If fnc.MovimientoSQL(sqlDeta) > 0 Then
                    contador += 1
                End If

                Dim sqlFich As String = "DELETE FROM TMPFICHPRED WHERE fpre_codi='" + lblcodigo.Text + "'"

                If fnc.MovimientoSQL(sqlFich) > 0 Then
                    contador += 1
                End If

                If contador = 2 Then
                    If CbPedido.CheckState = 1 Then
                        'Dim sql_Actualiza As String = "UPDATE pedidos_ficha SET Ped_EstPred='0' WHERE orden='" + TxtNped.Text + "'"
                        Dim sql_Actualiza As String = "SP_Pedidos_Estados_Actualizar '" & TxtNped.Text.Trim & "','P','0'"
                        fnc.MovimientoSQL(sql_Actualiza)

                    End If
                    CancelaCorrelativo("007", lblcodigo.Text)
                    'DESBLOQUEAR DE RACKDETA 
                    Dim _DESBLOQUEA_SOPORTANTE As String = "UPDATE rackdeta SET racd_estado='0', racd_pred='' WHERE racd_pred='" + lblcodigo.Text + "'"
                    fnc.MovimientoSQL(_DESBLOQUEA_SOPORTANTE)
                    limpiarformulario()
                End If
            End If
        Else
            limpiarformulario()
        End If
    End Sub

    Private Sub limpiarformulario()
        '  BtnBuscar.Enabled = True
        lblcodigo.Enabled = True
        lblcodigo.Text = ""
        txtrut.Text = ""
        verificador.Text = ""
        txtclinombre.Text = ""
        CmboCarga.SelectedValue = 0
        Temp1.Text = ""
        Temp2.Text = ""
        Temp3.Text = ""
        TxtContenedor.Text = ""
        Txtrampla.Text = ""
        TxtSello.Text = ""
        Txtdestino.Text = ""
        txtsoportantes.Text = "0"
        txtcajas.Text = "0"
        txtkilos.Text = "0"
        Cb1.Checked = False
        'For i As Integer = 0 To DataGridView1.Rows.Count - 1
        '    DataGridView1.Rows.RemoveAt(0)
        'Next
        Timer2.Enabled = False
        Label10.Text = "SOPORTANTES DEL PEDIDO   "
        'CmboPedido.DataSource = New DataTable
        Dt_fecha.Value = fnc.buscaHoraServidor()
        CbPedido.Enabled = True
        CbPedido.CheckState = 0
        DgvSoportantes.DataSource = Nothing
        CbCant.Checked = True
        Cant.Visible = False
        GroupBox1.Enabled = False
        TxtNped.Text = "0"
        CbEtiq.Enabled = True
        CbEtiq.Checked = False
        CbCant.Enabled = True
        lblcodigo.Focus()
    End Sub

    ' ---------------------------------------------------------------------------------------------
    ' |                                    VALIDADOR DE OBJETOS                                   |
    ' ---------------------------------------------------------------------------------------------

    Private Sub txtrut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrut.KeyPress
        If e.KeyChar = ChrW(13) Then
            If Len(txtrut.Text) = 8 Then
                verificador.Focus()
            End If
        End If
    End Sub

    Private Sub Temp1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Temp1.KeyUp
        If IsNumeric(Temp1.Text) Then
            Try
                If Convert.ToDouble(Temp1.Text.Replace(".", ",")) <= 0 AndAlso Convert.ToDouble(Temp1.Text.Replace(".", ",")) >= -25 Then
                    Temp1.BackColor = Color.White
                Else
                    Temp1.BackColor = Color.Red
                End If
            Catch ex As Exception
                Temp1.BackColor = Color.Red
            End Try
        Else
            Temp1.BackColor = Color.Red
        End If
    End Sub

    Private Sub Temp2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Temp2.KeyUp
        If IsNumeric(Temp2.Text) Then
            Try
                If Convert.ToDouble(Temp2.Text.Replace(".", ",")) <= 0 AndAlso Convert.ToDouble(Temp2.Text.Replace(".", ",")) >= -25 Then
                    Temp2.BackColor = Color.White
                Else
                    Temp2.BackColor = Color.Red
                End If
            Catch ex As Exception
                Temp2.BackColor = Color.Red
            End Try
        Else
            Temp2.BackColor = Color.Red
        End If
    End Sub

    Private Sub Temp3_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Temp3.KeyUp
        If IsNumeric(Temp3.Text) Then
            Try
                If Convert.ToDouble(Temp3.Text.Replace(".", ",")) <= 0 AndAlso Convert.ToDouble(Temp3.Text.Replace(".", ",")) >= -25 Then
                    Temp3.BackColor = Color.White
                Else
                    Temp3.BackColor = Color.Red
                End If
            Catch ex As Exception
                Temp3.BackColor = Color.Red
            End Try
        Else
            Temp3.BackColor = Color.Red
        End If
    End Sub

    Private Sub Temp1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Temp1.KeyPress, Temp2.KeyPress, Temp3.KeyPress
        If (e.KeyChar = "." Or e.KeyChar = "," Or e.KeyChar = "-") Then
            Exit Sub
        Else
            SoloNumeros(sender, e)
        End If
    End Sub

    Dim pallet_anterior As String = ""
    Dim pallet_anterior2 As String = ""
    Private Sub confirmacant()

        Dim PCA As String = txtpallet.Text
        Dim pallet As String = PCA.Substring(1, PCA.Length - 1)
        Dim pallet2 As String = pallet.Substring(1, 18)
        Dim pallet3 As String = pallet2.Substring(1, 17)
        Dim pallet4 As String = pallet3.Substring(1, 16)
        Dim pallet5 As String = pallet4.Substring(1, 15)
        Dim pallet6 As String = pallet5.Substring(1, 14)
        Dim pallet7 As String = pallet6.Substring(1, 13)
        Dim pallet8 As String = pallet7.Substring(1, 12)
        Dim pallet9 As String = pallet8.Substring(1, 11)
        Dim pallet10 As String = pallet9.Substring(1, 9)

        Dim sqlcajaa As String = "select ordenconjunta from Pedidos_ficha where orden ='" + TxtNped.Text.Trim() + "' "
        Dim tabla_cajaa As DataTable = fnc.ListarTablasSQL(sqlcajaa)

        If tabla_cajaa.Rows.Count > 0 Then

            'VG_PEDIDOSUNIDOSCANT

            Dim CONJ As String = tabla_cajaa.Rows(0)(0).ToString()


            Dim sqlconjunto As String = "select sumacant from VG_PEDIDOSUNIDOSCANT where ordenconjunta ='" + CONJ + "' and pallet ='" + pallet10 + "' "
            Dim tabla_conj As DataTable = fnc.ListarTablasSQL(sqlconjunto)

            If tabla_conj.Rows.Count > 0 Then


                Cant.Text = tabla_conj.Rows(0)(0).ToString()
                entro = "1"
            Else


                entro = ""

            End If

        End If
    End Sub

    Private Sub txtpallet_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpallet.KeyPress
        If e.KeyChar = ChrW(13) Then
            If TxtNped.Text = "0" Then

                MsgBox("Seleccione Pedido Antes de continuar", MsgBoxStyle.Critical, "Aviso")
                txtpallet.Text = ""
                Exit Sub

            Else

            End If
            palletoriginal = "" 'VARIABLE QUE DIFERENCIA A UN PALLET DE PICK CON UNO NORMAL LOS IF ECHOS SON PARA ESO 
            verificapick()
            If palletoriginal = "" Then
            Else

                ' txtpallet.Text = "11780000000" + palletoriginal + "1"
                ' CbCant.Checked = False
                'Cant.Text = cantidadpick
            End If
            If palletoriginal = "" Then


            Else

            End If
            If txtpallet.Text.Length <> 21 And palletoriginal = "" Then


                MsgBox("Codigo incorrecto", MsgBoxStyle.Critical, "Aviso")
                txtpallet.Text = ""
                Exit Sub



            Else

                'Dim PCA As String = txtpallet.Text
                'Dim pallet As String = PCA.Substring(1, PCA.Length - 1)
                'Dim pallet2 As String = pallet.Substring(1, 19)
                'Dim pallet3 As String = pallet2.Substring(1, 18)
                'Dim pallet4 As String = pallet3.Substring(1, 17)
                'Dim pallet5 As String = pallet4.Substring(1, 16)
                'Dim pallet6 As String = pallet5.Substring(1, 15)
                'Dim pallet7 As String = pallet6.Substring(1, 14)
                'Dim pallet8 As String = pallet7.Substring(1, 13)
                'Dim pallet9 As String = pallet8.Substring(1, 12)
                'Dim pallet10 As String = pallet9.Substring(2, 9)

                Dim valor_palletc As String = ""
                If palletoriginal = "" Then
                    valor_palletc = txtpallet.Text.Remove(0, 11)
                    valor_palletc = valor_palletc.Remove(9, 1)

                Else

                    valor_palletc = palletoriginal
                End If



                If palletoriginal = "" Then


                    Dim sqlsies As String = "select * from PALLETPICK where palletorigen ='" + valor_palletc + "' and pedido ='" + TxtNped.Text.Trim() + "' "
                    Dim tabla_sies As DataTable = fnc.ListarTablasSQL(sqlsies)

                    If tabla_sies.Rows.Count > 0 Then
                        MsgBox("Este pallet contiene una etiqueta de picking en este pedido", MsgBoxStyle.Critical, "Aviso")
                        txtpallet.Text = ""
                        Exit Sub

                    End If
                End If






                If TxtNped.Text = "2" Then
                    Dim sqlp As String = "SELECT  orden ,pallet from vg_pedidosactivos WHERE pallet='" + valor_palletc + "'"
                    Dim tablap As DataTable = fnc.ListarTablasSQL(sqlp)
                    If tablap.Rows.Count > 0 Then


                        Dim ordensu As String = tablap.Rows(0)(0).ToString()
                        MsgBox("Pallet contenido en un pedido activo =" + " " + ordensu, MsgBoxStyle.Critical, "Aviso")
                        txtpallet.Text = ""
                        Exit Sub

                    End If
                End If





                Dim sqlped As String = "SELECT   CAJ_PCOD AS PALET,CAJ_COD as CAJA,CAJ_PED AS ESTADO FROM DetaReceCajas INNER JOIN rackdeta ON racd_codi=Caj_Pcod INNER JOIN detarece ON drec_codi=racd_codi WHERE CAJ_PCOD='" + valor_palletc + "' and caj_ped='1' "
                'Dim sqlped As String = "SELECT * FROM detapedcajas where pc_numpal = '" + txtpallet.Text + "'"
                Dim tabla As DataTable = fnc.ListarTablasSQL(sqlped)

                If tabla.Rows.Count > 0 Then
                    '"SELECT    CAJ_PCOD AS PALET,CAJ_COD as CAJA,CAJ_PED AS ESTADO FROM DetaReceCajas INNER JOIN rackdeta ON racd_codi=Caj_Pcod INNER JOIN detarece ON drec_codi=racd_codi WHERE CAJ_PCOD='" + txtpallet.Text + "'  "



                    Dim Sqlpedido As String = "select dpc_codped from detapedcaja where dpc_numpal= '" + valor_palletc + "'"
                    Dim tabla2 As DataTable = fnc.ListarTablasSQL(Sqlpedido)
                    Dim pedidostr As String = tabla2.Rows(0)(0).ToString()

                    If (pedidostr <> TxtNped.Text.Trim) Then
                        MsgBox("Este Pallet Esta Contenido en el pedido " + pedidostr + ", Imposible PRE-Despachar", MsgBoxStyle.Critical, "Aviso")
                        Exit Sub
                    End If
                End If
            End If


            'numero pallet corto
            'Dim valor_pallet As String = txtpallet.Text.Remove(0, 11)
            'valor_pallet = valor_pallet.Remove(9, 1)

            Dim valor_pallet As String = ""
            If palletoriginal = "" Then
                valor_pallet = txtpallet.Text.Remove(0, 11)
                valor_pallet = valor_pallet.Remove(9, 1)

            Else

                valor_pallet = palletoriginal
            End If


            CbCant.Enabled = True

            pallet_anterior2 = pallet_anterior
            pallet_anterior = txtpallet.Text

            'SE OBTIENE EL CAMPO DE ORDEN CONJUNTA

            Dim sql_orden As String = "SELECT ordenconjunta FROM Pedidos_ficha WHERE Orden='" + TxtNped.Text + "'"
            Dim tabla_orden As DataTable = fnc.ListarTablasSQL(sql_orden)
            If tabla_orden.Rows.Count > 0 Then
                ordenconjunta = tabla_orden.Rows(0)(0).ToString()
            Else
                ordenconjunta = ""
            End If
            'FIN DE OBTENER LA ORDEN CONJUNTA

            'SI LA ORDEN CONJUNTA ES DISTINTA DE VACIA SE EJECUTA UN IF PARA COMPROBAR SI EL PALLET INGRESADO PERTENECE
            If Trim(ordenconjunta) <> "" Then
                sql_Pertenece = " SELECT Pedidos_ficha.Orden FROM Pedidos_ficha, Pedidos_detalle " & _
                                " WHERE Pedidos_ficha.pedido = Pedidos_detalle.pedido AND " & _
                                " Pedidos_detalle.pallet = '" + valor_pallet + "' AND Pedidos_ficha.ordenconjunta='" + ordenconjunta + "'"

                Dim tabla_Pertenece As DataTable = fnc.ListarTablasSQL(sql_Pertenece)
                Dim switch As String = "1"

                If tabla_Pertenece.Rows.Count > 0 Then
                    switch = "si"
                Else
                    switch = "no"
                End If

                If switch = "no" Then
                    MsgBox("Este pallet no pertenece a este pedido ", MsgBoxStyle.Critical, "Aviso")
                    txtpallet.Text = ""
                    Exit Sub
                End If

            End If

            'FIN DE COMPROBACION DE PALLET DE PEDIDO


            If fnc.verificaExistenciaCondicional("TMPDETAPRED", "dpre_folio='" + valor_pallet.ToString() + "' AND dpre_codvig='0' " & _
                                                                     "AND fpre_codi='" + lblcodigo.Text + "' AND dpre_CodPer='" + CerosAnteriorString(frm.codigo.ToString, 3) + "'") = True Then

                If MsgBox("Desea eliminar el pallet seleccionado", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Aviso") = MsgBoxResult.Yes Then
                    Dim _sql As String = "DELETE FROM TMPDETAPRED WHERE fpre_codi='" + lblcodigo.Text + "' AND dpre_folio='" + valor_pallet + "'"
                    Dim _sql2 As String = "DELETE FROM detapredcajas WHERE dpre_npallet='" + valor_pallet + "' AND dpre_nped='" + TxtNped.Text + "'"

                    fnc.MovimientoSQL(_sql)
                    fnc.MovimientoSQL(_sql2)
                    CargaGrilla()
                    txtpallet.Text = ""
                    Dim _DESBLOQUEA_SOPORTANTE As String = "UPDATE rackdeta SET racd_estado='0', racd_pred='' WHERE racd_codi='" + valor_pallet + "' AND racd_estado='7'"
                    fnc.MovimientoSQL(_DESBLOQUEA_SOPORTANTE)
                    txtpallet.Text = ""
                    txtpallet.Focus()
                    Exit Sub
                End If
            End If



            'If pallet_anterior = pallet_anterior2 Then
            '    If MsgBox("Desea eliminar el pallet seleccionado", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Aviso") = MsgBoxResult.Yes Then
            '        Dim _sql As String = "DELETE FROM TMPDETAPRED WHERE fpre_codi='" + lblcodigo.Text + "' AND dpre_folio='" + valor_pallet + "'"
            '        Dim _sql2 As String = "DELETE FROM detapredcajas WHERE dpre_npallet='" + valor_pallet + "' AND dpre_nped='" + TxtNped.Text + "'"

            '        fnc.MovimientoSQL(_sql)
            '        fnc.MovimientoSQL(_sql2)
            '        CargaGrilla()
            '        txtpallet.Text = ""
            '        Dim _DESBLOQUEA_SOPORTANTE As String = "UPDATE rackdeta SET racd_estado='0', racd_pred='' WHERE racd_codi='" + valor_pallet + "' AND racd_estado='7'"
            '        fnc.MovimientoSQL(_DESBLOQUEA_SOPORTANTE)
            '        txtpallet.Text = ""
            '        txtpallet.Focus()
            '        Exit Sub
            '    End If
            'End If


            ' bloquea cmbopedido
            ' CmboPedido.Enabled = False

            If fnc.verificaExistencia("DetaRece", "drec_codi", valor_pallet) = True Then ' si el pallet existe

                CbPedido.Enabled = False
                CbEtiq.Enabled = False

                Dim sql_esta_bloqueado As String = "SELECT racd_estado FROM rackdeta WHERE racd_codi='" + valor_pallet.ToString() + "'"
                Dim tabla_bloqueado As DataTable = fnc.ListarTablasSQL(sql_esta_bloqueado)

                If tabla_bloqueado.Rows.Count > 0 Then
                    If Convert.ToInt32(tabla_bloqueado.Rows(0)(0).ToString()) > 2 AndAlso CbEtiq.Checked = False Then
                        MsgBox("Este soportante se encuentra bloqueado", MsgBoxStyle.Critical, "Aviso")
                        txtpallet.Text = ""
                        txtpallet.Focus()
                        Exit Sub
                    End If
                End If

                If fnc.verificaExistencia("rackdeta", "racd_codi", valor_pallet.ToString()) = True Then ' si el pallet esta en el stock, si no esta es porque se despacho

                    If CbPedido.CheckState = 1 Then

                        Dim esdelpedido As String = "SELECT parcial, pd.pedido FROM pedidos_detalle AS pd INNER JOIN Pedidos_ficha AS pf ON " & _
                                                    "pf.pedido=pd.pedido WHERE pallet='" + valor_pallet.ToString() + "' AND orden='" + TxtNped.Text + "'"

                        Dim tablacompleto As DataTable = fnc.ListarTablasSQL(esdelpedido)

                        ' Mayor a 0 corresponde al pedido
                        If tablacompleto.Rows.Count > 0 Then

                            If tablacompleto.Rows(0)(0).ToString() = "1" Then

                                'Verifica si corresponde al pedido de cajas
                                Dim sql_veri As String = "SELECT pf.pedido, cajas, pc_tpoped FROM Pedidos_detalle pd INNER JOIN Pedidos_ficha pf ON pf.pedido=pd.pedido " & _
                                                         "INNER JOIN pedcaja ON pd.pallet=pc_numpal AND pf.orden= pc_codped WHERE Orden='" + TxtNped.Text + "' AND pd.pallet='" + valor_pallet.ToString() + "'"

                                Dim tabla_veri As DataTable = fnc.ListarTablasSQL(sql_veri)

                                If tabla_veri.Rows.Count > 0 Then
                                    'caja normal
                                    If tabla_veri.Rows(0)(2).ToString() = "2" Then
                                        CbCant.CheckState = 0
                                        Cant.Text = tabla_veri.Rows(0)(1).ToString()
                                    ElseIf tabla_veri.Rows(0)(2).ToString() = "3" Then
                                        ''caja especifica 

                                        If fnc.verificaExistenciaCondicional("TMPDETAPRED", "dpre_folio='" + valor_pallet.ToString() + "' AND dpre_codvig='0' " & _
                                                                             "AND fpre_codi='" + lblcodigo.Text + "' AND dpre_CodPer='" + CerosAnteriorString(frm.codigo.ToString, 3) + "'") = True Then

                                            MsgBox("El pallet seleccionado se encuentra agregado a este pre-despacho", MsgBoxStyle.Critical, "Aviso")
                                            txtpallet.Text = ""
                                            Exit Sub
                                        End If

                                        Dim f As New Frm_CajasPedido
                                        f.numero_pedido = Convert.ToInt32(TxtNped.Text)
                                        f.numero_pallet = valor_pallet.ToString()
                                        Dim ret As DialogResult = f.ShowDialog()

                                        Dim numerocajas As Integer = f.ncajas

                                        If numerocajas = 0 Then
                                            MsgBox("Debe registrar las cajas del soportante", MsgBoxStyle.Critical, "Aviso")
                                            Dim sqlElimina As String = "DELETE FROM detapredcajas WHERE dpre_npallet='" + valor_pallet.ToString() + "' AND dpre_nped='" + TxtNped.Text + "'"
                                            fnc.MovimientoSQL(sqlElimina)
                                            txtpallet.Text = ""
                                            Exit Sub
                                        Else
                                            CbCant.CheckState = 0
                                            Cant.Text = numerocajas.ToString()
                                        End If
                                    End If

                                End If
                            End If
                        Else
                            'else no corresponde al pedido

                            'Preguntar si el pallet esta en otro pedido

                            Dim sql As String = "SELECT 'EN STOCK' AS MOV, racd_unidades FROM rackdeta WHERE  racd_codi='" + valor_pallet + "' " & _
                                                "UNION ALL " & _
                                                "SELECT 'PEDIDOS' AS MOV, isnull(SUM(pc_ncaja),0) AS CAJAS FROM pedcaja WHERE pc_estado='1' AND pc_numpal='" + valor_pallet + "' AND pc_codped<>'" + TxtNped.Text + "' " & _
                                                "UNION ALL " & _
                                                "SELECT 'TEMPORAL' AS MOV, isnull(SUM(dpre_unidades),0) AS CAJAS  FROM TMPDETAPRED WHERE dpre_folio='" + valor_pallet + "' " & _
                                                "UNION ALL  " & _
                                                "SELECT 'PREDESPACHADOS' AS MOV, isnull(SUM(dpre_unidades),0) AS CAJAS  FROM detapred INNER JOIN fichpred ON fpre_codi=LEFT(dpre_codi,7) WHERE dpre_folio='" + valor_pallet + "' AND fpre_codvig<>'2' "


                            Dim tabla_consulta As DataTable = fnc.ListarTablasSQL(sql)

                            Dim cantidad_disponible As Integer = Convert.ToInt32(tabla_consulta.Rows(0)(1).ToString()) - (Convert.ToInt32(tabla_consulta.Rows(1)(1).ToString()) + Convert.ToInt32(tabla_consulta.Rows(2)(1).ToString()) + Convert.ToInt32(tabla_consulta.Rows(3)(1).ToString()))

                            If cantidad_disponible <= 0 Then
                                MsgBox("El soportante no tiene cajas disponibles", MsgBoxStyle.Critical, "Aviso")
                                txtpallet.Text = ""
                                txtpallet.Focus()
                                Exit Sub
                            Else

                                If CbCant.Checked = True Then

                                    'Valido si existe en el pre-despacho
                                    If fnc.verificaExistenciaCondicional("TMPDETAPRED", "dpre_folio='" + valor_pallet.ToString() + "' AND dpre_codvig='0' AND dpre_CodPer='" + CerosAnteriorString(frm.codigo.ToString, 3) + "'") = True Then

                                        If fnc.verificaExistenciaCondicional("TMPDETAPRED", "dpre_folio='" + valor_pallet.ToString() + "' AND dpre_codvig='0' AND fpre_codi='" + lblcodigo.Text + "' AND dpre_CodPer='" + CerosAnteriorString(frm.codigo.ToString, 3) + "'") = True Then
                                            MsgBox("El pallet seleccionado se encuentra agregado a este pre-despacho", MsgBoxStyle.Critical, "Aviso")
                                            txtpallet.Text = ""
                                        Else
                                            MsgBox("El pallet seleccionado se encuentra agregado a un pre-despacho", MsgBoxStyle.Critical, "Aviso")
                                            txtpallet.Text = ""
                                        End If
                                        CbCant.CheckState = 1
                                        Exit Sub
                                    End If
                                    If TxtNped.Text = "2" Then

                                    Else
                                        MsgBox("El soportante no corresponde al pedido", MsgBoxStyle.Critical, "Aviso")
                                        txtpallet.Text = ""
                                        Exit Sub
                                    End If

                                    'If MsgBox("¿El soportante no corresponde al pedido pero tiene " + cantidad_disponible.ToString() + " cajas disponibles, las desea agregar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                                    CbCant.Checked = False
                                    Cant.Text = cantidad_disponible.ToString()
                                    'Else
                                    '    CbCant.Checked = True
                                    '    txtpallet.Text = ""
                                    '    txtpallet.Focus()
                                    '    Exit Sub
                                    'End If
                                Else
                                    'parte de cajas
                                    If IsNumeric(Cant.Text) Then
                                        If Convert.ToInt32(Cant.Text) > cantidad_disponible Then
                                            If MsgBox("¿El soportante tiene " + cantidad_disponible.ToString() + " cajas disponibles, las desea agregar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                                                CbCant.Checked = False
                                                Cant.Text = cantidad_disponible.ToString()
                                            Else
                                                CbCant.Checked = False
                                                txtpallet.Text = ""
                                                txtpallet.Focus()
                                                Exit Sub
                                            End If
                                        End If
                                    End If

                                End If
                            End If
                        End If
                    Else
                        'cantidad del pallet que tiene disponible

                        Dim sql As String = "SELECT 'EN STOCK' AS MOV, racd_unidades FROM rackdeta WHERE  racd_codi='" + valor_pallet + "' " & _
                         "UNION ALL " & _
                         "SELECT 'PEDIDOS' AS MOV, isnull(SUM(pc_ncaja),0) AS CAJAS FROM pedcaja WHERE pc_estado='1' AND pc_numpal='" + valor_pallet + "'  AND pc_codped<>'" + TxtNped.Text + "'  " & _
                         "UNION ALL " & _
                         "SELECT 'TEMPORAL' AS MOV, isnull(SUM(dpre_unidades),0) AS CAJAS  FROM TMPDETAPRED WHERE dpre_folio='" + valor_pallet + "' " & _
                         "UNION ALL  " & _
                         "SELECT 'PREDESPACHADOS' AS MOV, isnull(SUM(dpre_unidades),0) AS CAJAS  FROM detapred INNER JOIN fichpred ON fpre_codi=LEFT(dpre_codi,7) WHERE dpre_folio='" + valor_pallet + "' AND fpre_codvig<>'2'  "


                        Dim tabla_consulta As DataTable = fnc.ListarTablasSQL(sql)

                        Dim cantidad_disponible As Integer = Convert.ToInt32(tabla_consulta.Rows(0)(1).ToString()) - (Convert.ToInt32(tabla_consulta.Rows(1)(1).ToString()) + Convert.ToInt32(tabla_consulta.Rows(2)(1).ToString()) + Convert.ToInt32(tabla_consulta.Rows(3)(1).ToString()))

                        If cantidad_disponible <= 0 Then
                            MsgBox("El soportante no tiene cajas disponibles", MsgBoxStyle.Critical, "Aviso")
                            txtpallet.Text = ""
                            txtpallet.Focus()
                            Exit Sub
                        Else
                            If CbCant.Checked = True Then

                                'Valido si existe en el pre-despacho
                                If fnc.verificaExistenciaCondicional("TMPDETAPRED", "dpre_folio='" + valor_pallet.ToString() + "' AND dpre_codvig='0' AND dpre_CodPer='" + CerosAnteriorString(frm.codigo.ToString, 3) + "'") = True Then

                                    If fnc.verificaExistenciaCondicional("TMPDETAPRED", "dpre_folio='" + valor_pallet.ToString() + "' AND dpre_codvig='0' AND fpre_codi='" + lblcodigo.Text + "' AND dpre_CodPer='" + CerosAnteriorString(frm.codigo.ToString, 3) + "'") = True Then
                                        MsgBox("El pallet seleccionado se encuentra agregado a este pre-despacho", MsgBoxStyle.Critical, "Aviso")
                                        txtpallet.Text = ""
                                        CbCant.CheckState = 1
                                        Exit Sub
                                        'Else
                                        '    MsgBox("El pallet seleccionado se encuentra agregado a un pre-despacho", MsgBoxStyle.Critical, "Aviso")
                                        '    txtpallet.Text = ""
                                    End If

                                End If

                                If cantidad_disponible <> tabla_consulta.Rows(0)(1).ToString() Then
                                    If MsgBox("¿El soportante tiene " + cantidad_disponible.ToString() + " cajas disponibles, las desea agregar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                                        CbCant.Checked = False
                                        Cant.Text = cantidad_disponible.ToString()
                                    Else
                                        CbCant.Checked = True
                                        txtpallet.Text = ""
                                        txtpallet.Focus()
                                        Exit Sub
                                    End If
                                End If


                            Else
                                'parte de cajas
                                If IsNumeric(Cant.Text) Then
                                    If Convert.ToInt32(Cant.Text) > cantidad_disponible Then
                                        If MsgBox("¿El soportante tiene " + cantidad_disponible.ToString() + " cajas disponibles, las desea agregar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                                            CbCant.Checked = False
                                            Cant.Text = cantidad_disponible.ToString()
                                        Else
                                            CbCant.Checked = True
                                            txtpallet.Text = ""
                                            txtpallet.Focus()
                                            Exit Sub
                                        End If
                                    End If
                                End If
                            End If

                            'If MsgBox("¿El soportante tiene " + cantidad_disponible.ToString() + " cajas disponibles, las desea agregar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                            '    CbCant.Checked = False
                            '    Cant.Text = cantidad_disponible.ToString()
                            'Else
                            '    CbCant.Checked = False
                            '    txtpallet.Text = ""
                            '    txtpallet.Focus()
                            '    Exit Sub
                            'End If

                        End If
                    End If

                    '10017800000-0000158028

                    'selecciono el pallet , si existe y esta en stock consulto si corresponde al cliente
                    Dim sqlvalidapallet As String = "SELECT drec_codpro, drec_codsopo, drec_sopocli, racd_unidades, racd_peso, drec_rutcli, drec_contcli, " & _
                        "drec_fecprod, drec_camara, drec_banda, drec_colum, drec_piso, drec_nivel, drec_almacen, drec_dcaja " & _
                        "FROM detarece, rackdeta WHERE drec_codi=racd_codi AND drec_codi= '" + valor_pallet + "' AND drec_rutcli='" + txtrut.Text + verificador.Text + "'"

                    Dim cantidadEnPredespacho As Integer = 0 ' cantidad de cajas que estan en pre-despachos activos

                    Dim tabla_can As DataTable = fnc.ListarTablasSQL("SELECT SUM(dpre_unidades) FROM detapred, fichpred  " & _
                                                                     "WHERE dpre_folio='" + valor_pallet + "' AND left(dpre_codi,7)=fpre_codi AND Fpre_codvig='0' ")

                    If tabla_can.Rows.Count > 0 Then
                        If IsNumeric(tabla_can.Rows(0)(0).ToString()) Then
                            cantidadEnPredespacho = tabla_can.Rows(0)(0).ToString()
                        End If
                    End If


                    Dim tabla As DataTable = fnc.ListarTablasSQL(sqlvalidapallet)

                    If tabla.Rows.Count > 0 Then 'si corresponde al cliente pasa el if **********************

                        If CbCant.Checked = False Then ' parte del pallet ***********************
                            If IsNumeric(Cant.Text) Then
                                If Val(Cant.Text) <= Val(tabla.Rows(0)(3).ToString() - cantidadEnPredespacho) Then


                                    Dim kilosUnitario As Double = Convert.ToDouble(tabla.Rows(0)(4).ToString()) / Convert.ToDouble(tabla.Rows(0)(3).ToString())
                                    Dim Kilos As Double = FormatNumber(kilosUnitario * Convert.ToDouble(Cant.Text), 2)


                                    Dim sqlNumero As String = "SELECT MAX( CONVERT(NUMERIC(18,0),dpre_codi)) FROM TMPDETAPRED WHERE fpre_codi='" + lblcodigo.Text + "'"
                                    Dim tablaNumero As DataTable = fnc.ListarTablasSQL(sqlNumero)

                                    Dim numeropallet As String = "01"

                                    If IsNumeric(tablaNumero.Rows(0)(0).ToString()) Then
                                        numeropallet = (Convert.ToInt32(tablaNumero.Rows(0)(0).ToString()) + 1).ToString()
                                    End If


                                    If fnc.verificaExistenciaCondicional("TMPDETAPRED", "dpre_folio='" + valor_pallet.ToString() + "' AND dpre_codvig='0' AND dpre_CodPer='" + CerosAnteriorString(frm.codigo.ToString, 3) + "'") = True Then

                                        If fnc.verificaExistenciaCondicional("TMPDETAPRED", "dpre_folio='" + valor_pallet.ToString() + "' AND dpre_codvig='0' AND fpre_codi='" + lblcodigo.Text + "' AND dpre_CodPer='" + CerosAnteriorString(frm.codigo.ToString, 3) + "'") = True Then
                                            MsgBox("El pallet seleccionado se encuentra agregado a este pre-despacho", MsgBoxStyle.Critical, "Aviso")
                                            txtpallet.Text = ""
                                            CbCant.CheckState = 1
                                            Exit Sub
                                        End If
                                    End If
                                    Dim pallet_cod As String = "0"

                                    If Convert.ToInt32(Cant.Text) = Val(Convert.ToInt32(tabla.Rows(0)(3).ToString()) - cantidadEnPredespacho) Then
                                        pallet_cod = "1"
                                    End If
                                    If TxtNped.Text <> "2" Then

                                        'Dim SQLCAJAS As String = "SELECT * FROM VG_PEDIDODETALLE WHERE  pallet= '" + valor_pallet + "' AND orden='" + TxtNped.Text + "'"
                                        Dim SQLCAJAS As String = "SELECT * FROM VG_PEDIDODETALLE WHERE pallet='" + valor_pallet + "' AND (case when ordenconjunta is not null then ordenconjunta else convert(varchar,Orden) end) like '%" + TxtNped.Text.Trim + "%'"

                                        Dim CANTID As Integer = 0 ' cantidad de cajas que estan en pre-despachos activos

                                        Dim tabla_caj As DataTable = fnc.ListarTablasSQL(SQLCAJAS)

                                        If tabla_caj.Rows.Count > 0 Then

                                            CANTID = Convert.ToInt32(tabla_caj.Rows(0)(2).ToString())
                                            If Convert.ToInt32(Cant.Text) > CANTID Then
                                                MsgBox("La cantidad es mayor a la solicitada en pedido ", MsgBoxStyle.Critical, "Aviso")
                                                txtpallet.Text = ""
                                                Exit Sub

                                            End If

                                            If Convert.ToInt32(Cant.Text) < CANTID Then
                                                MsgBox("La cantidad de cajas es menor a las del pedido ", MsgBoxStyle.Information, "Aviso")


                                            End If
                                        End If

                                    End If

                                    confirmacant()

                                    Dim sql As String = "INSERT INTO TMPDETAPRED (fpre_codi, dpre_codi, dpre_codpro, dpre_codsopo, dpre_sopocli, " & _
                                                        "dpre_unidades, dpre_peso, dpre_fecdes, dpre_rutcli, dpre_contcli, dpre_fecprod, " & _
                                                        "dpre_camara, dpre_banda, dpre_colum, dpre_piso, dpre_nivel, dpre_almacen, " & _
                                                        "dpre_folio, dpre_activa, dpre_radio, dpre_track, dpre_codvig, dpre_pallet, " & _
                                                        "dpre_slot, dpre_TS, dpre_TM, dpre_TI, dpre_Ptr, dpre_Pick, dpre_CodPer, dpre_Hora, " & _
                                                        "dpre_fecn, dpre_ActUni, dpre_TotUni)" & _
                                                        "VALUES('" + lblcodigo.Text + "','" + CerosAnteriorString(numeropallet.ToString(), 2).ToString() + "','" + tabla.Rows(0)(0).ToString() + "'," & _
                                                        "'" + Val(tabla.Rows(0)(1).ToString()).ToString() + "','" + tabla.Rows(0)(2).ToString() + "','" + Cant.Text() + "', " & _
                                                        "'" + Kilos.ToString().Replace(",", ".") + "','" + devuelve_fecha(Dt_fecha.Value) + "','" + tabla.Rows(0)(5).ToString() + "', " & _
                                                        "'" + tabla.Rows(0)(6).ToString() + "','" + tabla.Rows(0)(7).ToString() + "','" + tabla.Rows(0)(8).ToString() + "', " & _
                                                        "'" + tabla.Rows(0)(9).ToString() + "','" + tabla.Rows(0)(10).ToString() + "','" + tabla.Rows(0)(11).ToString() + "', " & _
                                                        "'" + tabla.Rows(0)(12).ToString() + "','" + tabla.Rows(0)(13).ToString() + "','" + valor_pallet.ToString() + "', " & _
                                                        "'0','0','0','0','" + pallet_cod.ToString() + "','000','0','0','0','" + Val(numeropallet).ToString + "','0','" + CerosAnteriorString(frm.codigo.ToString, 3) + "','" + DevuelveHora() + "','" + devuelve_fecha(Dt_fecha.Value) + "'," & _
                                                        "'" + Cant.Text + "','" + Val(tabla.Rows(0)(3).ToString() - (cantidadEnPredespacho + Val(Cant.Text))).ToString() + "')"

                                    If fnc.MovimientoSQL(sql) > 0 Then
                                        CargaGrilla()
                                        txtpallet.Text = ""
                                        CbCant.CheckState = 1
                                        'BLOQUEAR DE RACKDETA 
                                        Dim _BLOQUEA_SOPORTANTE As String = "UPDATE rackdeta SET racd_estado='7', racd_pred='" + lblcodigo.Text + "' WHERE racd_codi='" + valor_pallet + "'"
                                        fnc.MovimientoSQL(_BLOQUEA_SOPORTANTE)
                                    End If
                                Else
                                    MsgBox("la cantidad de cajas ingresadas es mayor a las disponibles en stock (" + _
                                           Val(Val(tabla.Rows(0)(3).ToString()) - cantidadEnPredespacho).ToString() + ")", MsgBoxStyle.Critical, "Aviso")
                                    txtpallet.Text = ""
                                End If
                            Else
                                MsgBox("Debe ingresar un numero de cajas", MsgBoxStyle.Critical, "Aviso")
                                txtpallet.Text = ""
                            End If
                        Else
                            'Pallet completo *******************************************

                            Dim CajasRestantes As Integer = Val(tabla.Rows(0)(3).ToString() - cantidadEnPredespacho)
                            Dim KilosRestantes As Double = CajasRestantes * (tabla.Rows(0)(4).ToString() / tabla.Rows(0)(3).ToString())

                            If CajasRestantes <= 0 Then
                                MsgBox("No tiene cajas disponibles este soportante", MsgBoxStyle.Critical, "Aviso")
                                txtpallet.Text = ""
                                CbCant.CheckState = 1
                                Exit Sub
                            End If

                            Dim sqlNumero As String = "SELECT MAX( CONVERT(NUMERIC(18,0),dpre_codi)) FROM TMPDETAPRED WHERE fpre_codi='" + lblcodigo.Text + "'"
                            Dim tablaNumero As DataTable = fnc.ListarTablasSQL(sqlNumero)

                            Dim numeropallet As String = "01"

                            If IsNumeric(tablaNumero.Rows(0)(0).ToString()) Then
                                numeropallet = (Convert.ToInt32(tablaNumero.Rows(0)(0).ToString()) + 1).ToString()
                            End If

                            Dim usu_cod As String = CerosAnteriorString(frm.codigo.ToString, 3)

                            If fnc.verificaExistenciaCondicional("TMPDETAPRED", "dpre_folio='" + valor_pallet.ToString() + "' AND dpre_codvig='0'") = True Then
                                If fnc.verificaExistenciaCondicional("TMPDETAPRED", "dpre_folio='" + valor_pallet.ToString() + "' AND dpre_codvig='0' AND fpre_codi='" + lblcodigo.Text + "'") = True Then
                                    MsgBox("El pallet seleccionado se encuentra agregado a este pre-despacho", MsgBoxStyle.Critical, "Aviso")
                                    txtpallet.Text = ""
                                    'Else
                                    '    MsgBox("El pallet seleccionado se encuentra agregado a un pre-despacho", MsgBoxStyle.Critical, "Aviso")
                                    '    txtpallet.Text = ""

                                    CbCant.CheckState = 1
                                    Exit Sub
                                End If
                            End If


                            If TxtNped.Text <> "2" Then

                                'Dim SQLCAJAS2 As String = "SELECT * FROM VG_PEDIDODETALLE  WHERE  pallet= '" + valor_pallet + "' AND orden='" + TxtNped.Text + "'"
                                Dim SQLCAJAS2 As String = "SELECT * FROM VG_PEDIDODETALLE WHERE pallet='" + valor_pallet + "' AND (case when ordenconjunta is not null then ordenconjunta else convert(varchar,Orden) end) like '%" + TxtNped.Text.Trim + "%'"

                                Dim CANTID2 As Integer = 0 ' cantidad de cajas que estan en pre-despachos activos

                                Dim tabla_caj2 As DataTable = fnc.ListarTablasSQL(SQLCAJAS2)

                                If tabla_caj2.Rows.Count > 0 Then

                                    CANTID2 = Convert.ToInt32(tabla_caj2.Rows(0)(2).ToString())


                                    If CANTID2 = CajasRestantes Then
                                    Else
                                        'MsgBox("Pallet contiene picking sin lectura", MsgBoxStyle.Information, "Aviso")
                                        MsgBox("Pallet contiene picking", MsgBoxStyle.Information, "Aviso")
                                        Dim kilosUnitario As Double = Convert.ToDouble(tabla.Rows(0)(4).ToString()) / Convert.ToDouble(tabla.Rows(0)(3).ToString())
                                        KilosRestantes = FormatNumber(kilosUnitario * CANTID2)

                                    End If
                                    CajasRestantes = CANTID2

                                End If

                            End If




                            Dim sql As String = "INSERT INTO TMPDETAPRED (fpre_codi, dpre_codi, dpre_codpro, dpre_codsopo, dpre_sopocli, " & _
                                                "dpre_unidades, dpre_peso, dpre_fecdes, dpre_rutcli, dpre_contcli, dpre_fecprod, " & _
                                                "dpre_camara, dpre_banda, dpre_colum, dpre_piso, dpre_nivel, dpre_almacen, " & _
                                                "dpre_folio, dpre_activa, dpre_radio, dpre_track, dpre_codvig, dpre_pallet, " & _
                                                "dpre_slot, dpre_TS, dpre_TM, dpre_TI, dpre_Ptr, dpre_Pick, dpre_CodPer, dpre_Hora, " & _
                                                "dpre_fecn, dpre_ActUni, dpre_TotUni)" & _
                                                "VALUES('" + lblcodigo.Text + "','" + CerosAnteriorString(numeropallet.ToString(), 2).ToString() + "','" + tabla.Rows(0)(0).ToString() + "'," & _
                                                "'" + Val(tabla.Rows(0)(1).ToString()).ToString() + "','" + tabla.Rows(0)(2).ToString() + "','" + CajasRestantes.ToString() + "', " & _
                                                "'" + KilosRestantes.ToString().Replace(",", ".") + "','" + devuelve_fecha(Dt_fecha.Value) + "','" + tabla.Rows(0)(5).ToString() + "', " & _
                                                "'" + tabla.Rows(0)(6).ToString() + "','" + tabla.Rows(0)(7).ToString() + "','" + tabla.Rows(0)(8).ToString() + "', " & _
                                                "'" + tabla.Rows(0)(9).ToString() + "','" + tabla.Rows(0)(10).ToString() + "','" + tabla.Rows(0)(11).ToString() + "', " & _
                                                "'" + tabla.Rows(0)(12).ToString() + "','" + tabla.Rows(0)(13).ToString() + "','" + valor_pallet.ToString() + "', " & _
                                                "'0','0','0','0','1','000','0','0','0','" + Val(numeropallet).ToString + "','0','" + usu_cod + "','" + DevuelveHora() + "','" + devuelve_fecha(Dt_fecha.Value) + "'," & _
                                                "'" + CajasRestantes.ToString + "','0')"

                            If fnc.MovimientoSQL(sql) > 0 Then
                                CargaGrilla()
                                txtpallet.Text = ""

                                'BLOQUEAR DE RACKDETA 
                                Dim _BLOQUEA_SOPORTANTE As String = "UPDATE rackdeta SET racd_estado='7', racd_pred='" + lblcodigo.Text + "' WHERE racd_codi='" + valor_pallet + "'"
                                fnc.MovimientoSQL(_BLOQUEA_SOPORTANTE)

                            End If
                            'FINNNNNN *****************************************
                        End If
                    Else
                        MsgBox("El pallet ingresado no es del cliente seleccionado", MsgBoxStyle.Critical, "Aviso")
                        txtpallet.Text = ""

                    End If
                Else
                    MsgBox("El pallet ya se despacho con anterioridad", MsgBoxStyle.Critical, "Aviso")
                    txtpallet.Text = ""

                End If
            Else
                MsgBox("El numero de pallet no existe", MsgBoxStyle.Critical, "Aviso")
                txtpallet.Text = ""

            End If

            If CbEtiq.Enabled = False AndAlso CbEtiq.Checked = True Then
                CbCant.Enabled = False
                Cant.Visible = False
            End If

            CbCant.CheckState = 1
        Else
            SoloNumeros(sender, e)
        End If


    End Sub

    Private Sub Cant_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cant.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub CbCant_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbCant.CheckStateChanged

        If CbCant.Checked = True Then
            If CbEtiq.Enabled = True Then
                Cant.Visible = False
                Cant.Text = ""
            Else
                Cant.Visible = False
            End If
        Else
            Cant.Visible = True
        End If

    End Sub

    Private Sub Frm_GuiaPreDespachoAgregar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'If e.KeyCode = Keys.F1 Then
        '    If RealizarAccion("002", "004") = False Then
        '        Exit Sub
        '    End If
        '    Dim frm As New Frm_GuiaPreDespachoRecupera
        '    frm.ShowDialog(Frm_Principal)
        '    If Frm_Principal.buscavalor <> "" Then
        '        Me.lblcodigo.Text = Frm_Principal.buscavalor.ToString()
        '        RescataTMPPreDespacho(lblcodigo.Text)
        '        btn_BuscaCliente.Enabled = False
        '        CbEtiq.Enabled = False
        '        Frm_Principal.buscavalor = ""
        '        BtnBuscar.Enabled = False
        '    End If
        'End If
    End Sub

    'Private Sub Btn_AnulaGuia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_AnulaGuia.Click

    '    If RealizarAccion("002", "005") = False Then
    '        Exit Sub
    '    End If

    '    Dim tabla As DataTable = fnc.ListarTablasSQL("SELECT fpre_codvig, fpre_activa FROM fichpred WHERE fpre_codi='" + lblcodigo.Text + "'")

    '    If tabla.Rows.Count > 0 Then
    '        If tabla.Rows(0)(0).ToString() = "0" Then
    '            If tabla.Rows(0)(1).ToString() = "1" Then
    '                MsgBox("No puede Anular un pre-despacho que esta siendo utilizado por otro usuario", MsgBoxStyle.Critical, "Aviso")
    '            Else
    '                If MsgBox("Seguro de anular la guia ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
    '                    Dim sql As String = "DELETE FROM fichpred WHERE fpre_codi='" + lblcodigo.Text + "'"
    '                    If fnc.MovimientoSQL(sql) > 0 Then

    '                        MsgBox("Documento Anulado", MsgBoxStyle.Information, "Aviso")

    '                        Dim Sql_Elimina_Rackdeta As String = "DELETE FROM detapred WHERE dpre_codi LIKE '" + lblcodigo.Text + "__%'"
    '                        fnc.MovimientoSQL(Sql_Elimina_Rackdeta)

    '                        Dim Sqlelimina As String = "DELETE FROM movpallet WHERE mov_tipo = 'PD' AND mov_Doc = '" + lblcodigo.Text + "'"
    '                        fnc.MovimientoSQL(Sqlelimina)


    '                        Dim Sql_PedCaja As String = "UPDATE pedcaja SET pc_estado='1' WHERE pc_codped='" + TxtNped.Text + "'"
    '                        fnc.MovimientoSQL(Sql_PedCaja)

    '                        Dim sql_fichapedido As String = "UPDATE pedidos_ficha SET Ped_EstPred='0' WHERE orden='" + TxtNped.Text + "'"
    '                        fnc.MovimientoSQL(sql_fichapedido)

    '                        limpiarformulario()
    '                    End If
    '                End If
    '            End If

    '        ElseIf tabla.Rows(0)(0).ToString() = "2" Then
    '            MsgBox("No se puede anular el pre-despacho ya que se encuentra despachado", MsgBoxStyle.Critical, "Aviso")

    '        Else
    '            MsgBox("El documento ya se encuentra anulado", MsgBoxStyle.Critical, "Aviso")
    '        End If
    '    End If
    'End Sub

    Private Sub CmboCarga_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmboCarga.KeyPress
        e.Handled = True
    End Sub

    Private Sub CbPedido_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbPedido.CheckStateChanged

        If CbPedido.CheckState = 1 AndAlso estcheck = True Then

            Dim sql As String = "SELECT Orden, pedido, fecha, Destino FROM  Pedidos_ficha WHERE cliente='" + txtrut.Text + "" + verificador.Text + "' AND fecha>=convert(date, getdate()) AND Ped_EstPred='0' ORDER BY Orden desc "
            Dim tabla_pedidos As DataTable = fnc.ListarTablasSQL(sql)

            If tabla_pedidos.Rows.Count = 0 Then
                CbPedido.Enabled = False
            End If

            '----------------
            'valor de retorno
            '----------------

            Dim frm As New Frm_ListadoPedidos
            frm.rutcli = txtrut.Text + "" + verificador.Text
            Dim res As DialogResult = frm.ShowDialog()

     

            Dim ValorRetorno As String = frm.codigoPedido.ToString()

            If ValorRetorno <> "0" Then
                TxtNped.Text = ValorRetorno
                'Dim sql_Actualiza As String = "UPDATE pedidos_ficha SET Ped_EstPred='1' WHERE orden='" + ValorRetorno + "'"
                Dim sql_Actualiza As String = "SP_Pedidos_Estados_Actualizar '" & ValorRetorno.Trim & "','P','1'"
                fnc.MovimientoSQL(sql_Actualiza)

                'select ordenconjunta from Pedidos_ficha
                Dim conjunto As String = "select ordenconjunta from Pedidos_ficha WHERE Orden='" + TxtNped.Text + "'  "
                Dim TABLAconj As DataTable = fnc.ListarTablasSQL(conjunto)

                ordenconjunta = TABLAconj.Rows(0)(0).ToString()

                If Trim(ordenconjunta) = "" Then

                    Dim PALLETS As String = "SELECT  pd.pallet FALTAN  FROM Pedidos_detalle pd INNER JOIN Pedidos_ficha pf ON pd.pedido=pf.pedido " & _
                    "WHERE Orden='" + ValorRetorno + "' ORDER BY pd.pallet "
                    Dim TABLA As DataTable = fnc.ListarTablasSQL(PALLETS)

                    Dim stringpallets As String = ""

                    Label10.Text = Label10.Text + "(" + (TABLA.Rows.Count).ToString() + ")"

                    For i As Integer = 0 To TABLA.Rows.Count - 1
                        stringpallets = stringpallets + "  -  " + TABLA.Rows(i)(0).ToString()
                    Next

                    Lblpalletsped.Text = stringpallets
                    Lblpalletsped.Visible = True
                    Timer2.Enabled = True
                    CbPedido.Enabled = False
                Else
                    MsgBox("Este Pedido se encuentra unido " + ordenconjunta, MsgBoxStyle.Information, "Aviso")
                    Dim PALLETS As String = "SELECT  pd.pallet FALTAN  FROM Pedidos_detalle pd INNER JOIN Pedidos_ficha pf ON pd.pedido=pf.pedido " & _
                      "WHERE ordenconjunta='" + ordenconjunta + "' ORDER BY pd.pallet "
                    Dim TABLA As DataTable = fnc.ListarTablasSQL(PALLETS)

                    Dim stringpallets As String = ""

                    Label10.Text = Label10.Text + "(" + (TABLA.Rows.Count).ToString() + ")"

                    For i As Integer = 0 To TABLA.Rows.Count - 1
                        stringpallets = stringpallets + "  -  " + TABLA.Rows(i)(0).ToString()
                    Next

                    Lblpalletsped.Text = stringpallets
                    Lblpalletsped.Visible = True
                    Timer2.Enabled = True

                End If
                

            Else
                TxtNped.Text = "0"
                CbPedido.Enabled = False
                CbPedido.Checked = False
            End If
        End If
    End Sub

    Private Sub CmboPedido_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If Lblpalletsped.Text.Length > 50 Then
            Dim TEXTO As String = Lblpalletsped.Text
            TEXTO = Lblpalletsped.Text.Remove(0, 1) + "" + Lblpalletsped.Text.Chars(0)
            Lblpalletsped.Text = TEXTO
        End If

    End Sub

    Private Sub CbEtiq_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbEtiq.CheckStateChanged
        If CbEtiq.Checked = True Then
            CbEtiq.Enabled = False
            CbCant.Enabled = False
        End If
    End Sub

    Private Sub Btn_AnulaGuia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_AnulaGuia.Click
        Dim tabla As DataTable = fnc.ListarTablasSQL("SELECT fpre_codvig, fpre_activa FROM fichpred WHERE fpre_codi='" + lblcodigo.Text + "'")

        If tabla.Rows.Count > 0 Then
            If tabla.Rows(0)(0).ToString() = "0" Then
                If tabla.Rows(0)(1).ToString() = "1" Then
                    MsgBox("No puede Anular un pre-despacho que esta siendo utilizado por otro usuario", MsgBoxStyle.Critical, "Aviso")
                Else
                    If MsgBox("Seguro de anular la guia ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                        Dim sql As String = "DELETE FROM fichpred WHERE fpre_codi='" + lblcodigo.Text + "'"
                        If fnc.MovimientoSQL(sql) > 0 Then

                            MsgBox("Documento Anulado", MsgBoxStyle.Information, "Aviso")

                            Dim Sql_Elimina_Rackdeta As String = "DELETE FROM detapred WHERE dpre_codi LIKE '" + lblcodigo.Text + "__%'"
                            fnc.MovimientoSQL(Sql_Elimina_Rackdeta)

                            Dim Sqlelimina As String = "DELETE FROM movpallet WHERE (mov_tipo = 'PD' OR mov_tipo='PR') AND mov_Doc = '" + lblcodigo.Text + "'"
                            fnc.MovimientoSQL(Sqlelimina)


                            Dim Sql_PedCaja As String = "UPDATE pedcaja SET pc_estado='1' WHERE pc_codped='" + TxtNped.Text + "'"
                            fnc.MovimientoSQL(Sql_PedCaja)

                            'Dim sql_fichapedido As String = "UPDATE pedidos_ficha SET Ped_EstPred='0' WHERE orden='" + TxtNped.Text + "'"
                            Dim sql_fichapedido As String = "SP_Pedidos_Estados_Actualizar '" & TxtNped.Text.Trim & "','P','0'"
                            fnc.MovimientoSQL(sql_fichapedido)

                            limpiarformulario()
                        End If
                    End If
                End If

            ElseIf tabla.Rows(0)(0).ToString() = "2" Then
                MsgBox("No se puede anular el pre-despacho ya que se encuentra despachado", MsgBoxStyle.Critical, "Aviso")

            Else
                MsgBox("El documento ya se encuentra anulado", MsgBoxStyle.Critical, "Aviso")
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TxtNped.Text = "2"
    End Sub
End Class