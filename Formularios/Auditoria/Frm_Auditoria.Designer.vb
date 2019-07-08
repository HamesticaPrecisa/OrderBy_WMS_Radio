<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Frm_auditoria
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
        Me.btn_seleccionar = New System.Windows.Forms.Button
        Me.grp_buscar = New System.Windows.Forms.Panel
        Me.txt_codigoauditoria = New System.Windows.Forms.TextBox
        Me.txt_descripcionauditoria = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btn_limpiar = New System.Windows.Forms.Button
        Me.txt_leidos = New System.Windows.Forms.TextBox
        Me.txt_soportantes = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtg_auditoria = New System.Windows.Forms.DataGrid
        Me.dtg_auditoria_detalle = New System.Windows.Forms.DataGridTableStyle
        Me.CSoportante = New System.Windows.Forms.DataGridTextBoxColumn
        Me.CCamara = New System.Windows.Forms.DataGridTextBoxColumn
        Me.CBanda = New System.Windows.Forms.DataGridTextBoxColumn
        Me.CColumna = New System.Windows.Forms.DataGridTextBoxColumn
        Me.CPiso = New System.Windows.Forms.DataGridTextBoxColumn
        Me.CNivel = New System.Windows.Forms.DataGridTextBoxColumn
        Me.btn_bien = New System.Windows.Forms.Button
        Me.txt_codigosoportante = New System.Windows.Forms.TextBox
        Me.btn_mal = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.txt_nivel = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_piso = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_columna = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_banda = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_camara = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_observacion = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.rdi_ordendesc = New System.Windows.Forms.RadioButton
        Me.rdi_ordenasc = New System.Windows.Forms.RadioButton
        Me.grp_buscar.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_seleccionar
        '
        Me.btn_seleccionar.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btn_seleccionar.ForeColor = System.Drawing.Color.White
        Me.btn_seleccionar.Location = New System.Drawing.Point(206, 7)
        Me.btn_seleccionar.Name = "btn_seleccionar"
        Me.btn_seleccionar.Size = New System.Drawing.Size(20, 20)
        Me.btn_seleccionar.TabIndex = 1
        Me.btn_seleccionar.Text = "B"
        '
        'grp_buscar
        '
        Me.grp_buscar.BackColor = System.Drawing.Color.Gainsboro
        Me.grp_buscar.Controls.Add(Me.txt_codigoauditoria)
        Me.grp_buscar.Controls.Add(Me.btn_seleccionar)
        Me.grp_buscar.Controls.Add(Me.txt_descripcionauditoria)
        Me.grp_buscar.Location = New System.Drawing.Point(5, 6)
        Me.grp_buscar.Name = "grp_buscar"
        Me.grp_buscar.Size = New System.Drawing.Size(231, 33)
        '
        'txt_codigoauditoria
        '
        Me.txt_codigoauditoria.Enabled = False
        Me.txt_codigoauditoria.Location = New System.Drawing.Point(3, 6)
        Me.txt_codigoauditoria.Name = "txt_codigoauditoria"
        Me.txt_codigoauditoria.Size = New System.Drawing.Size(36, 21)
        Me.txt_codigoauditoria.TabIndex = 48
        '
        'txt_descripcionauditoria
        '
        Me.txt_descripcionauditoria.Enabled = False
        Me.txt_descripcionauditoria.Location = New System.Drawing.Point(42, 6)
        Me.txt_descripcionauditoria.Name = "txt_descripcionauditoria"
        Me.txt_descripcionauditoria.Size = New System.Drawing.Size(160, 21)
        Me.txt_descripcionauditoria.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel1.Controls.Add(Me.btn_limpiar)
        Me.Panel1.Controls.Add(Me.txt_leidos)
        Me.Panel1.Controls.Add(Me.txt_soportantes)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(5, 45)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(231, 36)
        '
        'btn_limpiar
        '
        Me.btn_limpiar.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btn_limpiar.Enabled = False
        Me.btn_limpiar.ForeColor = System.Drawing.Color.White
        Me.btn_limpiar.Location = New System.Drawing.Point(205, 6)
        Me.btn_limpiar.Name = "btn_limpiar"
        Me.btn_limpiar.Size = New System.Drawing.Size(20, 20)
        Me.btn_limpiar.TabIndex = 49
        Me.btn_limpiar.Text = "L"
        '
        'txt_leidos
        '
        Me.txt_leidos.Enabled = False
        Me.txt_leidos.Location = New System.Drawing.Point(164, 6)
        Me.txt_leidos.Name = "txt_leidos"
        Me.txt_leidos.Size = New System.Drawing.Size(38, 21)
        Me.txt_leidos.TabIndex = 4
        '
        'txt_soportantes
        '
        Me.txt_soportantes.Enabled = False
        Me.txt_soportantes.Location = New System.Drawing.Point(80, 6)
        Me.txt_soportantes.Name = "txt_soportantes"
        Me.txt_soportantes.Size = New System.Drawing.Size(38, 21)
        Me.txt_soportantes.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(120, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 20)
        Me.Label2.Text = "Leidos:"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(1, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 20)
        Me.Label1.Text = "Soportantes:"
        '
        'dtg_auditoria
        '
        Me.dtg_auditoria.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.dtg_auditoria.Location = New System.Drawing.Point(9, 249)
        Me.dtg_auditoria.Name = "dtg_auditoria"
        Me.dtg_auditoria.Size = New System.Drawing.Size(222, 261)
        Me.dtg_auditoria.TabIndex = 2
        Me.dtg_auditoria.TableStyles.Add(Me.dtg_auditoria_detalle)
        '
        'dtg_auditoria_detalle
        '
        Me.dtg_auditoria_detalle.GridColumnStyles.Add(Me.CSoportante)
        Me.dtg_auditoria_detalle.GridColumnStyles.Add(Me.CCamara)
        Me.dtg_auditoria_detalle.GridColumnStyles.Add(Me.CBanda)
        Me.dtg_auditoria_detalle.GridColumnStyles.Add(Me.CColumna)
        Me.dtg_auditoria_detalle.GridColumnStyles.Add(Me.CPiso)
        Me.dtg_auditoria_detalle.GridColumnStyles.Add(Me.CNivel)
        '
        'CSoportante
        '
        Me.CSoportante.Format = ""
        Me.CSoportante.FormatInfo = Nothing
        Me.CSoportante.HeaderText = "Soportante"
        Me.CSoportante.MappingName = "Soportante"
        Me.CSoportante.Width = 70
        '
        'CCamara
        '
        Me.CCamara.Format = ""
        Me.CCamara.FormatInfo = Nothing
        Me.CCamara.HeaderText = "CA"
        Me.CCamara.MappingName = "Camara"
        Me.CCamara.Width = 20
        '
        'CBanda
        '
        Me.CBanda.Format = ""
        Me.CBanda.FormatInfo = Nothing
        Me.CBanda.HeaderText = "BA"
        Me.CBanda.MappingName = "Banda"
        Me.CBanda.Width = 20
        '
        'CColumna
        '
        Me.CColumna.Format = ""
        Me.CColumna.FormatInfo = Nothing
        Me.CColumna.HeaderText = "CO"
        Me.CColumna.MappingName = "Columna"
        Me.CColumna.Width = 20
        '
        'CPiso
        '
        Me.CPiso.Format = ""
        Me.CPiso.FormatInfo = Nothing
        Me.CPiso.HeaderText = "PI"
        Me.CPiso.MappingName = "Piso"
        Me.CPiso.Width = 20
        '
        'CNivel
        '
        Me.CNivel.Format = ""
        Me.CNivel.FormatInfo = Nothing
        Me.CNivel.HeaderText = "NI"
        Me.CNivel.MappingName = "Nivel"
        Me.CNivel.Width = 20
        '
        'btn_bien
        '
        Me.btn_bien.BackColor = System.Drawing.Color.Green
        Me.btn_bien.Enabled = False
        Me.btn_bien.Font = New System.Drawing.Font("Wingdings", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btn_bien.ForeColor = System.Drawing.Color.White
        Me.btn_bien.Location = New System.Drawing.Point(155, 88)
        Me.btn_bien.Name = "btn_bien"
        Me.btn_bien.Size = New System.Drawing.Size(35, 21)
        Me.btn_bien.TabIndex = 37
        Me.btn_bien.Text = "ü"
        '
        'txt_codigosoportante
        '
        Me.txt_codigosoportante.Enabled = False
        Me.txt_codigosoportante.Location = New System.Drawing.Point(8, 88)
        Me.txt_codigosoportante.Name = "txt_codigosoportante"
        Me.txt_codigosoportante.Size = New System.Drawing.Size(136, 21)
        Me.txt_codigosoportante.TabIndex = 38
        '
        'btn_mal
        '
        Me.btn_mal.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btn_mal.Enabled = False
        Me.btn_mal.Font = New System.Drawing.Font("Courier New", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btn_mal.ForeColor = System.Drawing.Color.White
        Me.btn_mal.Location = New System.Drawing.Point(196, 88)
        Me.btn_mal.Name = "btn_mal"
        Me.btn_mal.Size = New System.Drawing.Size(35, 21)
        Me.btn_mal.TabIndex = 39
        Me.btn_mal.Text = "×"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel2.Controls.Add(Me.txt_nivel)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.txt_piso)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txt_columna)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.txt_banda)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.txt_camara)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Location = New System.Drawing.Point(5, 115)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(231, 36)
        '
        'txt_nivel
        '
        Me.txt_nivel.Enabled = False
        Me.txt_nivel.Location = New System.Drawing.Point(208, 5)
        Me.txt_nivel.MaxLength = 1
        Me.txt_nivel.Name = "txt_nivel"
        Me.txt_nivel.Size = New System.Drawing.Size(20, 21)
        Me.txt_nivel.TabIndex = 20
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(185, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(23, 20)
        Me.Label7.Text = "NI"
        '
        'txt_piso
        '
        Me.txt_piso.Enabled = False
        Me.txt_piso.Location = New System.Drawing.Point(162, 5)
        Me.txt_piso.MaxLength = 2
        Me.txt_piso.Name = "txt_piso"
        Me.txt_piso.Size = New System.Drawing.Size(23, 21)
        Me.txt_piso.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(139, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 20)
        Me.Label5.Text = "PI"
        '
        'txt_columna
        '
        Me.txt_columna.Enabled = False
        Me.txt_columna.Location = New System.Drawing.Point(116, 5)
        Me.txt_columna.MaxLength = 2
        Me.txt_columna.Name = "txt_columna"
        Me.txt_columna.Size = New System.Drawing.Size(23, 21)
        Me.txt_columna.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(93, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(23, 20)
        Me.Label6.Text = "CO"
        '
        'txt_banda
        '
        Me.txt_banda.Enabled = False
        Me.txt_banda.Location = New System.Drawing.Point(70, 5)
        Me.txt_banda.MaxLength = 2
        Me.txt_banda.Name = "txt_banda"
        Me.txt_banda.Size = New System.Drawing.Size(23, 21)
        Me.txt_banda.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(47, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 20)
        Me.Label3.Text = "BA"
        '
        'txt_camara
        '
        Me.txt_camara.Enabled = False
        Me.txt_camara.Location = New System.Drawing.Point(24, 5)
        Me.txt_camara.MaxLength = 2
        Me.txt_camara.Name = "txt_camara"
        Me.txt_camara.Size = New System.Drawing.Size(23, 21)
        Me.txt_camara.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(1, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 20)
        Me.Label4.Text = "CA"
        '
        'txt_observacion
        '
        Me.txt_observacion.Enabled = False
        Me.txt_observacion.Location = New System.Drawing.Point(10, 173)
        Me.txt_observacion.Multiline = True
        Me.txt_observacion.Name = "txt_observacion"
        Me.txt_observacion.Size = New System.Drawing.Size(220, 38)
        Me.txt_observacion.TabIndex = 42
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(9, 153)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 20)
        Me.Label8.Text = "Observación:"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel3.Controls.Add(Me.rdi_ordendesc)
        Me.Panel3.Controls.Add(Me.rdi_ordenasc)
        Me.Panel3.Location = New System.Drawing.Point(10, 213)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(220, 31)
        '
        'rdi_ordendesc
        '
        Me.rdi_ordendesc.Enabled = False
        Me.rdi_ordendesc.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.rdi_ordendesc.Location = New System.Drawing.Point(114, 4)
        Me.rdi_ordendesc.Name = "rdi_ordendesc"
        Me.rdi_ordendesc.Size = New System.Drawing.Size(100, 20)
        Me.rdi_ordendesc.TabIndex = 1
        Me.rdi_ordendesc.TabStop = False
        Me.rdi_ordendesc.Text = "Orden DESC"
        '
        'rdi_ordenasc
        '
        Me.rdi_ordenasc.Checked = True
        Me.rdi_ordenasc.Enabled = False
        Me.rdi_ordenasc.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.rdi_ordenasc.Location = New System.Drawing.Point(9, 4)
        Me.rdi_ordenasc.Name = "rdi_ordenasc"
        Me.rdi_ordenasc.Size = New System.Drawing.Size(100, 20)
        Me.rdi_ordenasc.TabIndex = 0
        Me.rdi_ordenasc.Text = "Orden ASC"
        '
        'Frm_auditoria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(250, 500)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txt_observacion)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btn_mal)
        Me.Controls.Add(Me.txt_codigosoportante)
        Me.Controls.Add(Me.btn_bien)
        Me.Controls.Add(Me.dtg_auditoria)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grp_buscar)
        Me.Menu = Me.mainMenu1
        Me.Name = "Frm_auditoria"
        Me.Text = "Auditoría"
        Me.grp_buscar.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_seleccionar As System.Windows.Forms.Button
    Friend WithEvents grp_buscar As System.Windows.Forms.Panel
    Friend WithEvents txt_descripcionauditoria As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txt_codigoauditoria As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_soportantes As System.Windows.Forms.TextBox
    Friend WithEvents txt_leidos As System.Windows.Forms.TextBox
    Friend WithEvents dtg_auditoria As System.Windows.Forms.DataGrid
    Friend WithEvents btn_bien As System.Windows.Forms.Button
    Friend WithEvents txt_codigosoportante As System.Windows.Forms.TextBox
    Friend WithEvents btn_mal As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txt_banda As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_camara As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_piso As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_columna As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_nivel As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btn_limpiar As System.Windows.Forms.Button
    Friend WithEvents txt_observacion As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtg_auditoria_detalle As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents CSoportante As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents CCamara As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents CBanda As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents CColumna As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents CPiso As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents CNivel As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents rdi_ordendesc As System.Windows.Forms.RadioButton
    Friend WithEvents rdi_ordenasc As System.Windows.Forms.RadioButton
End Class
