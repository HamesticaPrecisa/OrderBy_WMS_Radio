Imports System.Data.SqlClient

Public Class frm_DetOTTunel

    Private fnc As Funciones = New Funciones()
    Private picked As Integer

    Public ott_id As Integer
    Public ott_numero As String
    Public ott_maxpallets As Integer
    Public frec_guiades As String
    Public frec_codi As String
    Public cli_nomb As String

    Private Sub frm_DetOTTunel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Text = "OT #" + ott_numero.Trim()
        lblInfoOT.Text = frec_guiades.Trim() + "-" + cli_nomb.Trim()
        requeryPallets()
        If picked = 0 Then Picking()
    End Sub


    Private Sub requeryPallets()
        Dim Sql As String = "SELECT drec_codi,dot_ca,dot_ba,dot_co,dot_pi,dot_ni " & _
                            "  FROM det_ots_tunel " & _
                            " WHERE ott_id = @ott_id"
        Dim pallets As DataTable = fnc.ListarTablasSQL(Sql, New SqlParameter() {New SqlParameter("@ott_id", SqlDbType.Int) With {.Value = ott_id}})
        DataGrid1.DataSource = pallets
        picked = pallets.Rows.Count
        refreshPickCount()
    End Sub

    Private Sub refreshPickCount()
        lblCount.Text = String.Format("{0} pallets de {1} - {2} faltantes", picked, ott_maxpallets, ott_maxpallets - picked)
        Panel1.BackColor = If(picked < ott_maxpallets, Color.Red, Color.DarkGreen)
        lblCount.BackColor = Panel1.BackColor

        btnEliminar.Visible = (picked > 0)
        btnFinalizar.Visible = (picked = ott_maxpallets)
        btnAgregar.Visible = (picked < ott_maxpallets)
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        picking()
    End Sub

    Private Sub Picking()
        Dim f As New frm_PickOTTUnel
        f.usuario = encargado_global
        f.cargo = ""
        f.perfil = ""
        f.codigo = id_global.ToString()
        f.frec_codi = frec_codi
        f.picked = picked
        f.max_pallets = ott_maxpallets
        f.ott_id = ott_id
        f.ott_numero = ott_numero
        f.ShowDialog()
    End Sub
End Class