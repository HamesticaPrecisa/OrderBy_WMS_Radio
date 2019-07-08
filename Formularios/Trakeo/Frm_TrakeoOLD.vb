Imports System.Data

Public Class Frm_TrakeoOLD

    'Dim fnc As New funciones2

    Private Sub Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim x As String = InputBox("Ingrese el numero de recepcion", MsgBoxStyle.Question)
        If Not IsNumeric(x) Then
            MsgBox("Codigo mal escrito")
        Else
            Dim sql As String = "SELECT trec_con FROM receTMP WHERE Trec_cod='" + CerosAnteriorString(x.ToString(), 7) + "'"
            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count = 0 Then
                MsgBox("Recepcion no existe", MsgBoxStyle.Information, "Aviso")
            Else
                BtnPallet.Enabled = True
            End If
        End If

    End Sub

    Function CerosAnteriorString(ByVal numero As String, ByVal largo As Integer) As String

        Dim valorCeros As String = ""

        For i As Integer = 0 To ((largo - 1) - numero.Length)
            valorCeros = valorCeros + "0"
        Next

        Return valorCeros + numero
    End Function


    Private Sub BtnPallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPallet.Click
        Try
            Dim x As String = InputBox("Ingrese el numero de Pallet", MsgBoxStyle.Question)
            Dim Val As String = (x.Remove(0, 13))
            Dim fin As String = Val.Remove(9, 1)

            If Not IsNumeric(Convert.ToInt32(fin)) Then
                MsgBox("Codigo mal escrito")
            Else
                'guarda en grilla

                If fnc.verificaExistencia("Pallet", "pal_cod", fin.ToString()) = True Then
                    If Len(fin.ToString()) >= 7 Then
                        tpal.Text = fin.ToString()
                        Dim sql As String = "SELECT pal_caj FROM Pallet WHERE pal_cod='" + tpal.Text + "'"

                        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

                        If tabla.Rows.Count > 0 Then
                            CajasTotal.Text = tabla.Rows(0)(0).ToString()
                        End If

                        tpal.Text = ""
                        txtrecibe.Text = ""
                        txtrecibe.Enabled = False

                        MsgBox("El pallet se encuentra trakeado", MsgBoxStyle.Information, "Aviso")
                        BtnGuardaTodo.Enabled = False
                    End If
                Else

                    Dim x1 As String = InputBox("Ingrese la cantidad de CAJAS que tiene el pallet", MsgBoxStyle.Question)
                    If Not IsNumeric(x1) Then
                        MsgBox("Error No es numero")
                        Exit Sub
                    Else
                        CajasTotal.Text = x1.ToString()
                    End If

                    tpal.Text = fin.ToString()

                    ' 
                End If

                tpal.Enabled = False
                BtnPallet.Enabled = False
                txtrecibe.Enabled = True

            End If

        Catch ex As Exception
            MsgBox("Ocurrio un error, debe ingresar los campos nuevamente", MsgBoxStyle.Information, "Aviso")
        End Try
    End Sub

    Private Sub txtrecibe_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrecibe.KeyPress
        If e.KeyChar = ChrW(13) AndAlso txtrecibe.Text <> "" Then
            If txtrecibe.Text.Length >= 300 Then
                txtrecibe.Text = ""
                txtrecibe.Focus()
                Exit Sub
            End If

            If ListBox1.Items.Count = CajasTotal.Text Then
                MsgBox("Las cajas del pallet ya se encuentran leidas en su totalidad", MsgBoxStyle.Information, "Aviso")
                BtnGuardaTodo.Enabled = True
            Else

                If EstaLaCaja(txtrecibe.Text) = True Then
                    Panel1.BackColor = Color.Red
                    txtrecibe.Text = ""
                    txtrecibe.Focus()
                Else
                    Panel1.BackColor = Color.Green

                    txtrecibe.Focus()
                    ListBox1.Items.Add(txtrecibe.Text)
                    txtcaj.Text = ListBox1.Items.Count.ToString()
                    txtrecibe.Text = ""
                End If


            End If
        End If


    End Sub

    Public Function EstaLaCaja(ByVal codigo_caja) As Boolean
        EstaLaCaja = False
        For i As Integer = 0 To ListBox1.Items.Count - 1

            If ListBox1.Items(i) = codigo_caja Then
                EstaLaCaja = True
            End If

        Next

        Return EstaLaCaja
    End Function


    Dim filaSeleccionada As String = ""

    Private Sub ListBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ListBox1.KeyPress
        ListBox1_SelectedIndexChanged()
        If e.KeyChar = ChrW(13) AndAlso filaSeleccionada <> "" Then
            If MsgBox("Desea Eliminar la caja seleccionada", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = MsgBoxResult.Yes Then
                ListBox1.Items.RemoveAt(filaSeleccionada)
                filaSeleccionada = ""
            End If
        End If

    End Sub

    Private Sub ListBox1_SelectedIndexChanged()
        filaSeleccionada = ListBox1.SelectedIndex.ToString()
    End Sub


    Private Sub BtnGuardaTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardaTodo.Click
        If fnc.verificaExistencia("Pallet", "pal_cod", tpal.Text) = True Then
            MsgBox("Pallet ya agregado")
        Else

            If CajasTotal.Text = txtcaj.Text Then
                If MsgBox("Desea Terminar la lectura de este pallet", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = MsgBoxResult.Yes Then
                    'Actualiza Estado del pallet
                    '0 activo 1 terminado
                    Dim AgregaPallet As String = "INSERT INTO Pallet(pal_cod, pal_caj)VALUES('" + tpal.Text + "','" + txtcaj.Text + "')"

                    If fnc.MovimientoSQL(AgregaPallet) > 0 Then
                        LblM.Text = "Pallet Terminado"

                        For i As Integer = 0 To ListBox1.Items.Count - 1
                            Dim sqlGuardaCAjas As String = "INSERT INTO Cajas(caj_cod, Caj_pcod)" & _
                                                "VALUES('" + tpal.Text + "','" + ListBox1.Items(i).ToString() + "')"
                            If fnc.MovimientoSQL(sqlGuardaCAjas) > 0 Then
                                LblM.Text = "Se han Guardado  " & (i + 1).ToString() & "  Cajas"
                            End If

                        Next
                    End If
                End If
            Else
                LblM.Text = "Faltan cajas por ingresar"
            End If
        End If
    End Sub

    Private Sub Frm_Trakeo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            BtnGuardaTodo_Click(sender, e)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        tpal.Text = ""
        BtnPallet.Enabled = True
        txtrecibe.Text = ""
        txtcaj.Text = ""
        CajasTotal.Text = ""
        BtnGuardaTodo.Enabled = False

        For i As Integer = 0 To ListBox1.Items.Count - 1
            ListBox1.Items.RemoveAt(0)
        Next
    End Sub


    Private Sub tpal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tpal.KeyPress
        If e.KeyChar = ChrW(13) Then
            Dim fin As Integer = Convert.ToInt32(tpal.Text)

            If Not IsNumeric(Convert.ToInt32(fin)) Then
                MsgBox("Codigo mal escrito")
            Else
                'guarda en grilla

                If fnc.verificaExistencia("Pallet", "pal_cod", fin.ToString()) = True Then
                    If Len(fin.ToString()) >= 7 Then
                        tpal.Text = fin.ToString()
                        Dim sql As String = "SELECT pal_caj FROM Pallet WHERE pal_cod='" + tpal.Text + "'"

                        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

                        If tabla.Rows.Count > 0 Then
                            CajasTotal.Text = tabla.Rows(0)(0).ToString()
                        End If

                        tpal.Text = ""
                        txtrecibe.Text = ""
                        txtrecibe.Enabled = False

                        MsgBox("El pallet se encuentra trakeado", MsgBoxStyle.Information, "Aviso")
                        BtnGuardaTodo.Enabled = False
                    End If
                Else

                    Dim x1 As String = InputBox("Ingrese la cantidad de CAJAS que tiene el pallet", MsgBoxStyle.Question)
                    If Not IsNumeric(x1) Then
                        MsgBox("Error No es numero")
                        Exit Sub
                    Else
                        CajasTotal.Text = x1.ToString()
                    End If

                    tpal.Text = fin.ToString()

                    ' 
                End If

                tpal.Enabled = False
                BtnPallet.Enabled = False
                txtrecibe.Enabled = True

            End If
        Else
            SoloNumeros(sender, e)
        End If
    End Sub

    Private Sub txtrecibe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtrecibe.TextChanged

    End Sub
End Class
