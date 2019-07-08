<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Frm_Columna
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
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.BtnLiberar = New System.Windows.Forms.Button
        Me.Posicionar = New System.Windows.Forms.Label
        Me.grilla = New System.Windows.Forms.DataGrid
        Me.FilaPrincipal = New System.Windows.Forms.DataGridTableStyle
        Me.txtposicion = New System.Windows.Forms.TextBox
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.SuspendLayout()
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Silver
        Me.PictureBox4.Location = New System.Drawing.Point(2, 3)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(236, 44)
        '
        'BtnLiberar
        '
        Me.BtnLiberar.Location = New System.Drawing.Point(210, 14)
        Me.BtnLiberar.Name = "BtnLiberar"
        Me.BtnLiberar.Size = New System.Drawing.Size(25, 21)
        Me.BtnLiberar.TabIndex = 16
        Me.BtnLiberar.Text = "..."
        '
        'Posicionar
        '
        Me.Posicionar.BackColor = System.Drawing.Color.Silver
        Me.Posicionar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Posicionar.Location = New System.Drawing.Point(5, 17)
        Me.Posicionar.Name = "Posicionar"
        Me.Posicionar.Size = New System.Drawing.Size(77, 15)
        Me.Posicionar.Text = "POSICIÓN"
        '
        'grilla
        '
        Me.grilla.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.grilla.Location = New System.Drawing.Point(5, 53)
        Me.grilla.Name = "grilla"
        Me.grilla.Size = New System.Drawing.Size(232, 212)
        Me.grilla.TabIndex = 18
        Me.grilla.TableStyles.Add(Me.FilaPrincipal)
        Me.grilla.Visible = False
        '
        'FilaPrincipal
        '
        Me.FilaPrincipal.GridColumnStyles.Add(Me.DataGridTextBoxColumn1)
        Me.FilaPrincipal.GridColumnStyles.Add(Me.DataGridTextBoxColumn2)
        Me.FilaPrincipal.GridColumnStyles.Add(Me.DataGridTextBoxColumn3)
        Me.FilaPrincipal.GridColumnStyles.Add(Me.DataGridTextBoxColumn4)
        Me.FilaPrincipal.GridColumnStyles.Add(Me.DataGridTextBoxColumn5)
        Me.FilaPrincipal.GridColumnStyles.Add(Me.DataGridTextBoxColumn6)
        '
        'txtposicion
        '
        Me.txtposicion.Location = New System.Drawing.Point(77, 14)
        Me.txtposicion.Name = "txtposicion"
        Me.txtposicion.Size = New System.Drawing.Size(127, 21)
        Me.txtposicion.TabIndex = 15
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "Pallet"
        Me.DataGridTextBoxColumn1.MappingName = "Pallet"
        Me.DataGridTextBoxColumn1.Width = 80
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Camara"
        Me.DataGridTextBoxColumn2.MappingName = "Camara"
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "Banda"
        Me.DataGridTextBoxColumn3.MappingName = "Banda"
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "Columna"
        Me.DataGridTextBoxColumn4.MappingName = "Columna"
        Me.DataGridTextBoxColumn4.Width = 60
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "Piso"
        Me.DataGridTextBoxColumn5.MappingName = "Piso"
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "Nivel"
        Me.DataGridTextBoxColumn6.MappingName = "Nivel"
        '
        'Frm_Columna
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.grilla)
        Me.Controls.Add(Me.BtnLiberar)
        Me.Controls.Add(Me.txtposicion)
        Me.Controls.Add(Me.Posicionar)
        Me.Controls.Add(Me.PictureBox4)
        Me.Menu = Me.mainMenu1
        Me.Name = "Frm_Columna"
        Me.Text = "COLUMNA POS"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnLiberar As System.Windows.Forms.Button
    Friend WithEvents Posicionar As System.Windows.Forms.Label
    Friend WithEvents grilla As System.Windows.Forms.DataGrid
    Friend WithEvents FilaPrincipal As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents txtposicion As System.Windows.Forms.TextBox
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
End Class
