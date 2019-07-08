Public Class Frm_ListadoPedidos

    Public rutcli As String = ""
    Public codigoPedido As Integer = 0

    Dim fnc As New Funciones

    Private Sub Frm_ListadoPedidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Dim sql As String = "SELECT orden, pedido, fecha, ordenconjunta FROM  Pedidos_ficha WHERE codvig='0' AND " & _
        '"cliente='" + rutcli.ToString + "' AND fecha>=convert(date, getdate()) AND isnull(Ped_EstPred,0)='0' ORDER BY Orden desc "


        Dim sql As String = "SELECT orden, pedido, fecha, ordenconjunta FROM  Pedidos_ficha WHERE codvig='0' AND " & _
        "cliente='" + rutcli.ToString + "' AND fecha>=convert(date, getdate()) AND isnull(Ped_EstPred,0)<'3' ORDER BY Orden desc "

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        DgvPedidos.DataSource = tabla
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub DgvPedidos_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DgvPedidos.CurrentCellChanged
        codigoPedido = CInt(DgvPedidos(DgvPedidos.CurrentCell.RowNumber, 0))
        Button1.Visible = True
    End Sub

End Class
