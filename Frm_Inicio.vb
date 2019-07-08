Public Class Frm_Inicio

    Dim fnc As New Funciones

    Private Sub Frm_Inicio_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        Application.Exit()
    End Sub

    Private Sub Frm_Inicio_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Close()
    End Sub

    Private Sub Frm_Inicio_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = ChrW(13) Then

            If txtpassword.Text = "" Then
                txtpassword.Focus()
            ElseIf txtusuario.Text = "" Then
                txtusuario.Focus()
            End If

            Dim sql As String = "SELECT usu_codigo, radio, descri FROM usuarios WHERE usu_usuario='" + txtusuario.Text + "' " & _
                                "AND usu_pass2='" + CODIFICA(txtpassword.Text) + "'"

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
            If tabla.Rows.Count > 0 Then

                If tabla.Rows(0)(1).ToString() = "0" Then
                    MsgBox("No tiene privilegios para usar este dispositivo", MsgBoxStyle.Critical, "Aviso")
                    Exit Sub
                End If

                Dim f As New Frm_Menu
                f.usuario = tabla.Rows(0)(2).ToString()
                f.codigo = Convert.ToInt32(tabla.Rows(0)(0).ToString())

                encargado_global = tabla.Rows(0)(2).ToString()
                id_global = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                f.ShowDialog()
            Else
                MsgBox("No es usuario")
            End If
        End If
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim f As New frm_ejemplo
        f.ShowDialog()
    End Sub

    Private Sub Label4_ParentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.ParentChanged

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Frm_Inicio_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
End Class