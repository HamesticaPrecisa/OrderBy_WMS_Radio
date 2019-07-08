<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Frm_Andenes
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
        Me.verificador = New System.Windows.Forms.TextBox
        Me.txtclinombre = New System.Windows.Forms.TextBox
        Me.txtrut = New System.Windows.Forms.TextBox
        Me.btn_BuscaCliente = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Limpiar = New System.Windows.Forms.Button
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'verificador
        '
        Me.verificador.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular)
        Me.verificador.Location = New System.Drawing.Point(136, 17)
        Me.verificador.MaxLength = 1
        Me.verificador.Name = "verificador"
        Me.verificador.Size = New System.Drawing.Size(19, 20)
        Me.verificador.TabIndex = 358
        '
        'txtclinombre
        '
        Me.txtclinombre.Enabled = False
        Me.txtclinombre.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular)
        Me.txtclinombre.Location = New System.Drawing.Point(57, 44)
        Me.txtclinombre.Name = "txtclinombre"
        Me.txtclinombre.Size = New System.Drawing.Size(171, 20)
        Me.txtclinombre.TabIndex = 359
        '
        'txtrut
        '
        Me.txtrut.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular)
        Me.txtrut.Location = New System.Drawing.Point(57, 18)
        Me.txtrut.MaxLength = 8
        Me.txtrut.Name = "txtrut"
        Me.txtrut.Size = New System.Drawing.Size(69, 20)
        Me.txtrut.TabIndex = 357
        '
        'btn_BuscaCliente
        '
        Me.btn_BuscaCliente.Location = New System.Drawing.Point(159, 16)
        Me.btn_BuscaCliente.Name = "btn_BuscaCliente"
        Me.btn_BuscaCliente.Size = New System.Drawing.Size(22, 22)
        Me.btn_BuscaCliente.TabIndex = 360
        Me.btn_BuscaCliente.Text = "..."
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(128, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(12, 13)
        Me.Label8.Text = "-"
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label15.Location = New System.Drawing.Point(7, 20)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(56, 13)
        Me.Label15.Text = "CLIENTE"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label1.Location = New System.Drawing.Point(7, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.Text = "ANDEN"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular)
        Me.TextBox1.Location = New System.Drawing.Point(57, 70)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(171, 20)
        Me.TextBox1.TabIndex = 365
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(7, 187)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(98, 64)
        Me.Button1.TabIndex = 366
        Me.Button1.Text = "APERTURA"
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(130, 187)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(98, 64)
        Me.Button2.TabIndex = 367
        Me.Button2.Text = "CIERRE"
        '
        'TextBox2
        '
        Me.TextBox2.Enabled = False
        Me.TextBox2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular)
        Me.TextBox2.Location = New System.Drawing.Point(57, 96)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(171, 20)
        Me.TextBox2.TabIndex = 368
        '
        'Limpiar
        '
        Me.Limpiar.Location = New System.Drawing.Point(198, 17)
        Me.Limpiar.Name = "Limpiar"
        Me.Limpiar.Size = New System.Drawing.Size(30, 21)
        Me.Limpiar.TabIndex = 369
        Me.Limpiar.Text = " X"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(9, 138)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(219, 43)
        Me.TextBox3.TabIndex = 373
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label2.Location = New System.Drawing.Point(9, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.Text = "OBS"
        '
        'Frm_Andenes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Limpiar)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.verificador)
        Me.Controls.Add(Me.txtclinombre)
        Me.Controls.Add(Me.txtrut)
        Me.Controls.Add(Me.btn_BuscaCliente)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label15)
        Me.Menu = Me.mainMenu1
        Me.Name = "Frm_Andenes"
        Me.Text = "Ingreso/Cierre Andenes"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents verificador As System.Windows.Forms.TextBox
    Friend WithEvents txtclinombre As System.Windows.Forms.TextBox
    Friend WithEvents txtrut As System.Windows.Forms.TextBox
    Friend WithEvents btn_BuscaCliente As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Limpiar As System.Windows.Forms.Button
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
