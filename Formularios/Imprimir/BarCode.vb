Imports iTextSharp.text.pdf
Imports iTextSharp.text.pdf.BarcodeCodabar
Imports iTextSharp.text.pdf.BarcodeEAN
Imports iTextSharp.text.pdf.Barcode39
Imports iTextSharp.text.pdf.Barcode128
Imports iTextSharp.text.pdf.BarcodePDF417
Imports iTextSharp.text.pdf.BarcodeDatamatrix

Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D


Public NotInheritable Class BarCode
    Private Sub New()
    End Sub

#Region "Codabar"
 

    'Public Shared Function CodeCodABAR(ByVal _code As String, Optional ByVal PrintTextInCode As Boolean = False, Optional ByVal Height As Single = 0, Optional ByVal GenerateChecksum As Boolean = False, Optional ByVal ChecksumText As Boolean = False) As Bitmap
    '    If _code.Trim = "" Then
    '        Return Nothing
    '    Else
    '        Dim barcode As New BarcodeCodabar
    '        barcode.StartStopText = True
    '        barcode.GenerateChecksum = GenerateChecksum
    '        barcode.ChecksumText = ChecksumText
    '        If Height <> 0 Then barcode.BarHeight = Height
    '        barcode.Code = _code
    '        Try
    '            Dim bm As New System.Drawing.Bitmap(barcode.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White))
    '            If PrintTextInCode = False Then
    '                Return bm
    '            Else
    '                Dim bmT As Image
    '                bmT = New Bitmap(bm.Width, bm.Height + 14)
    '                Dim g As Graphics = Graphics.FromImage(bmT)
    '                g.FillRectangle(New SolidBrush(Color.White), 0, 0, bm.Width, bm.Height + 14)

    '                Dim drawFont As New Font("Arial", 8)
    '                Dim drawBrush As New SolidBrush(Color.Black)

    '                Dim stringSize As New SizeF
    '                stringSize = g.MeasureString(_code, drawFont)
    '                Dim xCenter As Single = (bm.Width - stringSize.Width) / 2
    '                Dim x As Single = xCenter
    '                Dim y As Single = bm.Height

    '                Dim drawFormat As New StringFormat
    '                drawFormat.FormatFlags = StringFormatFlags.NoWrap

    '                g.DrawImage(bm, 0, 0)
    '                'en el codabar no mostrar la primera letra ni la última, ya que representan estados internos del codigo
    '                Dim _ncode As String = _code.Substring(1, _code.Length - 2)
    '                g.DrawString(_ncode, drawFont, drawBrush, x, y, drawFormat)

    '                Return bmT
    '            End If
    '        Catch ex As Exception
    '            Throw New Exception("Error generating EAN13 barcode. Desc:" & ex.Message)
    '        End Try
    '    End If
    'End Function
#End Region


#Region "Code 128"
    'Public Enum Code128SubTypes
    '    'CODABAR = iTextSharp.text.pdf.Barcode.CODABAR
    '    CODE128 = iTextSharp.text.pdf.Barcode.CODE128
    '    CODE128_RAW = iTextSharp.text.pdf.Barcode.CODE128_RAW
    '    CODE128_UCC = iTextSharp.text.pdf.Barcode.CODE128_UCC

    'End Enum
    'Public Shared Function Code128(ByVal _code As String, Optional ByVal codeType As Integer = Code128SubTypes.CODE128, _
    '                               Optional ByVal PrintTextInCode As Boolean = False, Optional ByVal Height As Single = 0, _
    '                                   Optional ByVal GenerateChecksum As Boolean = True, Optional ByVal ChecksumText As Boolean = True) As Bitmap
    '    If _code.Trim = "" Then
    '        Return Nothing
    '    Else
    '        Dim barcode As New Barcode128

    '        barcode.CodeType = codeType
    '        barcode.StartStopText = True
    '        barcode.GenerateChecksum = GenerateChecksum
    '        barcode.ChecksumText = ChecksumText
    '        If Height <> 0 Then barcode.BarHeight = Height
    '        barcode.Code = _code
    '        Try
    '            Dim bm As New System.Drawing.Bitmap(barcode.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White))
    '            If PrintTextInCode = False Then
    '                Return bm
    '            Else
    '                Dim bmT As Image
    '                bmT = New Bitmap(bm.Width, bm.Height + 14)
    '                Dim g As Graphics = Graphics.FromImage(bmT)
    '                g.FillRectangle(New SolidBrush(Color.White), 0, 0, bm.Width, bm.Height + 14)

    '                Dim drawFont As New Font("Arial", 8)
    '                Dim drawBrush As New SolidBrush(Color.Black)

    '                Dim stringSize As New SizeF
    '                stringSize = g.MeasureString(_code, drawFont)
    '                Dim xCenter As Single = (bm.Width - stringSize.Width) / 2
    '                Dim x As Single = xCenter
    '                Dim y As Single = bm.Height

    '                Dim drawFormat As New StringFormat
    '                drawFormat.FormatFlags = StringFormatFlags.NoWrap

    '                g.DrawImage(bm, 0, 0)
    '                g.DrawString(_code, drawFont, drawBrush, x, y, drawFormat)

    '                Return bmT
    '            End If
    '        Catch ex As Exception
    '            Throw New Exception("Error generating code128 barcode. Desc:" & ex.Message)
    '        End Try
    '    End If
    'End Function
#End Region



End Class
