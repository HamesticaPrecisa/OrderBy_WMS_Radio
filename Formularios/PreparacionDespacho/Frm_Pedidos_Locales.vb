Public Class Frm_Pedidos_Locales
    Dim fnc As New Funciones
    Dim valorRecibido As String = ""
    Public CodUsu As String = ""

    Private Sub Frm_Pedidos_Locales_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim FecAct As Date = fnc.DevuelveFechaServidor

        txtFecIni.MinDate = DateAdd(DateInterval.Month, -2, FecAct)
        txtFecIni.MaxDate = DateAdd(DateInterval.Month, 2, FecAct)
        txtFecIni.Value = FecAct
        txtFecFin.MinDate = DateAdd(DateInterval.Month, -2, FecAct)
        txtFecFin.MaxDate = DateAdd(DateInterval.Month, 2, FecAct)
        txtFecFin.Value = FecAct
        limpiar()
    End Sub

    Sub pedidosPendientes()
        Try
            Dim Rut As String = txtRut.Text.Trim.Replace("-", "")
            Dim FecIni As String = txtFecIni.Value.Date.ToString("yyyyMMdd")
            Dim FecFin As String = txtFecFin.Value.Date.ToString("yyyyMMdd")

            Dim sql As String = "SP_Pedidos_Locales_Pendientes_Listar '" & Rut & "','" & FecIni & "','" & FecFin & "'"
            Dim dtResp As DataTable = fnc.ListarTablasSQL(sql)

            If (dtResp.Rows.Count > 0) Then
                dgPedPen.DataSource = dtResp
            Else
                MsgBox("No se encontraron Pedidos Locales Pendientes.", MsgBoxStyle.Information, "Info!")
                dgPedPen.DataSource = Nothing
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al buscar los Pedidos Locales Pendientes.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnBusCli_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBusCli.Click
        Try
            Dim frm As New Lst_AyudaClientes
            Dim res As DialogResult = frm.ShowDialog()

            If frm.resultado = "OK" Then
                Me.valorRecibido = frm.IdPrincipal
            End If

            txtRut.Text = frm.IdPrincipal
            txtFecIni.Focus()
        Catch ex As Exception
            MsgBox("Ocurrió un error al buscar los Clientes.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Sub buscarCli()
        Try
            Dim Rut As String = txtRut.Text.Trim.Replace("-", "")
            If (Rut <> "") Then
                Dim sql As String = "SELECT cli_nomb, cli_estado FROM clientes WHERE cli_rut='" + valorRecibido + "'"
                Dim resp As DataTable = fnc.ListarTablasSQL(sql)
                If (resp.Rows.Count > 0) Then
                    txtCli.Text = resp.Rows(0).Item(0).ToString.Trim
                Else
                    MsgBox("No se encontraron los datos del Cliente.", MsgBoxStyle.Information, "No existe Cliente")
                End If
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al buscar los datos del Cliente.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub txtRut_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRut.LostFocus
        buscarCli()
    End Sub

    Sub limpiar()
        Try
            Dim FecAct As Date = fnc.DevuelveFechaServidor

            txtRut.Text = ""
            txtCli.Text = ""
            txtFecIni.Value = FecAct
            txtFecFin.Value = FecAct
            dgPedPen.DataSource = Nothing
            txtRut.Focus()
        Catch ex As Exception
            MsgBox("Ocurrió un error al limpiar el Formulario.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnLim_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLim.Click
        limpiar()
    End Sub

    Private Sub btnFil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFil.Click
        pedidosPendientes()
    End Sub

    Private Sub btnSal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSal.Click
        Me.Close()
    End Sub

    Private Sub dgPedPen_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgPedPen.DoubleClick
        detLocs()
    End Sub

    Sub detLocs()
        Try
            Dim Orden As String = dgPedPen.Item(dgPedPen.CurrentRowIndex, 1).ToString.Trim
            Dim Fecha As String = dgPedPen.Item(dgPedPen.CurrentRowIndex, 0).ToString.Trim
            Dim Cliente As String = txtCli.Text.Trim
            Dim Rut As String = txtRut.Text.Trim

            Dim f As New Frm_Pedidos_Locales_Detalle_Local
            f.Ord = Orden
            f.Fec = Fecha
            f.Cli = Cliente
            f.Rut = Rut
            f.CodUsu = CodUsu
            f.ShowDialog()
            pedidosPendientes()
        Catch ex As Exception
            MsgBox("Ocurrió un error al seleccionar el Pedido.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


    Private Sub dgPedPen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgPedPen.KeyPress
        If (e.KeyChar = ChrW(13)) Then
            detLocs()
        End If
    End Sub

    Private Sub btnVol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVol.Click
        Me.Close()
    End Sub

    Private Sub btnCons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCons.Click
        Try
            Dim row As Integer = dgPedPen.CurrentRowIndex
            MsgBox(row, MsgBoxStyle.Information, "Info")
            Dim Orden As String = dgPedPen.Item(dgPedPen.CurrentRowIndex, 1).ToString.Trim
        Catch ex As Exception
            MsgBox("Ocurrió un error al consolidar el Pedido seleccionado.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class