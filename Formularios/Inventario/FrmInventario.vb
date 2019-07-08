Imports System.Data.SqlClient

Public Class FrmInventario

    Dim fnc As New Funciones
    Public codigo As String = ""
    Dim TIPO_INGRESO As String = ""
    Dim con As New Conexion

    Public Function TransformaPallet(ByVal pallet As String) As String

        Dim separado As String = ""
        For i As Integer = 11 To pallet.Length - 2
            separado = separado + pallet.Chars(i)
        Next
        Txtpallet.Text = separado

        Return separado
    End Function

    Private Sub Txtpallet_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtpallet.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            If Txtpallet.Text = "" Then
                Exit Sub
            End If

            If Txtpallet.Text.Length < 21 Then
                Txtpallet.Text = CerosAnteriorString(Txtpallet.Text + "0", 21)
                TIPO_INGRESO = "MANUAL"
            ElseIf Txtpallet.Text.Length > 21 Then
                Txtpallet.Text = ""
                Exit Sub
            Else
                TIPO_INGRESO = "LECTURA"
            End If

            Dim sql As String = "SELECT racd_ca, racd_Ba, racd_Co, racd_Pi, racd_Ni, isnull(drec_codcaja,0) as drec_codcaja, " & _
                                "CASE  WHEN isnull(ESTADO,0)='0' THEN '0' ELSE '1' END AS EST, drec_rev , mae_descr, " & _
                                "racd_unidades, cli_nomb, isnull(VALPRODUCTO,-1) AS VALPRODUCTO, isnull(VALCLIENTE,-1) AS VALCLIENTE, " & _
                                "isnull(VALCANTIDAD,-1) AS VALCANTIDAD, drec_sopocli " & _
                                "FROM rackdeta LEFT JOIN AINVENTARIO ON PALLET=racd_codi INNER JOIN maeprod ON mae_codi=racd_codpro  " & _
                                "INNER JOIN detarece ON drec_codi=racd_codi  INNER JOIN clientes ON cli_rut=drec_rutcli  " & _
                                "WHERE racd_codi='" + TransformaPallet(Txtpallet.Text) + "'"

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
            Dim EST As String = ""

            If tabla.Rows.Count > 0 Then

                main.Enabled = True
                Txtpallet.Enabled = False

                tca.Text = tabla.Rows(0)(0).ToString()
                tba.Text = tabla.Rows(0)(1).ToString()
                tco.Text = tabla.Rows(0)(2).ToString()
                tpi.Text = tabla.Rows(0)(3).ToString()
                tni.Text = tabla.Rows(0)(4).ToString()

                If tabla.Rows(0)(5).ToString() = "2" Then
                    traq.Text = "SI"
                    traq.BackColor = Color.Green
                Else
                    traq.Text = "NO"
                    traq.BackColor = Color.Red
                End If


                If tabla.Rows(0)(6).ToString() = "1" Then
                    lblestado.Text = "INVENTARIADO"
                Else
                    lblestado.Text = "NO INVENTARIADO"
                End If


                If tabla.Rows(0)(7).ToString() = "1" Then
                    rev.Text = "SI"
                    rev.BackColor = Color.Green
                Else
                    rev.Text = "NO"
                    rev.BackColor = Color.Red
                End If

                lblprod.Text = tabla.Rows(0)(8).ToString()
                lblcant.Text = tabla.Rows(0)(9).ToString()
                lblcliente.Text = tabla.Rows(0)(10).ToString()


                If tabla.Rows(0)(11).ToString() = "-1" Then
                    cli_sin.Checked = True
                ElseIf tabla.Rows(0)(11).ToString() = "1" Then
                    cli_si.Checked = True
                Else
                    cli_no.Checked = True
                End If

                If tabla.Rows(0)(12).ToString() = "-1" Then
                    pro_sin.Checked = True
                ElseIf tabla.Rows(0)(12).ToString() = "1" Then
                    pro_si.Checked = True
                Else
                    pro_no.Checked = True
                End If


                If tabla.Rows(0)(13).ToString() = "-1" Then
                    cant_sin.Checked = True
                ElseIf tabla.Rows(0)(13).ToString() = "1" Then
                    cant_si.Checked = True
                Else
                    cant_no.Checked = True
                End If

                lblncli.Text = tabla.Rows(0)(14).ToString()


                ULTIMO.Text = Txtpallet.Text
                lblleidos.Text = (Val(lblleidos.Text) + 1).ToString()

            Else
                MsgBox("El pallet leido no existe", MsgBoxStyle.Critical, "Aviso")
                Txtpallet.Text = ""
                Txtpallet.Enabled = True
                Txtpallet.Focus()
            End If

        Else
            fnc.SoloNumeros(sender, e)
        End If
        Txtpallet.Focus()
    End Sub

    Private Sub btnlimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlimpiar.Click
        lblleidos.Text = "0"
        If Txtpallet.Enabled = True Then
            Txtpallet.Focus()
        End If
    End Sub

    Private Sub cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelar.Click
        Txtpallet.Text = ""
        Txtpallet.Enabled = True
        Txtpallet.Focus()
        main.Enabled = True
        tca.Text = ""
        tba.Text = ""
        tco.Text = ""
        tpi.Text = ""
        tni.Text = ""

        lblestado.Text = ""
        traq.Text = ""
        rev.Text = ""

        lblcliente.Text = ""
        lblprod.Text = ""
        lblcant.Text = ""

        cli_sin.Checked = True
        pro_sin.Checked = True
        cant_sin.Checked = True
        lblncli.Text = ""
        rev.BackColor = Color.White
        traq.BackColor = Color.White

    End Sub
 
    Private Function Seleccion(ByVal op As Integer) As Integer
        Dim retorno As Integer = -1

        If op = 1 Then
            If cli_si.Checked = True Then
                retorno = 1
            ElseIf cli_no.Checked = True Then
                retorno = 0
            End If
        ElseIf op = 2 Then
            If pro_si.Checked = True Then
                retorno = 1
            ElseIf pro_no.Checked = True Then
                retorno = 0
            End If
        ElseIf op = 3 Then
            If cant_si.Checked = True Then
                retorno = 1
            ElseIf cant_no.Checked = True Then
                retorno = 0
            End If
        End If

        Return retorno
    End Function

    Private Sub FrmInventario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con.cerrarSQL()
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click

        If Txtpallet.Enabled = True Then
            Txtpallet.Focus()
        End If

        If cli_sin.Checked = True Then
            MsgBox("Debe seleccionar el cliente", MsgBoxStyle.Critical, "Aviso")
            Return
        End If

        If rev.Text = "NO" AndAlso cant_sin.Checked = True Then
            MsgBox("Debe revisar la cantidad de cajas", MsgBoxStyle.Critical, "Aviso")
            Return
        End If

        Try
            con.conectarSQL()

            Dim _cmd As SqlCommand = New SqlCommand("PAG_INVENTARIO", con.conSQL)
            _cmd.CommandType = CommandType.StoredProcedure
            _cmd.Parameters.AddWithValue("@pallet", Txtpallet.Text)
            _cmd.Parameters.AddWithValue("@usuario", CerosAnteriorString(codigo, 3))
            _cmd.Parameters.AddWithValue("@tipolect", TIPO_INGRESO)
            _cmd.Parameters.AddWithValue("@valpro", Seleccion(2))
            _cmd.Parameters.AddWithValue("@valcli", Seleccion(1))
            _cmd.Parameters.AddWithValue("@valcan", Seleccion(3))
            _cmd.Parameters.AddWithValue("@camara", tca.Text)
            _cmd.Parameters.AddWithValue("@codpro", lblncli.Text)

            Dim resp As Integer = 0

            Try
                resp = Convert.ToInt32(_cmd.ExecuteScalar())
            Catch ex As Exception
                resp = 1
            End Try

            If resp = 0 Then
                cancelar_Click(Nothing, Nothing)
            Else
                MsgBox("Error al guardar cambios", MsgBoxStyle.Critical, "Aviso")
            End If

            con.cerrarSQL()

        Catch ex As Exception
            MsgBox(ex.Message())
        End Try

    End Sub
End Class