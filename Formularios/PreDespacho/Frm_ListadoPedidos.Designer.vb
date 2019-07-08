<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Frm_ListadoPedidos
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
        Me.DgvPedidos = New System.Windows.Forms.DataGrid
        Me.Titulo = New System.Windows.Forms.DataGridTableStyle
        Me.CODIGO = New System.Windows.Forms.DataGridTextBoxColumn
        Me.PEDIDO = New System.Windows.Forms.DataGridTextBoxColumn
        Me.FECHA = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.ORDENCONJUNTA = New System.Windows.Forms.DataGridTextBoxColumn
        Me.SuspendLayout()
        '
        'DgvPedidos
        '
        Me.DgvPedidos.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DgvPedidos.Location = New System.Drawing.Point(3, 23)
        Me.DgvPedidos.Name = "DgvPedidos"
        Me.DgvPedidos.Size = New System.Drawing.Size(234, 212)
        Me.DgvPedidos.TabIndex = 3
        Me.DgvPedidos.TableStyles.Add(Me.Titulo)
        '
        'Titulo
        '
        Me.Titulo.GridColumnStyles.Add(Me.CODIGO)
        Me.Titulo.GridColumnStyles.Add(Me.PEDIDO)
        Me.Titulo.GridColumnStyles.Add(Me.FECHA)
        Me.Titulo.GridColumnStyles.Add(Me.ORDENCONJUNTA)
        '
        'CODIGO
        '
        Me.CODIGO.Format = ""
        Me.CODIGO.FormatInfo = Nothing
        Me.CODIGO.HeaderText = "CODIGO"
        Me.CODIGO.MappingName = "orden"
        Me.CODIGO.Width = 60
        '
        'PEDIDO
        '
        Me.PEDIDO.Format = ""
        Me.PEDIDO.FormatInfo = Nothing
        Me.PEDIDO.HeaderText = "PEDIDO"
        Me.PEDIDO.MappingName = "pedido"
        Me.PEDIDO.Width = 60
        '
        'FECHA
        '
        Me.FECHA.Format = ""
        Me.FECHA.FormatInfo = Nothing
        Me.FECHA.HeaderText = "FECHA"
        Me.FECHA.MappingName = "fecha"
        Me.FECHA.Width = 60
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(5, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(156, 20)
        Me.Label1.Text = "LISTADO DE PEDIDOS"
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button1.Location = New System.Drawing.Point(3, 241)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(65, 19)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "ACEPTAR"
        Me.Button1.Visible = False
        '
        'ORDENCONJUNTA
        '
        Me.ORDENCONJUNTA.Format = ""
        Me.ORDENCONJUNTA.FormatInfo = Nothing
        Me.ORDENCONJUNTA.HeaderText = "ORDEN CONJUNTA"
        Me.ORDENCONJUNTA.MappingName = "ordenconjunta"
        Me.ORDENCONJUNTA.Width = 120
        '
        'Frm_ListadoPedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DgvPedidos)
        Me.Controls.Add(Me.Label1)
        Me.Menu = Me.mainMenu1
        Me.Name = "Frm_ListadoPedidos"
        Me.Text = "Pedidos"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DgvPedidos As System.Windows.Forms.DataGrid
    Friend WithEvents Titulo As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CODIGO As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents PEDIDO As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents FECHA As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents ORDENCONJUNTA As System.Windows.Forms.DataGridTextBoxColumn
End Class
