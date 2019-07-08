Imports Microsoft.Win32
Imports System.IO
Imports FieldSoftware.PrinterCE_NetCF
Imports SqlRDA.PrintCENET
Public Class ImprimeEtiqueta
    Private mCurLang As Int32 = 0
    Dim fnc As New Funciones
    Dim CLIENTE As String = ""
    Dim PRODUCTO As String = ""
    Dim FOLIOCLIENTE As String = ""
    Dim UNIDADESACTUALES As String = ""
    Dim UNIDADESRECE As String = ""
    Dim KG As String = ""
    Dim FPRO As String = ""
    Dim FVEN As String = ""
    Dim CODIGOLARGO As String = ""
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub llenaetiqueta()

        Dim sql As String = "SELECT * FROM VG_ETIQUETA_INA WHERE drec_codi='" + TextBox1.Text.Trim() + "' "

        Dim TablaCheck As DataTable = fnc.ListarTablasSQL(sql)

        If TablaCheck.Rows.Count > 0 Then

            CLIENTE = TablaCheck.Rows(0)(1).ToString()
            PRODUCTO = TablaCheck.Rows(0)(2).ToString()
            FOLIOCLIENTE = TablaCheck.Rows(0)(3).ToString()
            UNIDADESACTUALES = TablaCheck.Rows(0)(4).ToString()
            UNIDADESRECE = TablaCheck.Rows(0)(5).ToString()
            KG = TablaCheck.Rows(0)(6).ToString()
            FPRO = TablaCheck.Rows(0)(7).ToString()
            FVEN = TablaCheck.Rows(0)(8).ToString()
            CODIGOLARGO = TablaCheck.Rows(0)(9).ToString()

        End If
    End Sub

    Private Sub generabar()

        

    End Sub
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sqltra As String = "SELECT * from rackdeta WHERE racd_codi='" + TextBox1.Text.Trim() + "'"
        Dim tablatra As DataTable = fnc.ListarTablasSQL(sqltra)

        If tablatra.Rows.Count > 0 Then
            llenaetiqueta()


        Else

            MsgBox("El valor ingresado no pertenece a un soportante", MsgBoxStyle.Critical, "Aviso")
            Exit Sub
        End If

        Dim print1 As PrintCE
        Dim y As Double = 0.0

        Try
            print1 = New PrintCE
        Catch x As Exception
            MessageBox.Show(x.Message, "Error")
            Return
        End Try
        print1.Init("My license key")

        ' set language of the user interface
        print1.Language = mCurLang

        ' switch measuring units to inches
        print1.MeasureUnit = MeasureUnit.kInches

        If print1.SetupDlg(Me.Handle) = False Then
            print1.UnInit()
            Return
        End If





        print1.StartDoc()

        ' start printing page
        print1.StartPage()

        ' print heading with font of 14 points in height, bold 
        print1.FontSize = 14.0
        print1.FontBold = True
        y += 0.1
        print1.DrawAlignedText("PRECISA FROZEN", print1.PageWidth / 2, y, TextHorAlign.hCenter, TextVertAlign.vTop)
        y += print1.GetTextHeight("PRECISA FROZEN")

        ' print bitmap
        'Dim stream As Stream = System.Reflection.Assembly.GetCallingAssembly().GetManifestResourceStream("SqlRDA.LOGO.bmp")
        'If Not (stream Is Nothing) Then
        '    Dim bmp As Bitmap = New Bitmap(stream)
        '    If print1.DrawBitmap(bmp, 0.0, y, 0.8, 0.0, True) = True Then
        '        y += 0.9
        '    End If
        'End If
        print1.FontBold = False
        print1.FontSize = 9.0
        y += 0.3
        print1.DrawText("CLIENTE          :" + CLIENTE, 0, y)
        y += 0.2
        print1.DrawText("PRODUCTO       :" + PRODUCTO, 0, y)
        y += 0.2
        print1.DrawText("FOLIO CLIENTE :" + FOLIOCLIENTE + " UND:" + UNIDADESACTUALES + "/" + UNIDADESRECE + " KG:" + KG, 0, y)
        y += 0.2
        print1.DrawText("F.PRODUCCION :" + FPRO + " F.VENCIMIENTO: " + FVEN, 0, y)
        y += 0.2
        print1.FontSize = 24.0
        print1.DrawText("PALLET:", 0, y)
        y += 0.3
        print1.FontSize = 56.0
        print1.DrawText(TextBox1.Text, 0, y)
        y += 0.9
        print1.FontSize = 68.0
        print1.DrawCode128(CODIGOLARGO, 0, y, True, 68)
        y += 0.7
        print1.FontSize = 12.0
        'print1.DrawText(CODIGOLARGO, 0.5, y)
        ' set blue line colour
        ' set blue line colour
        '  print1.LineColor = Color.Blue

        ' set line width of 0.05 inches
        '  print1.LineWidth = 0.05

        ' print 3 blue lines of 2, 1.5 and 1 inches in length
        '

        ' print rectangle of 2 inches in length and 0.5 inch in width
        'print1.DrawRect(0.0, y, 2.0, y + 0.5)

        '' set line width of 0.01 inches
        'print1.LineWidth = 0.01

        '' set black line colour
        'print1.LineColor = Color.Black

        '' set red fill colour
        'print1.FillColor = Color.Red

        '' print ellipse inside the rectangle
        'print1.DrawEllipse(0.5, y + 0.05, 1.5, y + 0.45)

        y += 0.9

        ' print text with 9 points font 
        print1.FontBold = False
        print1.FontSize = 9.0
        '  print1.DrawText("PALLET NUMERO:" + TextBox1.Text, 0, y)

        ' end printing document
        print1.EndDoc()

        ' library deinitialization
        print1.UnInit()

    End Sub
End Class