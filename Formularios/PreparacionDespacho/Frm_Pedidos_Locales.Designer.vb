<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Frm_Pedidos_Locales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Pedidos_Locales))
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.dgPedPen = New System.Windows.Forms.DataGrid
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtFecIni = New System.Windows.Forms.DateTimePicker
        Me.txtFecFin = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnFil = New System.Windows.Forms.Button
        Me.btnLim = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtRut = New System.Windows.Forms.TextBox
        Me.btnBusCli = New System.Windows.Forms.PictureBox
        Me.txtCli = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnSal = New System.Windows.Forms.Button
        Me.btnVol = New System.Windows.Forms.Button
        Me.btnCons = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'dgPedPen
        '
        Me.dgPedPen.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.dgPedPen.Location = New System.Drawing.Point(3, 156)
        Me.dgPedPen.Name = "dgPedPen"
        Me.dgPedPen.Size = New System.Drawing.Size(272, 132)
        Me.dgPedPen.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(10, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 20)
        Me.Label3.Text = "Desde"
        '
        'txtFecIni
        '
        Me.txtFecIni.CustomFormat = "dd/mm/yyyy"
        Me.txtFecIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFecIni.Location = New System.Drawing.Point(73, 66)
        Me.txtFecIni.Name = "txtFecIni"
        Me.txtFecIni.Size = New System.Drawing.Size(90, 22)
        Me.txtFecIni.TabIndex = 0
        Me.txtFecIni.Value = New Date(2018, 11, 26, 15, 50, 12, 0)
        '
        'txtFecFin
        '
        Me.txtFecFin.CustomFormat = "dd/mm/yyyy"
        Me.txtFecFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFecFin.Location = New System.Drawing.Point(73, 94)
        Me.txtFecFin.Name = "txtFecFin"
        Me.txtFecFin.Size = New System.Drawing.Size(90, 22)
        Me.txtFecFin.TabIndex = 1
        Me.txtFecFin.Value = New Date(2018, 11, 26, 15, 50, 12, 0)
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(10, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 20)
        Me.Label4.Text = "Hasta"
        '
        'btnFil
        '
        Me.btnFil.Location = New System.Drawing.Point(28, 130)
        Me.btnFil.Name = "btnFil"
        Me.btnFil.Size = New System.Drawing.Size(53, 20)
        Me.btnFil.TabIndex = 2
        Me.btnFil.Text = "Filtrar"
        '
        'btnLim
        '
        Me.btnLim.Location = New System.Drawing.Point(87, 130)
        Me.btnLim.Name = "btnLim"
        Me.btnLim.Size = New System.Drawing.Size(53, 20)
        Me.btnLim.TabIndex = 3
        Me.btnLim.Text = "Limpiar"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(10, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 20)
        Me.Label1.Text = "Rut"
        '
        'txtRut
        '
        Me.txtRut.Location = New System.Drawing.Point(73, 12)
        Me.txtRut.Name = "txtRut"
        Me.txtRut.Size = New System.Drawing.Size(104, 21)
        Me.txtRut.TabIndex = 0
        '
        'btnBusCli
        '
        Me.btnBusCli.Image = CType(resources.GetObject("btnBusCli.Image"), System.Drawing.Image)
        Me.btnBusCli.Location = New System.Drawing.Point(183, 12)
        Me.btnBusCli.Name = "btnBusCli"
        Me.btnBusCli.Size = New System.Drawing.Size(25, 21)
        Me.btnBusCli.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'txtCli
        '
        Me.txtCli.Location = New System.Drawing.Point(73, 39)
        Me.txtCli.Name = "txtCli"
        Me.txtCli.ReadOnly = True
        Me.txtCli.Size = New System.Drawing.Size(135, 21)
        Me.txtCli.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(10, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 20)
        Me.Label2.Text = "Cliente"
        '
        'btnSal
        '
        Me.btnSal.Location = New System.Drawing.Point(146, 130)
        Me.btnSal.Name = "btnSal"
        Me.btnSal.Size = New System.Drawing.Size(53, 20)
        Me.btnSal.TabIndex = 6
        Me.btnSal.Text = "Salir"
        '
        'btnVol
        '
        Me.btnVol.Location = New System.Drawing.Point(87, 294)
        Me.btnVol.Name = "btnVol"
        Me.btnVol.Size = New System.Drawing.Size(72, 20)
        Me.btnVol.TabIndex = 30
        Me.btnVol.Text = "Volver"
        '
        'btnCons
        '
        Me.btnCons.Location = New System.Drawing.Point(3, 294)
        Me.btnCons.Name = "btnCons"
        Me.btnCons.Size = New System.Drawing.Size(78, 20)
        Me.btnCons.TabIndex = 36
        Me.btnCons.Text = "Consolidar"
        '
        'Frm_Pedidos_Locales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.btnCons)
        Me.Controls.Add(Me.btnVol)
        Me.Controls.Add(Me.btnSal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCli)
        Me.Controls.Add(Me.btnBusCli)
        Me.Controls.Add(Me.txtRut)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnLim)
        Me.Controls.Add(Me.btnFil)
        Me.Controls.Add(Me.txtFecFin)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtFecIni)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dgPedPen)
        Me.Menu = Me.mainMenu1
        Me.Name = "Frm_Pedidos_Locales"
        Me.Text = "Pedidos Locales"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgPedPen As System.Windows.Forms.DataGrid
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFecIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtFecFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnFil As System.Windows.Forms.Button
    Friend WithEvents btnLim As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRut As System.Windows.Forms.TextBox
    Friend WithEvents btnBusCli As System.Windows.Forms.PictureBox
    Friend WithEvents txtCli As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSal As System.Windows.Forms.Button
    Friend WithEvents btnVol As System.Windows.Forms.Button
    Friend WithEvents btnCons As System.Windows.Forms.Button
End Class
