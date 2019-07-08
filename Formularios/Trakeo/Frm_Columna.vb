Imports System.Data
Imports System.Windows
Imports System.Windows.Forms

Public Class Frm_Columna
    Dim fnc As New Funciones


    Private Sub txtusuario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtposicion.KeyPress
        Dim camara As String = ""
        Dim banda As String = ""
        Dim columna As String = ""
        Dim cadena As String
        Dim switch As String

        If e.KeyChar = ChrW(Keys.Enter) Then
            switch = "0"

            If txtposicion.Text.Length >= 13 Then
                cadena = txtposicion.Text.Substring(6, 6)
                camara = cadena.Substring(0, 2)
                banda = cadena.Substring(2, 2)
                columna = cadena.Substring(4, 2)
                switch = "1"
            End If

            If txtposicion.Text.Length = 6 Then
                cadena = txtposicion.Text
                camara = cadena.Substring(0, 2)
                banda = cadena.Substring(2, 2)
                columna = cadena.Substring(4, 2)
                switch = "1"
            End If

            If switch = "0" Then
                txtposicion.Text = ""
                txtposicion.Focus()
                Return
            End If

            Dim _codigoposicion As String = ""

            _codigoposicion = txtposicion.Text


            Dim sqlBusca As String = "SELECT racd_codi As Pallet,racd_ca As Camara, racd_Ba As Banda, racd_Co As Columna, racd_Pi As Piso, racd_Ni As Nivel FROM " & _
                                    "rackdeta WHERE (racd_ca = N'" + camara + "') AND (racd_ba = N'" + banda + "') AND (racd_co = N'" + columna + "') ORDER BY racd_Pi ASC"

            Dim tabla As DataTable = fnc.ListarTablasSQL(sqlBusca)

            If tabla.Rows.Count > 0 Then
                grilla.DataSource = tabla
                txtposicion.Text = _codigoposicion
                txtposicion.Enabled = False
                grilla.Visible = True
            Else
                MsgBox("Posicion no encontrada")
            End If
            txtposicion.SelectAll()
        End If
    End Sub

    Private Sub BtnLiberar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLiberar.Click
        txtposicion.Enabled = True
        txtposicion.Text = ""
        grilla.Visible = False
        txtposicion.Focus()

    End Sub
End Class