<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Frm_TraqueoService
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
        Me.txt_codigo = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_envases = New System.Windows.Forms.TextBox
        Me.txt_leidas = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_lector = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.BtnNuevo = New System.Windows.Forms.Button
        Me.dtg_cajasleidas = New System.Windows.Forms.DataGrid
        Me.dtg_cajasleidas_coleccion = New System.Windows.Forms.DataGridTableStyle
        Me.IdTracking = New System.Windows.Forms.DataGridTextBoxColumn
        Me.EtiquetaCompleta = New System.Windows.Forms.DataGridTextBoxColumn
        Me.MainMenu2 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboproducto = New System.Windows.Forms.ComboBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'txt_codigo
        '
        Me.txt_codigo.Location = New System.Drawing.Point(65, 56)
        Me.txt_codigo.Name = "txt_codigo"
        Me.txt_codigo.Size = New System.Drawing.Size(163, 21)
        Me.txt_codigo.TabIndex = 19
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(0, 58)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 20)
        Me.Label8.Text = "CODIGO"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(227, 23)
        Me.Label1.Text = "________________________________________________________"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(1, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 20)
        Me.Label4.Text = "ENVASES"
        '
        'txt_envases
        '
        Me.txt_envases.Enabled = False
        Me.txt_envases.Location = New System.Drawing.Point(66, 85)
        Me.txt_envases.Name = "txt_envases"
        Me.txt_envases.Size = New System.Drawing.Size(39, 21)
        Me.txt_envases.TabIndex = 35
        '
        'txt_leidas
        '
        Me.txt_leidas.Enabled = False
        Me.txt_leidas.Location = New System.Drawing.Point(156, 85)
        Me.txt_leidas.Name = "txt_leidas"
        Me.txt_leidas.Size = New System.Drawing.Size(39, 21)
        Me.txt_leidas.TabIndex = 37
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(109, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 20)
        Me.Label5.Text = "LEIDAS"
        '
        'txt_lector
        '
        Me.txt_lector.Enabled = False
        Me.txt_lector.Location = New System.Drawing.Point(3, 117)
        Me.txt_lector.Name = "txt_lector"
        Me.txt_lector.Size = New System.Drawing.Size(198, 21)
        Me.txt_lector.TabIndex = 41
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(203, 116)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(23, 23)
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Location = New System.Drawing.Point(201, 85)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(28, 22)
        Me.BtnNuevo.TabIndex = 49
        Me.BtnNuevo.Text = " X"
        '
        'dtg_cajasleidas
        '
        Me.dtg_cajasleidas.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.dtg_cajasleidas.Location = New System.Drawing.Point(3, 146)
        Me.dtg_cajasleidas.Name = "dtg_cajasleidas"
        Me.dtg_cajasleidas.Size = New System.Drawing.Size(234, 119)
        Me.dtg_cajasleidas.TabIndex = 77
        Me.dtg_cajasleidas.TableStyles.Add(Me.dtg_cajasleidas_coleccion)
        '
        'dtg_cajasleidas_coleccion
        '
        Me.dtg_cajasleidas_coleccion.GridColumnStyles.Add(Me.IdTracking)
        Me.dtg_cajasleidas_coleccion.GridColumnStyles.Add(Me.EtiquetaCompleta)
        '
        'IdTracking
        '
        Me.IdTracking.Format = ""
        Me.IdTracking.FormatInfo = Nothing
        Me.IdTracking.HeaderText = "Id"
        Me.IdTracking.MappingName = "IdTracking"
        Me.IdTracking.Width = 0
        '
        'EtiquetaCompleta
        '
        Me.EtiquetaCompleta.Format = ""
        Me.EtiquetaCompleta.FormatInfo = Nothing
        Me.EtiquetaCompleta.HeaderText = "Etiqueta"
        Me.EtiquetaCompleta.MappingName = "EtiquetaCompleta"
        Me.EtiquetaCompleta.Width = 230
        '
        'MainMenu2
        '
        Me.MainMenu2.MenuItems.Add(Me.MenuItem1)
        '
        'MenuItem1
        '
        Me.MenuItem1.Text = "Salir"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(3, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(227, 23)
        Me.Label2.Text = "________________________________________________________"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(1, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(227, 23)
        Me.Label3.Text = "________________________________________________________"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(0, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 20)
        Me.Label6.Text = "PRODUCTO"
        '
        'cboproducto
        '
        Me.cboproducto.Location = New System.Drawing.Point(67, 22)
        Me.cboproducto.Name = "cboproducto"
        Me.cboproducto.Size = New System.Drawing.Size(161, 22)
        Me.cboproducto.TabIndex = 88
        '
        'CheckBox1
        '
        Me.CheckBox1.Location = New System.Drawing.Point(65, 0)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(163, 20)
        Me.CheckBox1.TabIndex = 89
        Me.CheckBox1.Text = "PRODUCTO MIXTO"
        '
        'Frm_TraqueoService
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.cboproducto)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dtg_cajasleidas)
        Me.Controls.Add(Me.BtnNuevo)
        Me.Controls.Add(Me.txt_lector)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txt_leidas)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_envases)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_codigo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Menu = Me.MainMenu2
        Me.Name = "Frm_TraqueoService"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txt_codigo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_envases As System.Windows.Forms.TextBox
    Friend WithEvents txt_leidas As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_lector As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnNuevo As System.Windows.Forms.Button
    Friend WithEvents dtg_cajasleidas As System.Windows.Forms.DataGrid
    Friend WithEvents dtg_cajasleidas_coleccion As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents IdTracking As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents EtiquetaCompleta As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents MainMenu2 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboproducto As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
End Class
