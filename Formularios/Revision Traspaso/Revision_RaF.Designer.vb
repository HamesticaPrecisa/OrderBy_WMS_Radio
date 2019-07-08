<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Revision_RaF
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
        Me.txtpallet = New System.Windows.Forms.TextBox
        Me.ToolBar1 = New System.Windows.Forms.ToolBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnPallet = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblcant = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.BtnSi = New System.Windows.Forms.Button
        Me.BtnNo = New System.Windows.Forms.Button
        Me.lblMensaje = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblusu = New System.Windows.Forms.Label
        Me.BtnCancelar = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblencargado = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.ncliente = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblproducto = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.Add(Me.MenuItem1)
        '
        'MenuItem1
        '
        Me.MenuItem1.MenuItems.Add(Me.MenuItem2)
        Me.MenuItem1.Text = "Opciones"
        '
        'MenuItem2
        '
        Me.MenuItem2.Text = "Estado de una recepción"
        '
        'txtpallet
        '
        Me.txtpallet.Location = New System.Drawing.Point(47, 11)
        Me.txtpallet.Name = "txtpallet"
        Me.txtpallet.Size = New System.Drawing.Size(160, 21)
        Me.txtpallet.TabIndex = 0
        '
        'ToolBar1
        '
        Me.ToolBar1.Name = "ToolBar1"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(3, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(235, 31)
        '
        'BtnPallet
        '
        Me.BtnPallet.Location = New System.Drawing.Point(210, 11)
        Me.BtnPallet.Name = "BtnPallet"
        Me.BtnPallet.Size = New System.Drawing.Size(25, 21)
        Me.BtnPallet.TabIndex = 3
        Me.BtnPallet.Text = " ..."
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(3, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 20)
        Me.Label2.Text = "PALLET"
        '
        'lblcant
        '
        Me.lblcant.Font = New System.Drawing.Font("Tahoma", 28.0!, System.Drawing.FontStyle.Bold)
        Me.lblcant.Location = New System.Drawing.Point(117, 47)
        Me.lblcant.Name = "lblcant"
        Me.lblcant.Size = New System.Drawing.Size(90, 45)
        Me.lblcant.Text = "0"
        Me.lblcant.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblcant.Visible = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.Label4.Location = New System.Drawing.Point(3, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 25)
        Me.Label4.Text = "ENVASES"
        '
        'BtnSi
        '
        Me.BtnSi.BackColor = System.Drawing.Color.Green
        Me.BtnSi.ForeColor = System.Drawing.Color.White
        Me.BtnSi.Location = New System.Drawing.Point(30, 101)
        Me.BtnSi.Name = "BtnSi"
        Me.BtnSi.Size = New System.Drawing.Size(40, 20)
        Me.BtnSi.TabIndex = 7
        Me.BtnSi.Text = "SI"
        Me.BtnSi.Visible = False
        '
        'BtnNo
        '
        Me.BtnNo.BackColor = System.Drawing.Color.Red
        Me.BtnNo.ForeColor = System.Drawing.Color.White
        Me.BtnNo.Location = New System.Drawing.Point(84, 101)
        Me.BtnNo.Name = "BtnNo"
        Me.BtnNo.Size = New System.Drawing.Size(40, 20)
        Me.BtnNo.TabIndex = 8
        Me.BtnNo.Text = "NO"
        Me.BtnNo.Visible = False
        '
        'lblMensaje
        '
        Me.lblMensaje.Location = New System.Drawing.Point(47, 5)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(182, 17)
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(5, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 17)
        Me.Label3.Text = "NOTA"
        '
        'lblusu
        '
        Me.lblusu.Location = New System.Drawing.Point(5, 39)
        Me.lblusu.Name = "lblusu"
        Me.lblusu.Size = New System.Drawing.Size(13, 10)
        Me.lblusu.Text = "000"
        Me.lblusu.Visible = False
        '
        'BtnCancelar
        '
        Me.BtnCancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnCancelar.ForeColor = System.Drawing.Color.White
        Me.BtnCancelar.Location = New System.Drawing.Point(138, 101)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(77, 20)
        Me.BtnCancelar.TabIndex = 16
        Me.BtnCancelar.Text = "CANCELAR"
        Me.BtnCancelar.Visible = False
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(4, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 17)
        Me.Label5.Text = "ENCARGADO"
        '
        'lblencargado
        '
        Me.lblencargado.Location = New System.Drawing.Point(87, 6)
        Me.lblencargado.Name = "lblencargado"
        Me.lblencargado.Size = New System.Drawing.Size(142, 17)
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(3, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 17)
        Me.Label6.Text = "N CLIENTE"
        '
        'ncliente
        '
        Me.ncliente.Location = New System.Drawing.Point(73, 6)
        Me.ncliente.Name = "ncliente"
        Me.ncliente.Size = New System.Drawing.Size(157, 17)
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lblMensaje)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(3, 129)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(233, 28)
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel2.Controls.Add(Me.ncliente)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Location = New System.Drawing.Point(3, 161)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(233, 28)
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel3.Controls.Add(Me.lblencargado)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Location = New System.Drawing.Point(3, 224)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(233, 28)
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel4.Controls.Add(Me.lblproducto)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Location = New System.Drawing.Point(3, 192)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(233, 28)
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(3, 5)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 17)
        Me.Label7.Text = "PROD"
        '
        'lblproducto
        '
        Me.lblproducto.Location = New System.Drawing.Point(44, 5)
        Me.lblproducto.Name = "lblproducto"
        Me.lblproducto.Size = New System.Drawing.Size(185, 17)
        '
        'Revision_RaF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.lblusu)
        Me.Controls.Add(Me.BtnNo)
        Me.Controls.Add(Me.BtnSi)
        Me.Controls.Add(Me.BtnPallet)
        Me.Controls.Add(Me.txtpallet)
        Me.Controls.Add(Me.ToolBar1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblcant)
        Me.Menu = Me.mainMenu1
        Me.Name = "Revision_RaF"
        Me.Text = "Revisión Soportantes"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtpallet As System.Windows.Forms.TextBox
    Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnPallet As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblcant As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtnSi As System.Windows.Forms.Button
    Friend WithEvents BtnNo As System.Windows.Forms.Button
    Friend WithEvents lblMensaje As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblusu As System.Windows.Forms.Label
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblencargado As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ncliente As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblproducto As System.Windows.Forms.Label
End Class
