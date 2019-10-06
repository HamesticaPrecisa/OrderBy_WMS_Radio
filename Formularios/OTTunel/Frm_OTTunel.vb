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



    Private Sub Frm_OTTunel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Cargamos la lista de tuneles
        Dim tuneles As DataTable = fnc.ListarTablasSQL("SELECT cam_unica, cam_descr " & _
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


        ' Verificamos si el radio tiene una OT de tunel en borrador.
        ot = fnc.sqlExecuteRow("SELECT a.ott_id, a.ott_numero, a.cam_unica, a.frec_unica, b.frec_guiades, b.frec_codi, c.cli_nomb, a.mer_id, a.ott_alcance, a.ott_numpallets, d.mer_nombre, " & _
                               "       ISNULL((SELECT COUNT(*) FROM det_ots_tunel WHERE ott_id = a.ott_id), 0) AS picked, " & _
                               "       ISNULL((SELECT COUNT(*) FROM detarece WHERE frec_codi1 = b.frec_codi), 0) AS numpallets " & _
                               "  FROM ots_tunel a " & _
                               "  LEFT JOIN fichrece b ON b.frec_unica = a.frec_unica " & _
                               "  LEFT JOIN clientes c ON c.cli_rut = b.frec_rutcli" & _
                               "  LEFT JOIN mercados d ON d.mer_id = a.mer_id " & _
                               " WHERE a.ott_deviceid = @deviceid " & _
                               "   AND a.ott_status NOT IN ('FINALIZADA','CERRADA','ANULADA')", _
                               New SqlParameter() {New SqlParameter("@deviceid", SqlDbType.VarChar) With {.Value = deviceId}})
        If ot Is Nothing Then
            cboTunel.Text = "SELECCIONAR"
            cboMercado.Text = "SELECCIONAR"
        Else
            cboTunel.SelectedValue = ot("cam_unica")
            txtGuia.Text = ot("frec_codi").ToString().Trim()
            lblCliente.Text = ot("cli_nomb").ToString().Trim()
            frec_unica = ot("frec_unica")
            frec_codi = ot("frec_codi").ToString()
            frec_guiades = ot("frec_guiades").ToString()
            cli_nomb = ot("cli_nomb").ToString()
            frec_maxpallets = If(CInt(ot("ott_alcance").ToString()) = 0, CInt(ot("numpallets").ToString()), CInt(ot("ott_maxpallets").ToString()))
            cboMercado.SelectedValue = CInt(ot("mer_id").ToString())
            If CInt(ot("ott_alcance").ToString()) = 1 Then rbtParcial.Checked = True
            txtMaxPallets.Text = ot("ott_numpallets").ToString()
            cmdOk.Text = "Continuar"
            cmdDescartar.Visible = True


            ' Si la OT ya tiene lineas cargadas, no se permite cambiar nada mas que el mercado
            If (CInt(ot("picked").ToString()) > 0) Then
                cboTunel.Enabled = False
                txtGuia.Enabled = False
                btn_buscarGuia.Enabled = False
                rbtTodos.Enabled = False
                rbtParcial.Enabled = False
                txtMaxPallets.Enabled = False
                btn_buscarGuia.Enabled = False
            End If
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
        Dim row As DataRow = fnc.sqlExecuteRow("SELECT frec_codi, frec_fecrec, cli_nomb, frec_unica " & _
                                               "  FROM fichrece " & _
                                               "  LEFT JOIN clientes ON cli_rut = frec_rutcli " & _
                                               " WHERE frec_guiades = @guia", _
                                               New SqlParameter() {New SqlParameter("@guia", SqlDbType.VarChar) With {.Value = guia}})
        If row Is Nothing Then
            lblCliente.Text = ""
            txtGuia.Text = ""
            MessageBox.Show("La guia indicada no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Return False
        End If


        frec_unica = row("frec_unica").ToString()
        frec_codi = row("frec_codi").ToString()
        frec_guiades = guia
        cli_nomb = row("cli_nomb").ToString().Trim()
        lblCliente.Text = cli_nomb

        '
        ' DETERMINAMOS LA CANTIDAD DE PALLETS NO ASOCIADOS 
        ' A OT QUE TIENE LA GUIA
        '
        row = fnc.sqlExecuteRow("SELECT COUNT(*) AS maxpallets " & _
                                "  FROM detarece a " & _
                                " WHERE frec_codi1 = @frec_codi " & _
                                "   AND drec_codi NOT IN (SELECT drec_codi FROM det_ots_tunel WHERE ott_id <> @ott_id)", _
                                New SqlParameter() { _
                                    New SqlParameter("@frec_codi", SqlDbType.VarChar) With {.Value = frec_codi}, _
                                    New SqlParameter("@ott_id", SqlDbType.Int) With {.Value = CInt(ot("ott_id").ToString())} _
                                })
        frec_maxpallets = CInt(row("maxpallets").ToString())
        txtMaxPallets.Text = frec_maxpallets.ToString()

        Return True
    End Function

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub rbtParcial_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtParcial.CheckedChanged
        txtMaxPallets.Visible = rbtParcial.Checked
    End Sub

    Private Sub buscarGuia()
        Dim frm As frm_BuscarGuia = New frm_BuscarGuia()
        frm.ShowDialog()
        If frm.frec_guiades.Length > 0 Then
            txtGuia.Text = frm.frec_guiades
            validarGuia(frm.frec_guiades)
            cboMercado.Focus()
        End If
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        crearOT()
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
            txtMaxPallets.Focus()
            Return
        End If


        Dim idot As Integer
        Dim numot As String
        Dim usuario As String = CerosAnteriorString(id_global.ToString(), 3)
        Dim alcance As Integer = 0
        If rbtParcial.Checked Then alcance = 1
        Dim numpallets As Integer = CInt("0" + txtMaxPallets.Text)
        Dim Sql As String = "INSERT INTO ots_tunel (ott_numero, frec_unica, ott_status, cam_unica, usu_codigo, ott_ususta, ott_fecsta, ott_deviceid, mer_id, ott_alcance, ott_numpallets) " & _
                            " VAlUES (@ott_numero, @frec_unica, 'BORRADOR', @cam_unica, @usu_codigo, @ott_ususta, @ott_fecsta, @ott_deviceid, @mer_id, @ott_alcance, @ott_numpallets) "
        If (ot Is Nothing) Then
            idot = 0
            numot = BuscaCorrelativo("901")
        Else
            idot = CInt(ot("ott_id").ToString())
            numot = ot("ott_numero").ToString()
            Sql = "UPDATE ots_tunel " & _
                  "   SET frec_unica = @frec_unica," & _
                  "       cam_unica = @cam_unica," & _
                  "       usu_codigo = @usu_codigo," & _
                  "       mer_id = @mer_id," & _
                  "       ott_alcance = @ott_alcance," & _
                  "       ott_numpallets = @ott_numpallets" & _
                  " WHERE ott_id = @ott_id"
        End If
        If fnc.MovimientoSQL(Sql, New SqlParameter() _
                             { _
                                New SqlParameter("@ott_id", SqlDbType.Int) With {.Value = idot}, _
                                New SqlParameter("@ott_numero", SqlDbType.VarChar) With {.Value = numot}, _
                                New SqlParameter("@frec_unica", frec_unica), _
                                New SqlParameter("@cam_unica", cboTunel.SelectedValue), _
                                New SqlParameter("@usu_codigo", SqlDbType.VarChar) With {.Value = usuario}, _
                                New SqlParameter("@ott_ususta", SqlDbType.VarChar) With {.Value = usuario}, _
                                New SqlParameter("@ott_fecsta", SqlDbType.DateTime) With {.Value = DateTime.Now}, _
                                New SqlParameter("@ott_deviceid", SqlDbType.VarChar) With {.Value = deviceId}, _
                                New SqlParameter("@mer_id", SqlDbType.Int) With {.Value = cboMercado.SelectedValue}, _
                                New SqlParameter("@ott_alcance", SqlDbType.SmallInt) With {.Value = alcance}, _
                                New SqlParameter("@ott_numpallets", SqlDbType.Int) With {.Value = numpallets} _
                             }) <> 0 Then

            If idot = 0 Then
                Dim info As DataRow = fnc.sqlExecuteRow("SELECT ott_id FROM ots_tunel WHERE ott_numero = '" & numot.Trim() & "'")
                idot = CInt(info("ott_id").ToString())
            End If

            Dim frm As frm_DetOTTunel = New frm_DetOTTunel()
            frm.ott_id = idot
            frm.ott_numero = numot
            frm.ott_maxpallets = frec_maxpallets
            frm.frec_guiades = frec_guiades
            frm.frec_codi = frec_codi
            frm.cli_nomb = cli_nomb
            frm.ShowDialog()
        Else
            MessageBox.Show(lastSQLError, "Cuidado", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End If

    End Sub

    Private Sub cmdDescartar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDescartar.Click
        If MessageBox.Show("Descartar esta OT?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            Return
        End If
        Dim sql1 As String = "UPDATE ots_tunel SET ott_status = 'ANULADA' WHERE ott_id = @ott_id"
        Dim sql2 As String = "DELETE FROM det_ots_tunel WHERE ott_id = @ott_id"
        Dim idot As Integer = CInt(ot("ott_id").ToString())
        If fnc.MovimientoSQL(sql1, New SqlParameter() {New SqlParameter("@ott_id", SqlDbType.Int) With {.Value = idot}}) = 0 Or _
           fnc.MovimientoSQL(sql2, New SqlParameter() {New SqlParameter("@ott_id", SqlDbType.Int) With {.Value = idot}}) = 0 Then
            MessageBox.Show(lastSQLError, "Cuidado", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Return
        End If

        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cboMercado.SelectedValue = 3

        MessageBox.Show("VALUE: " + cboMercado.SelectedIndex.ToString() + " " + cboMercado.SelectedValue.ToString() + " " + cboMercado.Text, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1)
    End Sub
End Class