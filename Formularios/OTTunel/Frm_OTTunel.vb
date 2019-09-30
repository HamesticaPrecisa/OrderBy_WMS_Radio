Imports System.Data.SqlClient

' VES Sep 2019
Public Class Frm_OTTunel

    Dim fnc As New Funciones

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Frm_OTTunel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Cargamos la lista de tuneles
        Dim tuneles As DataTable = fnc.ListarTablasSQL("SELECT cam_codi, cam_descr " & _
                                                       "  FROM camaras " & _
                                                       " WHERE cam_tipo IN (2,2) " & _
                                                       " ORDER BY cam_codi")
        cboTunel.DataSource = tuneles
        cboTunel.DisplayMember = "cam_descr"
        cboTunel.ValueMember = "cam_codi"
        cboTunel.Text = "SELECCIONAR"

        ' Cargamos la lista de mercados
        Dim mercados As DataTable = fnc.ListarTablasSQL("SELECT mer_id, mer_nombre " & _
                                                       "   FROM mercados " & _
                                                       "  WHERE mer_status = 'ACTIVO' " & _
                                                       "  ORDER BY mer_nombre")
        cboMercado.DataSource = mercados
        cboMercado.DisplayMember = "mer_nombre"
        cboMercado.ValueMember = "mer_id"
        cboMercado.Text = "SELECCIONAR"


        ' Se inicializan otros elementos de la UI
        lblCliente.Text = ""
        lblCliente.Visible = True


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
        Dim row As DataRow = fnc.sqlExecuteRow("SELECT frec_codi, frec_fecrec, cli_nomb" & _
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

        lblCliente.Text = row("cli_nomb").ToString().Trim()
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
            lblCliente.Text = frm.cli_nomb
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

    End Sub
End Class