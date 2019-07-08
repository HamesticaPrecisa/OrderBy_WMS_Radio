<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Frm_buscaClienteParaAND
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

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar con el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtbusca = New System.Windows.Forms.TextBox
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.Btn_salir = New System.Windows.Forms.Button
        Me.btn_ok = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 20)
        Me.Label1.Text = "Buscar"
        '
        'txtbusca
        '
        Me.txtbusca.Location = New System.Drawing.Point(49, 9)
        Me.txtbusca.Name = "txtbusca"
        Me.txtbusca.Size = New System.Drawing.Size(185, 21)
        Me.txtbusca.TabIndex = 1
        '
        'DataGrid1
        '
        Me.DataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DataGrid1.Location = New System.Drawing.Point(3, 36)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(234, 229)
        Me.DataGrid1.TabIndex = 2
        '
        'Btn_salir
        '
        Me.Btn_salir.Location = New System.Drawing.Point(162, 267)
        Me.Btn_salir.Name = "Btn_salir"
        Me.Btn_salir.Size = New System.Drawing.Size(72, 20)
        Me.Btn_salir.TabIndex = 3
        Me.Btn_salir.Text = "Volver"
        '
        'btn_ok
        '
        Me.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btn_ok.Location = New System.Drawing.Point(3, 267)
        Me.btn_ok.Name = "btn_ok"
        Me.btn_ok.Size = New System.Drawing.Size(79, 20)
        Me.btn_ok.TabIndex = 5
        Me.btn_ok.Text = "Seleccionar"
        Me.btn_ok.Visible = False
        '
        'Frm_buscaClienteParaAND
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.btn_ok)
        Me.Controls.Add(Me.Btn_salir)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.txtbusca)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Frm_buscaClienteParaAND"
        Me.Text = "Frm_buscaCliente"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtbusca As System.Windows.Forms.TextBox
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents Btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_ok As System.Windows.Forms.Button
End Class
