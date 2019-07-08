<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Frm_Repaletiza
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
        Me.RDSUGERIDO = New System.Windows.Forms.RadioButton
        Me.RDMANUAL = New System.Windows.Forms.RadioButton
        Me.txtorigen = New System.Windows.Forms.TextBox
        Me.txtdestino = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtcaja = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblcantori = New System.Windows.Forms.Label
        Me.lblcantdes = New System.Windows.Forms.Label
        Me.txtconfdest = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.btnok = New System.Windows.Forms.Button
        Me.btn_mal = New System.Windows.Forms.Button
        Me.btn_bien = New System.Windows.Forms.Button
        Me.btnotro = New System.Windows.Forms.Button
        Me.LBLPOS = New System.Windows.Forms.Label
        Me.btnnodestino = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'RDSUGERIDO
        '
        Me.RDSUGERIDO.Location = New System.Drawing.Point(83, -1)
        Me.RDSUGERIDO.Name = "RDSUGERIDO"
        Me.RDSUGERIDO.Size = New System.Drawing.Size(91, 20)
        Me.RDSUGERIDO.TabIndex = 0
        Me.RDSUGERIDO.Text = "SUGERIDO"
        '
        'RDMANUAL
        '
        Me.RDMANUAL.Location = New System.Drawing.Point(3, -1)
        Me.RDMANUAL.Name = "RDMANUAL"
        Me.RDMANUAL.Size = New System.Drawing.Size(74, 20)
        Me.RDMANUAL.TabIndex = 1
        Me.RDMANUAL.Text = "MANUAL"
        '
        'txtorigen
        '
        Me.txtorigen.Enabled = False
        Me.txtorigen.Location = New System.Drawing.Point(3, 39)
        Me.txtorigen.Name = "txtorigen"
        Me.txtorigen.Size = New System.Drawing.Size(100, 21)
        Me.txtorigen.TabIndex = 2
        '
        'txtdestino
        '
        Me.txtdestino.Enabled = False
        Me.txtdestino.Location = New System.Drawing.Point(115, 39)
        Me.txtdestino.Name = "txtdestino"
        Me.txtdestino.Size = New System.Drawing.Size(100, 21)
        Me.txtdestino.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.Text = "PALLET ORIGEN"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(115, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.Text = "PALLET DESTINO"
        '
        'txtcaja
        '
        Me.txtcaja.Location = New System.Drawing.Point(0, 174)
        Me.txtcaja.Name = "txtcaja"
        Me.txtcaja.Size = New System.Drawing.Size(186, 21)
        Me.txtcaja.TabIndex = 74
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(0, 156)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(186, 18)
        Me.Label3.Text = "LECTURA CAJA ORIGEN"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(0, 196)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(135, 13)
        Me.Label4.Text = "CONFIRMA DESTINO "
        '
        'lblcantori
        '
        Me.lblcantori.Font = New System.Drawing.Font("Tahoma", 40.0!, System.Drawing.FontStyle.Regular)
        Me.lblcantori.Location = New System.Drawing.Point(3, 92)
        Me.lblcantori.Name = "lblcantori"
        Me.lblcantori.Size = New System.Drawing.Size(100, 60)
        Me.lblcantori.Text = "0"
        '
        'lblcantdes
        '
        Me.lblcantdes.Font = New System.Drawing.Font("Tahoma", 40.0!, System.Drawing.FontStyle.Regular)
        Me.lblcantdes.Location = New System.Drawing.Point(109, 92)
        Me.lblcantdes.Name = "lblcantdes"
        Me.lblcantdes.Size = New System.Drawing.Size(100, 60)
        Me.lblcantdes.Text = "0"
        '
        'txtconfdest
        '
        Me.txtconfdest.Enabled = False
        Me.txtconfdest.Location = New System.Drawing.Point(0, 212)
        Me.txtconfdest.Name = "txtconfdest"
        Me.txtconfdest.Size = New System.Drawing.Size(186, 21)
        Me.txtconfdest.TabIndex = 83
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(3, 237)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 30)
        Me.Button1.TabIndex = 84
        Me.Button1.Text = "Limpiar "
        '
        'btnok
        '
        Me.btnok.Enabled = False
        Me.btnok.Location = New System.Drawing.Point(147, 237)
        Me.btnok.Name = "btnok"
        Me.btnok.Size = New System.Drawing.Size(87, 30)
        Me.btnok.TabIndex = 85
        Me.btnok.Text = "Confirmar"
        '
        'btn_mal
        '
        Me.btn_mal.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btn_mal.Enabled = False
        Me.btn_mal.Font = New System.Drawing.Font("Courier New", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btn_mal.ForeColor = System.Drawing.Color.White
        Me.btn_mal.Location = New System.Drawing.Point(211, 174)
        Me.btn_mal.Name = "btn_mal"
        Me.btn_mal.Size = New System.Drawing.Size(23, 21)
        Me.btn_mal.TabIndex = 87
        Me.btn_mal.Text = "×"
        Me.btn_mal.Visible = False
        '
        'btn_bien
        '
        Me.btn_bien.BackColor = System.Drawing.Color.Green
        Me.btn_bien.Enabled = False
        Me.btn_bien.Font = New System.Drawing.Font("Wingdings", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btn_bien.ForeColor = System.Drawing.Color.White
        Me.btn_bien.Location = New System.Drawing.Point(192, 174)
        Me.btn_bien.Name = "btn_bien"
        Me.btn_bien.Size = New System.Drawing.Size(23, 21)
        Me.btn_bien.TabIndex = 86
        Me.btn_bien.Text = "ü"
        Me.btn_bien.Visible = False
        '
        'btnotro
        '
        Me.btnotro.BackColor = System.Drawing.Color.CadetBlue
        Me.btnotro.Enabled = False
        Me.btnotro.ForeColor = System.Drawing.Color.Black
        Me.btnotro.Location = New System.Drawing.Point(217, 39)
        Me.btnotro.Name = "btnotro"
        Me.btnotro.Size = New System.Drawing.Size(23, 21)
        Me.btnotro.TabIndex = 94
        Me.btnotro.Text = "+"
        '
        'LBLPOS
        '
        Me.LBLPOS.Location = New System.Drawing.Point(115, 63)
        Me.LBLPOS.Name = "LBLPOS"
        Me.LBLPOS.Size = New System.Drawing.Size(119, 20)
        '
        'btnnodestino
        '
        Me.btnnodestino.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnnodestino.Enabled = False
        Me.btnnodestino.Font = New System.Drawing.Font("Courier New", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btnnodestino.ForeColor = System.Drawing.Color.White
        Me.btnnodestino.Location = New System.Drawing.Point(192, 212)
        Me.btnnodestino.Name = "btnnodestino"
        Me.btnnodestino.Size = New System.Drawing.Size(23, 21)
        Me.btnnodestino.TabIndex = 96
        Me.btnnodestino.Text = "×"
        Me.btnnodestino.Visible = False
        '
        'Frm_Repaletiza
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.btnnodestino)
        Me.Controls.Add(Me.LBLPOS)
        Me.Controls.Add(Me.btnotro)
        Me.Controls.Add(Me.btn_mal)
        Me.Controls.Add(Me.btn_bien)
        Me.Controls.Add(Me.btnok)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtconfdest)
        Me.Controls.Add(Me.lblcantdes)
        Me.Controls.Add(Me.lblcantori)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtcaja)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtdestino)
        Me.Controls.Add(Me.txtorigen)
        Me.Controls.Add(Me.RDMANUAL)
        Me.Controls.Add(Me.RDSUGERIDO)
        Me.Menu = Me.mainMenu1
        Me.Name = "Frm_Repaletiza"
        Me.Text = "Repaletizaje "
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RDSUGERIDO As System.Windows.Forms.RadioButton
    Friend WithEvents RDMANUAL As System.Windows.Forms.RadioButton
    Friend WithEvents txtorigen As System.Windows.Forms.TextBox
    Friend WithEvents txtdestino As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtcaja As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblcantori As System.Windows.Forms.Label
    Friend WithEvents lblcantdes As System.Windows.Forms.Label
    Friend WithEvents txtconfdest As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnok As System.Windows.Forms.Button
    Friend WithEvents btn_mal As System.Windows.Forms.Button
    Friend WithEvents btn_bien As System.Windows.Forms.Button
    Friend WithEvents btnotro As System.Windows.Forms.Button
    Friend WithEvents LBLPOS As System.Windows.Forms.Label
    Friend WithEvents btnnodestino As System.Windows.Forms.Button
End Class
