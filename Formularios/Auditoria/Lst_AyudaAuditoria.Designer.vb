<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Lst_AyudaAuditoria
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
        Me.btn_seleccionar = New System.Windows.Forms.Button
        Me.dtg_listado = New System.Windows.Forms.DataGrid
        Me.dtg_listado_coleccion = New System.Windows.Forms.DataGridTableStyle
        Me.CIdAuditoriaFicha = New System.Windows.Forms.DataGridTextBoxColumn
        Me.CDescripcion = New System.Windows.Forms.DataGridTextBoxColumn
        Me.CCantidad = New System.Windows.Forms.DataGridTextBoxColumn
        Me.grp_buscar = New System.Windows.Forms.Panel
        Me.txt_buscar = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.chk_auditoria = New System.Windows.Forms.CheckBox
        Me.CTipo = New System.Windows.Forms.DataGridTextBoxColumn
        Me.grp_buscar.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_cerrar
        '
        Me.btn_cerrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btn_cerrar.ForeColor = System.Drawing.Color.White
        Me.btn_cerrar.Location = New System.Drawing.Point(123, 242)
        Me.btn_cerrar.Name = "btn_cerrar"
        Me.btn_cerrar.Size = New System.Drawing.Size(110, 21)
        Me.btn_cerrar.TabIndex = 46
        Me.btn_cerrar.Text = "Cerrar"
        '
        'btn_seleccionar
        '
        Me.btn_seleccionar.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btn_seleccionar.Enabled = False
        Me.btn_seleccionar.ForeColor = System.Drawing.Color.White
        Me.btn_seleccionar.Location = New System.Drawing.Point(7, 242)
        Me.btn_seleccionar.Name = "btn_seleccionar"
        Me.btn_seleccionar.Size = New System.Drawing.Size(110, 21)
        Me.btn_seleccionar.TabIndex = 45
        Me.btn_seleccionar.Text = "Seleccionar"
        '
        'dtg_listado
        '
        Me.dtg_listado.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.dtg_listado.Location = New System.Drawing.Point(6, 50)
        Me.dtg_listado.Name = "dtg_listado"
        Me.dtg_listado.Size = New System.Drawing.Size(229, 151)
        Me.dtg_listado.TabIndex = 44
        Me.dtg_listado.TableStyles.Add(Me.dtg_listado_coleccion)
        '
        'dtg_listado_coleccion
        '
        Me.dtg_listado_coleccion.GridColumnStyles.Add(Me.CIdAuditoriaFicha)
        Me.dtg_listado_coleccion.GridColumnStyles.Add(Me.CDescripcion)
        Me.dtg_listado_coleccion.GridColumnStyles.Add(Me.CCantidad)
        Me.dtg_listado_coleccion.GridColumnStyles.Add(Me.CTipo)
        '
        'CIdAuditoriaFicha
        '
        Me.CIdAuditoriaFicha.Format = ""
        Me.CIdAuditoriaFicha.FormatInfo = Nothing
        Me.CIdAuditoriaFicha.HeaderText = "Folio"
        Me.CIdAuditoriaFicha.MappingName = "IdAuditoriaFicha"
        Me.CIdAuditoriaFicha.Width = 30
        '
        'CDescripcion
        '
        Me.CDescripcion.Format = ""
        Me.CDescripcion.FormatInfo = Nothing
        Me.CDescripcion.HeaderText = "Descripción"
        Me.CDescripcion.MappingName = "Descripcion"
        Me.CDescripcion.Width = 120
        '
        'CCantidad
        '
        Me.CCantidad.Format = ""
        Me.CCantidad.FormatInfo = Nothing
        Me.CCantidad.HeaderText = "Soportantes"
        Me.CCantidad.MappingName = "Cantidad"
        '
        'grp_buscar
        '
        Me.grp_buscar.BackColor = System.Drawing.Color.Gainsboro
        Me.grp_buscar.Controls.Add(Me.txt_buscar)
        Me.grp_buscar.Controls.Add(Me.Label1)
        Me.grp_buscar.Location = New System.Drawing.Point(5, 6)
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
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(2, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 20)
        Me.Label1.Text = "Buscar"
        '
        'chk_auditoria
        '
        Me.chk_auditoria.Font = New System.Drawing.Font("Tahoma", 6.5!, System.Drawing.FontStyle.Bold)
        Me.chk_auditoria.Location = New System.Drawing.Point(0, 207)
        Me.chk_auditoria.Name = "chk_auditoria"
        Me.chk_auditoria.Size = New System.Drawing.Size(240, 29)
        Me.chk_auditoria.TabIndex = 48
        Me.chk_auditoria.Text = "LA AUDITORÍA NO SE ENCUENTRA EN LA LISTA"
        '
        'CTipo
        '
        Me.CTipo.Format = ""
        Me.CTipo.FormatInfo = Nothing
        Me.CTipo.HeaderText = "Tipo"
        Me.CTipo.MappingName = "Tipo"
        '
        'Lst_AyudaAuditoria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.chk_auditoria)
        Me.Controls.Add(Me.btn_cerrar)
        Me.Controls.Add(Me.btn_seleccionar)
        Me.Controls.Add(Me.dtg_listado)
        Me.Controls.Add(Me.grp_buscar)
        Me.Menu = Me.mainMenu1
        Me.Name = "Lst_AyudaAuditoria"
        Me.Text = "Auditoria"
        Me.grp_buscar.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_cerrar As System.Windows.Forms.Button
    Friend WithEvents btn_seleccionar As System.Windows.Forms.Button
    Friend WithEvents dtg_listado As System.Windows.Forms.DataGrid
    Friend WithEvents dtg_listado_coleccion As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents grp_buscar As System.Windows.Forms.Panel
    Friend WithEvents txt_buscar As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CIdAuditoriaFicha As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents CDescripcion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents CCantidad As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents chk_auditoria As System.Windows.Forms.CheckBox
    Friend WithEvents CTipo As System.Windows.Forms.DataGridTextBoxColumn
End Class
