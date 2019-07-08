Imports System.Data.SqlClient

Public Class Frm_IngresoTunel

    Public usuario As String = ""
    Public cargo As String = ""
    Public perfil As String = ""
    Public codigo As String = ""
    Public pallet_global As String = ""
    Public estado_pallet As String = ""

    Dim fnc As New Funciones
    Dim con As New Conexion

#Region "Eventos"

    Private Sub Frm_IngresoTunel_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        cb_Tipo.SelectedIndex = 1
        Me.Close()
    End Sub

    Private Sub Frm_IngresoTunel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cb_Tipo.SelectedIndex = 0
        cb_posicionar.SelectedIndex = 0
        cb_posicionar.Enabled = False
        dtpFecha.MinDate = DateAdd(DateInterval.Month, -2, Now)
        dtpFecha.Value = fnc.DevuelveFechaServidor()
    End Sub

    Private Sub cb_Tipo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cb_Tipo.LostFocus
        If cb_Tipo.SelectedIndex = 0 Then
            MsgBox("Debe Seleccionar un Tipo", MsgBoxStyle.Information, "Ingreso Tunel")
            cb_Tipo.Focus()
        End If
    End Sub

    Private Sub cb_Tipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_Tipo.SelectedIndexChanged
        Select Case cb_Tipo.SelectedIndex
            Case 1
                
                Label8.Text = "Ingreso:"

                Dim sql As String = "SELECT cam_codi,cam_descr FROM camaras WHERE cam_descr LIKE '%TUNEL%' OR cam_descr LIKE '%TUNEL%2' ORDER BY 2 ;"
                Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

                cb_posicion.DataSource = Nothing
                cb_posicion.DataSource = tabla
                cb_posicion.DisplayMember = "cam_descr"
                cb_posicion.ValueMember = "cam_codi"
                estado_pallet = "2"

                cb_posicionar.SelectedIndex = 0
                cb_posicionar.Enabled = False

            Case 2
               
                Label8.Text = "Salida:"

                Dim sql As String = "SELECT cam_codi,cam_descr FROM camaras WHERE cam_descr LIKE '%ANDEN%' OR cam_descr LIKE '%SALA%' ORDER BY 2 "
                Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

                cb_posicion.DataSource = Nothing
                cb_posicion.DataSource = tabla
                cb_posicion.DisplayMember = "cam_descr"
                cb_posicion.ValueMember = "cam_codi"
                estado_pallet = "0"

                cb_posicionar.SelectedIndex = 0
                cb_posicionar.Enabled = True

            Case Else
                Label8.Text = ""
        End Select
    End Sub

    Private Sub txt_Guia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Guia.KeyPress
        If e.KeyChar = ChrW(13) Then

            Dim nroAux = "0000000"
            Dim nroGui = Trim(txt_Guia.Text)
            Dim nroGuiFrm = nroAux & nroGui
            Dim nroGuiLen = Len(nroGuiFrm) - 7
            Dim nroGuiFin = nroGuiFrm.ToString.Substring(nroGuiLen)

            txt_Guia.Text = nroGuiFin

            'If txt_Guia.Text.Length >= 4 Then
            '    txt_Guia.Text = Trim(txt_Guia.Text)
            '    Dim valor As String = "000" + txt_Guia.Text
            '    txt_Guia.Text = valor
            'End If

            Select Case cb_Tipo.SelectedIndex
                Case 1
                    TraeIngresoTunel(txt_Guia.Text)
                Case 2
                    TraeSalidaTunel(txt_Guia.Text)
            End Select
        End If
    End Sub

    Private Sub txt_Temp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Temp.KeyPress
        If rb_Total.Checked And e.KeyChar = ChrW(13) Then
            txt_Temp.Text = Trim(txt_Temp.Text)
            Select Case cb_Tipo.SelectedIndex
                Case 1
                    validarTunelAnterior()
                    IngresoTunelTotal(txt_Guia.Text, txt_Temp.Text)
                Case 2
                    If (validaFechaSalida(txt_Guia.Text.Trim, "")) Then
                        MsgBox("La fecha de salida debe ser mayor a la fecha de entrada.", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If

                    SalidaTunelTotal(txt_Guia.Text, txt_Temp.Text)
            End Select

            Select Case cb_Tipo.SelectedIndex
                Case 1
                    TraeIngresoTunel(txt_Guia.Text)
                Case 2
                    TraeSalidaTunel(txt_Guia.Text)
            End Select
        End If
        If rb_Parcial.Checked And e.KeyChar = ChrW(13) Then
            txt_Pallet.Focus()
        End If
    End Sub

    Private Sub txt_Pallet_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Pallet.KeyPress

        Dim tipoError As Integer

        If e.KeyChar = ChrW(13) Then

            If txt_Pallet.Text.Length > 4 Then
                If txt_Pallet.Text.Chars(0).ToString() + txt_Pallet.Text.Chars(1).ToString() + txt_Pallet.Text.Chars(2).ToString() = "]C1" Then
                    txt_Pallet.Text = txt_Pallet.Text.Remove(0, 3)
                End If
            End If

            Select Case cb_Tipo.SelectedIndex
                Case 1
                    If (txt_Pallet.Text.Trim = "") Then
                        MsgBox("Debe ingresar un Nro. de Pallet", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If

                    If ValidaPallet(txt_Guia.Text, txt_Pallet.Text, tipoError) Then
                        Color.BackColor = Drawing.Color.Green
                        Dim posicion As String = cb_posicion.SelectedValue.ToString
                        Dim pallet As String = txt_Pallet.Text
                        IngresoTunelParcial(txt_Guia.Text, pallet, txt_Temp.Text)

                        If cb_posicionar.SelectedIndex = 0 Then
                            CambioPosicionPallet(pallet, posicion, "SI")
                        End If

                        If cb_posicionar.SelectedIndex = 1 Then
                            TunelSinPosicion(pallet, posicion)
                        End If

                        Dim separado As String = TransformaPallet(pallet, "SI")
                        pallet_global = separado
                        cambiarEstadoTunel()

                        txt_Pallet.Text = ""
                    Else
                        Select Case tipoError
                            Case 1
                                mensaje.Text = "Pallet leído NO corresponde " + txt_Pallet.Text.Remove(0, txt_Pallet.Text.Length - 7)
                                Color.BackColor = Drawing.Color.Red
                                txt_Pallet.Text = ""
                            Case 2
                                mensaje.Text = "Pallet ya fue Leído " + txt_Pallet.Text.Remove(0, txt_Pallet.Text.Length - 7)
                                Color.BackColor = Drawing.Color.Orange
                                txt_Pallet.Text = ""
                        End Select
                    End If
                Case 2
                    If (txt_Pallet.Text.Trim = "") Then
                        Exit Sub
                    End If

                    If ValidaPallet(txt_Guia.Text, txt_Pallet.Text, tipoError) Then
                        Color.BackColor = Drawing.Color.Green
                        Dim posicion As String = cb_posicion.SelectedValue.ToString
                        Dim pallet As String = txt_Pallet.Text

                        If (validaFechaSalida(txt_Guia.Text.Trim, pallet)) Then
                            MsgBox("La fecha de salida debe ser mayor a la fecha de entrada.", MsgBoxStyle.Critical, "Error")
                            Exit Sub
                        End If

                        SalidaTunelParcial(txt_Guia.Text, pallet, txt_Temp.Text)

                        If cb_posicionar.SelectedIndex = 0 Then
                            CambioPosicionPallet(pallet, posicion, "SI")
                        End If

                        If cb_posicionar.SelectedIndex = 1 Then
                            TunelSinPosicion(pallet, posicion)
                        End If

                        Dim separado As String = TransformaPallet(pallet, "SI")
                        pallet_global = separado
                        cambiarEstadoTunel()

                        txt_Pallet.Text = ""
                    Else
                        Select Case tipoError
                            Case 1
                                mensaje.Text = "Pallet leído NO corresponde " + txt_Pallet.Text.Remove(0, txt_Pallet.Text.Length - 7)
                                Color.BackColor = Drawing.Color.Red
                                txt_Pallet.Text = ""
                            Case 2
                                mensaje.Text = "Pallet ya fue Leído " + txt_Pallet.Text.Remove(0, txt_Pallet.Text.Length - 7)
                                Color.BackColor = Drawing.Color.Orange
                                txt_Pallet.Text = ""
                        End Select
                    End If
            End Select
        End If
    End Sub

    Function validaFechaSalida(ByVal guia As String, ByVal pallet As String) As Boolean
        Dim Resp As Boolean = True

        Dim fecha As Date = dtpFecha.Value

        Try
            Dim sql As String = "SP_Salida_Tunel_Validar_Fecha '" & guia & "','" & devuelve_fecha_Formato2(fecha) & "','" & pallet & "'"
            Dim dt As DataTable = fnc.ListarTablasSQL(sql)

            If (dt.Rows.Count > 0) Then
                If (dt.Rows(0).Item(0).ToString.Trim = "1") Then
                    Resp = False
                End If
            End If
        Catch ex As Exception

        End Try

        Return Resp
    End Function

#End Region

#Region "Procedimientos"

    Sub TraeIngresoTunel(ByVal guia As String)

        DataGrid1.DataSource = Nothing

        Dim sql As String = "SELECT * FROM fichrece WHERE frec_codi='" + guia + "' AND frec_RecepTunel='2'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

        If tabla.Rows.Count = 0 Then
            MsgBox("Guia de Recepcion NO Existe o NO fue registrada con ingreso a túnel", MsgBoxStyle.Information, cb_Tipo.Text)
            txt_Guia.Focus()
            txt_Guia.SelectAll()
            Exit Sub
        End If

        Dim sqlRZ As String = "SELECT clientes.cli_nomb FROM fichrece,clientes WHERE fichrece.frec_rutcli = clientes.cli_rut AND fichrece.frec_codi = '" + guia + "'"
        Dim tablaRZ As DataTable = fnc.ListarTablasSQL(sqlRZ)

        lbRazonSocial.Text = tablaRZ.Rows(0)(0).ToString()

        Dim sqldeta As String = "SELECT drec_codi FROM detarece WHERE frec_codi1='" + guia + "'"
        Dim tabladeta As DataTable = fnc.ListarTablasSQL(sqldeta)

        If tabla.Rows.Count > 0 Then
            Dim sqlDetalle As String = "SELECT SUBSTRING(frec_codi,11,9) AS frec_codi ,temp_ingreso FROM tuneles WHERE frec_guia='" + guia + "' ORDER BY frec_codi"
            Dim tablad As DataTable = fnc.ListarTablasSQL(sqlDetalle)

            If tablad.Rows.Count > 0 Then
                rb_Total.Enabled = False
                rb_Parcial.Checked = True
                DataGrid1.DataSource = tablad
            End If

            If tablad.Rows.Count = tabladeta.Rows.Count Then
                lblcanttotal.Text = tablad.Rows.Count.ToString & "/" & tabladeta.Rows.Count.ToString
                MsgBox("Ya estan todos los Pallets en tunel", MsgBoxStyle.Information, cb_Tipo.Text)
                txt_Pallet.Text = ""
                txt_Guia.Focus()
                txt_Guia.SelectAll()
                DataGrid1.DataSource = Nothing
                rb_Total.Enabled = True
                Exit Sub
            End If

            lblcanttotal.Text = tablad.Rows.Count.ToString & "/" & tabladeta.Rows.Count.ToString

            txt_Guia.Enabled = False
            cb_Tipo.Enabled = False
            txt_Temp.Text = ""
            txt_Pallet.Text = ""
            txt_Temp.Focus()
        End If
    End Sub

    Sub TraeSalidaTunel(ByVal guia As String)

        DataGrid1.DataSource = Nothing

        Dim sql As String = "SELECT * FROM fichrece WHERE frec_codi='" + guia + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

        If tabla.Rows.Count = 0 Then
            MsgBox("Guia de Recepcion NO Existe", MsgBoxStyle.Information, cb_Tipo.Text)
            txt_Guia.Focus()
            txt_Guia.SelectAll()
            Exit Sub
        End If

        Dim sqlRZ As String = "SELECT clientes.cli_nomb FROM fichrece,clientes WHERE fichrece.frec_rutcli = clientes.cli_rut AND fichrece.frec_codi = '" + guia + "'"
        Dim tablaRZ As DataTable = fnc.ListarTablasSQL(sqlRZ)

        lbRazonSocial.Text = tablaRZ.Rows(0)(0).ToString()

        Dim sqldeta As String = "SELECT frec_codi FROM tuneles WHERE frec_guia='" + guia + "' AND temp_salida IS NULL"
        Dim tabladeta As DataTable = fnc.ListarTablasSQL(sqldeta)

        If tabla.Rows.Count > 0 Then
            Dim sqlDetalle As String = "SELECT SUBSTRING(frec_codi,11,9) AS frec_codi FROM tuneles WHERE frec_guia='" + guia + "' AND temp_salida IS NULL ORDER BY frec_codi "
            Dim tablad As DataTable = fnc.ListarTablasSQL(sqlDetalle)

            If tablad.Rows.Count > 0 Then
                DataGrid1.DataSource = tablad
            End If

            lblcanttotal.Text = tablad.Rows.Count.ToString & "/" & tabladeta.Rows.Count.ToString

            txt_Guia.Enabled = False
            cb_Tipo.Enabled = False
            txt_Temp.Text = ""
            txt_Pallet.Text = ""
            txt_Temp.Focus()
        End If
    End Sub
  

    Sub IngresoTunelTotal(ByVal guia As String, ByVal temp_ingreso As String)
        Dim msg = MsgBox("Desea Ingresar Pallets a Tunel ?", MsgBoxStyle.OkCancel, cb_Tipo.Text)

        If msg = vbOK Then
            Dim qry As String
            Dim fecha As Date
            Dim hora As String

            fecha = dtpFecha.Value
            hora = dtpHora.Text

            qry = "  INSERT INTO tuneles(frec_guia,frec_codi,fechora_ingreso,temp_ingreso)"
            qry += " SELECT frec_codi1,drec_etiqueta,'" + devuelve_fecha_Formato2(fecha) + " " + hora + "','" + temp_ingreso + "'" & _
                   "   FROM detarece " & _
                   "  WHERE frec_codi1 = '" + guia + "'"


            fnc.MovimientoSQL(qry)


            Dim sqlDetalle As String = "SELECT frec_codi FROM tuneles WHERE frec_guia='" + guia + "' ORDER BY frec_codi"
            Dim tablad As DataTable = fnc.ListarTablasSQL(sqlDetalle)

            Dim posicion As String = cb_posicion.SelectedValue.ToString()

            If tablad.Rows.Count > 0 Then

                For i As Integer = 0 To tablad.Rows.Count - 1
                    Dim separado As String = TransformaPallet(tablad.Rows(i)(0).ToString(), "SI")
                    pallet_global = separado
                    cambiarEstadoTunel()

                    If cb_posicionar.SelectedIndex = 0 Then
                        CambioPosicionPallet(tablad.Rows(i)(0).ToString(), posicion, "NO")
                    End If

                    If cb_posicionar.SelectedIndex = 1 Then
                        TunelSinPosicion(tablad.Rows(i)(0).ToString(), posicion)
                    End If
                Next
            End If

        End If

    End Sub

    Sub SalidaTunelTotal(ByVal guia As String, ByVal temp_salida As String)
        Dim msg = MsgBox("Desea Salida Total de Pallets de Tunel ?", MsgBoxStyle.OkCancel, cb_Tipo.Text)

        If msg = vbOK Then

            Dim fecha As Date
            Dim hora As String

            fecha = dtpFecha.Value
            hora = dtpHora.Text

            Dim sql As String = "SELECT frec_codi FROM tuneles WHERE frec_guia = '" + guia + "' AND temp_salida IS NULL"
            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            Dim posicion As String = cb_posicion.SelectedValue.ToString()

            If tabla.Rows.Count > 0 Then
                For i As Integer = 0 To tabla.Rows.Count - 1
                    Dim separado As String = TransformaPallet(tabla.Rows(i)(0).ToString(), "SI")
                    pallet_global = separado
                    cambiarEstadoTunel()

                    If cb_posicionar.SelectedIndex = 0 Then
                        CambioPosicionPallet(tabla.Rows(i)(0).ToString(), posicion, "NO")
                    End If

                    If cb_posicionar.SelectedIndex = 1 Then
                        TunelSinPosicion(tabla.Rows(i)(0).ToString(), posicion)
                    End If

                Next
            End If

            Dim qry As String
            qry = "  UPDATE tuneles "
            qry += "    SET temp_salida = '" + temp_salida + "',"
            qry += "        fechora_salida = '" + devuelve_fecha_Formato2(fecha) + " " + hora + "'"
            qry += "  WHERE frec_guia = '" + guia + "'"
            qry += "    AND temp_salida IS NULL "

            fnc.MovimientoSQL(qry)

        End If


    End Sub

    Function ValidaPallet(ByVal guia As String, ByVal pallet As String, ByRef tipoError As Integer) As Boolean
        tipoError = 0

        Dim sql As String = "SELECT * FROM detarece WHERE drec_etiqueta = '" + pallet + "' AND frec_codi1 = '" + guia + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

        If tabla.Rows.Count = 0 Then
            tipoError = 1
            Return False
        End If

        Dim sql1 As String = "SELECT frec_codi FROM tuneles WHERE frec_guia='" + guia + "' AND frec_codi = '" + pallet + "'"
        If cb_Tipo.SelectedIndex = 2 Then
            sql1 += " AND temp_salida is not null"
        End If
        Dim tabla1 As DataTable = fnc.ListarTablasSQL(sql1)

        Dim sqlTunAnt = "select isnull(est_tunel,1) from rackdeta where racd_codi='" & pallet & "'"
        Dim dtTunAnt As New DataTable
        dtTunAnt = fnc.ListarTablasSQL(sql)
        If (dtTunAnt.Rows.Count > 0) Then
            Dim EstTun = dtTunAnt.Rows(0).Item(0).ToString.Trim
            If (EstTun = "0") Then
                MsgBox("Este Pallet ya estuvo en Tunel anteriormente.", MsgBoxStyle.Information, "Error")
            ElseIf (EstTun = "2") Then
                MsgBox("Este Pallet ya está en Tunel.", MsgBoxStyle.Information, "Error")
            End If
        End If

        If tabla1.Rows.Count > 0 Then
            tipoError = 2
            Return False
        End If

        Return True

    End Function

    Sub IngresoTunelParcial(ByVal guia As String, ByVal pallet As String, ByVal temp_ingreso As String)
        Dim msg = MsgBox("Desea Ingresar Pallet a Tunel ?", MsgBoxStyle.OkCancel, cb_Tipo.Text)

        If msg = vbOK Then
            Dim fecha As Date
            Dim hora As String

            fecha = dtpFecha.Value

            hora = dtpHora.Text

            Dim qry As String
            qry = "  INSERT INTO tuneles(frec_guia,frec_codi,fechora_ingreso,temp_ingreso)"
            qry += " VALUES('" + guia + "','" + pallet + "','" + devuelve_fecha_Formato2(fecha) + " " + hora + "','" + temp_ingreso + "')"

            fnc.MovimientoSQL(qry)

        End If
        txt_Pallet.Text = ""

        TraeIngresoTunel(guia)

    End Sub

    Sub SalidaTunelParcial(ByVal guia As String, ByVal pallet As String, ByVal temp_salida As String)
        Dim msg = MsgBox("Desea Salida de Pallet de Tunel ?", MsgBoxStyle.OkCancel, cb_Tipo.Text)

        If msg = vbOK Then
            Dim fecha As Date
            Dim hora As String
            Dim qry As String

            fecha = dtpFecha.Value
            hora = dtpHora.Text

            qry = "  UPDATE tuneles "
            qry += "    SET temp_salida = '" + temp_salida + "',"
            qry += "        fechora_salida = '" + devuelve_fecha_Formato2(fecha) + " " + hora + "'"
            qry += "  WHERE frec_guia = '" + guia + "'"
            qry += "    AND frec_codi = '" + pallet + "'"

            fnc.MovimientoSQL(qry)
        End If
        txt_Pallet.Text = ""

        TraeSalidaTunel(guia)

    End Sub

    Public Function TransformaPallet(ByVal pallet As String, ByVal msg As String) As String

        Dim separado As String = ""
        For i As Integer = 10 To pallet.Length - 2
            separado = separado + pallet.Chars(i)
        Next
        If msg = "SI" Then
            txt_Pallet.Text = separado
        End If

        Return separado
    End Function

    Sub CambioPosicionPallet(ByVal pallet As String, ByVal posicion As String, ByVal msg As String)

        Dim separado As String = TransformaPallet(pallet, msg)
        pallet_global = separado

        Try

            con.conectarSQL()

            Dim _cmd As SqlCommand = New SqlCommand("PAG_POSICIONAR", con.conSQL)
            _cmd.CommandType = CommandType.StoredProcedure
            _cmd.Parameters.AddWithValue("@pallet", separado)
            _cmd.Parameters.AddWithValue("@camara", posicion)
            _cmd.Parameters.AddWithValue("@banda", "00")
            _cmd.Parameters.AddWithValue("@columna", "00")
            _cmd.Parameters.AddWithValue("@piso", "00")
            _cmd.Parameters.AddWithValue("@nivel", "0")
            _cmd.Parameters.AddWithValue("@tipo", "RR")
            _cmd.Parameters.AddWithValue("@encargado", CerosAnteriorString(codigo, 3))

            Dim resp As Integer = 0

            Try
                resp = Convert.ToInt32(_cmd.ExecuteScalar())
            Catch ex As Exception
                resp = 1
            End Try

            If msg = "SI" Then
                If resp = 0 Then
                    cambiarEstadoTunel()
                    MsgBox("Grabación exitosa")
                ElseIf resp < 4 AndAlso resp <> 0 Then
                    MsgBox("Error al actualizar" + resp.ToString())
                ElseIf resp = 4 Then
                    MsgBox("El pallet no existe")
                End If
            End If

            con.cerrarSQL()

        Catch ex As Exception

        End Try
    End Sub

#End Region

    Private Sub txt_Guia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Guia.TextChanged

    End Sub

    Private Sub txt_Temp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Temp.LostFocus
        If InStr(txt_Temp.Text, ",") > 0 Then
            Dim nuevo = Replace(txt_Temp.Text, ",", ".")
            txt_Temp.Text = nuevo
        End If
    End Sub

    Private Sub cambiarEstadoTunel()
        Dim queryUpd As String
        queryUpd = "UPDATE rackdeta SET est_tunel='" + estado_pallet + "' WHERE racd_codi='" + pallet_global + "'"
        fnc.MovimientoSQL(queryUpd)
    End Sub

    Sub validarTunelAnterior()
        Try
            Dim NroGuia = txt_Guia.Text.Trim
            If (NroGuia <> "") Then
                Dim sql = "select isnull(min(est_tunel),1) from rackdeta where racd_codi like '" & NroGuia & "%'"

                Dim dt As New DataTable
                dt = fnc.ListarTablasSQL(sql)

                If (dt.Rows.Count > 0) Then
                    Dim EstTun = dt.Rows(0).Item(0).ToString.Trim

                    If (EstTun <> "1") Then
                        MsgBox("Esta Guía ya estuvo en Tunel anteriormente.", MsgBoxStyle.Information, "Error")
                    ElseIf (EstTun = "2") Then
                        MsgBox("Esta Guía tiene Pallets en Tunel.", MsgBoxStyle.Information, "Error")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al validar Tunel Previo de la Guía.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Sub TunelSinPosicion(ByVal pallet As String, ByVal PosicionTunel As String)
        Try
            Dim PallFrm As String = TransformaPallet(pallet, "NO")
            Dim CodUsu As String = CerosAnteriorString(codigo, 3)

            Dim Fecha As Date = dtpFecha.Value.ToString("yyyy/MM/dd")
            Dim Hora As String = dtpHora.Value.ToString("HH:mm")

            Dim query As String = "SP_Tunel_Sin_Posicion_MovPallet_Grabar '" & PallFrm & "','" & PosicionTunel & "','" & Fecha & "','" & Hora & "','" & CodUsu & "'"
            fnc.MovimientoSQL(query)
        Catch ex As Exception
            MsgBox("Ocurrió un error al registrar la trazabilidad del movimiento.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class