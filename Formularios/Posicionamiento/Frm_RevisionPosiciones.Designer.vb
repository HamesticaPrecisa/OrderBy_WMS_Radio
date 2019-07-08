<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Frm_RevisionPosiciones
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
        Me.txtposicion = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.txtcolumna = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtbanda = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtcamara = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.DataGridDatos = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.SuspendLayout()
        '
        'txtposicion
        '
        Me.txtposicion.Location = New System.Drawing.Point(65, 7)
        Me.txtposicion.MaxLength = 13
        Me.txtposicion.Name = "txtposicion"
        Me.txtposicion.Size = New System.Drawing.Size(171, 21)
        Me.txtposicion.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Silver
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(3, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 20)
        Me.Label7.Text = "Posición"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Silver
        Me.PictureBox1.Location = New System.Drawing.Point(2, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(237, 31)
        '
        'txtcolumna
        '
        Me.txtcolumna.Enabled = False
        Me.txtcolumna.Location = New System.Drawing.Point(207, 39)
        Me.txtcolumna.MaxLength = 2
        Me.txtcolumna.Name = "txtcolumna"
        Me.txtcolumna.Size = New System.Drawing.Size(29, 21)
        Me.txtcolumna.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Silver
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(154, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 18)
        Me.Label4.Text = "Columna"
        '
        'txtbanda
        '
        Me.txtbanda.Enabled = False
        Me.txtbanda.Location = New System.Drawing.Point(122, 39)
        Me.txtbanda.MaxLength = 2
        Me.txtbanda.Name = "txtbanda"
        Me.txtbanda.Size = New System.Drawing.Size(29, 21)
        Me.txtbanda.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Silver
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(83, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 18)
        Me.Label3.Text = "Banda"
        '
        'txtcamara
        '
        Me.txtcamara.Enabled = False
        Me.txtcamara.Location = New System.Drawing.Point(53, 39)
        Me.txtcamara.MaxLength = 2
        Me.txtcamara.Name = "txtcamara"
        Me.txtcamara.Size = New System.Drawing.Size(29, 21)
        Me.txtcamara.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Silver
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(3, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 18)
        Me.Label2.Text = "Cámara"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Silver
        Me.PictureBox2.Location = New System.Drawing.Point(2, 34)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(237, 31)
        '
        'DataGridDatos
        '
        Me.DataGridDatos.BackgroundColor = System.Drawing.Color.White
        Me.DataGridDatos.Location = New System.Drawing.Point(0, 66)
        Me.DataGridDatos.Name = "DataGridDatos"
        Me.DataGridDatos.RowHeadersVisible = False
        Me.DataGridDatos.Size = New System.Drawing.Size(240, 200)
        Me.DataGridDatos.TabIndex = 49
        Me.DataGridDatos.TableStyles.Add(Me.DataGridTableStyle1)
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.GridColumnStyles.Add(Me.DataGridTextBoxColumn1)
        Me.DataGridTableStyle1.GridColumnStyles.Add(Me.DataGridTextBoxColumn2)
        Me.DataGridTableStyle1.GridColumnStyles.Add(Me.DataGridTextBoxColumn3)
        Me.DataGridTableStyle1.GridColumnStyles.Add(Me.DataGridTextBoxColumn4)
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "Pallet"
        Me.DataGridTextBoxColumn1.MappingName = "racd_codi"
        Me.DataGridTextBoxColumn1.Width = 60
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Piso"
        Me.DataGridTextBoxColumn2.MappingName = "racd_pi"
        Me.DataGridTextBoxColumn2.Width = 30
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "Nivel"
        Me.DataGridTextBoxColumn3.MappingName = "racd_ni"
        Me.DataGridTextBoxColumn3.Width = 30
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "Cliente"
        Me.DataGridTextBoxColumn4.MappingName = "cli_nomb"
        Me.DataGridTextBoxColumn4.Width = 150
        '
        'Frm_RevisionPosiciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.DataGridDatos)
        Me.Controls.Add(Me.txtcolumna)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtbanda)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtcamara)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.txtposicion)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.PictureBox1)
        Me.Menu = Me.mainMenu1
        Me.Name = "Frm_RevisionPosiciones"
        Me.Text = "Revisión Posiciones"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtposicion As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtcolumna As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtbanda As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtcamara As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents DataGridDatos As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
End Class
