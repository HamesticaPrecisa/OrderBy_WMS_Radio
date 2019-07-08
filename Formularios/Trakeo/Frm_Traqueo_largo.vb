Imports System.Data.SqlClient

Public Class Frm_Traqueo_largo


    Dim arreglo_etiq(5) As String

    Dim cancelar As Boolean = False
    Dim fnc As New Funciones
    Public modi As Integer = 0


    Private Sub lector_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lector.KeyPress
        If e.KeyChar = ChrW(13) Then

            If lector.Text.Length > 4 Then
                If lector.Text.Chars(0).ToString() + lector.Text.Chars(1).ToString() + lector.Text.Chars(2).ToString() = "]C1" Then
                    lector.Text = lector.Text.Remove(0, 3)
                End If
            End If

            lector.Text = lector.Text.ToUpper
            Dim esta As Boolean = False
            For i As Integer = 0 To arreglo_etiq.Length - 1
                If lector.Text = arreglo_etiq(i) Then
                    lector.Text = ""
                    lector.Focus()
                    esta = True
                    Exit For
                End If
            Next

            If esta = True Then
                Exit Sub
            End If

            If arreglo_etiq(0).Length = 0 Then
                arreglo_etiq(0) = lector.Text
            ElseIf arreglo_etiq(1).Length = 0 Then
                arreglo_etiq(1) = lector.Text
            ElseIf arreglo_etiq(2).Length = 0 Then
                arreglo_etiq(2) = lector.Text
            ElseIf arreglo_etiq(3).Length = 0 Then
                arreglo_etiq(3) = lector.Text
            ElseIf arreglo_etiq(4).Length = 0 Then
                arreglo_etiq(4) = lector.Text
            Else
                MsgBox("No puede leer mas de 5 etiquetas", MsgBoxStyle.Critical, "Aviso")
            End If
            bucle()
        End If
    End Sub

    Private Sub Frm_Traqueo_largo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If modi = 1 Then
            Dim sql As String = "SELECT isnull(rtraq_largo,0) AS rtraq_largo, isnull(rtraq_l2,0) AS rtraq_l2, " & _
                                "isnull(rtraq_l3,0) AS rtraq_l3, isnull(rtraq_l4,0) AS rtraq_l4, isnull(rtraq_l5,0) AS rtraq_l5 " & _
                                "FROM  detareceestado WHERE rtraq_codi='" + numrece.Text + "'"

            Dim TablaCliente As DataTable = fnc.ListarTablasSQL(sql)

            If TablaCliente.Rows.Count > 0 Then
                cancelar = True
                If Convert.ToInt32(TablaCliente.Rows(0)(0).ToString()) > 0 Then
                    l1.Text = Largo(TablaCliente.Rows(0)(0).ToString())
                    b1.Text = TablaCliente.Rows(0)(0).ToString()
                    b1.Enabled = False
                    arreglo_etiq(0) = Largo(TablaCliente.Rows(0)(0).ToString())
                End If

                If Convert.ToInt32(TablaCliente.Rows(0)(1).ToString()) > 0 Then
                    l2.Text = Largo(TablaCliente.Rows(0)(1).ToString())
                    b2.Text = TablaCliente.Rows(0)(1).ToString()
                    l2.Visible = True
                    b2.Visible = True
                    b2.Enabled = False
                    arreglo_etiq(1) = Largo(TablaCliente.Rows(0)(1).ToString())
                End If

                If Convert.ToInt32(TablaCliente.Rows(0)(2).ToString()) > 0 Then
                    l3.Text = Largo(TablaCliente.Rows(0)(2).ToString())
                    b3.Text = TablaCliente.Rows(0)(2).ToString()
                    l3.Visible = True
                    b3.Visible = True
                    b3.Enabled = False
                    arreglo_etiq(2) = Largo(TablaCliente.Rows(0)(2).ToString())
                End If

                If Convert.ToInt32(TablaCliente.Rows(0)(3).ToString()) > 0 Then
                    l4.Text = Largo(TablaCliente.Rows(0)(3).ToString())
                    b4.Text = TablaCliente.Rows(0)(3).ToString()
                    l4.Visible = True
                    b4.Visible = True
                    b4.Enabled = False
                    arreglo_etiq(3) = Largo(TablaCliente.Rows(0)(3).ToString())
                End If

                If Convert.ToInt32(TablaCliente.Rows(0)(4).ToString()) > 0 Then
                    l5.Text = Largo(TablaCliente.Rows(0)(4).ToString())
                    b5.Text = TablaCliente.Rows(0)(4).ToString()
                    l5.Visible = True
                    b5.Visible = True
                    b5.Enabled = False
                    arreglo_etiq(4) = Largo(TablaCliente.Rows(0)(4).ToString())
                End If

            End If
        End If


        For i As Integer = 0 To arreglo_etiq.Length - 1
            If arreglo_etiq(i) Is Nothing Then
                arreglo_etiq(i) = ""
            End If
        Next


    End Sub

    Function Largo(ByVal cod As String) As String
        Dim l As String
        For i As Integer = 0 To Convert.ToInt32(cod) - 1
            l = l + "*"
        Next
        Return l
    End Function



    Sub bucle()

        Dim aux As String = ""

        '3  0  3  5  0
        For i As Integer = 1 To arreglo_etiq.Length - 2
            Console.WriteLine(arreglo_etiq(i).Length)
            If arreglo_etiq(i).Length = 0 Then
                'For j As Integer = 0 To arreglo_etiq.Length - 2
                aux = arreglo_etiq(i)
                arreglo_etiq(i) = arreglo_etiq(i + 1)
                arreglo_etiq(i + 1) = aux.ToString()
                'Next
            End If
        Next

        l2.Visible = False
        b2.Visible = False
        l3.Visible = False
        b3.Visible = False
        l4.Visible = False
        b4.Visible = False
        l5.Visible = False
        b5.Visible = False

        If arreglo_etiq(0).Length > 0 Then
            l1.Text = arreglo_etiq(0)
            b1.Text = arreglo_etiq(0).Length.ToString()
            l1.Visible = True
            b1.Visible = True
        Else
            l1.Text = ""
            b1.Text = "0"
        End If

        If arreglo_etiq(1).Length > 0 Then
            l2.Text = arreglo_etiq(1)
            b2.Text = arreglo_etiq(1).Length.ToString()
            l2.Visible = True
            b2.Visible = True
        Else
            l2.Text = ""
            b2.Text = "0"
        End If

        If arreglo_etiq(2).Length > 0 Then
            l3.Text = arreglo_etiq(2)
            b3.Text = arreglo_etiq(2).Length.ToString()
            l3.Visible = True
            b3.Visible = True
        Else
            l3.Text = ""
            b3.Text = "0"
        End If

        If arreglo_etiq(3).Length > 0 Then
            l4.Text = arreglo_etiq(3)
            b4.Text = arreglo_etiq(3).Length.ToString()
            l4.Visible = True
            b4.Visible = True
        Else
            l4.Text = ""
            b4.Text = "0"
        End If

        If arreglo_etiq(4).Length > 0 Then
            l5.Text = arreglo_etiq(4)
            b5.Text = arreglo_etiq(4).Length.ToString()
            l5.Visible = True
            b5.Visible = True
        Else
            l5.Text = ""
            b5.Text = "0"
        End If
        lector.Text = ""
        lector.Focus()

    End Sub

    Private Sub b1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b1.Click
        arreglo_etiq(0) = ""
        bucle()
    End Sub

    Private Sub b2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b2.Click
        arreglo_etiq(1) = ""
        bucle()
    End Sub

    Private Sub b3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b3.Click
        arreglo_etiq(2) = ""
        bucle()
    End Sub

    Private Sub b4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b4.Click
        arreglo_etiq(3) = ""
        bucle()
    End Sub

    Private Sub b5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b5.Click
        arreglo_etiq(4) = ""
        bucle()
    End Sub

    Private Sub Actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Actualizar.Click

        If b1.Text = "0" Then
            MsgBox("Debe ingresar minimo 1 etiqueta de muestra", 16, "Aviso")
            Exit Sub
        End If

        Dim con As New Conexion
        Try
            con.conectarSQL()
            Dim _cmd As SqlCommand = New SqlCommand("PAG_LARGOETIQ", con.conSQL)
            _cmd.CommandType = CommandType.StoredProcedure
            _cmd.Parameters.AddWithValue("@recepcion", numrece.Text)
            _cmd.Parameters.AddWithValue("@estado", 0)
            _cmd.Parameters.AddWithValue("@largo1", b1.Text)
            _cmd.Parameters.AddWithValue("@largo2", b2.Text)
            _cmd.Parameters.AddWithValue("@largo3", b3.Text)
            _cmd.Parameters.AddWithValue("@largo4", b4.Text)
            _cmd.Parameters.AddWithValue("@largo5", b5.Text)
            Dim resp As Integer = 0
            Try
                resp = Convert.ToInt32(_cmd.ExecuteScalar())
            Catch ex As Exception
                resp = 1
            End Try

            If resp = 0 Then
                MsgBox("Grabación exitosa", MsgBoxStyle.Information, "Aviso")
                cancelar = True
                Me.Close()
            Else
                MsgBox("Error inesperado al grabar la información", MsgBoxStyle.Critical, "Aviso")
            End If
            con.cerrarSQL()
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try

    End Sub

    Private Sub Frm_Traqueo_largo_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If cancelar = False Then
            e.Cancel = True
        End If
    End Sub
End Class