Public Class PosicionRecepciones

    Dim fnc As New Funciones

    Private Sub TxtRece_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtRece.KeyPress
        If e.KeyChar = ChrW(13) Then
            If TxtRece.Text.Length > 0 Then
                TxtRece.Text = CerosAnteriorString(TxtRece.Text, 7)
                Dim sql As String = "SELECT RIGHT(drec_codi,2) AS PALLET, isnull(drec_camara,0) FROM detarece WHERE LEFT(drec_codi,7)='" + TxtRece.Text + "'"
                Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

                If tabla.Rows.Count > 0 Then
                    If tabla.Rows.Count <= 69 Then
                        TxtRece.Enabled = False
                        Llenar(tabla)
                    Else
                        MsgBox("No se puede ver el estado de los soportantes", MsgBoxStyle.Critical, "Aviso")
                    End If
                Else
                    TxtRece.Text = ""
                    MsgBox("La recepcion ingresada no existe", MsgBoxStyle.Critical, "Aviso")
                End If
            End If
        End If

    End Sub


    Sub Reset()
        Dim tb As Button
        For i As Integer = 0 To 69
            tb = DirectCast(GetReference("t" + (i + 1).ToString()), Button)
            tb.BackColor = Color.Black
            tb.ForeColor = Color.Black
            tb.Visible = False
        Next
    End Sub

    Sub Llenar(ByVal tabla As DataTable)
        Dim tb As Button

        For i As Integer = 0 To tabla.Rows.Count - 1
            tb = DirectCast(GetReference("t" + (i + 1).ToString()), Button)
            If tabla.Rows(i)(1).ToString() = "71" Or tabla.Rows(i)(1).ToString() = "72" Or _
               tabla.Rows(i)(1).ToString() = "73" Or tabla.Rows(i)(1).ToString() = "74" Or _
               tabla.Rows(i)(1).ToString() = "75" Or tabla.Rows(i)(1).ToString() = "76" Then
                tb.ForeColor = Color.White
                tb.BackColor = Color.Red
                tb.Visible = True
            Else
                tb.ForeColor = Color.White
                tb.BackColor = Color.Green
                tb.Visible = True
            End If

        Next


    End Sub


    Private Function GetReference(ByVal nombreControl As String) As Control

        ' Recorremos la colección de controles del formulario
        '
        For Each ctrl As Control In Me.Controls

            If ctrl.Name.ToLower = nombreControl.ToLower Then
                ' Devolvemos la referencia y abandonamos la función
                Return ctrl
            End If
        Next
        Return Nothing
    End Function

    Private Sub Frm_PorTraquear_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Reset()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Reset()
        TxtRece.Text = ""
        TxtRece.Enabled = True
        TxtRece.Focus()
    End Sub
End Class