<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Frm_temperaturas
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
        Me.dtg_listado = New System.Windows.Forms.DataGrid
        Me.dtg_listado_coleccion = New System.Windows.Forms.DataGridTableStyle
        Me.Soportante = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Temperatura = New System.Windows.Forms.DataGridTextBoxColumn
        Me.grp_buscar = New System.Windows.Forms.Panel
        Me.btn_menos = New System.Windows.Forms.Button
        Me.lbl_promedio = New System.Windows.Forms.Label
        Me.lbl_cantidad = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_soportante = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btn_actualizar = New System.Windows.Forms.Button
        Me.txt_temperatura = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btn_punto = New System.Windows.Forms.Button
        Me.grp_buscar.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_cerrar
        '
        Me.btn_cerrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btn_cerrar.ForeColor = System.Drawing.Color.White
        Me.btn_cerrar.Location = New System.Drawing.Point(173, 49)
        Me.btn_cerrar.Name = "btn_cerrar"
        Me.btn_cerrar.Size = New System.Drawing.Size(54, 21)
        Me.btn_cerrar.TabIndex = 54
        Me.btn_cerrar.Text = "Cerrar"
        '
        'dtg_listado
        '
        Me.dtg_listado.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.dtg_listado.Location = New System.Drawing.Point(5, 133)
        Me.dtg_listado.Name = "dtg_listado"
        Me.dtg_listado.Size = New System.Drawing.Size(229, 251)
        Me.dtg_listado.TabIndex = 52
        Me.dtg_listado.TableStyles.Add(Me.dtg_listado_coleccion)
        '
        'dtg_listado_coleccion
        '
        Me.dtg_listado_coleccion.GridColumnStyles.Add(Me.Soportante)
        Me.dtg_listado_coleccion.GridColumnStyles.Add(Me.Temperatura)
        '
        'Soportante
        '
        Me.Soportante.Format = ""
        Me.Soportante.FormatInfo = Nothing
        Me.Soportante.HeaderText = "Soportante"
        Me.Soportante.MappingName = "Soportante"
        Me.Soportante.Width = 100
        '
        'Temperatura
        '
        Me.Temperatura.Format = ""
        Me.Temperatura.FormatInfo = Nothing
        Me.Temperatura.HeaderText = "Temperatura"
        Me.Temperatura.MappingName = "Temperatura"
        Me.Temperatura.Width = 100
        '
        'grp_buscar
        '
        Me.grp_buscar.BackColor = System.Drawing.Color.Gainsboro
        Me.grp_buscar.Controls.Add(Me.btn_punto)
        Me.grp_buscar.Controls.Add(Me.btn_menos)
        Me.grp_buscar.Controls.Add(Me.lbl_promedio)
        Me.grp_buscar.Controls.Add(Me.lbl_cantidad)
        Me.grp_buscar.Controls.Add(Me.Label4)
        Me.grp_buscar.Controls.Add(Me.Label3)
        Me.grp_buscar.Controls.Add(Me.txt_soportante)
        Me.grp_buscar.Controls.Add(Me.Label1)
        Me.grp_buscar.Controls.Add(Me.btn_cerrar)
        Me.grp_buscar.Controls.Add(Me.btn_actualizar)
        Me.grp_buscar.Controls.Add(Me.txt_temperatura)
        Me.grp_buscar.Controls.Add(Me.Label2)
        Me.grp_buscar.Location = New System.Drawing.Point(5, 6)
        Me.grp_buscar.Name = "grp_buscar"
        Me.grp_buscar.Size = New System.Drawing.Size(231, 124)
        '
        'btn_menos
        '
        Me.btn_menos.Enabled = False
        Me.btn_menos.Location = New System.Drawing.Point(186, 26)
        Me.btn_menos.Name = "btn_menos"
        Me.btn_menos.Size = New System.Drawing.Size(20, 20)
        Me.btn_menos.TabIndex = 60
        Me.btn_menos.Text = "-"
        '
        'lbl_promedio
        '
        Me.lbl_promedio.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_promedio.Location = New System.Drawing.Point(89, 97)
        Me.lbl_promedio.Name = "lbl_promedio"
        Me.lbl_promedio.Size = New System.Drawing.Size(138, 20)
        Me.lbl_promedio.Text = "0"
        '
        'lbl_cantidad
        '
        Me.lbl_cantidad.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_cantidad.Location = New System.Drawing.Point(89, 76)
        Me.lbl_cantidad.Name = "lbl_cantidad"
        Me.lbl_cantidad.Size = New System.Drawing.Size(138, 20)
        Me.lbl_cantidad.Text = "0"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(3, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 21)
        Me.Label4.Text = "Promedio T°: "
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(20, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 21)
        Me.Label3.Text = "Cantidad : "
        '
        'txt_soportante
        '
        Me.txt_soportante.Enabled = False
        Me.txt_soportante.Location = New System.Drawing.Point(89, 2)
        Me.txt_soportante.Name = "txt_soportante"
        Me.txt_soportante.Size = New System.Drawing.Size(138, 21)
        Me.txt_soportante.TabIndex = 57
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(3, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 21)
        Me.Label1.Text = "Soportante"
        '
        'btn_actualizar
        '
        Me.btn_actualizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btn_actualizar.Enabled = False
        Me.btn_actualizar.ForeColor = System.Drawing.Color.White
        Me.btn_actualizar.Location = New System.Drawing.Point(89, 49)
        Me.btn_actualizar.Name = "btn_actualizar"
        Me.btn_actualizar.Size = New System.Drawing.Size(80, 21)
        Me.btn_actualizar.TabIndex = 55
        Me.btn_actualizar.Text = "Actualizar"
        '
        'txt_temperatura
        '
        Me.txt_temperatura.Enabled = False
        Me.txt_temperatura.Location = New System.Drawing.Point(89, 25)
        Me.txt_temperatura.MaxLength = 5
        Me.txt_temperatura.Name = "txt_temperatura"
        Me.txt_temperatura.Size = New System.Drawing.Size(94, 21)
        Me.txt_temperatura.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(3, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 21)
        Me.Label2.Text = "Temperatura"
        '
        'btn_punto
        '
        Me.btn_punto.Enabled = False
        Me.btn_punto.Location = New System.Drawing.Point(209, 26)
        Me.btn_punto.Name = "btn_punto"
        Me.btn_punto.Size = New System.Drawing.Size(20, 20)
        Me.btn_punto.TabIndex = 67
        Me.btn_punto.Text = "."
        '
        'Frm_temperaturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 400)
        Me.Controls.Add(Me.dtg_listado)
        Me.Controls.Add(Me.grp_buscar)
        Me.Menu = Me.mainMenu1
        Me.Name = "Frm_temperaturas"
        Me.Text = "Temperaturas"
        Me.grp_buscar.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_cerrar As System.Windows.Forms.Button
    Friend WithEvents dtg_listado As System.Windows.Forms.DataGrid
    Friend WithEvents dtg_listado_coleccion As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents grp_buscar As System.Windows.Forms.Panel
    Friend WithEvents txt_temperatura As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_soportante As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_actualizar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbl_promedio As System.Windows.Forms.Label
    Friend WithEvents lbl_cantidad As System.Windows.Forms.Label
    Friend WithEvents Soportante As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Temperatura As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btn_menos As System.Windows.Forms.Button
    Friend WithEvents btn_punto As System.Windows.Forms.Button
End Class
