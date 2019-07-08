Public Class Frm_Pedidos_Locales_Detalle_Local
    Dim fnc As New Funciones

    Public Ord As String = ""
    Public Fec As String = ""
    Public Cli As String = ""
    Public Rut As String = ""
    Public CodUsu As String = ""

    Private Sub Frm_Pedidos_Locales_Detalle_Local_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblOrden.Text = Ord
        lblFecPed.Text = Fec
        lblCli.Text = Cli
        buscarDetLocs()
    End Sub

    Sub buscarDetLocs()
        Try
            Dim sql As String = "SP_Pedidos_Locales_Detalle_Locales_Listar '" & Ord & "'"
            Dim dtRes As DataTable = fnc.ListarTablasSQL(sql)

            If (dtRes.Rows.Count > 0) Then
                dgDetLoc.DataSource = dtRes
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al buscar el detalle de los Locales", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub dgDetLoc_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgDetLoc.DoubleClick
        detPal()
    End Sub

    Sub detPal()
        Try
            Dim IDLoc As String = dgDetLoc.Item(dgDetLoc.CurrentRowIndex, 0).ToString.Trim
            Dim NomLoc As String = dgDetLoc.Item(dgDetLoc.CurrentRowIndex, 1).ToString.Trim

            Dim f As New Frm_Pedidos_Locales_Detalle_Pallets
            f.Ord = Ord
            f.Fec = Fec
            f.Cli = Cli
            f.Rut = Rut
            f.IDLoc = IDLoc
            f.Loc = NomLoc
            f.CodUsu = CodUsu
            f.ShowDialog()
            buscarDetLocs()
        Catch ex As Exception
            MsgBox("Ocurrió un error al seleccionar el Local.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub dgDetLoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgDetLoc.KeyPress
        If (e.KeyChar = ChrW(13)) Then
            detPal()
        End If
    End Sub

    Private Sub btnVol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVol.Click
        Me.Close()
    End Sub
End Class