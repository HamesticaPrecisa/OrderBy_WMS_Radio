Imports System.Data.SqlClient

Public Class Frm_Preparar

    Dim fnc As New Funciones
    Dim cantidad_de_registros As Integer = 0
    Dim pedido As String = ""
    Public codigo As String = ""
    Public encargado As String = ""

    Dim i1 As Boolean = False
    Dim i2 As Boolean = False
    Dim i3 As Boolean = False

    Dim rev1 As Boolean = False
    Dim rev2 As Boolean = False
    Dim rev3 As Boolean = False

    Dim term1 As Boolean = False
    Dim term2 As Boolean = False
    Dim term3 As Boolean = False

    Dim _LimpiaMensaje As Boolean = False

    Dim _Or As String = ""

    Dim Limpiar As DataTable = New DataTable
    Dim con As New Conexion

    Private Sub ped1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ped1.KeyPress
        If e.KeyChar = ChrW(13) Then
            If ped1.Text.Length > 0 Then
                ped1.Enabled = False
                ped2.Enabled = True
                ped2.Focus()
            Else
                MsgBox("Debe seleccionar minimo 1 pedido")
            End If
        Else
            SoloNumeros(sender, e)
        End If
    End Sub

    Private Sub ped2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ped2.KeyPress
        If e.KeyChar = ChrW(13) Then
            If ped1.Text.Trim = ped2.Text.Trim Then
                MsgBox("El pedido coincide con el pedido 1")
                ped2.Text = ""
                Return
            End If
            ped2.Enabled = False
            ped3.Enabled = True
            ped3.Focus()
        Else
            SoloNumeros(sender, e)
        End If
    End Sub

    Private Sub ped3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ped3.KeyPress
        If e.KeyChar = ChrW(13) Then
            If ped2.Text.Trim = ped3.Text.Trim AndAlso ped3.Text <> "" Then
                MsgBox("El pedido coincide con el pedido 2")
                ped3.Text = ""
                Return
            End If

            If ped1.Text.Trim = ped3.Text.Trim Then
                MsgBox("El pedido coincide con el pedido 1")
                ped3.Text = ""
                Return
            End If

            ped3.Enabled = False
            BtnBuscar.Focus()
        Else
            SoloNumeros(sender, e)
        End If
    End Sub


    Function ACTUALIZA_GRILLA() As Boolean

        Dim sqlDetalle As String = "SELECT pallet, racd_ca+'-'+racd_ba+'-'+ racd_co+'-'+ racd_pi+'-'+ racd_ni AS posicion, orden " & _
                                   "FROM pedidos_detalle INNER JOIN rackdeta ON racd_codi=pallet  INNER JOIN Pedidos_ficha ON pedidos_ficha.pedido=Pedidos_detalle.pedido " & _
                                   "WHERE (orden='" + ped1.Text + "' " + _Or + ") AND est<>'1' ORDER BY  racd_ca, racd_ba ASC"

        Dim tabladetalle As DataTable = fnc.ListarTablasSQL(sqlDetalle)

        DataGrid1.DataSource = tabladetalle


        If tabladetalle.Rows.Count > 0 Then


            rev1 = False
            rev2 = False
            rev3 = False

            For i As Integer = 0 To tabladetalle.Rows.Count - 1

                If i1 = True AndAlso rev1 = False Then
                    If ped1.Text = tabladetalle.Rows(i)(2).ToString() Then
                        rev1 = True
                    End If
                End If

                If i2 = True AndAlso rev2 = False Then
                    If ped2.Text = tabladetalle.Rows(i)(2).ToString() Then
                        rev2 = True
                    End If
                End If

                If i3 = True AndAlso rev3 = False Then
                    If ped3.Text = tabladetalle.Rows(i)(2).ToString() Then
                        rev3 = True
                    End If
                End If
            Next

            If rev1 = False AndAlso ped1.Text <> "" AndAlso term1 = False Then

                Dim sql As String = "UPDATE pedidos_ficha SET terminado='1', fechatermino=GETDATE() WHERE Orden='" + ped1.Text + "'"
                'Dim sql As String = "SP_Pedidos_Estados_Actualizar '" & ped1.Text.Trim & "','D','1'"
                While fnc.MovimientoSQL(sql) = 0
                End While
                MsgBox("Pedido N° " + ped1.Text + " Terminado", MsgBoxStyle.Information, "Aviso")
                term1 = True
                Return True
            End If

            If rev2 = False AndAlso ped2.Text <> "" AndAlso term2 = False Then
                Dim sql As String = "UPDATE pedidos_ficha SET terminado='1', fechatermino=GETDATE() WHERE Orden='" + ped2.Text + "'"
                'Dim sql As String = "SP_Pedidos_Estados_Actualizar '" & ped2.Text.Trim & "','D','1'"
                While fnc.MovimientoSQL(sql) = 0
                End While
                MsgBox("Pedido N° " + ped2.Text + " Terminado", MsgBoxStyle.Information, "Aviso")
                term2 = True
                Return True
            End If

            If rev3 = False AndAlso ped3.Text <> "" AndAlso term3 = False Then
                Dim sql As String = "UPDATE pedidos_ficha SET terminado='1', fechatermino=GETDATE() WHERE Orden='" + ped3.Text + "'"
                'Dim sql As String = "SP_Pedidos_Estados_Actualizar '" & ped3.Text.Trim & "','D','1'"
                While fnc.MovimientoSQL(sql) = 0
                End While
                MsgBox("Pedido N° " + ped3.Text + " Terminado", MsgBoxStyle.Information, "Aviso")
                term3 = True
                Return True
            End If

        Else
            Dim pedido As String = ""
            If rev1 = True Then
                pedido = ped1.Text
            End If
            If rev2 = True Then
                pedido = ped2.Text
            End If
            If rev3 = True Then
                pedido = ped3.Text
            End If


            Dim SQL_VERIFICA As String = "SELECT fechatermino FROM pedidos_ficha WHERE orden='" + pedido + "'"
            Dim tabla2 As DataTable = fnc.ListarTablasSQL(SQL_VERIFICA)

            If tabla2.Rows.Count > 0 Then
                If tabla2.Rows(0)(0).ToString() = "" Then
                    Dim sql As String = "UPDATE pedidos_ficha SET terminado='1', fechatermino=GETDATE() WHERE orden='" + pedido + "'"
                    'Dim sql As String = "SP_Pedidos_Estados_Actualizar '" & pedido & "','D','1'"
                    While fnc.MovimientoSQL(sql) = 0
                    End While
                    MsgBox("Pedido N° " + pedido + " Terminado", MsgBoxStyle.Information, "Aviso")
                    DataGrid1.DataSource = tabladetalle
                Else
                    MsgBox("Pedido N° " + pedido + " Terminado", MsgBoxStyle.Information, "Aviso")
                End If
                Return False

            End If

            If rev1 = False And rev2 = False And rev3 = False Then
                Btn_LimpiaPedido_Click(Nothing, Nothing)
                Return False
            End If
            Return True
        End If
        Return True
    End Function

    Private Sub Bnt_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bnt_Salir.Click
        Me.Close()
    End Sub

    Private Sub Btn_LimpiaPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_LimpiaPedido.Click
        ped1.Text = ""
        ped1.Enabled = True
        ped2.Text = ""
        ped3.Text = ""
        lmensaje.Text = ""
        TxtPallet.Text = ""
        TxtPallet.Enabled = True
        txtposicion.Text = ""
        txtcamara.Text = ""
        txtbanda.Text = ""
        txtcolumna.Text = ""
        txtpiso.Text = ""
        txtnivel.Text = ""
        RadioButton1.Checked = True
        BtnBuscar.Enabled = True
        DataGrid1.DataSource = Limpiar
        ped1.Focus()
    End Sub

    Private Sub ComboBox1_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TxtPallet.Focus()
    End Sub

    Private Sub TxtPallet_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPallet.KeyPress
        If e.KeyChar = ChrW(13) Then
            If RadioButton2.Checked = True Then
                'Modificacion Pallets Código mayor a 1000000
                Dim CodPalFrm As String = "000000000" & TxtPallet.Text.Trim
                CodPalFrm = CodPalFrm.Substring(CodPalFrm.Length - 9, 9)
                TxtPallet.Text = CodPalFrm

                'If TxtPallet.Text.Length = 6 Then
                '    TxtPallet.Text = "000" + TxtPallet.Text
                'End If
                'Modificacion Pallets Código mayor a 1000000

                If TxtPallet.Text.Length = 9 Then

                    Dim valor_pallet As String = TxtPallet.Text


                    Dim sqlEsta As String = "SELECT orden, pd.pedido FROM Pedidos_detalle AS pd , pedidos_ficha AS pf " & _
                                            "WHERE pd.pedido=pf.pedido AND pallet='" + valor_pallet.ToString() + "' AND (orden='" + ped1.Text + "'" + _Or + ")"

                    Dim tabla_esta As DataTable = fnc.ListarTablasSQL(sqlEsta)

                    If tabla_esta.Rows.Count > 0 Then

                        TxtPallet.Text = valor_pallet.ToString()
                        TxtPallet.Enabled = False
                        txtposicion.Enabled = True
                        txtposicion.Focus()
                    Else
                        TxtPallet.Text = ""
                        txtposicion.Enabled = False
                    End If
                Else
                    MsgBox("El pallet ingresado no existe", MsgBoxStyle.Information, "Aviso")
                    TxtPallet.Text = ""
                    TxtPallet.Focus()
                End If
            Else

                If TxtPallet.Text.Length = 21 Then

                    Dim valor_pallet As String = TxtPallet.Text.Remove(0, 11)
                    valor_pallet = valor_pallet.Remove(9, 1)

                    Dim sqlEsta As String = "SELECT orden, pd.pedido FROM Pedidos_detalle AS pd , pedidos_ficha AS pf " & _
                                            "WHERE pd.pedido=pf.pedido AND pallet='" + valor_pallet.ToString() + "' AND (orden='" + ped1.Text + "'" + _Or + ")"

                    Dim tabla_esta As DataTable = fnc.ListarTablasSQL(sqlEsta)

                    If tabla_esta.Rows.Count > 0 Then

                        TxtPallet.Text = valor_pallet.ToString()
                        TxtPallet.Enabled = False
                        txtposicion.Enabled = True
                        txtposicion.Focus()


                    Else
                        TxtPallet.Text = ""
                        txtposicion.Enabled = False
                    End If
                Else
                    MsgBox("El pallet ingresado no existe", MsgBoxStyle.Information, "Aviso")
                    TxtPallet.Text = ""
                    TxtPallet.Focus()
                End If
            End If
        Else
            SoloNumeros(sender, e)
        End If

    End Sub

    Private Sub txtposicion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtposicion.KeyPress
        If e.KeyChar = ChrW(13) Then

            txtpiso.Focus()

            Dim valor_pallet As String = TxtPallet.Text

            If txtposicion.Text.Length = 13 Then

                txtcamara.Text = txtposicion.Text.Chars(6) + "" + txtposicion.Text.Chars(7)
                txtbanda.Text = txtposicion.Text.Chars(8) + "" + txtposicion.Text.Chars(9)
                txtcolumna.Text = txtposicion.Text.Chars(10) + "" + txtposicion.Text.Chars(11)



                Dim sql As String = "SELECT zonap,trans from camaraconf where camara ='" + txtcamara.Text.Trim() + "' "
                Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

                If tabla.Rows.Count > 0 Then

                    If tabla.Rows.Count > 0 Then



                        If tabla.Rows(0)(0).ToString() = "1" Then

                            txtpiso.Text = "01"
                            txtnivel.Text = "0"
                            pos()

                        Else
                            MsgBox("Posicion no es una Zona de pedidos", MsgBoxStyle.Information, "Aviso")
                            txtposicion.Text = ""
                            txtposicion.Focus()
                            Exit Sub


                        End If



                    End If
                End If
                'If txtcamara.Text = "71" Or txtcamara.Text = "72" _
                '  Or txtcamara.Text = "73" Or txtcamara.Text = "74" _
                '  Or txtcamara.Text = "75" Or txtcamara.Text = "76" _
                '  Or txtcamara.Text = "61" Or txtcamara.Text = "62" _
                '  Or txtcamara.Text = "63" Or txtcamara.Text = "64" _
                '  Or txtcamara.Text = "91" Or txtcamara.Text = "92" _
                '  Or txtcamara.Text = "81" Or txtcamara.Text = "82" Then

                '    ' corresponde a Anden

                '    txtpiso.Text = "00"
                '    txtnivel.Text = "0"
                '    pos()

                'End If

            End If

        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim frm As New frm_Pos
        'accion_global = 1
        'frm.ShowDialog()
        Dim f As New frm_Pos
        accion_global = 1
        f.usuario = encargado_global
        f.cargo = ""
        f.perfil = ""
        f.codigo = Convert.ToString(id_global)
        f.ShowDialog()

    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        'Necesario para pedidos pendientes
        btn_pedidos_pendientes.Enabled = False
        mod_ped1 = ""
        mod_ped2 = ""
        mod_ped3 = ""
        'Fin
        _Or = ""
        i1 = False
        i2 = False
        i3 = False

        rev1 = False
        rev2 = False
        rev3 = False

        term1 = False
        term2 = False
        term3 = False

        If ped1.Text = "" Or ped1.Text = "0" Then
            lmensaje.Text = "Debe seleccionar el pedido 1"
            ped1.Focus()
            Return
        End If
        BtnBuscar.Enabled = False
        If ped2.Text <> "" Then
            _Or = _Or + " OR Orden='" + ped2.Text + "' "
        End If
        If ped3.Text <> "" Then
            _Or = _Or + " OR Orden='" + ped3.Text + "' "
        End If

        Dim sql As String = "SELECT pedido, terminado, Orden, codvig  FROM pedidos_ficha WHERE terminado<>'1' AND codvig='0' AND (Orden='" + ped1.Text + "' " + _Or + ")"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

        If tabla.Rows.Count > 0 Then

            For i As Integer = 0 To tabla.Rows.Count - 1

                If tabla.Rows(i)(2).ToString() = ped1.Text AndAlso (tabla.Rows(i)(1).ToString() = "0" AndAlso tabla.Rows(i)(3).ToString() = "0") Then
                    i1 = True
                End If

                If tabla.Rows(i)(2).ToString() = ped2.Text AndAlso (tabla.Rows(i)(1).ToString() = "0" AndAlso tabla.Rows(i)(3).ToString() = "0") Then
                    i2 = True
                End If

                If tabla.Rows(i)(2).ToString() = ped3.Text AndAlso (tabla.Rows(i)(1).ToString() = "0" AndAlso tabla.Rows(i)(3).ToString() = "0") Then
                    i3 = True
                End If

            Next
            If OrdenaNumeros() = False Then
                Exit Sub
            End If

            pedido = tabla.Rows(0)(0).ToString()
            If ACTUALIZA_GRILLA() = False Then
                Return
            End If
            ped1.Enabled = False

            'guarda quien tomo el pedido

            Dim sqlactualiza As String = "UPDATE pedidos_ficha SET encargado='" + encargado_global + "'  WHERE (Orden='" + ped1.Text + "' " + _Or + ")"

            While (fnc.MovimientoSQL(sqlactualiza) = 0)
            End While
            TxtPallet.Focus()

        Else
            MsgBox("El o los pedidos seleccionados no corresponden", MsgBoxStyle.Critical, "Aviso")
            Btn_LimpiaPedido_Click(Nothing, Nothing)
            Exit Sub
        End If

    End Sub

    Function OrdenaNumeros() As Boolean

        If i1 = False Then
            ped1.Text = ""
        End If

        If i2 = False Then
            ped2.Text = ""
        End If

        If i3 = False Then
            ped3.Text = ""
        End If

        If i1 = False AndAlso i2 = False AndAlso i3 = False Then
            MsgBox("No tiene pedidos a preparar", MsgBoxStyle.Critical, "Aviso")
            Btn_LimpiaPedido_Click(Nothing, Nothing)
            Return False
        End If

        If i1 = False AndAlso i2 = True Then
            i1 = True
            i2 = False
            ped1.Text = ped2.Text
            ped2.Text = ""
        End If

        If i1 = False AndAlso i3 = True Then
            i1 = True
            i3 = False
            ped1.Text = ped3.Text
            ped3.Text = ""
        End If

        If i2 = False AndAlso i3 = True Then
            i2 = True
            i3 = False
            ped2.Text = ped3.Text
            ped3.Text = ""
        End If
        Return True
    End Function

    Private Sub Frm_Preparar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RadioButton1.Checked = True
        Timer1.Enabled = True
        'Limpiar.Columns.Add("pallet")
        'Limpiar.Columns.Add("posicion")
        'Limpiar.Columns.Add("orden")
        DataGrid1.DataSource = Limpiar

        ped1.Text = mod_ped1
        ped2.Text = mod_ped2
        ped3.Text = mod_ped3

        If mod_ped1 = "" Then
            ped1.Enabled = True
            ped1.Focus()
        Else
            ped1.Enabled = False
        End If

        If mod_ped2 = "" And mod_ped1 <> "" Then
            ped2.Enabled = True
            ped2.Focus()
        Else
            ped2.Enabled = False
        End If

        If mod_ped3 = "" And mod_ped2 <> "" Then
            ped3.Enabled = True
            ped3.Focus()
        Else
            ped3.Enabled = False
        End If

    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If lmensaje.Text.Trim <> "" AndAlso _LimpiaMensaje = False Then
            _LimpiaMensaje = True
        Else
            lmensaje.Text = ""
            _LimpiaMensaje = False
        End If
    End Sub

    Private Sub Frm_Preparar_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Timer1.Enabled = False
    End Sub

    Private Sub Frm_Preparar_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = System.Windows.Forms.Keys.Up) Then
            'Up
        End If
        If (e.KeyCode = System.Windows.Forms.Keys.Down) Then
            'Down
        End If
        If (e.KeyCode = System.Windows.Forms.Keys.Left) Then
            'Left
        End If
        If (e.KeyCode = System.Windows.Forms.Keys.Right) Then
            'Right
        End If
        If (e.KeyCode = System.Windows.Forms.Keys.Enter) Then
            'Enter
        End If

    End Sub
    Sub logest()
        Dim qry As String = "INSERT INTO Pedido_Est(pedido,pallet ,est ,fecha_reg)VALUES ()"

        fnc.MovimientoSQL(qry)
    End Sub
    Private Sub txtnivel_KeyPress_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnivel.KeyPress
        'If e.KeyChar = ChrW(13) Then

        '    Dim valor_pallet As String = TxtPallet.Text

        '    If txtposicion.Text.Length = 13 Then

        '        Dim camara As String = txtposicion.Text.Chars(6) + "" + txtposicion.Text.Chars(7)
        '        Dim banda As String = txtposicion.Text.Chars(8) + "" + txtposicion.Text.Chars(9)
        '        Dim columna As String = txtposicion.Text.Chars(10) + "" + txtposicion.Text.Chars(11)
        '        Dim piso As String = txtpiso.Text
        '        Dim nivel As String = txtnivel.Text

        '        Dim Sql_Ocupada As String = "SELECT * FROM rackdeta WHERE racd_ca='" + camara + "' AND racd_ba='" + banda + "' AND " & _
        '                                    "racd_co='" + columna + "' AND racd_pi='" + piso + "'  "

        '        Dim tabla_ocupada As DataTable = fnc.ListarTablasSQL(Sql_Ocupada)
        '        If tabla_ocupada.Rows.Count > 0 Then
        '            lmensaje.Text = "Posición ocupada por el pallet Nº " + tabla_ocupada.Rows(0)(1).ToString()

        '        Else

        '            Dim numPedido As Integer = devuelvePedido(valor_pallet.ToString)

        '            Dim sqlActualiza As String = "UPDATE pedidos_detalle SET est='1' WHERE pallet='" + valor_pallet.ToString() + "'"
        '            If fnc.MovimientoSQL(sqlActualiza) > 0 Then

        '                'AQUIIIIIIIIIIIIIIIIIIIIIIIIIII

        '                Dim sqlins As String = "INSERT INTO Pedido_Est(pallet ,fecha_reg,pedido,encargado)VALUES ('" + valor_pallet.ToString() + "',GETDATE(),'" + numPedido.ToString() + "','" + valor_pallet.ToString() + "')"

        '                fnc.MovimientoSQL(sqlins)


        '                Panel1.BackColor = Color.Green

        '                Try
        '                    con.conectarSQL()

        '                    Dim _cmd As SqlCommand = New SqlCommand("PAG_POSICIONAR", con.conSQL)
        '                    _cmd.CommandType = CommandType.StoredProcedure
        '                    _cmd.Parameters.AddWithValue("@pallet", valor_pallet.ToString())
        '                    _cmd.Parameters.AddWithValue("@camara", camara)
        '                    _cmd.Parameters.AddWithValue("@banda", banda)
        '                    _cmd.Parameters.AddWithValue("@columna", columna)
        '                    _cmd.Parameters.AddWithValue("@piso", piso)
        '                    _cmd.Parameters.AddWithValue("@nivel", nivel)
        '                    _cmd.Parameters.AddWithValue("@tipo", "RR")
        '                    _cmd.Parameters.AddWithValue("@encargado", fnc.CerosAnteriorString(id_global.ToString(), 3))
        '                    Dim resp As Integer = 0

        '                    Try
        '                        resp = Convert.ToInt32(_cmd.ExecuteScalar())
        '                    Catch ex As Exception
        '                        resp = 1
        '                    End Try

        '                    If resp = 0 Then
        '                        lmensaje.Text = "Grabación exitosa"
        '                        txtnivel.Text = ""
        '                        txtpiso.Text = ""
        '                    ElseIf resp < 4 AndAlso resp <> 0 Then
        '                        lmensaje.Text = "Error al actualizar" + resp.ToString()
        '                    ElseIf resp = 4 Then
        '                        lmensaje.Text = "El pallet no existe"
        '                    End If
        '                    con.cerrarSQL()

        '                Catch ex As Exception

        '                End Try

        '                If ACTUALIZA_GRILLA() = False Then
        '                    Btn_LimpiaPedido_Click(Nothing, Nothing)
        '                    Return
        '                End If

        '                TxtPallet.Text = ""
        '                TxtPallet.Enabled = True
        '                txtposicion.Enabled = False
        '                txtposicion.Text = ""
        '                TxtPallet.Focus()

        '                '----------------------------------------
        '            Else
        '                Panel1.BackColor = Color.Red
        '                txtposicion.Text = ""
        '                txtposicion.Focus()
        '            End If
        '        End If
        '    Else
        '        MsgBox("La etiqueta ingresada no es valida", MsgBoxStyle.Information, "Aviso")
        '    End If
        'End If

    End Sub
    Private Sub pos()

        Dim valor_pallet As String = TxtPallet.Text

        If txtposicion.Text.Length = 13 Then

            Dim camara As String = txtposicion.Text.Chars(6) + "" + txtposicion.Text.Chars(7)
            Dim banda As String = txtposicion.Text.Chars(8) + "" + txtposicion.Text.Chars(9)
            Dim columna As String = txtposicion.Text.Chars(10) + "" + txtposicion.Text.Chars(11)
            Dim piso As String = txtpiso.Text
            Dim nivel As String = txtnivel.Text

            Dim numPedido As Integer = devuelvePedido(valor_pallet.ToString)

            Dim sqlActualiza As String = "UPDATE pedidos_detalle SET est='1' WHERE pallet='" + valor_pallet.ToString() + "'"
            If fnc.MovimientoSQL(sqlActualiza) > 0 Then

                'AQUIIIIIIIIIIIIIIIIIIIIIIIIIII
                Dim sqlins As String = "INSERT INTO Pedido_Est(pallet ,fecha_reg,pedido,encargado)VALUES ('" + valor_pallet.ToString() + "',GETDATE(),'" + numPedido.ToString() + "','" + encargado_global + "')"

                fnc.MovimientoSQL(sqlins)


                Panel1.BackColor = Color.Green

                Try
                    con.conectarSQL()

                    Dim _cmd As SqlCommand = New SqlCommand("PAG_POSICIONAR", con.conSQL)
                    _cmd.CommandType = CommandType.StoredProcedure
                    _cmd.Parameters.AddWithValue("@pallet", valor_pallet.ToString())
                    _cmd.Parameters.AddWithValue("@camara", camara)
                    _cmd.Parameters.AddWithValue("@banda", banda)
                    _cmd.Parameters.AddWithValue("@columna", columna)
                    _cmd.Parameters.AddWithValue("@piso", piso)
                    _cmd.Parameters.AddWithValue("@nivel", nivel)
                    _cmd.Parameters.AddWithValue("@tipo", "RR")
                    _cmd.Parameters.AddWithValue("@encargado", fnc.CerosAnteriorString(id_global.ToString(), 3))
                    Dim resp As Integer = 0

                    Try
                        resp = Convert.ToInt32(_cmd.ExecuteScalar())
                    Catch ex As Exception
                        resp = 1
                    End Try

                    If resp = 0 Then
                        lmensaje.Text = "Grabación exitosa"
                        txtnivel.Text = ""
                        txtpiso.Text = ""
                    ElseIf resp < 4 AndAlso resp <> 0 Then
                        lmensaje.Text = "Error al actualizar" + resp.ToString()
                    ElseIf resp = 4 Then
                        lmensaje.Text = "El pallet no existe"
                    End If
                    con.cerrarSQL()

                Catch ex As Exception

                End Try

                If ACTUALIZA_GRILLA() = False Then
                    Btn_LimpiaPedido_Click(Nothing, Nothing)
                    Return
                End If

                TxtPallet.Text = ""
                TxtPallet.Enabled = True
                txtposicion.Enabled = False
                txtposicion.Text = ""
                TxtPallet.Focus()

                '----------------------------------------
            Else
                Panel1.BackColor = Color.Red
                txtposicion.Text = ""
                txtposicion.Focus()
            End If

        Else
            MsgBox("La etiqueta ingresada no es valida", MsgBoxStyle.Information, "Aviso")
        End If


    End Sub

    Private Sub txtpiso_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpiso.TextChanged
        txtnivel.Focus()
    End Sub

    Function devuelvePedido(ByVal pallet As String) As Integer
        Dim sql As String = "SELECT MAX(orden) orden, pallet " & _
                            "  FROM pedidos_detalle " & _
                            " INNER JOIN rackdeta ON rackdeta.racd_codi = pedidos_detalle.pallet " & _
                            " INNER JOIN Pedidos_ficha ON pedidos_ficha.pedido = Pedidos_detalle.pedido " & _
                            " WHERE (pedidos_detalle.pallet='" + pallet + "') " & _
                            "   AND pedidos_detalle.est <> '1' " & _
                            " GROUP BY pallet " & _
                            " ORDER BY pallet ASC"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        Dim pedido As Integer = 0

        If tabla.Rows.Count > 0 Then
            For i As Integer = 0 To tabla.Rows.Count - 1

                If tabla.Rows(i)(0).ToString() <> "" Then
                    pedido = Convert.ToInt32(tabla.Rows(i)(0))
                    Return pedido
                Else
                    Return pedido
                End If

            Next
        Else
            Return pedido
        End If
    End Function

    Private Sub btn_pedidos_pendientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pedidos_pendientes.Click
        Dim f As New Frm_PedidosPendientes
        f.Show()
        Me.Close()
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        mod_ped1 = ""
        mod_ped2 = ""
        mod_ped3 = ""
        ped1.Text = ""
        ped2.Text = ""
        ped3.Text = ""
        ped2.Enabled = False
        ped3.Enabled = False
        ped1.Enabled = True
        ped1.Focus()
        btn_pedidos_pendientes.Enabled = True
    End Sub
End Class