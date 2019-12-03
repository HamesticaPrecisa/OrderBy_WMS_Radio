<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frm_PickOTTUnel
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.lblcodigo = New System.Windows.Forms.Label
        Me.btn_buscar = New System.Windows.Forms.Button
        Me.lmensaje = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.BtnNuevo = New System.Windows.Forms.Button
        Me.txtnivel = New System.Windows.Forms.TextBox
        Me.txtpiso = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtposicion = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtcolumna = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtbanda = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtcamara = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtpalet = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.lblCount = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblInfoOT = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(138, 257)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 34)
        Me.Button1.TabIndex = 141
        Me.Button1.Text = "Salir"
        '
        'lblcodigo
        '
        Me.lblcodigo.Location = New System.Drawing.Point(1, 235)
        Me.lblcodigo.Name = "lblcodigo"
        Me.lblcodigo.Size = New System.Drawing.Size(31, 20)
        Me.lblcodigo.Text = "000"
        '
        'btn_buscar
        '
        Me.btn_buscar.Location = New System.Drawing.Point(213, 54)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(24, 21)
        Me.btn_buscar.TabIndex = 139
        Me.btn_buscar.Text = "..."
        '
        'lmensaje
        '
        Me.lmensaje.Location = New System.Drawing.Point(51, 186)
        Me.lmensaje.Name = "lmensaje"
        Me.lmensaje.Size = New System.Drawing.Size(185, 43)
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Silver
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(4, 188)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 20)
        Me.Label8.Text = "OBS."
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Location = New System.Drawing.Point(153, 155)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(80, 20)
        Me.BtnNuevo.TabIndex = 138
        Me.BtnNuevo.Text = "Cancelar"
        '
        'txtnivel
        '
        Me.txtnivel.Location = New System.Drawing.Point(121, 154)
        Me.txtnivel.MaxLength = 1
        Me.txtnivel.Name = "txtnivel"
        Me.txtnivel.Size = New System.Drawing.Size(29, 25)
        Me.txtnivel.TabIndex = 137
        '
        'txtpiso
        '
        Me.txtpiso.Location = New System.Drawing.Point(52, 154)
        Me.txtpiso.MaxLength = 2
        Me.txtpiso.Name = "txtpiso"
        Me.txtpiso.Size = New System.Drawing.Size(29, 25)
        Me.txtpiso.TabIndex = 136
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Silver
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(82, 156)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 17)
        Me.Label6.Text = "Nivel"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Silver
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(15, 156)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 17)
        Me.Label5.Text = "Piso"
        '
        'txtposicion
        '
        Me.txtposicion.Location = New System.Drawing.Point(65, 88)
        Me.txtposicion.MaxLength = 13
        Me.txtposicion.Name = "txtposicion"
        Me.txtposicion.Size = New System.Drawing.Size(171, 25)
        Me.txtposicion.TabIndex = 135
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Silver
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(3, 89)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 20)
        Me.Label7.Text = "Posición"
        '
        'txtcolumna
        '
        Me.txtcolumna.Enabled = False
        Me.txtcolumna.Location = New System.Drawing.Point(203, 119)
        Me.txtcolumna.MaxLength = 2
        Me.txtcolumna.Name = "txtcolumna"
        Me.txtcolumna.Size = New System.Drawing.Size(29, 25)
        Me.txtcolumna.TabIndex = 134
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Silver
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(151, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 18)
        Me.Label4.Text = "Columna"
        '
        'txtbanda
        '
        Me.txtbanda.Enabled = False
        Me.txtbanda.Location = New System.Drawing.Point(121, 119)
        Me.txtbanda.MaxLength = 2
        Me.txtbanda.Name = "txtbanda"
        Me.txtbanda.Size = New System.Drawing.Size(29, 25)
        Me.txtbanda.TabIndex = 133
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Silver
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(82, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 18)
        Me.Label3.Text = "Banda"
        '
        'txtcamara
        '
        Me.txtcamara.Enabled = False
        Me.txtcamara.Location = New System.Drawing.Point(52, 119)
        Me.txtcamara.MaxLength = 2
        Me.txtcamara.Name = "txtcamara"
        Me.txtcamara.Size = New System.Drawing.Size(29, 25)
        Me.txtcamara.TabIndex = 132
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Silver
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(5, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 18)
        Me.Label2.Text = "Cámara"
        '
        'txtpalet
        '
        Me.txtpalet.Location = New System.Drawing.Point(65, 54)
        Me.txtpalet.MaxLength = 30
        Me.txtpalet.Name = "txtpalet"
        Me.txtpalet.Size = New System.Drawing.Size(147, 25)
        Me.txtpalet.TabIndex = 131
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Silver
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(3, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 19)
        Me.Label1.Text = "Nº Pallet"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Silver
        Me.PictureBox3.Location = New System.Drawing.Point(2, 50)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(237, 30)
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Silver
        Me.PictureBox1.Location = New System.Drawing.Point(2, 82)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(237, 30)
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Silver
        Me.PictureBox2.Location = New System.Drawing.Point(1, 115)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(237, 30)
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Silver
        Me.PictureBox4.Location = New System.Drawing.Point(1, 149)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(237, 30)
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Silver
        Me.PictureBox5.Location = New System.Drawing.Point(1, 183)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(237, 49)
        '
        'lblCount
        '
        Me.lblCount.BackColor = System.Drawing.Color.Red
        Me.lblCount.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblCount.ForeColor = System.Drawing.Color.White
        Me.lblCount.Location = New System.Drawing.Point(10, 23)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(215, 20)
        Me.lblCount.Text = "0 pallets de 0 - 0 faltantes"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Red
        Me.Panel1.Controls.Add(Me.lblCount)
        Me.Panel1.Controls.Add(Me.lblInfoOT)
        Me.Panel1.Location = New System.Drawing.Point(1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(237, 47)
        '
        'lblInfoOT
        '
        Me.lblInfoOT.BackColor = System.Drawing.Color.Red
        Me.lblInfoOT.ForeColor = System.Drawing.Color.White
        Me.lblInfoOT.Location = New System.Drawing.Point(10, 3)
        Me.lblInfoOT.Name = "lblInfoOT"
        Me.lblInfoOT.Size = New System.Drawing.Size(400, 20)
        Me.lblInfoOT.Text = "000000 - Nombre del cliente"
        '
        'frm_PickOTTUnel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button1)
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
        Me.Name = "frm_PickOTTUnel"
        Me.Text = "OT#"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblcodigo As System.Windows.Forms.Label
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents lmensaje As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents BtnNuevo As System.Windows.Forms.Button
    Friend WithEvents txtnivel As System.Windows.Forms.TextBox
    Friend WithEvents txtpiso As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtposicion As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtcolumna As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtbanda As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtcamara As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtpalet As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblInfoOT As System.Windows.Forms.Label
End Class
