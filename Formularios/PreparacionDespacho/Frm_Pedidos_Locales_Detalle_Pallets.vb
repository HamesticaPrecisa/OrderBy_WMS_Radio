Public Class Frm_Pedidos_Locales_Detalle_Pallets
    Dim fnc As New Funciones

    Public Ord As String = ""
    Public Fec As String = ""
    Public Cli As String = ""
    Public Rut As String = ""
    Public IDLoc As String = ""
    Public Loc As String = ""
    Public CodUsu As String = ""

    Private Sub Frm_Pedidos_Locales_Detalle_Pallets_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblOrden.Text = Ord
        lblFecPed.Text = Fec
        lblCli.Text = Cli
        lblIdLoc.Text = IDLoc
        lblLoc.Text = Loc
        cargarDetsPalls()
    End Sub

    Public Sub cargarDetsPalls()
        Try
            Dim sql As String = "SP_Pedidos_Locales_Detalle_Pallets_Listar '" & Ord & "','" & IDLoc & "'"
            Dim dtResp As DataTable = fnc.ListarTablasSQL(sql)

            If (dtResp.Rows.Count > 0) Then
                dgDetPals.DataSource = dtResp
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al buscar el detalle de los Pallets", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub dgDetPals_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgDetPals.DoubleClick
        recepCajs()
    End Sub

    Sub recepCajs()
        Try
            Dim DatCajs As String() = dgDetPals.Item(dgDetPals.CurrentRowIndex, 3).ToString.Trim.Split("/")
            Dim CajsMarc As Integer = Integer.Parse(DatCajs(0))
            Dim CajsTot As Integer = Integer.Parse(DatCajs(1))
            Dim CajsPend As Integer = CajsTot - CajsMarc

            If (CajsPend <= 0) Then
                MsgBox("Este Soportante ya está terminado.", MsgBoxStyle.Critical, "Error")
                Exit Sub
            End If

            Dim Soportante As String = dgDetPals.Item(dgDetPals.CurrentRowIndex, 0).ToString.Trim
            Dim Posicion As String = dgDetPals.Item(dgDetPals.CurrentRowIndex, 2).ToString.Trim

            Dim sqlExiTrack = "select caj_cod from DetaReceCajas with(nolock) where caj_ped='0' and caj_Pcod='" & Soportante & "'"
            Dim dtExiTrack As DataTable = fnc.ListarTablasSQL(sqlExiTrack)

            If (dtExiTrack.Rows.Count > 0) Then
                Dim f As New Frm_Pedidos_Locales_Pallet_Trackeo_Preparar
                f.Ord = Ord
                f.IdLoc = IDLoc
                f.Soportante = Soportante
                f.Posicion = Posicion
                f.CajsPend = CajsPend
                f.CodUsu = CodUsu
                f.ShowDialog()
            Else
                Dim f As New Frm_Pedidos_Locales_Pallet_Preparar
                f.Ord = Ord
                f.IdLoc = IDLoc
                f.Soportante = Soportante
                f.Posicion = Posicion
                f.CajsPend = CajsPend
                f.CodUsu = CodUsu
                f.ShowDialog()
            End If

            cargarDetsPalls()
        Catch ex As Exception
            MsgBox("Ocurrió un error al preparar este Pallet", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub dgDetPals_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgDetPals.KeyPress
        If (e.KeyChar = ChrW(13)) Then
            recepCajs()
        End If
    End Sub

    Private Sub btnVol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVol.Click
        Me.Close()
    End Sub
End Class