<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Frm_Etiquetado
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtFolio = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ok = New System.Windows.Forms.Panel
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.Lector = New System.Windows.Forms.TextBox
        Me.TxtContrato = New System.Windows.Forms.TextBox
        Me.TxtCliente = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lclie = New System.Windows.Forms.Label
        Me.lcont = New System.Windows.Forms.Label
        Me.BtnFinalizarLectura = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 15)
        Me.Label1.Text = "CODIGO"
        '
        'TxtFolio
        '
        Me.TxtFolio.Location = New System.Drawing.Point(65, 3)
        Me.TxtFolio.MaxLength = 5
        Me.TxtFolio.Name = "TxtFolio"
        Me.TxtFolio.Size = New System.Drawing.Size(49, 21)
        Me.TxtFolio.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ok)
        Me.Panel1.Controls.Add(Me.ListBox1)
        Me.Panel1.Controls.Add(Me.Lector)
        Me.Panel1.Controls.Add(Me.TxtContrato)
        Me.Panel1.Controls.Add(Me.TxtCliente)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(8, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(224, 237)
        '
        'ok
        '
        Me.ok.Location = New System.Drawing.Point(193, 87)
        Me.ok.Name = "ok"
        Me.ok.Size = New System.Drawing.Size(20, 20)
        '
        'ListBox1
        '
        Me.ListBox1.Location = New System.Drawing.Point(6, 115)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(212, 114)
        Me.ListBox1.TabIndex = 8
        '
        'Lector
        '
        Me.Lector.Enabled = False
        Me.Lector.Location = New System.Drawing.Point(6, 87)
        Me.Lector.Name = "Lector"
        Me.Lector.Size = New System.Drawing.Size(181, 21)
        Me.Lector.TabIndex = 6
        '
        'TxtContrato
        '
        Me.TxtContrato.Enabled = False
        Me.TxtContrato.Location = New System.Drawing.Point(68, 37)
        Me.TxtContrato.Name = "TxtContrato"
        Me.TxtContrato.Size = New System.Drawing.Size(153, 21)
        Me.TxtContrato.TabIndex = 5
        '
        'TxtCliente
        '
        Me.TxtCliente.Enabled = False
        Me.TxtCliente.Location = New System.Drawing.Point(68, 10)
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(153, 21)
        Me.TxtCliente.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(3, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 19)
        Me.Label3.Text = "CONTRATO"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(3, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 19)
        Me.Label2.Text = "CLIENTE"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(3, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(218, 41)
        Me.Label4.Text = "LECTURA DE SOPORTANTES"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lclie
        '
        Me.lclie.Location = New System.Drawing.Point(154, 11)
        Me.lclie.Name = "lclie"
        Me.lclie.Size = New System.Drawing.Size(11, 10)
        Me.lclie.Visible = False
        '
        'lcont
        '
        Me.lcont.Location = New System.Drawing.Point(184, 11)
        Me.lcont.Name = "lcont"
        Me.lcont.Size = New System.Drawing.Size(11, 10)
        Me.lcont.Visible = False
        '
        'BtnFinalizarLectura
        '
        Me.BtnFinalizarLectura.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.BtnFinalizarLectura.Location = New System.Drawing.Point(123, 4)
        Me.BtnFinalizarLectura.Name = "BtnFinalizarLectura"
        Me.BtnFinalizarLectura.Size = New System.Drawing.Size(109, 20)
        Me.BtnFinalizarLectura.TabIndex = 4
        Me.BtnFinalizarLectura.Text = "TERMINAR LECTURA"
        '
        'Frm_Etiquetado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.BtnFinalizarLectura)
        Me.Controls.Add(Me.lcont)
        Me.Controls.Add(Me.lclie)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TxtFolio)
        Me.Controls.Add(Me.Label1)
        Me.Menu = Me.mainMenu1
        Me.Name = "Frm_Etiquetado"
        Me.Text = "Etiquetado"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtFolio As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtContrato As System.Windows.Forms.TextBox
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Lector As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents lclie As System.Windows.Forms.Label
    Friend WithEvents lcont As System.Windows.Forms.Label
    Friend WithEvents ok As System.Windows.Forms.Panel
    Friend WithEvents BtnFinalizarLectura As System.Windows.Forms.Button
End Class
