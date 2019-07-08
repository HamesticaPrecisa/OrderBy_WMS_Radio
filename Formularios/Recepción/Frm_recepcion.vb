Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports Microsoft.Win32
Imports System.IO
Imports FieldSoftware.PrinterCE_NetCF
Imports SqlRDA.PrintCENET


Public Class Frm_recepción
    Public detareceaux As DataTable
    Public dataadicionalesaux As DataTable
    Dim fuente As Font
    Dim fnc As New Funciones
    Dim modifi As String = ""
    Dim NumeroPallet As String = ""
    Dim valorRecibido As String = ""
    Dim descrRecibido As String = ""
    Public mensaje As String = ""
    Dim fila_grilladetalle As Integer = -1
    Dim OBSERVACION_VAS As String = ""
    Dim datosguia As String = "0"
    Dim modificacion As Boolean = False
    Dim pesopa As Integer = 0
    Dim TxtNpallets As String = "0"
    Dim TxtPromTemp As String = "0"
    Dim DiasVenc As Integer = 0
    Dim nombrepc As String = "Radio frecuencia"
    Dim sucursalglo As String = "1"
    Dim ingreso As Boolean = False
    Dim largo_global As Integer = 0
    Private mCurLang As Int32 = 0
    Dim CLIENTE As String = ""
    Dim PRODUCTO As String = ""
    Dim FOLIOCLIENTE As String = ""
    Dim UNIDADESACTUALES As String = ""
    Dim UNIDADESRECE As String = ""
    Dim KG2 As String = ""
    Dim FPRO As String = ""
    Dim FVEN As String = ""
    Dim CODIGOLARGO As String = ""
    Dim configuracionimpresora As Boolean = False

    Dim frmM As New Frm_Menu



    Private Sub TxtCodRece_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodRece.KeyPress
        If e.KeyChar = ChrW(13) Then
            If TxtCodRece.Text = "" Then
                If RealizarAccion("001", "001") = False Then
                    Exit Sub
                End If

                TxtCodRece.Text = BuscaCorrelativo("006")
                txtCodRece2.Text = TxtCodRece.Text



                If TxtCodRece.Text.Substring(0, 3) = "000" Then
                    Dim stttt As String = TxtCodRece.Text.Substring(0, 3)

                    stttt = stttt



                Else
                    TxtCodRece.Text = ""
                    txtCodRece2.Text = TxtCodRece.Text
                    Dim sql_log As String = "INSERT INTO LOG_SALTOCORR(tmps_codi, tmps_correl, tmps_personal, tmps_fecha, tmps_gestion)VALUES( " & _
                 "'SI','006','" + encargado_global + "','" + fnc.DevuelveFechaServidor() + "','SALTO GRABADO OTRO LADO')"
                    fnc.MovimientoSQL(sql_log)


                    TxtCodRece.Text = BuscaCorrelativo("006")
                    txtCodRece2.Text = TxtCodRece.Text

                End If

                If TxtCodRece.Text.Trim = "SI" Or TxtCodRece.Text = "0003880" Then

                    Dim sql_log As String = "INSERT INTO LOG_SALTOCORR(tmps_codi, tmps_correl, tmps_personal, tmps_fecha, tmps_gestion)VALUES( " & _
                   "'SI','006','" + encargado_global + "','" + fnc.DevuelveFechaServidor() + "','SALTO GRABADO OTRO LADO')"
                    fnc.MovimientoSQL(sql_log)



                End If

                Dim frm As New Frm_CamionesAndenRecepcion
                Dim res As DialogResult = frm.ShowDialog()

                If frm.resultado = "OK" Then
                    Me.valorRecibido = frm.IdPrincipal
                End If

                If fnc.verificaExistencia("zchecklist", "cl_fol", valorRecibido) = False Then
                    'Console.WriteLine(valorRecibido)
                    If valorRecibido <> "NO" Then
                        MsgBox("No ha seleccionado un camion", MsgBoxStyle.Critical, "Aviso")
                        CancelaCorrelativo("006", TxtCodRece.Text)
                        TxtCodRece.Text = ""
                        txtCodRece2.Text = TxtCodRece.Text
                        TxtCodRece.Focus()
                        Exit Sub
                    Else
                        valorRecibido = ""
                        TxtCodRece.Enabled = False
                        btn_guardar.Enabled = True
                        btn_guardar2.Enabled = True

                        Gb_Encabezado.Enabled = True
                        Gb_Cliente.Enabled = True
                        Gb_observacion.Enabled = True
                        Gb_Cliente.Enabled = True

                        Lbl_EstadoGuia.Text = "ACTIVA"
                        Lbl_EstadoGuia2.Text = "ACTIVA"
                        Lbl_EstadoGuia.ForeColor = Color.Blue
                        Lbl_EstadoGuia2.ForeColor = Color.Blue
                        txtrutchofer.Enabled = False
                        TxtClirut.Enabled = False
                        horalleg.Text = DevuelveHora()
                        TimeAdicionales.Enabled = True

                    End If
                Else
                    Dim sql As String = "SELECT cl_rutcli, cli_nomb, cl_chorut, cho_nombre, cl_pate, cl_choemp,  " & _
                                        "right(convert(char(8),Cl_Lleg,8),8) AS HORA, Cl_Ting  FROM  zchecklist, choferes, clientes  " & _
                                        "WHERE cli_rut=cl_rutcli AND cl_chorut=cho_rut  AND  cl_fol='" + valorRecibido + "'"

                    Dim TablaCheck As DataTable = fnc.ListarTablasSQL(sql)

                    If TablaCheck.Rows.Count > 0 Then
                        TxtFolioPorteria.Text = valorRecibido
                        TxtClirut.Text = TablaCheck.Rows(0)(0).ToString()
                        txtclinom.Text = TablaCheck.Rows(0)(1).ToString()
                        txtrutchofer.Text = TablaCheck.Rows(0)(2).ToString()
                        txtnombrechofer.Text = TablaCheck.Rows(0)(3).ToString()
                        txtpatente.Text = TablaCheck.Rows(0)(4).ToString()
                        txtempresa.Text = TablaCheck.Rows(0)(5).ToString()
                        horalleg.Text = TablaCheck.Rows(0)(6).ToString()
                        txtTempTermo.Text = TablaCheck.Rows(0)(7).ToString()

                        If IsNumeric(txtTempTermo.Text) Then
                            If txtTempTermo.Text <= -14 Then
                                txtTempTermo.ForeColor = Color.Red
                                Label55.ForeColor = Color.Red
                                Label55.Enabled = True
                            End If
                        End If

                        'cambio estado del checklist
                        sql = "UPDATE zcheckList SET cl_estfrigo='1' WHERE cl_fol='" + valorRecibido + "'"
                        fnc.MovimientoSQL(sql)

                    Else
                        CancelaCorrelativo("006", TxtCodRece.Text)
                        TxtCodRece.Text = ""
                        txtCodRece2.Text = TxtCodRece.Text
                        TxtCodRece.Focus()
                        Exit Sub
                    End If

                    valorRecibido = ""
                    TxtCodRece.Enabled = False
                    btn_guardar.Enabled = True
                    btn_guardar2.Enabled = True
                    Gb_Encabezado.Enabled = True
                    Lbl_EstadoGuia.Text = "ACTIVA"
                    Lbl_EstadoGuia2.Text = "ACTIVA"
                    Lbl_EstadoGuia.ForeColor = Color.Blue
                    Lbl_EstadoGuia2.ForeColor = Color.Blue
                    txtrutchofer.Enabled = False
                    TxtClirut.Enabled = False
                    TimeAdicionales.Enabled = True
                End If

                btn_BuscaCliente.Enabled = True
                Btn_BuscaContrato.Enabled = True
                Btn_BuscaChofer.Enabled = True

                If horainic.Text.Trim = "" Then
                    horainic.Text = DevuelveHora()
                End If
                Dim sqlDel As String = "DELETE FROM TMP_SERVICIOS WHERE Serv_folio='" + TxtCodRece.Text + "'"
                fnc.MovimientoSQL(sqlDel)
                insertarTemporalServicios()
            Else
                Exit Sub
            End If
        Else
            SoloNumeros(sender, e)
        End If
    End Sub

    Private Sub Frm_recepción_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CMBESTPA.SelectedIndex = 0
        CargarCombobox()
        txtResponsable.Text = fnc.DevuelveUsuario(id_global.ToString)
        fecharece.Value = fnc.DevuelveFechaServidor()
        'DataAdicionales.DataSource = fnc.ListarTablasSQL("SELECT 'False' AS Dvas_Est ,Serv_Cod, Serv_Nom,'0' AS Dvas_Unid, " & _
        '                                                 "'0' AS dvas_cajas,'0' AS dvas_kilos FROM FacServicios WHERE " & _
        '                                                 "isnull(Serv_OrdR,0) >'0' ORDER BY Serv_ordr ASC")
        TxtCodRece.Focus()


        cbonumtun.Text = ""
        Me.AutoScroll = True
        Cmbo_Almacenamiento.SelectedValue = 2
        Cmbotiporece.SelectedValue = 1
    End Sub

    Public Sub CargarCombobox()

        Cmbotiporece.DataSource = fnc.ListarTablasSQL("SELECT IdRecepcion , DescripcionRecepcion FROM P_TipoRecepcion ORDER BY IdRecepcion DESC")
        Cmbotiporece.ValueMember = "IdRecepcion"
        Cmbotiporece.DisplayMember = "DescripcionRecepcion"

        Cmbo_Almacenamiento.DataSource = fnc.ListarTablasSQL("SELECT id, almacenamiento FROM P_tipoalmacenamiento ORDER BY id ASC")
        Cmbo_Almacenamiento.ValueMember = "id"
        Cmbo_Almacenamiento.DisplayMember = "almacenamiento"

        cmbo_descarga.DataSource = fnc.ListarTablasSQL("SELECT tcar_codi, tcar_descr FROM P_TipoCargaDescarga ORDER BY tcar_codi ASC")
        cmbo_descarga.ValueMember = "tcar_codi"
        cmbo_descarga.DisplayMember = "tcar_descr"

        CmboTuneles.DataSource = fnc.ListarTablasSQL("SELECT IdTunel, Tunel FROM P_TipoTunel ORDER BY idTunel ASC")
        CmboTuneles.ValueMember = "IdTunel"
        CmboTuneles.DisplayMember = "Tunel"

        cmbAnden.DataSource = fnc.ListarTablasSQL("SELECT cam_codi, cam_descr FROM camaras WHERE cam_codi>='71' AND cam_codi<='80' ORDER BY cam_descr ASC")
        cmbAnden.ValueMember = "cam_codi"
        cmbAnden.DisplayMember = "cam_descr"

        cbonumtun.DataSource = fnc.ListarTablasSQL("select cam_descr from camaras where cam_descr  like'TUNEL%'")
        cbonumtun.ValueMember = "cam_descr"
        cbonumtun.DisplayMember = "cam_descr"


    End Sub

    Private Sub Frm_recepción_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If TxtCodRece.Text <> "" AndAlso TxtCodRece.Enabled = False Then
            If fnc.verificaExistencia("fichrece", "frec_codi", CerosAnteriorString(TxtCodRece.Text, 7)) = False Then

                If fnc.verificaExistencia("fichrece", "frec_codi", TxtCodRece.Text) = False Then

                    If MsgBox("Esta seguro de salir sin guardar la información", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbNo Then
                        e.Cancel = True
                    Else
                        CancelaCorrelativo("006", TxtCodRece.Text)

                        'libero estado del checklist
                        Dim sql As String = "UPDATE zcheckList SET cl_estfrigo='0' WHERE cl_fol='" + TxtFolioPorteria.Text + "'"
                        fnc.MovimientoSQL(sql)

                        Dim SqlEliminaTMPDETA As String = "DELETE FROM TmpDetaRece WHERE frec_codi='" + TxtCodRece.Text + "'"
                        fnc.MovimientoSQL(SqlEliminaTMPDETA)

                        sql = "DELETE FROM TmpFichrece WHERE frec_codi='" + TxtCodRece.Text + "'"
                        fnc.MovimientoSQL(sql)

                        sql = "DELETE FROM chk_imagesopo WHERE LEFT(id_pallets,7)='" + TxtCodRece.Text + "' "
                        fnc.MovimientoSQL(sql)

                        sql = "DELETE FROM detareceestado WHERE LEFT(rtraq_codi,7)='" + TxtCodRece.Text + "'"
                        fnc.MovimientoSQL(sql)

                        sql = "DELETE FROM detarececajas WHERE LEFT(caj_Pcod,7)='" + TxtCodRece.Text + "'"
                        fnc.MovimientoSQL(sql)

                        sql = "DELETE FROM TMP_SERVICIOS WHERE Serv_folio='" + TxtCodRece.Text + "'"
                        fnc.MovimientoSQL(sql)

                        sql = "DELETE FROM receimagen WHERE rimg_rececodi = '" + TxtCodRece.Text + "'"
                        fnc.MovimientoSQL(sql)

                        TimeAdicionales.Enabled = False
                    End If
                Else
                    TimeAdicionales.Enabled = False
                End If
            Else
                TimeAdicionales.Enabled = False
            End If
        Else
            TimeAdicionales.Enabled = False
        End If
    End Sub

    Private Sub btn_BuscaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_BuscaCliente.Click
        Dim frm As New Lst_AyudaClientes
        Dim res As DialogResult = frm.ShowDialog()

        If frm.resultado = "OK" Then
            Me.valorRecibido = frm.IdPrincipal
        End If

        If Len(valorRecibido) >= 9 Then

            Dim SqlBusca As String = "SELECT cli_nomb, cli_estado FROM clientes WHERE " & _
                                     "cli_rut='" + valorRecibido + "'"

            Dim tabla As DataTable = fnc.ListarTablasSQL(SqlBusca)

            If tabla.Rows.Count > 0 Then
                If tabla.Rows(0)(1).ToString() = "N" Then
                    MsgBox("El cliente seleccionado se encuentra bloqueado", MsgBoxStyle.Critical, "Aviso")
                    Exit Sub
                End If

                TxtClirut.Text = valorRecibido
                txtclinom.Text = tabla.Rows(0)(0).ToString()
                Btn_BuscaContrato.Enabled = True
                valorRecibido = ""

                If horainic.Text.Trim = ":" Then
                    horainic.Text = DevuelveHora()
                End If
                txtcodcontrato.Text = ""
                txtnom_contrato.Text = ""
                TxtClirut.Enabled = False
            Else
                MsgBox("El rut ingresado no existe", MsgBoxStyle.Information, "Aviso")
            End If
        End If
        valorRecibido = ""
    End Sub

    Private Sub Btn_BuscaContrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_BuscaContrato.Click

        Dim frm As New Lst_AyudaContratos
        frm.filtro = "WHERE  cont_rutclie='" + QuitarCaracteres(TxtClirut.Text) + "'"
        Dim res As DialogResult = frm.ShowDialog()


        If frm.resultado = "OK" Then
            Me.valorRecibido = frm.IdPrincipal
        End If




        Dim sql As String = " SELECT cont_descr, cont_tempcon, cont_tempgra, Hor_SRI, Hor_SRT, Hor_FRI, Hor_FRT, cont_bloqimp " & _
                            " FROM contrato, contratosHorarios WHERE cont_codi=Hor_Contcod AND cont_codi='" + valorRecibido.ToString() + "'"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

        If tabla.Rows.Count > 0 Then
            txtcodcontrato.Enabled = False
            txtcodcontrato.Text = valorRecibido.ToString
            txtnom_contrato.Text = tabla.Rows(0)(0).ToString()
            TxtTemp.Text = tabla.Rows(0)(1).ToString()
            TxtTempGracia.Text = tabla.Rows(0)(2).ToString()
            LV_horini.Text = tabla.Rows(0)(3).ToString()
            LV_ter.Text = tabla.Rows(0)(4).ToString()
            SA_HorIni.Text = tabla.Rows(0)(5).ToString()
            Sab_HorTer.Text = tabla.Rows(0)(6).ToString()

            If tabla.Rows(0)(7).ToString() = "1" Then
                Cmbotiporece.SelectedValue = 2
                Cmbotiporece.Enabled = False
            Else
                Cmbotiporece.Enabled = True
            End If

        End If
        valorRecibido = ""
    End Sub

    Private Sub Btn_BuscaChofer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_BuscaChofer.Click
        Dim frm As New Lst_AyudaChoferes
        Dim res As DialogResult = frm.ShowDialog()


        If frm.resultado = "OK" Then
            Me.valorRecibido = frm.IdPrincipal
        End If

        If Len(valorRecibido) >= 9 Then

            Dim SqlBusca As String = " SELECT cho_nombre, cho_patente, cho_empresa  FROM Choferes WHERE " & _
                                     " cho_rut='" + valorRecibido + "'"

            Dim tablaBuscaChofer As DataTable = fnc.ListarTablasSQL(SqlBusca)

            If tablaBuscaChofer.Rows.Count > 0 Then
                txtrutchofer.Text = valorRecibido
                txtnombrechofer.Text = tablaBuscaChofer.Rows(0)(0).ToString()
                txtpatente.Text = tablaBuscaChofer.Rows(0)(1).ToString()
                txtempresa.Text = tablaBuscaChofer.Rows(0)(2).ToString()
                txtrutchofer.Enabled = False
            End If

        End If
        valorRecibido = ""
    End Sub

    Function retornasanitario() As String
        retornasanitario = ""

        If Cb_OloresExtraños.CheckState = CheckState.Checked Then
            retornasanitario = retornasanitario & "11,"
        Else
            retornasanitario = retornasanitario & "10,"
        End If

        If Rb_higieneB.Checked = True Then
            retornasanitario = retornasanitario & "20,"
        Else
            retornasanitario = retornasanitario & "21,"
        End If

        If Rb_EstibaB.Checked = True Then
            retornasanitario = retornasanitario & "30"
        Else
            retornasanitario = retornasanitario & "31"
        End If

        Return retornasanitario

    End Function

    Function validacion() As Integer
        Dim numero As Integer = 0
        If Cmbotiporece.SelectedIndex = 2 Then


            If CHKEMB.Checked = True Then
                If TxtContenedor.Text = "" Then
                    mensaje = mensaje & vbCrLf & "- Debe ingresar un numero de Embarque valido"
                    numero += 1

                End If
            Else

                'If (TxtContenedor.Text = "" Or ValidadorContenedor(TxtContenedor.Text.Trim) = False) Then
                '    mensaje = mensaje & vbCrLf & "- Debe ingresar un numero de contenedor valido"
                '    numero += 1
                'End If
            End If
        End If
        If Cmbo_Almacenamiento.SelectedValue = 0 Then
            mensaje = mensaje & vbCrLf & "- Tipo de almacenamiento "
            numero += 1
        End If

        If Cmbotiporece.SelectedValue = 4 Then
            mensaje = mensaje & vbCrLf & "- Tipo de recepción "
            numero += 1
        End If

        If txtorigen.Text = "" Then
            mensaje = mensaje & vbCrLf & "- Tipo de Origen "
            numero += 1
        End If
        If cbonumtun.Enabled = True Then
            If cbonumtun.Text = "" Then
                mensaje = mensaje & vbCrLf & "- Numero de Tunel"

                numero += 1
            End If
        End If
        If datosguia = "1" Then
            If txtenvguia.Text = "" Then
                mensaje = mensaje & vbCrLf & "- Envases de guia "
                numero += 1

            End If
            If txtkilguia.Text = "" Then
                mensaje = mensaje & vbCrLf & "- Kilos de guia "
                numero += 1


            End If
        End If
        If ValidarHora(horainic.Text) = False Then
            mensaje = mensaje & vbCrLf & "- Hora de inicio correcta "
            numero += 1
        End If

        If txtclinom.Text = "" Then
            mensaje = mensaje & vbCrLf & "- Seleccionar un cliente"
            numero += 1
        End If

        If txtnom_contrato.Text = "" Then
            mensaje = mensaje & vbCrLf & "- Contrato correspondiente al cliente"
            numero += 1
        End If

        If txtcodcontrato.Text = "" Then
            mensaje = mensaje & vbCrLf & "- Contrato correspondiente al cliente"
            numero += 1
        End If


        If txtnombrechofer.Text = "" Then
            mensaje = mensaje & vbCrLf & "- Chofer "
            numero += 1
        End If

        If txtguia.Text = "" Then
            mensaje = mensaje & vbCrLf & "- Guia cliente no ingresada"
            numero += 1
        End If

        If IsNothing(cmbo_descarga.SelectedValue) Then
            mensaje = mensaje & vbCrLf & "- Tipo de descarga "
            numero += 1
        End If


        If txtsello.Text = "" Then
            mensaje = mensaje & vbCrLf & "- N° de sello"
            numero += 1
        End If

        If Rb_higieneB.Checked = False AndAlso Rb_higieneM.Checked = False Then
            mensaje = mensaje & vbCrLf & "- Estado de higiene"
            numero += 1
        End If

        If Rb_EstibaB.Checked = False AndAlso Rb_EstibaM.Checked = False Then
            mensaje = mensaje & vbCrLf & "- Estado de la estiba"
            numero += 1
        End If

        If Cb_OloresExtraños.Checked = True AndAlso Rb_EstibaM.Checked = True AndAlso Rb_higieneM.Checked = True AndAlso cbdañado.Checked = True Then
            mensaje = mensaje & vbCrLf & "- Este Producto Estaria Rechazado por su estado (Olores, Producto dañado, Higiene malo, etc.)"
            numero += 1
        End If

        If IsNumeric(TxtFilm.Text) AndAlso IsNumeric(txtsoportantes.Text) Then
            If Val(TxtFilm.Text) > Val(txtsoportantes.Text) Then
                mensaje = mensaje & vbCrLf & "- Cantidad de postura de film es mayor al total de recepcion"
                numero += 1
            End If
        End If

        If IsNumeric(TxtArriendo.Text) AndAlso IsNumeric(txtsoportantes.Text) Then
            If Val(TxtArriendo.Text) > Val(txtsoportantes.Text) Then
                mensaje = mensaje & vbCrLf & "- Cantidad de pallets agregados al arriendo " + vbCrLf & _
                    "es mayor al total de pallets de la recepcion"
                numero += 1
            End If
        End If

        If IsNumeric(TxtRepa.Text) AndAlso IsNumeric(txtsoportantes.Text) Then
            If Val(TxtRepa.Text) > Val(txtsoportantes.Text) Then
                mensaje = mensaje & vbCrLf & "- Cantidad de repaletizados agregados  " + vbCrLf & _
                    "es mayor al total de pallets de la recepcion"
                numero += 1
            End If
        End If
        If CHKEMB.Checked = True Then
            If TxtContenedor.Text = "" Then
                mensaje = mensaje & vbCrLf & "- Debe ingresar un numero de Embarque valido"
                numero += 1

            End If
        Else
            'If (TxtContenedor.Text = "" Or ValidadorContenedor(TxtContenedor.Text.Trim) = False) AndAlso Cmbotiporece.Enabled = False Then
            '    mensaje = mensaje & vbCrLf & "- Debe ingresar un numero de contenedor valido"
            '    numero += 1
            'End If
        End If


        If numero > 0 Then
            MsgBox(mensaje, MsgBoxStyle.Critical, "Aviso")
        End If


        mensaje = ""

        Return numero
    End Function

    Private Sub validar()

        If fnc.verificaExistencia("fichrece", "frec_codi", CerosAnteriorString(TxtCodRece.Text, 7)) = True Then
            Exit Sub
        End If

        If tab_recepcion.SelectedIndex = 1 Then
            mensaje = "Debe ingresar lo siguiente antes de agregar el detalle"
            If validacion() > 0 Then
                tab_recepcion.SelectedIndex = 0
                mensaje = ""
            Else
                'guarda TMPFICHRECE
                If fnc.verificaExistencia("TMPFICHRECE", "frec_codi", TxtCodRece.Text) = True Then

                    Dim SqlTemporal As String = "UPDATE TMPFICHRECE SET frec_rutcli='" + QuitarCaracteres(TxtClirut.Text) + "', " & _
                        " frec_contcli='" + txtcodcontrato.Text + "', " & _
                        " frec_fecproc='" + devuelve_fecha(fecharece.Value) + "', " & _
                        " frec_fecrec='" + devuelve_fecha(fecharece.Value) + "', " & _
                        " frec_guiades='" + txtguia.Text + "', " & _
                        " frec_totsopo='0', frec_totunidad='0', frec_totpeso='0', " & _
                        " frec_temppro='" + TxtPromTemp.ToString().Replace(",", ".") + "', frec_rutcond='" + QuitarCaracteres(txtrutchofer.Text) + "', " & _
                        " frec_observ='" + Txtobs.Text.Trim + "', frec_tipdesc='" + cmbo_descarga.SelectedValue.ToString() + "', frec_origen='" + txtorigen.Text + "', " & _
                        " frec_codvig='0', frec_radio='0', frec_tipo='" + Cmbotiporece.SelectedValue.ToString() + "', " & _
                        " frec_RecepTunel='" + CmboTuneles.SelectedValue.ToString() + "', frec_AspectoSanitario='" + retornasanitario() + "', frec_CondGeneral='0', " & _
                        " Est_Codi='0',frec_UsuCre='" + Convert.ToString(id_global) + "', " & _
                        " FREC_NUMSELLO='" + txtsello.Text + "', frec_tipoalmacenamiento='" + Cmbo_Almacenamiento.Text.ToString() + "', frec_contenedor='" + TxtContenedor.Text + "' " & _
                        " where frec_codi='" + TxtCodRece.Text + "'"

                    fnc.MovimientoSQL(SqlTemporal)
                    If Cmbotiporece.Enabled = False Then
                        txtcodsag.Text = TxtContenedor.Text
                    End If

                    If cmbo_descarga.SelectedValue.ToString() = "1" Then
                        CheckArriendo.Checked = True
                    Else
                        CheckArriendo.Checked = False
                    End If
                Else


                    Dim SqlTemporal As String = "INSERT INTO TMPFICHRECE (frec_codi, frec_rutcli, frec_contcli, frec_horalleg, frec_horarec, " & _
                        "frec_fecrec, frec_guiades, frec_totsopo, frec_totunidad, frec_totpeso, " & _
                        "frec_temppro, frec_rutcond, frec_observ, frec_tipdesc, frec_origen, frec_tipo, " & _
                            "frec_RecepTunel, frec_AspectoSanitario, Est_Codi, frec_FecCre, frec_UsuCre, frec_FecMod, " & _
                            "FREC_NUMSELLO, frec_tipoalmacenamiento, frec_clfol, frec_contenedor)" & _
                            "VALUES('" + TxtCodRece.Text + "','" + QuitarCaracteres(TxtClirut.Text) + "','" + txtcodcontrato.Text + "' ,'" + horalleg.Text + "' ," & _
                            "'" + horainic.Text + "','" + devuelve_fecha(fecharece.Value) + "', " & _
                            "'" + txtguia.Text + "' ,'0' ,'0' ,'0' ,'" + TxtPromTemp.ToString().Replace(",", ".") + "' ,'" + QuitarCaracteres(txtrutchofer.Text) + "' ,'" + Txtobs.Text.Trim + "' ," & _
                            "'" + cmbo_descarga.SelectedValue.ToString() + "' ,'" + txtorigen.Text + "','" + Cmbotiporece.SelectedValue.ToString() + "' ," & _
                            "'" + CmboTuneles.SelectedValue.ToString() + "' ,'" + retornasanitario() + "','0',GETDATE(),'" + Convert.ToString(id_global) + "'," & _
                            "GETDATE(),'" + txtsello.Text + "','" + Cmbo_Almacenamiento.Text.ToString() + "','" + TxtFolioPorteria.Text + "','" + TxtContenedor.Text + "')"


                    fnc.MovimientoSQL(SqlTemporal)

                    If Cmbotiporece.Enabled = False Then
                        txtcodsag.Text = TxtContenedor.Text
                    End If
                End If
                btn_BuscaCliente.Enabled = False
            End If
        End If


        'EJECUTO LA FUNCION ADICIONALES PARA ACTUALIZAR LOS SERVICIOS
        'adicionales()
    End Sub

    Private Sub Btn_buscaProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_buscaProducto.Click
        Dim frm As New Lst_AyudaProductos
        frm.filtro = "mae_clirut='" + QuitarCaracteres(TxtClirut.Text) + "' "
        Dim res As DialogResult = frm.ShowDialog()


        If frm.resultado = "OK" Then
            Me.valorRecibido = frm.IdPrincipal
        End If

        If valorRecibido <> "" Then
            Me.txtprodcod.Text = valorRecibido

            Dim sqlBusca = "SELECT mae_descr, mae_diasv FROM maeprod WHERE mae_codi='" + txtprodcod.Text + "'"

            Dim tabla As DataTable = fnc.ListarTablasSQL(sqlBusca.ToString)
            If tabla.Rows.Count > 0 Then
                txtprodnom.Text = tabla.Rows(0)(0).ToString()

                If Convert.ToInt32(tabla.Rows(0)(1).ToString()) > 0 Then
                    fvencimiento.Value = DateAdd(DateInterval.Month, Convert.ToInt32(tabla.Rows(0)(1).ToString()), felaboracion.Value)
                    DiasVenc = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    fvencimiento.Enabled = False
                Else
                    fvencimiento.Enabled = True
                End If

            End If

        End If
        valorRecibido = ""
    End Sub

    Private Sub btn_validar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        validar()
    End Sub

    Public Sub limpiarFormulario()
        CargarCombobox()
        LimpiarCajas(Gb_Cliente)

        Rb_higieneB.Checked = True
        Rb_EstibaB.Checked = True
        cbonumtun.Text = ""
        Me.AutoScroll = True
        Cmbo_Almacenamiento.SelectedValue = 2
        Cmbotiporece.SelectedValue = 1

        DetaRece.DataSource = Nothing
        txtrutchofer.Enabled = True
        txtrutchofer.Text = ""
        cbonumtun.Text = ""
        cbonumtun.Enabled = False
        txtsoportantes.Text = "0"
        txtcajas.Text = "0"
        txtkilos.Text = "0"
        TxtPromTemp = "0"

        'Cb_tunel.CheckState = 0
        Cb_OloresExtraños.CheckState = 0
        cbdañado.CheckState = 0

        Rb_higieneB.Checked = False
        Rb_higieneM.Checked = False
        lblenvguia.Visible = False
        lblkilguia.Visible = False
        txtenvguia.Visible = False
        txtkilguia.Visible = False
        datosguia = "0"
        chkdatosguia.Checked = False
        Rb_EstibaB.Checked = False
        Rb_EstibaM.Checked = False

        horainic.Text = ""
        horalleg.Text = ""

        fecharece.Value = fnc.DevuelveFechaServidor()
        Gb_Encabezado.Enabled = False
        Gb_Encabezado.Enabled = True
        Gb_Cliente.Enabled = True
        Gb_observacion.Enabled = True

        btn_guardar.Enabled = False
        btn_guardar2.Enabled = False

        TxtCodRece.Text = ""
        txtCodRece2.Text = TxtCodRece.Text
        TxtCodRece.Enabled = True
        TxtCodRece.Focus()
        Txtobs.Text = ""
        TxtClirut.Text = ""
        TxtClirut.Enabled = True
        txtcodcontrato.Enabled = True
        TxtFolioPorteria.Text = ""
        'LimpiarCajas(Panel5)
        Cmbotiporece.Enabled = True
        TxtPallet.Text = ""
        TxtNpallets = "0"
        TxtPromTemp = "0"

        Gb_soportante.Enabled = False

        largo_global = 0
        txtidetiqueta.Text = ""
        txtetiquetacliente.Text = ""
        txtdescripcionetiqueta.Text = ""

        Lbl_EstadoGuia.ForeColor = Color.Gold
        Lbl_EstadoGuia2.ForeColor = Color.Gold


    End Sub

    Private Sub Btn_buscasoportante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_buscasoportante.Click
        Dim frm As New Lst_AyudaSoportantes
        frm.ShowDialog()
        If frm.resultadosop = "OK" Then
            txtsopcodi.Text = frm.IdPrincipalsop
            txtsopnombre.Text = frm.NombrePrincipalsop
        End If
        If frm.resultadosop = "NO" Then
            txtsopcodi.Text = ""
            txtsopnombre.Text = ""
        End If
    End Sub

    Private Sub txtsopclie_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            felaboracion.Focus()
        End If
    End Sub

    Private Sub txtunid_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            kg.Focus()
        End If
    End Sub

    Private Sub txtunid_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        SoloNumeros(sender, e)
    End Sub

    Private Sub kg_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            loteclie.Focus()
        End If
    End Sub

    Private Sub kg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(13) Then
            loteclie.Focus()
        Else
            Dim KeyAscii As Short = Asc(e.KeyChar)
            If Not ((KeyAscii >= System.Windows.Forms.Keys.D0 And KeyAscii <= System.Windows.Forms.Keys.D9) Or (KeyAscii = System.Windows.Forms.Keys.Back) Or Chr(KeyAscii) = "." Or (Chr(KeyAscii) Like "[ ]")) Then
                KeyAscii = 0
                kg.Focus()
            End If
            If KeyAscii = 0 Then
                e.Handled = True
            End If

            If kg.Text.IndexOf(".") >= 0 And e.KeyChar = "." Then
                e.Handled = True
            End If

            If kg.Text.IndexOf(".") > 0 Then
                If kg.SelectionStart > kg.Text.IndexOf(".") Then
                    If kg.Text.Length - kg.Text.IndexOf(".") = 3 Then
                        e.Handled = True
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub loteclie_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            txtcodsag.Focus()
        End If
    End Sub

    Private Sub txtcodsag_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Btn_GuardaDetalle.Focus()
        End If
    End Sub

    Private Sub chkpretrack_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkpretrack.CheckStateChanged
        If chkpretrack.Checked = True Then
            txttrackprev.Text = ""
            txttrackprev.Enabled = True
            txttrackprev.Focus()

        ElseIf chkpretrack.Checked = False Then
            txttrackprev.Text = ""
            txttrackprev.Enabled = False

        End If
    End Sub

    Private Sub txttrackprev_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        SoloNumeros(sender, e)
    End Sub

    Function ValidadorContenedor(ByVal contenedor As String) As Boolean 'Formato PONU 894235-8
        ValidadorContenedor = 0
        Dim cont As String = contenedor
        Dim dig As Integer = 0

        If contenedor.Length <> 13 Then
            ValidadorContenedor = False
        Else
            Dim arrayLetter() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
            Dim arrayValor() As Integer = {10, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 34, 35, 36, 37, 38}
            Dim numeros() As Integer = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
            Dim numerosMult() As Integer = {1, 2, 4, 8, 16, 32, 64, 128, 256, 512}

            Dim suma_numeros = 0
            Dim j = 0

            ' REEMPLAZO LOS VALORES DE LAS LETRAS POR LOS NUMEROS Y DEJO LOS NUMEROS IGUAL
            For a As Integer = 0 To contenedor.Length - 3
                If a < 4 Then
                    For i As Integer = 0 To arrayLetter.Length - 1
                        If arrayLetter(i) = contenedor.Chars(a) Then
                            numeros(a) = arrayValor(i)
                            Exit For
                        End If
                    Next
                ElseIf a > 4 Then
                    Dim z = contenedor.Chars(a)
                    numeros(a - 1) = Val(z)

                End If
            Next

            For i As Integer = 1 To numeros.Length
                suma_numeros = suma_numeros + (Convert.ToInt32(numeros(i - 1)) * numerosMult(i - 1))
                Console.WriteLine((Convert.ToInt32(numeros(i - 1)) * numerosMult(i - 1)))
            Next

            Dim comparar As Integer = Int(suma_numeros / 11)
            dig = suma_numeros - (comparar * 11)
            If dig = 10 Then
                dig = 0
            End If
            If dig = Val(cont.Chars(cont.Length - 1)) Then
                ValidadorContenedor = True
            End If
        End If

        ' retorno 1- formato incorrecto
        Return ValidadorContenedor
    End Function

    Private Sub Imprimir()

        'ASIGNAR(VALORES)


        CLIENTE = txtclinom.Text
        PRODUCTO = txtprodnom.Text
        FOLIOCLIENTE = txtsopclie.Text
        UNIDADESACTUALES = txtunid.Text
        UNIDADESRECE = txtunid.Text
        KG2 = kg.Text
        FPRO = Convert.ToDateTime(felaboracion.Value).ToShortDateString()
        FVEN = Convert.ToDateTime(fvencimiento.Value).ToShortDateString()
        CODIGOLARGO = DigitoVerificadorEAN128UCC("1780000000" + CerosAnteriorString(CerosAnteriorString(TxtPallet.Text, 2), 7))

        Dim print1 As PrintCE
        Dim y As Double = 0.0

        Try
            print1 = New PrintCE
        Catch x As Exception
            MessageBox.Show(x.Message, "Error")
            Return
        End Try
        print1.Init("My license key")
        print1.Language = mCurLang
        print1.MeasureUnit = MeasureUnit.kInches

        If configuracionimpresora = False Then
            If print1.SetupDlg(Me.Handle) = False Then
                print1.UnInit()
                Return
            End If
            configuracionimpresora = True
        End If
        print1.StartDoc()
        print1.StartPage()
        print1.FontSize = 14.0
        print1.FontBold = True
        y += 0.1
        print1.DrawAlignedText("PRECISA FROZEN", print1.PageWidth / 2, y, TextHorAlign.hCenter, TextVertAlign.vTop)
        y += print1.GetTextHeight("PRECISA FROZEN")

        print1.FontBold = False
        print1.FontSize = 9.0
        y += 0.3
        print1.DrawText("CLIENTE          :" + CLIENTE, 0, y)
        y += 0.2
        print1.DrawText("PRODUCTO       :" + PRODUCTO, 0, y)
        y += 0.2
        print1.DrawText("FOLIO CLIENTE :" + FOLIOCLIENTE + " UND:" + UNIDADESACTUALES + "/" + UNIDADESRECE + " KG:" + KG2, 0, y)
        y += 0.2
        print1.DrawText("F.PRODUCCION :" + FPRO + " F.VENCIMIENTO: " + FVEN, 0, y)
        y += 0.2
        print1.FontSize = 24.0
        print1.DrawText("PALLET:", 0, y)
        y += 0.3
        print1.FontSize = 56.0
        print1.DrawText(TxtPallet.Text, 0, y)
        y += 0.9
        print1.FontSize = 68.0
        print1.DrawCode128(CODIGOLARGO, 0, y, True, 68)
        y += 0.7
        print1.FontSize = 12.0
        y += 0.9
        print1.FontBold = False
        print1.FontSize = 9.0
        print1.EndDoc()
        print1.UnInit()


    End Sub

    Private Sub SumaTotalPallets()
        '6 cajas 7 kilos

        Dim SumaCajas As Integer = 0
        Dim SumaKilos As Double = 0.0

        For i As Integer = 0 To detareceaux.Rows.Count - 1
            SumaCajas = SumaCajas + detareceaux.Rows(i)(5).ToString()
            SumaKilos = SumaKilos + Convert.ToDouble(detareceaux.Rows(i)(6).ToString())
        Next

        txtsoportantes.Text = detareceaux.Rows.Count
        txtcajas.Text = SumaCajas.ToString
        txtkilos.Text = SumaKilos.ToString().Replace(",", ".")
        txtunidadesdet.Text = txtcajas.Text
        txtkilosdet.Text = txtkilos.Text

    End Sub

    Private Sub LimpiarProductoIngreso()

        'txtsopclie.Text = ""
        txtsopclie.SelectAll()
        txtunid.Text = ""
        kg.Text = ""
        TxtPallet.Text = ""
        CMBESTPA.SelectedIndex = 0
        'CheckArriendo.Checked = False
    End Sub

    Private Sub CargaGrillaDetalle()
        DetaRece.DataSource = Nothing
        Dim sql As String = "SELECT frec_codi+''+drec_codi AS Pallet, drec_codPro, mae_descr, " & _
            "drec_codsopo, tsop_descr, drec_unidades, drec_peso, CONVERT(datetime,drec_fecprod,111) AS drec_fecprod, " & _
            "CONVERT(datetime,fechavencimiento,111) AS fechavencimiento, LoteCliente, drec_codsag, drec_sopocli," & _
            "isnull(drec_temp,'0') as drec_temp, drec_arriendo,estpallet " & _
            "FROM TMPDETARECE, tiposopo, maeprod " & _
            "WHERE drec_codpro=mae_codi AND convert(int,tsop_codi)=convert(int,drec_codsopo) AND frec_codi='" + TxtCodRece.Text + "' ORDER BY drec_codi ASC"
        DetaRece.DataSource = fnc.ListarTablasSQL(sql)
        detareceaux = fnc.ListarTablasSQL(sql)
        SumaTotalPallets()
    End Sub

    Private Sub insertadetarececajas()

        Dim query As String = ""

        Dim sql As String = "Select etiquetacompleta from t_tracking where IdEtiquetaAutoIncrement='" + txttrackprev.Text.Trim() + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQLEtiquetado(sql)

        If tabla.Rows.Count > 0 Then



            For i As Integer = 0 To tabla.Rows.Count - 1


                query = "INSERT INTO DetareceCajas (Caj_Pcod, Caj_cod, caj_codenca,val_pretrack)VALUES('" + TxtCodRece.Text.Trim() + NumeroPallet.ToString() + "','" + tabla.Rows(i)(0).ToString() + "','" + Convert.ToString(id_global) + "','" + txttrackprev.Text.Trim() + "')"
                fnc.MovimientoSQL(query)
            Next

        Else

            MsgBox("El Codigo De Pretraqueo No existe, No se añadio traqueo automatico", MsgBoxStyle.Critical, "Aviso")

        End If



    End Sub

    Private Sub calcularpesocial()

        Dim sqlNumero As String = "select mae_pcaja from maeprod where mae_descr='" + txtprodnom.Text + "'"
        Dim tablaNumero As DataTable = fnc.ListarTablasSQL(sqlNumero)

        If tablaNumero.Rows.Count > 0 Then
            Dim peso1 As Double = Convert.ToDouble(tablaNumero.Rows(0)(0).ToString())
            Dim pes As Integer = 0

            pes = peso1 * txtunid.Text
            kg.Text = Replace(kg.Text, ".", ",")
            pes = Convert.ToDecimal(kg.Text) - (peso1 * txtunid.Text)
            pes = pes - pesopa
            kg.Text = pes.ToString()

        Else
        End If

    End Sub

    Private Sub traepesopallet()
        Dim sqlNumero As String = "select pesoPallet from tiposopo where tsop_codi='" + txtsopcodi.Text + "'"
        Dim tablaNumero As DataTable = fnc.ListarTablasSQL(sqlNumero)

        If tablaNumero.Rows.Count > 0 Then
            pesopa = tablaNumero.Rows(0)(0).ToString()

        Else
        End If
    End Sub

    Function validacionDetalle() As Integer
        Dim valor As Integer = 0

        Dim mensaje As String = "Debe ingresar lo siguiente antes de agregar el pallet " & vbCrLf




        If txtprodcod.Text = "" Then
            mensaje = mensaje + "- Producto " & vbCrLf
            valor += 1
        End If

        If txtsopcodi.Text = "" Then
            mensaje = mensaje + "- Soportante actual " & vbCrLf
            valor += 1
        End If

        If chkpretrack.Checked = True Then
            If txttrackprev.Text = "" Then

                mensaje = mensaje + "- Ingrese etiqueta de traqueo previo " & vbCrLf
                valor += 1
            Else
                Dim sqltra As String = "SELECT * from detarececajas WHERE val_pretrack='" + txttrackprev.Text.Trim() + "'"
                Dim tablatra As DataTable = fnc.ListarTablasSQL(sqltra)

                If tablatra.Rows.Count > 0 Then
                    mensaje = mensaje + "- Etiqueta de traqueo previo ya usada  " & vbCrLf
                    valor += 1
                End If

            End If
        End If
        If chkpretrack.Checked = True Then
            Dim sql As String = "Select etiquetacompleta from t_tracking where IdEtiquetaAutoIncrement='" + txttrackprev.Text.Trim() + "'"
            Dim tabla As DataTable = fnc.ListarTablasSQLEtiquetado(sql)

            If tabla.Rows.Count > 0 Then

                Dim sql2 As String = "Select cantidad,peso from t_tracking2 where IdEtiquetaAutoIncrement='" + txttrackprev.Text.Trim() + "'"
                Dim tabla2 As DataTable = fnc.ListarTablasSQLEtiquetado(sql2)
                If tabla2.Rows.Count > 0 Then

                    If tabla2.Rows(0)(0).ToString() = txtunid.Text.Trim() Then
                    Else
                        'mensaje = mensaje + "- La cantidad de unidades traqueadas no coincide con las agregadas al pallet  " & vbCrLf
                        'valor += 1
                        txtunid.Text = tabla2.Rows(0)(0).ToString().Trim()


                    End If
                    If tabla2.Rows(1)(0).ToString() = txtkilos.Text.Trim() Then
                    Else
                        'mensaje = mensaje + "- La cantidad de unidades traqueadas no coincide con las agregadas al pallet  " & vbCrLf
                        'valor += 1
                        kg.Text = tabla2.Rows(0)(1).ToString().Trim()


                    End If
                End If

            Else
                mensaje = mensaje + "- Etiqueta de traqueo previo No existe  " & vbCrLf
                valor += 1
            End If

        End If

        If txtsopclie.Text = "" Then

        Else
            Dim sqlNumero As String = "SELECT * from TMPDETARECE where drec_sopocli='" + txtsopclie.Text + "'"
            Dim tablaNumero As DataTable = fnc.ListarTablasSQL(sqlNumero)

            If tablaNumero.Rows.Count > 0 Then

                If modifi = "OK" Then
                    modifi = ""
                Else
                    mensaje = mensaje + "- Soportante cliente ya existe en esta recepcion " & vbCrLf
                    valor += 1
                    modifi = ""
                End If

            End If


        End If



        'If txtsopclie.Text = "" Then
        '    mensaje = mensaje + "- Numero de soportante del cliente" & vbCrLf
        '    valor += 1
        'End If

        If felaboracion.Value > fvencimiento.Value Then
            mensaje = mensaje + "- Fecha de vencimiento mayor a la fecha de elaboración " & vbCrLf
            valor += 1
        End If
        If CMBESTPA.SelectedIndex = 0 Then
            mensaje = mensaje + "Seleccione Estado Calidad " & vbCrLf
            valor += 1

        End If

        If chkpretrack.Checked = True Then

        Else
            If txtunid.Text = "" Then
                mensaje = mensaje + "- unidades (cajas, contenedores, recipientes, etc.) " & vbCrLf
                valor += 1
            End If



            If kg.Text = "" Then
                mensaje = mensaje + "- Kilogramos del pallet " & vbCrLf
                valor += 1
            End If


        End If

        If txtunid.Text = "0" Then
            mensaje = mensaje + "- unidades Mayor a 0 " & vbCrLf
            valor += 1
        End If

        If kg.Text = "0" Then
            mensaje = mensaje + "- kilos mayor a 0 " & vbCrLf
            valor += 1
        End If

        If IsNumeric(kg.Text) Then
            If Val(kg.Text) > 1600 Then
                mensaje = mensaje + "- kilos menor a 1600 KG " & vbCrLf
                valor += 1
            End If
        End If

        If fvencimiento.Value <= fnc.DevuelveFechaServidor() Then
            mensaje = mensaje + "- No puede ingresar productos vencidos, o que la fecha de vencimiento sea durante el día " & vbCrLf
            valor += 1
        End If

        If (TxtContenedor.Text = "" Or ValidadorContenedor(TxtContenedor.Text.Trim) = False) AndAlso Cmbotiporece.Enabled = False Then
            mensaje = mensaje & vbCrLf & "- Debe ingresar un numero de contenedor valido"
            valor += 1
        End If
        'If CMBESTPA.SelectedIndex <> 0 Then
        '    mensaje = mensaje & vbCrLf & "- Debe ingresar estado de calidad"
        '    valor += 1
        'End If
        If valor > 0 Then
            MsgBox(mensaje, MsgBoxStyle.Critical, "Aviso")
        End If
        mensaje = ""
        Return valor
    End Function

    Private Sub Btn_GuardaDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_GuardaDetalle.Click
        If validacionDetalle() = 0 Then
            modifi = ""
            If TxtPallet.Text = "" Then
                If fnc.verificaExistencia("fichrece", "frec_codi", TxtCodRece.Text) = True Then
                    MsgBox("No puede ingresar pallets a la recepción", MsgBoxStyle.Critical, "Aviso")
                    '   LimpiarCajas(Panel5)
                    Exit Sub
                End If
                Dim sqlNumero As String = "SELECT MAX(drec_codi) FROM TMPDETARECE WHERE frec_codi='" + TxtCodRece.Text + "'"
                Dim tablaNumero As DataTable = fnc.ListarTablasSQL(sqlNumero)

                If tablaNumero.Rows.Count > 0 Then
                    NumeroPallet = CerosAnteriorString(Val(tablaNumero.Rows(0)(0).ToString()) + 1, 2)
                Else
                    MsgBox("Error al recatar el Correlativo del pallet", MsgBoxStyle.Critical, "Aviso")
                End If
                If TxtClirut.Text = "801863000" Then
                    traepesopallet()
                    calcularpesocial()
                    If Convert.ToInt32(kg.Text) < 0 Then
                        MsgBox("Kilos menor a 0 ", MsgBoxStyle.Critical, "Aviso")
                        Exit Sub

                    End If

                End If
                Dim sqlGuardar As String = "INSERT INTO TMPDETARECE(frec_codi, drec_codi, drec_codpro, drec_origen,  drec_codsopo, drec_sopocli, drec_unidades, drec_peso, " & _
                    "drec_fecrec, drec_rutcli, drec_contcli, drec_fecprod, drec_camara, drec_banda, drec_colum,  drec_piso,  drec_nivel, " & _
                    "drec_tunel, drec_pallet, drec_nrosopo, drec_dtgracia,  drec_codsag, drec_tipo, FechaVencimiento, LoteCliente, drec_codper, drec_hora, drec_arriendo,estpallet) VALUES(" & _
                    "'" + TxtCodRece.Text + "','" + NumeroPallet.ToString() + "','" + txtprodcod.Text + "','" + txtorigen.Text + "'," & _
                    "'" + Val(txtsopcodi.Text).ToString() + "', '" + txtsopclie.Text + "','" + txtunid.Text + "','" + kg.Text + "', " & _
                    "'" + devuelve_fecha(fecharece.Value) + "', '" + QuitarCaracteres(TxtClirut.Text) + "','" + txtcodcontrato.Text + "'," & _
                    "'" + devuelve_fecha(felaboracion.Value) + "','71','00','00','00','0', '" + CmboTuneles.SelectedValue.ToString() + "','0'," & _
                    "'0','" + TxtTemp.Text + "','" + txtcodsag.Text + "', '0', " & _
                    "'" + devuelve_fecha(fvencimiento.Value) + "','" + loteclie.Text + "','" + Convert.ToString(id_global) + "','" + DevuelveHora() + "','" + EstadoCheckBox(CheckArriendo.CheckState) + "','" + CMBESTPA.Text + "')"

                If fnc.MovimientoSQL(sqlGuardar) > 0 Then
                    MsgBox("Pallet agregado correctamente a la recepción", MsgBoxStyle.Information, "Aviso")
                    If chkpretrack.Checked = True Then
                        insertadetarececajas()
                    End If

                    CargaGrillaDetalle()

                    TxtPallet.Text = TxtCodRece.Text + NumeroPallet.ToString()
                    Imprimir()
                    LimpiarProductoIngreso()


                Else
                    MsgBox("Error al agregar el pallet a la recepción", MsgBoxStyle.Critical, "Aviso")
                End If

            Else
                'modifica tmprece
                If fnc.verificaExistencia("detarece", "drec_codi", TxtPallet.Text) = False Then
                    If TxtClirut.Text = "801863000" Then
                        traepesopallet()
                        calcularpesocial()
                        If Convert.ToInt32(kg.Text) < 0 Then
                            MsgBox("Kilos menor a 0 ", MsgBoxStyle.Critical, "Aviso")
                            Exit Sub

                        End If

                    End If
                    Dim sql As String = "UPDATE TMPDETARECE SET drec_codpro='" + txtprodcod.Text + "', " & _
                                      "drec_origen='" + txtorigen.Text + "', drec_codsopo='" + Val(txtsopcodi.Text).ToString() + "', " & _
                                      "drec_sopocli='" + txtsopclie.Text + "', drec_unidades='" + txtunid.Text + "', drec_peso='" + kg.Text.Replace(",", ".") + "', " & _
                                      "drec_fecprod='" + devuelve_fecha(felaboracion.Value) + "', FechaVencimiento='" + devuelve_fecha(fvencimiento.Value) + "', " & _
                                      "LoteCliente='" + loteclie.Text + "', drec_codsag='" + txtcodsag.Text + "', drec_arriendo='" + EstadoCheckBox(CheckArriendo.CheckState) + "' , estpallet='" + CMBESTPA.Text + "' " & _
                                      "WHERE frec_codi='" + TxtCodRece.Text + "' AND drec_codi='" + TxtPallet.Text.Remove(0, 7) + "'"

                    If fnc.MovimientoSQL(sql) > 0 Then
                        MsgBox("Pallet actualizado ", MsgBoxStyle.Information, "Aviso")
                        TxtPallet.Text = ""
                        Btn_GuardaDetalle.Text = "Grabar"
                        btn_eliminardetalle.Enabled = False
                        CargaGrillaDetalle()
                    Else
                        MsgBox("Error al actualizar el pallet ", MsgBoxStyle.Critical, "Aviso")
                    End If
                Else
                    'modifica recepcion
                    If TxtClirut.Text = "801863000" Then
                        traepesopallet()
                        calcularpesocial()
                        If Convert.ToInt32(kg.Text) < 0 Then
                            MsgBox("Kilos menor a 0 ", MsgBoxStyle.Critical, "Aviso")
                            Exit Sub

                        End If

                    End If
                    Dim sql As String = "UPDATE DETARECE SET drec_codpro='" + txtprodcod.Text + "', " & _
                                     "drec_origen='" + txtorigen.Text + "', drec_codsopo='" + Val(txtsopcodi.Text).ToString() + "', " & _
                                     "drec_sopocli='" + txtsopclie.Text + "', drec_unidades='" + txtunid.Text + "', drec_peso='" + kg.Text.Replace(",", ".") + "', " & _
                                     "drec_fecprod='" + devuelve_fecha(felaboracion.Value) + "', FechaVencimiento='" + devuelve_fecha_Formato2(devuelve_fecha(fvencimiento.Value)) + "', Estpallet = '" + CMBESTPA.Text + "', " & _
                                     "LoteCliente='" + loteclie.Text + "', drec_codsag='" + txtcodsag.Text + "', drec_arriendo='" + EstadoCheckBox(CheckArriendo.CheckState) + "' " & _
                                     "WHERE drec_codi='" + TxtPallet.Text + "'"

                    If fnc.MovimientoSQL(sql) > 0 Then
                        MsgBox("Pallet actualizado ", MsgBoxStyle.Information, "Aviso")
                        modifi = ""
                        ''''''''''''''''''' guardaVasAutomatico()
                        'LOG MODIFICO RECEPCION *************************************************************************************
                        Dim _log As String = "INSERT INTO LOG_FichRece(LFR_CODI, LFR_FECHA, LFR_HORA, LFR_USUARIO, LFR_PC)" & _
                            "VALUES('" + TxtCodRece.Text + "','" + devuelve_fecha(fnc.DevuelveFechaServidor()) + "'," & _
                            "'" + DevuelveHora() + "','" + Convert.ToString(id_global) + "','" + nombrepc + "')"
                        fnc.MovimientoSQL(_log)
                        'LOG MODIFICO RECEPCION *************************************************************************************

                        'BuscaDetalleRecepcionCompleta()
                        SumaTotalPallets()
                        ' modifica rackdeta

                        Dim SQL_RACKDETA As String = "UPDATE rackdeta SET  racd_codpro='" + txtprodcod.Text + "', " & _
                            "racd_unidades='" + txtunid.Text + "', racd_peso='" + kg.Text.Replace(",", ".") + "', racd_fecpro='" + devuelve_fecha(felaboracion.Value) + "', " & _
                           "fechavencimiento='" + devuelve_fecha_Formato2(devuelve_fecha(fvencimiento.Value)) + "', lotecliente='" + loteclie.Text + "' WHERE racd_codi='" + TxtPallet.Text + "'"

                        fnc.MovimientoSQL(SQL_RACKDETA)

                        'modifica encabezado
                        Dim SqlFich As String = "UPDATE fichrece SET frec_totsopo='" + txtsoportantes.Text + "', frec_totunidad='" + txtcajas.Text + "', " & _
                               "frec_totpeso='" + txtkilos.Text + "' WHERE frec_codi='" + TxtCodRece.Text + "'"
                        fnc.MovimientoSQL(SqlFich)

                        'modifica movpallet
                        Dim SqlMovpallet As String = "UPDATE movpallet SET mov_doc='" + TxtCodRece.Text + "', mov_saldo='" + txtunid.Text + "' WHERE  mov_folio='" + TxtPallet.Text + "' "
                        fnc.MovimientoSQL(SqlMovpallet)
                        Imprimir()
                        LimpiarProductoIngreso()
                        ' BuscaRecepcionCompleta()
                        CheckArriendo.Checked = False
                        txtsopclie.Focus()

                        '    If detareceaux.Rows.Count > 0 Then

                        '        Me.DetaRece.CurrentCell = detareceaux.Rows(detareceaux.Rows.Count - 1).Cells(0)
                        '        Me.DetaRece.Refresh()
                        '    End If
                        '    Exit Sub
                        'Else
                        '    MsgBox("error al actualizar el pallet ", MsgBoxStyle.Information, "Aviso")
                        'End If

                    End If
                    Imprimir()
                    LimpiarProductoIngreso()
                End If
            End If
        End If

        txtsopclie.Focus()

        'If Me.DetaRece.RowCount > 0 Then
        '    Me.DetaRece.ClearSelection()
        '    Me.DetaRece.CurrentCell = Me.DetaRece.Rows(Me.DetaRece.RowCount - 1).Cells(0)
        '    Me.DetaRece.Refresh()
        'End If
        modifi = ""
    End Sub

    Private Sub BtnOrigen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New Lst_AyudaOrigenes
        Dim res As DialogResult = frm.ShowDialog()

        If frm.resultado = "OK" Then
            Me.valorRecibido = frm.IdPrincipal
        End If

        If valorRecibido <> "" Then
            txtorigen.Text = valorRecibido
            txtorigend.Text = retorna_Origen(valorRecibido)
            valorRecibido = ""
        End If
    End Sub

    Private Sub dt_as_DoubleClick_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim sqlComando As String
        Dim IdServicio As String = CStr(dt_as(dt_as.CurrentCell.RowNumber, 0))
        sqlComando = "  DELETE FROM TMP_SERVICIOS WHERE Serv_cod='" + IdServicio + "' AND Serv_folio='" + TxtCodRece.Text.Trim + "'"

        If fnc.MovimientoSQL(sqlComando) > 0 Then
            listar()
            Exit Sub
        Else
            MsgBox("Ocurrio un error al quitar el servicio", MsgBoxStyle.Critical, "Aviso")
            Exit Sub
        End If
    End Sub

    Private Sub listar()
        Dim sqlListar As String
        Dim tablaListar As DataTable

        ''LISTA LOS SERVICIOS QUE NO AN SIDO AGREGADOS'
        'sqlListar = " SELECT Serv_cod,Serv_nom,'0' AS Dvas_unid,'0' AS Dvas_cajas,'0' AS Dvas_kilos " & _
        '            " FROM FacServicios WHERE isnull(Serv_OrdR,0) >'0' AND NOT EXISTS" & _
        '            " (SELECT Serv_cod FROM TMP_SERVICIOS WHERE Serv_folio='" + TxtCodRece.Text.Trim + "'" & _
        '            " AND FacServicios.Serv_Cod=TMP_SERVICIOS.Serv_cod)"
        'DataAdicionales.DataSource = Nothing
        'tablaListar = fnc.ListarTablasSQL(sqlListar)
        'DataAdicionales.DataSource = tablaListar

        'LISTA LOS SERVICIOS QUE YA FUERON AGREGADOS'
        sqlListar = " SELECT Serv_cod,Serv_nom,ISNULL(Dvas_unid,0) AS Dvas_unid," & _
                    " ISNULL(Dvas_cajas,0) AS Dvas_cajas,ISNULL(Dvas_kilos,0) AS" & _
                    " Dvas_kilos, Estado FROM TMP_SERVICIOS WHERE Serv_folio='" + TxtCodRece.Text.Trim + "' "
        dt_as.DataSource = Nothing
        tablaListar = fnc.ListarTablasSQL(sqlListar)
        dt_as.DataSource = tablaListar
    End Sub

    Sub guardaVasAutomatico()
        dataadicionalesaux = dt_as.DataSource
        Dim cantidad As Integer = dataadicionalesaux.Rows.Count - 1
        Dim registros As Integer = 0

        If cantidad > 0 Then
            If fnc.verificaExistenciaCondicional("FacVas", "Vas_Dcto='" + TxtCodRece.Text + "' AND Vas_TipDoc='0' ") = False Then
                Dim CODIGO_VAS As String = BuscaCorrelativo("012", 7)



                Dim sqlListar As String = "  SELECT ISNULL(COUNT(dvas_unid),0) AS Cantidad FROM TMP_SERVICIOS WHERE Serv_cod='" + TxtCodRece.Text.Trim + "' AND Dvas_unid <> '0'"
                Dim tablaListar As DataTable = fnc.ListarTablasSQL(sqlListar)

                If tablaListar.Rows.Count > 0 Then
                    registros = CInt(tablaListar.Rows(0)(0).ToString)
                Else
                    registros = 0
                End If

                If registros > 0 Then
                    Dim sql As String = "INSERT INTO facvas(Vas_cod, vas_clirut, vas_cont, vas_dcto, vas_fecha, vas_guia, vas_estado, vas_seccion, vas_tipdoc, Vas_Obs, vas_emis, vas_usucod)" & _
                                                       "VALUES('" + CODIGO_VAS + "','" + TxtClirut.Text + "','" + txtcodcontrato.Text + "','" + TxtCodRece.Text + "'," & _
                                                       "'" + devuelve_fecha(fecharece.Value) + "','" + txtguia.Text + "','0','0','0','" + OBSERVACION_VAS.ToString() + "'," & _
                                                       "GETDATE(),'" + Convert.ToString(id_global) + "')"
                    If fnc.MovimientoSQL(sql) > 0 Then
                        For i As Integer = 0 To dataadicionalesaux.Rows.Count - 1

                            Dim true_false As Boolean = False

                            Dim Unidad1 As String = "0"
                            Dim Unidad2 As String = "0"
                            Dim Unidad3 As String = "0"
                            'un=2 ca=3 ki=4
                            If Not IsNothing(dataadicionalesaux.Rows(i)(2).ToString) Then
                                Unidad1 = dataadicionalesaux.Rows(i)(2).ToString.Replace(",", ".")
                            End If
                            If Not IsNothing(dataadicionalesaux.Rows(i)(3).ToString) Then
                                Unidad2 = dataadicionalesaux.Rows(i)(3).ToString
                            End If
                            If Not IsNothing(dataadicionalesaux.Rows(i)(4).ToString) Then
                                Unidad3 = dataadicionalesaux.Rows(i)(4).ToString
                            End If

                            true_false = True

                            If Unidad1 <> "0" Or Unidad2 <> "0" Or Unidad2 <> "0" Then
                                Dim sqlDetalle As String = "INSERT INTO facVasDeta(Dvas_VasCod, dvas_est, Dvas_ServCod, Dvas_Unid, Dvas_Cajas, Dvas_Kilos, Dvas_cobrar)" & _
                                                           "VALUES('" + CODIGO_VAS + "','" + true_false.ToString() + "','" + dataadicionalesaux.Rows(i)(0).ToString() + "'," & _
                                                           "'" + Unidad1.ToString() + "','" + Unidad2.ToString() + "','" + Unidad3.ToString() + "','0')"
                                fnc.MovimientoSQL(sqlDetalle)
                            End If
                        Next
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub insertarTemporalServicios()
        Dim sqlListar As String = " SELECT Serv_cod,Serv_nom,'0' AS Dvas_unid,'0' AS Dvas_cajas,'0' AS Dvas_kilos " & _
                                  " FROM FacServicios WHERE isnull(Serv_OrdR,0) >'0' AND NOT EXISTS" & _
                                  " (SELECT Serv_cod FROM TMP_SERVICIOS WHERE Serv_folio='" + TxtCodRece.Text.Trim + "'" & _
                                  " AND FacServicios.Serv_Cod=TMP_SERVICIOS.Serv_cod)"
        Dim tablaListar As DataTable = fnc.ListarTablasSQL(sqlListar)
        Dim sqlComando As String
        For i As Integer = 0 To tablaListar.Rows.Count - 1
            sqlComando = " INSERT INTO TMP_SERVICIOS (Serv_cod,Serv_nom,Dvas_unid,Dvas_cajas,Dvas_kilos,Serv_folio,Estado) VALUES " & _
                     " ('" + tablaListar.Rows(i)(0).ToString + "','" + tablaListar.Rows(i)(1).ToString + "'," & _
                     " '" + tablaListar.Rows(i)(2).ToString + "','" + tablaListar.Rows(i)(3).ToString + "'," & _
                     "'" + tablaListar.Rows(i)(4).ToString + "','" + TxtCodRece.Text.Trim + "','NO')"
            fnc.MovimientoSQL(sqlComando)
        Next
    End Sub

    Private Sub DataAdicionales_DoubleClick_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim sqlComando As String
        'Dim Serv_cod As String = CStr(DataAdicionales(DataAdicionales.CurrentCell.RowNumber, 0))
        'Dim Serv_nom As String = CStr(DataAdicionales(DataAdicionales.CurrentCell.RowNumber, 1))
        'Dim Dvas_unid As String = CStr(DataAdicionales(DataAdicionales.CurrentCell.RowNumber, 2))
        'Dim Dvas_cajas As String = CStr(DataAdicionales(DataAdicionales.CurrentCell.RowNumber, 3))
        'Dim Dvas_kilos As String = CStr(DataAdicionales(DataAdicionales.CurrentCell.RowNumber, 4))
        'sqlComando = " INSERT INTO TMP_SERVICIOS (Serv_cod,Serv_nom,Dvas_unid,Dvas_cajas,Dvas_kilos,Serv_folio) VALUES " & _
        '             " ('" + Serv_cod + "','" + Serv_nom + "','" + Dvas_unid + "','" + Dvas_cajas + "','" + Dvas_kilos + "','" + TxtCodRece.Text.Trim + "')"

        'If fnc.MovimientoSQL(sqlComando) > 0 Then
        '    listar()
        '    Exit Sub
        'Else
        '    MsgBox("Ocurrio un error al agregar el servicio", MsgBoxStyle.Critical, "Aviso")
        '    Exit Sub
        'End If
    End Sub

    Private Sub BtnTemp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTemp.Click
        Dim frm As New Frm_temperaturas
        frm.filtro = TxtCodRece.Text.Trim
        Dim res As DialogResult = frm.ShowDialog()


        If frm.resultado = "OK" Then
            Me.valorRecibido = frm.IdPrincipal
            TxtNpallets = frm.lbl_cantidad.Text
            TxtPromTemp = frm.lbl_promedio.Text
        End If

        CargaGrillaDetalle()
        valorRecibido = ""
    End Sub

    Private Sub btnAdjuntarFotos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdjuntarFotos.Click
        Dim frm As New Frm_AdjuntaFotoRecepcion
        frm.filtro = TxtCodRece.Text.Trim
        Dim res As DialogResult = frm.ShowDialog()


        If frm.resultado = "OK" Then
            Me.valorRecibido = frm.IdPrincipal
        End If

        CargaGrillaDetalle()
        valorRecibido = ""
    End Sub

    Private Sub chkdatosguia_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkdatosguia.CheckStateChanged
        If chkdatosguia.Checked = True Then

            lblenvguia.Visible = True
            lblkilguia.Visible = True
            txtenvguia.Visible = True
            txtkilguia.Visible = True
            datosguia = "1"
        Else
            lblenvguia.Visible = False
            lblkilguia.Visible = False
            txtenvguia.Visible = False
            txtkilguia.Visible = False
            datosguia = "0"
        End If
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click, btn_nuevo2.Click
        If TxtCodRece.Text <> "" Then
            If fnc.verificaExistencia("fichrece", "frec_codi", TxtCodRece.Text) = False Then
                If TxtCodRece.Enabled = False Then
                    If MsgBox("Desea salir del Proceso de recepcion" + vbCrLf + "-Si abandona esta recepcion perderá todo lo ingresado", _
                              MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel, "Aviso") = vbYes Then
                        CancelaCorrelativo("006", TxtCodRece.Text)

                        'libero estado del checklist
                        Dim sql As String = "UPDATE zcheckList SET cl_estfrigo='0' WHERE cl_fol='" + TxtFolioPorteria.Text + "'"
                        fnc.MovimientoSQL(sql)


                        Dim SqlEliminaTMPDETA As String = "DELETE FROM TmpDetaRece WHERE frec_codi='" + TxtCodRece.Text + "'"
                        fnc.MovimientoSQL(SqlEliminaTMPDETA)


                        sql = "DELETE FROM TmpFichrece WHERE frec_codi='" + TxtCodRece.Text + "'"
                        fnc.MovimientoSQL(sql)

                        sql = "DELETE FROM chk_imagesopo WHERE LEFT(id_pallets,7)='" + TxtCodRece.Text + "'"
                        fnc.MovimientoSQL(sql)

                        sql = "DELETE FROM detarececajas WHERE LEFT(caj_Pcod,7)='" + TxtCodRece.Text + "'"
                        fnc.MovimientoSQL(sql)

                        sql = "DELETE FROM detareceestado WHERE LEFT(rtraq_codi,7)='" + TxtCodRece.Text + "'"
                        fnc.MovimientoSQL(sql)

                        sql = "DELETE FROM TMP_SERVICIOS WHERE Serv_folio='" + TxtCodRece.Text + "'"
                        fnc.MovimientoSQL(sql)

                        limpiarFormulario()
                        fecharece.Value = fnc.DevuelveFechaServidor()
                        TimeAdicionales.Enabled = False
                    End If
                Else
                    limpiarFormulario()
                    TimeAdicionales.Enabled = False
                End If
            Else
                limpiarFormulario()
                TimeAdicionales.Enabled = False
            End If
        Else
            TxtCodRece.Focus()
            TimeAdicionales.Enabled = False
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click, btn_salir2.Click
        Me.Close()
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click, btn_guardar2.Click

        Dim fecha_recepcion As String
        Dim fecha_formato1 As String
        Dim fecha_formato2 As String
        Dim sql_prueba As String




        If validacion() = 0 Then
            If fnc.verificaExistencia("fichrece", "frec_codi", TxtCodRece.Text) = False Then

                '********************** VALIDADOR DE TEMPERATURAS *************************

                Dim Gracia As Integer = Val(TxtTemp.Text) + Val(TxtTempGracia.Text)
                Dim sqltemp As String = "SELECT frec_codi+drec_codi AS sopo, isnull(drec_temp,'0.00') FROM TMPDETARECE WHERE frec_codi='" + TxtCodRece.Text + "' " & _
                    "AND drec_temp>'" + Gracia.ToString() + "' AND drec_temp<>0 ORDER BY drec_codi "

                Dim tabla As DataTable = fnc.ListarTablasSQL(sqltemp)

                If tabla.Rows.Count > 0 Then
                    If Val(txtsoportantes.Text) > Val(TxtNpallets) Then
                        mensaje = mensaje + "- Debe Ingresar todas las temperaturas de los soportantes"
                    End If
                ElseIf Val(TxtNpallets) < 6 Then
                    If Val(txtsoportantes.Text) > Val(TxtNpallets) AndAlso Val(txtsoportantes.Text) >= 6 Then   'TxtNpallets hace referencia a los pallets con temperatura.-
                        mensaje = mensaje + "-Debe Ingresar MINIMO 6 temperaturas"
                    ElseIf Val(txtsoportantes.Text) <> Val(TxtNpallets) Then
                        mensaje = mensaje + "-Debe Ingresar MINIMO " + txtsoportantes.Text + " temperaturas"
                    End If
                End If

                If mensaje.Length > 0 Then
                    MsgBox(mensaje, MsgBoxStyle.Critical, "Aviso")
                    Exit Sub
                End If
                '**************************************************************************
                '********************** VALIDADOR DE FOTOGRAFIAS* *************************
                Dim sqlFoto As String = "SELECT rimg_imagen,rimg_num,rimg_rececodi FROM receimagen WHERE rimg_rececodi = '" + TxtCodRece.Text + "'"

                Dim tablaFoto As DataTable = fnc.ListarTablasSQL(sqlFoto)

                If tablaFoto.Rows.Count = 0 Then
                    mensaje = mensaje + "- Debe Ingresar MINIMO una Fotografía"
                End If


                If mensaje.Length > 0 Then
                    MsgBox(mensaje, MsgBoxStyle.Critical, "Aviso")
                    Exit Sub
                End If
                '**************************************************************************


                'servicios
                Dim sqlServ As String = "SELECT * FROM TMP_SERVICIOS WHERE Serv_folio='" + TxtCodRece.Text.Trim + "'"
                Dim tablaServ As DataTable = fnc.ListarTablasSQL(sqlServ)

                'aqui
                If detareceaux.Rows.Count = 0 Then
                    MsgBox("Debe ingresar un detalle de recepcion", MsgBoxStyle.Critical, "Aviso")
                    Exit Sub
                End If

                'Guarda Encabezado
                TimeAdicionales.Enabled = False

                horaterm.Text = DevuelveHora()

                Dim turno As String = ""
                If Convert.ToDateTime("08:00:00") > DevuelveHora() AndAlso DevuelveHora() <= Convert.ToDateTime("19:59:59") Then
                    turno = "1"
                Else
                    turno = "2"
                End If

                'ACTUALIZA CHECKLIST 
                If IsNumeric(TxtFolioPorteria.Text) Then
                    Dim sqlActualizaChecklist = "UPDATE zchecklist SET Cl_RutCli='" + TxtClirut.Text + "' " & _
                                                "WHERE cl_fol='" + TxtFolioPorteria.Text + "'"
                    fnc.MovimientoSQL(sqlActualizaChecklist)
                End If


                Dim sqlGuarda As String = "INSERT INTO fichrece(frec_codi, frec_rutcli, frec_contcli, frec_horalleg, frec_horarec, frec_horater, frec_turnrec, frec_fecrec, frec_guiades, frec_totsopo, " & _
                    "frec_totunidad, frec_totpeso, frec_temppro, frec_rutcond, frec_observ, frec_tipdesc, frec_codienca, frec_origen, frec_codvig, frec_receptunel, " & _
                    "frec_numsello, frec_tiporecepcion, frec_tipoalmacenamiento, frec_olores, frec_higiene, frec_estiba, frec_dañado, frec_antecamara, frec_clfol, frec_contenedor,frec_ntunel,cod_bod,val_guia,uni_guia,kilos_guia,frec_orirec )VALUES" & _
                    "('" + TxtCodRece.Text + "','" + QuitarCaracteres(TxtClirut.Text, "-") + "','" + txtcodcontrato.Text + "','" + horalleg.Text + "','" + horainic.Text + "'," & _
                    "'" + horaterm.Text + "','" + turno + "','" + devuelve_fecha(fecharece.Value) + "','" + txtguia.Text + "'," & _
                    "'" + txtsoportantes.Text + "','" + txtcajas.Text + "','" + txtkilos.Text.Replace(",", ".") + "','" + TxtPromTemp.Replace(",", ".") + "'," & _
                    "'" + QuitarCaracteres(txtrutchofer.Text, "-") + "','" + Txtobs.Text + "','" + cmbo_descarga.SelectedValue.ToString() + "','" + Convert.ToString(id_global) + "'," & _
                    "'" + txtorigen.Text + "','0','" + CmboTuneles.SelectedValue.ToString() + "'," & _
                    "'" + txtsello.Text + "','" + Cmbotiporece.SelectedValue.ToString() + "','" + Cmbo_Almacenamiento.Text.ToString() + "','" + EstadoCheckBox(Cb_OloresExtraños.CheckState) + "'," & _
                    "'" + (Convert.ToInt16(Rb_higieneB.Checked)).ToString() + "','" + (Convert.ToInt16(Rb_EstibaB.Checked)).ToString() + "','" + EstadoCheckBox(cbdañado.CheckState).ToString() + "', " & _
                    "'" + cmbAnden.SelectedValue.ToString() + "','" + TxtFolioPorteria.Text + "','" + TxtContenedor.Text + "','" + cbonumtun.Text + "','" + sucursalglo + "','" + datosguia.Trim() + "','" + txtenvguia.Text.Trim() + "','" + txtkilguia.Text.Trim() + "','RADIO')"


                If fnc.MovimientoSQL(sqlGuarda) > 0 Then
                    MsgBox("Guia ingresada correctamente", MsgBoxStyle.Information, "Aviso")

                    Dim cantidadDetalle As Integer = 0

                    'Guarda Detalle
                    For i As Integer = 0 To detareceaux.Rows.Count - 1
                        Dim estado_traqueo As String = "0"
                        'Dim sqls As String = detareceaux.Rows(i)(16).ToString()
                        CargaGrillaDetalle()
                        Dim tabla_traqueo As DataTable = fnc.ListarTablasSQL("SELECT isnull(drec_codcaja,0) FROM TMPDETARECE WHERE frec_codi+drec_codi='" + detareceaux.Rows(i)(2).ToString() + "'")

                        If tabla_traqueo.Rows.Count > 0 Then
                            estado_traqueo = tabla_traqueo.Rows(0)(0).ToString()
                        End If


                        'BLOQUE DE CONTROL PARA VARIABLES DE FECHA
                        Try
                            fecha_recepcion = devuelve_fecha(fecharece.Value)
                            fecha_formato1 = devuelve_fecha(detareceaux.Rows(i)(7).ToString())
                            fecha_formato2 = devuelve_fecha_Formato2(detareceaux.Rows(i)(8).ToString())

                        Catch ex As InvalidCastException
                            Exit Sub
                        End Try


                        Dim sqlGuardaDetalle As String = "INSERT INTO detarece (drec_codi, drec_codcaja, drec_codpro, drec_codsopo, drec_sopocli, drec_unidades, drec_peso, " & _
                            "drec_fecrec, drec_rutcli, drec_contcli, drec_fecprod, drec_camara, drec_banda, drec_colum, drec_piso, drec_nivel, drec_codvig, " & _
                            "drec_codsag, fechaVencimiento, LoteCliente, drec_receptunel, drec_codper, drec_hora, drec_etiqueta, frec_codi1, drec_pallet, drec_almacen, drec_temp, drec_arriendo,Estpallet,cod_bod) " & _
                            "VALUES('" + detareceaux.Rows(i)(0).ToString() + "','" + estado_traqueo + "','" + detareceaux.Rows(i)(1).ToString() + "', " & _
                            "'" + detareceaux.Rows(i)(3).ToString() + "','" + detareceaux.Rows(i)(11).ToString() + "', " & _
                            "'" + detareceaux.Rows(i)(5).ToString() + "','" + detareceaux.Rows(i)(6).ToString().Replace(",", ".") + "'," & _
                            "'" + fecha_recepcion + "','" + QuitarCaracteres(TxtClirut.Text, "-") + "','" + txtcodcontrato.Text + "', " & _
                            "'" + fecha_formato1 + "','" + cmbAnden.SelectedValue.ToString() + "','00','00','00','0','0','" + detareceaux.Rows(i)(10).ToString() + "'," & _
                            "'" + fecha_formato2 + "','" + detareceaux.Rows(i)(9).ToString().Trim + "','" + CmboTuneles.SelectedValue.ToString() + "', " & _
                            "'" + Convert.ToString(id_global) + "','" + horainic.Text + "'," & _
                            "'" + DigitoVerificadorEAN128UCC("1780000000" + CerosAnteriorString(detareceaux.Rows(i)(0).ToString(), 7)) + "'," & _
                            "'" + TxtCodRece.Text + "','1','2','" + detareceaux.Rows(i)(12).ToString().Replace(",", ".") + "','" + detareceaux.Rows(i)(13).ToString() + "','" + detareceaux.Rows(i)(14).ToString() + "','" + sucursalglo + "') "

                        If fnc.MovimientoSQL(sqlGuardaDetalle) > 0 Then
                            cantidadDetalle += 1
                        End If

                        'Guarda Movpallet
                        Dim SqlMovpallet As String = "INSERT INTO movpallet(mov_folio, mov_codper, mov_ca, mov_ba, mov_co, mov_pi, mov_ni, mov_fecha, mov_tipo, mov_hora, mov_doc, mov_saldo,  mov_anden, mov_TS)" & _
                                                     "VALUES('" + detareceaux.Rows(i)(0).ToString() + "','" + Convert.ToString(id_global) + "','" + cmbAnden.SelectedValue.ToString() + "'," & _
                                                     "'00','00','00','0','" + fecha_recepcion + "','EN','" + DevuelveHora() + "','" + TxtCodRece.Text + "','" + detareceaux.Rows(i)(5).ToString() + "'," & _
                                                     "'" + cmbAnden.SelectedValue.ToString() + "','" + detareceaux.Rows(i)(12).ToString().Replace(",", ".") + "')"

                        fnc.MovimientoSQL(SqlMovpallet)

                        ' Guarda Rackdeta

                        'BLOQUEA IMPORTACION
                        Dim ESTADO As String = "0"

                        Dim sql As String = "SELECT cont_bloqimp FROM contrato WHERE cont_codi='" + txtcodcontrato.Text + "'"
                        Dim tablaEstado As DataTable = fnc.ListarTablasSQL(sql)

                        If tablaEstado.Rows.Count > 0 Then

                            If tablaEstado.Rows(0)(0).ToString() = "1" Then

                                ' verifico si debo ingresar el etiquetado bloqueado
                                If QuitarCaracteres(txtrutchofer.Text) = "222222222" Then

                                    Dim tabla_contenedor As DataTable = fnc.ListarTablasSQL("SELECT frec_codi, frec_contenedor FROM Proc_Importaciones INNER JOIN fichrece ON frec_codi=pimp_codrece " & _
                                                                                            "WHERE LTRIM(frec_contenedor) LIKE '%" + detareceaux.Rows(i)(9).ToString().Trim + "%'")

                                    If tabla_contenedor.Rows.Count > 0 Then
                                        ESTADO = "0"
                                    Else
                                        ESTADO = "5"
                                    End If
                                Else
                                    ESTADO = "5"
                                End If

                            End If

                        End If

                        Dim SQL_RACKDETA As String = " INSERT INTO rackdeta (racd_codi, racd_ca, racd_ba, racd_co, racd_pi, racd_ni, racd_codpro, racd_unidades, racd_peso, racd_fecpro, " & _
                            "fechavencimiento, lotecliente, racd_pedido, racd_estadopallet, racd_solicitado, racd_correo, racd_picking, racd_estado , cod_bod )" & _
                            "VALUES('" + detareceaux.Rows(i)(0).ToString() + "','" + cmbAnden.SelectedValue.ToString() + "','00','00','00','0','" + detareceaux.Rows(i)(1).ToString() + "'," & _
                            "'" + detareceaux.Rows(i)(5).ToString() + "','" + detareceaux.Rows(i)(6).ToString().Replace(",", ".") + "','" + fecha_formato1 + "'," & _
                            "'" + fecha_formato2 + "','" + detareceaux.Rows(i)(9).ToString().Trim + "','0','0','0','0','0','" + ESTADO.ToString() + "','" + sucursalglo + "')"

                        fnc.MovimientoSQL(SQL_RACKDETA)

                    Next

                    guardaVasAutomatico()

                    If cantidadDetalle = detareceaux.Rows.Count Then
                        Dim SqlEliminaTMPDETA As String = "DELETE FROM TmpDetaRece WHERE frec_codi='" + TxtCodRece.Text + "'"
                        fnc.MovimientoSQL(SqlEliminaTMPDETA)

                        Dim sql As String = "DELETE FROM TmpFichrece WHERE frec_codi='" + TxtCodRece.Text + "'"
                        fnc.MovimientoSQL(sql)

                        sql = "DELETE FROM TMP_SERVICIOS WHERE Serv_folio='" + TxtCodRece.Text + "'"
                        fnc.MovimientoSQL(sql)

                        Dim imagenes As String = "INSERT into chk_imagesopo (id_pallets, cl_imgtem, cl_imgsel, cl_imgpat, cl_fecha) " & _
                                                 "SELECT id_pallets, cl_imgtem, cl_imgsel, cl_imgpat, cl_fecha FROM chk_imagestmp WHERE LEFT(id_pallets,7)='" + TxtCodRece.Text + "'"
                        fnc.MovimientoSQL(imagenes)
                    End If

                Else
                    MsgBox("Ocurrio un error al ingresar la recepcion", MsgBoxStyle.Critical, "Aviso")
                End If

            End If
        End If

        limpiarFormulario()
        LimpiarProductoIngreso()
    End Sub

    Private Sub dt_as_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim sqlComando As String
        'Dim IdServicio As String = CStr(dt_as(dt_as.CurrentCell.RowNumber, 0))
        'sqlComando = "  DELETE FROM TMP_SERVICIOS WHERE Serv_cod='" + IdServicio + "' AND Serv_folio='" + TxtCodRece.Text.Trim + "'"

        'If fnc.MovimientoSQL(sqlComando) > 0 Then
        '    listar()
        '    Exit Sub
        'Else
        '    MsgBox("Ocurrio un error al quitar el servicio", MsgBoxStyle.Critical, "Aviso")
        '    Exit Sub
        'End If
    End Sub

    Private Sub activa_desactiva(ByVal codigo As String, ByVal true_false As Boolean)
        Dim sql As String = ""

        If true_false = True Then
            sql = " UPDATE TMP_SERVICIOS SET " & _
                  " Dvas_unid='" + txtsoportantes.Text.Trim + "'," & _
                  " Dvas_cajas='" + txtcajas.Text.Trim + "'," & _
                  " Dvas_kilos='" + txtkilos.Text.Trim + "'," & _
                  " Estado='SI' " & _
                  " WHERE Serv_cod='" + codigo + "' AND Serv_folio='" + TxtCodRece.Text.Trim + "' "
            fnc.MovimientoSQL(sql)
            listar()
        Else
            sql = " UPDATE TMP_SERVICIOS SET " & _
                  " Dvas_unid='0'," & _
                  " Dvas_cajas='0'," & _
                  " Dvas_kilos='0'," & _
                  " Estado='NO' " & _
                  " WHERE Serv_cod='" + codigo + "' AND Serv_folio='" + TxtCodRece.Text.Trim + "'"
            fnc.MovimientoSQL(sql)
            listar()
        End If
    End Sub

    Private Sub adicionales()
        Dim sql As String = ""
        dataadicionalesaux = dt_as.DataSource
        If TxtCodRece.Enabled = True Then
            Exit Sub
        End If

        Try
            OBSERVACION_VAS = ""
            'If Cb_tunel.Checked = True Then
            If CmboTuneles.SelectedValue = 1 Then
                activa_desactiva("005", False) '005
                activa_desactiva("010", False) '010
                activa_desactiva("004", False) '004
                activa_desactiva("016", False) '016
            ElseIf CmboTuneles.SelectedValue = 2 Then
                'tunel congelado 
                activa_desactiva("004", True) '004
                activa_desactiva("016", True) '016
                activa_desactiva("005", False) '005
                activa_desactiva("010", False) '010
            ElseIf CmboTuneles.SelectedValue = 3 Then
                'congelado en camara 
                activa_desactiva("005", True) '005
                activa_desactiva("016", False) '016
                activa_desactiva("004", False) '004
                activa_desactiva("010", False) '010
            ElseIf CmboTuneles.SelectedValue = 4 Then
                'proceso de ecualizacion
                activa_desactiva("010", True) '010
                activa_desactiva("016", False) '016
                activa_desactiva("004", False) '004
                activa_desactiva("005", False) '005
            End If

            If CbSinPostura.Checked = True Then
                activa_desactiva("016", False) '016
            End If
            If cmbo_descarga.SelectedValue.ToString() = "1" Then
                activa_desactiva("012", True) '012
            Else
                activa_desactiva("012", False) '012
            End If

            activa_desactiva("006", False) '006
            activa_desactiva("007", False) '007

            'arriendo pallets


            If CbArriendo.CheckState = CheckState.Checked Then
                If IsNumeric(TxtArriendo.Text) Then
                    sql = " UPDATE TMP_SERVICIOS SET dvas_unid='" + TxtArriendo.Text.Trim + "' WHERE Serv_cod='013'"
                    fnc.MovimientoSQL(sql)
                    listar()
                Else
                    activa_desactiva("013", False) '013
                End If
            Else
                activa_desactiva("013", False) '013
            End If



            If dataadicionalesaux.Rows.Count = 11 Then
                If Cb_Repa.Checked = True Then
                    If IsNumeric(TxtRepa.Text) Then
                        sql = " UPDATE TMP_SERVICIOS SET dvas_unid='" + TxtRepa.Text.Trim + "' WHERE Serv_cod='015'"
                        fnc.MovimientoSQL(sql)
                        listar()
                    Else
                        activa_desactiva("015", False) '015
                    End If
                Else
                    activa_desactiva("015", False) '015
                End If
            End If

            If Cb_Postura.CheckState = CheckState.Checked Then
                If IsNumeric(TxtFilm.Text) Then
                    sql = " UPDATE TMP_SERVICIOS SET dvas_unid='" + TxtFilm.Text.Trim + "' WHERE Serv_cod='019'"
                    fnc.MovimientoSQL(sql)
                    listar()
                Else
                    activa_desactiva("019", False) '019
                End If
            Else
                activa_desactiva("019", False) '019
            End If

            If Cb_Repa.CheckState = CheckState.Checked Then
                If IsNumeric(TxtRepa.Text) Then
                    sql = " UPDATE TMP_SERVICIOS SET dvas_unid='" + TxtRepa.Text.Trim + "' WHERE Serv_cod='015'"
                    fnc.MovimientoSQL(sql)
                    listar()
                Else
                    activa_desactiva("015", False) '015
                End If
            Else
                activa_desactiva("015", False) '015
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TimeAdicionales_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimeAdicionales.Tick
        adicionales()
    End Sub

    Private Sub CbArriendo_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbArriendo.CheckStateChanged
        If CbArriendo.CheckState = CheckState.Checked Then
            TxtArriendo.Visible = True
        Else
            TxtArriendo.Visible = False
        End If
    End Sub

    Private Sub Cb_Postura_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cb_Postura.CheckStateChanged
        If Cb_Postura.CheckState = CheckState.Checked Then
            TxtFilm.Visible = True
            TxtFilm.SelectAll()
        Else
            TxtFilm.Visible = False
            TxtFilm.Text = "0"
        End If
    End Sub

    Private Sub Cb_Repa_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cb_Repa.CheckStateChanged
        If Cb_Repa.CheckState = CheckState.Checked Then
            TxtRepa.Visible = True
            TxtRepa.SelectAll()
        Else
            TxtRepa.Visible = False
            TxtRepa.Text = "0"
        End If
    End Sub

    Private Sub tab_recepcion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tab_recepcion.SelectedIndexChanged
        validar()
    End Sub

    Private Sub btn_eliminardetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminardetalle.Click

        If MsgBox("¿Esta seguro que desea eliminar el soportante " + TxtPallet.Text.Trim + "? ", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel, "Aviso") = vbYes Then
            Dim sql As String = "DELETE FROM TmpDetaRece WHERE frec_codi+''+drec_codi='" + TxtPallet.Text + "'"
            If fnc.MovimientoSQL(sql) > 0 Then
                sql = "DELETE FROM detarececajas WHERE caj_pcod='" + TxtPallet.Text + "'"
                fnc.MovimientoSQL(sql)
                MsgBox("Soportante eliminado correctamente ", MsgBoxStyle.Information, "Aviso")
                CargaGrillaDetalle()
                Btn_GuardaDetalle.Text = "Grabar"
                btn_eliminardetalle.Enabled = False
                LimpiarProductoIngreso()
            Else
                MsgBox("Ocurrio un error al eliminar el soportante ", MsgBoxStyle.Information, "Aviso")
            End If

        End If



    End Sub

    Private Sub DetaRece_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetaRece.CurrentCellChanged
        Try
            TxtPallet.Text = CStr(DetaRece(DetaRece.CurrentCell.RowNumber, 0))
            txtprodcod.Text = CStr(DetaRece(DetaRece.CurrentCell.RowNumber, 1))
            txtsopcodi.Text = CStr(DetaRece(DetaRece.CurrentCell.RowNumber, 3))
            felaboracion.Text = CStr(DetaRece(DetaRece.CurrentCell.RowNumber, 7))
            fvencimiento.Text = CStr(DetaRece(DetaRece.CurrentCell.RowNumber, 8))
            txtsopclie.Text = CStr(DetaRece(DetaRece.CurrentCell.RowNumber, 11))
            loteclie.Text = CStr(DetaRece(DetaRece.CurrentCell.RowNumber, 9))
            txtcodsag.Text = CStr(DetaRece(DetaRece.CurrentCell.RowNumber, 10))
            txtunid.Text = CStr(DetaRece(DetaRece.CurrentCell.RowNumber, 5))
            kg.Text = CStr(DetaRece(DetaRece.CurrentCell.RowNumber, 6))

            Btn_GuardaDetalle.Text = "Actualizar"
            btn_eliminardetalle.Enabled = True
            modifi = "OK"

        Catch ex As NullReferenceException
            MsgBox("No se pudo seleccionar el soportante: " + ex.Message, MsgBoxStyle.Critical, "Aviso")
        End Try
    End Sub

    Private Sub felaboracion_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles felaboracion.ValueChanged
        If fvencimiento.Enabled = False Then
            fvencimiento.Value = felaboracion.Value.AddMonths(DiasVenc)
        End If
    End Sub

    Private Sub CmboTuneles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmboTuneles.SelectedIndexChanged
        If CmboTuneles.SelectedIndex = 1 Then

            cbonumtun.Enabled = True
            'cbonumtun.SelectedIndex = 0

        End If
        If CmboTuneles.SelectedIndex = 0 Then

            cbonumtun.Enabled = False
            cbonumtun.SelectedIndex = 0
            cbonumtun.Text = ""

        End If
    End Sub

    Private Sub txtetiquetacliente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtetiquetacliente.KeyPress
        If e.KeyChar = ChrW(13) Then
            Dim etiqueta As String
            Dim largo As Integer
            Dim sqlCon As String
            Dim tabla As DataTable


            etiqueta = txtetiquetacliente.Text.Trim
            largo = etiqueta.Length

            If txtidetiqueta.Text.Trim <> "" Then
                If largo > 0 Then

                    If largo = largo_global Then
                        autoCompletar()
                    Else
                        MsgBox("El largo de esta etiqueta no coincide con el seleccionado", MsgBoxStyle.Critical, "Aviso")
                        txtetiquetacliente.Text = ""
                        txtetiquetacliente.Focus()
                        Exit Sub
                    End If

                Else
                    MsgBox("Para usar esta función debe ingresar una etiqueta", MsgBoxStyle.Critical, "Aviso")
                    txtetiquetacliente.Text = ""
                    txtetiquetacliente.Focus()
                    Exit Sub
                End If

            Else
                MsgBox("Para usar esta función debe seleccionar una etiqueta primero", MsgBoxStyle.Critical, "Aviso")
                txtetiquetacliente.Text = ""
                Exit Sub
            End If
        Else
            SoloNumeros(sender, e)
        End If
    End Sub

    Private Sub autoCompletar()

        Dim codigoerror As Integer = 0

        Try
            Dim producto As String
            Dim soportante As String
            Dim elaboracion As String
            Dim vencimiento As String
            Dim sopoclie As String
            Dim lote As String
            Dim codigosap As String
            Dim unidades As String
            Dim kilos As String
            Dim etiqueta As String = txtetiquetacliente.Text.Trim
            Dim auxiliar As Integer

            Dim tablaAux As DataTable
            Dim sqlAux As String

            Dim dia As String
            Dim mes As String
            Dim year As String


            Dim sqlCon As String = " SELECT etiq_producto_inicio,etiq_producto_fin" & _
                                   " ,etiq_soportante_inicio,etiq_soportante_fin,etiq_felaboracion_inicio" & _
                                   " ,etiq_felaboracion_fin,etiq_felaboracion_orden" & _
                                   " ,etiq_fvencimiento_inicio,etiq_fvencimiento_fin,etiq_fvencimiento_orden" & _
                                   " ,etiq_sopoclie_inicio,etiq_sopoclie_fin " & _
                                   " ,etiq_lote_inicio,etiq_lote_fin,etiq_codsag_inicio,etiq_codsag_fin" & _
                                   " ,etiq_unidades_inicio,etiq_unidades_fin " & _
                                   " ,etiq_kilos_inicio,etiq_kilos_fin,etiq_kilos_punto FROM EtiquetaCliente " & _
                                   " WHERE etiq_id='" + txtidetiqueta.Text.Trim + "'"

            Dim tabla As DataTable = fnc.ListarTablasSQL(sqlCon)

            If tabla.Rows.Count > 0 Then

                codigoerror = 1
                'PRODUCTO
                If (CInt(tabla.Rows(0)(1).ToString) > 0) Then
                    producto = etiqueta.Substring(tabla.Rows(0)(0).ToString, tabla.Rows(0)(1).ToString)

                    sqlAux = "SELECT mae_descr, mae_diasv, mae_codi FROM maeprod WHERE mae_codcli='" + producto + "'"
                    tablaAux = fnc.ListarTablasSQL(sqlAux)
                    If tablaAux.Rows.Count > 0 Then
                        txtprodnom.Text = tablaAux.Rows(0)(0).ToString()
                        txtprodcod.Text = tablaAux.Rows(0)(2).ToString()
                        If Convert.ToInt32(tablaAux.Rows(0)(1).ToString()) > 0 Then
                            fvencimiento.Value = DateAdd(DateInterval.Month, Convert.ToInt32(tabla.Rows(0)(1).ToString()), felaboracion.Value)
                            DiasVenc = Convert.ToInt32(tablaAux.Rows(0)(1).ToString())
                            fvencimiento.Enabled = False
                        Else
                            fvencimiento.Enabled = True
                        End If

                    End If
                End If

                codigoerror = 2
                'SOPORTANTE
                If (CInt(tabla.Rows(0)(3).ToString) > 0) Then
                    soportante = etiqueta.Substring(tabla.Rows(0)(2).ToString, tabla.Rows(0)(3).ToString)

                    sqlAux = "SELECT tsop_descr FROM tiposopo WHERE tsop_codi='" + soportante + "'"
                    tablaAux = fnc.ListarTablasSQL(sqlAux)
                    If tablaAux.Rows.Count > 0 Then
                        txtsopcodi.Text = soportante
                        txtsopnombre.Text = tablaAux.Rows(0)(0).ToString
                    End If
                End If

                codigoerror = 3
                'FECHA ELABORACIÓN
                If (CInt(tabla.Rows(0)(5).ToString) > 0) Then
                    elaboracion = etiqueta.Substring(tabla.Rows(0)(4).ToString, tabla.Rows(0)(5).ToString)
                    If tabla.Rows(0)(6).ToString.ToLower = "dmy" Then
                        dia = elaboracion.Substring(0, 2)
                        mes = elaboracion.Substring(2, 2)
                        year = elaboracion.Substring(4, 4)
                        elaboracion = dia + "-" + mes + "-" + year
                    Else 'ymd
                        dia = elaboracion.Substring(6, 2)
                        mes = elaboracion.Substring(4, 2)
                        year = elaboracion.Substring(0, 4)
                        elaboracion = dia + "-" + mes + "-" + year
                    End If
                    felaboracion.Value = elaboracion
                    If IsNumeric(DiasVenc) Then
                        If Val(DiasVenc) <> 0 Then
                            If fvencimiento.Enabled = False Then
                                fvencimiento.Value = felaboracion.Value.AddMonths(DiasVenc)
                            End If
                        End If
                    End If
                End If

                codigoerror = 4
                'FECHA DE VENCIMIENTO
                If (CInt(tabla.Rows(0)(8).ToString) > 0) Then
                    vencimiento = etiqueta.Substring(tabla.Rows(0)(7).ToString, tabla.Rows(0)(8).ToString)
                    If tabla.Rows(0)(9).ToString.ToLower() = "dmy" Then
                        dia = vencimiento.Substring(0, 2)
                        mes = vencimiento.Substring(2, 2)
                        year = vencimiento.Substring(4, 4)
                        vencimiento = dia + "-" + mes + "-" + year
                    Else 'ymd
                        dia = vencimiento.Substring(6, 2)
                        mes = vencimiento.Substring(4, 2)
                        year = vencimiento.Substring(0, 4)
                        vencimiento = dia + "-" + mes + "-" + year
                    End If
                    fvencimiento.Value = vencimiento
                End If

                codigoerror = 5
                'SOPORTANTE CLIENTE
                If (CInt(tabla.Rows(0)(11).ToString) > 0) Then
                    sopoclie = etiqueta.Substring(tabla.Rows(0)(10).ToString, tabla.Rows(0)(11).ToString)
                    txtsopclie.Text = sopoclie
                End If

                codigoerror = 6
                'LOTE
                If (CInt(tabla.Rows(0)(13).ToString) > 0) Then
                    lote = etiqueta.Substring(tabla.Rows(0)(12).ToString, tabla.Rows(0)(13).ToString)
                    loteclie.Text = sopoclie
                End If

                codigoerror = 7
                'CODIGO SAG
                If (CInt(tabla.Rows(0)(15).ToString) > 0) Then
                    codigosap = etiqueta.Substring(tabla.Rows(0)(14).ToString, tabla.Rows(0)(15).ToString)
                    txtcodsag.Text = codigosap
                End If

                codigoerror = 8
                'UNIDADES
                If (CInt(tabla.Rows(0)(17).ToString) > 0) Then
                    unidades = etiqueta.Substring(tabla.Rows(0)(16).ToString, tabla.Rows(0)(17).ToString)
                    txtunid.Text = unidades
                End If

                codigoerror = 9
                'KILOS
                If (CInt(tabla.Rows(0)(19).ToString) > 0) Then
                    kilos = etiqueta.Substring(tabla.Rows(0)(18).ToString, tabla.Rows(0)(19).ToString)
                    auxiliar = CInt(tabla.Rows(0)(20).ToString) - 1

                    If auxiliar <> "" And auxiliar <> "0" Then
                        Dim x As Integer
                        Dim resultado As String
                        For x = 0 To kilos.Length - 1
                            If x = auxiliar Then
                                resultado = resultado & "."
                            End If
                            resultado = resultado & kilos.Chars(x)
                        Next
                        kg.Text = resultado
                    Else
                        kg.Text = kilos
                    End If


                End If

                txtetiquetacliente.Text = ""
            Else
                MsgBox("Ocurrio un error al extraer la información de la base", MsgBoxStyle.Critical, "Aviso")
                txtetiquetacliente.Text = ""
                Exit Sub
            End If

        Catch ex As ArgumentOutOfRangeException
        Catch ex As InvalidCastException
            MsgBox("Ocurrio un error al extraer la información de la etiqueta error(" + codigoerror.ToString + ")", MsgBoxStyle.Critical, "Aviso")
            txtetiquetacliente.Text = ""
            Exit Sub
        End Try

    End Sub

    Private Sub btnetiquetacliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnetiquetacliente.Click
        Dim frm As New Lst_AyudaEtiqueta
        frm.filtro = QuitarCaracteres(TxtClirut.Text)
        Dim res As DialogResult = frm.ShowDialog()

        If frm.resultado = "OK" Then
            Me.valorRecibido = frm.IdPrincipal
            Me.descrRecibido = frm.NombrePrincipal
        End If

        If valorRecibido <> "" Then
            Me.txtidetiqueta.Text = valorRecibido
            Me.txtdescripcionetiqueta.Text = descrRecibido
            Dim sqlCon As String = "SELECT LEN(etiq_muestra) AS largo FROM EtiquetaCliente WHERE etiq_id='" + txtidetiqueta.Text.Trim + "'"
            Dim tabla As DataTable = fnc.ListarTablasSQL(sqlCon)

            If tabla.Rows.Count > 0 Then
                largo_global = tabla.Rows(0)(0).ToString
            Else
                largo_global = 0
            End If
        End If
        valorRecibido = ""
        descrRecibido = ""
    End Sub
End Class