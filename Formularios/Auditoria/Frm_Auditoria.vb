Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports Microsoft.Win32
Imports System.IO
Imports System.Text.RegularExpressions

Public Class Frm_auditoria

    Dim fnc As New Funciones
    Dim sqlConsulta As String
    Dim tablaConsulta As DataTable
    Dim sqlListar As String
    Dim tablaListar As DataTable
    Dim sqlUpdate As String
    Dim estadoSoportante As String = ""
    Dim numeroSoportante As String
    Dim tipoAuditoria As String = "" 'N= normal L=libre
    Dim sqlInsert As String
    Dim sqlDelete As String

    'VARIABLES AUXILIARES PARA AUDITORIA LIBRE
    Dim camara As String
    Dim banda As String
    Dim columna As String
    Dim piso As String
    Dim nivel As String
    Dim posicionReal As String = ""
    Dim responsable As String = ""


    Private Sub Frm_auditoria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        limpiar()
        btn_seleccionar.Focus()
    End Sub

    'FUNCIONES OPERATIVAS DEL USUARIO'

    Private Sub habilitar()
        btn_bien.Enabled = True
        btn_mal.Enabled = True
        txt_camara.Enabled = True
        txt_banda.Enabled = True
        txt_columna.Enabled = True
        txt_piso.Enabled = True
        txt_nivel.Enabled = True
        camara = txt_camara.Text
        banda = txt_banda.Text
        columna = txt_columna.Text
        piso = txt_piso.Text
        nivel = txt_nivel.Text
        txt_observacion.Enabled = True
        txt_codigosoportante.Enabled = False
    End Sub

    Private Sub deshabilitar()
        btn_bien.Enabled = False
        btn_mal.Enabled = False
        txt_codigosoportante.Enabled = True
        txt_camara.Enabled = False
        txt_banda.Enabled = False
        txt_columna.Enabled = False
        txt_piso.Enabled = False
        txt_nivel.Enabled = False
        txt_observacion.Enabled = False
        txt_camara.Text = ""
        txt_banda.Text = ""
        txt_columna.Text = ""
        txt_piso.Text = ""
        txt_nivel.Text = ""
        txt_observacion.Text = ""
        txt_codigosoportante.Text = ""
        camara = ""
        banda = ""
        columna = ""
        piso = ""
        nivel = ""
        responsable = ""
        txt_codigosoportante.Focus()
    End Sub

    Private Sub listar()
        Dim orden As String = ""

        If rdi_ordenasc.Checked = True Then
            orden = "ASC"
        Else
            orden = "DESC"
        End If
        If tipoAuditoria = "N" Then
            sqlListar = " SELECT Soportante,Camara,Banda,Columna,Piso,Nivel FROM detalle_auditoria WHERE " & _
                        " Estado ='SL' AND IdAuditoriaFicha='" + txt_codigoauditoria.Text + "' ORDER BY Camara,Columna " + orden + ""
        Else
            sqlListar = " SELECT Soportante,Camara,Banda,Columna,Piso,Nivel FROM detalle_auditoria WHERE " & _
                        " Estado <> 'SL' AND IdAuditoriaFicha='" + txt_codigoauditoria.Text + "' ORDER BY IdAuditoriaDetalle " + orden + ""
        End If
        
        dtg_auditoria.DataSource = Nothing
        tablaListar = fnc.ListarTablasSQL(sqlListar)
        dtg_auditoria.DataSource = tablaListar

        sqlConsulta = "SELECT ISNULL(COUNT(Soportante),0) AS Leidos FROM detalle_auditoria WHERE IdAuditoriaFicha='" + txt_codigoauditoria.Text + "' AND Estado <> 'SL'"
        tablaConsulta = fnc.ListarTablasSQL(sqlConsulta)

        If tablaConsulta.Rows.Count > 0 Then
            txt_leidos.Text = tablaConsulta.Rows(0)(0).ToString()
        End If

        If txt_leidos.Text.Trim = txt_soportantes.Text.Trim Then
            sqlUpdate = " UPDATE ficha_auditoria SET Fin=GETDATE(),Estado='T' " & _
                            " WHERE IdAuditoriaFicha='" + txt_codigoauditoria.Text + "'"
            fnc.MovimientoSQL(sqlUpdate)
            MsgBox("La auditoria se encuentra terminada", MsgBoxStyle.Information, "Aviso")
            limpiar()
        End If

    End Sub

    Private Sub limpiar()
        tipoAuditoria = ""
        sqlConsulta = ""
        tablaConsulta = Nothing
        dtg_auditoria.DataSource = Nothing

        txt_codigoauditoria.Text = ""
        txt_descripcionauditoria.Text = ""
        txt_soportantes.Text = ""
        txt_leidos.Text = ""
        txt_codigosoportante.Text = ""
        txt_camara.Text = ""
        txt_banda.Text = ""
        txt_columna.Text = ""
        txt_piso.Text = ""
        txt_nivel.Text = ""
        txt_observacion.Text = ""
        camara = ""
        banda = ""
        columna = ""
        piso = ""
        nivel = ""
        responsable = ""
        rdi_ordenasc.Checked = True
        rdi_ordendesc.Checked = False

        txt_codigoauditoria.Enabled = False
        txt_descripcionauditoria.Enabled = False
        txt_soportantes.Enabled = False
        txt_leidos.Enabled = False
        txt_codigosoportante.Enabled = False
        txt_camara.Enabled = False
        txt_banda.Enabled = False
        txt_columna.Enabled = False
        txt_piso.Enabled = False
        txt_nivel.Enabled = False
        txt_observacion.Enabled = False

        btn_seleccionar.Enabled = True
        btn_bien.Enabled = False
        btn_mal.Enabled = False

        rdi_ordenasc.Enabled = False
        rdi_ordendesc.Enabled = False


    End Sub

    Private Function TransformaPallet(ByVal pallet As String) As String

        Dim separado As String = ""
        For i As Integer = 11 To pallet.Length - 2
            separado = separado + pallet.Chars(i)
        Next
        txt_codigosoportante.Text = separado
        Return separado
    End Function

    Private Function actualizarSoportante()

        sqlConsulta = "SELECT Inicio FROM ficha_auditoria WHERE IdAuditoriaFicha='" + txt_codigoauditoria.Text + "'"
        tablaConsulta = fnc.ListarTablasSQL(sqlConsulta)

        If tablaConsulta.Rows.Count > 0 Then
            If tablaConsulta.Rows(0)(0).ToString().Trim() = "" Then
                sqlUpdate = " UPDATE ficha_auditoria SET Inicio=GETDATE(), Estado='P' " & _
                            " WHERE IdAuditoriaFicha='" + txt_codigoauditoria.Text + "'"
                fnc.MovimientoSQL(sqlUpdate)
            End If
        End If

        posicionReal = "Camara " + txt_camara.Text + ", Banda " + txt_banda.Text + ", Columna " + txt_columna.Text + ", Piso " + txt_piso.Text + ", Nivel " + txt_nivel.Text + ""

        If tipoAuditoria = "N" Then

            sqlUpdate = " UPDATE detalle_auditoria SET LECTURA=GETDATE(), Usuario='" + id_global.ToString + "', " & _
                    " Observacion='" + txt_observacion.Text.Trim + "', Estado='" + estadoSoportante + "', PosicionReal='" + posicionReal + "', " & _
                    " ResponsableUltima='" + responsable + "' WHERE IdAuditoriaFicha='" + txt_codigoauditoria.Text + "' AND Soportante='" + txt_codigosoportante.Text + "' "

            If fnc.MovimientoSQL(sqlUpdate) > 0 Then
                deshabilitar()
            Else
                MsgBox("Ocurrio un error al guardar estado de soportante", MsgBoxStyle.Critical, "Aviso")
                deshabilitar()
            End If

        Else


            sqlInsert = " INSERT INTO detalle_auditoria " & _
                        " (IdAuditoriaFicha,Soportante,Lectura,Camara,Banda,Columna,Piso,Nivel,Usuario,PosicionReal,ResponsableUltima,Observacion,Estado) " & _
                        " VALUES ('" + txt_codigoauditoria.Text + "','" + txt_codigosoportante.Text.Trim + "',GETDATE(), " & _
                        " '" + camara + "','" + banda + "','" + columna + "','" + piso + "','" + nivel.ToUpper + "', " & _
                        " '" + id_global.ToString + "','" + posicionReal + "','" + responsable + "','" + txt_observacion.Text.Trim() + "','" + estadoSoportante + "')"

            If fnc.MovimientoSQL(sqlInsert) > 0 Then
                deshabilitar()
            Else
                MsgBox("Ocurrio un error al guardar estado de soportante", MsgBoxStyle.Critical, "Aviso")
                deshabilitar()
            End If

        End If

        listar()
        sqlConsulta = ""
        tablaConsulta = Nothing
        sqlUpdate = ""
        sqlInsert = ""
    End Function

    'FUNCIONES OPERATIVAS DEL SISTEMA'

    Private Sub btn_seleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_seleccionar.Click
        'LLAMADA AL FORMULARIO QUE LISTA LAS AUDITORIAS
        Dim frm As New Lst_AyudaAuditoria
        Dim res As DialogResult = frm.ShowDialog()

        If frm.resultado = "OK" Then
            txt_codigoauditoria.Text = frm.IdPrincipal.Trim
            txt_descripcionauditoria.Text = frm.NombrePrincipal.Trim
        End If

        'SI SE SELECCIONO AUDITORIA NORMAL SE OCUPA ESTA OPCIÓN
        If txt_codigoauditoria.Text <> "" And txt_codigoauditoria.Text <> "NO" Then

            sqlConsulta = "SELECT Cantidad,Tipo FROM ficha_auditoria WHERE IdAuditoriaFicha='" + txt_codigoauditoria.Text + "'"
            tablaConsulta = fnc.ListarTablasSQL(sqlConsulta)

            If tablaConsulta.Rows.Count > 0 Then
                txt_soportantes.Text = tablaConsulta.Rows(0)(0).ToString()
                tipoAuditoria = tablaConsulta.Rows(0)(1).ToString().Trim()
            Else
                MsgBox("Ocurrio un error al recuperar la información (N)", MsgBoxStyle.Critical, "Aviso")
                txt_codigoauditoria.Text = ""
                txt_descripcionauditoria.Text = ""
                Exit Sub
            End If

            txt_codigosoportante.Enabled = True
            rdi_ordenasc.Enabled = True
            rdi_ordendesc.Enabled = True
            btn_limpiar.Enabled = True
            sqlConsulta = ""
            tablaConsulta = Nothing
            listar()
            txt_codigosoportante.Focus()
        End If

        'SI SE SELECCIONO AUDITORIA LIBRE SE OCUPA ESTA OPCIÓN
        If txt_codigoauditoria.Text = "NO" Then
            btn_seleccionar.Enabled = False
            btn_limpiar.Enabled = True
            txt_descripcionauditoria.Enabled = True
            txt_descripcionauditoria.Focus()
            tipoAuditoria = "L"
        End If

    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        limpiar()
    End Sub

    Private Sub rdi_ordenasc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdi_ordenasc.CheckedChanged
        listar()
    End Sub

    Private Sub rdi_ordendesc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdi_ordendesc.CheckedChanged
        listar()
    End Sub

    Private Sub txt_codigosoportante_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigosoportante.KeyPress
        If e.KeyChar = ChrW(13) Then

            Try
                If txt_codigoauditoria.Text.Trim <> "" Then
                    Dim cantidad As Integer = txt_codigosoportante.Text.Trim.Length

                    If cantidad > 9 Then
                        numeroSoportante = txt_codigosoportante.Text.Trim
                        numeroSoportante = numeroSoportante.Replace("]C1", "")
                        numeroSoportante = Regex.Replace(numeroSoportante, "[^\w\.@-]", "")
                        numeroSoportante = numeroSoportante.Substring(10, 9)
                    Else
                        numeroSoportante = CerosAnteriorString(txt_codigosoportante.Text.Trim, 9)
                    End If

                    txt_codigosoportante.Text = numeroSoportante

                    'AUDITORIA NORMAL
                    If tipoAuditoria = "N" Then
                        sqlConsulta = " SELECT racd_ca, racd_Ba, racd_Co, racd_Pi, racd_Ni, Estado, " & _
                                      " (SELECT TOP (1) (usu_nombre + ' ' + usu_ap)" & _
                                      " FROM movpallet,Usuarios" & _
                                      " WHERE mov_codper = usu_codigo AND " & _
                                      " (mov_folio = '" + numeroSoportante + "')) " & _
                                      " FROM rackdeta, detarece, detalle_auditoria " & _
                                      " WHERE drec_codi=racd_codi AND" & _
                                      " drec_codi=Soportante AND " & _
                                      " racd_codi='" + numeroSoportante + "'"

                        tablaConsulta = fnc.ListarTablasSQL(sqlConsulta)

                        If tablaConsulta.Rows.Count > 0 Then

                            txt_camara.Text = tablaConsulta.Rows(0)(0).ToString()
                            txt_banda.Text = tablaConsulta.Rows(0)(1).ToString()
                            txt_columna.Text = tablaConsulta.Rows(0)(2).ToString()
                            txt_piso.Text = tablaConsulta.Rows(0)(3).ToString()
                            txt_nivel.Text = tablaConsulta.Rows(0)(4).ToString()
                            responsable = tablaConsulta.Rows(0)(6).ToString()

                            habilitar()

                            If tablaConsulta.Rows(0)(5).ToString().Trim <> "SL" Then
                                MsgBox("El soportante ingresado ya se encuentra leido", MsgBoxStyle.Information, "Aviso")
                                deshabilitar()
                                Exit Sub
                            End If
                        Else
                            MsgBox("El soportante ingresado no pertenece a la auditoria", MsgBoxStyle.Information, "Aviso")
                            deshabilitar()
                            Exit Sub
                        End If
                        'AUDITORIA LIBRE
                    Else
                        sqlConsulta = " SELECT IdAuditoriaDetalle FROM detalle_auditoria " & _
                                      " WHERE Soportante='" + numeroSoportante + "' AND IdAuditoriaFicha='" + txt_codigoauditoria.Text.Trim() + "' "

                        tablaConsulta = fnc.ListarTablasSQL(sqlConsulta)

                        If tablaConsulta.Rows.Count > 0 Then
                            MsgBox("El soportante ingresado ya se encuentra leido", MsgBoxStyle.Information, "Aviso")
                            deshabilitar()
                            Exit Sub
                        Else
                            sqlConsulta = " SELECT racd_ca, racd_Ba, racd_Co, racd_Pi, racd_Ni," & _
                                      " (SELECT TOP (1) (usu_nombre + ' ' + usu_ap)" & _
                                      " FROM movpallet,Usuarios" & _
                                      " WHERE mov_codper = usu_codigo AND " & _
                                      " (mov_folio = '" + numeroSoportante + "')" & _
                                      " ORDER BY mov_fecha DESC, mov_hora DESC) AS Nombre " & _
                                      " FROM rackdeta,detarece" & _
                                      " WHERE drec_codi=racd_codi AND " & _
                                      " racd_codi='" + numeroSoportante + "'"

                            tablaConsulta = fnc.ListarTablasSQL(sqlConsulta)

                            If tablaConsulta.Rows.Count > 0 Then

                                txt_camara.Text = tablaConsulta.Rows(0)(0).ToString()
                                txt_banda.Text = tablaConsulta.Rows(0)(1).ToString()
                                txt_columna.Text = tablaConsulta.Rows(0)(2).ToString()
                                txt_piso.Text = tablaConsulta.Rows(0)(3).ToString()
                                txt_nivel.Text = tablaConsulta.Rows(0)(4).ToString()
                                responsable = tablaConsulta.Rows(0)(5).ToString()

                                habilitar()
                            Else
                                MsgBox("Ocurrio un error al obtener soportante", MsgBoxStyle.Critical, "Aviso")
                                deshabilitar()
                                Exit Sub
                            End If
                        End If
                    End If
                Else
                    MsgBox("Debe ingresar un soportante", MsgBoxStyle.Critical, "Aviso")
                    deshabilitar()
                    Exit Sub
                End If
            Catch ex As ArgumentOutOfRangeException
                MsgBox("El codigo ingresado no es valido", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End Try
            btn_bien.Focus()
        End If
    End Sub

    Private Sub btn_bien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_bien.Click
        estadoSoportante = "BP"
        actualizarSoportante()
        estadoSoportante = ""
    End Sub

    Private Sub btn_mal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mal.Click
        estadoSoportante = "MP"
        actualizarSoportante()
        estadoSoportante = ""
    End Sub

    Private Sub txt_descripcionauditoria_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_descripcionauditoria.KeyPress
        If e.KeyChar = ChrW(13) Then
            txt_descripcionauditoria.Text = txt_descripcionauditoria.Text.Trim.ToUpper
            If txt_descripcionauditoria.Text.Trim <> "" Then
                sqlConsulta = "SELECT IdAuditoriaFicha FROM ficha_auditoria WHERE Descripcion='" + txt_descripcionauditoria.Text + "'"
                tablaConsulta = fnc.ListarTablasSQL(sqlConsulta)

                If tablaConsulta.Rows.Count > 0 Then
                    sqlConsulta = ""
                    tablaConsulta = Nothing
                    MsgBox("La descripción ingresada ya existe", MsgBoxStyle.Critical, "Aviso")
                    txt_descripcionauditoria.Text = ""
                    txt_descripcionauditoria.Focus()
                    Exit Sub
                Else
                    txt_descripcionauditoria.Enabled = False
                    txt_soportantes.Enabled = True
                    txt_soportantes.Focus()
                End If
            Else
                MsgBox("Debe ingresar una descripción valida", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txt_soportantes_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_soportantes.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txt_soportantes.Text.Trim <> "" Then
                If IsNumeric(txt_soportantes.Text.Trim) Then
                    If txt_soportantes.Text.Trim > 0 Then
                        txt_soportantes.Enabled = False

                        sqlInsert = " INSERT INTO ficha_auditoria " & _
                                    " (Descripcion,Ingreso,Cantidad,Porcentaje,Usuario,Tipo,Estado)" & _
                                    " VALUES ('" + txt_descripcionauditoria.Text.Trim + "',GETDATE(),'" + txt_soportantes.Text.Trim + "','0','" + id_global.ToString + "','L','A')"

                        If fnc.MovimientoSQL(sqlInsert) > 0 Then
                            sqlConsulta = " SELECT TOP 1 IdAuditoriaFicha FROM ficha_auditoria WHERE Usuario='" + id_global.ToString + "' " & _
                                          " AND Tipo='L' AND (Estado='A' OR Estado='P') ORDER BY IdAuditoriaFicha DESC"
                            tablaConsulta = fnc.ListarTablasSQL(sqlConsulta)

                            If tablaConsulta.Rows.Count > 0 Then
                                txt_codigoauditoria.Text = tablaConsulta.Rows(0)(0).ToString().Trim()
                                tablaConsulta = Nothing
                                deshabilitar()
                            Else
                                MsgBox("Ocurrio un error al recuperar auditoría libre", MsgBoxStyle.Critical, "Aviso")
                                limpiar()
                            End If
                        Else
                            MsgBox("Ocurrio un error al ingresar auditoría libre", MsgBoxStyle.Critical, "Aviso")
                            limpiar()
                        End If
                    Else
                        MsgBox("Debe ingresar una cantidad mayor a 0", MsgBoxStyle.Critical, "Aviso")
                        Exit Sub
                    End If
                Else
                    MsgBox("Debe ingresar una cantidad mayor a 0", MsgBoxStyle.Critical, "Aviso")
                    Exit Sub
                End If

            Else
                MsgBox("Debe ingresar una cantidad mayor a 0", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If

            rdi_ordenasc.Enabled = True
            rdi_ordendesc.Enabled = True
        Else
            SoloNumeros(sender, e)
        End If
    End Sub

    Private Sub txt_camara_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_camara.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub txt_banda_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_banda.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub txt_columna_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_columna.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub txt_piso_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_piso.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub dtg_auditoria_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtg_auditoria.DoubleClick
        If tipoAuditoria = "L" Then
            Dim soportanteEliminar As String = CStr(dtg_auditoria(dtg_auditoria.CurrentCell.RowNumber, 0))
            If MsgBox("¿Esta seguro que desea eliminar el soportante seleccionado de la auditoria?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                sqlDelete = "DELETE FROM detalle_auditoria WHERE Soportante='" + soportanteEliminar + "' AND IdAuditoriaFicha='" + txt_codigoauditoria.Text + "'"
                fnc.MovimientoSQL(sqlDelete)
            End If
            listar()
        End If
    End Sub
End Class