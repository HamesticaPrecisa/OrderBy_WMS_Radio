Imports System.Runtime.InteropServices
Imports System.IO


Public Class Frm_Traqueo

    Dim fnc As New Funciones
    Dim filaSeleccionada As Integer = -1
    'Dim _LARGOETIQUETA As Integer = 0
    Dim IsTemporal As Boolean = False
    Dim largo1 As Integer = 0
    Dim largo2 As Integer = 0
    Dim largo3 As Integer = 0
    Dim largo4 As Integer = 0
    Dim largo5 As Integer = 0
    Dim primer_pallet = False

    Public codigo_usuario As String = ""

    <DllImport("coredll.dll")> _
    Public Shared Function sndPlaySound(ByVal lpszSoundName As [String], ByVal fuSound As UInteger) As Boolean
    End Function


    Private Sub tpal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tpal.KeyPress
        If e.KeyChar = ChrW(13) Then
            If tpal.Text = "" Then
                Exit Sub
            End If

            If tpal.Text.Length <> 21 Then
                MsgBox("El codigo leido no corresponde a una etiqueta de pallet", MsgBoxStyle.Critical, "Aviso")
                tpal.Text = ""
                tpal.Focus()
                Exit Sub
            End If

            Dim valor_pallet As String = tpal.Text.Remove(0, 11)
            valor_pallet = valor_pallet.Remove(9, 1)


            Dim sql As String = "SELECT cli_nomb, racd_unidades, isnull(drec_codcaja,0) AS drec_codcaja, isnull(rtraq_largo,0) AS rtraq_largo, isnull(rtraq_est,0) AS rtraq_est, " & _
                                "isnull(rtraq_l2,0) AS rtraq_l2, isnull(rtraq_l3,0) AS rtraq_l3, isnull(rtraq_l4,0) AS rtraq_l4, isnull(rtraq_l5,0) AS rtraq_l5 " & _
                                "FROM rackdeta INNER JOIN detarece ON racd_codi=drec_codi " & _
                                "INNER JOIN clientes ON cli_rut=drec_rutcli LEFT JOIN detareceestado ON left(drec_codi,7)=rtraq_codi " & _
                                "WHERE racd_codi='" + valor_pallet + "'"

            Dim TablaCliente As DataTable = fnc.ListarTablasSQL(sql)

            Dim ncliente As String = ""
            Dim unidades As String = ""
            Dim estadocaja As String = ""

            Dim est As String = ""

            ' Si existe el soportante en temporales
            If TablaCliente.Rows.Count = 0 Then

                Dim _TMP As String = "SELECT cli_nomb, drec_unidades, isnull(drec_codcaja,0) AS drec_codcaja, isnull(rtraq_largo,0) AS rtraq_largo, isnull(rtraq_est,0) AS rtraq_est, " & _
                "isnull(rtraq_l2,0) AS rtraq_l2, isnull(rtraq_l3,0) AS rtraq_l3, isnull(rtraq_l4,0) AS rtraq_l4, isnull(rtraq_l5,0) AS rtraq_l5 " & _
                "FROM TMPDETARECE INNER JOIN clientes ON cli_rut=drec_rutcli LEFT JOIN detareceestado ON frec_codi=rtraq_codi  " & _
                "WHERE frec_codi+drec_codi='" + valor_pallet + "'"

                Dim tablaTMP As DataTable = fnc.ListarTablasSQL(_TMP)

                If tablaTMP.Rows.Count = 0 Then
                    MsgBox("El soportante no se encuentra, verifique que la recepción este concluida", MsgBoxStyle.Critical, "Aviso")
                    tpal.Text = ""
                    tpal.Focus()
                    Exit Sub
                Else
                    ncliente = tablaTMP.Rows(0)(0).ToString()
                    unidades = tablaTMP.Rows(0)(1).ToString()
                    estadocaja = tablaTMP.Rows(0)(2).ToString()
                    largo1 = Convert.ToInt32(tablaTMP.Rows(0)(3).ToString())
                    est = tablaTMP.Rows(0)(4).ToString()
                    largo2 = Convert.ToInt32(tablaTMP.Rows(0)(5).ToString())
                    largo3 = Convert.ToInt32(tablaTMP.Rows(0)(6).ToString())
                    largo4 = Convert.ToInt32(tablaTMP.Rows(0)(7).ToString())
                    largo5 = Convert.ToInt32(tablaTMP.Rows(0)(8).ToString())
                    IsTemporal = True
                End If
            Else
                ncliente = TablaCliente.Rows(0)(0).ToString()
                unidades = TablaCliente.Rows(0)(1).ToString()
                estadocaja = TablaCliente.Rows(0)(2).ToString()
                largo1 = Convert.ToInt32(TablaCliente.Rows(0)(3).ToString())
                est = TablaCliente.Rows(0)(4).ToString()
                largo2 = Convert.ToInt32(TablaCliente.Rows(0)(5).ToString())
                largo3 = Convert.ToInt32(TablaCliente.Rows(0)(6).ToString())
                largo4 = Convert.ToInt32(TablaCliente.Rows(0)(7).ToString())
                largo5 = Convert.ToInt32(TablaCliente.Rows(0)(8).ToString())
                IsTemporal = False
            End If


            ' Pregunta si existe el estado del traqueo ( nivel recepción )
            If Convert.ToInt16(est) = 1 Then
                MsgBox("La recepción correspondiente a este pallet ya fue traqueada", MsgBoxStyle.Information, "Aviso")
                tpal.Text = ""
                tpal.Focus()
                Exit Sub
            End If

            Dim _mensaje As String = ""
            If Convert.ToInt32(estadocaja) > 0 Then

                If Convert.ToInt32(estadocaja) = 1 Then
                    _mensaje = "en proceso de traqueo"
                ElseIf Convert.ToInt32(estadocaja) = 2 Then
                    _mensaje = "traqueado"
                End If

                If MsgBox("El soportante se encuentra " + _mensaje + " , quiere volverlo a traquear?", _
                          MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = MsgBoxResult.Yes Then

                    Dim _elimina_leido As String = "DELETE  FROM DetaReceCajas WHERE Caj_Pcod='" + valor_pallet.ToString() + "'"
                    Dim _actualiza_deta As String = "UPDATE detarece SET drec_codcaja='0' WHERE drec_codi='" + valor_pallet.ToString() + "'"

                    If fnc.MovimientoSQL(_elimina_leido) > 0 Then
                        fnc.MovimientoSQL(_actualiza_deta)
                        'Exit Sub
                    End If
                Else
                    tpal.Text = ""
                    tpal.Focus()
                    Exit Sub
                End If
            End If


            '10017800000 000026711 9

            If Convert.ToInt16(largo1) = 0 Then
                Dim f As New Frm_Traqueo_largo
                f.numrece.Text = valor_pallet.Remove(valor_pallet.Length - 2, 2)
                f.ShowDialog()
                primer_pallet = True

                'PREGUNTAR SI GUARDO LARGOS DE LA ETIQUETA
                Dim pregunta As String = "SELECT rtraq_est, rtraq_largo, rtraq_l2, rtraq_l3, rtraq_l4, rtraq_l5 " & _
                "FROM detareceestado WHERE rtraq_codi='" + valor_pallet.Remove(valor_pallet.Length - 2, 2) + "'"

                Dim tabla As DataTable = fnc.ListarTablasSQL(pregunta)
                If tabla.Rows.Count > 0 Then
                    largo1 = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    largo2 = Convert.ToInt32(tabla.Rows(0)(2).ToString())
                    largo3 = Convert.ToInt32(tabla.Rows(0)(3).ToString())
                    largo4 = Convert.ToInt32(tabla.Rows(0)(4).ToString())
                    largo5 = Convert.ToInt32(tabla.Rows(0)(5).ToString())
                Else
                    MsgBox("Ocurrio un error al grabar la información del tamaño de la etiqueta", MsgBoxStyle.Critical, "Aviso")
                    Button1_Click(Nothing, Nothing)
                End If
            End If
 
            Cliente.Text = ncliente
            Leidas.Text = "0"
            Envases.Text = unidades
            '_LARGOETIQUETA = largo1

            'Agrega codigo que identifica que se esta traqueando
            Dim actualizaestado As String = ""

            If IsTemporal = False Then
                actualizaestado = "UPDATE detarece SET drec_codcaja='1' WHERE drec_codi='" + valor_pallet + "'"
            Else
                actualizaestado = "UPDATE TMPdetarece SET drec_codcaja='1' WHERE frec_codi+drec_codi='" + valor_pallet + "'"
            End If

            While (fnc.MovimientoSQL(actualizaestado) = 0)
            End While

            tpal.Text = valor_pallet.ToString()
            tpal.Enabled = False
            Lector.Enabled = True
            Lector.Focus()
        Else
            SoloNumeros(sender, e)
        End If
    End Sub

    Private Sub Lector_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Lector.KeyPress
        Dim caja As String = ""
        Dim ultima As Boolean = False

        If e.KeyChar = ChrW(13) Then
            'selecciona caja

            If Lector.Text.Length > 4 Then
                If Lector.Text.Chars(0).ToString() + Lector.Text.Chars(1).ToString() + Lector.Text.Chars(2).ToString() = "]C1" Then
                    Lector.Text = Lector.Text.Remove(0, 3)
                End If
            End If

            If Lector.Text.Trim.Length = 0 Then
                sndPlaySound("\\TEST.WAV", 0)
                sndPlaySound("\\TEST.WAV", 0)
                Lector.Text = ""
                Panel1.BackColor = Color.Red
                Lector.Focus()
                Exit Sub
            End If

            Dim RespOrdenPallet As String = validOrdenCaja(Lector.Text.Trim)

            If (RespOrdenPallet <> "1" And RespOrdenPallet <> "-1") Then
                MsgBox("Esta caja corresponde al Pallet " & RespOrdenPallet & "", MsgBoxStyle.Information, "Error!")
                Exit Sub
            End If

            caja = Lector.Text.ToUpper

            If Lector.Text.Length = largo1 Or Lector.Text.Length = largo2 Or Lector.Text.Length = largo3 Or Lector.Text.Length = largo4 Or Lector.Text.Length = largo5 Then
                If EstaLaCaja(caja) = True Then
                    Panel1.BackColor = Color.Red
                    Lector.Text = ""
                    Lector.Focus()
                    ultima = False
                Else
                    Panel1.BackColor = Color.Green
                    Lector.Text = ""
                    Lector.Focus()
                    ListBox1.Items.Add(caja)
                    Leidas.Text = ListBox1.Items.Count.ToString()

                    If ListBox1.Items.Count = Convert.ToInt32(Envases.Text) Then
                        MsgBox("Las cajas del pallet ya se encuentran leidas en su totalidad", MsgBoxStyle.Information, "Aviso")
                        ultima = True
                    End If
                End If

                If ultima = True Then
                    'Grabar
                    Dim valores As String = ""
                    Dim query As String = ""

                    For i As Integer = 0 To ListBox1.Items.Count - 1
                        If (i = ListBox1.Items.Count - 1) Then
                            valores &= "('" + tpal.Text.ToUpper + "','" + ListBox1.Items(i).ToString() + "','" + CerosAnteriorString(codigo_usuario, 3) + "')"
                        Else
                            valores &= "('" + tpal.Text.ToUpper + "','" + ListBox1.Items(i).ToString() + "','" + CerosAnteriorString(codigo_usuario, 3) + "'),"
                        End If
                    Next

                    query = "INSERT INTO DetareceCajas (Caj_Pcod, Caj_cod, caj_codenca)VALUES" & _
                    valores
                    Dim intentos As Integer = 0

                    While (fnc.MovimientoSQL(query) = 0 AndAlso intentos < 3)
                        intentos += 1
                    End While

                    If intentos = 3 Then
                        MsgBox("Error al actualizar la información", MsgBoxStyle.Critical, "Aviso")
                        Exit Sub
                    End If

                    MsgBox("Soportante traqueado correctamente", MsgBoxStyle.Information, "Aviso")
                    If IsTemporal = True Then
                        Dim sql As String = "UPDATE TMPDETARECE SET drec_codcaja='2' WHERE frec_codi+drec_codi='" + tpal.Text + "'"
                        While (fnc.MovimientoSQL(sql) = 0)
                        End While
                    Else
                        Dim sql As String = "UPDATE detarece SET drec_codcaja='2' WHERE drec_codi='" + tpal.Text + "'"
                        While (fnc.MovimientoSQL(sql) = 0)
                        End While
                    End If

                    tpal.Text = ""
                    Lector.Enabled = True
                    Leidas.Text = ""
                    Cliente.Text = ""
                    Lector.Enabled = False
                    tpal.Enabled = True
                    For i As Integer = 0 To ListBox1.Items.Count - 1
                        ListBox1.Items.RemoveAt(0)
                    Next
                    Lector.Enabled = False
                    tpal.Focus()
                End If
            Else
                sndPlaySound("\\TEST.WAV", 0)
                sndPlaySound("\\TEST.WAV", 0)
                Lector.Text = ""
                Panel1.BackColor = Color.Red
                Lector.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Function validOrdenCaja(ByVal CodCaj As String) As String
        Dim Resp As String = "-1"

        Try
            Dim CodPal As String = tpal.Text.Trim

            If (CodPal <> "") Then
                Dim sql As String = "select a.Codigo_Caja,Codigo_Pallet_Precisa=isnull(b.drec_codi,'') from Orden_Pallets a with(nolock) left outer join detarece b with(nolock) on(a.Pallet_Cliente=b.drec_sopocli and a.Rut_Cliente=b.drec_rutcli) where a.Codigo_Caja='" & CodCaj & "'"
                Dim dt As New DataTable

                dt = fnc.ListarTablasSQL(sql)

                If (dt.Rows.Count > 0) Then
                    Dim CodPalOk As String = dt.Rows(0).Item(1).ToString.Trim

                    If (CodPalOk = CodPal) Then
                        Resp = "1"
                    Else
                        Resp = CodPalOk
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("", MsgBoxStyle.Critical, "Error!")
        End Try

        Return Resp
    End Function

    Private Sub ListBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ListBox1.KeyPress
        ListBox1_SelectedIndexChanged()
        If e.KeyChar = ChrW(13) AndAlso filaSeleccionada <> -1 Then
            If MsgBox("Desea eliminar la caja seleccionada", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = MsgBoxResult.Yes Then
                ListBox1.Items.RemoveAt(filaSeleccionada)
                filaSeleccionada = -1
            End If
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged()
        filaSeleccionada = Convert.ToInt32(ListBox1.SelectedIndex.ToString())
    End Sub

    Public Function EstaLaCaja(ByVal codigo_caja As String) As Boolean
        EstaLaCaja = False
        If codigo_caja = "0" Or codigo_caja = "1" Or codigo_caja = "2" Or codigo_caja = "" Then
            Return False
            Exit Function
        End If
        For i As Integer = 0 To ListBox1.Items.Count - 1
            If ListBox1.Items(i).ToString() = codigo_caja Then
                EstaLaCaja = True
            End If
        Next
        Return EstaLaCaja
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click

        If tpal.Enabled = False Then

            Dim sql As String = "SELECT cli_nomb, racd_unidades, isnull(drec_codcaja,0) AS drec_codcaja FROM rackdeta INNER JOIN detarece ON racd_codi=drec_codi " & _
                                     "INNER JOIN clientes ON cli_rut=drec_rutcli WHERE racd_codi='" + tpal.Text + "'"

            Dim TablaCliente As DataTable = fnc.ListarTablasSQL(sql)
            If TablaCliente.Rows.Count > 0 Then
                If Convert.ToInt32(TablaCliente.Rows(0)(2).ToString()) = 1 Then
                    sql = "UPDATE detarece SET drec_codcaja='0' WHERE drec_codi='" + tpal.Text + "'"
                    While (fnc.MovimientoSQL(sql) = 0)
                    End While
                End If
            End If
            tpal.Text = ""
            Lector.Enabled = True
            Leidas.Text = ""
            Cliente.Text = ""
            Lector.Enabled = False
            tpal.Enabled = True
            Envases.Text = ""
            largo1 = 0
            largo2 = 0
            largo3 = 0
            largo4 = 0
            largo5 = 0

            For i As Integer = 0 To ListBox1.Items.Count - 1
                ListBox1.Items.RemoveAt(0)
            Next

        End If
        tpal.Focus()
    End Sub

    Private Sub Frm_Traqueo_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If tpal.Enabled = False Then

            Dim sql As String = "SELECT cli_nomb, racd_unidades, isnull(drec_codcaja,0) AS drec_codcaja FROM rackdeta INNER JOIN detarece ON racd_codi=drec_codi " & _
                                    "INNER JOIN clientes ON cli_rut=drec_rutcli WHERE racd_codi='" + tpal.Text + "'"

            Dim TablaCliente As DataTable = fnc.ListarTablasSQL(sql)
            If TablaCliente.Rows.Count > 0 Then
                If Convert.ToInt32(TablaCliente.Rows(0)(2).ToString()) = 1 Then
                    sql = "UPDATE detarece SET drec_codcaja='0' WHERE drec_codi='" + tpal.Text + "'"
                    fnc.MovimientoSQL(sql)
                End If
            End If
        End If
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        Dim f As New Frm_PorTraquear
        f.ShowDialog()
    End Sub

    Private Sub LblCambio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblCambio.Click

        If tpal.Enabled = False Then
            Dim f As New Frm_Traqueo_largo
            f.numrece.Text = tpal.Text.Remove(tpal.Text.Length - 2, 2)
            f.modi = 1
            f.ShowDialog()
            'PREGUNTAR SI GUARDO LARGOS DE LA ETIQUETA
            Dim pregunta As String = "SELECT rtraq_est, rtraq_largo, rtraq_l2, rtraq_l3, rtraq_l4, rtraq_l5 " & _
            "FROM detareceestado WHERE rtraq_codi='" + tpal.Text.Remove(tpal.Text.Length - 2, 2) + "'"

            Dim tabla As DataTable = fnc.ListarTablasSQL(pregunta)
            If tabla.Rows.Count > 0 Then
                largo1 = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                largo2 = Convert.ToInt32(tabla.Rows(0)(2).ToString())
                largo3 = Convert.ToInt32(tabla.Rows(0)(3).ToString())
                largo4 = Convert.ToInt32(tabla.Rows(0)(4).ToString())
                largo5 = Convert.ToInt32(tabla.Rows(0)(5).ToString())
            Else
                MsgBox("Ocurrio un error al grabar la información del tamaño de la etiqueta", MsgBoxStyle.Critical, "Aviso")
                Button1_Click(Nothing, Nothing)
            End If
        End If

    End Sub
End Class