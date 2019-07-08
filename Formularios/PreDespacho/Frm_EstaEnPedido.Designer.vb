<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Frm_EstaEnPedido
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
        Me.nped = New System.Windows.Forms.TextBox
        Me.Limpiar = New System.Windows.Forms.Button
        Me.LstCajas = New System.Windows.Forms.ListBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtlectorcaja = New System.Windows.Forms.TextBox
        Me.Color = New System.Windows.Forms.PictureBox
        Me.mensaje = New System.Windows.Forms.Label
        Me.Actualizacjs = New System.Windows.Forms.Timer
        Me.LstLeidos = New System.Windows.Forms.ListBox
        Me.lblcantidad = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.LstCajasHistorial = New System.Windows.Forms.ListBox
        Me.lblcanttotal = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.VerEstado = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(4, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(21, 18)
        Me.Label1.Text = "N°"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'nped
        '
        Me.nped.Location = New System.Drawing.Point(25, 1)
        Me.nped.Name = "nped"
        Me.nped.Size = New System.Drawing.Size(56, 21)
        Me.nped.TabIndex = 1
        '
        'Limpiar
        '
        Me.Limpiar.Location = New System.Drawing.Point(84, 1)
        Me.Limpiar.Name = "Limpiar"
        Me.Limpiar.Size = New System.Drawing.Size(30, 20)
        Me.Limpiar.TabIndex = 2
        Me.Limpiar.Text = " X"
        '
        'LstCajas
        '
        Me.LstCajas.Location = New System.Drawing.Point(199, 184)
        Me.LstCajas.Name = "LstCajas"
        Me.LstCajas.Size = New System.Drawing.Size(37, 16)
        Me.LstCajas.TabIndex = 3
        Me.LstCajas.Visible = False
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(8, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(221, 20)
        Me.Label2.Text = "_________________________________"
        '
        'txtlectorcaja
        '
        Me.txtlectorcaja.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular)
        Me.txtlectorcaja.Location = New System.Drawing.Point(7, 29)
        Me.txtlectorcaja.Name = "txtlectorcaja"
        Me.txtlectorcaja.Size = New System.Drawing.Size(177, 24)
        Me.txtlectorcaja.TabIndex = 6
        '
        'Color
        '
        Me.Color.Location = New System.Drawing.Point(215, 29)
        Me.Color.Name = "Color"
        Me.Color.Size = New System.Drawing.Size(23, 24)
        '
        'mensaje
        '
        Me.mensaje.Location = New System.Drawing.Point(4, 244)
        Me.mensaje.Name = "mensaje"
        Me.mensaje.Size = New System.Drawing.Size(232, 20)
        '
        'Actualizacjs
        '
        Me.Actualizacjs.Interval = 9000
        '
        'LstLeidos
        '
        Me.LstLeidos.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular)
        Me.LstLeidos.Location = New System.Drawing.Point(5, 75)
        Me.LstLeidos.Name = "LstLeidos"
        Me.LstLeidos.Size = New System.Drawing.Size(232, 92)
        Me.LstLeidos.TabIndex = 16
        '
        'lblcantidad
        '
        Me.lblcantidad.Location = New System.Drawing.Point(118, 2)
        Me.lblcantidad.Name = "lblcantidad"
        Me.lblcantidad.Size = New System.Drawing.Size(39, 20)
        Me.lblcantidad.Text = "0"
        Me.lblcantidad.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(163, 1)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(20, 20)
        Me.Button2.TabIndex = 23
        Me.Button2.Text = "..."
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Green
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(8, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(155, 16)
        Me.Label4.Text = "LEIDOS SIN GUARDAR"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LstCajasHistorial
        '
        Me.LstCajasHistorial.Location = New System.Drawing.Point(199, 202)
        Me.LstCajasHistorial.Name = "LstCajasHistorial"
        Me.LstCajasHistorial.Size = New System.Drawing.Size(37, 16)
        Me.LstCajasHistorial.TabIndex = 31
        Me.LstCajasHistorial.Visible = False
        '
        'lblcanttotal
        '
        Me.lblcanttotal.Location = New System.Drawing.Point(164, 55)
        Me.lblcanttotal.Name = "lblcanttotal"
        Me.lblcanttotal.Size = New System.Drawing.Size(70, 17)
        Me.lblcanttotal.Tag = ""
        Me.lblcanttotal.Text = "0/0"
        Me.lblcanttotal.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Green
        Me.PictureBox1.Location = New System.Drawing.Point(4, 179)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(20, 18)
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Red
        Me.PictureBox2.Location = New System.Drawing.Point(4, 199)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(20, 18)
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Orange
        Me.PictureBox3.Location = New System.Drawing.Point(4, 219)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(20, 18)
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label3.Location = New System.Drawing.Point(26, 181)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(153, 21)
        Me.Label3.Text = "SI,    corresponde al pedido"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label5.Location = New System.Drawing.Point(26, 201)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(153, 21)
        Me.Label5.Text = "NO, corresponde al pedido"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label6.Location = New System.Drawing.Point(26, 221)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(208, 21)
        Me.Label6.Text = "SI,    corresponde al pedido (ya fue leída)"
        '
        'VerEstado
        '
        Me.VerEstado.Location = New System.Drawing.Point(188, 29)
        Me.VerEstado.Name = "VerEstado"
        Me.VerEstado.Size = New System.Drawing.Size(24, 24)
        Me.VerEstado.TabIndex = 38
        Me.VerEstado.Text = "..."
        '
        'Frm_EstaEnPedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.VerEstado)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblcanttotal)
        Me.Controls.Add(Me.LstCajasHistorial)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.lblcantidad)
        Me.Controls.Add(Me.LstLeidos)
        Me.Controls.Add(Me.mensaje)
        Me.Controls.Add(Me.Color)
        Me.Controls.Add(Me.txtlectorcaja)
        Me.Controls.Add(Me.Limpiar)
        Me.Controls.Add(Me.nped)
        Me.Controls.Add(Me.LstCajas)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.KeyPreview = True
        Me.Menu = Me.mainMenu1
        Me.Name = "Frm_EstaEnPedido"
        Me.Text = "Verificación de pedido"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nped As System.Windows.Forms.TextBox
    Friend WithEvents Limpiar As System.Windows.Forms.Button
    Friend WithEvents LstCajas As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtlectorcaja As System.Windows.Forms.TextBox
    Friend WithEvents Color As System.Windows.Forms.PictureBox
    Friend WithEvents mensaje As System.Windows.Forms.Label
    Friend WithEvents Actualizacjs As System.Windows.Forms.Timer
    Friend WithEvents LstLeidos As System.Windows.Forms.ListBox
    Friend WithEvents lblcantidad As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LstCajasHistorial As System.Windows.Forms.ListBox
    Friend WithEvents lblcanttotal As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents VerEstado As System.Windows.Forms.Button
End Class
