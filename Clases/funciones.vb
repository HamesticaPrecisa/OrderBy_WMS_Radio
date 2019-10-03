Imports System.Data.SqlClient
Imports System.Data
Imports System.Text

Public Class Funciones

    Dim con As New Conexion

    Public Function ListarTablasSQL(ByVal Consulta_sql As String) As DataTable
        Dim tabla As DataTable = New DataTable
        Try
            lastSQLError = Nothing
            con.conectarSQL()
            Dim Listado As SqlDataAdapter = New SqlDataAdapter(Consulta_sql, con.conSQL)
            Listado.Fill(tabla)
            con.cerrarSQL()
        Catch ex As SqlException
            lastSQLError = ex.Message
        Catch ex As Exception
            lastSQLError = ex.Message
        Finally
            If con.conSQL.State = ConnectionState.Open Then con.cerrarSQL()
        End Try
        Return tabla
    End Function


    ' VES Sep 2019
    ' Se incluye una sobrecarga que permita el uso de parametros en la sentencia SQL, para poder evitar el SqlInjection
    Public Function ListarTablasSQL(ByVal Consulta_sql As String, ByVal parameters() As SqlParameter) As DataTable
        Dim tabla As DataTable = New DataTable
        Try
            lastSQLError = Nothing
            con.conectarSQL()
            Dim Listado As SqlDataAdapter = New SqlDataAdapter(Consulta_sql, con.conSQL)

            Listado.SelectCommand.CommandTimeout = 0
            For Each param As SqlParameter In parameters
                Listado.SelectCommand.Parameters.Add(param)
            Next
            Listado.Fill(tabla)
            con.cerrarSQL()

        Catch ex As SqlException
            lastSQLError = ex.Message

        Catch ex As Exception
            lastSQLError = ex.Message

        Finally
            If con.conSQL.State = ConnectionState.Open Then con.cerrarSQL()
        End Try
        'retornar tabla con datos
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

    ' VES Sep 2019
    ' Se incluye una sobrecarga que permita el uso de parametros en la sentencia SQL, para poder evitar el SqlInjection
    Public Function MovimientoSQL(ByVal Consulta_sql As String, ByVal parameters() As SqlParameter) As Integer
        Dim retorno As Integer = 0

        Try
            con.conectarSQL()
            'Console.WriteLine(Consulta_sql)
            Dim _cmd As SqlCommand = New SqlCommand(Consulta_sql, con.conSQL)
            For Each param As SqlParameter In parameters
                _cmd.Parameters.Add(param)
            Next
            _cmd.ExecuteNonQuery()
            _cmd.CommandTimeout = 0
            retorno = 1


        Catch ex As SqlException
            retorno = 0
            lastSQLError = ex.Message
        Catch ex As Exception
            retorno = 0
            lastSQLError = ex.Message
        Finally
            If con.conSQL.State = ConnectionState.Open Then
                con.cerrarSQL()
            End If
        End Try

        ' retornar 
        '1 si se ejecuta correctamente
        '0 si no se ejecuta

        Return retorno
    End Function

    ' VES Sep 2019
    ' Permite ejecutar un comando SQL con parametros
    '
    Public Function runSQLCmd(ByVal sqlCmd As SqlCommand) As sqlCmdResult
        Dim resp As sqlCmdResult = New sqlCmdResult()
        Try
            con.conectarSQL()
            sqlCmd.Connection = con.conSQL
            If sqlCmd.CommandText.ToUpper().Substring(0, 7) = "SELECT " Then
                Dim Listado As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
                Listado.SelectCommand.CommandTimeout = 0
                resp.data = New DataTable()
                Listado.Fill(resp.data)
            Else
                sqlCmd.CommandTimeout = 0
                sqlCmd.ExecuteNonQuery()
            End If
            resp.result = True

        Catch ex As Exception
            resp.errorMsg = ex.Message

        Finally
            con.cerrarSQL()
        End Try

        Return resp
    End Function
    Public Function runSQLCmd(ByVal sqlCmdText As String, ByVal parameters() As SqlParameter) As sqlCmdResult
        Dim resp As sqlCmdResult = New sqlCmdResult()
        Try
            Dim sqlCmd As SqlCommand = New SqlCommand(sqlCmdText)
            For Each param As SqlParameter In parameters
                sqlCmd.Parameters.Add(param)
            Next
            resp = runSQLCmd(sqlCmd)

        Catch ex As Exception
            resp.errorMsg = ex.Message
        End Try
        Return resp
    End Function


    ' VES Sep 2019
    ' Ejecuta una consulta y devuelve el primer registro encontrado o NULL si no encuentra nada
    '
    Public Function sqlExecuteRow(ByVal sqlSelect As String, ByVal parameters() As SqlParameter) As DataRow
        Dim Resp As sqlCmdResult = runSQLCmd(sqlSelect, parameters)
        Dim result As DataRow = Nothing
        If Resp.result And Resp.data IsNot Nothing Then
            If Resp.data.Rows.Count > 0 Then
                result = Resp.data.Rows(0)
            End If
        End If
        Return result
    End Function
    Public Function sqlExecuteRow(ByVal sqlSelect As String) As DataRow
        Return sqlExecuteRow(sqlSelect, New SqlParameter() {})
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


    ' VES Sep 2019
    Private Declare Function GetDeviceUniqueID Lib "coredll.dll" _
         (ByVal appData As Byte(), _
          ByVal cbApplictionData As Integer, _
          ByVal dwDeviceIDVersion As Integer, _
          ByVal deviceIDOutput As Byte(), _
          ByRef pcbDeviceIDOutput As Integer) As Integer

    Public Function GetDeviceID(ByVal AppString As String) As String
        Dim AppData As Byte() = System.Text.Encoding.Unicode.GetBytes(AppString)
        Dim appDataSize As Integer = AppData.Length
        Dim DeviceOutput As Byte() = New Byte(19) {}
        Dim SizeOut As Integer = 20
        GetDeviceUniqueID(AppData, appDataSize, 1, DeviceOutput, SizeOut)
        Dim pcid As StringBuilder = New StringBuilder()
        For i As Integer = 0 To DeviceOutput.Length - 1
            If i Mod 2 = 0 AndAlso i > 0 Then pcid.Append("-"c)
            Dim token As String = CerosAnteriorString(DeviceOutput(i).ToString("X"), 2)
            pcid.Append(token)
        Next

        Return pcid.ToString()
    End Function

End Class
