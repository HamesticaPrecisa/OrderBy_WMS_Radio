<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Frm_Pedidos_Locales_Detalle_Local
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
        Me.lblFecPed = New System.Windows.Forms.Label
        Me.lblOrden = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblCli = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.dgDetLoc = New System.Windows.Forms.DataGrid
        Me.lblRut = New System.Windows.Forms.Label
        Me.btnVol = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 19)
        Me.Label1.Text = "Fecha:"
        '
        'lblFecPed
        '
        Me.lblFecPed.Location = New System.Drawing.Point(75, 10)
        Me.lblFecPed.Name = "lblFecPed"
        Me.lblFecPed.Size = New System.Drawing.Size(100, 19)
        Me.lblFecPed.Text = "..."
        '
        'lblOrden
        '
        Me.lblOrden.Location = New System.Drawing.Point(75, 29)
        Me.lblOrden.Name = "lblOrden"
        Me.lblOrden.Size = New System.Drawing.Size(100, 19)
        Me.lblOrden.Text = "..."
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(3, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 19)
        Me.Label4.Text = "Pedido:"
        '
        'lblCli
        '
        Me.lblCli.Location = New System.Drawing.Point(75, 48)
        Me.lblCli.Name = "lblCli"
        Me.lblCli.Size = New System.Drawing.Size(149, 40)
        Me.lblCli.Text = "..."
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(3, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 19)
        Me.Label6.Text = "Cliente:"
        '
        'dgDetLoc
        '
        Me.dgDetLoc.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.dgDetLoc.Location = New System.Drawing.Point(3, 91)
        Me.dgDetLoc.Name = "dgDetLoc"
        Me.dgDetLoc.Size = New System.Drawing.Size(221, 147)
        Me.dgDetLoc.TabIndex = 11
        '
        'lblRut
        '
        Me.lblRut.Location = New System.Drawing.Point(181, 10)
        Me.lblRut.Name = "lblRut"
        Me.lblRut.Size = New System.Drawing.Size(43, 19)
        Me.lblRut.Text = "..."
        Me.lblRut.Visible = False
        '
        'btnVol
        '
        Me.btnVol.Location = New System.Drawing.Point(3, 244)
        Me.btnVol.Name = "btnVol"
        Me.btnVol.Size = New System.Drawing.Size(72, 20)
        Me.btnVol.TabIndex = 29
        Me.btnVol.Text = "Volver"
        '
        'Frm_Pedidos_Locales_Detalle_Local
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.btnVol)
        Me.Controls.Add(Me.lblRut)
        Me.Controls.Add(Me.dgDetLoc)
        Me.Controls.Add(Me.lblCli)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblOrden)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblFecPed)
        Me.Controls.Add(Me.Label1)
        Me.Menu = Me.mainMenu1
        Me.Name = "Frm_Pedidos_Locales_Detalle_Local"
        Me.Text = "Detalle Locales"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblFecPed As System.Windows.Forms.Label
    Friend WithEvents lblOrden As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblCli As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dgDetLoc As System.Windows.Forms.DataGrid
    Friend WithEvents lblRut As System.Windows.Forms.Label
    Friend WithEvents btnVol As System.Windows.Forms.Button
End Class
