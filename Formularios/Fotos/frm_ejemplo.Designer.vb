<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frm_ejemplo
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
        Me.InputPanel1 = New Microsoft.WindowsCE.Forms.InputPanel
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(3, 12)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(234, 65)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = "Data Source=192.168.1.90\PRECISABD; Initial Catalog=PRECISA; Uid=sa; PWD=precisa;" & _
            ""
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(69, 83)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 20)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(3, 121)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(234, 125)
        Me.TextBox2.TabIndex = 2
        '
        'frm_ejemplo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Menu = Me.mainMenu1
        Me.Name = "frm_ejemplo"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents InputPanel1 As Microsoft.WindowsCE.Forms.InputPanel
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
End Class
