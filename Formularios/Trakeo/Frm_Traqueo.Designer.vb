<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Frm_Traqueo
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
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.tpal = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Cliente = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Envases = New System.Windows.Forms.TextBox
        Me.Leidas = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.Lector = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label6 = New System.Windows.Forms.Label
        Me.BtnNuevo = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.LblCambio = New System.Windows.Forms.LinkLabel
        Me.SuspendLayout()
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.Add(Me.MenuItem1)
        '
        'MenuItem1
        '
        Me.MenuItem1.MenuItems.Add(Me.MenuItem2)
        Me.MenuItem1.Text = "OPCIONES"
        '
        'MenuItem2
        '
        Me.MenuItem2.Text = "POR TRAQUEAR"
        '
        'tpal
        '
        Me.tpal.Location = New System.Drawing.Point(65, 1)
        Me.tpal.Name = "tpal"
        Me.tpal.Size = New System.Drawing.Size(163, 21)
        Me.tpal.TabIndex = 19
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(2, 3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 20)
        Me.Label8.Text = "N° PALLET"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(3, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(227, 23)
        Me.Label2.Text = "________________________________________________________"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(227, 23)
        Me.Label1.Text = "________________________________________________________"
        '
        'Cliente
        '
        Me.Cliente.Enabled = False
        Me.Cliente.Location = New System.Drawing.Point(65, 29)
        Me.Cliente.Name = "Cliente"
        Me.Cliente.Size = New System.Drawing.Size(163, 21)
        Me.Cliente.TabIndex = 30
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(2, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 20)
        Me.Label3.Text = "CLIENTE"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(2, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 20)
        Me.Label4.Text = "ENVASES"
        '
        'Envases
        '
        Me.Envases.Enabled = False
        Me.Envases.Location = New System.Drawing.Point(65, 54)
        Me.Envases.Name = "Envases"
        Me.Envases.Size = New System.Drawing.Size(39, 21)
        Me.Envases.TabIndex = 35
        '
        'Leidas
        '
        Me.Leidas.Enabled = False
        Me.Leidas.Location = New System.Drawing.Point(155, 54)
        Me.Leidas.Name = "Leidas"
        Me.Leidas.Size = New System.Drawing.Size(39, 21)
        Me.Leidas.TabIndex = 37
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(108, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 20)
        Me.Label5.Text = "LEIDAS"
        '
        'ListBox1
        '
        Me.ListBox1.Location = New System.Drawing.Point(4, 119)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(227, 114)
        Me.ListBox1.TabIndex = 39
        '
        'Lector
        '
        Me.Lector.Enabled = False
        Me.Lector.Location = New System.Drawing.Point(6, 92)
        Me.Lector.Name = "Lector"
        Me.Lector.Size = New System.Drawing.Size(198, 21)
        Me.Lector.TabIndex = 41
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(206, 91)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(23, 23)
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 7.5!, System.Drawing.FontStyle.Regular)
        Me.Label6.Location = New System.Drawing.Point(4, 235)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(227, 15)
        Me.Label6.Text = "Si la etiqueta no se puede leer, debe escribirla."
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Location = New System.Drawing.Point(200, 54)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(28, 22)
        Me.BtnNuevo.TabIndex = 49
        Me.BtnNuevo.Text = " X"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label7.Location = New System.Drawing.Point(0, 250)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(178, 18)
        Me.Label7.Text = "Agregar nueva etiqueta de muesta"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LblCambio
        '
        Me.LblCambio.Location = New System.Drawing.Point(179, 249)
        Me.LblCambio.Name = "LblCambio"
        Me.LblCambio.Size = New System.Drawing.Size(40, 15)
        Me.LblCambio.TabIndex = 68
        Me.LblCambio.Text = "AQUI"
        '
        'Frm_Traqueo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.LblCambio)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.BtnNuevo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Lector)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Leidas)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Envases)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Cliente)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tpal)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label2)
        Me.Menu = Me.mainMenu1
        Me.Name = "Frm_Traqueo"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tpal As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Envases As System.Windows.Forms.TextBox
    Friend WithEvents Leidas As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Lector As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BtnNuevo As System.Windows.Forms.Button
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LblCambio As System.Windows.Forms.LinkLabel
End Class
