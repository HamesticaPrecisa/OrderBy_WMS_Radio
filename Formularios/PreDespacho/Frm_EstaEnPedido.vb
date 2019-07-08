Imports System.Runtime.InteropServices
Imports System.Data
Imports System
Imports System.Windows.Forms
Imports System.IO
Imports System.Reflection
Imports System.Threading

Public Class Frm_EstaEnPedido

    Dim fnc As New Funciones

    Public codusuario As String = ""

    <DllImport("coredll.dll")> _
Public Shared Function sndPlaySound(ByVal lpszSoundName As [String], ByVal fuSound As UInteger) As Boolean

    End Function
    Private Sub nped_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles nped.KeyPress

        If e.KeyChar = ChrW(13) AndAlso nped.Text.Trim <> "" Then


            Dim sql As String = "SELECT * FROM pedidos_ficha WHERE Orden='" + nped.Text + "'"
            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then
                Dim sqlDetalle As String = "SELECT dpc_codcaja, dpc_codcaja AS cod FROM detapedcaja WHERE dpc_codped='" + nped.Text + "'"
                Dim tablad As DataTable = fnc.ListarTablasSQL(sqlDetalle)

                If tablad.Rows.Count > 0 Then
                    For i As Integer = 0 To tablad.Rows.Count - 1
                        LstCajas.Items.Add(tablad.Rows(i)(0).ToString())
                    Next
                End If

                nped.Enabled = False
                txtlectorcaja.Focus()
            Else
                MsgBox("El código ingresado no existe", MsgBoxStyle.Critical, "Aviso")
                nped.Text = ""
                nped.Focus()
            End If
            'ActualizaInfoReal()
            Actualizacjs.Enabled = True
        Else
            SoloNumeros(sender, e)
        End If

    End Sub

    Private Sub Lector_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtlectorcaja.KeyPress
        If e.KeyChar = ChrW(13) Then

            If txtlectorcaja.Text.Length > 4 Then
                If txtlectorcaja.Text.Chars(0).ToString() + txtlectorcaja.Text.Chars(1).ToString() + txtlectorcaja.Text.Chars(2).ToString() = "]C1" Then
                    txtlectorcaja.Text = txtlectorcaja.Text.Remove(0, 3)

                    Dim sql As String
                    sql = "SELECT dpc_codped FROM detapedcaja WHERE dpc_codcaja='" + txtlectorcaja.Text + "' AND dpc_codped!='" + nped.Text + "'"
                    Dim dt As DataTable = fnc.ListarTablasSQL(sql)
                    If dt.Rows.Count > 0 Then
                        MsgBox("La caja corresponde a otro pedido (" + dt.Rows(0)(0).ToString + ")", MsgBoxStyle.Information, "cantidad de cajas")
                    End If

                End If
            Else
                txtlectorcaja.Text = ""
                txtlectorcaja.Focus()
                Return
            End If


            If txtlectorcaja.BackColor = Drawing.Color.Red Then
                txtlectorcaja.BackColor = Drawing.Color.White
                txtlectorcaja.ForeColor = Drawing.Color.Black

                Dim _codigopallet As String = ""

                If txtlectorcaja.Text.Length = 20 Then
                    _codigopallet = CodigoPallet("0" + txtlectorcaja.Text)
                Else
                    _codigopallet = CerosAnteriorString(txtlectorcaja.Text, 9)
                End If


                Dim sql As String = "SELECT COUNT(DISTINCT SCAJ_CODCAJA)  FROM TMP_SELECCIONCAJAS WHERE scaj_codcaja in(SELECT dpc_codcaja FROM detapedcaja WHERE dpc_numpal='" + _codigopallet + "' AND dpc_codped='" + nped.Text + "')" & _
                                    "UNION ALL " & _
                                    "SELECT COUNT(*)  FROM detapedcaja WHERE dpc_numpal='" + _codigopallet + "' AND dpc_codped='" + nped.Text + "' "

                Dim dt As DataTable = fnc.ListarTablasSQL(sql)

                If dt.Rows.Count > 0 Then
                    MsgBox("Tiene " + dt.Rows(0)(0).ToString() + "/" + dt.Rows(1)(0).ToString() + " cajas leidas", MsgBoxStyle.Information, "cantidad de cajas")
                Else
                    MsgBox("El soportante ingresado no corresponde al pedido", MsgBoxStyle.Critical, "Aviso")
                End If
                txtlectorcaja.Text = ""
                txtlectorcaja.Focus()
                Exit Sub
            End If

            If EstaLaCaja(txtlectorcaja.Text) = True Then
                PisarCaja(txtlectorcaja.Text)
                Color.BackColor = Drawing.Color.Green
                lblcantidad.Text = (Val(lblcantidad.Text) + 1).ToString()

                'Pregunto si termine de leer las cajas y guardo el detalle
                mensaje.Text = "Corresponde al pedido " + txtlectorcaja.Text

                Dim _valores As String = ""
                txtlectorcaja.Text = ""
                txtlectorcaja.Focus()

            ElseIf EstaLaCajaHistorial(txtlectorcaja.Text) = True Then
                Color.BackColor = Drawing.Color.Orange
                mensaje.Text = "Corresponde al pedido " + txtlectorcaja.Text
                txtlectorcaja.Text = ""
            Else

                If txtlectorcaja.Text.Length > 6 Then

                    mensaje.Text = "La caja leida NO corresponde " + txtlectorcaja.Text.Remove(0, txtlectorcaja.Text.Length - 5)
                    Dim str As String = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase)
                    'sndPlaySound(str + "\" + "sound.WAV", 0)

                    sndPlaySound("\\TEST.WAV", 0)
                    sndPlaySound("\\TEST.WAV", 0)
                    sndPlaySound("\\TEST.WAV", 0)
                    sndPlaySound("\\TEST.WAV", 0)
                    sndPlaySound("\\TEST.WAV", 0)
                    sndPlaySound("\\TEST.WAV", 0)
                    sndPlaySound("\\TEST.WAV", 0)
                    sndPlaySound("\\TEST.WAV", 0)
                    sndPlaySound("\\TEST.WAV", 0)

                    Color.BackColor = Drawing.Color.Red
                    txtlectorcaja.Text = ""

                End If
                End If
        End If

    End Sub

    Public Function EstaLaCaja(ByVal codigo_caja As String) As Boolean
        EstaLaCaja = False
        If codigo_caja = "0" Or codigo_caja = "1" Or codigo_caja = "2" Or codigo_caja = "" Then
            Return False
            Exit Function
        End If
        For i As Integer = 0 To LstCajas.Items.Count - 1
            If LstCajas.Items(i).ToString() = codigo_caja Then
                EstaLaCaja = True
                LstLeidos.Items.Add(codigo_caja)
                LstCajasHistorial.Items.Add(codigo_caja)
                LstCajas.Items.RemoveAt(i)
                Exit For
            End If
        Next
        Return EstaLaCaja
    End Function

    Public Function EstaLaCajaHistorial(ByVal codigo_caja As String) As Boolean
        EstaLaCajaHistorial = False
        'If codigo_caja = "0" Or codigo_caja = "1" Or codigo_caja = "2" Or codigo_caja = "" Then
        '    Return False
        '    Exit Function
        'End If
        For i As Integer = 0 To LstCajasHistorial.Items.Count - 1
            If LstCajasHistorial.Items(i).ToString() = codigo_caja Then
                EstaLaCajaHistorial = True
                Exit For
            End If
        Next
        Return EstaLaCajaHistorial
    End Function

    Public Function PisarCaja(ByVal codigo_caja As String) As Boolean
        PisarCaja = False
        For i As Integer = 0 To LstCajas.Items.Count - 1
            If LstCajas.Items(i).ToString() = codigo_caja Then
                LstCajas.Items.RemoveAt(i) ' = "✓" + LstCajas.Items(i).ToString()
                LstCajasHistorial.Items.Add(codigo_caja)
                PisarCaja = True
                Exit For
            End If
        Next
        Return PisarCaja
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        lblcantidad.Text = "0"
    End Sub

    Private Sub Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Limpiar.Click
        Actualizacjs.Enabled = False

        While (LstCajas.Items.Count > 0)
            LstCajas.Items.RemoveAt(0)
        End While

        While (LstCajasHistorial.Items.Count > 0)
            LstCajasHistorial.Items.RemoveAt(0)
        End While

        While (LstLeidos.Items.Count > 0)
            LstLeidos.Items.RemoveAt(0)
        End While

        lblcantidad.Text = ""
        nped.Text = ""
        nped.Enabled = True
        nped.Focus()


    End Sub

    Private Sub Actualizacjs_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Actualizacjs.Tick

        'CheckForIllegalCrossThreadCalls = False
        If nped.Enabled = True Then
            Return
        End If
        ActualizaInfoReal()

    End Sub

    Private Sub Frm_EstaEnPedido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Actualizacjs.Enabled = True
    End Sub

    Private Sub Frm_EstaEnPedido_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Actualizacjs.Enabled = False
    End Sub

    Sub ActualizaInfoReal()

        Dim qry As String = "INSERT INTO TMP_SELECCIONCAJAS(scaj_codcaja, scaj_codped, scaj_fecha, scaj_enca)VALUES"
        If LstLeidos.Items.Count > 0 Then
            'Actualiza leidas
            For i As Integer = 0 To LstLeidos.Items.Count - 1
                qry += "('" + LstLeidos.Items(i).ToString() + "','" + nped.Text + "',GETDATE(),'" + CerosAnteriorString(codusuario, 3) + "'),"
            Next

            qry = qry.Remove(qry.Length - 1, 1)

            If fnc.MovimientoSQL(qry) > 0 Then
                For i As Integer = 0 To LstLeidos.Items.Count - 1
                    LstLeidos.Items.RemoveAt(0)
                Next
            End If
        End If

        'Limpia(Historial)
        While (LstCajasHistorial.Items.Count > 0)
            LstCajasHistorial.Items.RemoveAt(0)
        End While

        'Limpia(total)
        While (LstCajas.Items.Count > 0)
            LstCajas.Items.RemoveAt(0)
        End While

        Dim dt_inicio As DateTime = Date.Now()
       


        'Llena Listado Total            REVISAR ESTA QRY DEMORA DE 08 A 12 SEGUNDOS
        Dim _faltante As String = "SELECT DISTINCT dpc_codcaja FROM detapedcaja " & _
                                    "WHERE dpc_codped='" + nped.Text + "' AND dpc_codcaja not in" & _
                                    "(SELECT DISTINCT scaj_codcaja FROM TMP_SELECCIONCAJAS WHERE scaj_codped='" + nped.Text + "')"

        Dim _dtbl As DataTable = fnc.ListarTablasSQL(_faltante)

        For i As Integer = 0 To _dtbl.Rows.Count - 1
            LstCajas.Items.Add(_dtbl.Rows(i)(0).ToString())
        Next


        'LlenaHistorial
        Dim _hist As String = "SELECT DISTINCT scaj_codcaja FROM TMP_SELECCIONCAJAS WHERE scaj_codped='" + nped.Text + "'"
        _dtbl = fnc.ListarTablasSQL(_hist)


        For i As Integer = 0 To _dtbl.Rows.Count - 1
            LstCajasHistorial.Items.Add(_dtbl.Rows(i)(0).ToString())
        Next

        'Dim dt_termino As DateTime = Date.Now()

        'MsgBox(dt_inicio.ToString() + "   |   " + dt_termino.ToString())

        'Cantidad de cajas
        Dim total As Integer = LstCajasHistorial.Items.Count + LstCajas.Items.Count
        lblcanttotal.Text = LstCajasHistorial.Items.Count.ToString() + "/" + total.ToString()


    End Sub


    Private Sub VerEstado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerEstado.Click

        If txtlectorcaja.BackColor = Drawing.Color.White Then
            txtlectorcaja.BackColor = Drawing.Color.Red
            txtlectorcaja.ForeColor = Drawing.Color.White
        Else
            txtlectorcaja.BackColor = Drawing.Color.White
            txtlectorcaja.ForeColor = Drawing.Color.Black
        End If
        txtlectorcaja.Focus()
    End Sub

End Class