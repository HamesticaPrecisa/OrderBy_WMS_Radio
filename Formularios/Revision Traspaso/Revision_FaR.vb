Imports System.Data.SqlClient

Public Class Revision_FaR

    Dim fnc As New Funciones
    Dim con As New Conexion

    Public Function TransformaPallet(ByVal pallet As String) As String

        Dim separado As String = ""
        For i As Integer = 11 To pallet.Length - 2
            separado = separado + pallet.Chars(i)
        Next
        txtpallet.Text = separado
        Return separado
    End Function

    Private Sub Txtpallet_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpallet.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            lblmsgbox.Text = ""
            If txtpallet.Text.Length = 21 Then
                TransformaPallet(txtpallet.Text)
                Dim sql As String = "SELECT  racd_unidades, drec_rev, descri, drec_sopocli, mae_descr , " & _
                "(SELECT pallet FROM Pedidos_detalle pd WHERE pedido=(SELECT pedido FROM pedidos_ficha pf WHERE " & _
                "Orden='" + Txtnped.Text + "') AND pallet='" + txtpallet.Text + "') AS esta " & _
                "FROM detarece LEFT JOIN rackdeta ON racd_codi=drec_codi LEFT JOIN LOG_RevisionPallets ON drec_codi=rev_codpallet " & _
                "LEFT JOIN usuarios ON usu_codigo=rev_codenca INNER JOIN maeprod ON mae_codi=drec_codpro " & _
                "WHERE racd_codi='" + txtpallet.Text + "'"

                Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

                If tabla.Rows.Count > 0 Then

                    If tabla.Rows(0)(5).ToString() = "" Then
                        lblmsgbox.Text = "No corresponde al pedido"
                        txtpallet.Text = ""
                        Exit Sub
                    End If

                    lblcant.Text = tabla.Rows(0)(0).ToString()

                    If tabla.Rows(0)(1).ToString() = "0" Then
                        lblMensaje.Text = "SIN REVISION"
                    ElseIf tabla.Rows(0)(1).ToString() = "1" Then
                        lblMensaje.Text = "REVISADO: BIEN INGRESADO"
                    ElseIf tabla.Rows(0)(1).ToString() = "2" Then
                        lblMensaje.Text = "REVISADO: MAL INGRESADO"
                    End If
                    lblencargado.Text = tabla.Rows(0)(2).ToString()
                    ncliente.Text = tabla.Rows(0)(3).ToString()
                    lblproducto.Text = tabla.Rows(0)(4).ToString()

                    txtpallet.Enabled = False
                    lblcant.Visible = True
                    BtnSi.Visible = True
                    BtnNo.Visible = True
                    BtnPallet.Enabled = False
                    BtnCancelar.Visible = True
                    BtnSi.Focus()
                Else
                    lblmsgbox.Text = "Pallet no existe o se despacho"
                    txtpallet.Text = ""
                    txtpallet.Focus()
                End If
            Else
                txtpallet.Text = ""
                txtpallet.Focus()
            End If
        Else
            fnc.SoloNumeros(sender, e)
        End If
    End Sub

    Private Sub BtnPallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPallet.Click
        If txtpallet.Text.Length >= 2 AndAlso txtpallet.Text.Length <= 9 Then
            txtpallet.Text = fnc.CerosAnteriorString(txtpallet.Text + "0", 21)
            lblmsgbox.Text = ""
            If txtpallet.Text.Length = 21 Then

                Dim sql As String = "SELECT  racd_unidades, drec_rev, descri, drec_sopocli, mae_descr " & _
                     "FROM detarece LEFT JOIN rackdeta ON racd_codi=drec_codi LEFT JOIN LOG_RevisionPallets ON drec_codi=rev_codpallet " & _
                     "LEFT JOIN usuarios ON usu_codigo=rev_codenca INNER JOIN maeprod ON mae_codi=drec_codpro " & _
                     "WHERE racd_codi='" + TransformaPallet(txtpallet.Text) + "'"

                Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

                If tabla.Rows.Count > 0 Then

                    lblcant.Text = tabla.Rows(0)(0).ToString()

                    If tabla.Rows(0)(1).ToString() = "0" Then
                        lblMensaje.Text = "SIN REVISION"
                    ElseIf tabla.Rows(0)(1).ToString() = "1" Then
                        lblMensaje.Text = "REVISADO: BIEN INGRESADO"
                    ElseIf tabla.Rows(0)(1).ToString() = "2" Then
                        lblMensaje.Text = "REVISADO: MAL INGRESADO"
                    End If
                    lblencargado.Text = tabla.Rows(0)(2).ToString()
                    ncliente.Text = tabla.Rows(0)(3).ToString()
                    lblproducto.Text = tabla.Rows(0)(4).ToString()

                    txtpallet.Enabled = False
                    lblcant.Visible = True
                    BtnSi.Visible = True
                    BtnNo.Visible = True
                    BtnPallet.Enabled = False
                    BtnCancelar.Visible = True
                    BtnSi.Focus()
                Else
                    lblmsgbox.Text = "Pallet no existe o se despacho"
                    txtpallet.Text = ""
                    txtpallet.Focus()
                End If
            Else
                txtpallet.Text = ""
                txtpallet.Focus()
            End If
        End If
    End Sub

    Private Sub Limpiar()
        txtpallet.Text = ""
        lblencargado.Text = ""
        txtpallet.Enabled = True
        BtnPallet.Enabled = True
        lblcant.Visible = False
        BtnSi.Visible = False
        BtnNo.Visible = False
        BtnCancelar.Visible = False
        lblMensaje.Text = ""
        txtpallet.Focus()
    End Sub

    Private Sub BtnSi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSi.Click
        GuardaCambios("1")
    End Sub

    Private Sub BtnNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNo.Click
        GuardaCambios("2")
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        txtpallet.Text = ""
        txtpallet.Enabled = True
        BtnPallet.Enabled = True
        lblcant.Visible = False
        BtnSi.Visible = False
        BtnNo.Visible = False
        BtnCancelar.Visible = False
        lblMensaje.Text = ""
        lblencargado.Text = ""
        ncliente.Text = ""
        lblproducto.Text = ""
        lblmsgbox.Text = ""
        txtpallet.Focus()
    End Sub

    Private Sub GuardaCambios(ByVal Estado As String)
        Try
            con.conectarSQL()

            Dim _cmd As SqlCommand = New SqlCommand("PAG_PALLETCHEQUEADO", con.conSQL)
            _cmd.CommandType = CommandType.StoredProcedure
            _cmd.Parameters.AddWithValue("@estado", Estado)
            _cmd.Parameters.AddWithValue("@pallet", txtpallet.Text)
            _cmd.Parameters.AddWithValue("@usuario", CerosAnteriorString(lblusu.Text, 3))
            _cmd.Parameters.AddWithValue("@tipo", 2)
            _cmd.Parameters.AddWithValue("@pedido", Txtnped.Text)
            Dim resp As Integer = 0
            Try
                resp = Convert.ToInt32(_cmd.ExecuteScalar())
            Catch ex As Exception
                resp = 1
            End Try

            If resp = 0 Or resp = 5 Then
                lblmsgbox.Text = "Grabación exitosa"
            ElseIf resp = 4 Then
                lblmsgbox.Text = "Ya tenia el estado ingresado"
            ElseIf resp < 4 Then
                lblmsgbox.Text = "Error esperado al grabar la información"
            Else
                lblmsgbox.Text = "Error inesperado al actualizar"
            End If

            con.cerrarSQL()

            If resp = 5 Then
                MsgBox("Pedido revisado correctamente", MsgBoxStyle.Information, "Aviso")
                BtnPedido_Click(Nothing, Nothing)
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
        Limpiar()
    End Sub


    Private Sub Txtnped_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtnped.KeyPress
        If e.KeyChar = ChrW(13) Then

            If Txtnped.Text <> "" AndAlso Txtnped.Text <> "0" Then
                Dim sql As String = "SELECT pf.pedido, SUM(revisado), COUNT(*), isnull(ped_revision,0) FROM pedidos_ficha pf INNER JOIN Pedidos_detalle pd ON pf.pedido=pd.pedido " & _
                                    "WHERE  terminado<>'3' AND Orden='" + Txtnped.Text + "' GROUP BY pf.pedido, ped_revision "

                Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

                If tabla.Rows.Count > 0 Then
                    If tabla.Rows(0)(3).ToString() = "1" Then
                        lblmsgbox.Text = "El pedido ya se encuentra revisado"
                        Txtnped.Text = ""
                        Txtnped.Focus()
                        Exit Sub
                    End If
                    lblmsgbox.Text = ""
                    body.Enabled = True
                    Txtnped.Enabled = False
                    txtpallet.Focus()
                Else
                    lblmsgbox.Text = "El pedido ingresado no EXISTE"
                    Txtnped.Text = ""
                    Txtnped.Focus()
                    Exit Sub
                End If
            End If

        Else
            SoloNumeros(sender, e)
        End If
    End Sub

    Private Sub BtnPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPedido.Click
        Txtnped.Text = ""
        Txtnped.Enabled = True
        body.Enabled = False
        lblMensaje.Text = ""
        lblencargado.Text = ""
        lblcant.Text = "0"
        txtpallet.Text = ""
        lblmsgbox.Text = ""
        BtnPallet.Enabled = True
        Txtnped.Focus()
        txtpallet.Enabled = True
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        Dim f As New EstadoPedido
        f.ShowDialog()
    End Sub
End Class