<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Frm_IngresoTunel
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
        Me.txt_Guia = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_Pallet = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.mensaje = New System.Windows.Forms.Label
        Me.txt_Temp = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Color = New System.Windows.Forms.PictureBox
        Me.rb_Parcial = New System.Windows.Forms.RadioButton
        Me.Label8 = New System.Windows.Forms.Label
        Me.rb_Total = New System.Windows.Forms.RadioButton
        Me.lblcanttotal = New System.Windows.Forms.Label
        Me.cb_Tipo = New System.Windows.Forms.ComboBox
        Me.cb_posicion = New System.Windows.Forms.ComboBox
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.Pallet = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Temp = New System.Windows.Forms.DataGridTextBoxColumn
        Me.lbRazonSocial = New System.Windows.Forms.Label
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.dtpHora = New System.Windows.Forms.DateTimePicker
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cb_posicionar = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'txt_Guia
        '
        Me.txt_Guia.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.txt_Guia.Location = New System.Drawing.Point(168, 1)
        Me.txt_Guia.MaxLength = 30
        Me.txt_Guia.Name = "txt_Guia"
        Me.txt_Guia.Size = New System.Drawing.Size(69, 19)
        Me.txt_Guia.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(135, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 16)
        Me.Label1.Text = "Guia:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(1, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 16)
        Me.Label2.Text = "Tipo:"
        '
        'txt_Pallet
        '
        Me.txt_Pallet.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular)
        Me.txt_Pallet.Location = New System.Drawing.Point(56, 180)
        Me.txt_Pallet.MaxLength = 30
        Me.txt_Pallet.Name = "txt_Pallet"
        Me.txt_Pallet.Size = New System.Drawing.Size(148, 18)
        Me.txt_Pallet.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(1, 182)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 14)
        Me.Label3.Text = "Pallet:"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular)
        Me.Label6.Location = New System.Drawing.Point(19, 231)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(167, 11)
        Me.Label6.Text = "SI   corresponde a Guia (ya fue leída)"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular)
        Me.Label5.Location = New System.Drawing.Point(18, 220)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(115, 11)
        Me.Label5.Text = "NO  corresponde a Guia"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular)
        Me.Label4.Location = New System.Drawing.Point(19, 209)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 11)
        Me.Label4.Text = "SI   corresponde a Guia"
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Orange
        Me.PictureBox4.Location = New System.Drawing.Point(5, 231)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(11, 11)
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Red
        Me.PictureBox5.Location = New System.Drawing.Point(5, 220)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(11, 11)
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.Color.Green
        Me.PictureBox6.Location = New System.Drawing.Point(5, 209)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(11, 11)
        '
        'mensaje
        '
        Me.mensaje.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular)
        Me.mensaje.Location = New System.Drawing.Point(5, 245)
        Me.mensaje.Name = "mensaje"
        Me.mensaje.Size = New System.Drawing.Size(216, 16)
        '
        'txt_Temp
        '
        Me.txt_Temp.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular)
        Me.txt_Temp.Location = New System.Drawing.Point(56, 140)
        Me.txt_Temp.MaxLength = 3
        Me.txt_Temp.Name = "txt_Temp"
        Me.txt_Temp.Size = New System.Drawing.Size(24, 18)
        Me.txt_Temp.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.White
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(1, 142)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 18)
        Me.Label7.Text = "Temp.:"
        '
        'Color
        '
        Me.Color.Location = New System.Drawing.Point(205, 180)
        Me.Color.Name = "Color"
        Me.Color.Size = New System.Drawing.Size(25, 18)
        '
        'rb_Parcial
        '
        Me.rb_Parcial.BackColor = System.Drawing.Color.White
        Me.rb_Parcial.Checked = True
        Me.rb_Parcial.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold)
        Me.rb_Parcial.Location = New System.Drawing.Point(62, 34)
        Me.rb_Parcial.Name = "rb_Parcial"
        Me.rb_Parcial.Size = New System.Drawing.Size(59, 20)
        Me.rb_Parcial.TabIndex = 2
        Me.rb_Parcial.Text = "Parcial"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(3, 37)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 18)
        '
        'rb_Total
        '
        Me.rb_Total.BackColor = System.Drawing.Color.White
        Me.rb_Total.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold)
        Me.rb_Total.Location = New System.Drawing.Point(137, 34)
        Me.rb_Total.Name = "rb_Total"
        Me.rb_Total.Size = New System.Drawing.Size(49, 20)
        Me.rb_Total.TabIndex = 3
        Me.rb_Total.TabStop = False
        Me.rb_Total.Text = "Total"
        '
        'lblcanttotal
        '
        Me.lblcanttotal.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular)
        Me.lblcanttotal.Location = New System.Drawing.Point(189, 37)
        Me.lblcanttotal.Name = "lblcanttotal"
        Me.lblcanttotal.Size = New System.Drawing.Size(51, 14)
        Me.lblcanttotal.Tag = ""
        Me.lblcanttotal.Text = "0/0"
        Me.lblcanttotal.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cb_Tipo
        '
        Me.cb_Tipo.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.cb_Tipo.Items.Add("(Seleccione)")
        Me.cb_Tipo.Items.Add("Ingreso Tunel")
        Me.cb_Tipo.Items.Add("Salida Tunel")
        Me.cb_Tipo.Location = New System.Drawing.Point(33, 1)
        Me.cb_Tipo.Name = "cb_Tipo"
        Me.cb_Tipo.Size = New System.Drawing.Size(100, 20)
        Me.cb_Tipo.TabIndex = 0
        '
        'cb_posicion
        '
        Me.cb_posicion.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular)
        Me.cb_posicion.Location = New System.Drawing.Point(131, 140)
        Me.cb_posicion.Name = "cb_posicion"
        Me.cb_posicion.Size = New System.Drawing.Size(107, 19)
        Me.cb_posicion.TabIndex = 7
        '
        'DataGrid1
        '
        Me.DataGrid1.BackgroundColor = System.Drawing.Color.White
        Me.DataGrid1.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular)
        Me.DataGrid1.Location = New System.Drawing.Point(5, 52)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.RowHeadersVisible = False
        Me.DataGrid1.Size = New System.Drawing.Size(235, 67)
        Me.DataGrid1.TabIndex = 50
        Me.DataGrid1.TableStyles.Add(Me.DataGridTableStyle1)
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.GridColumnStyles.Add(Me.Pallet)
        Me.DataGridTableStyle1.GridColumnStyles.Add(Me.Temp)
        '
        'Pallet
        '
        Me.Pallet.Format = ""
        Me.Pallet.FormatInfo = Nothing
        Me.Pallet.HeaderText = "Palett"
        Me.Pallet.MappingName = "frec_codi"
        Me.Pallet.Width = 100
        '
        'Temp
        '
        Me.Temp.Format = ""
        Me.Temp.FormatInfo = Nothing
        Me.Temp.HeaderText = "Temp."
        Me.Temp.MappingName = "temp_ingreso"
        Me.Temp.Width = 100
        '
        'lbRazonSocial
        '
        Me.lbRazonSocial.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular)
        Me.lbRazonSocial.Location = New System.Drawing.Point(5, 21)
        Me.lbRazonSocial.Name = "lbRazonSocial"
        Me.lbRazonSocial.Size = New System.Drawing.Size(231, 15)
        '
        'dtpFecha
        '
        Me.dtpFecha.CustomFormat = "dd/mm/yyyy"
        Me.dtpFecha.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular)
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(56, 120)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(69, 19)
        Me.dtpFecha.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(1, 124)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 15)
        Me.Label9.Text = "Fecha:"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.White
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(130, 123)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 10)
        Me.Label10.Text = "Hora:"
        '
        'dtpHora
        '
        Me.dtpHora.CustomFormat = "HH:mm:ss"
        Me.dtpHora.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular)
        Me.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpHora.Location = New System.Drawing.Point(163, 120)
        Me.dtpHora.Name = "dtpHora"
        Me.dtpHora.ShowUpDown = True
        Me.dtpHora.Size = New System.Drawing.Size(75, 19)
        Me.dtpHora.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.White
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(83, 142)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 14)
        Me.Label11.Text = "Posicion:"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.White
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(1, 162)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 14)
        Me.Label12.Text = "Posicionar:"
        '
        'cb_posicionar
        '
        Me.cb_posicionar.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular)
        Me.cb_posicionar.Items.Add("SI")
        Me.cb_posicionar.Items.Add("NO")
        Me.cb_posicionar.Location = New System.Drawing.Point(56, 160)
        Me.cb_posicionar.Name = "cb_posicionar"
        Me.cb_posicionar.Size = New System.Drawing.Size(53, 19)
        Me.cb_posicionar.TabIndex = 8
        '
        'Frm_IngresoTunel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.cb_posicionar)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.dtpHora)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.lbRazonSocial)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.cb_posicion)
        Me.Controls.Add(Me.cb_Tipo)
        Me.Controls.Add(Me.lblcanttotal)
        Me.Controls.Add(Me.rb_Parcial)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.rb_Total)
        Me.Controls.Add(Me.Color)
        Me.Controls.Add(Me.txt_Temp)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.mensaje)
        Me.Controls.Add(Me.txt_Pallet)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_Guia)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.Menu = Me.mainMenu1
        Me.Name = "Frm_IngresoTunel"
        Me.Text = "Ingreso Tunel"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txt_Guia As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_Pallet As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents mensaje As System.Windows.Forms.Label
    Friend WithEvents txt_Temp As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Color As System.Windows.Forms.PictureBox
    Friend WithEvents rb_Parcial As System.Windows.Forms.RadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents rb_Total As System.Windows.Forms.RadioButton
    Friend WithEvents lblcanttotal As System.Windows.Forms.Label
    Friend WithEvents cb_Tipo As System.Windows.Forms.ComboBox
    Friend WithEvents cb_posicion As System.Windows.Forms.ComboBox
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents Pallet As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Temp As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents lbRazonSocial As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtpHora As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cb_posicionar As System.Windows.Forms.ComboBox
End Class
