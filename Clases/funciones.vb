Imports System.Data.SqlClient
Imports System.Data

Public Class Funciones

    Dim con As New Conexion

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
   

    Public Function ListarTablasSQLEtiquetado(ByVal Consulta_sql As String) As DataTable
        Dim tabla As DataTable = New DataTable
        Try
            con.conectarSQLEtiquetado()
            Dim Listado As SqlDataAdapter = New SqlDataAdapter(Consulta_sql, con.conSQLEtiquetado)
            Listado.Fill(tabla)
            con.cerrarSQLEtiquetado()
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
            'retorno = 0
            MsgBox(ex.ToString())
        End Try
        Return retorno
    End Function

    Public Function MovimientoSQLEtiquetado(ByVal Consulta_sql As String) As Integer
        Dim retorno As Integer = 0
        Try
            con.conectarSQLEtiquetado()
            Dim _cmd As SqlCommand = New SqlCommand(Consulta_sql, con.conSQLEtiquetado)
            _cmd.ExecuteNonQuery()
            retorno = 1
            con.cerrarSQLEtiquetado()
        Catch ex As Exception
            'retorno = 0
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

    Public Function UltimoRegistroEtiquetado(ByVal Consulta_sql As String) As Integer
        Dim _tabla As DataTable = New DataTable
        Dim _ultimoRegistro As Integer = 0
        Try

            con.conectarSQLEtiquetado()

            Dim _cmd As SqlDataAdapter = New SqlDataAdapter(Consulta_sql, con.conSQLEtiquetado)
            _cmd.Fill(_tabla)

            If _tabla.Rows.Count = 0 Then
                _ultimoRegistro = 1
            Else
                _ultimoRegistro = Convert.ToInt32(Convert.ToInt32(_tabla.Rows(_tabla.Rows.Count - 1)(0)) + 1)
            End If
            con.cerrarSQLEtiquetado()


        Catch ex As Exception
            ' MsgBox(ex.ToString())
        End Try

        Return _ultimoRegistro
    End Function

    Public Function ValorMaximo(ByVal Tabla As String, ByVal Campo As String, ByVal ValorSumar As Integer) As Integer

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

    Public Function ValorMaximoEtiquetado(ByVal Tabla As String, ByVal Campo As String, ByVal ValorSumar As Integer) As Integer

        Dim _tabla As DataTable = New DataTable
        Dim _valorMaximo As Integer = 0

        Try
            con.conectarSQLEtiquetado()

            Dim _cmd As SqlDataAdapter = New SqlDataAdapter("SELECT Max(" + Campo + ") FROM " + Tabla, con.conSQLEtiquetado)
            _cmd.Fill(_tabla)

            If _tabla.Rows.Count > 0 Then
                _valorMaximo = Convert.ToInt32(_tabla.Rows(0)(0))
            Else
                _valorMaximo = 0
            End If
            con.cerrarSQLEtiquetado()


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
            Dim P1 As Integer = Asc(Mid(PASS, X, 1))
            Dim P2 As Integer = Asc(Mid(LETRAS, y, 1))
            Dim fin As Char = Chr(P1 + P2)

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
            Dim P1 As Integer = Asc(Mid(PASS, X, 1))
            Dim P2 As Integer = Asc(Mid(LETRAS, y, 1))
            DECODIFICA = DECODIFICA & Chr(P1 - P2)
            y = y + 1
            If y = LARGO2 Then y = 1
        Next X
    End Function

    Public Function devuelve_fecha(ByVal fecha As DateTime) As String
        Dim a, m, d As String

        d = fecha.Day.ToString()
        If Val(d) < 10 Then d = "0" & d
        m = fecha.Month.ToString()
        If Val(m) < 10 Then m = "0" & m
        a = fecha.Year.ToString()
        devuelve_fecha = a & "/" & m & "/" & d
        Return devuelve_fecha
    End Function

    Public Function DevuelveHora() As String
        Dim hora As Date = DevuelveFechaServidor()
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

    Public Function buscaHoraServidor() As Date

        Dim tabla As DataTable = New DataTable
        Try
            con.conectarSQL()
            Dim Listado As SqlDataAdapter = New SqlDataAdapter("SELECT CONVERT(VARCHAR(23), GETDATE(), 121)", con.conSQL)
            Listado.Fill(tabla)
            con.cerrarSQL()
        Catch ex As Exception
            '  MsgBox(ex.Message())
        End Try
        'retornar tabla con datos
        Dim fecha As DateTime = Convert.ToDateTime(tabla.Rows(0)(0).ToString())
        Return fecha

    End Function

    Public Function DevuelveFechaServidor() As DateTime

        Dim tabla As DataTable = New DataTable
        Try
            con.conectarSQL()
            Dim Listado As SqlDataAdapter = New SqlDataAdapter("SELECT GETDATE()", con.conSQL)
            Listado.Fill(tabla)
            con.cerrarSQL()
        Catch ex As Exception
            '  MsgBox(ex.Message())
        End Try
        Return Convert.ToDateTime(tabla.Rows(0)(0).ToString())

    End Function

    Public Function verificaExistenciaCondicional(ByVal Tabla As String, ByVal Condicion As String) As Boolean

        Dim _tabla As DataTable = New DataTable
        Dim _RegistroExiste As Boolean = False
        Try
            con.conectarSQL()
            Dim sql As String = "SELECT * FROM " + Tabla + " WHERE " + Condicion + ""
            Dim _cmd As SqlDataAdapter = New SqlDataAdapter(sql, con.conSQL)
            _cmd.Fill(_tabla)

            If _tabla.Rows.Count = 0 Then
                _RegistroExiste = False
            Else
                _RegistroExiste = True
            End If

            con.cerrarSQL()


        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
        'retornar ultimo registro de la tabla 
        Return _RegistroExiste

    End Function

    Public Function DevuelveUsuario(ByVal codigo As String) As String

        Dim tabla As DataTable = New DataTable
        Try
            con.conectarSQL()
            Dim Listado As SqlDataAdapter = New SqlDataAdapter("SELECT usu_nombre+' '+ usu_ap FROM usuarios WHERE convert(int,usu_codigo) = '" + codigo + "'", con.conSQL)
            Listado.Fill(tabla)
            con.cerrarSQL()
        Catch ex As Exception

        End Try
        Return Convert.ToString(tabla.Rows(0)(0).ToString())

    End Function



End Class
