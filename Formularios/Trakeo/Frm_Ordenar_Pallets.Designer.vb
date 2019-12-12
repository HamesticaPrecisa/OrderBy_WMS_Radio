<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Frm_Ordenar_Pallets
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
        Me.TxtClirut = New System.Windows.Forms.TextBox
        Me.Label43 = New System.Windows.Forms.Label
        Me.btn_BuscaCliente = New System.Windows.Forms.Button
        Me.txtclinom = New System.Windows.Forms.TextBox
        Me.txtCodCaj = New System.Windows.Forms.TextBox
        Me.Label49 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnLim = New System.Windows.Forms.Button
        Me.btnNueCaj = New System.Windows.Forms.Button
        Me.btnSal = New System.Windows.Forms.Button
        Me.txtCodPal = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'TxtClirut
        '
        Me.TxtClirut.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Bold)
        Me.TxtClirut.Location = New System.Drawing.Point(76, 20)
        Me.TxtClirut.MaxLength = 8
        Me.TxtClirut.Name = "TxtClirut"
        Me.TxtClirut.Size = New System.Drawing.Size(10, 16)
        Me.TxtClirut.TabIndex = 96
        Me.TxtClirut.Visible = False
        '
        'Label43
        '
        Me.Label43.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Bold)
        Me.Label43.Location = New System.Drawing.Point(9, 23)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(61, 21)
        Me.Label43.Text = "CLIENTE"
        '
        'btn_BuscaCliente
        '
        Me.btn_BuscaCliente.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.btn_BuscaCliente.Location = New System.Drawing.Point(87, 20)
        Me.btn_BuscaCliente.Name = "btn_BuscaCliente"
        Me.btn_BuscaCliente.Size = New System.Drawing.Size(19, 19)
        Me.btn_BuscaCliente.TabIndex = 94
        '
        'txtclinom
        '
        Me.txtclinom.Enabled = False
        Me.txtclinom.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Bold)
        Me.txtclinom.Location = New System.Drawing.Point(112, 21)
        Me.txtclinom.Name = "txtclinom"
        Me.txtclinom.Size = New System.Drawing.Size(103, 16)
        Me.txtclinom.TabIndex = 95
        '
        'txtCodCaj
        '
        Me.txtCodCaj.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Bold)
        Me.txtCodCaj.Location = New System.Drawing.Point(87, 45)
        Me.txtCodCaj.MaxLength = 200
        Me.txtCodCaj.Name = "txtCodCaj"
        Me.txtCodCaj.Size = New System.Drawing.Size(128, 16)
        Me.txtCodCaj.TabIndex = 99
        '
        'Label49
        '
        Me.Label49.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Bold)
        Me.Label49.Location = New System.Drawing.Point(9, 47)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(63, 14)
        Me.Label49.Text = "CÓDIGO CAJA"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(9, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 14)
        Me.Label1.Text = "PALLET CLIENTE"
        '
        'btnLim
        '
        Me.btnLim.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Bold)
        Me.btnLim.Location = New System.Drawing.Point(78, 102)
        Me.btnLim.Name = "btnLim"
        Me.btnLim.Size = New System.Drawing.Size(63, 22)
        Me.btnLim.TabIndex = 163
        Me.btnLim.Text = "Limpiar"
        '
        'btnNueCaj
        '
        Me.btnNueCaj.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Bold)
        Me.btnNueCaj.Location = New System.Drawing.Point(9, 102)
        Me.btnNueCaj.Name = "btnNueCaj"
        Me.btnNueCaj.Size = New System.Drawing.Size(63, 22)
        Me.btnNueCaj.TabIndex = 164
        Me.btnNueCaj.Text = "Nueva Caja"
        '
        'btnSal
        '
        Me.btnSal.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Bold)
        Me.btnSal.Location = New System.Drawing.Point(147, 102)
        Me.btnSal.Name = "btnSal"
        Me.btnSal.Size = New System.Drawing.Size(63, 22)
        Me.btnSal.TabIndex = 168
        Me.btnSal.Text = "Salir"
        '
        'txtCodPal
        '
        Me.txtCodPal.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtCodPal.Location = New System.Drawing.Point(87, 69)
        Me.txtCodPal.Name = "txtCodPal"
        Me.txtCodPal.Size = New System.Drawing.Size(128, 30)
        '
        'Frm_Ordenar_Pallets
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.txtCodPal)
        Me.Controls.Add(Me.btnSal)
        Me.Controls.Add(Me.btnNueCaj)
        Me.Controls.Add(Me.btnLim)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCodCaj)
        Me.Controls.Add(Me.Label49)
        Me.Controls.Add(Me.TxtClirut)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.btn_BuscaCliente)
        Me.Controls.Add(Me.txtclinom)
        Me.Menu = Me.mainMenu1
        Me.Name = "Frm_Ordenar_Pallets"
        Me.Text = "Ordenar Pallets"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TxtClirut As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents btn_BuscaCliente As System.Windows.Forms.Button
    Friend WithEvents txtclinom As System.Windows.Forms.TextBox
    Friend WithEvents txtCodCaj As System.Windows.Forms.TextBox
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnLim As System.Windows.Forms.Button
    Friend WithEvents btnNueCaj As System.Windows.Forms.Button
    Friend WithEvents btnSal As System.Windows.Forms.Button
    Friend WithEvents txtCodPal As System.Windows.Forms.Label
End Class
