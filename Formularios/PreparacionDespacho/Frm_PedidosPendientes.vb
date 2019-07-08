Public Class Frm_PedidosPendientes
    Dim fnc As New Funciones
    Public orden As String = ""
    Dim tabla_datos As DataTable

    Private Sub Frm_PedidosPendientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarPedidos()
    End Sub

    Private Sub cargarPedidos()
        Dim sqlPedidosPendientes As String

        sqlPedidosPendientes = " SELECT  pedido, Orden,cli_nomb AS cliente, fecha, hora, '0/0' AS Sop, destino, destino AS sopo, codvig " & _
                               " FROM pedidos_ficha, clientes" & _
                               " WHERE cli_rut=cliente AND terminado <>'3' AND Ped_estpred<>'3' AND codvig='0' AND" & _
                               " Orden not in(SELECT fpre_nped FROM fichpred) AND Dateadd(day,2,Convert(date,fecha,103))>Convert(date,GETDATE(),103) ORDER BY orden DESC"

        Dim tablapedidos As DataTable = fnc.ListarTablasSQL(sqlPedidosPendientes)
        tabla_datos = tablapedidos
        tbl_pedidos_pendientes.DataSource = tablapedidos


        For i As Integer = 0 To tablapedidos.Rows.Count - 1

            Dim sqlTotal As String = "SELECT COUNT(*) FROM pedidos_detalle WHERE pedido='" + tablapedidos.Rows(i)(0).ToString() + "'"
            Dim tablatotal As DataTable = fnc.ListarTablasSQL(sqlTotal)

            Dim sqlTotal2 As String = "SELECT COUNT(*) FROM pedidos_detalle WHERE pedido='" + tablapedidos.Rows(i)(0).ToString() + "' AND est='1'"
            Dim tablatotal2 As DataTable = fnc.ListarTablasSQL(sqlTotal2)

            If tablatotal.Rows.Count > 0 AndAlso tablatotal2.Rows.Count > 0 Then
                Dim todos As String = tablatotal.Rows(0)(0).ToString()
                Dim de As String = tablatotal2.Rows(0)(0).ToString()
                tablapedidos.Rows(i)(5) = (de + " / " + todos).ToString()
            End If

        Next

    End Sub

    Private Sub tbl_pedidos_pendientes_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbl_pedidos_pendientes.DoubleClick

        Dim i As Integer
        i = CInt(tbl_pedidos_pendientes.CurrentRowIndex.ToString)
        orden = tabla_datos.Rows(i)(1).ToString()

        'Dim r As New Frm_Preparar

        Dim p1 As String = mod_ped1
        Dim p2 As String = mod_ped2
        Dim p3 As String = mod_ped3

        If (p1 = orden) Or (p2 = orden) Or (p3 = orden) Then
        Else
            If (Trim(mod_ped1) = "") Then
                mod_ped1 = orden
            ElseIf (Trim(mod_ped2) = "") Then
                mod_ped2 = orden
            ElseIf (Trim(mod_ped3) = "") Then
                mod_ped3 = orden
            Else
                MsgBox("Todas las casillas tienen valores")
            End If
        End If
        'r.Show()
        Dim frm As New Frm_Preparar
        frm.codigo = Convert.ToString(id_global)
        frm.encargado = encargado_global
        frm.ShowDialog()
        Me.Close()
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Dim r As New Frm_Preparar
        r.Show()
        Me.Close()
    End Sub
End Class