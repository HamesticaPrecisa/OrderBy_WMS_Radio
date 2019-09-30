<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frm_BuscarGuia
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btn_ok = New System.Windows.Forms.Button
        Me.Btn_salir = New System.Windows.Forms.Button
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.Titulo = New System.Windows.Forms.DataGridTableStyle
        Me.txtbusca = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.SuspendLayout()
        '
        'btn_ok
        '
        Me.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btn_ok.Location = New System.Drawing.Point(3, 270)
        Me.btn_ok.Name = "btn_ok"
        Me.btn_ok.Size = New System.Drawing.Size(117, 20)
        Me.btn_ok.TabIndex = 10
        Me.btn_ok.Text = "Seleccionar"
        Me.btn_ok.Visible = False
        '
        'Btn_salir
        '
        Me.Btn_salir.Location = New System.Drawing.Point(165, 270)
        Me.Btn_salir.Name = "Btn_salir"
        Me.Btn_salir.Size = New System.Drawing.Size(72, 20)
        Me.Btn_salir.TabIndex = 9
        Me.Btn_salir.Text = "Volver"
        '
        'DataGrid1
        '
        Me.DataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DataGrid1.Location = New System.Drawing.Point(3, 35)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(234, 229)
        Me.DataGrid1.TabIndex = 8
        Me.DataGrid1.TableStyles.Add(Me.Titulo)
        '
        'Titulo
        '
        Me.Titulo.GridColumnStyles.Add(Me.DataGridTextBoxColumn1)
        Me.Titulo.GridColumnStyles.Add(Me.DataGridTextBoxColumn2)
        '
        'txtbusca
        '
        Me.txtbusca.Location = New System.Drawing.Point(60, 8)
        Me.txtbusca.Name = "txtbusca"
        Me.txtbusca.Size = New System.Drawing.Size(174, 25)
        Me.txtbusca.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 20)
        Me.Label1.Text = "Buscar"
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "No Guia"
        Me.DataGridTextBoxColumn1.MappingName = "frec_guiades"
        Me.DataGridTextBoxColumn1.Width = 100
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Cliente"
        Me.DataGridTextBoxColumn2.MappingName = "cli_nomb"
        Me.DataGridTextBoxColumn2.Width = 250
        '
        'frm_BuscarGuia
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
        Me.Name = "frm_BuscarGuia"
        Me.Text = "Guias"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_ok As System.Windows.Forms.Button
    Friend WithEvents Btn_salir As System.Windows.Forms.Button
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents Titulo As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents txtbusca As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
End Class
