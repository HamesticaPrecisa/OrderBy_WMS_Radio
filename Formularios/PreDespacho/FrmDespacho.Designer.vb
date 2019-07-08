<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FrmDespacho
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

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar con el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDespacho))
        Me.Pre = New System.Windows.Forms.TabPage
        Me.Label14 = New System.Windows.Forms.Label
        Me.TxtObs = New System.Windows.Forms.TextBox
        Me.Txtdestino = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtSello = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Lst_pallets = New System.Windows.Forms.ListBox
        Me.txtcajas = New System.Windows.Forms.TextBox
        Me.Temp3 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.BtnGuardar = New System.Windows.Forms.PictureBox
        Me.BtnSalir = New System.Windows.Forms.PictureBox
        Me.BtnNuevo = New System.Windows.Forms.PictureBox
        Me.txtpallet = New System.Windows.Forms.TextBox
        Me.txtsoportantes = New System.Windows.Forms.TextBox
        Me.txtkilos = New System.Windows.Forms.TextBox
        Me.verificador = New System.Windows.Forms.TextBox
        Me.txtrut = New System.Windows.Forms.TextBox
        Me.txtclinombre = New System.Windows.Forms.TextBox
        Me.CmboCarga = New System.Windows.Forms.ComboBox
        Me.Temp1 = New System.Windows.Forms.TextBox
        Me.Temp2 = New System.Windows.Forms.TextBox
        Me.Txtrampla = New System.Windows.Forms.TextBox
        Me.TxtContenedor = New System.Windows.Forms.TextBox
        Me.BtnLimpiaPallet = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Btn_Pendientes = New System.Windows.Forms.Button
        Me.LblCodigo = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Cb1 = New System.Windows.Forms.CheckBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Btn_Cliente = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Tabmenu = New System.Windows.Forms.TabControl
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Pre.SuspendLayout()
        Me.Tabmenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pre
        '
        Me.Pre.AutoScroll = True
        Me.Pre.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Pre.Controls.Add(Me.Label19)
        Me.Pre.Controls.Add(Me.Label15)
        Me.Pre.Controls.Add(Me.Label14)
        Me.Pre.Controls.Add(Me.TxtObs)
        Me.Pre.Controls.Add(Me.Txtdestino)
        Me.Pre.Controls.Add(Me.Label4)
        Me.Pre.Controls.Add(Me.TxtSello)
        Me.Pre.Controls.Add(Me.Label2)
        Me.Pre.Controls.Add(Me.Lst_pallets)
        Me.Pre.Controls.Add(Me.txtcajas)
        Me.Pre.Controls.Add(Me.Temp3)
        Me.Pre.Controls.Add(Me.Label10)
        Me.Pre.Controls.Add(Me.Label9)
        Me.Pre.Controls.Add(Me.Label8)
        Me.Pre.Controls.Add(Me.BtnGuardar)
        Me.Pre.Controls.Add(Me.BtnSalir)
        Me.Pre.Controls.Add(Me.BtnNuevo)
        Me.Pre.Controls.Add(Me.txtpallet)
        Me.Pre.Controls.Add(Me.txtsoportantes)
        Me.Pre.Controls.Add(Me.txtkilos)
        Me.Pre.Controls.Add(Me.verificador)
        Me.Pre.Controls.Add(Me.txtrut)
        Me.Pre.Controls.Add(Me.txtclinombre)
        Me.Pre.Controls.Add(Me.CmboCarga)
        Me.Pre.Controls.Add(Me.Temp1)
        Me.Pre.Controls.Add(Me.Temp2)
        Me.Pre.Controls.Add(Me.Txtrampla)
        Me.Pre.Controls.Add(Me.TxtContenedor)
        Me.Pre.Controls.Add(Me.BtnLimpiaPallet)
        Me.Pre.Controls.Add(Me.Label3)
        Me.Pre.Controls.Add(Me.Label5)
        Me.Pre.Controls.Add(Me.Btn_Pendientes)
        Me.Pre.Controls.Add(Me.LblCodigo)
        Me.Pre.Controls.Add(Me.Label11)
        Me.Pre.Controls.Add(Me.Cb1)
        Me.Pre.Controls.Add(Me.Label16)
        Me.Pre.Controls.Add(Me.Label6)
        Me.Pre.Controls.Add(Me.Btn_Cliente)
        Me.Pre.Controls.Add(Me.Label13)
        Me.Pre.Controls.Add(Me.Label7)
        Me.Pre.Controls.Add(Me.Label1)
        Me.Pre.Controls.Add(Me.Label18)
        Me.Pre.Controls.Add(Me.Label17)
        Me.Pre.Controls.Add(Me.Label12)
        Me.Pre.Location = New System.Drawing.Point(0, 0)
        Me.Pre.Name = "Pre"
        Me.Pre.Size = New System.Drawing.Size(241, 581)
        Me.Pre.Text = "Pre-Despacho"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(0, 23)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(226, 1)
        '
        'TxtObs
        '
        Me.TxtObs.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.TxtObs.Location = New System.Drawing.Point(7, 448)
        Me.TxtObs.Multiline = True
        Me.TxtObs.Name = "TxtObs"
        Me.TxtObs.Size = New System.Drawing.Size(219, 63)
        Me.TxtObs.TabIndex = 238
        '
        'Txtdestino
        '
        Me.Txtdestino.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Txtdestino.Location = New System.Drawing.Point(53, 195)
        Me.Txtdestino.MaxLength = 20
        Me.Txtdestino.Name = "Txtdestino"
        Me.Txtdestino.Size = New System.Drawing.Size(141, 19)
        Me.Txtdestino.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label4.Location = New System.Drawing.Point(2, 197)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 19)
        Me.Label4.Text = "DESTINO"
        '
        'TxtSello
        '
        Me.TxtSello.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.TxtSello.Location = New System.Drawing.Point(53, 173)
        Me.TxtSello.MaxLength = 50
        Me.TxtSello.Name = "TxtSello"
        Me.TxtSello.Size = New System.Drawing.Size(141, 19)
        Me.TxtSello.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label2.Location = New System.Drawing.Point(2, 174)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 19)
        Me.Label2.Text = "SELLO"
        '
        'Lst_pallets
        '
        Me.Lst_pallets.Location = New System.Drawing.Point(7, 254)
        Me.Lst_pallets.Name = "Lst_pallets"
        Me.Lst_pallets.Size = New System.Drawing.Size(226, 142)
        Me.Lst_pallets.TabIndex = 192
        '
        'txtcajas
        '
        Me.txtcajas.Enabled = False
        Me.txtcajas.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.txtcajas.Location = New System.Drawing.Point(78, 401)
        Me.txtcajas.MaxLength = 3
        Me.txtcajas.Name = "txtcajas"
        Me.txtcajas.Size = New System.Drawing.Size(36, 19)
        Me.txtcajas.TabIndex = 171
        '
        'Temp3
        '
        Me.Temp3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Temp3.Location = New System.Drawing.Point(125, 95)
        Me.Temp3.MaxLength = 5
        Me.Temp3.Name = "Temp3"
        Me.Temp3.Size = New System.Drawing.Size(35, 19)
        Me.Temp3.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular)
        Me.Label10.Location = New System.Drawing.Point(158, 563)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 12)
        Me.Label10.Text = "Salir"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular)
        Me.Label9.Location = New System.Drawing.Point(96, 563)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 12)
        Me.Label9.Text = "Nuevo"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular)
        Me.Label8.Location = New System.Drawing.Point(28, 563)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 12)
        Me.Label8.Text = "Guardar"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(28, 517)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(41, 43)
        Me.BtnGuardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'BtnSalir
        '
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.Location = New System.Drawing.Point(158, 517)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(41, 43)
        Me.BtnSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Image = CType(resources.GetObject("BtnNuevo.Image"), System.Drawing.Image)
        Me.BtnNuevo.Location = New System.Drawing.Point(96, 517)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(41, 43)
        Me.BtnNuevo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'txtpallet
        '
        Me.txtpallet.Enabled = False
        Me.txtpallet.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.txtpallet.Location = New System.Drawing.Point(33, 226)
        Me.txtpallet.Name = "txtpallet"
        Me.txtpallet.Size = New System.Drawing.Size(171, 19)
        Me.txtpallet.TabIndex = 13
        '
        'txtsoportantes
        '
        Me.txtsoportantes.Enabled = False
        Me.txtsoportantes.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.txtsoportantes.Location = New System.Drawing.Point(30, 401)
        Me.txtsoportantes.MaxLength = 3
        Me.txtsoportantes.Name = "txtsoportantes"
        Me.txtsoportantes.Size = New System.Drawing.Size(22, 19)
        Me.txtsoportantes.TabIndex = 124
        '
        'txtkilos
        '
        Me.txtkilos.Enabled = False
        Me.txtkilos.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.txtkilos.Location = New System.Drawing.Point(138, 401)
        Me.txtkilos.MaxLength = 3
        Me.txtkilos.Name = "txtkilos"
        Me.txtkilos.Size = New System.Drawing.Size(69, 19)
        Me.txtkilos.TabIndex = 123
        '
        'verificador
        '
        Me.verificador.Enabled = False
        Me.verificador.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular)
        Me.verificador.Location = New System.Drawing.Point(117, 30)
        Me.verificador.MaxLength = 1
        Me.verificador.Name = "verificador"
        Me.verificador.Size = New System.Drawing.Size(10, 18)
        Me.verificador.TabIndex = 3
        '
        'txtrut
        '
        Me.txtrut.Enabled = False
        Me.txtrut.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular)
        Me.txtrut.Location = New System.Drawing.Point(53, 30)
        Me.txtrut.MaxLength = 8
        Me.txtrut.Name = "txtrut"
        Me.txtrut.Size = New System.Drawing.Size(59, 18)
        Me.txtrut.TabIndex = 1
        '
        'txtclinombre
        '
        Me.txtclinombre.Enabled = False
        Me.txtclinombre.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular)
        Me.txtclinombre.Location = New System.Drawing.Point(53, 49)
        Me.txtclinombre.Name = "txtclinombre"
        Me.txtclinombre.Size = New System.Drawing.Size(173, 18)
        Me.txtclinombre.TabIndex = 23
        '
        'CmboCarga
        '
        Me.CmboCarga.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.CmboCarga.Items.Add("Manual")
        Me.CmboCarga.Items.Add("Mecanica")
        Me.CmboCarga.Location = New System.Drawing.Point(53, 71)
        Me.CmboCarga.Name = "CmboCarga"
        Me.CmboCarga.Size = New System.Drawing.Size(95, 20)
        Me.CmboCarga.TabIndex = 5
        '
        'Temp1
        '
        Me.Temp1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Temp1.Location = New System.Drawing.Point(53, 95)
        Me.Temp1.MaxLength = 5
        Me.Temp1.Name = "Temp1"
        Me.Temp1.Size = New System.Drawing.Size(35, 19)
        Me.Temp1.TabIndex = 6
        '
        'Temp2
        '
        Me.Temp2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Temp2.Location = New System.Drawing.Point(89, 95)
        Me.Temp2.MaxLength = 5
        Me.Temp2.Name = "Temp2"
        Me.Temp2.Size = New System.Drawing.Size(35, 19)
        Me.Temp2.TabIndex = 7
        '
        'Txtrampla
        '
        Me.Txtrampla.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Txtrampla.Location = New System.Drawing.Point(53, 151)
        Me.Txtrampla.MaxLength = 15
        Me.Txtrampla.Name = "Txtrampla"
        Me.Txtrampla.Size = New System.Drawing.Size(141, 19)
        Me.Txtrampla.TabIndex = 10
        '
        'TxtContenedor
        '
        Me.TxtContenedor.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.TxtContenedor.Location = New System.Drawing.Point(53, 129)
        Me.TxtContenedor.MaxLength = 50
        Me.TxtContenedor.Name = "TxtContenedor"
        Me.TxtContenedor.Size = New System.Drawing.Size(141, 19)
        Me.TxtContenedor.TabIndex = 9
        '
        'BtnLimpiaPallet
        '
        Me.BtnLimpiaPallet.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.BtnLimpiaPallet.Location = New System.Drawing.Point(205, 226)
        Me.BtnLimpiaPallet.Name = "BtnLimpiaPallet"
        Me.BtnLimpiaPallet.Size = New System.Drawing.Size(18, 18)
        Me.BtnLimpiaPallet.TabIndex = 128
        Me.BtnLimpiaPallet.Text = " X"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label3.Location = New System.Drawing.Point(11, 403)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(182, 20)
        Me.Label3.Text = "  P             C                 K"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(5, 228)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(22, 19)
        Me.Label5.Text = "N°"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Btn_Pendientes
        '
        Me.Btn_Pendientes.BackColor = System.Drawing.Color.Red
        Me.Btn_Pendientes.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Btn_Pendientes.ForeColor = System.Drawing.Color.White
        Me.Btn_Pendientes.Location = New System.Drawing.Point(153, 3)
        Me.Btn_Pendientes.Name = "Btn_Pendientes"
        Me.Btn_Pendientes.Size = New System.Drawing.Size(73, 17)
        Me.Btn_Pendientes.TabIndex = 87
        Me.Btn_Pendientes.Text = "Pendientes"
        '
        'LblCodigo
        '
        Me.LblCodigo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LblCodigo.Location = New System.Drawing.Point(41, 3)
        Me.LblCodigo.Name = "LblCodigo"
        Me.LblCodigo.Size = New System.Drawing.Size(71, 21)
        Me.LblCodigo.Text = "0000000"
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(3, 3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(36, 21)
        Me.Label11.Text = "Nº :"
        '
        'Cb1
        '
        Me.Cb1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Cb1.Location = New System.Drawing.Point(158, 70)
        Me.Cb1.Name = "Cb1"
        Me.Cb1.Size = New System.Drawing.Size(56, 19)
        Me.Cb1.TabIndex = 71
        Me.Cb1.Text = "50%"
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label16.Location = New System.Drawing.Point(2, 32)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(48, 17)
        Me.Label16.Text = "CLIENTE"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Silver
        Me.Label6.Location = New System.Drawing.Point(110, 31)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(11, 20)
        Me.Label6.Text = "-"
        '
        'Btn_Cliente
        '
        Me.Btn_Cliente.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Bold)
        Me.Btn_Cliente.Location = New System.Drawing.Point(128, 30)
        Me.Btn_Cliente.Name = "Btn_Cliente"
        Me.Btn_Cliente.Size = New System.Drawing.Size(18, 18)
        Me.Btn_Cliente.TabIndex = 4
        Me.Btn_Cliente.Text = "..."
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label13.Location = New System.Drawing.Point(2, 75)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(44, 20)
        Me.Label13.Text = "CARGA"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label7.Location = New System.Drawing.Point(2, 98)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 20)
        Me.Label7.Text = "TEMP"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label1.Location = New System.Drawing.Point(59, 113)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 11)
        Me.Label1.Text = "   1          2          3"
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label18.Location = New System.Drawing.Point(2, 154)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(49, 19)
        Me.Label18.Text = "RAMPLA"
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label17.Location = New System.Drawing.Point(1, 132)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(45, 19)
        Me.Label17.Text = "CONT."
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label12.Location = New System.Drawing.Point(7, 428)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 20)
        Me.Label12.Text = "OBSERVACION"
        '
        'Tabmenu
        '
        Me.Tabmenu.Controls.Add(Me.Pre)
        Me.Tabmenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tabmenu.Location = New System.Drawing.Point(0, 0)
        Me.Tabmenu.Name = "Tabmenu"
        Me.Tabmenu.SelectedIndex = 0
        Me.Tabmenu.Size = New System.Drawing.Size(241, 604)
        Me.Tabmenu.TabIndex = 85
        Me.Tabmenu.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 5000
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Black
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 5.0!, System.Drawing.FontStyle.Regular)
        Me.Label15.Location = New System.Drawing.Point(7, 221)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(226, 1)
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Black
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 5.0!, System.Drawing.FontStyle.Regular)
        Me.Label19.Location = New System.Drawing.Point(7, 250)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(226, 1)
        '
        'FrmDespacho
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(241, 604)
        Me.Controls.Add(Me.Tabmenu)
        Me.KeyPreview = True
        Me.Name = "FrmDespacho"
        Me.Text = "Pre - Despacho"
        Me.Pre.ResumeLayout(False)
        Me.Tabmenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pre As System.Windows.Forms.TabPage
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents BtnGuardar As System.Windows.Forms.PictureBox
    Friend WithEvents BtnSalir As System.Windows.Forms.PictureBox
    Friend WithEvents BtnNuevo As System.Windows.Forms.PictureBox
    Friend WithEvents txtpallet As System.Windows.Forms.TextBox
    Friend WithEvents txtsoportantes As System.Windows.Forms.TextBox
    Friend WithEvents txtkilos As System.Windows.Forms.TextBox
    Friend WithEvents verificador As System.Windows.Forms.TextBox
    Friend WithEvents txtrut As System.Windows.Forms.TextBox
    Friend WithEvents txtclinombre As System.Windows.Forms.TextBox
    Friend WithEvents CmboCarga As System.Windows.Forms.ComboBox
    Friend WithEvents Temp1 As System.Windows.Forms.TextBox
    Friend WithEvents Temp2 As System.Windows.Forms.TextBox
    Friend WithEvents Txtrampla As System.Windows.Forms.TextBox
    Friend WithEvents TxtContenedor As System.Windows.Forms.TextBox
    Friend WithEvents BtnLimpiaPallet As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Btn_Pendientes As System.Windows.Forms.Button
    Friend WithEvents LblCodigo As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Cb1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Btn_Cliente As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Tabmenu As System.Windows.Forms.TabControl
    Friend WithEvents Temp3 As System.Windows.Forms.TextBox
    Friend WithEvents txtcajas As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Lst_pallets As System.Windows.Forms.ListBox
    Friend WithEvents Txtdestino As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtSello As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TxtObs As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class
