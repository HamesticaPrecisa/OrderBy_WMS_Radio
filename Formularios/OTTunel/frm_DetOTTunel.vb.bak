Imports System.Data.SqlClient

Public Class frm_DetOTTunel

    Private fnc As Funciones = New Funciones()

    Public caller As Frm_OTTunel
    Public cam_codi As String
    Public cam_descr As String
    Public ott_id As Integer
    Public ott_numero As String
    Public ott_maxpallets As Integer
    Public frec_guiades As String
    Public frec_codi As String
    Public cli_nomb As String

    Private picked As Integer


    Private Sub frm_DetOTTunel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Text = String.Format("OT #{0}", ott_numero.Trim())
        lblInfoOT.Text = frec_guiades.Trim() + "-" + cli_nomb.Trim()
        requeryPallets()
        If picked = 0 Then Picking()
    End Sub


    Private Sub requeryPallets()
        Dim sql As String = "SELECT e.racd_codi, e.racd_ca, e.racd_ba, e.racd_co, e.racd_pi, e.racd_ni " & _
                            "  FROM ots_tunel a " & _
                            "  INNER JOIN fichrece b ON b.frec_unica = a.frec_unica " & _
                            "  INNER JOIN detarece c ON c.frec_codi1 = b.frec_codi " & _
                            "  INNER JOIN camaras d ON d.cam_unica = a.cam_unica " & _
                            "  INNER JOIN rackdeta e ON e.racd_codi = c.drec_codi AND e.racd_ca = d.cam_codi " & _
                            "   LEFT JOIN det_ots_tunel f ON f.drec_codi = c.drec_codi " & _
                            "  WHERE a.ott_id = @ott_id " & _
                            "    AND f.dot_id IS NULL"
        Dim data As DataTable = fnc.ListarTablasSQL(sql, _
                                                    New SqlParameter() { _
                                                        New SqlParameter("@ott_id", ott_id) _
                                                    })

        DataGrid1.DataSource = Data
        picked = Data.Rows.Count
        refreshPickCount()
    End Sub

    Private Sub refreshPickCount()
        lblCount.Text = String.Format("{0} - {1}/{2} - {3} falt", cam_descr, picked, ott_maxpallets, ott_maxpallets - picked)
        Panel1.BackColor = If(picked < ott_maxpallets, Color.Red, Color.DarkGreen)
        lblCount.BackColor = Panel1.BackColor
        lblInfoOT.BackColor = Panel1.BackColor
        btnAgregar.Text = If(picked < ott_maxpallets, "Posicionar", "Finalizar")
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If picked < ott_maxpallets Then
            Picking()
        Else
            If Finalizar() Then Me.Close()
        End If
    End Sub

    Private Sub Picking()
        Dim f As New Frm_PosNew
        f.usuario = encargado_global
        f.cargo = ""
        f.perfil = ""
        f.codigo = id_global.ToString()
        f.ShowDialog()
        requeryPallets()
    End Sub

    Private Function Finalizar() As Boolean
        If MessageBox.Show("Finalizar esta OT?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            Return False
        End If
        '
        ' UBICAMOS LOS PALLETS DE LA GIUA ASOCIADA A LA OT
        ' QUE ESTEN UBICADOS EN EL TUNEL CORRESPONDIENTE
        ' Y QUE NO ESTEN REGISTRADOS COMO PARTE DE OTRA OT
        '
        ' ESTOS PALLETS SERAN REGISTRADOS COMO PARTE DE LA
        ' NUEVA OT
        '
        Dim sql1 As String = "INSERT INTO det_ots_tunel (ott_id, drec_codi, dot_ca, dot_ba, dot_co, dot_pi, dot_ni) " & _
                             "SELECT a.ott_id, c.drec_codi, e.racd_ca, e.racd_ba, e.racd_co, e.racd_pi, e.racd_ni " & _
                             "  FROM ots_tunel a " & _
                             " INNER JOIN fichrece b ON b.frec_unica = a.frec_unica " & _
                             " INNER JOIN detarece c ON c.frec_codi1 = b.frec_codi " & _
                             " INNER JOIN camaras d ON d.cam_unica = a.cam_unica " & _
                             "  LEFT JOIN rackdeta e ON e.racd_codi = c.drec_codi AND e.racd_ca = d.cam_codi " & _
                             "  LEFT JOIN det_ots_tunel f ON f.drec_codi = c.drec_codi " & _
                             " WHERE a.ott_id = @ott_id " & _
                             "   AND f.dot_id IS NULL"

        Dim sql2 As String = "UPDATE ots_tunel " & _
                             "   SET ott_status = 'PORINICIAR', " & _
                             "       ott_fecsta=GETDATE(), " & _
                             "       ott_finalcarga=GETDATE() " & _
                             " WHERE ott_id = @ott_id"

        Dim con As Conexion = New Conexion()
        Dim cmd1 As SqlCommand
        Dim cmd2 As SqlCommand 
        Dim tx As SqlTransaction
        Dim ok As Boolean = False
        Try
            con.conectarSQL()
            tx = con.conSQL.BeginTransaction()
            cmd1 = New SqlCommand(sql1, con.conSQL, tx)
            cmd1.Parameters.AddWithValue("@ott_id", ott_id)

            cmd2 = New SqlCommand(sql2, con.conSQL, tx)
            cmd2.Parameters.AddWithValue("@ott_id", ott_id)

            cmd1.ExecuteNonQuery()
            cmd2.ExecuteNonQuery()
            tx.Commit()
            ok = True

        Catch Ex As SqlException
            If con.conSQL.State = ConnectionState.Open And tx IsNot Nothing Then tx.Rollback()
            MessageBox.Show(Ex.Message, "Cuidado", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)

        Catch Ex As Exception
            If con.conSQL.State = ConnectionState.Open And tx IsNot Nothing Then tx.Rollback()
            MessageBox.Show(Ex.Message, "Cuidado", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)

        Finally
            If con.conSQL.State = ConnectionState.Open Then con.cerrarSQL()
        End Try

        Return ok
    End Function

    Private Sub cmdDescartar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDescartar.Click
        If caller.Descartar() Then Me.Close()
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnSalir_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class