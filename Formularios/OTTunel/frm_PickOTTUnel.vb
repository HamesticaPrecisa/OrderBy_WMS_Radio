Imports System.Data.SqlClient

' 
' ESTE FORMULARIO SE BASA EN FRM_POS PERO
' ADAPTADO AL PICKING DE OTS TUNEL
'
Public Class frm_PickOTTUnel

    Dim fnc As New Funciones
    Dim con As New Conexion
    Dim TIPOALAMACEN As String = ""
    Dim camara As String = ""
    Dim banda As String = ""
    Dim columna As String = ""
    Dim piso As String = ""
    Dim nivel As String = ""
    Dim pick As String = ""
    Dim picktra As String = ""
    Public usuario As String = ""
    Public cargo As String = ""
    Public perfil As String = ""
    Public codigo As String = ""
    Dim codigo_pallet As String = ""

    Public accion As Integer = 0

    Public frec_codi As String = ""
    Public frec_guiades As String = ""
    Public cli_nomb As String = ""
    Public cam_codi As String = ""
    Public cam_descr As String = ""
    Public ott_numero As String = ""
    Public ott_id As Integer = 0
    Public picked As Integer = 0
    Public max_pallets As Integer = 0


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

        Dim sql As String = "SELECT * FROM rackdeta WHERE racd_ca='" + txtcamara.Text + "' AND racd_ba='" + txtbanda.Text + "' AND " & _
        "racd_co='" + txtcolumna.Text + "' AND racd_pi='" + txtpiso.Text + "' AND racd_ni='" + txtnivel.Text + "' AND racd_codi<>'" + txtpalet.Text + "'"

        Dim Sql_Ocupada As String = "SELECT racd_ni,racd_codi FROM rackdeta WHERE racd_ca='" + txtcamara.Text + "' AND racd_ba='" + txtbanda.Text + "' AND " & _
        "racd_co='" + txtcolumna.Text + "' AND racd_pi='" + txtpiso.Text + "' AND racd_codi<>'" + txtpalet.Text + "' "

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

        Dim Sql_tip As String = "SELECT libre FROM camaraconf WHERE camara='" + txtcamara.Text.Trim() + "' "

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
                        codigo_pallet = tabla.Rows(0)(1).ToString()
                        retorno = 1
                    End If


                End If
            End If
        End If

        Return retorno
    End Function
    Private Sub borratemp()

        Dim sqlEliminas As String = "DELETE FROM TMP_POS WHERE pallet='" + txtpalet.Text + "'"
        fnc.MovimientoSQL(sqlEliminas)
    End Sub
    Private Sub temporalposicion()

        Dim qry As String = "INSERT INTO TMP_POS(pallet,fechareg ,encargado)VALUES ('" + txtpalet.Text + "',GETDATE(),'" + encargado_global + "')"

        fnc.MovimientoSQL(qry)


    End Sub
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

    Private Sub refreshPickCount()
        lblCount.Text = String.Format("{0} - {1}/{2} - {3} falt", cam_descr, picked, max_pallets, max_pallets - picked)
        Panel1.BackColor = If(picked < max_pallets, Color.Red, Color.DarkGreen)
        lblCount.BackColor = Panel1.BackColor

    End Sub

    Private Sub txtpalet_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpalet.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            '
            ' VALIDAMOS QUE EL PALLET EXISTA EN LA GUIA
            '
            Dim palletpadre As String = ""
            Dim tablaq As DataTable = New DataTable
            tablaq = fnc.ListarTablasSQL("SELECT * FROM detarece WHERE frec_codi1 = @frec_codi AND drec_codi = @drec_codi", _
                                         New SqlParameter() { _
                                            New SqlParameter("@frec_codi", SqlDbType.VarChar) With {.Value = frec_codi}, _
                                            New SqlParameter("@drec_codi", SqlDbType.VarChar) With {.Value = txtpalet.Text.Trim()} _
                                         })

            If tablaq.Rows.Count = 0 Then
                lmensaje.Text = "El pallet indicado no existe en la guia"
                txtpalet.Text = ""
                Beep()
                Return
            End If
            pick = txtpalet.Text.Trim()
            txtpalet.Text = "11780000000" + pick + "1"

            '
            ' VALIDAMOS SI EL PALLET YA SE PICKEO.  SI ES ASI, SE MUESTRA
            ' LA UBICACION ACTUAL
            '
            tablaq = fnc.ListarTablasSQL("SELECT * FROM det_ots_tunel WHERE ott_id = @ott_id AND drec_codi = @drec_codi", _
                                         New SqlParameter() { _
                                            New SqlParameter("@ott_id", SqlDbType.Int) With {.Value = ott_id}, _
                                            New SqlParameter("@drec_codi", SqlDbType.VarChar) With {.Value = pick} _
                                        })
            If tablaq.Rows.Count > 0 Then
                txtcamara.Text = tablaq.Rows(0)("dot_ca").ToString()
                txtbanda.Text = tablaq.Rows(0)("dot_ba").ToString()
                txtcolumna.Text = tablaq.Rows(0)("dot_co").ToString()
                txtpiso.Text = tablaq.Rows(0)("dot_pi").ToString()
                txtnivel.Text = tablaq.Rows(0)("dot_ni").ToString()
            End If

            lmensaje.Text = ""
            txtposicion.Text = ""
            txtposicion.Enabled = True
            txtposicion.Focus()

        Else
            fnc.SoloNumeros(sender, e)
        End If

    End Sub

    Private Sub txtposicion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtposicion.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtposicion.Text.Length = 13 Then
                Dim separado(15) As String

                For i As Integer = 0 To txtposicion.Text.Length - 1
                    separado(i) = txtposicion.Text.Chars(i)
                Next

                txtcamara.Text = "" + separado(6) + "" + separado(7)
                txtbanda.Text = "" + separado(8) + "" + separado(9)
                txtcolumna.Text = "" + separado(10) + "" + separado(11)
                txtpiso.Text = ""
                txtnivel.Text = ""
                lmensaje.Text = ""
                txtpiso.Focus()
                txtcolumna.Enabled = False
                txtnivel.Enabled = True
                ' verificar tipo de tarja

                '
                ' VERIFICAMOS QUE LA POSICION INDICADA CORRESPONDE A LA CAMARA
                ' ASOCIADA A LA OT
                '
                If txtcamara.Text <> cam_codi Then
                    lmensaje.Text = "La ubicacion no corresponde a una ubicacion de " + cam_descr
                    txtposicion.Enabled = False
                    Return
                End If

                Dim Sql_tip As String = "SELECT libre FROM camaraconf WHERE camara='" + txtcamara.Text.Trim() + "' "

                Dim tablatip As DataTable = fnc.ListarTablasSQL(Sql_tip)

                If tablatip.Rows.Count > 0 Then
                    If tablatip.Rows(0)(0).ToString().Trim() = "SI" Then

                        txtpiso.Text = "00"
                        txtnivel.Text = "0"
                        Posicionar_KeyPress(sender, e, "SI")

                    Else
                        txtcolumna.Enabled = True
                        txtnivel.Enabled = True
                        txtcolumna.Enabled = False
                        If txtcolumna.Text = "00" Then
                            txtpiso.Text = "00"
                            txtnivel.Text = "0"
                            Posicionar_KeyPress(sender, e, "SI")

                        Else
                            txtpiso.Text = ""
                            txtpiso.Focus()
                        End If



                    End If

                Else

                    lmensaje.Text = "Posicion ingresada no es valida"
                    txtcamara.Text = ""
                    txtcamara.Enabled = True
                    txtbanda.Text = ""
                    txtbanda.Enabled = True
                    txtcolumna.Text = ""
                    txtcolumna.Enabled = True
                    txtposicion.Text = ""
                    txtposicion.Enabled = True
                    txtposicion.Focus()
                    Exit Sub

                End If



            Else
                lmensaje.Text = "Posicion ingresada no es valida"
            End If
            txtposicion.Enabled = False
        End If

    End Sub

    Private Sub Posicionar_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        BtnNuevo_Click(sender, e)
    End Sub

    Private Sub Posicionar_KeyPress(ByVal sender As Object, _
                                    ByVal e As System.Windows.Forms.KeyPressEventArgs, _
                                    Optional ByVal op As String = "NO") Handles MyBase.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Or op = "SI" Then
            If txtposicion.Text = "" Or txtcamara.Text = "" Or txtpiso.Text = "" Or (txtnivel.Text = "" AndAlso txtcolumna.Enabled = False) Then
                lmensaje.Text = "LLene todos los campos"
            Else
                If fnc.verificaExistencia("det_ots_tunel", "racd_codi", fnc.CerosAnteriorString(txtpalet.Text, 9)) = False Then

                    If verificarPosicion() = 0 Then

                        Try

                            con.conectarSQL()

                            Dim _cmd As SqlCommand = New SqlCommand("PAG_POSICIONAR", con.conSQL)
                            _cmd.CommandType = CommandType.StoredProcedure
                            _cmd.Parameters.AddWithValue("@pallet", txtpalet.Text)
                            _cmd.Parameters.AddWithValue("@camara", txtcamara.Text)
                            _cmd.Parameters.AddWithValue("@banda", txtbanda.Text)
                            _cmd.Parameters.AddWithValue("@columna", txtcolumna.Text)
                            _cmd.Parameters.AddWithValue("@piso", txtpiso.Text)
                            _cmd.Parameters.AddWithValue("@nivel", txtnivel.Text)

                            ' TODO: ACLARAR VALOR CORRECTO DE @TIPO
                            If pick = "" Then
                                _cmd.Parameters.AddWithValue("@tipo", "RR")
                            Else
                                _cmd.Parameters.AddWithValue("@tipo", "RP")
                                ' txtpalet.Text = pick
                            End If

                            _cmd.Parameters.AddWithValue("@encargado", CerosAnteriorString(lblcodigo.Text, 3))

                            '
                            ' ADICIONALMENTE AL POSICIONAMIENTO, SE ANEXA EL PALLET A LA OT
                            '
                            Dim _cmd2 As SqlCommand = New SqlCommand("INSERT INTO det_ots_tunel (ott_id, drec_codi, dot_ca, dot_ba, dot_co, dot_pi, dot_ni) " & _
                                                                     " VALUES (@ott_id, @drec_codi, @dot_ca, @dot_ba, @dot_co, @dot_pi, @dot_ni)", con.conSQL)
                            _cmd2.CommandType = CommandType.Text
                            _cmd2.Parameters.AddWithValue("@ott_id", ott_id)
                            _cmd2.Parameters.AddWithValue("@drec_codi", fnc.CerosAnteriorString(txtpalet.Text, 9))
                            _cmd2.Parameters.AddWithValue("@dot_ca", txtcamara.Text)
                            _cmd2.Parameters.AddWithValue("@dot_ba", txtbanda.Text)
                            _cmd2.Parameters.AddWithValue("@dot_co", txtcolumna.Text)
                            _cmd2.Parameters.AddWithValue("@dot_pi", fnc.CerosAnteriorString(txtpiso.Text.Trim(), 2))
                            _cmd2.Parameters.AddWithValue("@dot_ni", fnc.CerosAnteriorString(txtnivel.Text.Trim(), 2))

                            Dim resp As Integer = 0

                            Dim tx As SqlTransaction
                            Try
                                tx = con.conSQL.BeginTransaction()
                                resp = Convert.ToInt32(_cmd.ExecuteScalar())
                                tx.Commit()

                            Catch ex As Exception
                                resp = 1
                                tx.Rollback()
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
                        If pick = "" Then
                        Else
                            Dim _actualiza As String = "UPDATE MOVPALLET SET mov_folio='" + pick + "'  WHERE mov_folio='" + txtpalet.Text + "' and mov_tipo='RP'"

                            fnc.MovimientoSQL(_actualiza)
                        End If



                        BtnNuevo_Click(sender, e)

                        If accion = 1 Then
                            Me.Close()
                        End If
                    End If
                Else
                    MsgBox("El pallet ingresado ya fue posicionado", MsgBoxStyle.MsgBoxHelp, "Aviso")
                End If
            End If
        End If
    End Sub

    Private Sub Posicionar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblcodigo.Text = codigo.ToString()
        Text = String.Format("OT #{0}", ott_numero.Trim())
        lblInfoOT.Text = frec_guiades.Trim() + "-" + cli_nomb.Trim()
        refreshPickCount()
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
            Dim nivel = txtnivel.Text.Trim.ToUpper
            Dim carDis As String = "0123456789fF"

            If (nivel <> "") Then
                Dim exi = True

                For i As Integer = 0 To carDis.Length - 1
                    If (nivel = carDis.Substring(i, 1)) Then
                        exi = False
                    End If
                Next

                If (exi) Then
                    MsgBox("Debe ingresar un nivel correcto (Número o F).", MsgBoxStyle.Exclamation, "Error!")
                    txtnivel.Text = ""
                    txtnivel.Focus()
                    Exit Sub
                End If
            End If

            Dim pisoa As String = "0" + txtpiso.Text.Trim()
            Dim Sql_tip As String = "SELECT * FROM camaraMantenedor WHERE camara='" + txtcamara.Text.Trim() + "' and banda='" + txtbanda.Text.Trim() + "' and columna ='" + txtcolumna.Text.Trim() + "' and piso='" + pisoa + "'"

            Dim tablatip As DataTable = fnc.ListarTablasSQL(Sql_tip)

            If tablatip.Rows.Count > 0 Then

                Dim sqlHabil = "SELECT * FROM camaraMantenedor WHERE camara='" + txtcamara.Text.Trim() + "' and banda='" + txtbanda.Text.Trim() + "' and columna ='" + txtcolumna.Text.Trim() + "' and piso='" + pisoa + "' and (estado<>'0' or aestado<>'0')"
                Dim dtHabil As DataTable = fnc.ListarTablasSQL(sqlHabil)
                If (dtHabil.Rows.Count > 0) Then
                    Dim sqlHabil2 = "SELECT * FROM camaraMantenedor WHERE camara='" + txtcamara.Text.Trim() + "' and banda='" + txtbanda.Text.Trim() + "' and columna ='" + txtcolumna.Text.Trim() + "' and piso='" + pisoa + "' and estado<>'0'"
                    Dim dtHabil2 As DataTable = fnc.ListarTablasSQL(sqlHabil2)
                    If (dtHabil2.Rows.Count > 0) Then
                        MsgBox("El piso seleccionado se encuentra deshabilitado.", MsgBoxStyle.Information, "Piso Deshabilitado!")
                    Else
                        MsgBox("El piso seleccionado se encuentra deshabilitado por diseño.", MsgBoxStyle.Information, "Piso Deshabilitado!")
                    End If

                    Exit Sub
                End If

                ''aquuuuuuuuuuuuuui
                Dim sql As String = "SELECT RACD_CODI,RACD_CA,frec_tipoalmacenamiento,pro_var FROM " & _
                            "VG_TIPOALMACEN_PALLET  WHERE racd_codi='" + txtpalet.Text.Trim() + "'"

                Dim tabla As DataTable = fnc.ListarTablasSQL(sql)


                If tabla.Rows.Count > 0 Then
                    TIPOALAMACEN = tabla.Rows(0)(2).ToString()
                    '            camara = tabla.Rows(0)(0).ToString()
                    Dim sql3 As String = "SELECT tipo_Almacen FROM " & _
                            "CAMARACONF  WHERE CAMARA='" + txtcamara.Text.Trim() + "'"

                    Dim tabla3 As DataTable = fnc.ListarTablasSQL(sql3)


                    If tabla3.Rows.Count > 0 Then


                        If TIPOALAMACEN.Trim() = tabla3.Rows(0)(0).ToString().Trim() Then
                            Posicionar_KeyPress(sender, e)
                        Else


                            If tabla.Rows(0)(3).ToString().Trim() = "SI" Then

                                Posicionar_KeyPress(sender, e)

                            Else

                                lmensaje.Text = "Camara definida para otro tipo de almacen"
                                Exit Sub


                            End If







                        End If

                    End If



                End If






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
        Dim palletpadre As String = ""
        Dim tablaq As DataTable = New DataTable
        tablaq = fnc.ListarTablasSQL("SELECT * FROM PALLETPICK WHERE  palletpick='" + txtpalet.Text.Trim() + "'")

        If tablaq.Rows.Count > 0 Then

            palletpadre = tablaq.Rows(0)(0).ToString().Trim()
            pick = txtpalet.Text.Trim()
            txtpalet.Text = palletpadre
        Else
            pick = ""
        End If

        If txtpalet.Text.Length >= 2 AndAlso txtpalet.Text.Length <= 9 Then
            txtpalet.Text = fnc.CerosAnteriorString(txtpalet.Text + "0", 21)

            If txtpalet.Text.Length = 21 Then
                codigo_pallet = ""

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

    ' ---------------------------------------
    ' POSICIONES QUE SE ENCUENTRAN BLOQUEADAS
    ' ---------------------------------------



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

    Private Sub BtnLiberar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        borratemp()
        Me.Close()
    End Sub

    Private Sub txtnivel_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtnivel.KeyUp
        Dim nivel = txtnivel.Text.Trim.ToUpper
        Dim carDis As String = "0123456789fF"

        If (nivel <> "") Then
            Dim exi = True

            For i As Integer = 0 To carDis.Length - 1
                If (nivel = carDis.Substring(i, 1)) Then
                    exi = False
                End If
            Next

            If (exi) Then
                MsgBox("Debe ingresar un nivel correcto (Número o F).", MsgBoxStyle.Exclamation, "Error!")
                txtnivel.Text = ""
                txtnivel.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txtnivel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnivel.TextChanged

    End Sub


End Class