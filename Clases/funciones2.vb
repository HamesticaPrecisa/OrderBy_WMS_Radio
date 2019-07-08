Imports System.Data.SqlClient
Imports System.Data

Public Class funciones2

    Dim con As New Conexion2

    Public Function ListarTablasSQL(ByVal Consulta_sql As String) As DataTable
        Dim tabla As DataTable = New DataTable
        Try
            con.conectarSQL()
            Dim Listado As SqlDataAdapter = New SqlDataAdapter(Consulta_sql, con.conSQL)
            Listado.Fill(tabla)
            con.cerrarSQL()
        Catch ex As Exception
            '  MsgBox(ex.ToString())
        End Try
        Return tabla
    End Function

    Public Function MovimientoSQL(ByVal Consulta_sql As String) As Integer
        Dim retorno As Integer = 0
        Try
            con.conectarSQL()
            Dim _cmd As SqlCommand = New SqlCommand(Consulta_sql, con.conSQL)
            _cmd.ExecuteNonQuery()
            retorno = 1
            con.cerrarSQL()
        Catch ex As Exception
            retorno = 0
            MsgBox(ex.ToString())
        End Try
        Return retorno
    End Function

    Public Function UltimoRegistro(ByVal Consulta_sql As String) As Integer
        Dim _tabla As DataTable = New DataTable
        Dim _ultimoRegistro As Integer = 0
        Try

            con.conectarSQL()

            Dim _cmd As SqlDataAdapter = New SqlDataAdapter(Consulta_sql, con.conSQL)
            _cmd.Fill(_tabla)

            If _tabla.Rows.Count = 0 Then
                _ultimoRegistro = 1
            Else
                _ultimoRegistro = Convert.ToInt32(Convert.ToInt32(_tabla.Rows(_tabla.Rows.Count - 1)(0)) + 1)
            End If
            con.cerrarSQL()


        Catch ex As Exception
            ' MsgBox(ex.ToString())
        End Try

        Return _ultimoRegistro
    End Function

    Public Function ValorMaximo(ByVal Tabla As String, ByVal Campo As String, ByVal ValorSumar As Integer) As String

        Dim _tabla As DataTable = New DataTable
        Dim _valorMaximo As Integer = 0

        Try
            con.conectarSQL()

            Dim _cmd As SqlDataAdapter = New SqlDataAdapter("SELECT Max(" + Campo + ") FROM " + Tabla, con.conSQL)
            _cmd.Fill(_tabla)

            If _tabla.Rows.Count > 0 Then
                _valorMaximo = Convert.ToInt32(_tabla.Rows(0)(0))
            Else
                _valorMaximo = 0
            End If
            con.cerrarSQL()


        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try

        Return (Convert.ToInt32(_valorMaximo) + Convert.ToInt32(ValorSumar))
    End Function




    '----------------- OTROS----------------------------->


    Public Sub SoloNumeros(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Function CODIFICA(ByVal PASS As String) As String
        Dim LETRAS As String
        LETRAS = "JJABRE"
        Dim largo As Integer = Len(PASS)
        Dim LARGO2 As Integer = Len(LETRAS)
        CODIFICA = ""
        Dim y As Integer = 1
        For X As Integer = 1 To largo
            Dim P1 = Asc(Mid(PASS, X, 1))
            Dim P2 = Asc(Mid(LETRAS, y, 1))
            Dim fin = Chr(P1 + P2)

            CODIFICA = CODIFICA & fin
            y = y + 1
            If y = LARGO2 Then y = 1
        Next X
        'CODIFICA = "•«®«"
    End Function

    Function DECODIFICA(ByVal PASS As String) As String
        Dim LETRAS As String
        LETRAS = "JJABRE"
        Dim largo As Integer = Len(PASS)
        Dim LARGO2 As Integer = Len(LETRAS)
        DECODIFICA = ""
        Dim y As Integer = 1
        For X As Integer = 1 To largo
            Dim P1 = Asc(Mid(PASS, X, 1))
            Dim P2 = Asc(Mid(LETRAS, y, 1))
            DECODIFICA = DECODIFICA & Chr(P1 - P2)
            y = y + 1
            If y = LARGO2 Then y = 1
        Next X
    End Function

    Public Function devuelve_fecha(ByVal fecha As DateTime) As String
        Dim a, m, d As String

        d = fecha.Day
        If Val(d) < 10 Then d = "0" & d
        m = fecha.Month
        If Val(m) < 10 Then m = "0" & m
        a = fecha.Year
        devuelve_fecha = a & "/" & m & "/" & d
        Return devuelve_fecha
    End Function

    Public Function DevuelveHora() As String
        Dim hora As Date = New Funciones().DevuelveFechaServidor()
        Dim horaReturn As String = hora.ToString("hh:mm")
        Return horaReturn
    End Function

    Function CerosAnteriorString(ByVal numero As String, ByVal largo As Integer) As String

        Dim valorCeros As String = ""

        For i As Integer = 0 To ((largo - 1) - numero.Length)
            valorCeros = valorCeros + "0"
        Next

        Return valorCeros + numero
    End Function

    Public Function verificaExistencia(ByVal Tabla As String, _
                                       ByVal Campo As String, ByVal valor As String) As Boolean

        Dim _tabla As DataTable = New DataTable
        Dim _RegistroExiste As Boolean = False
        Try
            con.conectarSQL()

            Dim _cmd As SqlDataAdapter = New SqlDataAdapter("SELECT * FROM " + Tabla + " WHERE " + Campo + "='" + valor + "'", con.conSQL)
            _cmd.Fill(_tabla)

            If _tabla.Rows.Count = 0 Then
                _RegistroExiste = False
            Else
                _RegistroExiste = True
            End If

            con.cerrarSQL()


        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
        'retornar ultimo registro de la tabla 
        Return _RegistroExiste


    End Function

End Class
