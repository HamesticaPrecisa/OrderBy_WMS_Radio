
Public Class Frm_RevisionPosiciones

    Dim fnc As New Funciones
    Dim con As New Conexion

    Private Sub txtposicion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtposicion.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtposicion.Text.Length = 13 Then
                DataGridDatos.DataSource = Nothing
                Dim separado(15) As String

                For i As Integer = 0 To txtposicion.Text.Length - 1
                    separado(i) = txtposicion.Text.Chars(i)
                Next

                txtcamara.Text = "" + separado(6) + "" + separado(7)
                txtbanda.Text = "" + separado(8) + "" + separado(9)
                txtcolumna.Text = "" + separado(10) + "" + separado(11)

                Dim sql As String = "SELECT racd_codi,racd_pi,racd_ni,cli_nomb " & _
                                    "  FROM rackdeta,fichrece,clientes " & _
                                    " WHERE fichrece.frec_codi = SUBSTRING(racd_codi,1,7) " & _
                                    "   AND fichrece.frec_rutcli = clientes.cli_rut " & _
                                    "   AND racd_ca = '" + txtcamara.Text + "'" & _
                                    "   AND racd_ba = '" + txtbanda.Text + "'" & _
                                    "   AND racd_co = '" + txtcolumna.Text + "'"

                Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

                DataGridDatos.DataSource = tabla

                txtposicion.Text = ""
                txtposicion.Focus()

            End If

        End If
    End Sub

  
End Class