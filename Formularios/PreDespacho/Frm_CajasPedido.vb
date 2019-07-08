Imports System.Runtime.InteropServices
Imports System.IO

Public Class Frm_CajasPedido

    Dim fnc As New Funciones
    Public numero_pallet As String
    Public numero_pedido As Integer
    Public ncajas As Integer = 0

    <DllImport("coredll.dll")> _
Public Shared Function sndPlaySound(ByVal lpszSoundName As [String], ByVal fuSound As UInteger) As Boolean
    End Function

    Private Sub Faltantes()

        For i As Integer = 0 To LstCajas.Items.Count


        Next

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
            End If
        Next
        Return EstaLaCaja
    End Function

    Public Function PisarCaja(ByVal codigo_caja As String) As Boolean
        PisarCaja = False
        For i As Integer = 0 To LstCajas.Items.Count - 1
            If LstCajas.Items(i).ToString() = codigo_caja Then
                LstCajas.Items(i) = "✓" + LstCajas.Items(i).ToString()
                PisarCaja = True
            End If
        Next
        Return PisarCaja
    End Function

    Private Sub txtlectorcaja_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtlectorcaja.KeyPress
        If e.KeyChar = ChrW(13) Then
            'borrar ]C1 en caso de que tenga un codigo extraño
            If txtlectorcaja.Text.Length > 4 Then
                If txtlectorcaja.Text.Chars(0).ToString() + txtlectorcaja.Text.Chars(1).ToString() + txtlectorcaja.Text.Chars(2).ToString() = "]C1" Then
                    txtlectorcaja.Text = txtlectorcaja.Text.Remove(0, 3)
                End If
            End If

            mensaje.Text = ""

            'pregunto si esta la caja y si esta cambio le agrego el ✓

            If EstaLaCaja(txtlectorcaja.Text) = True Then
                PisarCaja(txtlectorcaja.Text)
                color.BackColor = Drawing.Color.Green
                Label2.Text = (Val(Label2.Text) - 1).ToString()
                txtlectorcaja.Text = ""
                txtlectorcaja.Focus()

                ' pregunto si termine de leer las cajas y guardo el detalle
                Dim _valores As String = ""


                If Label2.Text = "0" Then
                    For i As Integer = 0 To LstCajas.Items.Count - 1
                        If (i = LstCajas.Items.Count - 1) Then
                            _valores &= "('" + numero_pallet.ToString() + "','" + LstCajas.Items(i).ToString.Remove(0, 1) + "','" + numero_pedido.ToString() + "')"
                        Else
                            _valores &= "('" + numero_pallet.ToString() + "','" + LstCajas.Items(i).ToString.Remove(0, 1) + "','" + numero_pedido.ToString() + "'),"
                        End If
                    Next
                    Dim SqlDeta As String = "INSERT INTO detapredcajas(dpre_npallet, dpre_caja, dpre_nped)VALUES" & _
                    _valores
                    Console.WriteLine(SqlDeta)
                    ncajas = LstCajas.Items.Count
                    While (fnc.MovimientoSQL(SqlDeta) = 0)
                    End While
                    Me.Close()
                End If

            Else
                ' si la caja no esta primero verifico que este leida antes de mandar el mensaje que "no corresponde"
                If EstaLaCaja("✓" + txtlectorcaja.Text) = True Then
                    mensaje.Text = "La caja ya esta leida"
                    sndPlaySound("\\TEST.WAV", 0)
                    'sndPlaySound("\\TEST.WAV", 0)
                    color.BackColor = Drawing.Color.Red
                    txtlectorcaja.Text = ""
                    Exit Sub
                End If

                mensaje.Text = "La caja leida no corresponde"
                sndPlaySound("\\TEST.WAV", 0)
                'sndPlaySound("\\TEST.WAV", 0)
                color.BackColor = Drawing.Color.Red
                txtlectorcaja.Text = ""
            End If


            'If tabla.Rows.Count = 0 Then
            '    mensaje.Text = "La caja leida no existe"
            '    sndPlaySound("\\TEST.WAV", 0)
            '    sndPlaySound("\\TEST.WAV", 0)
            '    color.BackColor = Drawing.Color.Red
            '    txtlectorcaja.Text = ""
            'Else
            '    If Convert.ToInt32(tabla.Rows(0)(0).ToString()) > 1 Then
            '        mensaje.Text = "La caja leida ya se despacho"
            '        sndPlaySound("\\TEST.WAV", 0)
            '        sndPlaySound("\\TEST.WAV", 0)
            '        color.BackColor = Drawing.Color.Red
            '        txtlectorcaja.Text = ""
            '    Else
            '        Dim i As Integer = 0
            '        For i = 0 To LstCajas.Items.Count - 1
            '            If LstCajas.Items(i).ToString() = txtlectorcaja.Text Then
            '                If LstCajas.Items(i).ToString().Chars(0) = "✓" Then
            '                    mensaje.Text = "La caja ya esta leida"
            '                    sndPlaySound("\\TEST.WAV", 0)
            '                    sndPlaySound("\\TEST.WAV", 0)
            '                    color.BackColor = Drawing.Color.Red
            '                    txtlectorcaja.Text = ""
            '                    Exit Sub
            '                Else
            '                    LstCajas.Items(i) = "✓" + LstCajas.Items(i).ToString()
            '                    'Guarda DetaPredCajas

            '                    Dim SqlDeta As String = "INSERT INTO detapredcajas(dpre_npallet, dpre_caja, dpre_nped)VALUES('" + numero_pallet.ToString() + "','" + txtlectorcaja.Text + "','" + numero_pedido.ToString() + "')"
            '                    If (fnc.MovimientoSQL(SqlDeta) > 0) Then
            '                        color.BackColor = Drawing.Color.Green
            '                    Else
            '                        sndPlaySound("\\TEST.WAV", 0)
            '                        'sndPlaySound("\\TEST.WAV", 0)
            '                        color.BackColor = Drawing.Color.Red
            '                        mensaje.Text = "Error al actualizar, intente denuevo"
            '                    End If

            '                    txtlectorcaja.Text = ""
            '                    Label2.Text = (Val(Label2.Text) - 1).ToString()


            '                    If Label2.Text = "0" Then
            '                        ncajas = LstCajas.Items.Count
            '                        Me.Close()
            '                        Exit For
            '                    End If
            '                    Exit For
            '                End If
            '            End If
            '        Next
            '    End If
            'End If
        End If
    End Sub

    Private Sub Frm_CajasPedido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT dpc_codcaja AS caja, dpc_codcaja as caj FROM detapedcaja WHERE dpc_numpal='" + numero_pallet.ToString() + "' " & _
                            "AND dpc_codped='" + numero_pedido.ToString() + "'"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        If tabla.Rows.Count = 0 Then
            Me.Close()
        End If

        For i As Integer = 0 To tabla.Rows.Count - 1
            LstCajas.Items.Add(tabla.Rows(i)(0).ToString())
        Next

        Label2.Text = LstCajas.Items.Count.ToString()
    End Sub

End Class