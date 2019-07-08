<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Frm_PreDespacho
    Inherits System.Windows.Forms.Form

    'Form invalida a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer
    Private mainMenu1 As System.Windows.Forms.MainMenu

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar con el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.Label6 = New System.Windows.Forms.Label
        Me.Dt_fecha = New System.Windows.Forms.DateTimePicker
        Me.BtnGuardar = New System.Windows.Forms.Button
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_nuevo = New System.Windows.Forms.Button
        Me.txtsoportantes = New System.Windows.Forms.TextBox
        Me.txtcajas = New System.Windows.Forms.TextBox
        Me.txtkilos = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.CbEtiq = New System.Windows.Forms.CheckBox
        Me.TxtNped = New System.Windows.Forms.TextBox
        Me.Temp3 = New System.Windows.Forms.TextBox
        Me.Cant = New System.Windows.Forms.TextBox
        Me.CbPedido = New System.Windows.Forms.CheckBox
        Me.Lbl_EstadoGuia = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.CbCant = New System.Windows.Forms.CheckBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.tempprom = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.btn_BuscaCliente = New System.Windows.Forms.Button
        Me.Label20 = New System.Windows.Forms.Label
        Me.Txtdestino = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtpallet = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtrut = New System.Windows.Forms.TextBox
        Me.TxtSello = New System.Windows.Forms.TextBox
        Me.txtclinombre = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.verificador = New System.Windows.Forms.TextBox
        Me.CmboCarga = New System.Windows.Forms.ComboBox
        Me.Temp1 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Temp2 = New System.Windows.Forms.TextBox
        Me.Cb1 = New System.Windows.Forms.CheckBox
        Me.TxtContenedor = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Txtrampla = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.lblcodigo = New System.Windows.Forms.TextBox
        Me.TxtObs = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Btn_AnulaGuia = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.Timer2 = New System.Windows.Forms.Timer
        Me.Lblpalletsped = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.DgvSoportantes = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.CODIGO = New System.Windows.Forms.DataGridTextBoxColumn
        Me.PRODUCTO = New System.Windows.Forms.DataGridTextBoxColumn
        Me.CAJ = New System.Windows.Forms.DataGridTextBoxColumn
        Me.KILOS = New System.Windows.Forms.DataGridTextBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.Panel
        Me.CHKCOND = New System.Windows.Forms.CheckBox
        Me.CHKHIG = New System.Windows.Forms.CheckBox
        Me.CHKOLOR = New System.Windows.Forms.CheckBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(117, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.Text = "FECHA"
        '
        'Dt_fecha
        '
        Me.Dt_fecha.Enabled = False
        Me.Dt_fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dt_fecha.Location = New System.Drawing.Point(159, 7)
        Me.Dt_fecha.Name = "Dt_fecha"
        Me.Dt_fecha.Size = New System.Drawing.Size(79, 22)
        Me.Dt_fecha.TabIndex = 361
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.BtnGuardar.Location = New System.Drawing.Point(3, 862)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(55, 30)
        Me.BtnGuardar.TabIndex = 349
        Me.BtnGuardar.Text = "Guardar"
        '
        'btn_salir
        '
        Me.btn_salir.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.btn_salir.Location = New System.Drawing.Point(177, 862)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(55, 30)
        Me.btn_salir.TabIndex = 351
        Me.btn_salir.Text = "Salir"
        '
        'btn_nuevo
        '
        Me.btn_nuevo.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.btn_nuevo.Location = New System.Drawing.Point(61, 862)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(55, 30)
        Me.btn_nuevo.TabIndex = 350
        Me.btn_nuevo.Text = "Nuevo"
        '
        'txtsoportantes
        '
        Me.txtsoportantes.Enabled = False
        Me.txtsoportantes.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.txtsoportantes.Location = New System.Drawing.Point(35, 656)
        Me.txtsoportantes.MaxLength = 3
        Me.txtsoportantes.Name = "txtsoportantes"
        Me.txtsoportantes.Size = New System.Drawing.Size(25, 19)
        Me.txtsoportantes.TabIndex = 357
        Me.txtsoportantes.Text = "0"
        '
        'txtcajas
        '
        Me.txtcajas.Enabled = False
        Me.txtcajas.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.txtcajas.Location = New System.Drawing.Point(97, 657)
        Me.txtcajas.MaxLength = 3
        Me.txtcajas.Name = "txtcajas"
        Me.txtcajas.Size = New System.Drawing.Size(45, 19)
        Me.txtcajas.TabIndex = 358
        Me.txtcajas.Text = "0"
        '
        'txtkilos
        '
        Me.txtkilos.Enabled = False
        Me.txtkilos.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.txtkilos.Location = New System.Drawing.Point(177, 657)
        Me.txtkilos.MaxLength = 3
        Me.txtkilos.Name = "txtkilos"
        Me.txtkilos.Size = New System.Drawing.Size(54, 19)
        Me.txtkilos.TabIndex = 356
        Me.txtkilos.Text = "0"
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular)
        Me.Label25.Location = New System.Drawing.Point(151, 660)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(27, 13)
        Me.Label25.Text = "KG"
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular)
        Me.Label24.Location = New System.Drawing.Point(70, 658)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(28, 13)
        Me.Label24.Text = "CAJ"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular)
        Me.Label3.Location = New System.Drawing.Point(5, 658)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.Text = "SOP"
        '
        'CbEtiq
        '
        Me.CbEtiq.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.CbEtiq.Location = New System.Drawing.Point(16, 268)
        Me.CbEtiq.Name = "CbEtiq"
        Me.CbEtiq.Size = New System.Drawing.Size(137, 17)
        Me.CbEtiq.TabIndex = 367
        Me.CbEtiq.Text = "PARA ETIQUETADO"
        '
        'TxtNped
        '
        Me.TxtNped.Enabled = False
        Me.TxtNped.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.TxtNped.Location = New System.Drawing.Point(102, 98)
        Me.TxtNped.Name = "TxtNped"
        Me.TxtNped.Size = New System.Drawing.Size(41, 19)
        Me.TxtNped.TabIndex = 368
        Me.TxtNped.Text = "0"
        '
        'Temp3
        '
        Me.Temp3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Temp3.Location = New System.Drawing.Point(132, 60)
        Me.Temp3.MaxLength = 4
        Me.Temp3.Name = "Temp3"
        Me.Temp3.Size = New System.Drawing.Size(36, 19)
        Me.Temp3.TabIndex = 340
        '
        'Cant
        '
        Me.Cant.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Cant.Location = New System.Drawing.Point(202, 458)
        Me.Cant.MaxLength = 3
        Me.Cant.Name = "Cant"
        Me.Cant.Size = New System.Drawing.Size(30, 19)
        Me.Cant.TabIndex = 348
        Me.Cant.Visible = False
        '
        'CbPedido
        '
        Me.CbPedido.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.CbPedido.Location = New System.Drawing.Point(68, 99)
        Me.CbPedido.Name = "CbPedido"
        Me.CbPedido.Size = New System.Drawing.Size(27, 16)
        Me.CbPedido.TabIndex = 366
        Me.CbPedido.Visible = False
        '
        'Lbl_EstadoGuia
        '
        Me.Lbl_EstadoGuia.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Lbl_EstadoGuia.ForeColor = System.Drawing.Color.Blue
        Me.Lbl_EstadoGuia.Location = New System.Drawing.Point(173, 44)
        Me.Lbl_EstadoGuia.Name = "Lbl_EstadoGuia"
        Me.Lbl_EstadoGuia.Size = New System.Drawing.Size(57, 14)
        Me.Lbl_EstadoGuia.Text = "ACTIVA"
        '
        'Label35
        '
        Me.Label35.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label35.Location = New System.Drawing.Point(119, 44)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(62, 14)
        Me.Label35.Text = "ESTADO :"
        '
        'CbCant
        '
        Me.CbCant.Checked = True
        Me.CbCant.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CbCant.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.CbCant.Location = New System.Drawing.Point(180, 459)
        Me.CbCant.Name = "CbCant"
        Me.CbCant.Size = New System.Drawing.Size(62, 17)
        Me.CbCant.TabIndex = 360
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label23.Location = New System.Drawing.Point(170, 63)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(20, 15)
        Me.Label23.Text = "TP"
        '
        'tempprom
        '
        Me.tempprom.Enabled = False
        Me.tempprom.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.tempprom.Location = New System.Drawing.Point(188, 60)
        Me.tempprom.MaxLength = 4
        Me.tempprom.Name = "tempprom"
        Me.tempprom.Size = New System.Drawing.Size(36, 19)
        Me.tempprom.TabIndex = 341
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label22.Location = New System.Drawing.Point(116, 63)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(20, 15)
        Me.Label22.Text = "TI"
        '
        'btn_BuscaCliente
        '
        Me.btn_BuscaCliente.Location = New System.Drawing.Point(155, 6)
        Me.btn_BuscaCliente.Name = "btn_BuscaCliente"
        Me.btn_BuscaCliente.Size = New System.Drawing.Size(22, 22)
        Me.btn_BuscaCliente.TabIndex = 354
        Me.btn_BuscaCliente.Text = "..."
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label20.Location = New System.Drawing.Point(13, 127)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(40, 15)
        Me.Label20.Text = "CARGA"
        '
        'Txtdestino
        '
        Me.Txtdestino.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Txtdestino.Location = New System.Drawing.Point(71, 170)
        Me.Txtdestino.MaxLength = 20
        Me.Txtdestino.Name = "Txtdestino"
        Me.Txtdestino.Size = New System.Drawing.Size(134, 19)
        Me.Txtdestino.TabIndex = 346
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label15.Location = New System.Drawing.Point(3, 10)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(56, 13)
        Me.Label15.Text = "CLIENTE"
        '
        'txtpallet
        '
        Me.txtpallet.Enabled = False
        Me.txtpallet.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.txtpallet.Location = New System.Drawing.Point(19, 458)
        Me.txtpallet.Name = "txtpallet"
        Me.txtpallet.Size = New System.Drawing.Size(161, 19)
        Me.txtpallet.TabIndex = 347
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(2, 461)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(21, 13)
        Me.Label5.Text = "N°"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label4.Location = New System.Drawing.Point(13, 173)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.Text = "DESTINO"
        '
        'txtrut
        '
        Me.txtrut.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular)
        Me.txtrut.Location = New System.Drawing.Point(53, 8)
        Me.txtrut.MaxLength = 8
        Me.txtrut.Name = "txtrut"
        Me.txtrut.Size = New System.Drawing.Size(69, 20)
        Me.txtrut.TabIndex = 335
        '
        'TxtSello
        '
        Me.TxtSello.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular)
        Me.TxtSello.Location = New System.Drawing.Point(71, 219)
        Me.TxtSello.MaxLength = 50
        Me.TxtSello.Name = "TxtSello"
        Me.TxtSello.Size = New System.Drawing.Size(134, 20)
        Me.TxtSello.TabIndex = 345
        '
        'txtclinombre
        '
        Me.txtclinombre.Enabled = False
        Me.txtclinombre.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular)
        Me.txtclinombre.Location = New System.Drawing.Point(53, 34)
        Me.txtclinombre.Name = "txtclinombre"
        Me.txtclinombre.Size = New System.Drawing.Size(171, 20)
        Me.txtclinombre.TabIndex = 337
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label2.Location = New System.Drawing.Point(13, 223)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.Text = "SELLO"
        '
        'verificador
        '
        Me.verificador.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular)
        Me.verificador.Location = New System.Drawing.Point(132, 7)
        Me.verificador.MaxLength = 1
        Me.verificador.Name = "verificador"
        Me.verificador.Size = New System.Drawing.Size(19, 20)
        Me.verificador.TabIndex = 336
        '
        'CmboCarga
        '
        Me.CmboCarga.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.CmboCarga.Items.Add("Manual")
        Me.CmboCarga.Items.Add("Mecanica")
        Me.CmboCarga.Location = New System.Drawing.Point(71, 122)
        Me.CmboCarga.Name = "CmboCarga"
        Me.CmboCarga.Size = New System.Drawing.Size(134, 20)
        Me.CmboCarga.TabIndex = 342
        '
        'Temp1
        '
        Me.Temp1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Temp1.Location = New System.Drawing.Point(20, 60)
        Me.Temp1.MaxLength = 4
        Me.Temp1.Name = "Temp1"
        Me.Temp1.Size = New System.Drawing.Size(36, 19)
        Me.Temp1.TabIndex = 338
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label1.Location = New System.Drawing.Point(3, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 15)
        Me.Label1.Text = "TS"
        '
        'Temp2
        '
        Me.Temp2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Temp2.Location = New System.Drawing.Point(77, 60)
        Me.Temp2.MaxLength = 4
        Me.Temp2.Name = "Temp2"
        Me.Temp2.Size = New System.Drawing.Size(36, 19)
        Me.Temp2.TabIndex = 339
        '
        'Cb1
        '
        Me.Cb1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Cb1.Location = New System.Drawing.Point(16, 245)
        Me.Cb1.Name = "Cb1"
        Me.Cb1.Size = New System.Drawing.Size(150, 17)
        Me.Cb1.TabIndex = 355
        Me.Cb1.Text = "SOL. MENOR A 24 HRS."
        '
        'TxtContenedor
        '
        Me.TxtContenedor.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular)
        Me.TxtContenedor.Location = New System.Drawing.Point(71, 194)
        Me.TxtContenedor.MaxLength = 50
        Me.TxtContenedor.Name = "TxtContenedor"
        Me.TxtContenedor.Size = New System.Drawing.Size(134, 20)
        Me.TxtContenedor.TabIndex = 343
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label17.Location = New System.Drawing.Point(13, 198)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(38, 13)
        Me.Label17.Text = "CONT."
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label18.Location = New System.Drawing.Point(13, 150)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(47, 15)
        Me.Label18.Text = "RAMPLA"
        '
        'Txtrampla
        '
        Me.Txtrampla.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Txtrampla.Location = New System.Drawing.Point(72, 146)
        Me.Txtrampla.MaxLength = 15
        Me.Txtrampla.Name = "Txtrampla"
        Me.Txtrampla.Size = New System.Drawing.Size(133, 19)
        Me.Txtrampla.TabIndex = 344
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(124, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(12, 13)
        Me.Label8.Text = "-"
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label21.Location = New System.Drawing.Point(57, 63)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(20, 15)
        Me.Label21.Text = "TM"
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(3, 10)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(42, 13)
        Me.Label19.Text = "FOLIO"
        '
        'lblcodigo
        '
        Me.lblcodigo.Location = New System.Drawing.Point(44, 7)
        Me.lblcodigo.Name = "lblcodigo"
        Me.lblcodigo.Size = New System.Drawing.Size(68, 21)
        Me.lblcodigo.TabIndex = 333
        '
        'TxtObs
        '
        Me.TxtObs.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.TxtObs.Location = New System.Drawing.Point(3, 700)
        Me.TxtObs.MaxLength = 255
        Me.TxtObs.Multiline = True
        Me.TxtObs.Name = "TxtObs"
        Me.TxtObs.Size = New System.Drawing.Size(229, 73)
        Me.TxtObs.TabIndex = 359
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label12.Location = New System.Drawing.Point(0, 683)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(117, 20)
        Me.Label12.Text = "OBSERVACION"
        '
        'Label9
        '
        Me.Label9.ForeColor = System.Drawing.Color.Silver
        Me.Label9.Location = New System.Drawing.Point(5, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(234, 17)
        Me.Label9.Text = "_________________________________________________________________________________" & _
            "__"
        '
        'Label7
        '
        Me.Label7.ForeColor = System.Drawing.Color.Silver
        Me.Label7.Location = New System.Drawing.Point(3, 361)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(232, 17)
        Me.Label7.Text = "_________________________________________________________________________________" & _
            "___"
        '
        'Btn_AnulaGuia
        '
        Me.Btn_AnulaGuia.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Btn_AnulaGuia.Location = New System.Drawing.Point(119, 862)
        Me.Btn_AnulaGuia.Name = "Btn_AnulaGuia"
        Me.Btn_AnulaGuia.Size = New System.Drawing.Size(55, 30)
        Me.Btn_AnulaGuia.TabIndex = 353
        Me.Btn_AnulaGuia.Text = "Anular"
        '
        'Timer1
        '
        Me.Timer1.Interval = 5000
        '
        'Timer2
        '
        Me.Timer2.Interval = 300
        '
        'Lblpalletsped
        '
        Me.Lblpalletsped.Location = New System.Drawing.Point(5, 791)
        Me.Lblpalletsped.Name = "Lblpalletsped"
        Me.Lblpalletsped.Size = New System.Drawing.Size(224, 59)
        Me.Lblpalletsped.Text = "  "
        Me.Lblpalletsped.Visible = False
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(0, 777)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(170, 16)
        Me.Label10.Text = " SOPORTANTES DEL PEDIDO   "
        '
        'DgvSoportantes
        '
        Me.DgvSoportantes.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DgvSoportantes.Location = New System.Drawing.Point(5, 480)
        Me.DgvSoportantes.Name = "DgvSoportantes"
        Me.DgvSoportantes.Size = New System.Drawing.Size(227, 170)
        Me.DgvSoportantes.TabIndex = 413
        Me.DgvSoportantes.TableStyles.Add(Me.DataGridTableStyle1)
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.GridColumnStyles.Add(Me.CODIGO)
        Me.DataGridTableStyle1.GridColumnStyles.Add(Me.PRODUCTO)
        Me.DataGridTableStyle1.GridColumnStyles.Add(Me.CAJ)
        Me.DataGridTableStyle1.GridColumnStyles.Add(Me.KILOS)
        '
        'CODIGO
        '
        Me.CODIGO.Format = ""
        Me.CODIGO.FormatInfo = Nothing
        Me.CODIGO.HeaderText = "CODIGO"
        Me.CODIGO.MappingName = "dpre_folio"
        Me.CODIGO.Width = 70
        '
        'PRODUCTO
        '
        Me.PRODUCTO.Format = ""
        Me.PRODUCTO.FormatInfo = Nothing
        Me.PRODUCTO.HeaderText = "PRODUCTO"
        Me.PRODUCTO.MappingName = "mae_descr"
        Me.PRODUCTO.Width = 120
        '
        'CAJ
        '
        Me.CAJ.Format = ""
        Me.CAJ.FormatInfo = Nothing
        Me.CAJ.HeaderText = "CAJ"
        Me.CAJ.MappingName = "dpre_unidades"
        '
        'KILOS
        '
        Me.KILOS.Format = ""
        Me.KILOS.FormatInfo = Nothing
        Me.KILOS.HeaderText = "KILOS"
        Me.KILOS.MappingName = "dpre_peso"
        Me.KILOS.Width = 65
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CHKCOND)
        Me.GroupBox1.Controls.Add(Me.CHKHIG)
        Me.GroupBox1.Controls.Add(Me.CHKOLOR)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Txtrampla)
        Me.GroupBox1.Controls.Add(Me.TxtContenedor)
        Me.GroupBox1.Controls.Add(Me.Cb1)
        Me.GroupBox1.Controls.Add(Me.Temp2)
        Me.GroupBox1.Controls.Add(Me.Temp1)
        Me.GroupBox1.Controls.Add(Me.CmboCarga)
        Me.GroupBox1.Controls.Add(Me.verificador)
        Me.GroupBox1.Controls.Add(Me.txtclinombre)
        Me.GroupBox1.Controls.Add(Me.CbEtiq)
        Me.GroupBox1.Controls.Add(Me.TxtSello)
        Me.GroupBox1.Controls.Add(Me.TxtNped)
        Me.GroupBox1.Controls.Add(Me.txtrut)
        Me.GroupBox1.Controls.Add(Me.Temp3)
        Me.GroupBox1.Controls.Add(Me.Txtdestino)
        Me.GroupBox1.Controls.Add(Me.CbPedido)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.btn_BuscaCliente)
        Me.GroupBox1.Controls.Add(Me.tempprom)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(3, 61)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(235, 391)
        '
        'CHKCOND
        '
        Me.CHKCOND.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.CHKCOND.Location = New System.Drawing.Point(16, 337)
        Me.CHKCOND.Name = "CHKCOND"
        Me.CHKCOND.Size = New System.Drawing.Size(137, 17)
        Me.CHKCOND.TabIndex = 386
        Me.CHKCOND.Text = "CONDENSACION"
        '
        'CHKHIG
        '
        Me.CHKHIG.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.CHKHIG.Location = New System.Drawing.Point(16, 314)
        Me.CHKHIG.Name = "CHKHIG"
        Me.CHKHIG.Size = New System.Drawing.Size(137, 17)
        Me.CHKHIG.TabIndex = 385
        Me.CHKHIG.Text = "HIGIENE"
        '
        'CHKOLOR
        '
        Me.CHKOLOR.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.CHKOLOR.Location = New System.Drawing.Point(16, 291)
        Me.CHKOLOR.Name = "CHKOLOR"
        Me.CHKOLOR.Size = New System.Drawing.Size(137, 17)
        Me.CHKOLOR.TabIndex = 384
        Me.CHKOLOR.Text = "OLORES EXTRAÑOS"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(148, 97)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(29, 20)
        Me.Button1.TabIndex = 380
        Me.Button1.Text = "x"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(13, 99)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 16)
        Me.Label11.Text = "PEDIDO"
        '
        'Label13
        '
        Me.Label13.ForeColor = System.Drawing.Color.Silver
        Me.Label13.Location = New System.Drawing.Point(5, 75)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(229, 17)
        Me.Label13.Text = "_________________________________________________________________________________" & _
            "__"
        '
        'Frm_PreDespacho
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(250, 905)
        Me.Controls.Add(Me.Dt_fecha)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DgvSoportantes)
        Me.Controls.Add(Me.Lblpalletsped)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Btn_AnulaGuia)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.btn_salir)
        Me.Controls.Add(Me.btn_nuevo)
        Me.Controls.Add(Me.txtsoportantes)
        Me.Controls.Add(Me.txtcajas)
        Me.Controls.Add(Me.txtkilos)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Cant)
        Me.Controls.Add(Me.CbCant)
        Me.Controls.Add(Me.txtpallet)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblcodigo)
        Me.Controls.Add(Me.Lbl_EstadoGuia)
        Me.Controls.Add(Me.TxtObs)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label19)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Menu = Me.mainMenu1
        Me.Name = "Frm_PreDespacho"
        Me.Text = "Pre - Despacho"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Dt_fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents txtsoportantes As System.Windows.Forms.TextBox
    Friend WithEvents txtcajas As System.Windows.Forms.TextBox
    Friend WithEvents txtkilos As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CbEtiq As System.Windows.Forms.CheckBox
    Friend WithEvents TxtNped As System.Windows.Forms.TextBox
    Friend WithEvents Temp3 As System.Windows.Forms.TextBox
    Friend WithEvents Cant As System.Windows.Forms.TextBox
    Friend WithEvents CbPedido As System.Windows.Forms.CheckBox
    Friend WithEvents Lbl_EstadoGuia As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents CbCant As System.Windows.Forms.CheckBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents tempprom As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents btn_BuscaCliente As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Txtdestino As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtpallet As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtrut As System.Windows.Forms.TextBox
    Friend WithEvents TxtSello As System.Windows.Forms.TextBox
    Friend WithEvents txtclinombre As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents verificador As System.Windows.Forms.TextBox
    Friend WithEvents CmboCarga As System.Windows.Forms.ComboBox
    Friend WithEvents Temp1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Temp2 As System.Windows.Forms.TextBox
    Friend WithEvents Cb1 As System.Windows.Forms.CheckBox
    Friend WithEvents TxtContenedor As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Txtrampla As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblcodigo As System.Windows.Forms.TextBox
    Friend WithEvents TxtObs As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Btn_AnulaGuia As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Lblpalletsped As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents DgvSoportantes As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents CODIGO As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents PRODUCTO As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents CAJ As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents KILOS As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CHKCOND As System.Windows.Forms.CheckBox
    Friend WithEvents CHKHIG As System.Windows.Forms.CheckBox
    Friend WithEvents CHKOLOR As System.Windows.Forms.CheckBox
End Class
