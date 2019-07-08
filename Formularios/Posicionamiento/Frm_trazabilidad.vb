Imports System.Data
Imports System.Windows
Imports System.Windows.Forms


Public Class Frm_trazabilidad

    Dim fnc As New Funciones
    Dim pick As String = ""
    Dim picktra As String = ""

    Public Function TransformaPallet(ByVal pallet As String) As String
        Dim separado As String = ""
        For i As Integer = 11 To pallet.Length - 2
            separado = separado + pallet.Chars(i)
        Next
        txtpallet.Text = separado
        Return separado
    End Function

    Private Sub txtusuario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpallet.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then

            Dim palletpadre As String = ""
            Dim tablaq As DataTable = New DataTable
            tablaq = fnc.ListarTablasSQL("SELECT * FROM PALLETPICK WHERE  palletpick='" + txtpallet.Text.Trim() + "'")

            If tablaq.Rows.Count > 0 Then
                Dim tablaTRA As DataTable = New DataTable
                tablaTRA = fnc.ListarTablasSQL("SELECT * FROM MOVPALLET WHERE  mov_folio='" + txtpallet.Text.Trim() + "'")
                If tablaTRA.Rows.Count > 0 Then

                    picktra = txtpallet.Text
                Else
                    picktra = ""

                End If
                palletpadre = tablaq.Rows(0)(0).ToString().Trim()
                pick = txtpallet.Text.Trim()
                txtpallet.Text = palletpadre
            Else
                pick = ""
            End If




            If txtpallet.Text.Length > 4 Then
                If txtpallet.Text.Chars(0).ToString() + txtpallet.Text.Chars(1).ToString() + txtpallet.Text.Chars(2).ToString() = "]C1" Then
                    txtpallet.Text = txtpallet.Text.Remove(0, 3)
                End If
            Else
                txtpallet.Text = ""
                txtpallet.Focus()
                Return
            End If

            Dim _codigopallet As String = ""

            If txtpallet.Text.Length = 20 Then
                _codigopallet = CodigoPallet("0" + txtpallet.Text)
            Else
                _codigopallet = CerosAnteriorString(txtpallet.Text, 9)
            End If
            Dim sqlbusca As String = ""
            sqlbusca = "SELECT descri, mov_ca, mov_ba, mov_co, mov_pi, " & _
                                     "mov_ni, mov_fecha, mov_hora FROM movpallet mp , usuarios ug WHERE " & _
                                     "mov_folio='" + _codigopallet + "' AND personal=mov_codper ORDER BY mov_fecha ASC, " & _
                                     "mov_hora ASC"
            If picktra = "" Then
            Else
                sqlbusca = "SELECT descri, mov_ca, mov_ba, mov_co, mov_pi, " & _
                                 "mov_ni, mov_fecha, mov_hora FROM movpallet mp , usuarios ug WHERE " & _
                                 "mov_folio='" + picktra + "' AND personal=mov_codper ORDER BY mov_fecha ASC, " & _
                                 "mov_hora ASC"

            End If
            Dim tabla As DataTable = fnc.ListarTablasSQL(sqlBusca)

            If tabla.Rows.Count > 0 Then
                'grilla.DataSource = tabla

                Dim sql As String = "SELECT racd_ca, racd_Ba, racd_Co, racd_Pi, racd_Ni, racd_fechamov, racd_horamov FROM " & _
                              "rackdeta WHERE racd_codi='" + _codigopallet + "'"

                Dim tablaUltimaPos As DataTable = fnc.ListarTablasSQL(sql)

                If tablaUltimaPos.Rows.Count > 0 Then

                    If picktra = "" Then
                        tabla.Rows.Add("ACTUAL->", tablaUltimaPos.Rows(0)(0), tablaUltimaPos.Rows(0)(1), tablaUltimaPos.Rows(0)(2), _
                                       tablaUltimaPos.Rows(0)(3), tablaUltimaPos.Rows(0)(4), "", "")
                    Else

                    End If

                    grilla.DataSource = tabla
                Else
                    grilla.DataSource = tabla
                End If




                    txtpallet.Text = _codigopallet
                    txtpallet.Enabled = False
                    grilla.Visible = True
                End If


            txtpallet.SelectAll()
        End If
    End Sub

    Private Sub BtnLiberar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLiberar.Click

        txtpallet.Enabled = True
        txtpallet.Text = ""
        grilla.Visible = False
        txtpallet.Focus()

    End Sub
End Class