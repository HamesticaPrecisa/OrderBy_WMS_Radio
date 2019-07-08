Public Class FrmInventario2vb
    Public codigo As String = ""
    Public encargado As String = ""
    Public de As Integer = 0
    Dim filaSeleccionada As String = ""
    Public PALL As String = ""
    Public GRABA As String = ""


    Dim fnc As New Funciones
    Sub limpiartodo()
        txtcli.Text = ""
        txtpallet.Text = ""
        txtingcaja.Text = ""
        While (ListBox1.Items.Count > 0)
            ListBox1.Items.RemoveAt(0)
        End While
        txtncaja.Text = ""
        txtncaja.Enabled = False
        txtobs.Text = ""
        GRABA = ""
        de = 0
        PALL = ""
        Label4.Text = "0/0"



    End Sub
    Sub validarexistenciaalgrabar()
        Dim valor_palletc As String = txtpallet.Text.Remove(0, 11)
        valor_palletc = valor_palletc.Remove(9, 1)
        PALL = valor_palletc
        Dim sqlped As String = "Select * from newinventario where inv_caj='" + txtingcaja.Text + "' "
        Dim tabla As DataTable = fnc.ListarTablasSQL(sqlped)

        If tabla.Rows.Count > 0 Then
            MsgBox("Caja ya ingresada en el pallet " + tabla.Rows(0)(0).ToString(), MsgBoxStyle.Critical, "Aviso")
            GRABA = "NO"

            Exit Sub
        Else
            GRABA = "SI"

            Exit Sub

        End If
    End Sub


    Sub validarexistenciaalgrabar2()
        Dim valor_palletc As String = txtpallet.Text.Remove(0, 11)
        valor_palletc = valor_palletc.Remove(9, 1)
        PALL = valor_palletc
        Dim sqlped As String = "Select * from newinventario where inv_pcod='" + PALL + "' "
        Dim tabla As DataTable = fnc.ListarTablasSQL(sqlped)

        If tabla.Rows.Count > 0 Then

            Dim sql2 As String = "DELETE FROM   newINVENTARIO WHERE inv_pcod ='" + PALL + "'"
            fnc.MovimientoSQL(sql2)

        Else
            

        End If
    End Sub
    Sub validarexistencia()
        Dim valor_palletc As String = txtpallet.Text.Remove(0, 11)
        valor_palletc = valor_palletc.Remove(9, 1)
        PALL = valor_palletc
        Dim sqlped As String = "Select * from newinventario where inv_pcod='" + valor_palletc + "' "
        Dim tabla As DataTable = fnc.ListarTablasSQL(sqlped)

        If tabla.Rows.Count > 0 Then
            Dim sum As Integer = 0

            For i As Integer = 0 To tabla.Rows.Count - 1
                ListBox1.Items.Add(tabla.Rows(i)(1).ToString())
                sum = sum + 1
                de = de + 1
            Next
            txtncaja.Text = sum.ToString()
            txtobs.Text = tabla.Rows(0)(5).ToString()

            Label4.Text = de.ToString() + "/" + txtncaja.Text
            txtingcaja.Focus()
            Exit Sub

        Else
            txtncaja.Enabled = True
            txtncaja.Focus()
            Exit Sub

        End If
    End Sub

    
    Private Sub txtpallet_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpallet.KeyPress
        If e.KeyChar = ChrW(13) AndAlso txtpallet.Text.Trim <> "" Then

            If txtpallet.Text.Length <> 21 Then
                MsgBox("Codigo incorrecto", MsgBoxStyle.Critical, "Aviso")
                txtpallet.Text = ""
                Exit Sub
            Else

                Dim valor_palletc As String = txtpallet.Text.Remove(0, 11)
                valor_palletc = valor_palletc.Remove(9, 1)
                PALL = valor_palletc
                Dim sqlped As String = "Select cli_nomb from VMOBILE_CLIENTES where drec_codi='" + valor_palletc + "' "
                Dim tabla As DataTable = fnc.ListarTablasSQL(sqlped)

                If tabla.Rows.Count > 0 Then

                    txtcli.Text = tabla.Rows(0)(0).ToString()

                    If (txtcli.Text = "ANDREWS SMOKY DELICACIES S.A") Then
                        txtingcaja.MaxLength = 14


                    End If

                    If (txtcli.Text = "SALMONES ANTARTICA S.A.") Then
                        txtingcaja.MaxLength = 12
                    End If

                    If (txtcli.Text = "GRANJA MARINA TORNAGALEONES S.A.") Then
                        txtingcaja.MaxLength = 35
                    End If
                    txtncaja.Focus()
                    validarexistencia()

                Else
                    MsgBox("Codigo incorrecto", MsgBoxStyle.Critical, "Aviso")
                    txtpallet.Text = ""
                    Exit Sub
                End If

            End If


        End If
    End Sub

    Private Sub txtncaja_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtncaja.KeyPress
        If (Char.IsDigit(e.KeyChar)) Then

            e.Handled = False

        ElseIf (Char.IsControl(e.KeyChar)) Then

            e.Handled = False

        Else

            e.Handled = True
        End If

        If e.KeyChar = ChrW(13) AndAlso txtncaja.Text.Trim <> "" Then

            txtingcaja.Enabled = True
            txtingcaja.Focus()
            txtncaja.Enabled = False
            Label4.Text = ListBox1.Items.Count.ToString() + "/" + txtncaja.Text

        End If

    End Sub

    Private Sub Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtingcaja_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtingcaja.KeyPress
        If e.KeyChar = ChrW(13) AndAlso txtingcaja.Text.Trim <> "" Then
            If (de < Convert.ToInt32(txtncaja.Text)) Then


                For i As Integer = 0 To ListBox1.Items.Count - 1
                    If (ListBox1.Items.Count > 0) Then


                        If (txtingcaja.Text = ListBox1.Items(i).ToString()) Then
                            MsgBox("Caja Ya Ingresada ", MsgBoxStyle.Critical, "Aviso")
                            Exit Sub
                        End If
                    End If
                Next
                validarexistenciaalgrabar()
                If (GRABA = "SI") Then



                    ListBox1.Items.Add(txtingcaja.Text)
                    de = de + 1
                    Label4.Text = de.ToString() + "/" + txtncaja.Text
                End If

            Else
                MsgBox("Numero de cajas Sobrepasa el Limite ", MsgBoxStyle.Critical, "Aviso")
                txtpallet.Text = ""
                Exit Sub
            End If



        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        For i As Integer = 0 To ListBox1.Items.Count
            If (i < ListBox1.Items.Count) Then

                Try
                    If (ListBox1.Items.Count < Convert.ToInt32(txtncaja.Text)) Then
                        MsgBox("Faltan Cajas Que Agregar al Pallet  ", MsgBoxStyle.Critical, "Aviso")
                        Exit Sub
                    Else

                        If (i = 0) Then
                            validarexistenciaalgrabar2()

                        End If
                        Dim sql As String = "INSERT INTO NewInventario (inv_pcod, inv_caj ,Cliente,fecha_reg,usr_reg,obs_com) VALUES( '" + PALL + "' ,  '" + ListBox1.Items(i).ToString() + "','" + txtcli.Text + "' , '" + DateTime.Now + "' ,'" + CerosAnteriorString(codigo, 3) + "','" + txtobs.Text + "')"
                        fnc.MovimientoSQL(sql)
                    End If


                Catch ex As Exception

                    MsgBox(ex.Message())
                End Try




            Else

                MsgBox("Guardado Correctamente ", MsgBoxStyle.Information, "ok")
                limpiartodo()

                Exit Sub

            End If
        Next
    End Sub

    Private Sub CheckBox1_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckStateChanged

        If (CheckBox1.Checked = True) Then





            txtncaja.Enabled = False
            txtncaja.Focus()

            de = ListBox1.Items.Count
            Label4.Text = de.ToString() + "/" + txtncaja.Text

        Else
            txtncaja.Enabled = True
            txtingcaja.Focus()

            de = ListBox1.Items.Count
            Label4.Text = de.ToString() + "/" + txtncaja.Text
        End If


    End Sub

    Private Sub Limpiar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Limpiar.Click
        limpiartodo()

    End Sub
End Class