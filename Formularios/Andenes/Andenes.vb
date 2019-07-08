Public Class Frm_Andenes
    Dim fnc As New Funciones
    Public foliorec As String = ""
    Public rutrec As String = ""

    Public usr As String = ""

    Private Sub btn_BuscaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub txtrut_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

    End Sub
    Private Sub verificador_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

    End Sub

    Private Sub btn_BuscaCliente_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_BuscaCliente.Click
        Dim frm As New Frm_buscaClienteParaAND

        Dim res As DialogResult = frm.ShowDialog()

        If res = Windows.Forms.DialogResult.OK Then
            rutrec = frm.cliente
            If frm.cliente.Length >= 0 Then
                Me.txtrut.Text = frm.cliente.Chars(0) & _
                frm.cliente.Chars(1) & _
                frm.cliente.Chars(2) & _
                frm.cliente.Chars(3) & _
                frm.cliente.Chars(4) & _
                frm.cliente.Chars(5) & _
                frm.cliente.Chars(6) & _
                frm.cliente.Chars(7)

                Me.verificador.Text = frm.cliente.Chars(8)
                Me.txtclinombre.Text = frm.nombrecliente
                foliorec = frm.folio
                Me.verificador.Enabled = False
                Me.txtclinombre.Enabled = False
                Me.txtrut.Enabled = False

                ' btn_BuscaCliente.Enabled = False
                TextBox1.Focus()

            End If
        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = ChrW(13) Then
            Dim str1 As String = TextBox1.Text
            If str1.Length = 13 Then


                str1 = str1.Substring(6, 7)
                str1 = str1.Substring(0, 2)
                Dim sql As String = "select cam_descr from camaras where cam_codi ='" + str1 + "'"

                Dim dt As DataTable = fnc.ListarTablasSQL(sql)

                If dt.Rows.Count > 0 Then
                    TextBox2.Text = dt.Rows(0)(0).ToString()

                    Dim sql2 As String = "select * from andenesreg  where folio = '" + foliorec + "' "
                    Dim dt2 As DataTable = fnc.ListarTablasSQL(sql2)
                    If dt2.Rows.Count = 0 Then
                        Button1.Enabled = True
                        Button2.Enabled = False
                    End If
                    If dt2.Rows.Count = 1 Then
                        Button1.Enabled = False
                        Button2.Enabled = True
                    End If
                    If dt2.Rows.Count = 2 Then
                        Button1.Enabled = False
                        Button2.Enabled = False
                        MsgBox("Folio Terminado ", MsgBoxStyle.Information, "Aviso")
                    End If
                End If


            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim qry As String
        qry = "  INSERT INTO AndenesReg(folio,Anden,Cliente,tip_mov,fec_reg,usr_reg,obs)"
        qry += " VALUES('" + foliorec + "','" + TextBox2.Text + "','" + rutrec + "','" + Button1.Text + "',getdate(),'" + usr + "','" + TextBox3.Text + "')"

    
        fnc.MovimientoSQL(qry)
        MsgBox("Grabación exitosa", MsgBoxStyle.Information, "Aviso")
        Button1.Enabled = False
    End Sub

    Private Sub txtclinombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtclinombre.TextChanged

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim qry As String
        qry = "  INSERT INTO AndenesReg(folio,Anden,Cliente,tip_mov,fec_reg,usr_reg2,obs)"
        qry += " VALUES('" + foliorec + "','" + TextBox2.Text + "','" + rutrec + "','" + Button2.Text + "',getdate(),'" + usr + "','" + TextBox3.Text + "')"


        fnc.MovimientoSQL(qry)
        MsgBox("Grabación exitosa", MsgBoxStyle.Information, "Aviso")
        Button2.Enabled = False


    End Sub

    Private Sub Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Limpiar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Limpiar.Click
        txtrut.Text = ""
        verificador.Text = ""
        txtclinombre.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        Button1.Enabled = False
        Button2.Enabled = False

    End Sub

    Private Sub Frm_Andenes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    
    End Sub
End Class