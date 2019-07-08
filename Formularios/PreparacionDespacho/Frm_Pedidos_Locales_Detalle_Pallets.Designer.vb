<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Frm_Pedidos_Locales_Detalle_Pallets
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
        Me.lblIdLoc = New System.Windows.Forms.Label
        Me.lblCli = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblOrden = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblFecPed = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblLoc = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.dgDetPals = New System.Windows.Forms.DataGrid
        Me.btnVol = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lblIdLoc
        '
        Me.lblIdLoc.Location = New System.Drawing.Point(181, 9)
        Me.lblIdLoc.Name = "lblIdLoc"
        Me.lblIdLoc.Size = New System.Drawing.Size(43, 19)
        Me.lblIdLoc.Text = "..."
        Me.lblIdLoc.Visible = False
        '
        'lblCli
        '
        Me.lblCli.Location = New System.Drawing.Point(75, 66)
        Me.lblCli.Name = "lblCli"
        Me.lblCli.Size = New System.Drawing.Size(149, 40)
        Me.lblCli.Text = "..."
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(3, 66)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 19)
        Me.Label6.Text = "Cliente:"
        '
        'lblOrden
        '
        Me.lblOrden.Location = New System.Drawing.Point(75, 28)
        Me.lblOrden.Name = "lblOrden"
        Me.lblOrden.Size = New System.Drawing.Size(100, 19)
        Me.lblOrden.Text = "..."
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(3, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 19)
        Me.Label4.Text = "Pedido:"
        '
        'lblFecPed
        '
        Me.lblFecPed.Location = New System.Drawing.Point(75, 9)
        Me.lblFecPed.Name = "lblFecPed"
        Me.lblFecPed.Size = New System.Drawing.Size(100, 19)
        Me.lblFecPed.Text = "..."
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 19)
        Me.Label1.Text = "Fecha:"
        '
        'lblLoc
        '
        Me.lblLoc.Location = New System.Drawing.Point(75, 47)
        Me.lblLoc.Name = "lblLoc"
        Me.lblLoc.Size = New System.Drawing.Size(100, 19)
        Me.lblLoc.Text = "..."
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(3, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 19)
        Me.Label3.Text = "Local:"
        '
        'dgDetPals
        '
        Me.dgDetPals.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.dgDetPals.Location = New System.Drawing.Point(3, 109)
        Me.dgDetPals.Name = "dgDetPals"
        Me.dgDetPals.Size = New System.Drawing.Size(224, 130)
        Me.dgDetPals.TabIndex = 18
        '
        'btnVol
        '
        Me.btnVol.Location = New System.Drawing.Point(3, 245)
        Me.btnVol.Name = "btnVol"
        Me.btnVol.Size = New System.Drawing.Size(72, 20)
        Me.btnVol.TabIndex = 28
        Me.btnVol.Text = "Volver"
        '
        'Frm_Pedidos_Locales_Detalle_Pallets
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.btnVol)
        Me.Controls.Add(Me.dgDetPals)
        Me.Controls.Add(Me.lblLoc)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblIdLoc)
        Me.Controls.Add(Me.lblCli)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblOrden)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblFecPed)
        Me.Controls.Add(Me.Label1)
        Me.Menu = Me.mainMenu1
        Me.Name = "Frm_Pedidos_Locales_Detalle_Pallets"
        Me.Text = "Detalle Soportantes"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblIdLoc As System.Windows.Forms.Label
    Friend WithEvents lblCli As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblOrden As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblFecPed As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblLoc As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgDetPals As System.Windows.Forms.DataGrid
    Friend WithEvents btnVol As System.Windows.Forms.Button
End Class
