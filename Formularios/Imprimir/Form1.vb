
Imports Microsoft.Win32
Imports System.IO
Imports FieldSoftware.PrinterCE_NetCF
Imports SqlRDA.PrintCENET

Public Class Form1

    Private mCurLang As Int32 = 0

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Print' button
        Print(False)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Print Silent' button
        Print(True)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'Language' button
        Dim menu As ContextMenu = New ContextMenu()
        Dim menuStr(6) As String
        menuStr(0) = "English"
        menuStr(1) = "Russian"
        menuStr(2) = "French"
        menuStr(3) = "Portuguese"
        menuStr(4) = "Italian"
        menuStr(5) = "Dutch"
        For i As Int32 = 0 To 5
            menu.MenuItems.Add(New MenuItem())
            menu.MenuItems(i).Text = menuStr(i)
            AddHandler menu.MenuItems(i).Click, AddressOf OnLangMenuClick
        Next
        menu.MenuItems(mCurLang).Checked = True
        menu.Show(Me, New Point(Me.Button3.Left + Me.Button3.Width / 2, Me.Button3.Top + Me.Button3.Height / 2))

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        'Exit' button
        Close()
    End Sub

    Private Sub OnLangMenuClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m1 As MenuItem = sender
        If m1.Text = "English" Then
            mCurLang = 0
        ElseIf m1.Text = "Russian" Then
            mCurLang = 1
        ElseIf m1.Text = "French" Then
            mCurLang = 2
        ElseIf m1.Text = "Portuguese" Then
            mCurLang = 3
        ElseIf m1.Text = "Italian" Then
            mCurLang = 4
        ElseIf m1.Text = "Dutch" Then
            mCurLang = 5
        End If
    End Sub

    Private Sub Print(ByVal silent As Boolean)

        Dim print1 As PrintCE
        Dim y As Double = 0.0

        Try
            print1 = New PrintCE
        Catch x As Exception
            MessageBox.Show(x.Message, "Error")
            Return
        End Try

        ' library initialization (licence key is transfered as a parameter)
        print1.Init("My license key")

        ' set language of the user interface
        print1.Language = mCurLang

        ' switch measuring units to inches
        print1.MeasureUnit = MeasureUnit.kInches

        If silent = True Then

            ' don't show print setup dialog, just print to file 'silent_out.prn' for 'HP PCL' printer
            Dim info As PrintInfo
            info.printer = 0                        ' HP PCL
            info.port = 9                           ' output to file
            info.portrait = True                    ' portrait mode
            info.color_mode = 2                 ' CMY colors
            info.draft_mode = False             ' no draft
            info.paper = 0                          ' 'A4' paper for HP printer (see "PrintCE documentation")
            info.paper_width = 0                    ' used only for 'custom paper'
            info.paper_height = 0                   ' used only for 'custom paper'
            info.start_page = info.end_page = -1    ' to print all pages
            info.left_margin = info.right_margin = info.top_margin = info.bottom_margin = 0 ' zero margins

            ' set output file path
            Dim reg_key As String = "HKEY_CURRENT_USER\Software\IneSoft\PrintCE"
            Registry.SetValue(reg_key, "FilePath", "\silent_out.prn")

            ' silent setup
            If print1.SilentPrintSetup(Me.Handle, info) = False Then
                print1.UnInit()
                print1.UnInit()
                MessageBox.Show("SilentPrintSetup failed !", "Error")
                Return
            End If
            ' disable progress dialog box
            print1.SilentMode = True

        Else
            ' show print setup dialog
            If print1.SetupDlg(Me.Handle) = False Then
                print1.UnInit()
                Return
            End If
        End If

        ' set margins
        print1.LeftMargin = 1.0
        print1.RightMargin = 1.0
        print1.TopMargin = 0.7
        print1.BottomMargin = 0.7

        ' start printing document
        print1.StartDoc()

        ' start printing page
        print1.StartPage()

        ' print heading with font of 14 points in height, bold 
        print1.FontSize = 14.0
        print1.FontBold = True
        print1.DrawAlignedText("PrintCE for Pocket PC", print1.PageWidth / 2, y, TextHorAlign.hCenter, TextVertAlign.vTop)
        y += print1.GetTextHeight("PrintCE for Pocket PC")

        ' print bitmap
        Dim stream As Stream = System.Reflection.Assembly.GetCallingAssembly().GetManifestResourceStream("Sample_PrintCE.tiger.bmp")
        If Not (stream Is Nothing) Then
            Dim bmp As Bitmap = New Bitmap(stream)
            If print1.DrawBitmap(bmp, 0.0, y, 0.8, 0.0, True) = True Then
                y += 0.9
            End If
        End If

        print1.LineColor = Color.Blue

        ' set line width of 0.05 inches
        print1.LineWidth = 0.05

        ' print 3 blue lines of 2, 1.5 and 1 inches in length
        print1.DrawLine(0, y, 2.0, y)
        y += 0.3
        print1.DrawLine(0, y, 1.5, y)
        y += 0.3
        print1.DrawLine(0, y, 1.0, y)
        y += 0.3

        ' set yellow line colour
        print1.LineColor = Color.Yellow

        ' set green fill colour
        print1.FillColor = Color.Green

        ' print rectangle of 2 inches in length and 0.5 inch in width
        print1.DrawRect(0.0, y, 2.0, y + 0.5)

        ' set line width of 0.01 inches
        print1.LineWidth = 0.01

        ' set black line colour
        print1.LineColor = Color.Black

        ' set red fill colour
        print1.FillColor = Color.Red

        ' print ellipse inside the rectangle
        print1.DrawEllipse(0.5, y + 0.05, 1.5, y + 0.45)

        y += 0.9

        ' print text with 9 points font 
        print1.FontBold = False
        print1.FontSize = 9.0
        print1.DrawText("http:\\www.inesoft.com", 0, y)

        ' end printing document
        print1.EndDoc()

        ' library deinitialization
        print1.UnInit()

        ' show message for user
        If (silent) Then
            MessageBox.Show("Silent printing done !", "Sample PrintCE")
        End If
    End Sub
End Class
