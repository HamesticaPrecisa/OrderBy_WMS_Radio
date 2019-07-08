<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Frm_PedidosPendientes
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
        Dim DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.tbl_pedidos_pendientes = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.SuspendLayout()
        '
        'DataGridTextBoxColumn6
        '
        DataGridTextBoxColumn6.Format = ""
        DataGridTextBoxColumn6.FormatInfo = Nothing
        DataGridTextBoxColumn6.HeaderText = "Soportantes"
        DataGridTextBoxColumn6.MappingName = "Sop"
        DataGridTextBoxColumn6.Width = 70
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.Add(Me.MenuItem1)
        '
        'MenuItem1
        '
        Me.MenuItem1.Text = "Volver"
        '
        'tbl_pedidos_pendientes
        '
        Me.tbl_pedidos_pendientes.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.tbl_pedidos_pendientes.Location = New System.Drawing.Point(0, 0)
        Me.tbl_pedidos_pendientes.Name = "tbl_pedidos_pendientes"
        Me.tbl_pedidos_pendientes.Size = New System.Drawing.Size(517, 336)
        Me.tbl_pedidos_pendientes.TabIndex = 0
        Me.tbl_pedidos_pendientes.TableStyles.Add(Me.DataGridTableStyle1)
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.GridColumnStyles.Add(Me.DataGridTextBoxColumn1)
        Me.DataGridTableStyle1.GridColumnStyles.Add(Me.DataGridTextBoxColumn2)
        Me.DataGridTableStyle1.GridColumnStyles.Add(Me.DataGridTextBoxColumn3)
        Me.DataGridTableStyle1.GridColumnStyles.Add(Me.DataGridTextBoxColumn4)
        Me.DataGridTableStyle1.GridColumnStyles.Add(DataGridTextBoxColumn6)
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "Orden"
        Me.DataGridTextBoxColumn1.MappingName = "Orden"
        Me.DataGridTextBoxColumn1.Width = 38
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Fecha"
        Me.DataGridTextBoxColumn2.MappingName = "fecha"
        Me.DataGridTextBoxColumn2.Width = 70
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "Cliente"
        Me.DataGridTextBoxColumn3.MappingName = "cliente"
        Me.DataGridTextBoxColumn3.Width = 270
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "Hora"
        Me.DataGridTextBoxColumn4.MappingName = "hora"
        '
        'Frm_PedidosPendientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 264)
        Me.Controls.Add(Me.tbl_pedidos_pendientes)
        Me.Menu = Me.mainMenu1
        Me.Name = "Frm_PedidosPendientes"
        Me.Text = "Pedidos Pendientes"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbl_pedidos_pendientes As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
End Class
