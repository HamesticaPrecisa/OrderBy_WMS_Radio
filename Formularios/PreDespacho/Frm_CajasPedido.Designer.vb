<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Frm_CajasPedido
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
        Me.txtlectorcaja = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.LstCajas = New System.Windows.Forms.ListBox
        Me.color = New System.Windows.Forms.PictureBox
        Me.mensaje = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtlectorcaja
        '
        Me.txtlectorcaja.Location = New System.Drawing.Point(4, 3)
        Me.txtlectorcaja.Name = "txtlectorcaja"
        Me.txtlectorcaja.Size = New System.Drawing.Size(211, 21)
        Me.txtlectorcaja.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(213, 239)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 13)
        Me.Label2.Text = "    "
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(85, 239)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 13)
        Me.Label1.Text = "CAJAS FALTANTES"
        '
        'LstCajas
        '
        Me.LstCajas.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.LstCajas.Location = New System.Drawing.Point(5, 45)
        Me.LstCajas.Name = "LstCajas"
        Me.LstCajas.Size = New System.Drawing.Size(230, 184)
        Me.LstCajas.TabIndex = 6
        '
        'color
        '
        Me.color.Location = New System.Drawing.Point(217, 3)
        Me.color.Name = "color"
        Me.color.Size = New System.Drawing.Size(20, 20)
        '
        'mensaje
        '
        Me.mensaje.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.mensaje.Location = New System.Drawing.Point(4, 27)
        Me.mensaje.Name = "mensaje"
        Me.mensaje.Size = New System.Drawing.Size(231, 15)
        '
        'Frm_CajasPedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.mensaje)
        Me.Controls.Add(Me.color)
        Me.Controls.Add(Me.LstCajas)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtlectorcaja)
        Me.Menu = Me.mainMenu1
        Me.Name = "Frm_CajasPedido"
        Me.Text = "Detalle Cajas"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtlectorcaja As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LstCajas As System.Windows.Forms.ListBox
    Friend WithEvents color As System.Windows.Forms.PictureBox
    Friend WithEvents mensaje As System.Windows.Forms.Label
End Class
