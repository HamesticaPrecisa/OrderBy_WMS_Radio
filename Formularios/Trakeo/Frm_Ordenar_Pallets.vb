Public Class Frm_Ordenar_Pallets

    Dim fnc As New Funciones
    Dim valorRecibido As String = ""

    Private Sub btn_BuscaCliente_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_BuscaCliente.Click
        Dim frm As New Lst_AyudaClientes
        Dim res As DialogResult = frm.ShowDialog()

        If frm.resultado = "OK" Then
            Me.valorRecibido = frm.IdPrincipal
        End If

        If Len(valorRecibido) >= 9 Then

            Dim SqlBusca As String = "SELECT cli_nomb, cli_estado FROM clientes WHERE " & _
                                     "cli_rut='" + valorRecibido + "'"

            Dim tabla As DataTable = fnc.ListarTablasSQL(SqlBusca)

            If tabla.Rows.Count > 0 Then
                If tabla.Rows(0)(1).ToString() = "N" Then
                    MsgBox("El cliente seleccionado se encuentra bloqueado", MsgBoxStyle.Critical, "Aviso")
                    Exit Sub
                End If

                TxtClirut.Text = valorRecibido
                txtclinom.Text = tabla.Rows(0)(0).ToString()
                valorRecibido = ""

                txtCodCaj.Focus()
            Else
                MsgBox("El rut ingresado no existe", MsgBoxStyle.Information, "Aviso")
            End If
        End If
        valorRecibido = ""
    End Sub

    Private Sub txtCodCaj_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodCaj.KeyPress
        If e.KeyChar = ChrW(13) Then
            Dim RutCli As String = TxtClirut.Text.Trim
            Dim CodCaj As String = txtCodCaj.Text.Trim

            If CodCaj.Chars(0).ToString() + CodCaj.Chars(1).ToString() + CodCaj.Chars(2).ToString() = "]C1" Then
                CodCaj = CodCaj.Remove(0, 3)
            End If

            If (RutCli = "") Then
                MsgBox("Debe seleccionar un cliente.", MsgBoxStyle.Information, "Advertencia")
                txtCodCaj.Text = ""
                txtCodPal.Text = ""
                btn_BuscaCliente.Focus()
            Else
                If (CodCaj <> "") Then
                    Dim sql As String = "select top 1 a.Pallet_Cliente from Orden_Pallets a with(nolock) where a.Rut_Cliente='" & RutCli & "' and a.Codigo_Caja='" & CodCaj & "'"
                    Dim dt As New DataTable

                    dt = fnc.ListarTablasSQL(sql)

                    If (dt.Rows.Count > 0) Then
                        Dim PalCli As String = dt.Rows(0).Item(0).ToString.Trim

                        txtCodPal.Text = PalCli
                    Else
                        MsgBox("No se encontró ordenamiento para esta caja.", MsgBoxStyle.Information, "Info")

                        txtCodCaj.Text = ""
                        txtCodPal.Text = ""
                        txtCodCaj.Focus()
                    End If
                Else
                    txtCodCaj.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub btnLim_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLim.Click
        TxtClirut.Text = ""
        txtclinom.Text = ""
        btn_BuscaCliente.Enabled = True

        txtCodCaj.Text = ""
        txtCodPal.Text = ""

        btn_BuscaCliente.Focus()
    End Sub

    Private Sub btnNueCaj_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNueCaj.Click
        txtCodCaj.Text = ""
        txtCodPal.Text = ""
        txtCodCaj.Focus()
    End Sub

    Private Sub btnSal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSal.Click
        Me.Close()
    End Sub
End Class