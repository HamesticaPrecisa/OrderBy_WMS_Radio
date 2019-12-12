Public Class Frm_Menu

    Public usuario As String = "" 'se recibe desde el login
    Public cargo As String = ""
    Public perfil As String = ""
    Public codigo As Integer = 0  ' se recibe desde el login

    Dim fnc As New Funciones

    Private Sub Frm_Menu_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Application.Exit()
    End Sub


    Private Sub Menu_pos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_78.Click
        Dim f As New Frm_PosNew
        f.usuario = Me.usuario
        f.cargo = Me.cargo
        f.perfil = Me.perfil
        f.codigo = Me.codigo.ToString()
        f.ShowDialog()

    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim frm As New frm_cuenta
        frm.txtusuario.Text = Me.usuario.ToString()
        frm.txtcargo.Text = Me.cargo.ToString()
        frm.txtperfil.Text = Me.perfil.ToString()
        frm.txtnumero.Text = Me.codigo.ToString()
        frm.ShowDialog()

    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_83.Click
        Dim f As New PosicionRecepciones
        f.ShowDialog()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New FrmDespacho
        frm.CODIENCA = Me.codigo.ToString()
        frm.ShowDialog()
    End Sub

    Private Sub Frm_Menu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = Me.usuario

        m_pedidos_locales.Enabled = True
        ml_pedidos_locales.BackColor = Color.Silver

        Dim tabla As DataTable = fnc.ListarTablasSQL("SELECT Spriv_Id, Spriv_nombre, Spriv_PrivId " & _
                                                     "  FROM UsuariosFunciones AS uf ,PrivilegiosSubSeccion AS us , Usuarios " & _
                                                     " WHERE uf.Usu_Rut = Usuarios.usu_rut " & _
                                                     "   AND uf.Usu_SprivId = us.Spriv_Id " & _
                                                     "   AND Spriv_PrivId = '026' " & _
                                                     "   AND usu_codigo = '" + CerosAnteriorString(codigo.ToString(), 3) + "'")

        For i As Integer = 0 To tabla.Rows.Count - 1

            If tabla.Rows(i)(0).ToString() = "078" Then
                m_78.Enabled = True
                ml_78.BackColor = Color.Silver
                m_117.Enabled = True
                ml_117.BackColor = Color.Silver
                m_116.Enabled = True
                ml_116.BackColor = Color.Silver
                M_666.Enabled = True
                ML_666.BackColor = Color.Silver

            End If

            If tabla.Rows(i)(0).ToString() = "079" Then
                m_79.Enabled = True
                ml_79.BackColor = Color.Silver
            End If

            If tabla.Rows(i)(0).ToString() = "080" Then
                m_80.Enabled = True
                ml_80.BackColor = Color.Silver
            End If

            If tabla.Rows(i)(0).ToString() = "081" Then
                m_81.Enabled = True
                ml_81.BackColor = Color.Silver
            End If

            If tabla.Rows(i)(0).ToString() = "082" Then
                m_82.Enabled = True
                ml_82.BackColor = Color.Silver
                m_118.Enabled = True
                ml_118.BackColor = Color.Coral.Silver
                pedidos_login = contarPedidos()
                timer_aviso.Enabled = True
            End If

            If tabla.Rows(i)(0).ToString() = "083" Then
                m_83.Enabled = True
                ml_83.BackColor = Color.Silver
            End If

            If tabla.Rows(i)(0).ToString() = "084" Then
                m_84.Enabled = True
                ml_84.BackColor = Color.Silver
            End If

            If tabla.Rows(i)(0).ToString() = "085" Then
                m_85.Enabled = True
                ml_85.BackColor = Color.Silver
            End If

            If tabla.Rows(i)(0).ToString() = "086" Then
                m_86.Enabled = True
                ml_86.BackColor = Color.Silver
            End If

            If tabla.Rows(i)(0).ToString() = "087" Then
                m_87.Enabled = True
                ml_87.BackColor = Color.Silver
            End If

            If tabla.Rows(i)(0).ToString() = "088" Then
                m_88.Enabled = True
                ml_88.BackColor = Color.Silver
            End If

            If tabla.Rows(i)(0).ToString() = "098" Then
                m_98.Enabled = True
                ml_98.BackColor = Color.Silver
            End If

            If tabla.Rows(i)(0).ToString() = "099" Then
                m_99.Enabled = True
                ml_99.BackColor = Color.Silver
            End If

            If tabla.Rows(i)(0).ToString() = "111" Then
                m_111.Enabled = True
                ml_111.BackColor = Color.Silver
            End If

            If tabla.Rows(i)(0).ToString() = "113" Then
                m_113.Enabled = True
                ml_113.BackColor = Color.Silver
            End If

            If tabla.Rows(i)(0).ToString() = "115" Then
                m_115.Enabled = True
                ml_115.BackColor = Color.Silver
            End If
            If tabla.Rows(i)(0).ToString() = "103" Then
                m_103.Enabled = True
                ml_103.BackColor = Color.Silver
            End If


            ' VES Sep 2019
            ' TODO: Asignar codigo de permiso
            m_201.Enabled = True
            ml_201.BackColor = Color.Silver
        Next
    End Sub

    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_82.Click
        Dim frm As New Frm_Preparar
        frm.codigo = Convert.ToString(id_global)
        frm.encargado = encargado_global
        frm.ShowDialog()
    End Sub

    Private Sub PictureBox12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_84.Click
        Dim frm As New Frm_Traqueo
        frm.codigo_usuario = Me.codigo.ToString()
        frm.ShowDialog()
    End Sub

    Private Sub PictureBox14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_80.Click
        Dim frm As New Frm_Etiquetado
        frm.codigo = Me.codigo.ToString()
        frm.encargado = Me.usuario.ToString()
        frm.ShowDialog()
        'MsgBox("En Construcción", MsgBoxStyle.Information, "Aviso")
    End Sub

    Private Sub PictureBox16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_81.Click
        Dim F As New Frm_PreDespacho
        F.codusu = Me.codigo
        F.ShowDialog()
    End Sub

    Private Sub PictureBox2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_85.Click
        Dim f As New FrmInventario2vb
        f.codigo = Me.codigo.ToString()
        f.ShowDialog()
    End Sub

    Private Sub PictureBox18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_79.Click
        Dim frm As New Frm_trazabilidad
        frm.ShowDialog()
    End Sub

    Private Sub LinkLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkLabel1.Click
        Application.Exit()
    End Sub

    Private Sub PictureBox9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_86.Click
        Dim f As New Frm_EstaEnPedido
        f.codusuario = Me.codigo.ToString()
        f.ShowDialog()
    End Sub

    Private Sub PictureBox3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_99.Click
        Dim f As New Frm_Andenes
        ' f.lblusu.Text = Me.codigo.ToString()
        f.usr = Me.usuario
        f.ShowDialog()
    End Sub

    Private Sub PictureBox20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_88.Click
        Dim f As New Revision_FaR
        f.lblusu.Text = Me.codigo.ToString()
        f.ShowDialog()
    End Sub

    Private Sub i_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim f As New FrmInventario2vb
        f.codigo = Me.codigo.ToString()
        f.ShowDialog()
    End Sub

    Private Sub m_98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_98.Click
        Dim f As New Frm_IngresoTunel
        f.codigo = Me.codigo.ToString()
        f.ShowDialog()
    End Sub

    Private Sub m_111_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_111.Click
        Dim f As New Frm_Columna
        f.ShowDialog()
    End Sub

    Private Sub m_113_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_113.Click
        Dim f As New Frm_TraqueoService
        f.ShowDialog()
    End Sub

    Private Sub m_115_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_115.Click
        Dim f As New Frm_recepción
        f.ShowDialog()
    End Sub

    Private Sub Frm_Menu_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = System.Windows.Forms.Keys.Up) Then
            'Up
        End If
        If (e.KeyCode = System.Windows.Forms.Keys.Down) Then
            'Down
        End If
        If (e.KeyCode = System.Windows.Forms.Keys.Left) Then
            'Left
        End If
        If (e.KeyCode = System.Windows.Forms.Keys.Right) Then
            'Right
        End If
        If (e.KeyCode = System.Windows.Forms.Keys.Enter) Then
            'Enter
        End If

    End Sub

    Private Sub PictureBox2_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_87.Click
        Dim f As New Revision_RaF
        f.lblusu.Text = Me.codigo.ToString()
        f.ShowDialog()
    End Sub

    Private Sub timer_aviso_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer_aviso.Tick
        pedidos_actuales = contarPedidos()
        Dim pedidos As Integer = 0
        Dim str_pedidos As String = ""

        If (pedidos_actuales > pedidos_login) Then
            pedidos = pedidos_actuales - pedidos_login

            If (pedidos <= 1) Then
                str_pedidos = CStr(pedidos)
                str_pedidos = "Existe: " + str_pedidos + " pedido nuevo"
            Else
                str_pedidos = CStr(pedidos)
                str_pedidos = "Existen: " + str_pedidos + " pedidos nuevos"
            End If
            pedidos_login = pedidos_actuales
            MsgBox(str_pedidos)
        Else
            pedidos_login = pedidos_actuales
        End If


        Dim Sql_tip As String = "SELECT * from VG_POS_PICK where (unidades='VACIO' OR UNIDADES < 5) AND AVISO_PICK='NO' "

        Dim tablatip As DataTable = fnc.ListarTablasSQL(Sql_tip)

        If tablatip.Rows.Count > 0 Then

            Dim CAM As String = tablatip.Rows(0)(1).ToString().Trim()
            Dim BAN As String = tablatip.Rows(0)(2).ToString().Trim()
            Dim COL As String = tablatip.Rows(0)(3).ToString().Trim()
            Dim PIS As String = tablatip.Rows(0)(8).ToString().Trim()
            MsgBox("Camara:" + CAM + "-Banda:" + BAN + "-Columna:" + COL + "-Piso:" + PIS + " llego a su minimo de stock picking")


            Dim sql_Actualiza As String = "UPDATE CamaraMantenedor SET aviso_pick='SI' " & _
                                                "WHERE CAMARA='" + CAM + "' AND BANDA ='" + BAN + "' AND COLUMNA ='" + COL + "' AND PISO = '" + PIS + "' "
            fnc.MovimientoSQL(sql_Actualiza)
        End If




    End Sub


    Private Sub m_116_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_116.Click
        Dim f As New ImprimeEtiqueta
        f.ShowDialog()
    End Sub

    Private Sub m_117_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_117.Click
        Dim f As New Frm_Pos_Sug
        f.ShowDialog()
    End Sub

    Private Sub m_118_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_118.Click
        Dim frm As New Frm_PreparaPicking
        frm.codigo = Convert.ToString(id_global)
        frm.encargado = encargado_global
        frm.ShowDialog()
    End Sub

    Private Sub m_103_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub m_103_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_103.Click
        Dim f As New Frm_auditoria
        f.ShowDialog()
    End Sub

    Private Sub m_666_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_666.Click
        Dim f As New Frm_Repaletiza
        f.ShowDialog()
    End Sub

    Private Sub m_pedidos_locales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_pedidos_locales.Click
        Dim frm As New Frm_Pedidos_Locales
        frm.CodUsu = codigo.ToString.Trim
        frm.ShowDialog()
    End Sub


    Private Sub m_201_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_201.Click
        Cursor.Current = Cursors.WaitCursor
        Dim frm As New Frm_OTTunel
        frm.ShowDialog()
    End Sub
End Class