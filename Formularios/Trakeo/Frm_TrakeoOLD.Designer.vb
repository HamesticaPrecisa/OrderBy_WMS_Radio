<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Frm_TrakeoOLD
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
        Me.components = New System.ComponentModel.Container
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.txtcaj = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.tpal = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.txtrecibe = New System.Windows.Forms.TextBox
        Me.LblM = New System.Windows.Forms.Label
        Me.BtnGuardaTodo = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.CajasTotal = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.BtnPallet = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.Add(Me.MenuItem1)
        '
        'MenuItem1
        '
        Me.MenuItem1.MenuItems.Add(Me.MenuItem2)
        Me.MenuItem1.Text = "agregar"
        '
        'MenuItem2
        '
        Me.MenuItem2.Text = "Agregar Recepcion"
        '
        'txtcaj
        '
        Me.txtcaj.Enabled = False
        Me.txtcaj.Location = New System.Drawing.Point(102, 43)
        Me.txtcaj.Name = "txtcaj"
        Me.txtcaj.Size = New System.Drawing.Size(35, 21)
        Me.txtcaj.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(3, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(108, 18)
        Me.Label6.Text = "Nº CAJAS LEIDAS"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(3, 4)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 20)
        Me.Label8.Text = "N° PALLET"
        '
        'tpal
        '
        Me.tpal.Enabled = False
        Me.tpal.Location = New System.Drawing.Point(67, 3)
        Me.tpal.Name = "tpal"
        Me.tpal.Size = New System.Drawing.Size(137, 21)
        Me.tpal.TabIndex = 16
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(186, 70)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(44, 23)
        '
        'ListBox1
        '
        Me.ListBox1.Location = New System.Drawing.Point(3, 99)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(227, 114)
        Me.ListBox1.TabIndex = 28
        '
        'txtrecibe
        '
        Me.txtrecibe.Enabled = False
        Me.txtrecibe.Location = New System.Drawing.Point(3, 72)
        Me.txtrecibe.Name = "txtrecibe"
        Me.txtrecibe.Size = New System.Drawing.Size(177, 21)
        Me.txtrecibe.TabIndex = 29
        '
        'LblM
        '
        Me.LblM.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.LblM.Location = New System.Drawing.Point(4, 250)
        Me.LblM.Name = "LblM"
        Me.LblM.Size = New System.Drawing.Size(226, 13)
        '
        'BtnGuardaTodo
        '
        Me.BtnGuardaTodo.Location = New System.Drawing.Point(4, 219)
        Me.BtnGuardaTodo.Name = "BtnGuardaTodo"
        Me.BtnGuardaTodo.Size = New System.Drawing.Size(107, 28)
        Me.BtnGuardaTodo.TabIndex = 35
        Me.BtnGuardaTodo.Text = "Guardar (F1)"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(140, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 20)
        Me.Label1.Text = "DE"
        '
        'CajasTotal
        '
        Me.CajasTotal.Enabled = False
        Me.CajasTotal.Location = New System.Drawing.Point(164, 43)
        Me.CajasTotal.Name = "CajasTotal"
        Me.CajasTotal.Size = New System.Drawing.Size(35, 21)
        Me.CajasTotal.TabIndex = 37
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular)
        Me.Label3.Location = New System.Drawing.Point(129, 215)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 38)
        Me.Label3.Text = "0- Sin Tarja." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "1- Error al leer." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "2- Otro."
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(202, 43)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(34, 20)
        Me.Button1.TabIndex = 44
        Me.Button1.Text = "Nvo"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(3, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(227, 23)
        Me.Label2.Text = "________________________________________________________"
        '
        'BtnPallet
        '
        Me.BtnPallet.Location = New System.Drawing.Point(210, 3)
        Me.BtnPallet.Name = "BtnPallet"
        Me.BtnPallet.Size = New System.Drawing.Size(20, 20)
        Me.BtnPallet.TabIndex = 27
        Me.BtnPallet.Text = "..."
        '
        'Frm_Trakeo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(239, 268)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CajasTotal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnGuardaTodo)
        Me.Controls.Add(Me.LblM)
        Me.Controls.Add(Me.txtrecibe)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.BtnPallet)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tpal)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtcaj)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label6)
        Me.KeyPreview = True
        Me.Menu = Me.mainMenu1
        Me.Name = "Frm_Trakeo"
        Me.Text = "Trakeo"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtcaj As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tpal As System.Windows.Forms.TextBox
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents txtrecibe As System.Windows.Forms.TextBox
    Friend WithEvents LblM As System.Windows.Forms.Label
    Friend WithEvents BtnGuardaTodo As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CajasTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnPallet As System.Windows.Forms.Button

End Class
