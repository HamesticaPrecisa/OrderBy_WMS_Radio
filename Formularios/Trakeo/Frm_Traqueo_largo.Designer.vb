<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Frm_Traqueo_largo
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
        Me.l1 = New System.Windows.Forms.TextBox
        Me.b1 = New System.Windows.Forms.Button
        Me.b2 = New System.Windows.Forms.Button
        Me.l2 = New System.Windows.Forms.TextBox
        Me.b3 = New System.Windows.Forms.Button
        Me.l3 = New System.Windows.Forms.TextBox
        Me.b4 = New System.Windows.Forms.Button
        Me.l4 = New System.Windows.Forms.TextBox
        Me.b5 = New System.Windows.Forms.Button
        Me.l5 = New System.Windows.Forms.TextBox
        Me.Actualizar = New System.Windows.Forms.Button
        Me.lector = New System.Windows.Forms.TextBox
        Me.numrece = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Silver
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(4, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(231, 20)
        Me.Label1.Text = "Elija las etiquetas de muestra"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'l1
        '
        Me.l1.Location = New System.Drawing.Point(4, 80)
        Me.l1.Name = "l1"
        Me.l1.ReadOnly = True
        Me.l1.Size = New System.Drawing.Size(195, 21)
        Me.l1.TabIndex = 2
        '
        'b1
        '
        Me.b1.Location = New System.Drawing.Point(205, 80)
        Me.b1.Name = "b1"
        Me.b1.Size = New System.Drawing.Size(30, 21)
        Me.b1.TabIndex = 4
        Me.b1.Text = "0"
        '
        'b2
        '
        Me.b2.Location = New System.Drawing.Point(205, 104)
        Me.b2.Name = "b2"
        Me.b2.Size = New System.Drawing.Size(30, 21)
        Me.b2.TabIndex = 6
        Me.b2.Text = "0"
        Me.b2.Visible = False
        '
        'l2
        '
        Me.l2.Location = New System.Drawing.Point(4, 104)
        Me.l2.Name = "l2"
        Me.l2.ReadOnly = True
        Me.l2.Size = New System.Drawing.Size(195, 21)
        Me.l2.TabIndex = 5
        Me.l2.Visible = False
        '
        'b3
        '
        Me.b3.Location = New System.Drawing.Point(205, 128)
        Me.b3.Name = "b3"
        Me.b3.Size = New System.Drawing.Size(30, 21)
        Me.b3.TabIndex = 8
        Me.b3.Text = "0"
        Me.b3.Visible = False
        '
        'l3
        '
        Me.l3.Location = New System.Drawing.Point(4, 128)
        Me.l3.Name = "l3"
        Me.l3.ReadOnly = True
        Me.l3.Size = New System.Drawing.Size(195, 21)
        Me.l3.TabIndex = 7
        Me.l3.Visible = False
        '
        'b4
        '
        Me.b4.Location = New System.Drawing.Point(205, 152)
        Me.b4.Name = "b4"
        Me.b4.Size = New System.Drawing.Size(30, 21)
        Me.b4.TabIndex = 10
        Me.b4.Text = "0"
        Me.b4.Visible = False
        '
        'l4
        '
        Me.l4.Location = New System.Drawing.Point(4, 152)
        Me.l4.Name = "l4"
        Me.l4.ReadOnly = True
        Me.l4.Size = New System.Drawing.Size(195, 21)
        Me.l4.TabIndex = 9
        Me.l4.Visible = False
        '
        'b5
        '
        Me.b5.Location = New System.Drawing.Point(205, 176)
        Me.b5.Name = "b5"
        Me.b5.Size = New System.Drawing.Size(30, 21)
        Me.b5.TabIndex = 12
        Me.b5.Text = "0"
        Me.b5.Visible = False
        '
        'l5
        '
        Me.l5.Location = New System.Drawing.Point(4, 176)
        Me.l5.Name = "l5"
        Me.l5.ReadOnly = True
        Me.l5.Size = New System.Drawing.Size(195, 21)
        Me.l5.TabIndex = 11
        Me.l5.Visible = False
        '
        'Actualizar
        '
        Me.Actualizar.Location = New System.Drawing.Point(4, 200)
        Me.Actualizar.Name = "Actualizar"
        Me.Actualizar.Size = New System.Drawing.Size(231, 21)
        Me.Actualizar.TabIndex = 13
        Me.Actualizar.Text = "Confirmar"
        '
        'lector
        '
        Me.lector.Location = New System.Drawing.Point(4, 50)
        Me.lector.Name = "lector"
        Me.lector.Size = New System.Drawing.Size(231, 21)
        Me.lector.TabIndex = 1
        '
        'numrece
        '
        Me.numrece.Enabled = False
        Me.numrece.Location = New System.Drawing.Point(72, 2)
        Me.numrece.Name = "numrece"
        Me.numrece.Size = New System.Drawing.Size(68, 21)
        Me.numrece.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(4, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 19)
        Me.Label2.Text = "Recepción"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label3.Location = New System.Drawing.Point(4, 224)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(231, 44)
        Me.Label3.Text = "Al agregar una etiqueta de muestra en una recepción en proceso, debe volver a lee" & _
            "r el soportante para que acepte los cambios."
        '
        'Frm_Traqueo_largo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.numrece)
        Me.Controls.Add(Me.Actualizar)
        Me.Controls.Add(Me.b5)
        Me.Controls.Add(Me.l5)
        Me.Controls.Add(Me.b4)
        Me.Controls.Add(Me.l4)
        Me.Controls.Add(Me.b3)
        Me.Controls.Add(Me.l3)
        Me.Controls.Add(Me.b2)
        Me.Controls.Add(Me.l2)
        Me.Controls.Add(Me.b1)
        Me.Controls.Add(Me.l1)
        Me.Controls.Add(Me.lector)
        Me.Controls.Add(Me.Label1)
        Me.Menu = Me.mainMenu1
        Me.Name = "Frm_Traqueo_largo"
        Me.Text = "Muestra de etiquetas"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents l1 As System.Windows.Forms.TextBox
    Friend WithEvents b1 As System.Windows.Forms.Button
    Friend WithEvents b2 As System.Windows.Forms.Button
    Friend WithEvents l2 As System.Windows.Forms.TextBox
    Friend WithEvents b3 As System.Windows.Forms.Button
    Friend WithEvents l3 As System.Windows.Forms.TextBox
    Friend WithEvents b4 As System.Windows.Forms.Button
    Friend WithEvents l4 As System.Windows.Forms.TextBox
    Friend WithEvents b5 As System.Windows.Forms.Button
    Friend WithEvents l5 As System.Windows.Forms.TextBox
    Friend WithEvents Actualizar As System.Windows.Forms.Button
    Friend WithEvents lector As System.Windows.Forms.TextBox
    Friend WithEvents numrece As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
