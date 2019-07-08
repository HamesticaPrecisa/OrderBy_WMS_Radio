<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Frm_trazabilidad
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
        Me.txtpallet = New System.Windows.Forms.TextBox
        Me.Posicionar = New System.Windows.Forms.Label
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.grilla = New System.Windows.Forms.DataGrid
        Me.FilaPrincipal = New System.Windows.Forms.DataGridTableStyle
        Me.Persona = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Camara = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Banda = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Columna = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Piso = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Nivel = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Fecha = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Hora = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnLiberar = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtpallet
        '
        Me.txtpallet.Location = New System.Drawing.Point(42, 11)
        Me.txtpallet.Name = "txtpallet"
        Me.txtpallet.Size = New System.Drawing.Size(163, 21)
        Me.txtpallet.TabIndex = 7
        '
        'Posicionar
        '
        Me.Posicionar.BackColor = System.Drawing.Color.Silver
        Me.Posicionar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Posicionar.Location = New System.Drawing.Point(2, 14)
        Me.Posicionar.Name = "Posicionar"
        Me.Posicionar.Size = New System.Drawing.Size(56, 15)
        Me.Posicionar.Text = "Pallet"
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Silver
        Me.PictureBox4.Location = New System.Drawing.Point(1, 7)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(236, 30)
        '
        'grilla
        '
        Me.grilla.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.grilla.Location = New System.Drawing.Point(2, 60)
        Me.grilla.Name = "grilla"
        Me.grilla.Size = New System.Drawing.Size(235, 143)
        Me.grilla.TabIndex = 10
        Me.grilla.TableStyles.Add(Me.FilaPrincipal)
        Me.grilla.Visible = False
        '
        'FilaPrincipal
        '
        Me.FilaPrincipal.GridColumnStyles.Add(Me.Persona)
        Me.FilaPrincipal.GridColumnStyles.Add(Me.Camara)
        Me.FilaPrincipal.GridColumnStyles.Add(Me.Banda)
        Me.FilaPrincipal.GridColumnStyles.Add(Me.Columna)
        Me.FilaPrincipal.GridColumnStyles.Add(Me.Piso)
        Me.FilaPrincipal.GridColumnStyles.Add(Me.Nivel)
        Me.FilaPrincipal.GridColumnStyles.Add(Me.Fecha)
        Me.FilaPrincipal.GridColumnStyles.Add(Me.Hora)
        '
        'Persona
        '
        Me.Persona.Format = ""
        Me.Persona.FormatInfo = Nothing
        Me.Persona.HeaderText = "Persona"
        Me.Persona.MappingName = "descri"
        Me.Persona.Width = 100
        '
        'Camara
        '
        Me.Camara.Format = ""
        Me.Camara.FormatInfo = Nothing
        Me.Camara.HeaderText = "Camara"
        Me.Camara.MappingName = "mov_ca"
        '
        'Banda
        '
        Me.Banda.Format = ""
        Me.Banda.FormatInfo = Nothing
        Me.Banda.HeaderText = "Banda"
        Me.Banda.MappingName = "mov_ba"
        '
        'Columna
        '
        Me.Columna.Format = ""
        Me.Columna.FormatInfo = Nothing
        Me.Columna.HeaderText = "Columna"
        Me.Columna.MappingName = "mov_co"
        '
        'Piso
        '
        Me.Piso.Format = ""
        Me.Piso.FormatInfo = Nothing
        Me.Piso.HeaderText = "Piso"
        Me.Piso.MappingName = "mov_pi"
        '
        'Nivel
        '
        Me.Nivel.Format = ""
        Me.Nivel.FormatInfo = Nothing
        Me.Nivel.HeaderText = "Nivel"
        Me.Nivel.MappingName = "mov_ni"
        '
        'Fecha
        '
        Me.Fecha.Format = ""
        Me.Fecha.FormatInfo = Nothing
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.MappingName = "mov_fecha"
        '
        'Hora
        '
        Me.Hora.Format = ""
        Me.Hora.FormatInfo = Nothing
        Me.Hora.HeaderText = "Hora"
        Me.Hora.MappingName = "mov_hora"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(229, 20)
        Me.Label1.Text = "Nota:"
        '
        'BtnLiberar
        '
        Me.BtnLiberar.Location = New System.Drawing.Point(207, 11)
        Me.BtnLiberar.Name = "BtnLiberar"
        Me.BtnLiberar.Size = New System.Drawing.Size(25, 21)
        Me.BtnLiberar.TabIndex = 13
        Me.BtnLiberar.Text = "..."
        '
        'Frm_trazabilidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.BtnLiberar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grilla)
        Me.Controls.Add(Me.txtpallet)
        Me.Controls.Add(Me.Posicionar)
        Me.Controls.Add(Me.PictureBox4)
        Me.Menu = Me.mainMenu1
        Me.Name = "Frm_trazabilidad"
        Me.Text = "TRAZABILIDAD"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtpallet As System.Windows.Forms.TextBox
    Friend WithEvents Posicionar As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents grilla As System.Windows.Forms.DataGrid
    Friend WithEvents FilaPrincipal As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents Persona As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Camara As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Banda As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Columna As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Piso As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Nivel As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Hora As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnLiberar As System.Windows.Forms.Button
End Class
