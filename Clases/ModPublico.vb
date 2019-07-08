Imports System.Data
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports System.Text
Imports System.Security.Cryptography
Imports System.IO

Module ModPublico


    Dim fnc As New Funciones
    Dim frm As New Frm_Menu
    Public mod_ped1 As String = ""
    Public mod_ped2 As String = ""
    Public mod_ped3 As String = ""
    Public pedidos_login As Integer = 0
    Public pedidos_actuales As Integer = 0
    'Necesario para preparacion de pedidos listado
    Public encargado_global As String = ""
    Public accion_global As Integer = 1
    Public id_global As Integer = 0


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

    Public Function devuelve_fecha_Formato2(ByVal fecha As DateTime) As String
        Dim a, m, d As String

        d = fecha.Day.ToString()
        If Val(d) < 10 Then d = "0" & d
        m = fecha.Month.ToString()
        If Val(m) < 10 Then m = "0" & m
        a = fecha.Year.ToString()
        devuelve_fecha_Formato2 = d & "/" & m & "/" & a
        Return devuelve_fecha_Formato2
    End Function

    Public Function RutDigito(ByVal Rut As String) As Boolean
        Try
            Dim ru, RU2 As Integer
            Dim Digito As Integer
            Dim Contador As Integer
            Dim Multiplo As Integer
            Dim Acumulador As Integer
            Dim r As String
            Rut = Rut.ToUpper()
            If Len(Rut) >= 9 Then
                ru = Convert.ToInt32(Mid(Rut, 1, Len(Rut) - 2))
                RU2 = ru
                Contador = 2
                Acumulador = 0
                While ru <> 0
                    Multiplo = (ru Mod 10) * Contador
                    Acumulador = Acumulador + Multiplo
                    ru = ru \ 10
                    Contador = Contador + 1
                    If Contador = 8 Then
                        Contador = 2
                    End If
                End While
                Digito = 11 - (Acumulador Mod 11)

                r = RU2 & "-" & CStr(Digito)
                If Digito = 10 Then r = RU2 & "-" & "K"
                If Digito = 11 Then r = RU2 & "-" & "0"

                If r = Rut Or "0" + r = Rut Then
                    RutDigito = True
                ElseIf CerosAnteriorString(r, 10) = Rut Then

                    RutDigito = True
                Else
                    RutDigito = False
                End If
            Else

                RutDigito = False
            End If
        Catch ex As Exception
            RutDigito = False
        End Try

    End Function

    Public Function FncConvierteNumero(ByVal mone As String) As Double
        Dim largo As Integer
        Dim cons, str As String

        cons = ""
        str = ""
        largo = Len(mone)
        For i As Integer = 1 To largo
            cons = Mid(mone, i, 1)
            If IsNumeric(cons) Then
                str = str & cons
            End If
        Next
        Return Val(str)
    End Function

    Public Sub SoloNumeros(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Public Function QuitarCaracteres(ByVal cadena As String, Optional ByVal chars As String = ".:<>{}[]^+,;_-/*?¿!$%&/¨Ññ()='áéíóúÁÉÍÓÚ¡" + Chr(34)) As String
        Dim i As Integer
        Dim nCadena As String
        'Asignamos valor a la cadena de trabajo para
        'no modificar la que envía el cliente.
        nCadena = cadena
        For i = 1 To Len(chars)
            nCadena = Replace(nCadena, Mid(chars, i, 1), "")
        Next i
        'Devolvemos la cadena tratada
        QuitarCaracteres = nCadena
        Return nCadena
    End Function

    Function CerosAnteriorString(ByVal numero As String, ByVal largo As Integer) As String

        Dim valorCeros As String = ""

        For i As Integer = 0 To ((largo - 1) - numero.Length)
            valorCeros = valorCeros + "0"
        Next

        Return valorCeros + numero
    End Function

    Function CerosPosteriorString(ByVal numero As String, ByVal largo As Integer) As String

        Dim valorCeros As String = ""

        For i As Integer = 0 To ((largo - 1) - numero.Length)
            valorCeros = valorCeros + "0"
        Next

        Return numero + valorCeros
    End Function

    Public Function validar_Mail(ByVal sMail As String) As Boolean
        ' retorna true o false   
        Return Regex.IsMatch(sMail, _
                "^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$")
    End Function

    Public Sub ValidaTemperatura(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ChrW(189) Or e.KeyChar <> ChrW(109) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> ChrW(45) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Public Function ValidarHora(ByVal texto As String) As Boolean
        Dim ValidaHora As Boolean = IsDate(texto)
        Return ValidaHora
    End Function

    Public Function DevuelveHora() As String
        Dim hora As Date = fnc.DevuelveFechaServidor()
        Dim horaReturn As String = hora.ToString("HH:mm")
        Return horaReturn
    End Function

    Function DigitoVerificadorEAN128UCC(ByVal numero As String) As String

        Dim separado(20) As String
        Dim valores(20) As Integer

        Dim suma As Integer = 0

        For i As Integer = 0 To numero.Length - 1
            separado(i) = numero.Chars(i)
        Next


        For i As Integer = 0 To separado.Length - 1
            If i Mod 2 = 1 Then
                suma = Convert.ToInt32(suma + (Val(separado(i)) * 1))
            Else
                suma = Convert.ToInt32(suma + (Val(separado(i)) * 3))
            End If
        Next

        Dim multiplo As Integer = 0


        For i As Integer = 0 To suma Step 10
            multiplo = multiplo + 10
        Next


        Dim verificador As Integer = multiplo - suma

        If verificador = 10 Then
            verificador = 0
        End If


        Return numero & "" & verificador.ToString()
    End Function

    Public Function CancelaCorrelativo(ByVal NCorrelat As String, ByVal CodigoEliminar As String) As Integer
        Dim x As Integer = 0

        Dim sql As String = "INSERT INTO Correlat_Salto(tmps_codi, tmps_correl, tmps_personal, tmps_fecha)VALUES('" + CodigoEliminar + "','" + NCorrelat + "','" + New Frm_Menu().codigo.ToString() + "','" + devuelve_fecha(fnc.DevuelveFechaServidor()) + "')"

        If fnc.MovimientoSQL(sql) > 0 Then
            x = 1
        End If

        Return x
    End Function

    Public Function BuscaCorrelativo(ByVal NCorrelat As String, Optional ByVal largo As Integer = 7) As String

        Dim NcorrAct As String = ""

        Dim SqlSalto As String = "SELECT tmps_unica, tmps_codi FROM Correlat_salto WHERE tmps_correl ='" + NCorrelat + "' ORDER BY tmps_codi ASC"
        Dim tablaSalto As DataTable = fnc.ListarTablasSQL(SqlSalto)

        If tablaSalto.Rows.Count > 0 Then
            If NCorrelat = "006" Then
                If fnc.verificaExistencia("Fichrece", "frec_codi", tablaSalto.Rows(0)(1).ToString()) = True Then

                    Dim sqlEliminas As String = "DELETE FROM Correlat_salto WHERE tmps_unica='" + tablaSalto.Rows(0)(0).ToString() + "'"
                    fnc.MovimientoSQL(sqlEliminas)

                    Dim sql As String = "SELECT cor_correact FROM correlat WHERE cor_codi='" + NCorrelat + "'"
                    Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

                    If tabla.Rows.Count > 0 Then
                        NcorrAct = tabla.Rows(0)(0).ToString()

                        Dim sqlUpdate As String = "UPDATE correlat SET cor_correact='" + (Convert.ToInt32(tabla.Rows(0)(0).ToString()) + 1).ToString() + "' " & _
                            "WHERE cor_codi='" + NCorrelat.ToString() + "'"

                        fnc.MovimientoSQL(sqlUpdate)

                    End If
                    Return CerosAnteriorString(NcorrAct, largo)
                    Exit Function
                End If
            End If
            Dim sqlEliminaSalto As String = "DELETE FROM Correlat_salto WHERE tmps_unica='" + tablaSalto.Rows(0)(0).ToString() + "'"
            fnc.MovimientoSQL(sqlEliminaSalto)

            Return tablaSalto.Rows(0)(1).ToString()
            Exit Function
        Else

            Dim sql As String = "SELECT cor_correact FROM correlat WHERE cor_codi='" + NCorrelat + "'"
            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then
                NcorrAct = tabla.Rows(0)(0).ToString()

                Dim sqlUpdate As String = "UPDATE correlat SET cor_correact='" + (Convert.ToInt32(tabla.Rows(0)(0).ToString()) + 1).ToString() + "' " & _
                    "WHERE cor_codi='" + NCorrelat.ToString() + "'"

                fnc.MovimientoSQL(sqlUpdate)

            End If
        End If
        Return CerosAnteriorString(NcorrAct, largo)
    End Function

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
            DECODIFICA = DECODIFICA & Chr(P1 - P2).ToString()
            y = y + 1
            If y = LARGO2 Then y = 1
        Next X
    End Function

    Function RealizarAccion(ByVal Seccion As String, ByVal Subseccion As String, ByVal usuario As String, Optional ByVal Mensaje As Boolean = True) As Boolean
        RealizarAccion = True

        Dim sql As String = "SELECT * FROM UsuariosFunciones AS uf ,PrivilegiosSubSeccion AS us , Usuarios " & _
            "WHERE uf.Usu_Rut = Usuarios.usu_rut AND uf.Usu_SprivId = us.Spriv_Id AND  Spriv_PrivId='" + Seccion + "' AND Spriv_Id='" + Subseccion + "' AND usu_codigo='" + usuario + "' "

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        If tabla.Rows.Count = 0 Then
            If Mensaje = True Then
                MsgBox("No puede realizar esta acción, Operacion Denegada", MsgBoxStyle.Critical, "Aviso")
            End If
            RealizarAccion = False
        End If
    End Function

    Public Function CodigoPallet(ByVal pallet As String) As String

        Dim separado As String = ""
        For i As Integer = 11 To pallet.Length - 2
            separado = separado + pallet.Chars(i)
        Next
        Return separado
    End Function

    Public Function contarPedidos() As Integer
        Dim sql As String = " SELECT COUNT(Orden) As cantidad" & _
                            " FROM pedidos_ficha, clientes" & _
                            " WHERE cli_rut=cliente AND terminado <>'3' AND Ped_estpred<>'3' AND codvig='0' AND" & _
                            " Orden not in(SELECT fpre_nped FROM fichpred) AND Dateadd(day,2,Convert(date,fecha,103))>Convert(date,GETDATE(),103)"
        Dim cantidad As Integer = 0
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        If tabla.Rows.Count > 0 Then
            cantidad = CInt(tabla.Rows(0)(0).ToString())
        Else
            cantidad = 0
        End If
        Return cantidad
    End Function

    Public Function RealizarAccion(ByVal Seccion As String, ByVal Subseccion As String, Optional ByVal Mensaje As Boolean = True) As Boolean
        RealizarAccion = True

        Dim sql As String = "SELECT * FROM UsuariosFunciones AS uf ,PrivilegiosSubSeccion AS us , Usuarios " & _
            "WHERE uf.Usu_Rut = Usuarios.usu_rut AND uf.Usu_SprivId = us.Spriv_Id AND  Spriv_PrivId='" + Seccion + "' AND Spriv_Id='" + Subseccion + "' AND convert(int,usu_codigo)='" + id_global.ToString + "' "

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        If tabla.Rows.Count = 0 Then
            If Mensaje = True Then
                MsgBox("No puede realizar esta acción, Operacion Denegada", MsgBoxStyle.Critical, "Aviso")
            End If
            RealizarAccion = False
        End If
    End Function

    Public Function retorna_Origen(ByVal codigo As String) As String
        retorna_Origen = ""
        Dim sql As String = "SELECT Ori_descr FROM Origen WHERE ori_codi='" + codigo.ToString() + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        If tabla.Rows.Count > 0 Then
            retorna_Origen = tabla.Rows(0)(0).ToString()
        End If
        Return retorna_Origen
    End Function

    Public Function RetornaCliente(ByVal rut As String) As String

        Dim nombre_cliente As String = ""

        Dim sql As String = "SELECT cli_nomb FROM clientes WHERE cli_rut='" + rut + "'"

        If fnc.ListarTablasSQL(sql).Rows.Count > 0 Then
            nombre_cliente = fnc.ListarTablasSQL(sql).Rows(0)(0).ToString()
        End If

        Return nombre_cliente
    End Function

    Public Sub LimpiarCajas(ByVal Objeto As Object)
        'For Each c As Control In Objeto.Controls
        '    If TypeOf c Is TextBox Then
        '        c.Text = ""
        '    End If
        'Next
    End Sub

    Public Function EstadoCheckBox(ByVal check As Integer) As String
        Dim estado As String = "" + check.ToString()
        Return estado
    End Function

End Module
