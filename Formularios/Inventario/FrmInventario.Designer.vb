<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FrmInventario
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
        Me.Txtpallet = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.tca = New System.Windows.Forms.TextBox
        Me.tba = New System.Windows.Forms.TextBox
        Me.tco = New System.Windows.Forms.TextBox
        Me.tpi = New System.Windows.Forms.TextBox
        Me.tni = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cli_sin = New System.Windows.Forms.RadioButton
        Me.cli_no = New System.Windows.Forms.RadioButton
        Me.cli_si = New System.Windows.Forms.RadioButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblcliente = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.lblestado = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.traq = New System.Windows.Forms.Label
        Me.rev = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblprod = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.pro_no = New System.Windows.Forms.RadioButton
        Me.pro_si = New System.Windows.Forms.RadioButton
        Me.pro_sin = New System.Windows.Forms.RadioButton
        Me.Label15 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.lblcant = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.cant_no = New System.Windows.Forms.RadioButton
        Me.cant_si = New System.Windows.Forms.RadioButton
        Me.cant_sin = New System.Windows.Forms.RadioButton
        Me.Label18 = New System.Windows.Forms.Label
        Me.main = New System.Windows.Forms.Panel
        Me.BtnGuardar = New System.Windows.Forms.Button
        Me.cancelar = New System.Windows.Forms.Button
        Me.lblncli = New System.Windows.Forms.TextBox
        Me.btnlimpiar = New System.Windows.Forms.Button
        Me.lblleidos = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.ULTIMO = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.main.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(5, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 20)
        Me.Label1.Text = "N°"
        '
        'Txtpallet
        '
        Me.Txtpallet.Location = New System.Drawing.Point(25, 3)
        Me.Txtpallet.Name = "Txtpallet"
        Me.Txtpallet.Size = New System.Drawing.Size(70, 21)
        Me.Txtpallet.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(5, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(231, 20)
        Me.Label2.Text = "__________________________________"
        '
        'tca
        '
        Me.tca.Enabled = False
        Me.tca.Location = New System.Drawing.Point(78, 2)
        Me.tca.Name = "tca"
        Me.tca.Size = New System.Drawing.Size(21, 21)
        Me.tca.TabIndex = 3
        Me.tca.WordWrap = False
        '
        'tba
        '
        Me.tba.Enabled = False
        Me.tba.Location = New System.Drawing.Point(108, 2)
        Me.tba.Name = "tba"
        Me.tba.Size = New System.Drawing.Size(21, 21)
        Me.tba.TabIndex = 4
        Me.tba.WordWrap = False
        '
        'tco
        '
        Me.tco.Enabled = False
        Me.tco.Location = New System.Drawing.Point(138, 2)
        Me.tco.Name = "tco"
        Me.tco.Size = New System.Drawing.Size(21, 21)
        Me.tco.TabIndex = 5
        Me.tco.WordWrap = False
        '
        'tpi
        '
        Me.tpi.Enabled = False
        Me.tpi.Location = New System.Drawing.Point(168, 2)
        Me.tpi.Name = "tpi"
        Me.tpi.Size = New System.Drawing.Size(21, 21)
        Me.tpi.TabIndex = 6
        Me.tpi.WordWrap = False
        '
        'tni
        '
        Me.tni.Enabled = False
        Me.tni.Location = New System.Drawing.Point(198, 2)
        Me.tni.Name = "tni"
        Me.tni.Size = New System.Drawing.Size(21, 21)
        Me.tni.TabIndex = 7
        Me.tni.WordWrap = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(1, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 15)
        Me.Label3.Text = "POSICION"
        '
        'cli_sin
        '
        Me.cli_sin.Checked = True
        Me.cli_sin.ForeColor = System.Drawing.Color.Black
        Me.cli_sin.Location = New System.Drawing.Point(165, 20)
        Me.cli_sin.Name = "cli_sin"
        Me.cli_sin.Size = New System.Drawing.Size(49, 17)
        Me.cli_sin.TabIndex = 47
        Me.cli_sin.Text = "----"
        '
        'cli_no
        '
        Me.cli_no.ForeColor = System.Drawing.Color.Black
        Me.cli_no.Location = New System.Drawing.Point(110, 20)
        Me.cli_no.Name = "cli_no"
        Me.cli_no.Size = New System.Drawing.Size(49, 17)
        Me.cli_no.TabIndex = 46
        Me.cli_no.TabStop = False
        Me.cli_no.Text = "NO"
        '
        'cli_si
        '
        Me.cli_si.ForeColor = System.Drawing.Color.Black
        Me.cli_si.Location = New System.Drawing.Point(49, 20)
        Me.cli_si.Name = "cli_si"
        Me.cli_si.Size = New System.Drawing.Size(49, 17)
        Me.cli_si.TabIndex = 45
        Me.cli_si.TabStop = False
        Me.cli_si.Text = "SI"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.Controls.Add(Me.lblcliente)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.cli_no)
        Me.Panel1.Controls.Add(Me.cli_si)
        Me.Panel1.Controls.Add(Me.cli_sin)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Location = New System.Drawing.Point(1, 66)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(234, 40)
        '
        'lblcliente
        '
        Me.lblcliente.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.lblcliente.Location = New System.Drawing.Point(56, 2)
        Me.lblcliente.Name = "lblcliente"
        Me.lblcliente.Size = New System.Drawing.Size(177, 15)
        Me.lblcliente.Text = "GRANJA MARINA"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(1, 2)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 17)
        Me.Label6.Text = "CLIENTE"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(2, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(231, 20)
        Me.Label7.Text = "________________________________"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(2, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 15)
        Me.Label11.Text = "ESTADO"
        '
        'lblestado
        '
        Me.lblestado.Location = New System.Drawing.Point(78, 26)
        Me.lblestado.Name = "lblestado"
        Me.lblestado.Size = New System.Drawing.Size(141, 19)
        Me.lblestado.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(2, 46)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 15)
        Me.Label12.Text = "TRAQUEADO"
        '
        'traq
        '
        Me.traq.Location = New System.Drawing.Point(74, 46)
        Me.traq.Name = "traq"
        Me.traq.Size = New System.Drawing.Size(30, 18)
        Me.traq.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'rev
        '
        Me.rev.Location = New System.Drawing.Point(188, 46)
        Me.rev.Name = "rev"
        Me.rev.Size = New System.Drawing.Size(30, 18)
        Me.rev.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(124, 46)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 15)
        Me.Label14.Text = "REVISADO"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Silver
        Me.Panel2.Controls.Add(Me.lblprod)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.pro_no)
        Me.Panel2.Controls.Add(Me.pro_si)
        Me.Panel2.Controls.Add(Me.pro_sin)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Location = New System.Drawing.Point(1, 109)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(234, 40)
        '
        'lblprod
        '
        Me.lblprod.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.lblprod.Location = New System.Drawing.Point(37, 2)
        Me.lblprod.Name = "lblprod"
        Me.lblprod.Size = New System.Drawing.Size(187, 17)
        Me.lblprod.Text = "GRANJA MARINA"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(1, 2)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 17)
        Me.Label10.Text = "PROD"
        '
        'pro_no
        '
        Me.pro_no.ForeColor = System.Drawing.Color.Black
        Me.pro_no.Location = New System.Drawing.Point(110, 20)
        Me.pro_no.Name = "pro_no"
        Me.pro_no.Size = New System.Drawing.Size(49, 17)
        Me.pro_no.TabIndex = 46
        Me.pro_no.TabStop = False
        Me.pro_no.Text = "NO"
        '
        'pro_si
        '
        Me.pro_si.ForeColor = System.Drawing.Color.Black
        Me.pro_si.Location = New System.Drawing.Point(49, 20)
        Me.pro_si.Name = "pro_si"
        Me.pro_si.Size = New System.Drawing.Size(49, 17)
        Me.pro_si.TabIndex = 45
        Me.pro_si.TabStop = False
        Me.pro_si.Text = "SI"
        '
        'pro_sin
        '
        Me.pro_sin.Checked = True
        Me.pro_sin.ForeColor = System.Drawing.Color.Black
        Me.pro_sin.Location = New System.Drawing.Point(165, 20)
        Me.pro_sin.Name = "pro_sin"
        Me.pro_sin.Size = New System.Drawing.Size(49, 17)
        Me.pro_sin.TabIndex = 47
        Me.pro_sin.Text = "----"
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(2, 6)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(231, 20)
        Me.Label15.Text = "________________________________"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Silver
        Me.Panel3.Controls.Add(Me.lblcant)
        Me.Panel3.Controls.Add(Me.Label17)
        Me.Panel3.Controls.Add(Me.cant_no)
        Me.Panel3.Controls.Add(Me.cant_si)
        Me.Panel3.Controls.Add(Me.cant_sin)
        Me.Panel3.Controls.Add(Me.Label18)
        Me.Panel3.Location = New System.Drawing.Point(1, 152)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(234, 40)
        '
        'lblcant
        '
        Me.lblcant.Location = New System.Drawing.Point(67, 2)
        Me.lblcant.Name = "lblcant"
        Me.lblcant.Size = New System.Drawing.Size(40, 17)
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label17.Location = New System.Drawing.Point(1, 2)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(69, 17)
        Me.Label17.Text = "CANTIDAD"
        '
        'cant_no
        '
        Me.cant_no.ForeColor = System.Drawing.Color.Black
        Me.cant_no.Location = New System.Drawing.Point(110, 20)
        Me.cant_no.Name = "cant_no"
        Me.cant_no.Size = New System.Drawing.Size(49, 17)
        Me.cant_no.TabIndex = 46
        Me.cant_no.TabStop = False
        Me.cant_no.Text = "NO"
        '
        'cant_si
        '
        Me.cant_si.ForeColor = System.Drawing.Color.Black
        Me.cant_si.Location = New System.Drawing.Point(49, 20)
        Me.cant_si.Name = "cant_si"
        Me.cant_si.Size = New System.Drawing.Size(49, 17)
        Me.cant_si.TabIndex = 45
        Me.cant_si.TabStop = False
        Me.cant_si.Text = "SI"
        '
        'cant_sin
        '
        Me.cant_sin.Checked = True
        Me.cant_sin.ForeColor = System.Drawing.Color.Black
        Me.cant_sin.Location = New System.Drawing.Point(165, 20)
        Me.cant_sin.Name = "cant_sin"
        Me.cant_sin.Size = New System.Drawing.Size(49, 17)
        Me.cant_sin.TabIndex = 47
        Me.cant_sin.Text = "----"
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(2, 6)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(231, 20)
        Me.Label18.Text = "________________________________"
        '
        'main
        '
        Me.main.Controls.Add(Me.BtnGuardar)
        Me.main.Controls.Add(Me.Panel3)
        Me.main.Controls.Add(Me.Label3)
        Me.main.Controls.Add(Me.Panel2)
        Me.main.Controls.Add(Me.rev)
        Me.main.Controls.Add(Me.Label14)
        Me.main.Controls.Add(Me.traq)
        Me.main.Controls.Add(Me.Label12)
        Me.main.Controls.Add(Me.lblestado)
        Me.main.Controls.Add(Me.Label11)
        Me.main.Controls.Add(Me.Panel1)
        Me.main.Controls.Add(Me.tni)
        Me.main.Controls.Add(Me.tpi)
        Me.main.Controls.Add(Me.tco)
        Me.main.Controls.Add(Me.tba)
        Me.main.Controls.Add(Me.tca)
        Me.main.Enabled = False
        Me.main.Location = New System.Drawing.Point(2, 29)
        Me.main.Name = "main"
        Me.main.Size = New System.Drawing.Size(237, 216)
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Location = New System.Drawing.Point(3, 195)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(232, 18)
        Me.BtnGuardar.TabIndex = 75
        Me.BtnGuardar.Text = "GUARDAR CAMBIOS"
        '
        'cancelar
        '
        Me.cancelar.Location = New System.Drawing.Point(98, 3)
        Me.cancelar.Name = "cancelar"
        Me.cancelar.Size = New System.Drawing.Size(26, 21)
        Me.cancelar.TabIndex = 57
        Me.cancelar.Text = "..."
        '
        'lblncli
        '
        Me.lblncli.Location = New System.Drawing.Point(130, 3)
        Me.lblncli.MaxLength = 50
        Me.lblncli.Name = "lblncli"
        Me.lblncli.Size = New System.Drawing.Size(106, 21)
        Me.lblncli.TabIndex = 58
        '
        'btnlimpiar
        '
        Me.btnlimpiar.Location = New System.Drawing.Point(211, 245)
        Me.btnlimpiar.Name = "btnlimpiar"
        Me.btnlimpiar.Size = New System.Drawing.Size(26, 20)
        Me.btnlimpiar.TabIndex = 66
        Me.btnlimpiar.Text = "..."
        '
        'lblleidos
        '
        Me.lblleidos.Location = New System.Drawing.Point(173, 248)
        Me.lblleidos.Name = "lblleidos"
        Me.lblleidos.Size = New System.Drawing.Size(35, 16)
        Me.lblleidos.Text = "0"
        Me.lblleidos.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(118, 248)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 16)
        Me.Label5.Text = "LEIDOS :   "
        '
        'ULTIMO
        '
        Me.ULTIMO.Location = New System.Drawing.Point(54, 248)
        Me.ULTIMO.Name = "ULTIMO"
        Me.ULTIMO.Size = New System.Drawing.Size(61, 17)
        Me.ULTIMO.Text = "0000000"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(1, 248)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 17)
        Me.Label4.Text = "ULTIMO:"
        '
        'FrmInventario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.btnlimpiar)
        Me.Controls.Add(Me.lblleidos)
        Me.Controls.Add(Me.ULTIMO)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblncli)
        Me.Controls.Add(Me.cancelar)
        Me.Controls.Add(Me.main)
        Me.Controls.Add(Me.Txtpallet)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.KeyPreview = True
        Me.Menu = Me.mainMenu1
        Me.Name = "FrmInventario"
        Me.Text = "Inventario"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.main.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txtpallet As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tca As System.Windows.Forms.TextBox
    Friend WithEvents tba As System.Windows.Forms.TextBox
    Friend WithEvents tco As System.Windows.Forms.TextBox
    Friend WithEvents tpi As System.Windows.Forms.TextBox
    Friend WithEvents tni As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cli_sin As System.Windows.Forms.RadioButton
    Friend WithEvents cli_no As System.Windows.Forms.RadioButton
    Friend WithEvents cli_si As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblestado As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents traq As System.Windows.Forms.Label
    Friend WithEvents lblcliente As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents rev As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblprod As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents pro_no As System.Windows.Forms.RadioButton
    Friend WithEvents pro_si As System.Windows.Forms.RadioButton
    Friend WithEvents pro_sin As System.Windows.Forms.RadioButton
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblcant As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cant_no As System.Windows.Forms.RadioButton
    Friend WithEvents cant_si As System.Windows.Forms.RadioButton
    Friend WithEvents cant_sin As System.Windows.Forms.RadioButton
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents main As System.Windows.Forms.Panel
    Friend WithEvents cancelar As System.Windows.Forms.Button
    Friend WithEvents lblncli As System.Windows.Forms.TextBox
    Friend WithEvents btnlimpiar As System.Windows.Forms.Button
    Friend WithEvents lblleidos As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ULTIMO As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
End Class
