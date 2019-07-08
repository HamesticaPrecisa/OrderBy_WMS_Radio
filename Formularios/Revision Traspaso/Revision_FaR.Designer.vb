<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Revision_FaR
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
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.lblproducto = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.lblencargado = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.ncliente = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Panel8 = New System.Windows.Forms.Panel
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Panel9 = New System.Windows.Forms.Panel
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Panel10 = New System.Windows.Forms.Panel
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblMensaje = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.BtnCancelar = New System.Windows.Forms.Button
        Me.lblusu = New System.Windows.Forms.Label
        Me.BtnNo = New System.Windows.Forms.Button
        Me.BtnSi = New System.Windows.Forms.Button
        Me.BtnPallet = New System.Windows.Forms.Button
        Me.txtpallet = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblcant = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Txtnped = New System.Windows.Forms.TextBox
        Me.BtnPedido = New System.Windows.Forms.Button
        Me.body = New System.Windows.Forms.Panel
        Me.lblmsgbox = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.body.SuspendLayout()
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
        Me.MenuItem2.Text = "Faltantes Por Pedido"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel4.Controls.Add(Me.lblproducto)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Location = New System.Drawing.Point(5, 176)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(225, 28)
        '
        'lblproducto
        '
        Me.lblproducto.Location = New System.Drawing.Point(44, 5)
        Me.lblproducto.Name = "lblproducto"
        Me.lblproducto.Size = New System.Drawing.Size(168, 17)
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(3, 5)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 17)
        Me.Label7.Text = "PROD"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel3.Controls.Add(Me.lblencargado)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Location = New System.Drawing.Point(5, 207)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(225, 28)
        '
        'lblencargado
        '
        Me.lblencargado.Location = New System.Drawing.Point(87, 6)
        Me.lblencargado.Name = "lblencargado"
        Me.lblencargado.Size = New System.Drawing.Size(125, 17)
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(4, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 17)
        Me.Label5.Text = "ENCARGADO"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel2.Controls.Add(Me.ncliente)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Panel8)
        Me.Panel2.Controls.Add(Me.Panel9)
        Me.Panel2.Controls.Add(Me.Panel10)
        Me.Panel2.Location = New System.Drawing.Point(5, 146)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(225, 28)
        '
        'ncliente
        '
        Me.ncliente.Location = New System.Drawing.Point(75, 6)
        Me.ncliente.Name = "ncliente"
        Me.ncliente.Size = New System.Drawing.Size(144, 17)
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(3, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 17)
        Me.Label6.Text = "N CLIENTE"
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel8.Controls.Add(Me.Label11)
        Me.Panel8.Controls.Add(Me.Label17)
        Me.Panel8.Controls.Add(Me.Label18)
        Me.Panel8.Location = New System.Drawing.Point(0, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(225, 28)
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(161, 6)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(144, 17)
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(75, 6)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(144, 17)
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label18.Location = New System.Drawing.Point(3, 6)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(72, 17)
        Me.Label18.Text = "N CLIENTE"
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel9.Controls.Add(Me.Label19)
        Me.Panel9.Controls.Add(Me.Label20)
        Me.Panel9.Location = New System.Drawing.Point(0, 61)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(225, 28)
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(87, 6)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(125, 17)
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label20.Location = New System.Drawing.Point(4, 6)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(86, 17)
        Me.Label20.Text = "ENCARGADO"
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel10.Controls.Add(Me.Label21)
        Me.Panel10.Controls.Add(Me.Label22)
        Me.Panel10.Location = New System.Drawing.Point(0, 30)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(225, 28)
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(44, 5)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(168, 17)
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label22.Location = New System.Drawing.Point(3, 5)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(42, 17)
        Me.Label22.Text = "PROD"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lblMensaje)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(5, 116)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(226, 28)
        '
        'lblMensaje
        '
        Me.lblMensaje.Location = New System.Drawing.Point(58, 5)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(158, 17)
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(5, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 17)
        Me.Label3.Text = "NOTA"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnCancelar.ForeColor = System.Drawing.Color.White
        Me.BtnCancelar.Location = New System.Drawing.Point(138, 76)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(77, 20)
        Me.BtnCancelar.TabIndex = 30
        Me.BtnCancelar.Text = "CANCELAR"
        Me.BtnCancelar.Visible = False
        '
        'lblusu
        '
        Me.lblusu.Location = New System.Drawing.Point(6, 35)
        Me.lblusu.Name = "lblusu"
        Me.lblusu.Size = New System.Drawing.Size(13, 10)
        Me.lblusu.Text = "000"
        Me.lblusu.Visible = False
        '
        'BtnNo
        '
        Me.BtnNo.BackColor = System.Drawing.Color.Red
        Me.BtnNo.ForeColor = System.Drawing.Color.White
        Me.BtnNo.Location = New System.Drawing.Point(84, 76)
        Me.BtnNo.Name = "BtnNo"
        Me.BtnNo.Size = New System.Drawing.Size(40, 20)
        Me.BtnNo.TabIndex = 29
        Me.BtnNo.Text = "NO"
        Me.BtnNo.Visible = False
        '
        'BtnSi
        '
        Me.BtnSi.BackColor = System.Drawing.Color.Green
        Me.BtnSi.ForeColor = System.Drawing.Color.White
        Me.BtnSi.Location = New System.Drawing.Point(30, 76)
        Me.BtnSi.Name = "BtnSi"
        Me.BtnSi.Size = New System.Drawing.Size(40, 20)
        Me.BtnSi.TabIndex = 28
        Me.BtnSi.Text = "SI"
        Me.BtnSi.Visible = False
        '
        'BtnPallet
        '
        Me.BtnPallet.Location = New System.Drawing.Point(201, 8)
        Me.BtnPallet.Name = "BtnPallet"
        Me.BtnPallet.Size = New System.Drawing.Size(25, 21)
        Me.BtnPallet.TabIndex = 26
        Me.BtnPallet.Text = " ..."
        '
        'txtpallet
        '
        Me.txtpallet.Location = New System.Drawing.Point(45, 8)
        Me.txtpallet.Name = "txtpallet"
        Me.txtpallet.Size = New System.Drawing.Size(153, 21)
        Me.txtpallet.TabIndex = 22
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(2, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 20)
        Me.Label2.Text = "PALLET"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(3, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 27)
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.Label4.Location = New System.Drawing.Point(3, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 25)
        Me.Label4.Text = "ENVASES"
        '
        'lblcant
        '
        Me.lblcant.Font = New System.Drawing.Font("Tahoma", 28.0!, System.Drawing.FontStyle.Bold)
        Me.lblcant.Location = New System.Drawing.Point(117, 29)
        Me.lblcant.Name = "lblcant"
        Me.lblcant.Size = New System.Drawing.Size(90, 45)
        Me.lblcant.Text = "0"
        Me.lblcant.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblcant.Visible = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(3, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 20)
        Me.Label8.Text = "PEDIDO"
        '
        'Txtnped
        '
        Me.Txtnped.Location = New System.Drawing.Point(53, 5)
        Me.Txtnped.Name = "Txtnped"
        Me.Txtnped.Size = New System.Drawing.Size(49, 21)
        Me.Txtnped.TabIndex = 38
        '
        'BtnPedido
        '
        Me.BtnPedido.Location = New System.Drawing.Point(107, 5)
        Me.BtnPedido.Name = "BtnPedido"
        Me.BtnPedido.Size = New System.Drawing.Size(25, 21)
        Me.BtnPedido.TabIndex = 39
        Me.BtnPedido.Text = "..."
        '
        'body
        '
        Me.body.Controls.Add(Me.lblmsgbox)
        Me.body.Controls.Add(Me.Label4)
        Me.body.Controls.Add(Me.BtnSi)
        Me.body.Controls.Add(Me.BtnNo)
        Me.body.Controls.Add(Me.BtnPallet)
        Me.body.Controls.Add(Me.Panel4)
        Me.body.Controls.Add(Me.txtpallet)
        Me.body.Controls.Add(Me.lblusu)
        Me.body.Controls.Add(Me.Label2)
        Me.body.Controls.Add(Me.Panel3)
        Me.body.Controls.Add(Me.Label9)
        Me.body.Controls.Add(Me.BtnCancelar)
        Me.body.Controls.Add(Me.Panel2)
        Me.body.Controls.Add(Me.Panel1)
        Me.body.Controls.Add(Me.lblcant)
        Me.body.Enabled = False
        Me.body.Location = New System.Drawing.Point(0, 30)
        Me.body.Name = "body"
        Me.body.Size = New System.Drawing.Size(234, 238)
        '
        'lblmsgbox
        '
        Me.lblmsgbox.BackColor = System.Drawing.Color.Gray
        Me.lblmsgbox.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblmsgbox.ForeColor = System.Drawing.Color.White
        Me.lblmsgbox.Location = New System.Drawing.Point(5, 99)
        Me.lblmsgbox.Name = "lblmsgbox"
        Me.lblmsgbox.Size = New System.Drawing.Size(225, 18)
        Me.lblmsgbox.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(3, 5)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(226, 27)
        '
        'Revision_FaR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(244, 273)
        Me.Controls.Add(Me.body)
        Me.Controls.Add(Me.BtnPedido)
        Me.Controls.Add(Me.Txtnped)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label1)
        Me.Menu = Me.mainMenu1
        Me.Name = "Revision_FaR"
        Me.Text = "Revisión Pedidos"
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.body.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lblproducto As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblencargado As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ncliente As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblMensaje As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblusu As System.Windows.Forms.Label
    Friend WithEvents BtnNo As System.Windows.Forms.Button
    Friend WithEvents BtnSi As System.Windows.Forms.Button
    Friend WithEvents BtnPallet As System.Windows.Forms.Button
    Friend WithEvents txtpallet As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblcant As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Txtnped As System.Windows.Forms.TextBox
    Friend WithEvents BtnPedido As System.Windows.Forms.Button
    Friend WithEvents body As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents lblmsgbox As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
