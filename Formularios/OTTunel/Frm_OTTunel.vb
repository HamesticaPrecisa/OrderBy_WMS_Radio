Imports System.Data
Imports System.Data.SqlClient

' VES Sep 2019
Public Class Frm_OTTunel

    Dim fnc As New Funciones
    Dim frec_unica As Object
    Dim frec_codi As String
    Dim frec_guiades As String
    Dim cli_nomb As String
    Dim frec_maxpallets As Integer
    Dim ot As DataRow = Nothing
    Dim cam_codi As String = ""
    Dim cam_descr As String = ""

    Dim idot As Integer = 0
    Dim numot As String = ""
    Dim status As String = "BORRADOR"

    Dim prefOTParcial As Boolean = True
    Dim maxPalletsPorTunel As Integer = 24


    Private Sub Frm_OTTunel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.Default

        ' Cargamos las preferencias de tunel
        loadPrefs()

        ' Cargamos la lista de tuneles
        Dim tuneles As DataTable = fnc.ListarTablasSQL("SELECT cam_unica, cam_descr, cam_codi " & _
                                                       "  FROM camaras " & _
                                                       " WHERE cam_tipo IN (2,2) " & _
                                                       " ORDER BY cam_codi")
        cboTunel.DataSource = tuneles
        cboTunel.DisplayMember = "cam_descr"
        cboTunel.ValueMember = "cam_unica"


        ' Cargamos la lista de mercados
        Dim mercados As DataTable = fnc.ListarTablasSQL("SELECT mer_id, mer_nombre " & _
                                                       "   FROM mercados " & _
                                                       "  WHERE mer_status = 'ACTIVO' " & _
                                                       "  ORDER BY mer_nombre")
        cboMercado.DataSource = mercados
        cboMercado.DisplayMember = "mer_nombre"
        cboMercado.ValueMember = "mer_id"



        ' Se inicializan otros elementos de la UI
        lblCliente.Text = ""
        lblCliente.Visible = True


        ' Se crea el correlativo para OTs de tunel (si no existe)
        If fnc.verificaExistencia("correlat", "cor_codi", "901") = False Then
            fnc.MovimientoSQL("INSERT INTO correlat (cor_unica, cor_codi, cor_descr, cor_correini,cor_correfin,cor_correact,cor_codact) " & _
                              " VALUES (NEWID(),'901','OT TUNEL',1,9999999,1,0)")
        End If


        ' Verificamos si el radio tiene una OT de tunel en borrador o cargando.
        ot = fnc.sqlExecuteRow("SELECT a.ott_id, a.ott_numero, a.cam_unica, a.frec_unica, b.frec_guiades, b.frec_codi, c.cli_nomb, " & _
                               "       a.mer_id, a.ott_alcance, a.ott_numpallets, d.mer_nombre, e.cam_codi, e.cam_descr, a.ott_status " & _
                               "  FROM ots_tunel a " & _
                               "  LEFT JOIN fichrece b ON b.frec_unica = a.frec_unica " & _
                               "  LEFT JOIN clientes c ON c.cli_rut = b.frec_rutcli" & _
                               "  LEFT JOIN mercados d ON d.mer_id = a.mer_id " & _
                               "  LEFT JOIN camaras e ON e.cam_unica = a.cam_unica " & _
                               " WHERE a.ott_deviceid = @deviceid " & _
                               "   AND a.ott_status = 'CARGANDO'", _
                               New SqlParameter() {New SqlParameter("@deviceid", SqlDbType.VarChar) With {.Value = deviceId}})
        If ot Is Nothing Then
            cboTunel.Text = "SELECCIONAR"
            cboMercado.Text = "(NINGUNO)"
            cboMercado.Enabled = False
        Else
            idot = CInt(ot("ott_id").ToString())
            numot = ot("ott_numero").ToString().Trim()
            status = ot("ott_status").ToString().Trim()
            cboTunel.SelectedValue = ot("cam_unica")
            txtGuia.Text = ot("frec_codi").ToString().Trim()
            lblCliente.Text = ot("cli_nomb").ToString().Trim()
            frec_unica = ot("frec_unica")
            frec_codi = ot("frec_codi").ToString()
            frec_guiades = ot("frec_guiades").ToString()
            cli_nomb = ot("cli_nomb").ToString()
            cam_codi = ot("cam_codi").ToString()
            cam_descr = ot("cam_descr").ToString()
            frec_maxpallets = CInt(ot("ott_numpallets").ToString())
            cboMercado.SelectedValue = CInt(ot("mer_id").ToString())
            If CInt(ot("ott_alcance").ToString()) = 1 Then rbtParcial.Checked = True
            txtMaxPallets.Text = ot("ott_numpallets").ToString()
            cmdOk.Text = "Continuar"
            cmdDescartar.Enabled = False
            cboMercado.Enabled = False


            cboTunel.Enabled = False
            txtGuia.Enabled = False
            btn_buscarGuia.Enabled = False
            rbtTodos.Enabled = False
            rbtParcial.Enabled = False
            txtMaxPallets.Enabled = False
            btn_buscarGuia.Enabled = False
        End If

        ' Aplicamos algunas preferencias
        If prefOTParcial = False And rbtTodos.Checked = True Then
            pnlAlcance.Visible = False
        End If
    End Sub

    Private Sub cboTunel_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTunel.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtGuia_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGuia.KeyPress
        If e.KeyChar = ChrW(13) Then
            If Not validarGuia(txtGuia.Text.Trim()) Then
                e.Handled = True
            Else
                SoloNumeros(sender, e)
            End If
        End If
    End Sub


    Private Sub btn_buscarGuia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscarGuia.Click
        buscarGuia()
    End Sub

    Private Function validarGuia(ByVal guia As String) As Boolean
        '
        ' VERIFICAMOS QUE LA GUIA EXISTA
        '
        Dim row As DataRow = fnc.sqlExecuteRow("SELECT frec_codi, frec_guiades, frec_fecrec, cli_nomb, frec_unica ,ott_pct, mer_id " & _
                                               "  FROM fichrece " & _
                                               "  LEFT JOIN clientes ON cli_rut = frec_rutcli " & _
                                               " WHERE frec_guiades = @guia OR frec_codi = @guia", _
                                               New SqlParameter() {New SqlParameter("@guia", SqlDbType.VarChar) With {.Value = guia}})
        If row Is Nothing Then
            lblCliente.Text = ""
            txtGuia.Text = ""
            MessageBox.Show("La guia indicada no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Return False
        End If


        frec_unica = row("frec_unica").ToString()
        frec_codi = row("frec_codi").ToString()
        frec_guiades = row("frec_guiades").ToString()
        cli_nomb = row("cli_nomb").ToString().Trim()
        cboMercado.SelectedValue = CInt(row("mer_id"))
        lblCliente.Text = cli_nomb

        Dim ott_pct As Decimal = CDec(row("ott_pct").ToString())

        '
        ' DETERMINAMOS LA CANTIDAD DE PALLETS NO ASOCIADOS 
        ' A OT QUE TIENE LA GUIA
        '
        row = fnc.sqlExecuteRow("SELECT COUNT(*) AS maxpallets " & _
                                "  FROM detarece a " & _
                                " WHERE frec_codi1 = @frec_codi " & _
                                "   AND drec_codi NOT IN (SELECT drec_codi FROM vwPalletsEnTunel)", _
                                New SqlParameter() { _
                                    New SqlParameter("@frec_codi", SqlDbType.VarChar) With {.Value = frec_codi} _
                                })

        If row Is Nothing Then
            MsgBox(lastSQLError, MsgBoxStyle.Critical, "Cuidado")
            Return False
        End If

        Dim numPallets As Integer = CInt(row("maxpallets").ToString())


        frec_maxpallets = numPallets
        txtMaxPallets.Text = frec_maxpallets.ToString()

        '
        ' SI LA GUIA YA TIENE PALLETS EN TUNEL, SE FUERZA 
        ' EL MODO PARCIAL
        '
        If ott_pct > 0.0 Then
            rbtParcial.Checked = True
            rbtTodos.Enabled = False
        Else
            rbtTodos.Checked = True
            rbtTodos.Enabled = True
        End If

        Return True
    End Function

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub rbtParcial_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtMaxPallets.Visible = rbtParcial.Checked
    End Sub

    Private Sub buscarGuia()
        Dim frm As frm_BuscarGuia = New frm_BuscarGuia()
        frm.ShowDialog()
        If frm.frec_guiades.Length > 0 Then
            txtGuia.Text = frm.frec_codi
            validarGuia(frm.frec_codi)
            cboMercado.Focus()
        End If
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        If status = "BORRADOR" Then
            crearOT()
        ElseIf status = "CARGANDO" Then
            actualizarOT()
        Else
            Picking()
        End If

    End Sub


    Private Sub crearOT()
        If cboTunel.Text = "SELECCIONAR" Or _
           cboMercado.Text = "SELECCIONAR" Or _
           txtGuia.Text.Length = 0 Then
            MessageBox.Show("Todos los datos son obligatorios", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Return
        End If

        If rbtParcial.Checked And CInt("0" & txtMaxPallets.Text) = 0 Then
            MessageBox.Show("Debe indicar la cantidad de pallets a incluir en la OT", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            txtMaxPallets.Focus()
            Return
        End If

        If rbtParcial.Checked And CInt("0" & txtMaxPallets.Text) > frec_maxpallets Then
            MessageBox.Show("La cantidad de pallets no puede ser mayor a " + frec_maxpallets.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            txtMaxPallets.Text = frec_maxpallets.ToString()
            txtMaxPallets.Focus()
            Return
        End If

        '
        '   DETERMINAMOS LA CANTIDAD TOTAL DE PALLETS EN OTRAS
        '   OTS EN PROCESO ASOCIADAS AL MISMO TUNEL
        '
        Dim row2 As DataRow
        row2 = fnc.sqlExecuteRow("SELECT SUM(ott_numpallets) AS numpallets,COUNT(*) AS numots " & _
                                 "  FROM ots_tunel " & _
                                 " WHERE cam_unica = @cam_unica" & _
                                 "   AND ott_status NOT IN ('ANULADA','CERRADA')", _
                                 New SqlParameter() { _
                                    New SqlParameter("@cam_unica", cboTunel.SelectedValue) _
                                })

        If row2 Is Nothing Then
            MsgBox(lastSQLError, MsgBoxStyle.Critical, "Cuidado")
            Return
        End If
        Dim palletsEnOT As Integer = 0
        If CInt(row2("numots").ToString()) > 0 Then
            palletsEnOT = CInt(row2("numpallets").ToString())
        End If


        ' 
        '  SI LA CANTIDAD DE PALLETS YA EN EL TUNEL MAS LA CANTIDAD DE PALLETS
        '  EN LA GUIA ACTUAL SUPERA EL MAXIMO DE PALLETS PERMITIDOS EN TUNEL
        '  SE PIDE CONFIRMACION
        '
        Dim numpallets As Integer = CInt("0" + txtMaxPallets.Text)
        If (palletsEnOT + numpallets) > maxPalletsPorTunel Then
            If MessageBox.Show(String.Format("Este túnel ya tiene {0} pallets asignados, por lo que al adicionar " & _
                                         "los {1} pallets de esta guia se superará la apacidad del túnel ({2})." & _
                                         "Desea continuar?", palletsEnOT, numpallets, maxPalletsPorTunel), _
                            "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Return
            End If
        End If


        If MessageBox.Show("Registrar esta OT?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            Return
        End If
        Cursor.Current = Cursors.WaitCursor

        Dim usuario As String = CerosAnteriorString(id_global.ToString(), 3)
        Dim alcance As Integer = 0
        If rbtParcial.Checked Then alcance = 1
        Dim Sql As String = "INSERT INTO ots_tunel (ott_numero, frec_unica, ott_status, cam_unica, usu_codigo, ott_ususta, ott_fecsta, ott_iniciocarga, ott_deviceid, mer_id, ott_alcance, ott_numpallets) " & _
                            " VAlUES (@ott_numero, @frec_unica, 'CARGANDO', @cam_unica, @usu_codigo, @ott_ususta, GETDATE(), GETDATE(), @ott_deviceid, @mer_id, @ott_alcance, @ott_numpallets) "

        idot = 0
        numot = BuscaCorrelativo("901")

        If fnc.MovimientoSQL(Sql, New SqlParameter() _
                             { _
                                New SqlParameter("@ott_id", SqlDbType.Int) With {.Value = idot}, _
                                New SqlParameter("@ott_numero", SqlDbType.VarChar) With {.Value = numot}, _
                                New SqlParameter("@frec_unica", frec_unica), _
                                New SqlParameter("@cam_unica", cboTunel.SelectedValue), _
                                New SqlParameter("@usu_codigo", SqlDbType.VarChar) With {.Value = usuario}, _
                                New SqlParameter("@ott_ususta", SqlDbType.VarChar) With {.Value = usuario}, _
                                New SqlParameter("@ott_deviceid", SqlDbType.VarChar) With {.Value = deviceId}, _
                                New SqlParameter("@mer_id", SqlDbType.Int) With {.Value = cboMercado.SelectedValue}, _
                                New SqlParameter("@ott_alcance", SqlDbType.SmallInt) With {.Value = alcance}, _
                                New SqlParameter("@ott_numpallets", SqlDbType.Int) With {.Value = numpallets} _
                             }) <> 0 Then

            If idot = 0 Then
                Dim info As DataRow = fnc.sqlExecuteRow("SELECT ott_id FROM ots_tunel WHERE ott_numero = '" & numot.Trim() & "'")
                idot = CInt(info("ott_id").ToString())
            End If


            Cursor.Current = Cursors.Default

            Picking()

            cmdOk.Text = "Continuar"
            cboTunel.Enabled = False
            txtGuia.Enabled = False
            btn_buscarGuia.Enabled = False
            rbtTodos.Enabled = False
            rbtParcial.Enabled = False
            txtMaxPallets.Enabled = False
            btn_buscarGuia.Enabled = False
        Else
            Cursor.Current = Cursors.Default
            MessageBox.Show(lastSQLError, "Cuidado", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End If

    End Sub

    Private Sub actualizarOT()
        Cursor.Current = Cursors.WaitCursor

        Dim usuario As String = CerosAnteriorString(id_global.ToString(), 3)
        Dim Sql As String = "UPDATE ots_tunel SET mer_id = @mer_id WHERE ott_id = @ott_id"

        If fnc.MovimientoSQL(Sql, New SqlParameter() _
                             { _
                                New SqlParameter("@ott_id", SqlDbType.Int) With {.Value = idot}, _
                                New SqlParameter("@mer_id", SqlDbType.Int) With {.Value = cboMercado.SelectedValue} _
                             }) <> 0 Then

            Cursor.Current = Cursors.Default

            Picking()
        Else
            Cursor.Current = Cursors.Default
            MessageBox.Show(lastSQLError, "Cuidado", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End If

    End Sub

    Private Sub cmdDescartar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDescartar.Click
        If Descartar() Then Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cboMercado.SelectedValue = 3

        MessageBox.Show("VALUE: " + cboMercado.SelectedIndex.ToString() + " " + cboMercado.SelectedValue.ToString() + " " + cboMercado.Text, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1)
    End Sub

    Private Sub cboTunel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTunel.SelectedIndexChanged, cboMercado.SelectedIndexChanged
        Dim cam_unica As Object = cboTunel.SelectedValue
        Dim row As DataRow = fnc.sqlExecuteRow("SELECT cam_codi,cam_descr FROM camaras WHERE cam_unica = @cam_unica", _
                                               New SqlParameter() {New SqlParameter("@cam_unica", SqlDbType.UniqueIdentifier) With {.Value = cam_unica}})
        If row IsNot Nothing Then
            cam_codi = row(0).ToString()
            cam_descr = row(1).ToString()
        End If

    End Sub

    Public Function Descartar() As Boolean
        If MessageBox.Show("Descartar esta OT?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            Return False
        End If
        If idot > 0 Then
            Dim sql As String = "UPDATE ots_tunel SET ott_status = 'ANULADA',ott_fecsta=GETDATE(), ott_ususta=@usuario WHERE ott_id = @ott_id"
            If fnc.MovimientoSQL(sql, New SqlParameter() { _
                                    New SqlParameter("@ott_id", idot), _
                                    New SqlParameter("@usuario", CerosAnteriorString(id_global.ToString(), 3)) _
                                 }) = 0 Then
                MessageBox.Show(lastSQLError, "Cuidado", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub Picking()
        Dim frm As frm_DetOTTunel = New frm_DetOTTunel()
        frm.caller = Me
        frm.ott_id = idot
        frm.ott_numero = numot
        frm.ott_maxpallets = frec_maxpallets
        frm.frec_guiades = frec_guiades
        frm.frec_codi = frec_codi
        frm.cli_nomb = cli_nomb
        frm.cam_codi = cam_codi
        frm.cam_descr = cam_descr
        frm.ShowDialog()

        '
        ' VERIFICAMOS SI LA OT FUE FINALIZADA. SI ES ASI, CERRAMOS
        ' ESTE FORMULARIO Y VOLVEMOS AL MENU
        '
        Dim row As DataRow = fnc.sqlExecuteRow("SELECT ott_status FROM ots_tunel WHERE ott_id = " + idot.ToString())
        If row IsNot Nothing And row(0).ToString().Trim() <> "CARGANDO" Then
            Me.Close()
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


    Private Sub loadPrefs()
        Dim prefs As DataTable = fnc.ListarTablasSQL("SELECT * FROM dbo.fnListPrefs('ptech.tunel.*')")
        For Each pref As DataRow In prefs.Rows
            Dim prfId As String = pref("prf_id").ToString.Trim()
            Dim prfValue As String = pref("prf_value").ToString.Trim()

            Select Case prfId
                Case "permitirOTParcial"
                    prefOTParcial = (prfValue = "True")

                Case "maxPalletsPorTunel"
                    maxPalletsPorTunel = CInt(prfValue)
            End Select
        Next
    End Sub
End Class