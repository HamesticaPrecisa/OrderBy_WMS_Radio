<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frm_cuenta
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
        Me.Posicionar = New System.Windows.Forms.Label
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.txtusuario = New System.Windows.Forms.TextBox
        Me.txtcargo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtperfil = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtnumero = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.SuspendLayout()
        '
        'Posicionar
        '
        Me.Posicionar.BackColor = System.Drawing.Color.Silver
        Me.Posicionar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Posicionar.Location = New System.Drawing.Point(8, 27)
        Me.Posicionar.Name = "Posicionar"
        Me.Posicionar.Size = New System.Drawing.Size(87, 15)
        Me.Posicionar.Text = "Usuario"
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Silver
        Me.PictureBox4.Location = New System.Drawing.Point(8, 20)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(229, 30)
        '
        'txtusuario
        '
        Me.txtusuario.Enabled = False
        Me.txtusuario.Location = New System.Drawing.Point(84, 24)
        Me.txtusuario.Name = "txtusuario"
        Me.txtusuario.Size = New System.Drawing.Size(149, 21)
        Me.txtusuario.TabIndex = 4
        '
        'txtcargo
        '
        Me.txtcargo.Enabled = False
        Me.txtcargo.Location = New System.Drawing.Point(84, 70)
        Me.txtcargo.Name = "txtcargo"
        Me.txtcargo.Size = New System.Drawing.Size(149, 21)
        Me.txtcargo.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Silver
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(8, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 15)
        Me.Label1.Text = "Cargo"
        '
        'txtperfil
        '
        Me.txtperfil.Enabled = False
        Me.txtperfil.Location = New System.Drawing.Point(84, 118)
        Me.txtperfil.Name = "txtperfil"
        Me.txtperfil.Size = New System.Drawing.Size(149, 21)
        Me.txtperfil.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Silver
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(8, 121)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 15)
        Me.Label2.Text = "Perfil"
        '
        'txtnumero
        '
        Me.txtnumero.Enabled = False
        Me.txtnumero.Location = New System.Drawing.Point(84, 165)
        Me.txtnumero.Name = "txtnumero"
        Me.txtnumero.Size = New System.Drawing.Size(149, 21)
        Me.txtnumero.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Silver
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(8, 168)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 15)
        Me.Label3.Text = "Personal Nº"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Silver
        Me.PictureBox1.Location = New System.Drawing.Point(8, 66)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(229, 30)
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Silver
        Me.PictureBox2.Location = New System.Drawing.Point(8, 113)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(229, 30)
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Silver
        Me.PictureBox3.Location = New System.Drawing.Point(8, 160)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(229, 30)
        '
        'frm_cuenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.txtnumero)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtperfil)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtcargo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtusuario)
        Me.Controls.Add(Me.Posicionar)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox3)
        Me.Menu = Me.mainMenu1
        Me.Name = "frm_cuenta"
        Me.Text = "Cuenta personal"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Posicionar As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents txtusuario As System.Windows.Forms.TextBox
    Friend WithEvents txtcargo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtperfil As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtnumero As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
End Class
