<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Frm_Pos_Sug
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
        Me.txtpalet = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtcamara = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtbanda = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtcolumna = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtpiso = New System.Windows.Forms.TextBox
        Me.txtnivel = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtposicion = New System.Windows.Forms.TextBox
        Me.lmensaje = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.btn_buscar = New System.Windows.Forms.Button
        Me.lblcodigo = New System.Windows.Forms.Label
        Me.BtnLiberar = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.txtnivel2 = New System.Windows.Forms.TextBox
        Me.txtpiso2 = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtcolumna2 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtbanda2 = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtcamara2 = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.PictureBox7 = New System.Windows.Forms.PictureBox
        Me.BtnNuevo = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.txtpallete = New System.Windows.Forms.TextBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'txtpalet
        '
        Me.txtpalet.Location = New System.Drawing.Point(66, 8)
        Me.txtpalet.MaxLength = 30
        Me.txtpalet.Name = "txtpalet"
        Me.txtpalet.Size = New System.Drawing.Size(166, 21)
        Me.txtpalet.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Silver
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(4, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 19)
        Me.Label1.Text = "Nº Pallet"
        '
        'txtcamara
        '
        Me.txtcamara.Enabled = False
        Me.txtcamara.Location = New System.Drawing.Point(53, 39)
        Me.txtcamara.MaxLength = 2
        Me.txtcamara.Name = "txtcamara"
        Me.txtcamara.Size = New System.Drawing.Size(29, 21)
        Me.txtcamara.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Silver
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(6, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 18)
        Me.Label2.Text = "Cámara"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Silver
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(83, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 18)
        Me.Label3.Text = "Banda"
        '
        'txtbanda
        '
        Me.txtbanda.Enabled = False
        Me.txtbanda.Location = New System.Drawing.Point(122, 39)
        Me.txtbanda.MaxLength = 2
        Me.txtbanda.Name = "txtbanda"
        Me.txtbanda.Size = New System.Drawing.Size(29, 21)
        Me.txtbanda.TabIndex = 20
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Silver
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(152, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 18)
        Me.Label4.Text = "Columna"
        '
        'txtcolumna
        '
        Me.txtcolumna.Enabled = False
        Me.txtcolumna.Location = New System.Drawing.Point(204, 39)
        Me.txtcolumna.MaxLength = 2
        Me.txtcolumna.Name = "txtcolumna"
        Me.txtcolumna.Size = New System.Drawing.Size(29, 21)
        Me.txtcolumna.TabIndex = 23
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Silver
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(16, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 17)
        Me.Label5.Text = "Piso"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Silver
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(83, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 17)
        Me.Label6.Text = "Nivel"
        '
        'txtpiso
        '
        Me.txtpiso.Location = New System.Drawing.Point(53, 70)
        Me.txtpiso.MaxLength = 2
        Me.txtpiso.Name = "txtpiso"
        Me.txtpiso.Size = New System.Drawing.Size(29, 21)
        Me.txtpiso.TabIndex = 41
        '
        'txtnivel
        '
        Me.txtnivel.Location = New System.Drawing.Point(122, 70)
        Me.txtnivel.MaxLength = 1
        Me.txtnivel.Name = "txtnivel"
        Me.txtnivel.Size = New System.Drawing.Size(29, 21)
        Me.txtnivel.TabIndex = 42
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Silver
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(6, 101)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(117, 20)
        Me.Label7.Text = "Posición Sugerida"
        '
        'txtposicion
        '
        Me.txtposicion.Location = New System.Drawing.Point(31, 221)
        Me.txtposicion.MaxLength = 13
        Me.txtposicion.Name = "txtposicion"
        Me.txtposicion.Size = New System.Drawing.Size(171, 21)
        Me.txtposicion.TabIndex = 32
        '
        'lmensaje
        '
        Me.lmensaje.Location = New System.Drawing.Point(6, 268)
        Me.lmensaje.Name = "lmensaje"
        Me.lmensaje.Size = New System.Drawing.Size(147, 26)
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 500
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Silver
        Me.PictureBox3.Location = New System.Drawing.Point(3, 4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(237, 30)
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Silver
        Me.PictureBox1.Location = New System.Drawing.Point(2, 97)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(237, 31)
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Silver
        Me.PictureBox2.Location = New System.Drawing.Point(2, 35)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(237, 30)
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Silver
        Me.PictureBox4.Location = New System.Drawing.Point(2, 66)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(237, 30)
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Silver
        Me.PictureBox5.Location = New System.Drawing.Point(2, 204)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(237, 63)
        '
        'btn_buscar
        '
        Me.btn_buscar.Location = New System.Drawing.Point(208, 241)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(24, 21)
        Me.btn_buscar.TabIndex = 84
        Me.btn_buscar.Text = "..."
        Me.btn_buscar.Visible = False
        '
        'lblcodigo
        '
        Me.lblcodigo.Location = New System.Drawing.Point(230, 268)
        Me.lblcodigo.Name = "lblcodigo"
        Me.lblcodigo.Size = New System.Drawing.Size(10, 20)
        Me.lblcodigo.Text = "000"
        '
        'BtnLiberar
        '
        Me.BtnLiberar.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.BtnLiberar.Location = New System.Drawing.Point(6, 241)
        Me.BtnLiberar.Name = "BtnLiberar"
        Me.BtnLiberar.Size = New System.Drawing.Size(10, 20)
        Me.BtnLiberar.TabIndex = 99
        Me.BtnLiberar.Text = "Liberar"
        Me.BtnLiberar.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(157, 271)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 20)
        Me.Button1.TabIndex = 115
        Me.Button1.Text = "Salir"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Silver
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(53, 205)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(147, 16)
        Me.Label8.Text = "Confirmar Sugerido"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(154, 180)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(80, 20)
        Me.Button2.TabIndex = 145
        Me.Button2.Text = "Cancelar"
        '
        'txtnivel2
        '
        Me.txtnivel2.Location = New System.Drawing.Point(122, 178)
        Me.txtnivel2.MaxLength = 1
        Me.txtnivel2.Name = "txtnivel2"
        Me.txtnivel2.Size = New System.Drawing.Size(29, 21)
        Me.txtnivel2.TabIndex = 144
        '
        'txtpiso2
        '
        Me.txtpiso2.Location = New System.Drawing.Point(53, 178)
        Me.txtpiso2.MaxLength = 2
        Me.txtpiso2.Name = "txtpiso2"
        Me.txtpiso2.Size = New System.Drawing.Size(29, 21)
        Me.txtpiso2.TabIndex = 143
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Silver
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(83, 183)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 17)
        Me.Label9.Text = "Nivel"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Silver
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(16, 181)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 18)
        Me.Label10.Text = "Piso"
        '
        'txtcolumna2
        '
        Me.txtcolumna2.Enabled = False
        Me.txtcolumna2.Location = New System.Drawing.Point(204, 151)
        Me.txtcolumna2.MaxLength = 2
        Me.txtcolumna2.Name = "txtcolumna2"
        Me.txtcolumna2.Size = New System.Drawing.Size(29, 21)
        Me.txtcolumna2.TabIndex = 142
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Silver
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(152, 154)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 18)
        Me.Label11.Text = "Columna"
        '
        'txtbanda2
        '
        Me.txtbanda2.Enabled = False
        Me.txtbanda2.Location = New System.Drawing.Point(122, 151)
        Me.txtbanda2.MaxLength = 2
        Me.txtbanda2.Name = "txtbanda2"
        Me.txtbanda2.Size = New System.Drawing.Size(29, 21)
        Me.txtbanda2.TabIndex = 141
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Silver
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(83, 154)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 18)
        Me.Label12.Text = "Banda"
        '
        'txtcamara2
        '
        Me.txtcamara2.Enabled = False
        Me.txtcamara2.Location = New System.Drawing.Point(53, 151)
        Me.txtcamara2.MaxLength = 2
        Me.txtcamara2.Name = "txtcamara2"
        Me.txtcamara2.Size = New System.Drawing.Size(29, 21)
        Me.txtcamara2.TabIndex = 140
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Silver
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(6, 154)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 18)
        Me.Label13.Text = "Cámara"
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.Color.Silver
        Me.PictureBox6.Location = New System.Drawing.Point(1, 126)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(237, 49)
        '
        'PictureBox7
        '
        Me.PictureBox7.BackColor = System.Drawing.Color.Silver
        Me.PictureBox7.Location = New System.Drawing.Point(2, 176)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(237, 27)
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Location = New System.Drawing.Point(154, 71)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(80, 20)
        Me.BtnNuevo.TabIndex = 71
        Me.BtnNuevo.Text = "Cancelar"
        Me.BtnNuevo.Visible = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(122, 243)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(80, 20)
        Me.Button3.TabIndex = 168
        Me.Button3.Text = "Otro"
        '
        'txtpallete
        '
        Me.txtpallete.Location = New System.Drawing.Point(156, 100)
        Me.txtpallete.MaxLength = 30
        Me.txtpallete.Name = "txtpallete"
        Me.txtpallete.Size = New System.Drawing.Size(78, 21)
        Me.txtpallete.TabIndex = 169
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(31, 243)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(80, 20)
        Me.Button4.TabIndex = 192
        Me.Button4.Text = "Manual"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Silver
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(6, 130)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(94, 15)
        Me.Label14.Text = "Cámara Filtro"
        '
        'ComboBox1
        '
        Me.ComboBox1.Items.Add("01")
        Me.ComboBox1.Items.Add("02")
        Me.ComboBox1.Items.Add("03")
        Me.ComboBox1.Items.Add("04")
        Me.ComboBox1.Items.Add("05")
        Me.ComboBox1.Items.Add("06")
        Me.ComboBox1.Location = New System.Drawing.Point(134, 127)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(100, 22)
        Me.ComboBox1.TabIndex = 195
        '
        'Frm_Pos_Sug
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.txtpallete)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txtnivel2)
        Me.Controls.Add(Me.txtpiso2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtcolumna2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtbanda2)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtcamara2)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.PictureBox7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.BtnLiberar)
        Me.Controls.Add(Me.lblcodigo)
        Me.Controls.Add(Me.btn_buscar)
        Me.Controls.Add(Me.lmensaje)
        Me.Controls.Add(Me.BtnNuevo)
        Me.Controls.Add(Me.txtnivel)
        Me.Controls.Add(Me.txtpiso)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtposicion)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtcolumna)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtbanda)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtcamara)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtpalet)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.PictureBox5)
        Me.Name = "Frm_Pos_Sug"
        Me.Text = "POSICIONAMIENTO SUGERIDO"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtpalet As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtcamara As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtbanda As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtcolumna As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtpiso As System.Windows.Forms.TextBox
    Friend WithEvents txtnivel As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtposicion As System.Windows.Forms.TextBox
    Friend WithEvents lmensaje As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents lblcodigo As System.Windows.Forms.Label
    Friend WithEvents BtnLiberar As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtnivel2 As System.Windows.Forms.TextBox
    Friend WithEvents txtpiso2 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtcolumna2 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtbanda2 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtcamara2 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnNuevo As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents txtpallete As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
End Class
