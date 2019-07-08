<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Frm_CamionesAndenRecepcion
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
        Me.btn_cerrar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.btn_seleccionar = New System.Windows.Forms.Button
        Me.dtg_listado = New System.Windows.Forms.DataGrid
        Me.dtg_listado_coleccion = New System.Windows.Forms.DataGridTableStyle
        Me.grp_buscar = New System.Windows.Forms.Panel
        Me.txt_buscar = New System.Windows.Forms.TextBox
        Me.chk_sincamion = New System.Windows.Forms.CheckBox
        Me.cl_fol = New System.Windows.Forms.DataGridTextBoxColumn
        Me.cl_rutcli = New System.Windows.Forms.DataGridTextBoxColumn
        Me.cli_nomb = New System.Windows.Forms.DataGridTextBoxColumn
        Me.cl_chorut = New System.Windows.Forms.DataGridTextBoxColumn
        Me.cho_nombre = New System.Windows.Forms.DataGridTextBoxColumn
        Me.grp_buscar.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_cerrar
        '
        Me.btn_cerrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btn_cerrar.ForeColor = System.Drawing.Color.White
        Me.btn_cerrar.Location = New System.Drawing.Point(123, 239)
        Me.btn_cerrar.Name = "btn_cerrar"
        Me.btn_cerrar.Size = New System.Drawing.Size(110, 21)
        Me.btn_cerrar.TabIndex = 32
        Me.btn_cerrar.Text = "Cerrar"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(2, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 20)
        Me.Label1.Text = "Buscar"
        '
        'btn_seleccionar
        '
        Me.btn_seleccionar.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btn_seleccionar.Enabled = False
        Me.btn_seleccionar.ForeColor = System.Drawing.Color.White
        Me.btn_seleccionar.Location = New System.Drawing.Point(7, 239)
        Me.btn_seleccionar.Name = "btn_seleccionar"
        Me.btn_seleccionar.Size = New System.Drawing.Size(110, 21)
        Me.btn_seleccionar.TabIndex = 31
        Me.btn_seleccionar.Text = "Seleccionar"
        '
        'dtg_listado
        '
        Me.dtg_listado.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.dtg_listado.Location = New System.Drawing.Point(6, 47)
        Me.dtg_listado.Name = "dtg_listado"
        Me.dtg_listado.Size = New System.Drawing.Size(229, 151)
        Me.dtg_listado.TabIndex = 30
        Me.dtg_listado.TableStyles.Add(Me.dtg_listado_coleccion)
        '
        'dtg_listado_coleccion
        '
        Me.dtg_listado_coleccion.GridColumnStyles.Add(Me.cl_fol)
        Me.dtg_listado_coleccion.GridColumnStyles.Add(Me.cl_rutcli)
        Me.dtg_listado_coleccion.GridColumnStyles.Add(Me.cli_nomb)
        Me.dtg_listado_coleccion.GridColumnStyles.Add(Me.cl_chorut)
        Me.dtg_listado_coleccion.GridColumnStyles.Add(Me.cho_nombre)
        '
        'grp_buscar
        '
        Me.grp_buscar.BackColor = System.Drawing.Color.Gainsboro
        Me.grp_buscar.Controls.Add(Me.txt_buscar)
        Me.grp_buscar.Controls.Add(Me.Label1)
        Me.grp_buscar.Location = New System.Drawing.Point(5, 3)
        Me.grp_buscar.Name = "grp_buscar"
        Me.grp_buscar.Size = New System.Drawing.Size(231, 38)
        '
        'txt_buscar
        '
        Me.txt_buscar.Location = New System.Drawing.Point(45, 7)
        Me.txt_buscar.Name = "txt_buscar"
        Me.txt_buscar.Size = New System.Drawing.Size(183, 21)
        Me.txt_buscar.TabIndex = 3
        '
        'chk_sincamion
        '
        Me.chk_sincamion.Font = New System.Drawing.Font("Tahoma", 6.5!, System.Drawing.FontStyle.Bold)
        Me.chk_sincamion.Location = New System.Drawing.Point(0, 204)
        Me.chk_sincamion.Name = "chk_sincamion"
        Me.chk_sincamion.Size = New System.Drawing.Size(240, 29)
        Me.chk_sincamion.TabIndex = 34
        Me.chk_sincamion.Text = "EL CAMIÓN NO SE ENCUENTRA EN ESTA LISTA"
        '
        'cl_fol
        '
        Me.cl_fol.Format = ""
        Me.cl_fol.FormatInfo = Nothing
        Me.cl_fol.HeaderText = "Folio"
        Me.cl_fol.MappingName = "cl_fol"
        '
        'cl_rutcli
        '
        Me.cl_rutcli.Format = ""
        Me.cl_rutcli.FormatInfo = Nothing
        Me.cl_rutcli.HeaderText = "Rut"
        Me.cl_rutcli.MappingName = "cl_rutcli"
        Me.cl_rutcli.Width = 0
        '
        'cli_nomb
        '
        Me.cli_nomb.Format = ""
        Me.cli_nomb.FormatInfo = Nothing
        Me.cli_nomb.HeaderText = "Cliente"
        Me.cli_nomb.MappingName = "cli_nomb"
        '
        'cl_chorut
        '
        Me.cl_chorut.Format = ""
        Me.cl_chorut.FormatInfo = Nothing
        Me.cl_chorut.HeaderText = "Rut Chofer"
        Me.cl_chorut.MappingName = "cl_chorut"
        '
        'cho_nombre
        '
        Me.cho_nombre.Format = ""
        Me.cho_nombre.FormatInfo = Nothing
        Me.cho_nombre.HeaderText = "Chofer"
        Me.cho_nombre.MappingName = "cho_nombre"
        '
        'Frm_CamionesAndenRecepcion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.chk_sincamion)
        Me.Controls.Add(Me.btn_cerrar)
        Me.Controls.Add(Me.btn_seleccionar)
        Me.Controls.Add(Me.dtg_listado)
        Me.Controls.Add(Me.grp_buscar)
        Me.Menu = Me.mainMenu1
        Me.Name = "Frm_CamionesAndenRecepcion"
        Me.Text = "Camiones"
        Me.grp_buscar.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_cerrar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_seleccionar As System.Windows.Forms.Button
    Friend WithEvents dtg_listado As System.Windows.Forms.DataGrid
    Friend WithEvents dtg_listado_coleccion As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents grp_buscar As System.Windows.Forms.Panel
    Friend WithEvents txt_buscar As System.Windows.Forms.TextBox
    Friend WithEvents chk_sincamion As System.Windows.Forms.CheckBox
    Friend WithEvents cl_fol As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents cl_rutcli As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents cli_nomb As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents cl_chorut As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents cho_nombre As System.Windows.Forms.DataGridTextBoxColumn
End Class
