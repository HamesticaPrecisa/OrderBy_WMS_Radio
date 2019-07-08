<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Frm_Preparar
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
        Me.ped1 = New System.Windows.Forms.TextBox
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.TxtPallet = New System.Windows.Forms.TextBox
        Me.Btn_LimpiaPedido = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Bnt_Salir = New System.Windows.Forms.Button
        Me.txtposicion = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.ped2 = New System.Windows.Forms.TextBox
        Me.ped3 = New System.Windows.Forms.TextBox
        Me.BtnBuscar = New System.Windows.Forms.Button
        Me.lmensaje = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.txtnivel = New System.Windows.Forms.TextBox
        Me.txtpiso = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtcolumna = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtbanda = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtcamara = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.Label11 = New System.Windows.Forms.Label
        Me.btn_pedidos_pendientes = New System.Windows.Forms.Button
        Me.btn_limpiar = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'ped1
        '
        Me.ped1.Location = New System.Drawing.Point(84, 3)
        Me.ped1.Name = "ped1"
        Me.ped1.Size = New System.Drawing.Size(39, 21)
        Me.ped1.TabIndex = 0
        '
        'DataGrid1
        '
        Me.DataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.DataGrid1.Location = New System.Drawing.Point(3, 27)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(221, 147)
        Me.DataGrid1.TabIndex = 3
        Me.DataGrid1.TableStyles.Add(Me.DataGridTableStyle1)
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.GridColumnStyles.Add(Me.DataGridTextBoxColumn1)
        Me.DataGridTableStyle1.GridColumnStyles.Add(Me.DataGridTextBoxColumn2)
        Me.DataGridTableStyle1.GridColumnStyles.Add(Me.DataGridTextBoxColumn3)
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "Pallets"
        Me.DataGridTextBoxColumn1.MappingName = "pallet"
        Me.DataGridTextBoxColumn1.Width = 90
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Posicion"
        Me.DataGridTextBoxColumn2.MappingName = "posicion"
        Me.DataGridTextBoxColumn2.Width = 180
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "Orden"
        Me.DataGridTextBoxColumn3.MappingName = "orden"
        Me.DataGridTextBoxColumn3.Width = 70
        '
        'TxtPallet
        '
        Me.TxtPallet.Location = New System.Drawing.Point(72, 206)
        Me.TxtPallet.Name = "TxtPallet"
        Me.TxtPallet.Size = New System.Drawing.Size(165, 21)
        Me.TxtPallet.TabIndex = 4
        '
        'Btn_LimpiaPedido
        '
        Me.Btn_LimpiaPedido.Location = New System.Drawing.Point(84, 352)
        Me.Btn_LimpiaPedido.Name = "Btn_LimpiaPedido"
        Me.Btn_LimpiaPedido.Size = New System.Drawing.Size(80, 20)
        Me.Btn_LimpiaPedido.TabIndex = 6
        Me.Btn_LimpiaPedido.Text = "Cancelar"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(62, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 21)
        Me.Label2.Text = "N°"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(226, 240)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(12, 20)
        '
        'Bnt_Salir
        '
        Me.Bnt_Salir.Location = New System.Drawing.Point(170, 352)
        Me.Bnt_Salir.Name = "Bnt_Salir"
        Me.Bnt_Salir.Size = New System.Drawing.Size(65, 20)
        Me.Bnt_Salir.TabIndex = 18
        Me.Bnt_Salir.Text = "Salir"
        '
        'txtposicion
        '
        Me.txtposicion.Location = New System.Drawing.Point(73, 237)
        Me.txtposicion.Name = "txtposicion"
        Me.txtposicion.Size = New System.Drawing.Size(151, 21)
        Me.txtposicion.TabIndex = 22
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Silver
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label1.Location = New System.Drawing.Point(0, 205)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(240, 25)
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Silver
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(8, 210)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 20)
        Me.Label4.Text = "PALLET"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Silver
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(8, 239)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 20)
        Me.Label3.Text = "POSICION"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Silver
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label5.Location = New System.Drawing.Point(2, 234)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(232, 27)
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(3, 352)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 20)
        Me.Button1.TabIndex = 28
        Me.Button1.Text = "Posicionar"
        '
        'ped2
        '
        Me.ped2.Enabled = False
        Me.ped2.Location = New System.Drawing.Point(124, 3)
        Me.ped2.Name = "ped2"
        Me.ped2.Size = New System.Drawing.Size(39, 21)
        Me.ped2.TabIndex = 35
        '
        'ped3
        '
        Me.ped3.Enabled = False
        Me.ped3.Location = New System.Drawing.Point(164, 3)
        Me.ped3.Name = "ped3"
        Me.ped3.Size = New System.Drawing.Size(39, 21)
        Me.ped3.TabIndex = 36
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Location = New System.Drawing.Point(204, 3)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(20, 21)
        Me.BtnBuscar.TabIndex = 37
        Me.BtnBuscar.Text = "..."
        '
        'lmensaje
        '
        Me.lmensaje.ForeColor = System.Drawing.Color.Red
        Me.lmensaje.Location = New System.Drawing.Point(9, 327)
        Me.lmensaje.Name = "lmensaje"
        Me.lmensaje.Size = New System.Drawing.Size(233, 18)
        '
        'Timer1
        '
        Me.Timer1.Interval = 2000
        '
        'txtnivel
        '
        Me.txtnivel.Location = New System.Drawing.Point(120, 299)
        Me.txtnivel.MaxLength = 1
        Me.txtnivel.Name = "txtnivel"
        Me.txtnivel.Size = New System.Drawing.Size(29, 21)
        Me.txtnivel.TabIndex = 47
        '
        'txtpiso
        '
        Me.txtpiso.Location = New System.Drawing.Point(51, 299)
        Me.txtpiso.MaxLength = 2
        Me.txtpiso.Name = "txtpiso"
        Me.txtpiso.Size = New System.Drawing.Size(29, 21)
        Me.txtpiso.TabIndex = 46
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Silver
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(80, 304)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 17)
        Me.Label6.Text = "Nivel"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Silver
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(4, 298)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(238, 23)
        '
        'txtcolumna
        '
        Me.txtcolumna.Enabled = False
        Me.txtcolumna.Location = New System.Drawing.Point(202, 269)
        Me.txtcolumna.MaxLength = 2
        Me.txtcolumna.Name = "txtcolumna"
        Me.txtcolumna.Size = New System.Drawing.Size(29, 21)
        Me.txtcolumna.TabIndex = 63
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Silver
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(150, 272)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 18)
        Me.Label8.Text = "Columna"
        '
        'txtbanda
        '
        Me.txtbanda.Enabled = False
        Me.txtbanda.Location = New System.Drawing.Point(120, 269)
        Me.txtbanda.MaxLength = 2
        Me.txtbanda.Name = "txtbanda"
        Me.txtbanda.Size = New System.Drawing.Size(29, 21)
        Me.txtbanda.TabIndex = 62
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Silver
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(81, 272)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 18)
        Me.Label9.Text = "Banda"
        '
        'txtcamara
        '
        Me.txtcamara.Enabled = False
        Me.txtcamara.Location = New System.Drawing.Point(51, 269)
        Me.txtcamara.MaxLength = 2
        Me.txtcamara.Name = "txtcamara"
        Me.txtcamara.Size = New System.Drawing.Size(29, 21)
        Me.txtcamara.TabIndex = 61
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Silver
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(4, 272)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 18)
        Me.Label10.Text = "Cámara"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Silver
        Me.PictureBox2.Location = New System.Drawing.Point(0, 265)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(237, 30)
        '
        'RadioButton1
        '
        Me.RadioButton1.Location = New System.Drawing.Point(3, 180)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(71, 20)
        Me.RadioButton1.TabIndex = 68
        Me.RadioButton1.Text = "Pistola"
        '
        'RadioButton2
        '
        Me.RadioButton2.Location = New System.Drawing.Point(83, 180)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(100, 20)
        Me.RadioButton2.TabIndex = 69
        Me.RadioButton2.Text = "Manual"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Silver
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(5, 304)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 17)
        Me.Label11.Text = "Piso"
        '
        'btn_pedidos_pendientes
        '
        Me.btn_pedidos_pendientes.Location = New System.Drawing.Point(9, 2)
        Me.btn_pedidos_pendientes.Name = "btn_pedidos_pendientes"
        Me.btn_pedidos_pendientes.Size = New System.Drawing.Size(30, 21)
        Me.btn_pedidos_pendientes.TabIndex = 83
        Me.btn_pedidos_pendientes.Text = "P.P."
        '
        'btn_limpiar
        '
        Me.btn_limpiar.Location = New System.Drawing.Point(41, 2)
        Me.btn_limpiar.Name = "btn_limpiar"
        Me.btn_limpiar.Size = New System.Drawing.Size(18, 21)
        Me.btn_limpiar.TabIndex = 98
        Me.btn_limpiar.Text = "L"
        '
        'Frm_Preparar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.btn_limpiar)
        Me.Controls.Add(Me.btn_pedidos_pendientes)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.txtcolumna)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtbanda)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtcamara)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.txtnivel)
        Me.Controls.Add(Me.txtpiso)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lmensaje)
        Me.Controls.Add(Me.BtnBuscar)
        Me.Controls.Add(Me.ped3)
        Me.Controls.Add(Me.ped2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtposicion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtPallet)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Bnt_Salir)
        Me.Controls.Add(Me.Btn_LimpiaPedido)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.ped1)
        Me.Controls.Add(Me.Label2)
        Me.KeyPreview = True
        Me.Name = "Frm_Preparar"
        Me.Text = "Preparación de pedidos"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents TxtPallet As System.Windows.Forms.TextBox
    Friend WithEvents Btn_LimpiaPedido As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Bnt_Salir As System.Windows.Forms.Button
    Friend WithEvents txtposicion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ped2 As System.Windows.Forms.TextBox
    Friend WithEvents ped3 As System.Windows.Forms.TextBox
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents lmensaje As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents txtnivel As System.Windows.Forms.TextBox
    Friend WithEvents txtpiso As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtcolumna As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtbanda As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtcamara As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btn_pedidos_pendientes As System.Windows.Forms.Button
    Public WithEvents ped1 As System.Windows.Forms.TextBox
    Friend WithEvents btn_limpiar As System.Windows.Forms.Button
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
End Class
