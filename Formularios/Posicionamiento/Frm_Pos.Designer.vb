<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frm_Pos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Pos))
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
        Me.BtnNuevo = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
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
        Me.SuspendLayout()
        '
        'txtpalet
        '
        Me.txtpalet.Location = New System.Drawing.Point(66, 8)
        Me.txtpalet.MaxLength = 30
        Me.txtpalet.Name = "txtpalet"
        Me.txtpalet.Size = New System.Drawing.Size(147, 21)
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
        Me.txtcamara.Location = New System.Drawing.Point(53, 73)
        Me.txtcamara.MaxLength = 2
        Me.txtcamara.Name = "txtcamara"
        Me.txtcamara.Size = New System.Drawing.Size(29, 21)
        Me.txtcamara.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Silver
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(6, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 18)
        Me.Label2.Text = "Cámara"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Silver
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(83, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 18)
        Me.Label3.Text = "Banda"
        '
        'txtbanda
        '
        Me.txtbanda.Enabled = False
        Me.txtbanda.Location = New System.Drawing.Point(122, 73)
        Me.txtbanda.MaxLength = 2
        Me.txtbanda.Name = "txtbanda"
        Me.txtbanda.Size = New System.Drawing.Size(29, 21)
        Me.txtbanda.TabIndex = 20
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Silver
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(152, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 18)
        Me.Label4.Text = "Columna"
        '
        'txtcolumna
        '
        Me.txtcolumna.Enabled = False
        Me.txtcolumna.Location = New System.Drawing.Point(204, 73)
        Me.txtcolumna.MaxLength = 2
        Me.txtcolumna.Name = "txtcolumna"
        Me.txtcolumna.Size = New System.Drawing.Size(29, 21)
        Me.txtcolumna.TabIndex = 23
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Silver
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(16, 110)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 17)
        Me.Label5.Text = "Piso"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Silver
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(83, 110)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 17)
        Me.Label6.Text = "Nivel"
        '
        'txtpiso
        '
        Me.txtpiso.Location = New System.Drawing.Point(53, 108)
        Me.txtpiso.MaxLength = 2
        Me.txtpiso.Name = "txtpiso"
        Me.txtpiso.Size = New System.Drawing.Size(29, 21)
        Me.txtpiso.TabIndex = 41
        '
        'txtnivel
        '
        Me.txtnivel.Location = New System.Drawing.Point(122, 108)
        Me.txtnivel.MaxLength = 1
        Me.txtnivel.Name = "txtnivel"
        Me.txtnivel.Size = New System.Drawing.Size(29, 21)
        Me.txtnivel.TabIndex = 42
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Silver
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(4, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 20)
        Me.Label7.Text = "Posición"
        '
        'txtposicion
        '
        Me.txtposicion.Location = New System.Drawing.Point(66, 42)
        Me.txtposicion.MaxLength = 13
        Me.txtposicion.Name = "txtposicion"
        Me.txtposicion.Size = New System.Drawing.Size(171, 21)
        Me.txtposicion.TabIndex = 32
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Location = New System.Drawing.Point(154, 109)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(80, 20)
        Me.BtnNuevo.TabIndex = 71
        Me.BtnNuevo.Text = "Cancelar"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Silver
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(5, 142)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 20)
        Me.Label8.Text = "OBS."
        '
        'lmensaje
        '
        Me.lmensaje.Location = New System.Drawing.Point(52, 140)
        Me.lmensaje.Name = "lmensaje"
        Me.lmensaje.Size = New System.Drawing.Size(185, 43)
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
        Me.PictureBox1.Location = New System.Drawing.Point(3, 36)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(237, 30)
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Silver
        Me.PictureBox2.Location = New System.Drawing.Point(2, 69)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(237, 30)
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Silver
        Me.PictureBox4.Location = New System.Drawing.Point(2, 103)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(237, 30)
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Silver
        Me.PictureBox5.Location = New System.Drawing.Point(2, 137)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(237, 49)
        '
        'btn_buscar
        '
        Me.btn_buscar.Location = New System.Drawing.Point(214, 8)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(24, 21)
        Me.btn_buscar.TabIndex = 84
        Me.btn_buscar.Text = "..."
        '
        'lblcodigo
        '
        Me.lblcodigo.Location = New System.Drawing.Point(2, 189)
        Me.lblcodigo.Name = "lblcodigo"
        Me.lblcodigo.Size = New System.Drawing.Size(31, 20)
        Me.lblcodigo.Text = "000"
        '
        'BtnLiberar
        '
        Me.BtnLiberar.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.BtnLiberar.Location = New System.Drawing.Point(2, 165)
        Me.BtnLiberar.Name = "BtnLiberar"
        Me.BtnLiberar.Size = New System.Drawing.Size(49, 20)
        Me.BtnLiberar.TabIndex = 99
        Me.BtnLiberar.Text = "Liberar"
        Me.BtnLiberar.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(159, 271)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 20)
        Me.Button1.TabIndex = 115
        Me.Button1.Text = "Salir"
        '
        'frm_Pos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.BtnLiberar)
        Me.Controls.Add(Me.lblcodigo)
        Me.Controls.Add(Me.btn_buscar)
        Me.Controls.Add(Me.lmensaje)
        Me.Controls.Add(Me.Label8)
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
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_Pos"
        Me.Text = "POSICIONAMIENTO"
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
    Friend WithEvents BtnNuevo As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
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
End Class
