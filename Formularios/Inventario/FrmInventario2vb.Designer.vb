<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FrmInventario2vb
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
        Me.txtpallet = New System.Windows.Forms.TextBox
        Me.txtcli = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtncaja = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtingcaja = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Limpiar = New System.Windows.Forms.Button
        Me.txtobs = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'txtpallet
        '
        Me.txtpallet.Location = New System.Drawing.Point(3, 4)
        Me.txtpallet.Name = "txtpallet"
        Me.txtpallet.Size = New System.Drawing.Size(197, 21)
        Me.txtpallet.TabIndex = 0
        '
        'txtcli
        '
        Me.txtcli.Enabled = False
        Me.txtcli.Location = New System.Drawing.Point(3, 29)
        Me.txtcli.Name = "txtcli"
        Me.txtcli.Size = New System.Drawing.Size(234, 21)
        Me.txtcli.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.Text = "N° DE CAJAS"
        '
        'txtncaja
        '
        Me.txtncaja.Enabled = False
        Me.txtncaja.Location = New System.Drawing.Point(109, 55)
        Me.txtncaja.Name = "txtncaja"
        Me.txtncaja.Size = New System.Drawing.Size(100, 21)
        Me.txtncaja.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(0, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 16)
        Me.Label2.Text = "CAJA"
        '
        'txtingcaja
        '
        Me.txtingcaja.Enabled = False
        Me.txtingcaja.Location = New System.Drawing.Point(40, 83)
        Me.txtingcaja.MaxLength = 35
        Me.txtingcaja.Name = "txtingcaja"
        Me.txtingcaja.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtingcaja.Size = New System.Drawing.Size(200, 21)
        Me.txtingcaja.TabIndex = 19
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(216, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 15)
        Me.Label4.Text = "0/0"
        '
        'ListBox1
        '
        Me.ListBox1.Enabled = False
        Me.ListBox1.Location = New System.Drawing.Point(6, 125)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(230, 86)
        Me.ListBox1.TabIndex = 21
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(164, 244)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 20)
        Me.Button1.TabIndex = 22
        Me.Button1.Text = "Grabar"
        '
        'Limpiar
        '
        Me.Limpiar.Location = New System.Drawing.Point(206, 4)
        Me.Limpiar.Name = "Limpiar"
        Me.Limpiar.Size = New System.Drawing.Size(30, 20)
        Me.Limpiar.TabIndex = 26
        Me.Limpiar.Text = " X"
        '
        'txtobs
        '
        Me.txtobs.Location = New System.Drawing.Point(37, 217)
        Me.txtobs.Name = "txtobs"
        Me.txtobs.Size = New System.Drawing.Size(200, 21)
        Me.txtobs.TabIndex = 27
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(6, 222)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 16)
        Me.Label3.Text = "OBS"
        '
        'CheckBox1
        '
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(214, 57)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(22, 20)
        Me.CheckBox1.TabIndex = 31
        '
        'FrmInventario2vb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtobs)
        Me.Controls.Add(Me.Limpiar)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtingcaja)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtncaja)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtcli)
        Me.Controls.Add(Me.txtpallet)
        Me.Menu = Me.mainMenu1
        Me.Name = "FrmInventario2vb"
        Me.Text = "Inventario "
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtpallet As System.Windows.Forms.TextBox
    Friend WithEvents txtcli As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtncaja As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtingcaja As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Limpiar As System.Windows.Forms.Button
    Friend WithEvents txtobs As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
End Class
