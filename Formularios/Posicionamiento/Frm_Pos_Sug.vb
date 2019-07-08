Imports System.Data.SqlClient
Imports System.Runtime.InteropServices

Public Class Frm_Pos_Sug

    Dim fnc As New Funciones
    Dim con As New Conexion

    Dim CERO As Integer = 0
    Dim CEROMAX As Integer = 0
    Dim camara As String = ""
    Dim banda As String = ""
    Dim columna As String = ""
    Dim piso As String = ""
    Dim nivel As String = ""
    Dim PUERTA As String = ""
    Dim cordenada As String = ""
    Public usuario As String = ""
    Public cargo As String = ""
    Public perfil As String = ""
    Public codigo As String = ""
    Dim codigo_pallet As String = ""
    Dim impnac As String = ""
    Dim anden As String = ""
    Dim cli As String = ""
    Dim pro As String = ""
    Dim PALLETGLOBAL As String = ""
    Public accion As Integer = 0

    Function DigitoVerificador(ByVal numero As String) As Integer


        Dim separado(12) As String
        Dim valores(12) As Integer

        Dim suma As Integer = 0

        For i As Integer = 0 To numero.Length - 1
            separado(i) = numero.Chars(i)
        Next

        For i As Integer = 0 To separado.Length - 1
            If i Mod 2 = 0 Then
                suma = Convert.ToInt32(suma + (Val(separado(i)) * 1))
            Else
                suma = Convert.ToInt32(suma + (Val(separado(i)) * 3))
            End If
        Next

        Dim multiplo As Integer = 0

        For i As Integer = 0 To suma Step 10
            multiplo = multiplo + 10
        Next

        Dim verificador As Integer = multiplo - suma

        'txtposicion.Text = numero + "" + verificador.ToString()
        txtposicion.Focus()
        Return verificador
    End Function

    Public Function TransformaPallet(ByVal pallet As String) As String

        Dim separado As String = ""
        For i As Integer = 11 To pallet.Length - 2
            separado = separado + pallet.Chars(i)
        Next
        txtpalet.Text = separado
        Return separado
    End Function

    Public Sub variables()
        camara = txtcamara.Text
        banda = txtbanda.Text
        columna = txtcolumna.Text

        If Len(txtpiso.Text) = 1 Then
            piso = "0" + txtpiso.Text
        Else
            piso = txtpiso.Text
        End If

        nivel = txtnivel.Text

        If Len(Me.codigo) = 1 Then
            Me.codigo = "00" + codigo
        ElseIf Len(Me.codigo) = 2 Then
            Me.codigo = "0" + codigo
        End If
    End Sub

    Public Function verificarPosicion() As Integer

        Dim retorno As Integer = 0

        Dim sql As String = "SELECT * FROM rackdeta WHERE racd_ca='" + txtcamara2.Text + "' AND racd_ba='" + txtbanda2.Text + "' AND " & _
        "racd_co='" + txtcolumna2.Text + "' AND racd_pi='" + txtpiso2.Text + "' AND racd_ni='" + txtnivel2.Text + "' AND racd_codi<>'" + txtpallete.Text + "'"

        Dim Sql_Ocupada As String = "SELECT racd_ni,racd_codi FROM rackdeta WHERE racd_ca='" + txtcamara2.Text + "' AND racd_ba='" + txtbanda2.Text + "' AND " & _
        "racd_co='" + txtcolumna2.Text + "' AND racd_pi='" + txtpiso2.Text + "' AND racd_codi<>'" + txtpallete.Text + "' "

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        Dim tabla_ocupada As DataTable = fnc.ListarTablasSQL(Sql_Ocupada)

        If tabla_ocupada.Rows.Count > 0 Then
            If tabla_ocupada.Rows(0)(0).ToString() = "F" Or tabla_ocupada.Rows(0)(0).ToString() = "f" Then
                lmensaje.Text = "Posicion ocupada por pallet " & tabla_ocupada.Rows(0)(1).ToString()
                retorno = 1
            ElseIf tabla_ocupada.Rows(0)(0).ToString() = "1" AndAlso txtnivel.Text = "1" Then
                lmensaje.Text = "Posicion ocupada por pallet " & tabla_ocupada.Rows(0)(1).ToString()
                retorno = 1
            ElseIf tabla_ocupada.Rows(0)(0).ToString() = "2" AndAlso txtnivel.Text = "2" Then
                lmensaje.Text = "Posicion ocupada por pallet " & tabla_ocupada.Rows(0)(1).ToString()
                retorno = 1
            ElseIf tabla_ocupada.Rows(0)(0).ToString() = "" Then
                MsgBox("Posicion ocupada por pallet " & tabla_ocupada.Rows(0)(1).ToString(), MsgBoxStyle.Critical, "Aviso")
                retorno = 1
            End If
        End If

        Dim Sql_tip As String = "SELECT libre FROM camaraconf WHERE camara='" + txtcamara2.Text.Trim() + "' "

        Dim tablatip As DataTable = fnc.ListarTablasSQL(Sql_tip)

        If tabla.Rows.Count > 0 Then


            If tablatip.Rows.Count > 0 Then


                If tablatip.Rows(0)(0).ToString().Trim() = "SI" Then
                    retorno = 0

                Else
                    If txtcolumna.Text = "00" Then
                        retorno = 0
                    Else
                        lmensaje.Text = "Posición ocupada por el pallet Nº " + tabla.Rows(0)(1).ToString()
                        BtnLiberar.Visible = True
                        codigo_pallet = tabla.Rows(0)(1).ToString()
                        retorno = 1
                    End If


                End If
            End If
        End If

        Return retorno
    End Function

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '---->
        Dim sql As String = "SELECT pos_camara, pos_banda, pos_nivel WHERE pos_codigo='" + txtposicion.Text + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        If tabla.Rows.Count > 0 Then
            txtcamara.Text = tabla.Rows(0)(0).ToString()
            txtbanda.Text = tabla.Rows(0)(1).ToString()
            txtcolumna.Text = tabla.Rows(0)(2).ToString()
        End If
        '---->
    End Sub
    Private Sub sugerido_pos()
        Dim cam As String = ""
        Dim sql As String = "SELECT frec_tiporecepcion,drec_codpro,drec_rutcli,frec_antecamara" & _
                                   "   FROM vg_detarecesug " & _
                                   "WHERE drec_codi='" + PALLETGLOBAL + "'"
        txtpallete.Text = PALLETGLOBAL
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)


        If tabla.Rows.Count > 0 Then

            impnac = tabla.Rows(0)(0).ToString().Trim()

            If impnac = "1" Then
                impnac = "NACIONAL"
            End If
            If impnac = "2" Then
                impnac = "IMPORTACION"
            End If
            If impnac = "3" Then
                impnac = "NACIONAL"
            End If
            pro = tabla.Rows(0)(1).ToString().Trim()
            cli = tabla.Rows(0)(2).ToString().Trim()
            anden = tabla.Rows(0)(3).ToString().Trim()

            If anden = "71" Or anden = "72" Or anden = "73" Or anden = "74" Then

                '   anden = " AND (Camara = '01' OR Camara = '02' OR Camara = '03' OR Camara = '04') "
                anden = " AND (camara='" + ComboBox1.Text + "') "
            End If
            If anden = "75" Or anden = "76" Then
                ' anden = " AND (Camara = '05' OR Camara = '06') "
                anden = " AND (camara='" + ComboBox1.Text + "') "
            End If


        End If

        Dim sql2 As String = "SELECT * " & _
                                   "   FROM vg_pos_sugeridas " & _
                                   "WHERE imp_nac ='" + impnac + "' and reserva_producto='" + pro + "' and reserva_cliente='" + cli + "' " + anden

        Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)


        If tabla2.Rows.Count > 0 Then


            'ACA SI TIENE TOdo
            Dim sqll As String = "SELECT count(*) " & _
                                 "   FROM vg_pos_sugeridas " & _
                                 "WHERE imp_nac ='" + impnac + "' and reserva_producto='" + pro + "' and reserva_cliente='" + cli + "' " + anden

            Dim tablaa As DataTable = fnc.ListarTablasSQL(sqll)


            If tablaa.Rows.Count > 0 Then
                CEROMAX = Convert.ToInt32(tablaa.Rows(0)(0).ToString())

                If CEROMAX < CERO Then
                    lmensaje.Text = "No Más Sugerencias"
                    Exit Sub

                End If
            End If


            PUERTA = tabla2.Rows(CERO)(15).ToString().Trim()
            If PUERTA = "P1" Or PUERTA = "P2" Then

                Dim SD As String = "SELECT * " & _
                                  "  FROM vg_pos_sugeridas " & _
                                  "WHERE imp_nac ='" + impnac + "' and reserva_producto='" + pro + "' and reserva_cliente='" + cli + "' " + anden + " ORDER BY LEFT(Cordenada,1), case when isnumeric(substring(Cordenada,2,100))=1 then cast(substring(Cordenada,2,100) as int) else cast(left(substring(Cordenada,2,100),len(substring(Cordenada,2,100))-1) as int) end ASC"

                Dim TD As DataTable = fnc.ListarTablasSQL(SD)


                If TD.Rows.Count > 0 Then
                    txtcamara2.Text = TD.Rows(CERO)(0).ToString().Trim()
                    txtbanda2.Text = TD.Rows(CERO)(1).ToString().Trim()
                    txtcolumna2.Text = TD.Rows(CERO)(2).ToString().Trim()
                    txtpiso2.Text = TD.Rows(CERO)(3).ToString().Trim()
                    txtnivel2.Enabled = False
                    txtnivel2.Text = "F"
                End If

            Else
                Dim SD As String = "SELECT * " & _
                              "  FROM vg_pos_sugeridas " & _
                              "WHERE imp_nac ='" + impnac + "' and reserva_producto='" + pro + "' and reserva_cliente='" + cli + "' " + anden + " ORDER BY LEFT(Cordenada,1), case when isnumeric(substring(Cordenada,2,100))=1 then cast(substring(Cordenada,2,100) as int) else cast(left(substring(Cordenada,2,100),len(substring(Cordenada,2,100))-1) as int) end DESC"

                Dim TD As DataTable = fnc.ListarTablasSQL(SD)


                If TD.Rows.Count > 0 Then
                    txtcamara2.Text = TD.Rows(CERO)(0).ToString().Trim()
                    txtbanda2.Text = TD.Rows(CERO)(1).ToString().Trim()
                    txtcolumna2.Text = TD.Rows(CERO)(2).ToString().Trim()
                    txtpiso2.Text = TD.Rows(CERO)(3).ToString().Trim()
                    txtnivel2.Enabled = False
                    txtnivel2.Text = "F"

                End If





            End If

        Else


            Dim sql3 As String = "SELECT * " & _
                            "  FROM vg_pos_sugeridas " & _
                            "WHERE imp_nac ='" + impnac + "' and reserva_producto='" + pro + "'" + anden

            Dim tabla3 As DataTable = fnc.ListarTablasSQL(sql3)


            If tabla3.Rows.Count > 0 Then

                'ACA SI TIENE IMPNAC Y PRODUCTO 
                Dim sqll As String = "SELECT count(*) " & _
                                 "  FROM vg_pos_sugeridas " & _
                     "WHERE imp_nac ='" + impnac + "' and reserva_producto='" + pro + "'" + anden

                Dim tablaa As DataTable = fnc.ListarTablasSQL(sqll)


                If tablaa.Rows.Count > 0 Then
                    CEROMAX = Convert.ToInt32(tablaa.Rows(0)(0).ToString())

                    If CEROMAX < CERO Then
                        lmensaje.Text = "No Más Sugerencias"
                        Exit Sub

                    End If
                End If
                PUERTA = tabla3.Rows(CERO)(15).ToString().Trim()
                If PUERTA = "P1" Or PUERTA = "P2" Then

                    Dim SD As String = "SELECT * " & _
                                      "  FROM vg_pos_sugeridas " & _
                                      "WHERE imp_nac ='" + impnac + "' and reserva_producto='" + pro + "'" + anden + " ORDER BY LEFT(Cordenada,1), case when isnumeric(substring(Cordenada,2,100))=1 then cast(substring(Cordenada,2,100) as int) else cast(left(substring(Cordenada,2,100),len(substring(Cordenada,2,100))-1) as int) end ASC"

                    Dim TD As DataTable = fnc.ListarTablasSQL(SD)


                    If TD.Rows.Count > 0 Then
                        txtcamara2.Text = TD.Rows(CERO)(0).ToString().Trim()
                        txtbanda2.Text = TD.Rows(CERO)(1).ToString().Trim()
                        txtcolumna2.Text = TD.Rows(CERO)(2).ToString().Trim()
                        txtpiso2.Text = TD.Rows(CERO)(3).ToString().Trim()
                        txtnivel2.Enabled = False
                        txtnivel2.Text = "F"
                    End If

                Else
                    Dim SD As String = "SELECT * " & _
                                  "  FROM vg_pos_sugeridas " & _
                                  "WHERE imp_nac ='" + impnac + "' and reserva_producto='" + pro + "'" + anden + " ORDER BY LEFT(Cordenada,1), case when isnumeric(substring(Cordenada,2,100))=1 then cast(substring(Cordenada,2,100) as int) else cast(left(substring(Cordenada,2,100),len(substring(Cordenada,2,100))-1) as int) end DESC"

                    Dim TD As DataTable = fnc.ListarTablasSQL(SD)


                    If TD.Rows.Count > 0 Then
                        txtcamara2.Text = TD.Rows(CERO)(0).ToString().Trim()
                        txtbanda2.Text = TD.Rows(CERO)(1).ToString().Trim()
                        txtcolumna2.Text = TD.Rows(CERO)(2).ToString().Trim()
                        txtpiso2.Text = TD.Rows(CERO)(3).ToString().Trim()
                        txtnivel2.Enabled = False
                        txtnivel2.Text = "F"

                    End If





                End If
            Else


                Dim sql4 As String = "SELECT * " & _
                                "  FROM vg_pos_sugeridas " & _
                                "WHERE imp_nac ='" + impnac + "' and reserva_cliente='" + cli + "'" + anden

                Dim tabla4 As DataTable = fnc.ListarTablasSQL(sql4)


                If tabla4.Rows.Count > 0 Then

                    'ACA SI TIENE IMPCA Y CLI 
                    Dim sqll As String = "SELECT count(*) " & _
                               "  FROM vg_pos_sugeridas " & _
                            "WHERE imp_nac ='" + impnac + "' and reserva_cliente='" + cli + "'" + anden

                    Dim tablaa As DataTable = fnc.ListarTablasSQL(sqll)


                    If tablaa.Rows.Count > 0 Then
                        CEROMAX = Convert.ToInt32(tablaa.Rows(0)(0).ToString())

                        If CEROMAX < CERO Then
                            lmensaje.Text = "No Más Sugerencias"
                            Exit Sub

                        End If
                    End If
                    PUERTA = tabla4.Rows(CERO)(15).ToString().Trim()
                    If PUERTA = "P1" Or PUERTA = "P2" Then

                        Dim SD As String = "SELECT * " & _
                                          "  FROM vg_pos_sugeridas " & _
                                          "WHERE imp_nac ='" + impnac + "' and reserva_cliente='" + cli + "' " + anden + " ORDER BY LEFT(Cordenada,1), case when isnumeric(substring(Cordenada,2,100))=1 then cast(substring(Cordenada,2,100) as int) else cast(left(substring(Cordenada,2,100),len(substring(Cordenada,2,100))-1) as int) end ASC"

                        Dim TD As DataTable = fnc.ListarTablasSQL(SD)


                        If TD.Rows.Count > 0 Then
                            txtcamara2.Text = TD.Rows(CERO)(0).ToString().Trim()
                            txtbanda2.Text = TD.Rows(CERO)(1).ToString().Trim()
                            txtcolumna2.Text = TD.Rows(CERO)(2).ToString().Trim()
                            txtpiso2.Text = TD.Rows(CERO)(3).ToString().Trim()
                            txtnivel2.Enabled = False
                            txtnivel2.Text = "F"
                        End If

                    Else
                        Dim SD As String = "SELECT * " & _
                                      "  FROM vg_pos_sugeridas " & _
                                      "WHERE imp_nac ='" + impnac + "'  and reserva_cliente='" + cli + "' " + anden + " ORDER BY LEFT(Cordenada,1), case when isnumeric(substring(Cordenada,2,100))=1 then cast(substring(Cordenada,2,100) as int) else cast(left(substring(Cordenada,2,100),len(substring(Cordenada,2,100))-1) as int) end DESC"

                        Dim TD As DataTable = fnc.ListarTablasSQL(SD)


                        If TD.Rows.Count > 0 Then
                            txtcamara2.Text = TD.Rows(CERO)(0).ToString().Trim()
                            txtbanda2.Text = TD.Rows(CERO)(1).ToString().Trim()
                            txtcolumna2.Text = TD.Rows(CERO)(2).ToString().Trim()
                            txtpiso2.Text = TD.Rows(CERO)(3).ToString().Trim()
                            txtnivel2.Enabled = False
                            txtnivel2.Text = "F"

                        End If





                    End If
                Else

                    Dim sql5 As String = "SELECT * " & _
                            "  FROM vg_pos_sugeridas " & _
                            "WHERE reserva_producto='" + pro + "'  and reserva_cliente='" + cli + "'  " + anden

                    Dim tabla5 As DataTable = fnc.ListarTablasSQL(sql3)


                    If tabla5.Rows.Count > 0 Then
                        ' ACA SI TIENE PRO Y CLI 
                        Dim sqll As String = "SELECT count(*) " & _
                              "  FROM vg_pos_sugeridas " & _
                                "WHERE reserva_producto='" + pro + "'  and reserva_cliente='" + cli + "'  " + anden

                        Dim tablaa As DataTable = fnc.ListarTablasSQL(sqll)


                        If tablaa.Rows.Count > 0 Then
                            CEROMAX = Convert.ToInt32(tablaa.Rows(0)(0).ToString())

                            If CEROMAX < CERO Then
                                lmensaje.Text = "No Más Sugerencias"
                                Exit Sub

                            End If
                        End If
                        PUERTA = tabla5.Rows(CERO)(15).ToString().Trim()
                        If PUERTA = "P1" Or PUERTA = "P2" Then

                            Dim SD As String = "SELECT * " & _
                                              "  FROM vg_pos_sugeridas " & _
                                              "WHERE reserva_producto='" + pro + "' and reserva_cliente='" + cli + "' " + anden + " ORDER BY LEFT(Cordenada,1), case when isnumeric(substring(Cordenada,2,100))=1 then cast(substring(Cordenada,2,100) as int) else cast(left(substring(Cordenada,2,100),len(substring(Cordenada,2,100))-1) as int) end ASC"

                            Dim TD As DataTable = fnc.ListarTablasSQL(SD)


                            If TD.Rows.Count > 0 Then
                                txtcamara2.Text = TD.Rows(CERO)(0).ToString().Trim()
                                txtbanda2.Text = TD.Rows(CERO)(1).ToString().Trim()
                                txtcolumna2.Text = TD.Rows(CERO)(2).ToString().Trim()
                                txtpiso2.Text = TD.Rows(CERO)(3).ToString().Trim()
                                txtnivel2.Enabled = False
                                txtnivel2.Text = "F"
                            End If

                        Else
                            Dim SD As String = "SELECT * " & _
                                          "  FROM vg_pos_sugeridas " & _
                                          "WHERE  reserva_producto='" + pro + "' and reserva_cliente='" + cli + "' " + anden + " ORDER BY LEFT(Cordenada,1), case when isnumeric(substring(Cordenada,2,100))=1 then cast(substring(Cordenada,2,100) as int) else cast(left(substring(Cordenada,2,100),len(substring(Cordenada,2,100))-1) as int) end DESC"

                            Dim TD As DataTable = fnc.ListarTablasSQL(SD)


                            If TD.Rows.Count > 0 Then
                                txtcamara2.Text = TD.Rows(CERO)(0).ToString().Trim()
                                txtbanda2.Text = TD.Rows(CERO)(1).ToString().Trim()
                                txtcolumna2.Text = TD.Rows(CERO)(2).ToString().Trim()
                                txtpiso2.Text = TD.Rows(CERO)(3).ToString().Trim()
                                txtnivel2.Enabled = False
                                txtnivel2.Text = "F"

                            End If





                        End If



                    Else


                        Dim sql6 As String = "SELECT * " & _
                                        "  FROM vg_pos_sugeridas " & _
                                        "WHERE imp_nac ='" + impnac + "'" + anden

                        Dim tabla6 As DataTable = fnc.ListarTablasSQL(sql6)


                        If tabla6.Rows.Count > 0 Then
                            'ACA SOLO SI TIENE IMPNAC

                            Dim sqll As String = "SELECT count(*) " & _
                             "  FROM vg_pos_sugeridas " & _
                              "WHERE imp_nac ='" + impnac + "'" + anden

                            Dim tablaa As DataTable = fnc.ListarTablasSQL(sqll)


                            If tablaa.Rows.Count > 0 Then
                                CEROMAX = Convert.ToInt32(tablaa.Rows(0)(0).ToString())

                                If CEROMAX < CERO Then
                                    lmensaje.Text = "No Más Sugerencias"
                                    Exit Sub

                                End If
                            End If
                            PUERTA = tabla6.Rows(CERO)(15).ToString().Trim()
                            If PUERTA = "P1" Or PUERTA = "P2" Then

                                Dim SD As String = "SELECT * " & _
                                                  "  FROM vg_pos_sugeridas " & _
                                                  "WHERE imp_nac ='" + impnac + "'" + anden + " ORDER BY LEFT(Cordenada,1), case when isnumeric(substring(Cordenada,2,100))=1 then cast(substring(Cordenada,2,100) as int) else cast(left(substring(Cordenada,2,100),len(substring(Cordenada,2,100))-1) as int) end ASC"

                                Dim TD As DataTable = fnc.ListarTablasSQL(SD)


                                If TD.Rows.Count > 0 Then
                                    txtcamara2.Text = TD.Rows(CERO)(0).ToString().Trim()
                                    txtbanda2.Text = TD.Rows(CERO)(1).ToString().Trim()
                                    txtcolumna2.Text = TD.Rows(CERO)(2).ToString().Trim()
                                    txtpiso2.Text = TD.Rows(CERO)(3).ToString().Trim()
                                    txtnivel2.Enabled = False
                                    txtnivel2.Text = "F"
                                End If

                            Else
                                Dim SD As String = "SELECT * " & _
                                              "  FROM vg_pos_sugeridas " & _
                                              "WHERE imp_nac ='" + impnac + "'  " + anden + " ORDER BY LEFT(Cordenada,1), case when isnumeric(substring(Cordenada,2,100))=1 then cast(substring(Cordenada,2,100) as int) else cast(left(substring(Cordenada,2,100),len(substring(Cordenada,2,100))-1) as int) end DESC"

                                Dim TD As DataTable = fnc.ListarTablasSQL(SD)


                                If TD.Rows.Count > 0 Then
                                    txtcamara2.Text = TD.Rows(CERO)(0).ToString().Trim()
                                    txtbanda2.Text = TD.Rows(CERO)(1).ToString().Trim()
                                    txtcolumna2.Text = TD.Rows(CERO)(2).ToString().Trim()
                                    txtpiso2.Text = TD.Rows(CERO)(3).ToString().Trim()
                                    txtnivel2.Enabled = False
                                    txtnivel2.Text = "F"

                                End If





                            End If


                        Else


                            Dim sql7 As String = "SELECT * " & _
                                            "  FROM vg_pos_sugeridas " & _
                                            "WHERE reserva_producto='" + pro + "' " + anden

                            Dim tabla7 As DataTable = fnc.ListarTablasSQL(sql7)


                            If tabla7.Rows.Count > 0 Then
                                'ACA SI SOLO TIENE PRODUCTO
                                Dim sqll As String = "SELECT count(*) " & _
                             "  FROM vg_pos_sugeridas " & _
                           "WHERE reserva_producto='" + pro + "' " + anden

                                Dim tablaa As DataTable = fnc.ListarTablasSQL(sqll)


                                If tablaa.Rows.Count > 0 Then
                                    CEROMAX = Convert.ToInt32(tablaa.Rows(0)(0).ToString())

                                    If CEROMAX < CERO Then
                                        lmensaje.Text = "No Más Sugerencias"
                                        Exit Sub

                                    End If
                                End If
                                PUERTA = tabla7.Rows(CERO)(15).ToString().Trim()
                                If PUERTA = "P1" Or PUERTA = "P2" Then

                                    Dim SD As String = "SELECT * " & _
                                                      "  FROM vg_pos_sugeridas " & _
                                                      "WHERE reserva_producto='" + pro + "'  " + anden + " ORDER BY LEFT(Cordenada,1), case when isnumeric(substring(Cordenada,2,100))=1 then cast(substring(Cordenada,2,100) as int) else cast(left(substring(Cordenada,2,100),len(substring(Cordenada,2,100))-1) as int) end ASC"

                                    Dim TD As DataTable = fnc.ListarTablasSQL(SD)


                                    If TD.Rows.Count > 0 Then
                                        txtcamara2.Text = TD.Rows(CERO)(0).ToString().Trim()
                                        txtbanda2.Text = TD.Rows(CERO)(1).ToString().Trim()
                                        txtcolumna2.Text = TD.Rows(CERO)(2).ToString().Trim()
                                        txtpiso2.Text = TD.Rows(CERO)(3).ToString().Trim()
                                        txtnivel2.Enabled = False
                                        txtnivel2.Text = "F"
                                    End If

                                Else
                                    Dim SD As String = "SELECT * " & _
                                                  "  FROM vg_pos_sugeridas " & _
                                                  "WHERE reserva_producto='" + pro + "'  " + anden + " ORDER BY LEFT(Cordenada,1), case when isnumeric(substring(Cordenada,2,100))=1 then cast(substring(Cordenada,2,100) as int) else cast(left(substring(Cordenada,2,100),len(substring(Cordenada,2,100))-1) as int) end DESC"

                                    Dim TD As DataTable = fnc.ListarTablasSQL(SD)


                                    If TD.Rows.Count > 0 Then
                                        txtcamara2.Text = TD.Rows(CERO)(0).ToString().Trim()
                                        txtbanda2.Text = TD.Rows(CERO)(1).ToString().Trim()
                                        txtcolumna2.Text = TD.Rows(CERO)(2).ToString().Trim()
                                        txtpiso2.Text = TD.Rows(CERO)(3).ToString().Trim()
                                        txtnivel2.Enabled = False
                                        txtnivel2.Text = "F"

                                    End If





                                End If

                            Else

                                Dim sql8 As String = "SELECT * " & _
                                            "  FROM vg_pos_sugeridas " & _
                                            "WHERE reserva_cliente  ='" + cli + "' " + anden

                                Dim tabla8 As DataTable = fnc.ListarTablasSQL(sql8)


                                If tabla8.Rows.Count > 0 Then
                                    'ACA SOLO SI TIENE CLIENTE 

                                    Dim sqll As String = "SELECT count(*) " & _
                             "  FROM vg_pos_sugeridas " & _
                               "WHERE reserva_cliente  ='" + cli + "' " + anden

                                    Dim tablaa As DataTable = fnc.ListarTablasSQL(sqll)


                                    If tablaa.Rows.Count > 0 Then
                                        CEROMAX = Convert.ToInt32(tablaa.Rows(0)(0).ToString())

                                        If CEROMAX < CERO Then
                                            lmensaje.Text = "No Más Sugerencias"
                                            Exit Sub

                                        End If
                                    End If
                                    PUERTA = tabla8.Rows(CERO)(15).ToString().Trim()
                                    If PUERTA = "P1" Or PUERTA = "P2" Then

                                        Dim SD As String = "SELECT * " & _
                                                          "  FROM vg_pos_sugeridas " & _
                                                          "WHERE reserva_cliente='" + cli + "' " + anden + " ORDER BY LEFT(Cordenada,1), case when isnumeric(substring(Cordenada,2,100))=1 then cast(substring(Cordenada,2,100) as int) else cast(left(substring(Cordenada,2,100),len(substring(Cordenada,2,100))-1) as int) end ASC"

                                        Dim TD As DataTable = fnc.ListarTablasSQL(SD)


                                        If TD.Rows.Count > 0 Then
                                            txtcamara2.Text = TD.Rows(CERO)(0).ToString().Trim()
                                            txtbanda2.Text = TD.Rows(CERO)(1).ToString().Trim()
                                            txtcolumna2.Text = TD.Rows(CERO)(2).ToString().Trim()
                                            txtpiso2.Text = TD.Rows(CERO)(3).ToString().Trim()
                                            txtnivel2.Enabled = False
                                            txtnivel2.Text = "F"
                                        End If

                                    Else
                                        Dim SD As String = "SELECT * " & _
                                                      "  FROM vg_pos_sugeridas " & _
                                                      "WHERE reserva_cliente='" + cli + "' " + anden + " ORDER BY LEFT(Cordenada,1), case when isnumeric(substring(Cordenada,2,100))=1 then cast(substring(Cordenada,2,100) as int) else cast(left(substring(Cordenada,2,100),len(substring(Cordenada,2,100))-1) as int) end DESC"

                                        Dim TD As DataTable = fnc.ListarTablasSQL(SD)


                                        If TD.Rows.Count > 0 Then
                                            txtcamara2.Text = TD.Rows(CERO)(0).ToString().Trim()
                                            txtbanda2.Text = TD.Rows(CERO)(1).ToString().Trim()
                                            txtcolumna2.Text = TD.Rows(CERO)(2).ToString().Trim()
                                            txtpiso2.Text = TD.Rows(CERO)(3).ToString().Trim()
                                            txtnivel2.Enabled = False
                                            txtnivel2.Text = "F"

                                        End If





                                    End If

                                Else

                                    Dim sql9 As String = "SELECT * " & _
                                            "  FROM vg_pos_sugeridas " & _
                                      "WHERE camara <>'' " + anden

                                    Dim tabla9 As DataTable = fnc.ListarTablasSQL(sql9)


                                    If tabla9.Rows.Count > 0 Then

                                        'ACA SI NO TIENE NADA 

                                        Dim sqll As String = "SELECT count(*) " & _
                          "  FROM vg_pos_sugeridas " & _
                 "WHERE camara <>'' " + anden

                                        Dim tablaa As DataTable = fnc.ListarTablasSQL(sqll)


                                        If tablaa.Rows.Count > 0 Then
                                            CEROMAX = Convert.ToInt32(tablaa.Rows(0)(0).ToString())

                                            If CEROMAX < CERO Then
                                                lmensaje.Text = "No Más Sugerencias"
                                                Exit Sub

                                            End If
                                        End If
                                        PUERTA = tabla9.Rows(CERO)(15).ToString().Trim()
                                        If PUERTA = "P1" Or PUERTA = "P2" Then

                                            Dim SD As String = "SELECT * " & _
                                                              "  FROM vg_pos_sugeridas " & _
                                                              "WHERE camara <>'' " + anden + " ORDER BY LEFT(Cordenada,1), case when isnumeric(substring(Cordenada,2,100))=1 then cast(substring(Cordenada,2,100) as int) else cast(left(substring(Cordenada,2,100),len(substring(Cordenada,2,100))-1) as int) end ASC"

                                            Dim TD As DataTable = fnc.ListarTablasSQL(SD)


                                            If TD.Rows.Count > 0 Then
                                                txtcamara2.Text = TD.Rows(CERO)(0).ToString().Trim()
                                                txtbanda2.Text = TD.Rows(CERO)(1).ToString().Trim()
                                                txtcolumna2.Text = TD.Rows(CERO)(2).ToString().Trim()
                                                txtpiso2.Text = TD.Rows(CERO)(3).ToString().Trim()
                                                txtnivel2.Enabled = False
                                                txtnivel2.Text = "F"
                                            End If

                                        Else
                                            Dim SD As String = "SELECT * " & _
                                                          "  FROM vg_pos_sugeridas " & _
                                                          "WHERE camara <>''  " + anden + " ORDER BY LEFT(Cordenada,1), case when isnumeric(substring(Cordenada,2,100))=1 then cast(substring(Cordenada,2,100) as int) else cast(left(substring(Cordenada,2,100),len(substring(Cordenada,2,100))-1) as int) end DESC"

                                            Dim TD As DataTable = fnc.ListarTablasSQL(SD)


                                            If TD.Rows.Count > 0 Then
                                                txtcamara2.Text = TD.Rows(CERO)(0).ToString().Trim()
                                                txtbanda2.Text = TD.Rows(CERO)(1).ToString().Trim()
                                                txtcolumna2.Text = TD.Rows(CERO)(2).ToString().Trim()
                                                txtpiso2.Text = TD.Rows(CERO)(3).ToString().Trim()
                                                txtnivel2.Enabled = False
                                                txtnivel2.Text = "F"

                                            End If





                                        End If


                                    End If



                                End If


                            End If



                        End If





                    End If


                End If

            End If



        End If







    End Sub


    Private Sub RANGOPUERTA()
        If PUERTA = "P1" Then




        End If


    End Sub
    Private Sub txtpalet_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpalet.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then

            If txtpalet.Text.Length = 21 Then

                codigo_pallet = ""
                BtnLiberar.Visible = False

                Dim sql As String = "SELECT racd_ca, racd_Ba, racd_Co, racd_Pi, racd_Ni, drec_rev " & _
                                    "FROM rackdeta INNER JOIN detarece ON drec_codi=racd_codi " & _
                                    "WHERE racd_codi='" + TransformaPallet(txtpalet.Text) + "'"
                PALLETGLOBAL = txtpalet.Text
                txtpallete.Text = TransformaPallet(txtpalet.Text)
                Dim tabla As DataTable = fnc.ListarTablasSQL(sql)


                If tabla.Rows.Count > 0 Then

                    If tabla.Rows(0)(5).ToString() <> "1" Then
                        MsgBox("Debe revisar los envases antes de posicionar", MsgBoxStyle.Critical, "Aviso")
                        BtnNuevo_Click(Nothing, Nothing)
                        Exit Sub
                    End If
                    If ComboBox1.Text = "" Then

                        MsgBox("Debe Seleccionar una camara", MsgBoxStyle.Critical, "Aviso")

                        Exit Sub

                    End If
                    temporalposicion()
                    txtcamara.Text = tabla.Rows(0)(0).ToString()
                    txtbanda.Text = tabla.Rows(0)(1).ToString()
                    txtcolumna.Text = tabla.Rows(0)(2).ToString()
                    txtpiso.Text = tabla.Rows(0)(3).ToString()
                    txtnivel.Text = tabla.Rows(0)(4).ToString()
                    variables()
                    lmensaje.Text = ""
                    txtpalet.Enabled = False
                    txtposicion.Enabled = True
                    txtcolumna.Enabled = False
                    txtposicion.Focus()
                    CERO = 0
                    traesugerido()
                Else
                    lmensaje.Text = "Pallet no existe"
                    txtpalet.Text = ""
                    txtpalet.Focus()
                End If

                lmensaje.Text = ""
                txtposicion.Focus()

            Else
                'lmensaje.Text = "Pallet no existe"
                txtpalet.Text = ""
                txtpalet.Focus()
            End If


        Else
            fnc.SoloNumeros(sender, e)
        End If

    End Sub
    Private Sub traesugerido()

        sugerido_pos()


    End Sub


    Private Sub txtposicion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtposicion.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtposicion.Text.Length = 13 Then
                Dim separado(15) As String

                For i As Integer = 0 To txtposicion.Text.Length - 1
                    separado(i) = txtposicion.Text.Chars(i)
                Next

                Dim CAMARASEP As String = "" + separado(6) + "" + separado(7)
                Dim BANDASEP As String = "" + separado(8) + "" + separado(9)
                Dim COLUMSEP As String = "" + separado(10) + "" + separado(11)


                If CAMARASEP <> txtcamara2.Text.Trim() Then
                    lmensaje.Text = "Posicion no valida"
                    txtposicion.Text = ""
                    Exit Sub

                End If
                If BANDASEP <> txtbanda2.Text.Trim() Then
                    lmensaje.Text = "Posicion no valida"
                    txtposicion.Text = ""
                    Exit Sub

                End If
                If COLUMSEP <> txtcolumna2.Text.Trim() Then
                    lmensaje.Text = "Posicion no valida"
                    txtposicion.Text = ""
                    Exit Sub

                End If
                'txtpiso.Text = ""
                'txtnivel.Text = ""
                'lmensaje.Text = ""
                'txtpiso.Focus()
                'txtcolumna.Enabled = False
                'txtnivel.Enabled = True
                ' verificar tipo de tarja

                Dim Sql_tip As String = "SELECT libre FROM camaraconf WHERE camara='" + txtcamara.Text.Trim() + "' "

                Dim tablatip As DataTable = fnc.ListarTablasSQL(Sql_tip)

                If tablatip.Rows.Count > 0 Then
                    If tablatip.Rows(0)(0).ToString().Trim() = "SI" Then

                        ' txtpiso.Text = "00"
                        'txtnivel.Text = "0"
                        Posicionar_KeyPress(sender, e, "SI")

                    Else
                        txtcolumna.Enabled = True
                        txtnivel.Enabled = True
                        txtcolumna.Enabled = False

                        ' txtnivel.Text = "0"
                        Posicionar_KeyPress(sender, e, "SI")




                    End If

                Else

                    lmensaje.Text = "Posicion no valida"
                    'txtcamara.Text = ""
                    'txtcamara.Enabled = True
                    'txtbanda.Text = ""
                    'txtbanda.Enabled = True
                    'txtcolumna.Text = ""
                    'txtcolumna.Enabled = True
                    txtposicion.Text = ""
                    'txtposicion.Enabled = True
                    txtposicion.Focus()
                    Exit Sub

                End If



            Else
                lmensaje.Text = "Posicion no valida"
            End If
            txtposicion.Enabled = False
        End If

    End Sub

    Private Sub Posicionar_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        BtnNuevo_Click(sender, e)
    End Sub
    Private Sub borratemp()

        Dim sqlEliminas As String = "DELETE FROM TMP_POS WHERE pallet='" + txtpalet.Text + "'"
        fnc.MovimientoSQL(sqlEliminas)
    End Sub
    Private Sub Posicionar_KeyPress(ByVal sender As Object, _
                                    ByVal e As System.Windows.Forms.KeyPressEventArgs, _
                                    Optional ByVal op As String = "NO") Handles MyBase.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Or op = "SI" Then
            If txtposicion.Text = "" Or txtcamara.Text = "" Or txtpiso.Text = "" Or (txtnivel.Text = "" AndAlso txtcolumna.Enabled = False) Then
                lmensaje.Text = "LLene todos los campos"
            Else
                If fnc.verificaExistencia("rackdeta", "racd_codi", fnc.CerosAnteriorString(txtpallete.Text, 9)) = True Then

                    If verificarPosicion() = 0 Then

                        Try

                            con.conectarSQL()

                            Dim _cmd As SqlCommand = New SqlCommand("PAG_POSICIONAR", con.conSQL)
                            _cmd.CommandType = CommandType.StoredProcedure
                            _cmd.Parameters.AddWithValue("@pallet", txtpallete.Text)
                            _cmd.Parameters.AddWithValue("@camara", txtcamara2.Text)
                            _cmd.Parameters.AddWithValue("@banda", txtbanda2.Text)
                            _cmd.Parameters.AddWithValue("@columna", txtcolumna2.Text)
                            _cmd.Parameters.AddWithValue("@piso", txtpiso2.Text)
                            _cmd.Parameters.AddWithValue("@nivel", txtnivel2.Text)
                            _cmd.Parameters.AddWithValue("@tipo", "RS")
                            _cmd.Parameters.AddWithValue("@encargado", CerosAnteriorString(lblcodigo.Text, 3))

                            Dim resp As Integer = 0

                            Try
                                resp = Convert.ToInt32(_cmd.ExecuteScalar())
                            Catch ex As Exception
                                resp = 1
                            End Try

                            If resp = 0 Then
                                borratemp()

                                lmensaje.Text = "Grabación exitosa"
                            ElseIf resp < 4 AndAlso resp <> 0 Then
                                lmensaje.Text = "Error al actualizar" + resp.ToString()
                            ElseIf resp = 4 Then
                                lmensaje.Text = "El pallet no existe"
                            End If
                            con.cerrarSQL()

                        Catch ex As Exception

                        End Try

                        BtnNuevo_Click(sender, e)

                        If accion = 1 Then
                            Me.Close()
                        End If
                    End If
                Else
                    MsgBox("El pallet ingresado no existe", MsgBoxStyle.MsgBoxHelp, "Aviso")
                End If
            End If
        End If
    End Sub

    Private Sub Posicionar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblcodigo.Text = codigo.ToString()
        txtpalet.Focus()
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        borratemp()

        txtpalet.Text = ""
        txtposicion.Text = ""
        txtpiso.Text = ""
        txtnivel.Text = ""
        txtcamara.Text = ""
        txtbanda.Text = ""
        txtcolumna.Text = ""
        txtpalet.Enabled = True
        txtcolumna.Enabled = False
        txtpalet.Focus()
    End Sub

    Private Sub txtpiso_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpiso.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            Dim pisoa As String = "0" + txtpiso.Text.Trim()
            Dim Sql_tip As String = "SELECT * FROM camaraMantenedor WHERE camara='" + txtcamara.Text.Trim() + "' and banda='" + txtbanda.Text.Trim() + "' and columna ='" + txtcolumna.Text.Trim() + "' and piso='" + pisoa + "'"

            Dim tablatip As DataTable = fnc.ListarTablasSQL(Sql_tip)

            If tablatip.Rows.Count > 0 Then
                Posicionar_KeyPress(sender, e)
            Else
                lmensaje.Text = "Esta Posicion No Se Encuentra Creada"
            End If
        Else
            'fnc.SoloNumeros(sender, e)
        End If
    End Sub

    Private Sub txtnivel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnivel.KeyPress
        txtnivel.Text = txtnivel.Text.ToUpper()
        If e.KeyChar = ChrW(Keys.Enter) Then
            Dim pisoa As String = "0" + txtpiso.Text.Trim()
            Dim Sql_tip As String = "SELECT * FROM camaraMantenedor WHERE camara='" + txtcamara.Text.Trim() + "' and banda='" + txtbanda.Text.Trim() + "' and columna ='" + txtcolumna.Text.Trim() + "' and piso='" + pisoa + "'"

            Dim tablatip As DataTable = fnc.ListarTablasSQL(Sql_tip)

            If tablatip.Rows.Count > 0 Then
                Posicionar_KeyPress(sender, e)
            Else
                lmensaje.Text = "Esta Posicion No Se Encuentra Creada"
            End If


        End If
    End Sub

    Private Sub txtpiso_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpiso.KeyUp
        If txtpiso.Text.Length > 0 Then
            txtnivel.Focus()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        If txtpalet.Text.Length >= 2 AndAlso txtpalet.Text.Length <= 9 Then
            txtpalet.Text = fnc.CerosAnteriorString(txtpalet.Text + "0", 21)

            If txtpalet.Text.Length = 21 Then
                codigo_pallet = ""
                BtnLiberar.Visible = False

                Dim sql As String = "SELECT racd_ca, racd_Ba, racd_Co, racd_Pi, racd_Ni,drec_rev FROM " & _
                            "rackdeta INNER JOIN detarece ON drec_codi=racd_codi WHERE racd_codi='" + TransformaPallet(txtpalet.Text) + "'"

                Dim tabla As DataTable = fnc.ListarTablasSQL(sql)


                If tabla.Rows.Count > 0 Then


                    If tabla.Rows(0)(5).ToString() <> "1" Then
                        MsgBox("Debe revisar los envases antes de posicionar", MsgBoxStyle.Critical, "Aviso")
                        BtnNuevo_Click(Nothing, Nothing)
                        Exit Sub
                    End If
                    temporalposicion()
                    txtcamara.Text = tabla.Rows(0)(0).ToString()
                    txtbanda.Text = tabla.Rows(0)(1).ToString()
                    txtcolumna.Text = tabla.Rows(0)(2).ToString()
                    txtpiso.Text = tabla.Rows(0)(3).ToString()
                    txtnivel.Text = tabla.Rows(0)(4).ToString()

                    variables()
                    lmensaje.Text = ""

                    txtpalet.Enabled = False
                    txtposicion.Enabled = True
                    txtposicion.Focus()

                Else
                    lmensaje.Text = "Pallet no existe"
                    txtpalet.Text = ""
                    txtpalet.Focus()
                End If
            Else
                lmensaje.Text = "Pallet no existe"
                txtpalet.Text = ""
                txtpalet.Focus()
            End If
        End If
    End Sub

    Private Sub txtpiso_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpiso.LostFocus
        If valida_posiciones_bloqueadas() = True Then
            MsgBox("Posicion bloqueada para inspeccion de equipos", MsgBoxStyle.Critical, "Aviso")
            txtpiso.Text = ""
            txtpiso.Focus()
        End If
    End Sub
    Private Sub temporalposicion()

        Dim qry As String = "INSERT INTO TMP_POS(pallet,fechareg ,encargado)VALUES ('" + txtpalet.Text + "',GETDATE(),'" + encargado_global + "')"

        fnc.MovimientoSQL(qry)


    End Sub
    ' ---------------------------------------
    ' POSICIONES QUE SE ENCUENTRAN BLOQUEADAS
    ' ---------------------------------------

    Function valida_posiciones_bloqueadas() As Boolean
        Dim BLOQUEADA As Boolean = False



        '           CAMARA N° 1

        If txtcamara.Text = "01" AndAlso txtbanda.Text = "02" AndAlso txtcolumna.Text = "01" _
        AndAlso CerosAnteriorString(txtpiso.Text, 2) = "05" Then
            BLOQUEADA = True
        End If

        If txtcamara.Text = "01" AndAlso txtbanda.Text = "03" AndAlso txtcolumna.Text = "01" _
        AndAlso CerosAnteriorString(txtpiso.Text, 2) = "05" Then
            BLOQUEADA = True
        End If

        If txtcamara.Text = "01" AndAlso txtbanda.Text = "08" AndAlso txtcolumna.Text = "01" _
        AndAlso CerosAnteriorString(txtpiso.Text, 2) = "05" Then
            BLOQUEADA = True
        End If

        If txtcamara.Text = "01" AndAlso txtbanda.Text = "09" AndAlso txtcolumna.Text = "01" _
        AndAlso CerosAnteriorString(txtpiso.Text, 2) = "05" Then
            BLOQUEADA = True
        End If

        If txtcamara.Text = "01" AndAlso txtbanda.Text = "14" AndAlso txtcolumna.Text = "01" _
        AndAlso CerosAnteriorString(txtpiso.Text, 2) = "05" Then
            BLOQUEADA = True
        End If


        '           CAMARA N° 2

        If txtcamara.Text = "02" AndAlso txtbanda.Text = "03" AndAlso txtcolumna.Text = "15" _
        AndAlso CerosAnteriorString(txtpiso.Text, 2) = "04" Then
            BLOQUEADA = True
        End If

        If txtcamara.Text = "02" AndAlso txtbanda.Text = "04" AndAlso txtcolumna.Text = "15" _
        AndAlso CerosAnteriorString(txtpiso.Text, 2) = "04" Then
            BLOQUEADA = True
        End If

        If txtcamara.Text = "02" AndAlso txtbanda.Text = "09" AndAlso txtcolumna.Text = "15" _
        AndAlso CerosAnteriorString(txtpiso.Text, 2) = "04" Then
            BLOQUEADA = True
        End If

        If txtcamara.Text = "02" AndAlso txtbanda.Text = "10" AndAlso txtcolumna.Text = "15" _
        AndAlso CerosAnteriorString(txtpiso.Text, 2) = "04" Then
            BLOQUEADA = True
        End If

        If txtcamara.Text = "02" AndAlso txtbanda.Text = "15" AndAlso txtcolumna.Text = "15" _
        AndAlso CerosAnteriorString(txtpiso.Text, 2) = "04" Then
            BLOQUEADA = True
        End If

        If txtcamara.Text = "02" AndAlso txtbanda.Text = "16" AndAlso txtcolumna.Text = "15" _
        AndAlso CerosAnteriorString(txtpiso.Text, 2) = "04" Then
            BLOQUEADA = True
        End If



        '           CAMARA N° 3


        If txtcamara.Text = "03" AndAlso txtbanda.Text = "03" AndAlso txtcolumna.Text = "01" _
        AndAlso CerosAnteriorString(txtpiso.Text, 2) = "05" Then
            BLOQUEADA = True
        End If

        If txtcamara.Text = "03" AndAlso txtbanda.Text = "04" AndAlso txtcolumna.Text = "01" _
        AndAlso CerosAnteriorString(txtpiso.Text, 2) = "05" Then
            BLOQUEADA = True
        End If

        If txtcamara.Text = "03" AndAlso txtbanda.Text = "09" AndAlso txtcolumna.Text = "01" _
        AndAlso CerosAnteriorString(txtpiso.Text, 2) = "05" Then
            BLOQUEADA = True
        End If

        If txtcamara.Text = "03" AndAlso txtbanda.Text = "10" AndAlso txtcolumna.Text = "01" _
        AndAlso CerosAnteriorString(txtpiso.Text, 2) = "05" Then
            BLOQUEADA = True
        End If

        If txtcamara.Text = "03" AndAlso txtbanda.Text = "11" AndAlso txtcolumna.Text = "01" _
        AndAlso CerosAnteriorString(txtpiso.Text, 2) = "05" Then
            BLOQUEADA = True
        End If

        If txtcamara.Text = "03" AndAlso txtbanda.Text = "15" AndAlso txtcolumna.Text = "01" _
        AndAlso CerosAnteriorString(txtpiso.Text, 2) = "05" Then
            BLOQUEADA = True
        End If

        If txtcamara.Text = "03" AndAlso txtbanda.Text = "16" AndAlso txtcolumna.Text = "01" _
        AndAlso CerosAnteriorString(txtpiso.Text, 2) = "05" Then
            BLOQUEADA = True
        End If

        If txtcamara.Text = "03" AndAlso txtbanda.Text = "17" AndAlso txtcolumna.Text = "01" _
        AndAlso CerosAnteriorString(txtpiso.Text, 2) = "05" Then
            BLOQUEADA = True
        End If

        If txtcamara.Text = "03" AndAlso txtbanda.Text = "18" AndAlso txtcolumna.Text = "01" _
        AndAlso CerosAnteriorString(txtpiso.Text, 2) = "05" Then
            BLOQUEADA = True
        End If

        If txtcamara.Text = "03" AndAlso txtbanda.Text = "22" AndAlso txtcolumna.Text = "01" _
        AndAlso CerosAnteriorString(txtpiso.Text, 2) = "05" Then
            BLOQUEADA = True
        End If

        If txtcamara.Text = "03" AndAlso txtbanda.Text = "23" AndAlso txtcolumna.Text = "01" _
        AndAlso CerosAnteriorString(txtpiso.Text, 2) = "05" Then
            BLOQUEADA = True
        End If

        If txtcamara.Text = "03" AndAlso txtbanda.Text = "24" AndAlso txtcolumna.Text = "01" _
        AndAlso CerosAnteriorString(txtpiso.Text, 2) = "05" Then
            BLOQUEADA = True
        End If

        If txtcamara.Text = "03" AndAlso txtbanda.Text = "" AndAlso txtcolumna.Text = "01" _
        AndAlso CerosAnteriorString(txtpiso.Text, 2) = "05" Then
            BLOQUEADA = True
        End If



        '           CAMARA N° 4


        If txtcamara.Text = "04" AndAlso txtbanda.Text = "05" AndAlso txtcolumna.Text = "16" _
        AndAlso CerosAnteriorString(txtpiso.Text, 2) = "04" Then
            BLOQUEADA = True
        End If
        If txtcamara.Text = "04" AndAlso txtbanda.Text = "06" AndAlso txtcolumna.Text = "16" _
        AndAlso CerosAnteriorString(txtpiso.Text, 2) = "04" Then
            BLOQUEADA = True
        End If
        If txtcamara.Text = "04" AndAlso txtbanda.Text = "11" AndAlso txtcolumna.Text = "16" _
        AndAlso CerosAnteriorString(txtpiso.Text, 2) = "04" Then
            BLOQUEADA = True
        End If
        If txtcamara.Text = "04" AndAlso txtbanda.Text = "12" AndAlso txtcolumna.Text = "16" _
        AndAlso CerosAnteriorString(txtpiso.Text, 2) = "04" Then
            BLOQUEADA = True
        End If
        If txtcamara.Text = "04" AndAlso txtbanda.Text = "17" AndAlso txtcolumna.Text = "16" _
        AndAlso CerosAnteriorString(txtpiso.Text, 2) = "04" Then
            BLOQUEADA = True
        End If
        If txtcamara.Text = "04" AndAlso txtbanda.Text = "18" AndAlso txtcolumna.Text = "16" _
        AndAlso CerosAnteriorString(txtpiso.Text, 2) = "04" Then
            BLOQUEADA = True
        End If
        If txtcamara.Text = "04" AndAlso txtbanda.Text = "23" AndAlso txtcolumna.Text = "16" _
        AndAlso CerosAnteriorString(txtpiso.Text, 2) = "04" Then
            BLOQUEADA = True
        End If
        If txtcamara.Text = "04" AndAlso txtbanda.Text = "24" AndAlso txtcolumna.Text = "16" _
        AndAlso CerosAnteriorString(txtpiso.Text, 2) = "04" Then
            BLOQUEADA = True
        End If
        If txtcamara.Text = "04" AndAlso txtbanda.Text = "25" AndAlso txtcolumna.Text = "16" _
        AndAlso CerosAnteriorString(txtpiso.Text, 2) = "04" Then
            BLOQUEADA = True
        End If

        Return BLOQUEADA

    End Function

    Private Sub txtcolumna_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcolumna.KeyPress
        If e.KeyChar = ChrW(13) Then
            txtpiso.Focus()
        Else
            fnc.SoloNumeros(sender, e)
        End If
    End Sub

    Private Sub txtcolumna_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcolumna.LostFocus
        txtcolumna.Text = CerosAnteriorString(txtcolumna.Text, 2)
    End Sub

    Private Sub BtnLiberar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLiberar.Click

        If MsgBox("Seguro de liberar la posición", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") Then
            Try
                con.conectarSQL()

                Dim _cmd As SqlCommand = New SqlCommand("PAG_POSICIONAR", con.conSQL)
                _cmd.CommandType = CommandType.StoredProcedure
                _cmd.Parameters.AddWithValue("@pallet", codigo_pallet)
                _cmd.Parameters.AddWithValue("@camara", "71")
                _cmd.Parameters.AddWithValue("@banda", "00")
                _cmd.Parameters.AddWithValue("@columna", "00")
                _cmd.Parameters.AddWithValue("@piso", "00")
                _cmd.Parameters.AddWithValue("@nivel", "0")
                _cmd.Parameters.AddWithValue("@tipo", "RR")
                _cmd.Parameters.AddWithValue("@encargado", CerosAnteriorString(lblcodigo.Text, 3))
                Dim resp As Integer = 0

                Try
                    resp = Convert.ToInt32(_cmd.ExecuteScalar())
                Catch ex As Exception
                    resp = 1
                End Try

                If resp = 0 Then
                    lmensaje.Text = "Grabación exitosa"
                ElseIf resp < 4 AndAlso resp <> 0 Then
                    lmensaje.Text = "Error al actualizar" + resp.ToString()
                ElseIf resp = 4 Then
                    lmensaje.Text = "El pallet no existe"
                End If
                con.cerrarSQL()

            Catch ex As Exception

            End Try
            BtnLiberar.Visible = False
            BtnNuevo_Click(sender, e)
        End If


    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim f As New Frm_RevisionPosiciones
        f.ShowDialog()
    End Sub

    Private Sub txtposicion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtposicion.TextChanged

    End Sub

    Private Sub txtpiso_ParentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpiso.ParentChanged

    End Sub
    <DllImport("coredll.dll")> _
Public Shared Function sndPlaySound(ByVal lpszSoundName As [String], ByVal fuSound As UInteger) As Boolean
    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        borratemp()
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        CERO = CERO + 1

        If CERO > CEROMAX - 1 Then
        Else
            sndPlaySound("\\TEST.WAV", 0)
            sugerido_pos()
        End If


    End Sub

    Private Sub txtpalet_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpalet.TextChanged

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim f As New frm_Pos
        f.usuario = Me.usuario
        f.cargo = Me.cargo
        f.perfil = Me.perfil
        f.codigo = Me.codigo.ToString()
        f.ShowDialog()
    End Sub
End Class