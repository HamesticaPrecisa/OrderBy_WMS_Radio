Public Class Frm_Repaletiza
    Dim fnc As New Funciones
    Dim con As New Conexion
    Dim palletori As String = ""
    Dim palletdest As String = ""
    Dim array() As String
    Dim camara As String = ""
    Dim banda As String = ""
    Dim columna As String = ""
    Dim piso As String = ""
    Dim nivel As String = ""
    Dim peso1 As String = ""
    Dim peso2 As String = ""
    Dim peso3 As String = ""
    Dim clienteorigen As String = ""
    Dim clientedestino As String = ""
    Dim productoorigen As String = ""
    Dim productodestino As String = ""
    Dim peosuma As Double
    Dim maxcajas As Int32 = 0
    Dim fechasugsino As String = ""
    Dim guardadestino As String = ""
    Dim cero As Int32 = 0
    Dim totalsuma As Int32 = 0

    Dim cantidadeorigen As String = ""

    Private Sub DetaRece_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Public Function TransformaPallet(ByVal pallet As String) As String

        Dim separado As String = ""
        Try
            For i As Integer = 11 To pallet.Length - 2
                separado = separado + pallet.Chars(i)
            Next
        Catch ex As ArgumentOutOfRangeException
            separado = ""
            Return separado
        End Try
        Return separado
    End Function

    Private Sub traecliorigen()
        Dim sql As String = "SELECT drec_rutcli,drec_codpro   " & _
                                        " from DetaRece  " & _
                                        "WHERE drec_codi='" + txtorigen.Text.Trim() + "'"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)


        If tabla.Rows.Count > 0 Then

            clienteorigen = tabla.Rows(0)(0).ToString()
            productoorigen = tabla.Rows(0)(1).ToString()

        End If


    End Sub
    Private Sub traeclidestino()
        Dim sql As String = "SELECT drec_rutcli,drec_codpro   " & _
                                        " from DetaRece  " & _
                                        "WHERE drec_codi='" + txtdestino.Text.Trim() + "'"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)


        If tabla.Rows.Count > 0 Then

            clientedestino = tabla.Rows(0)(0).ToString()
            productodestino = tabla.Rows(0)(1).ToString()


        End If


    End Sub

    Private Sub traevaloressug()
        Dim sql As String = "SELECT cli_maxcajas,cli_repafecha   " & _
                                     " from clientes  " & _
                                     "WHERE cli_rut='" + clienteorigen + "'"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)


        If tabla.Rows.Count > 0 Then
            maxcajas = Convert.ToInt32(tabla.Rows(0)(0).ToString())
            fechasugsino = tabla.Rows(0)(1).ToString()


        End If

    End Sub
    Private Sub traesugeridosinfecha()

        Dim sql As String = "SELECT racd_codi,racd_ca,racd_ba,racd_co,racd_pi,racd_ni  " & _
                                       " from vg_pallets_sugerir  " & _
                                       "WHERE drec_rutcli ='" + clienteorigen + "' and racd_codpro='" + productoorigen + "' and racd_unidades < " + Convert.ToInt32(maxcajas + lblcantori.Text).ToString() + " and racd_codi <> '" + txtorigen.Text.Trim() + "' "

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)


        If tabla.Rows.Count > 0 Then

            txtdestino.Text = tabla.Rows(0)(0).ToString()
            LBLPOS.Text = tabla.Rows(0)(1).ToString() + "-" + tabla.Rows(0)(2).ToString() + "-" + tabla.Rows(0)(3).ToString() + "-" + tabla.Rows(0)(4).ToString() + "-" + tabla.Rows(0)(5).ToString()
            txtdestino.Enabled = False
            'txtcaja.Focus()
            traedestino()

        End If




    End Sub

    Private Sub traesugeridosinfechaotro()

        Dim sql As String = "SELECT racd_codi,racd_ca,racd_ba,racd_co,racd_pi,racd_ni   " & _
                                       " from vg_pallets_sugerir  " & _
                                       "WHERE drec_rutcli ='" + clienteorigen + "' and racd_codpro='" + productoorigen + "' and racd_unidades < " + Convert.ToInt32(maxcajas + lblcantori.Text).ToString() + " and racd_codi <> '" + txtorigen.Text.Trim() + "' "

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)


        If tabla.Rows.Count > 0 Then

            txtdestino.Text = tabla.Rows(cero)(0).ToString()
            LBLPOS.Text = tabla.Rows(cero)(1).ToString() + "-" + tabla.Rows(cero)(2).ToString() + "-" + tabla.Rows(cero)(3).ToString() + "-" + tabla.Rows(cero)(4).ToString() + "-" + tabla.Rows(cero)(5).ToString()
            txtdestino.Enabled = False
           
            traedestino()
            cero = cero + 1
        End If




    End Sub

    Private Sub traesugeridoscount()

        Dim sql As String = "SELECT count(racd_codi) as total   " & _
                                       " from vg_pallets_sugerir  " & _
                                       "WHERE drec_rutcli ='" + clienteorigen + "' and racd_codpro='" + productoorigen + "' and racd_unidades < " + Convert.ToInt32(maxcajas + lblcantori.Text).ToString() + " and racd_codi <> '" + txtorigen.Text.Trim() + "' "

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)


        If tabla.Rows.Count > 0 Then

            totalsuma = Convert.ToInt32(tabla.Rows(0)(0).ToString())
        End If




    End Sub
    Private Sub txtorigen_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtorigen.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            Dim origen As String
            origen = TransformaPallet(txtorigen.Text)
            txtorigen.Text = origen
            traecliorigen()
            deletecajaspreventivo()

            If fnc.verificaExistenciaCondicional("rackdeta", " racd_codi='" + origen + "'") = True Then

                Dim sql As String = "SELECT COUNT(CAJ_COD) AS CANT  " & _
                               " from DetaReceCajas  " & _
                               "WHERE caj_Pcod='" + origen + "'"

                Dim tabla As DataTable = fnc.ListarTablasSQL(sql)


                If tabla.Rows.Count > 0 Then

                    RDMANUAL.Enabled = False
                    RDSUGERIDO.Enabled = False
                    txtorigen.Enabled = False
                    txtdestino.Focus()

                    If RDMANUAL.Checked = True Then

                        lblcantori.Text = tabla.Rows(0)(0).ToString()
                        cantidadeorigen = tabla.Rows(0)(0).ToString()

                    ElseIf RDSUGERIDO.Checked = True Then


                        lblcantori.Text = tabla.Rows(0)(0).ToString()
                        traevaloressug()

                        If fechasugsino <> "SI" Then
                            traesugeridoscount()
                            If totalsuma > 1 Then

                                btnotro.Enabled = True
                            Else
                                btnotro.Enabled = False

                            End If
                            traesugeridosinfecha()
                        End If

                    End If

                End If



            Else
                MsgBox("El soportante ingresado no existe", MsgBoxStyle.Critical, "Aviso")
                txtorigen.Text = ""
                txtorigen.Focus()
            End If


        Else
            fnc.SoloNumeros(sender, e)
        End If


    End Sub
    Private Sub traedestino()

        Dim sql As String = "SELECT COUNT(CAJ_COD) AS CANT  " & _
                             " from DetaReceCajas  " & _
                             "WHERE caj_Pcod='" + txtdestino.Text.Trim() + "'"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

    

        If tabla.Rows.Count > 0 Then

            lblcantdes.Text = tabla.Rows(0)(0).ToString()

            txtdestino.Enabled = False
            txtcaja.Focus()
        End If


    End Sub
    Private Sub Frm_Repaletiza_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        deletecajas()
        RDMANUAL.Checked = True
        txtorigen.Enabled = True
        txtdestino.Enabled = True
        txtorigen.Focus()
    End Sub

    Private Sub RDMANUAL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDMANUAL.CheckedChanged
        If RDMANUAL.Checked = True Then
            txtorigen.Enabled = True
            txtdestino.Enabled = True
            txtorigen.Focus()
        Else
            txtorigen.Enabled = True
            txtdestino.Enabled = True
            txtorigen.Focus()
        End If
    End Sub

    Private Sub txtdestino_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdestino.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            Dim destino As String
            destino = TransformaPallet(txtdestino.Text)
            txtdestino.Text = destino
            traeclidestino()


            If fnc.verificaExistenciaCondicional("rackdeta", " racd_codi='" + destino + "'") = True Then

                Dim sql As String = "SELECT COUNT(CAJ_COD) AS CANT  " & _
                                   " from DetaReceCajas  " & _
                                   "WHERE caj_Pcod='" + destino + "'"

                Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

                If txtorigen.Text.Trim() = txtdestino.Text.Trim() Then
                    txtdestino.Text = ""
                    txtdestino.Focus()
                    MsgBox("No puede seleccionar el mismo pallet como origen y destino", MsgBoxStyle.Critical, "Aviso")
                    Exit Sub
                End If

                If clientedestino <> clienteorigen Then
                    txtdestino.Text = ""
                    txtdestino.Focus()
                    MsgBox("No puede repaletizar con distintos clientes", MsgBoxStyle.Critical, "Aviso")
                    Exit Sub
                End If

                If productodestino <> productoorigen Then
                    MsgBox("ADVERTENCIA: Esta a punto de juntar productos diferentes", MsgBoxStyle.Information, "Aviso")
                End If


                If tabla.Rows.Count > 0 Then
                    lblcantdes.Text = tabla.Rows(0)(0).ToString()
                    txtdestino.Enabled = False
                    txtcaja.Focus()
                End If
            Else
                MsgBox("El soportante ingresado no existe", MsgBoxStyle.Critical, "Aviso")
                txtdestino.Text = ""
                txtdestino.Focus()
            End If


        Else
            fnc.SoloNumeros(sender, e)
        End If

    End Sub

    Private Sub btn_bien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btn_mal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtcaja_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcaja.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            btn_mal.Visible = False
            btn_bien.Visible = False
            Dim sql As String = "SELECT CAJ_COD   " & _
                                       " from DetaReceCajas  " & _
                                       "WHERE caj_cod='" + txtcaja.Text.Trim() + "' and caj_pcod ='" + txtorigen.Text.Trim() + "' "

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)


            If tabla.Rows.Count > 0 Then



                Dim sql2 As String = " SELECT cod_caja   " & _
                                     " FROM TMP_CAJAS  " & _
                                     " WHERE cod_caja='" + txtcaja.Text.Trim() + "' AND cod_origen='" + txtorigen.Text.Trim() + "' AND cod_destino='" + txtdestino.Text.Trim() + "'"

                Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)


                If tabla2.Rows.Count > 0 Then
                    btn_mal.Visible = True
                    txtcaja.Text = ""
                    txtcaja.Focus()

                Else
                    Dim sqlInsert As String = " INSERT INTO tmp_cajas(cod_caja,cod_origen,cod_destino) values ('" + txtcaja.Text + "','" + txtorigen.Text + "','" + txtdestino.Text + "')"

                    If fnc.MovimientoSQL(sqlInsert) > 0 Then

                        Dim orican As Int32 = Convert.ToInt32(lblcantori.Text)
                        Dim descan As Int32 = Convert.ToInt32(lblcantdes.Text)
                        orican = orican - 1
                        descan = descan + 1
                        lblcantori.Text = orican.ToString()
                        lblcantdes.Text = descan.ToString()
                        If orican = 0 Then
                            If descan <> 0 Then

                                txtconfdest.Enabled = True


                            End If
                          
                        End If
                        btn_bien.Visible = True
                        txtcaja.Text = ""
                        txtcaja.Focus()
                        If orican = 0 Then
                            If descan <> 0 Then
                                txtconfdest.Focus()
                            End If
                        End If

                    Else
                        MsgBox("Ocurrio un error al guardar vuelve a intentar ", MsgBoxStyle.Critical, "Aviso")

                    End If


                    End If

                    Else
                    btn_mal.Visible = True
                    txtcaja.Text = ""
                    txtcaja.Focus()

                    End If
        End If
    End Sub

    Private Sub txtconfdest_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtconfdest.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            Dim confirmar As String
            confirmar = TransformaPallet(txtconfdest.Text)
            txtconfdest.Text = confirmar

            If fnc.verificaExistenciaCondicional("rackdeta", " racd_codi='" + confirmar + "'") = True Then

                Dim sql As String = "SELECT CAJ_pCOD   " & _
                                   " from DetaReceCajas  " & _
                                   "WHERE caj_Pcod='" + confirmar + "'"

                Dim tabla As DataTable = fnc.ListarTablasSQL(sql)


                If tabla.Rows.Count > 0 Then
                    If txtdestino.Text = txtconfdest.Text Then
                        txtconfdest.Text = tabla.Rows(0)(0).ToString()
                        btnok.Enabled = True
                        txtconfdest.Enabled = False
                        btnnodestino.Visible = False
                    Else
                        btnnodestino.Visible = True
                        txtconfdest.Text = ""
                        txtconfdest.Focus()
                    End If
                End If
            Else
                MsgBox("Soportante ingresado no existe", MsgBoxStyle.Critical, "Aviso")
                txtconfdest.Text = ""
                txtconfdest.Focus()
            End If


        Else
            fnc.SoloNumeros(sender, e)
        End If
    End Sub

    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        If txtorigen.Text <> "" Then

            If txtdestino.Text <> "" Then


                If lblcantori.Text = "0" Then

                    If lblcantdes.Text <> "0" Then
                        sumapeso()
                        insertmovpallet()
                        deleterackdeta()
                        updaterackdeta()


                        Dim sql As String = " SELECT cod_caja   " & _
                                            " FROM TMP_CAJAS " & _
                                            " WHERE cod_origen='" + txtorigen.Text.Trim() + "' AND " & _
                                            " cod_destino='" + txtdestino.Text.Trim() + "'"

                        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)


                        For i As Integer = 0 To tabla.Rows.Count - 1
                            Dim SqlCambiaestado As String = "UPDATE detarececajas SET caj_pcod='" + txtdestino.Text.Trim() + "' WHERE caj_cod='" + tabla.Rows(i)(0).ToString() + "' AND caj_pcod='" + txtorigen.Text.Trim() + "'"
                            fnc.MovimientoSQL(SqlCambiaestado)
                        Next

                        MsgBox("Soportante repaletizado correctamente", MsgBoxStyle.Information, "Aviso")
                        lim()
                    End If
                End If
            End If
        End If
      
    End Sub

    Private Sub updaterackdeta()

        Dim SqlCambiaestado As String = "UPDATE rackdeta SET racd_unidades='" + lblcantdes.Text.Trim() + "',racd_peso='" + peosuma.ToString().Replace(",", ".") + "' WHERE racd_codi='" + txtdestino.Text.Trim() + "'"
        fnc.MovimientoSQL(SqlCambiaestado)

    End Sub


    Private Sub deleterackdeta()
        Dim _Delete As String = "DELETE FROM rackdeta WHERE racd_codi='" + txtorigen.Text.Trim() + "'"
        fnc.MovimientoSQL(_Delete)



    End Sub
    Private Sub deletecajas()

        Dim _Delete As String = "DELETE FROM tmp_cajas WHERE cod_origen='" + txtorigen.Text.Trim() + "' AND cod_destino='" + txtdestino.Text.Trim() + "'"
        fnc.MovimientoSQL(_Delete)

    End Sub

    Private Sub deletecajaspreventivo()

        Dim _Delete As String = "DELETE FROM tmp_cajas WHERE cod_origen='" + txtorigen.Text.Trim() + "'"
        fnc.MovimientoSQL(_Delete)

    End Sub

    Private Sub sumapeso()
        Dim sql As String = "SELECT racd_peso from rackdeta where racd_codi = '" + txtorigen.Text.Trim() + "'"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)


        If tabla.Rows.Count > 0 Then

            peso1 = tabla.Rows(0)(0).ToString()

        End If
        Dim sql2 As String = "SELECT racd_peso from rackdeta where racd_codi = '" + txtdestino.Text.Trim() + "'"

        Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)


        If tabla2.Rows.Count > 0 Then

            peso2 = tabla2.Rows(0)(0).ToString()

        End If
        Dim pesod1 As Double = Convert.ToDouble(peso1)
        Dim pesod2 As Double = Convert.ToDouble(peso2)


        peosuma = pesod1 + pesod2




    End Sub


    Private Sub insertmovpallet()


        Dim _MovPallet As String = "INSERT INTO movpallet(mov_doc,mov_folio, mov_codper, mov_fecha, mov_tipo, mov_hora, " & _
                         " mov_saldo,mov_despacho)VALUES('" + txtdestino.Text.Trim() + "','" + txtorigen.Text.Trim() + "'," & _
                         "'" + Convert.ToString(id_global) + "',REPLACE(CAST(CONVERT(CHAR(10), GETDATE(), 103) AS DATE),'-','/'),'SR','" + DevuelveHora() + "', " & _
                         "'" + lblcantori.Text.Trim() + "','" + cantidadeorigen + "')"

        fnc.MovimientoSQL(_MovPallet)

        Dim sql As String = "SELECT racd_ca, racd_Ba, racd_Co, racd_Pi, racd_Ni, drec_rev " & _
                                   "FROM rackdeta INNER JOIN detarece ON drec_codi=racd_codi " & _
                                   "WHERE racd_codi='" + txtorigen.Text.Trim() + "'"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)


        If tabla.Rows.Count > 0 Then

            camara = tabla.Rows(0)(0).ToString()
            banda = tabla.Rows(0)(1).ToString()
            columna = tabla.Rows(0)(2).ToString()
            piso = tabla.Rows(0)(3).ToString()
            nivel = tabla.Rows(0)(4).ToString()
        End If
        Dim _MovPallet2 As String = "INSERT INTO movpallet(mov_doc,mov_folio, mov_codper, mov_fecha, mov_tipo, mov_hora, mov_ca, " & _
                        "mov_ba, mov_co, mov_pi, mov_ni, mov_unidped, mov_saldo,mov_despacho)VALUES('" + txtorigen.Text.Trim() + "','" + txtdestino.Text.Trim() + "'," & _
                        "'" + Convert.ToString(id_global) + "',REPLACE(CAST(CONVERT(CHAR(10), GETDATE(), 103) AS DATE),'-','/'),'RI','" + DevuelveHora() + "','" + camara + "'," & _
                        "'" + banda + "','" + columna + "','" + piso + "','" + nivel + "', " & _
                        "'0','" + lblcantdes.Text.Trim() + "','" + cantidadeorigen + "')"

        fnc.MovimientoSQL(_MovPallet2)




    End Sub
    Private Sub lim()
        deletecajas()
        If RDMANUAL.Checked = True Then
            txtorigen.Enabled = True
            txtdestino.Enabled = True

        Else
            txtorigen.Enabled = True
        End If
        cantidadeorigen = "0"
        txtorigen.Text = ""
        txtdestino.Text = ""
        lblcantori.Text = "0"
        lblcantdes.Text = "0"
        txtcaja.Text = ""
        txtcaja.Enabled = True
        txtconfdest.Enabled = False
        btnok.Enabled = False
        btnotro.Enabled = False
        txtconfdest.Text = ""
        txtorigen.Focus()
        RDMANUAL.Enabled = True
        RDSUGERIDO.Enabled = True
    End Sub
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        lim()
    End Sub

    Private Sub RDSUGERIDO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDSUGERIDO.CheckedChanged

    End Sub

    Private Sub Frm_Repaletiza_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        deletecajas()
    End Sub

    Private Sub Frm_Repaletiza_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        deletecajas()
    End Sub

    Private Sub btnotro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnotro.Click
        If cero = totalsuma Then
            cero = 0
        End If

     

        Dim sql As String = "SELECT COUNT(CAJ_COD) AS CANT  " & _
                             " from DetaReceCajas  " & _
                             "WHERE caj_Pcod='" + txtorigen.Text.Trim() + "'"


        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)


        If tabla.Rows.Count > 0 Then
            traecliorigen()

            If RDMANUAL.Checked = True Then

                lblcantori.Text = tabla.Rows(0)(0).ToString()
                cantidadeorigen = tabla.Rows(0)(0).ToString()
                txtorigen.Enabled = False
                txtdestino.Focus()

            ElseIf RDSUGERIDO.Checked = True Then


                lblcantori.Text = tabla.Rows(0)(0).ToString()
                traevaloressug()

                If fechasugsino = "SI" Then

                Else
                    traesugeridoscount()
                    If totalsuma > 1 Then

                        btnotro.Enabled = True
                    Else
                        btnotro.Enabled = False

                    End If
                    traesugeridosinfechaotro()

                End If





            End If











        End If
    End Sub
End Class