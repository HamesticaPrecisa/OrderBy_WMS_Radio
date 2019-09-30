<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Frm_OTTunel
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.cboTunel = New System.Windows.Forms.ComboBox
        Me.btn_buscarGuia = New System.Windows.Forms.Button
        Me.txtGuia = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lblCliente = New System.Windows.Forms.Label
        Me.cboMercado = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.rbtTodos = New System.Windows.Forms.RadioButton
        Me.rbtParcial = New System.Windows.Forms.RadioButton
        Me.txtMaxPallets = New System.Windows.Forms.TextBox
        Me.cmdOk = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(3, 271)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 20)
        Me.Button1.TabIndex = 116
        Me.Button1.Text = "Salir"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Silver
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(3, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 19)
        Me.Label1.Text = "Túnel"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Silver
        Me.PictureBox3.Location = New System.Drawing.Point(2, 4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(237, 30)
        '
        'cboTunel
        '
        Me.cboTunel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cboTunel.Location = New System.Drawing.Point(53, 7)
        Me.cboTunel.Name = "cboTunel"
        Me.cboTunel.Size = New System.Drawing.Size(181, 26)
        Me.cboTunel.TabIndex = 121
        '
        'btn_buscarGuia
        '
        Me.btn_buscarGuia.Location = New System.Drawing.Point(213, 41)
        Me.btn_buscarGuia.Name = "btn_buscarGuia"
        Me.btn_buscarGuia.Size = New System.Drawing.Size(24, 21)
        Me.btn_buscarGuia.TabIndex = 127
        Me.btn_buscarGuia.Text = "..."
        '
        'txtGuia
        '
        Me.txtGuia.Location = New System.Drawing.Point(75, 41)
        Me.txtGuia.MaxLength = 30
        Me.txtGuia.Name = "txtGuia"
        Me.txtGuia.Size = New System.Drawing.Size(137, 25)
        Me.txtGuia.TabIndex = 126
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Silver
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(3, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 19)
        Me.Label2.Text = "Nº Guia"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Silver
        Me.PictureBox1.Location = New System.Drawing.Point(2, 37)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(237, 59)
        '
        'lblCliente
        '
        Me.lblCliente.BackColor = System.Drawing.Color.Silver
        Me.lblCliente.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblCliente.Location = New System.Drawing.Point(5, 72)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(231, 19)
        Me.lblCliente.Text = "nombre del cliente"
        Me.lblCliente.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblCliente.Visible = False
        '
        'cboMercado
        '
        Me.cboMercado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cboMercado.Location = New System.Drawing.Point(75, 102)
        Me.cboMercado.Name = "cboMercado"
        Me.cboMercado.Size = New System.Drawing.Size(162, 26)
        Me.cboMercado.TabIndex = 136
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Silver
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(3, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 19)
        Me.Label3.Text = "Mercado"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Silver
        Me.PictureBox2.Location = New System.Drawing.Point(2, 99)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(237, 30)
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Silver
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(3, 138)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 19)
        Me.Label4.Text = "Pallets"
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Silver
        Me.PictureBox4.Location = New System.Drawing.Point(2, 132)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(237, 62)
        '
        'rbtTodos
        '
        Me.rbtTodos.BackColor = System.Drawing.Color.Silver
        Me.rbtTodos.Checked = True
        Me.rbtTodos.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.rbtTodos.Location = New System.Drawing.Point(72, 138)
        Me.rbtTodos.Name = "rbtTodos"
        Me.rbtTodos.Size = New System.Drawing.Size(126, 20)
        Me.rbtTodos.TabIndex = 143
        Me.rbtTodos.Text = "Todos"
        '
        'rbtParcial
        '
        Me.rbtParcial.BackColor = System.Drawing.Color.Silver
        Me.rbtParcial.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.rbtParcial.Location = New System.Drawing.Point(72, 164)
        Me.rbtParcial.Name = "rbtParcial"
        Me.rbtParcial.Size = New System.Drawing.Size(126, 20)
        Me.rbtParcial.TabIndex = 144
        Me.rbtParcial.TabStop = False
        Me.rbtParcial.Text = "Parcial"
        '
        'txtMaxPallets
        '
        Me.txtMaxPallets.Location = New System.Drawing.Point(157, 161)
        Me.txtMaxPallets.MaxLength = 30
        Me.txtMaxPallets.Name = "txtMaxPallets"
        Me.txtMaxPallets.Size = New System.Drawing.Size(77, 25)
        Me.txtMaxPallets.TabIndex = 145
        Me.txtMaxPallets.Visible = False
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(157, 271)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(80, 20)
        Me.cmdOk.TabIndex = 146
        Me.cmdOk.Text = "Aceptar"
        '
        'Frm_OTTunel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.txtMaxPallets)
        Me.Controls.Add(Me.rbtParcial)
        Me.Controls.Add(Me.rbtTodos)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.cboMercado)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.lblCliente)
        Me.Controls.Add(Me.btn_buscarGuia)
        Me.Controls.Add(Me.txtGuia)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.cboTunel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Frm_OTTunel"
        Me.Text = "O/T Túnel"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents cboTunel As System.Windows.Forms.ComboBox
    Friend WithEvents btn_buscarGuia As System.Windows.Forms.Button
    Friend WithEvents txtGuia As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents cboMercado As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents rbtTodos As System.Windows.Forms.RadioButton
    Friend WithEvents rbtParcial As System.Windows.Forms.RadioButton
    Friend WithEvents txtMaxPallets As System.Windows.Forms.TextBox
    Friend WithEvents cmdOk As System.Windows.Forms.Button
End Class
