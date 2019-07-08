Imports System.Runtime.InteropServices
Imports System.IO


Public Class Frm_TraqueoService

    Dim fnc As New Funciones
    Dim filaSeleccionada As Integer = -1
    'Dim _LARGOETIQUETA As Integer = 0
    Dim IsTemporal As Boolean = False
    Dim largo1 As Integer = 0
    Dim largo2 As Integer = 0
    Dim largo3 As Integer = 0
    Dim largo4 As Integer = 0
    Dim largo5 As Integer = 0
    Dim fila_grilladetalle As String
    Dim caja As String = ""
    Dim codigo As String

    Public codigo_usuario As String = ""

    <DllImport("coredll.dll")> _
    Public Shared Function sndPlaySound(ByVal lpszSoundName As [String], ByVal fuSound As UInteger) As Boolean
    End Function


    Private Sub tpal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo.KeyPress
        If e.KeyChar = ChrW(13) Then

            codigo = txt_codigo.Text.Trim

            If txt_codigo.Text = "" Then
                'SI EL CODIGO ESTA VACIO SE INSERTA UNO NUEVO Y SE RETORNA

                Dim insertCodigo As String = "INSERT INTO t_etiquetas_autoincrement (FechaCreacion,Peso,Cantidad)" & _
                                             "VALUES (GETDATE(),0,0)"

                If fnc.MovimientoSQLEtiquetado(insertCodigo) > 0 Then
                    Dim sqlId As String = "SELECT TOP 1 IdEtiquetaAutoIncrement FROM t_etiquetas_autoincrement ORDER BY IdEtiquetaAutoIncrement DESC"
                    Dim tablaEtiquetaId As DataTable = fnc.ListarTablasSQLEtiquetado(sqlId)

                    ' EXTRAIGO EL CODIGO RECIEN INSERTADO
                    If tablaEtiquetaId.Rows.Count > 0 Then
                        txt_codigo.Enabled = False
                        txt_codigo.Text = tablaEtiquetaId.Rows(0)(0).ToString
                        txt_envases.Enabled = True
                        txt_envases.Focus()
                    Else
                        MsgBox("Ocurrio un error al extraer nuevo codigo", MsgBoxStyle.Critical, "Aviso")
                        Exit Sub
                    End If
                Else
                    MsgBox("Ocurrio un error al generar un nuevo codigo", MsgBoxStyle.Critical, "Aviso")
                    Exit Sub
                End If

            Else
                'SI EL CODIGO NO ESTA VACIO SE BUSCA Y SE RETORNA
                Dim sql As String = "SELECT IdEtiquetaAutoIncrement, ISNULL(Cantidad,0) As Cantidad FROM t_etiquetas_autoincrement WHERE IdEtiquetaAutoIncrement='" + codigo + "'"
                Dim tablaEtiqueta As DataTable = fnc.ListarTablasSQLEtiquetado(sql)

                ' SE DEJA SELECCIONADO
                If tablaEtiqueta.Rows.Count > 0 Then
                    txt_codigo.Enabled = False
                    txt_codigo.Text = tablaEtiqueta.Rows(0)(0).ToString

                    If tablaEtiqueta.Rows(0)(1).ToString = "0" Then
                        txt_envases.Text = ""
                        txt_envases.Enabled = True
                        txt_lector.Enabled = False
                        txt_envases.Focus()
                    Else
                        txt_envases.Text = tablaEtiqueta.Rows(0)(1).ToString
                        txt_lector.Enabled = True
                        txt_lector.Focus()
                    End If

                Else
                    MsgBox("El codigo ingresado no existe", MsgBoxStyle.Critical, "Aviso")
                    Exit Sub
                End If

            End If
            listarCajas()

        Else
            SoloNumeros(sender, e)
        End If
    End Sub

    Private Sub listarCajas()

        dtg_cajasleidas.DataSource = Nothing

        Dim sqlContar As String = "SELECT COUNT(IdEtiquetaAutoIncrement) AS Cantidad FROM t_tracking WHERE IdEtiquetaAutoIncrement='" + txt_codigo.Text + "'"
        Dim sqlListar As String = "SELECT IdTracking,EtiquetaCompleta FROM t_tracking WHERE IdEtiquetaAutoIncrement='" + txt_codigo.Text + "'"

        Dim tablaCajas As DataTable = fnc.ListarTablasSQLEtiquetado(sqlContar)
        Dim tablaListar As DataTable = fnc.ListarTablasSQLEtiquetado(sqlListar)

        ' CALCULO LAS CAJAS LEIDAS
        If tablaCajas.Rows.Count > 0 Then
            txt_leidas.Text = tablaCajas.Rows(0)(0).ToString
            dtg_cajasleidas.DataSource = tablaListar
        Else
            txt_leidas.Text = "0"
        End If

        If txt_envases.Text = txt_leidas.Text Then
            MsgBox("Todas las cajas se encuentran leidas", MsgBoxStyle.Information, "Aviso")
            actualizarPeso()
            limpiar()
            Exit Sub
        End If
    End Sub

    Private Sub Lector_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_lector.KeyPress

        If e.KeyChar = ChrW(13) Then
            'selecciona caja

           


            caja = txt_lector.Text.Trim
            caja = caja.Replace("]C1", "")
            txt_lector.Text = caja


            If txt_lector.Text.Trim.Length <> 41 Then
                sndPlaySound("\\TEST.WAV", 0)
                sndPlaySound("\\TEST.WAV", 0)
                txt_lector.Text = ""
                Panel1.BackColor = Color.Red
                txt_lector.Focus()
                MsgBox("Las etiquetas deben tener un largo de 41 caracteres", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If

            ''CONSULTO SI PERTENECE AL PRODUCTO 
            If CheckBox1.Checked = True Then
            Else
                Dim sqlx As String = "SELECT IdProducto FROM ve_etiprodu WHERE EtiquetaCompleta='" + txt_lector.Text + "'"
                Dim tablax As DataTable = fnc.ListarTablasSQLEtiquetado(sqlx)

                If tablax.Rows.Count > 0 Then

                    Dim des As String = tablax.Rows(0)(0).ToString.Trim()
                    Dim id As String = cboproducto.SelectedValue.ToString()
                    If des <> id Then
                        sndPlaySound("\\TEST.WAV", 0)
                        sndPlaySound("\\TEST.WAV", 0)
                        txt_lector.Text = ""
                        Panel1.BackColor = Color.Red
                        txt_lector.Focus()
                        MsgBox("Esta etiqueta no pertenece a producto seleccionado", MsgBoxStyle.Critical, "Aviso")
                        Exit Sub

                    End If

                Else
                    sndPlaySound("\\TEST.WAV", 0)
                    sndPlaySound("\\TEST.WAV", 0)
                    txt_lector.Text = ""
                    Panel1.BackColor = Color.Red
                    txt_lector.Focus()
                    MsgBox("Esta etiqueta no Existe", MsgBoxStyle.Critical, "Aviso")
                    Exit Sub

                End If

            End If

           

            'HAGO CONSULTA PARA SABER SI LA CAJA EXISTE EN LA TABLA DE TRACKING
            Dim sql As String = "SELECT IdTracking FROM t_tracking WHERE EtiquetaCompleta='" + caja + "'"
            Dim tablaEtiqueta As DataTable = fnc.ListarTablasSQLEtiquetado(sql)
            Dim IdTracking As String = ""

            ' SI LA CAJA NO EXISTE INSERTO
            If tablaEtiqueta.Rows.Count = 0 Then

                Dim sqlC As String = "SELECT COUNT(IdEtiquetaAutoIncrement) AS Cantidad FROM t_tracking WHERE IdEtiquetaAutoIncrement='" + txt_codigo.Text + "'"
                Dim tablaC As DataTable = fnc.ListarTablasSQLEtiquetado(sqlC)
                Dim cantidad As String
                If tablaC.Rows.Count > 0 Then
                    cantidad = tablaC.Rows(0)(0).ToString
                    If txt_envases.Text = cantidad Then
                        MsgBox("Todas las cajas se encuentran leidas", MsgBoxStyle.Information, "Aviso")
                        actualizarPeso()
                        limpiar()
                        Exit Sub
                    Else
                        sqlC = "SELECT Cantidad FROM t_etiquetas_autoincrement WHERE IdEtiquetaAutoIncrement='" + txt_codigo.Text + "'"
                        tablaC = fnc.ListarTablasSQLEtiquetado(sqlC)

                        If tablaC.Rows.Count > 0 Then
                            If cantidad = tablaC.Rows(0)(0).ToString Then
                                MsgBox("No se pueden ingresar más cajas debido a que la cantidad fue modificada a una menor", MsgBoxStyle.Critical, "Aviso")
                                actualizarPeso()
                                limpiar()
                                Exit Sub
                            Else
                                Dim insertCodigo As String = " INSERT INTO t_tracking (IdEtiquetaAutoincrement,EtiquetaCompleta,FechaIngreso,Encargado)" & _
                                                 " VALUES ('" + txt_codigo.Text + "','" + txt_lector.Text + "',GETDATE(),'" + id_global.ToString + "')"

                                If fnc.MovimientoSQLEtiquetado(insertCodigo) > 0 Then
                                    Panel1.BackColor = Color.Green
                                    txt_lector.Text = ""
                                    txt_lector.Focus()
                                Else
                                    MsgBox("Ocurrio un error al grabar", MsgBoxStyle.Critical, "Aviso")
                                    Exit Sub
                                End If
                            End If
                        Else
                            MsgBox("Ocurrio un error al obtener una cantidad.", MsgBoxStyle.Critical, "Aviso")
                            Exit Sub
                        End If
                    End If
                Else
                    MsgBox("Ocurrio un error al grabar.", MsgBoxStyle.Critical, "Aviso")
                    Exit Sub
                End If
            Else
                ' SI LA CAJA EXISTE CONSULTO SI PERTENECE A ESTE CODIGO O A OTRO
                IdTracking = tablaEtiqueta.Rows(0)(0).ToString

                Dim sqlCajaExiste As String = "SELECT IdEtiquetaAutoIncrement FROM t_tracking WHERE IdTracking='" + IdTracking + "' AND IdEtiquetaAutoIncrement='" + txt_codigo.Text + "'"
                Dim tablaCajaExiste As DataTable = fnc.ListarTablasSQLEtiquetado(sqlCajaExiste)

                If tablaCajaExiste.Rows.Count > 0 Then

                    If MsgBox("¿La caja leida ya se encuentra almacenada para este codigo, desea eliminarla?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = MsgBoxResult.Yes Then
                        Dim deleteTracking As String = "DELETE FROM t_tracking WHERE IdTracking='" + IdTracking + "'"

                        If fnc.MovimientoSQLEtiquetado(deleteTracking) > 0 Then
                            MsgBox("Caja eliminada", MsgBoxStyle.Critical, "Aviso")
                            Panel1.BackColor = Color.Red
                            txt_lector.Text = ""
                            txt_lector.Focus()
                            listarCajas()
                            Exit Sub
                        End If
                    End If

                Else
                    sqlCajaExiste = "SELECT IdEtiquetaAutoIncrement FROM t_tracking WHERE IdTracking='" + IdTracking + "'"
                    tablaCajaExiste = fnc.ListarTablasSQLEtiquetado(sqlCajaExiste)
                    MsgBox("Esta caja ya se encuentra leida en otro codigo referencia (" + tablaCajaExiste.Rows(0)(0).ToString + ")", MsgBoxStyle.Critical, "Aviso")
                    Exit Sub
                End If

                Panel1.BackColor = Color.Red
                txt_lector.Text = ""
                txt_lector.Focus()
            End If

            listarCajas()

        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        limpiar()
    End Sub

    Private Sub txt_envases_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_envases.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txt_envases.Text <> "" Then
                If IsNumeric(txt_envases.Text) = True Then
                    If txt_envases.Text <= 0 Then
                        MsgBox("Debe ingresar una cantidad de envases superior a 0", MsgBoxStyle.Critical, "Aviso")
                        Exit Sub
                    Else
                        Dim updateEnvases As String = "UPDATE t_etiquetas_autoincrement SET Cantidad = '" + txt_envases.Text + "' WHERE IdEtiquetaAutoIncrement='" + txt_codigo.Text + "'"

                        If fnc.MovimientoSQLEtiquetado(updateEnvases) > 0 Then
                            txt_envases.Enabled = False
                            txt_lector.Enabled = True
                            txt_lector.Focus()
                            listarCajas()
                        Else
                            MsgBox("Error al ingresar envases", MsgBoxStyle.Critical, "Aviso")
                            txt_envases.Focus()
                            Exit Sub
                        End If
                        
                    End If
                Else
                    MsgBox("Debe ingresar una cantidad de envases superior a 0", MsgBoxStyle.Critical, "Aviso")
                    txt_envases.Focus()
                    Exit Sub
                End If
            Else
                MsgBox("Debe ingresar una cantidad de envases superior a 0", MsgBoxStyle.Critical, "Aviso")
                txt_envases.Focus()
                Exit Sub
            End If
        Else
            SoloNumeros(sender, e)
        End If
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Me.Close()
    End Sub

    Private Sub limpiar()
        txt_codigo.Text = ""
        txt_envases.Text = ""
        txt_leidas.Text = ""
        txt_lector.Text = ""
        dtg_cajasleidas.DataSource = Nothing

        txt_envases.Enabled = False
        txt_leidas.Enabled = False
        txt_lector.Enabled = False

        txt_codigo.Enabled = True
        txt_codigo.Focus()
    End Sub

    Private Sub actualizarPeso()

        Dim sql As String = "SELECT ISNULL(SUM(CAST((SUBSTRING(EtiquetaCompleta,33,2)+'.'+SUBSTRING(EtiquetaCompleta,35,2))AS FLOAT)),0) AS Peso FROM t_tracking WHERE IdEtiquetaAutoincrement='" + txt_codigo.Text + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQLEtiquetado(sql)
        Dim Peso As String = "0"
        ' SI LA CAJA NO EXISTE INSERTO
        If tabla.Rows.Count > 0 Then
            Peso = tabla.Rows(0)(0).ToString
            Peso = Peso.Replace(",", ".")
            Dim updateEnvases As String = "UPDATE t_etiquetas_autoincrement SET Peso = '" + Peso + "' WHERE IdEtiquetaAutoIncrement='" + txt_codigo.Text + "'"

            If fnc.MovimientoSQLEtiquetado(updateEnvases) > 0 Then
            Else
            End If
        End If
        
    End Sub

    Private Sub Frm_TraqueoService_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cboproducto.DataSource = fnc.ListarTablasSQLEtiquetado("SELECT IdProducto , Descripcion FROM m_producto WHERE (dbo.m_producto.IdCliente = 1) Group by Descripcion,IdProducto ORDER BY IdProducto DESC")
        cboproducto.ValueMember = "IdProducto"
        cboproducto.DisplayMember = "Descripcion"
    End Sub
End Class