﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Frm_Pedidos_Locales_Pallet_Preparar
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
        Me.lblSop = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtEtiq = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblCan = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtSal = New System.Windows.Forms.TextBox
        Me.lblPos = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblOrd = New System.Windows.Forms.Label
        Me.lblIdLoc = New System.Windows.Forms.Label
        Me.btnVol = New System.Windows.Forms.Button
        Me.txtCajs = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblSop
        '
        Me.lblSop.Location = New System.Drawing.Point(87, 8)
        Me.lblSop.Name = "lblSop"
        Me.lblSop.Size = New System.Drawing.Size(100, 19)
        Me.lblSop.Text = "..."
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 19)
        Me.Label1.Text = "Soportante:"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(3, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(215, 19)
        Me.Label2.Text = "Leer Etiqueta Soportante:"
        '
        'txtEtiq
        '
        Me.txtEtiq.Location = New System.Drawing.Point(3, 122)
        Me.txtEtiq.Name = "txtEtiq"
        Me.txtEtiq.Size = New System.Drawing.Size(215, 21)
        Me.txtEtiq.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(3, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 19)
        Me.Label3.Text = "Retirar:"
        '
        'lblCan
        '
        Me.lblCan.Location = New System.Drawing.Point(87, 81)
        Me.lblCan.Name = "lblCan"
        Me.lblCan.Size = New System.Drawing.Size(58, 19)
        Me.lblCan.Text = "..."
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(3, 178)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 19)
        Me.Label5.Text = "Saldo:"
        '
        'txtSal
        '
        Me.txtSal.Location = New System.Drawing.Point(87, 176)
        Me.txtSal.Name = "txtSal"
        Me.txtSal.Size = New System.Drawing.Size(58, 21)
        Me.txtSal.TabIndex = 2
        '
        'lblPos
        '
        Me.lblPos.Location = New System.Drawing.Point(54, 46)
        Me.lblPos.Name = "lblPos"
        Me.lblPos.Size = New System.Drawing.Size(133, 19)
        Me.lblPos.Text = "..."
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(3, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(215, 19)
        Me.Label6.Text = "Posición (Ca-Ba-Co-Pi-Ni):"
        '
        'lblOrd
        '
        Me.lblOrd.Location = New System.Drawing.Point(193, 8)
        Me.lblOrd.Name = "lblOrd"
        Me.lblOrd.Size = New System.Drawing.Size(43, 19)
        Me.lblOrd.Text = "..."
        Me.lblOrd.Visible = False
        '
        'lblIdLoc
        '
        Me.lblIdLoc.Location = New System.Drawing.Point(193, 27)
        Me.lblIdLoc.Name = "lblIdLoc"
        Me.lblIdLoc.Size = New System.Drawing.Size(43, 19)
        Me.lblIdLoc.Text = "..."
        Me.lblIdLoc.Visible = False
        '
        'btnVol
        '
        Me.btnVol.Location = New System.Drawing.Point(3, 245)
        Me.btnVol.Name = "btnVol"
        Me.btnVol.Size = New System.Drawing.Size(72, 20)
        Me.btnVol.TabIndex = 3
        Me.btnVol.Text = "Volver"
        '
        'txtCajs
        '
        Me.txtCajs.Location = New System.Drawing.Point(87, 149)
        Me.txtCajs.Name = "txtCajs"
        Me.txtCajs.Size = New System.Drawing.Size(58, 21)
        Me.txtCajs.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(3, 151)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 19)
        Me.Label4.Text = "Retiradas:"
        '
        'Frm_Pedidos_Locales_Pallet_Preparar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.txtCajs)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnVol)
        Me.Controls.Add(Me.lblIdLoc)
        Me.Controls.Add(Me.lblOrd)
        Me.Controls.Add(Me.lblPos)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtSal)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblCan)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtEtiq)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblSop)
        Me.Controls.Add(Me.Label1)
        Me.Menu = Me.mainMenu1
        Me.Name = "Frm_Pedidos_Locales_Pallet_Preparar"
        Me.Text = "Picking Soportante"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblSop As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtEtiq As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblCan As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSal As System.Windows.Forms.TextBox
    Friend WithEvents lblPos As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblOrd As System.Windows.Forms.Label
    Friend WithEvents lblIdLoc As System.Windows.Forms.Label
    Friend WithEvents btnVol As System.Windows.Forms.Button
    Friend WithEvents txtCajs As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
