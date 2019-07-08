Imports System.Runtime.InteropServices

Namespace PrintCENET

    Public Class PrintCE_LoadLib_Exception
        Inherits System.Exception
        Public Overrides ReadOnly Property Message() As String
            Get
                Return "PrintCE.dll not found"
            End Get
        End Property
    End Class

    Public Class PrintCE_VersionLib_Exception
        Inherits System.Exception
        Public Overrides ReadOnly Property Message() As String
            Get
                Return "You need PrintCE.dll version 2.5 or higher"
            End Get
        End Property
    End Class

    Public Enum MeasureUnit
        kPixels = 0
        kInches
        kMillimeters
        kCentimeters
        kPoints
    End Enum

    Public Enum TextHorAlign
        hLeft = 0
        hRight
        hCenter
    End Enum

    Public Enum TextVertAlign
        vTop = 0
        vBottom
        vCenter
    End Enum

    Public Enum FillStyle
        Transparent = 0
		Opaque = 1
    End Enum

    Public Enum ASCII_PORT
        ASCII_NONE = -1
        ASCII_IR = 0
        ASCII_COM1 = 1
        ASCII_COM2 = 2
        ASCII_COM3 = 3
        ASCII_COM4 = 4
        ASCII_COM5 = 5
        ASCII_COM6 = 6
        ASCII_COM7 = 7
        ASCII_COM8 = 8
        ASCII_FILE = 9
        ASCII_NET = 10
        ASCII_COM9 = 11
        ASCII_COM10 = 12
        ASCII_COM11 = 13
        ASCII_COM12 = 14
        ASCII_BTBROAD = 15
        ASCII_BTMSOFT = 16
        ASCII_LPT1 = 17
        ASCII_USB = 18
    End Enum

    Public Structure PrintInfo
        Public printer As Int32
        Public port As Int32
        Public paper As Int32
        Public paper_width As Int32
        Public paper_height As Int32
        Public color_mode As Int32
        Public portrait As Boolean
        Public draft_mode As Boolean
        Public left_margin As Int32
        Public top_margin As Int32
        Public right_margin As Int32
        Public bottom_margin As Int32
        Public start_page As Int32
        Public end_page As Int32
    End Structure

    Public Class PrintCE
        Public Sub New()
            If LoadLibrary("PrintCE.dll") = 0 Then
                Throw (New PrintCE_LoadLib_Exception)
            End If
            If prnGetVersion() / 1000.0 < 2.5 Then
                Throw (New PrintCE_VersionLib_Exception)
            End If
        End Sub
        <StructLayout(LayoutKind.Sequential)> _
         Private Structure PRNINFO
            Public printer As Int32
            Public port As Int32
            Public paper As Int32
            Public paper_size_x As Int32
            Public paper_size_y As Int32
            Public color_mode As Int32
            Public portrait As Int32
            Public draft_mode As Int32
            Public margin_left As Int32
            Public margin_top As Int32
            Public margin_right As Int32
            Public margin_bottom As Int32
            Public start_page As Int32
            Public end_page As Int32
        End Structure
        <DllImport("CoreDll.dll", EntryPoint:="LoadLibrary", SetLastError:=True)> _
        Private Shared Function LoadLibrary(ByVal lpFileName As String) As Int32
        End Function
        <DllImport("CoreDll.dll", EntryPoint:="DeleteObject", SetLastError:=True)> _
        Private Shared Function DeleteObject(ByVal hObject As IntPtr) As Boolean
        End Function
        <DllImport("PrintCE.dll", EntryPoint:="prnInit")> _
        Private Shared Sub prnInit(ByVal szLicenseKey As String)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="prnUnInit")> _
        Private Shared Sub prnUnInit()
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="prnSetupDlg")> _
        Private Shared Function prnSetupDlg(ByVal parent As IntPtr) As Boolean
        End Function
        <DllImport("PrintCE.dll", EntryPoint:="prnSilentPrintSetup")> _
        Private Shared Function prnSilentPrintSetup(ByVal parent As IntPtr, ByRef info As PRNINFO) As Boolean
        End Function
        <DllImport("PrintCE.dll", EntryPoint:="prnGetCurrentSetup")> _
        Private Shared Sub prnGetCurrentSetup(ByRef info As PRNINFO)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="prnGetState")> _
        Private Shared Function prnGetState() As Int32
        End Function
        <DllImport("PrintCE.dll", EntryPoint:="prnIsConnection")> _
        Private Shared Function prnIsConnection() As Int32
        End Function
        <DllImport("PrintCE.dll", EntryPoint:="prnStartDoc")> _
        Private Shared Function prnStartDoc() As Int32
        End Function
        <DllImport("PrintCE.dll", EntryPoint:="prnStartPage")> _
        Private Shared Function prnStartPage() As Int32
        End Function
        <DllImport("PrintCE.dll", EntryPoint:="prnEndDoc")> _
        Private Shared Function prnEndDoc() As Int32
        End Function
        <DllImport("PrintCE.dll", EntryPoint:="NETprnDrawTextFlow")> _
        Private Shared Function NETprnDrawTextFlow(ByVal lpString As String, ByRef x As Double, ByRef y As Double, ByRef width As Double, ByRef height As Double) As Int32
        End Function
        <DllImport("PrintCE.dll", EntryPoint:="NETprnGetTextFlowHeight")> _
        Private Shared Sub NETprnGetTextFlowHeight(ByVal lpString As String, ByRef width As Double, ByRef ret_val As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETprnDrawText")> _
        Private Shared Sub NETprnDrawText(ByVal lpString As String, ByRef x As Double, ByRef y As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETprnDrawText2")> _
        Private Shared Sub NETprnDrawText2(ByVal lpString As String, ByRef x As Double, ByRef y As Double, ByVal color As Int32)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETprnDrawAlignedText")> _
        Private Shared Sub NETprnDrawAlignedText(ByVal lpString As String, ByRef x As Double, ByRef y As Double, ByVal hor_align As Int32, ByVal vert_align As Int32)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETprnDrawEllipse")> _
        Private Shared Sub NETprnDrawEllipse(ByRef x1 As Double, ByRef y1 As Double, ByRef x2 As Double, ByRef y2 As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETprnDrawCircle")> _
        Private Shared Sub NETprnDrawCircle(ByRef x1 As Double, ByRef y1 As Double, ByRef radius As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETprnDrawLine")> _
        Private Shared Sub NETprnDrawLine(ByRef x1 As Double, ByRef y1 As Double, ByRef x2 As Double, ByRef y2 As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETprnDrawRect")> _
        Private Shared Sub NETprnDrawRect(ByRef x1 As Double, ByRef y1 As Double, ByRef x2 As Double, ByRef y2 As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETprnDrawSolidRect")> _
        Private Shared Sub NETprnDrawSolidRect(ByRef x1 As Double, ByRef y1 As Double, ByRef x2 As Double, ByRef y2 As Double, ByVal color As Int32)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETprnDrawRoundRect")> _
        Private Shared Sub NETprnDrawRoundRect(ByRef x1 As Double, ByRef y1 As Double, ByRef x2 As Double, ByRef y2 As Double, ByRef width As Double, ByRef height As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETprnDrawPicture")> _
        Private Shared Function NETprnDrawPicture(ByVal path As String, ByRef x As Double, ByRef y As Double, ByRef width As Double, ByRef height As Double, ByVal keep_aspect As Boolean) As Boolean
        End Function
        <DllImport("PrintCE.dll", EntryPoint:="NETprnDrawBitmap")> _
        Private Shared Function NETprnDrawBitmap(ByVal hBitmap As IntPtr, ByRef x As Double, ByRef y As Double, ByRef width As Double, ByRef height As Double, ByVal keep_aspect As Boolean) As Boolean
        End Function
        <DllImport("PrintCE.dll", EntryPoint:="prnGetPictureSize")> _
        Private Shared Function prnGetPictureSize(ByVal path As String, ByRef width As Double, ByRef height As Double) As Boolean
        End Function
        <DllImport("PrintCE.dll", EntryPoint:="NETprnConvertValue")> _
        Private Shared Sub NETprnConvertValue(ByRef value As Double, ByVal fromv As Int32, ByVal tov As Int32, ByRef ret_val As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="prnSetMeasureUnit")> _
        Private Shared Sub prnSetMeasureUnit(ByVal val As Int32)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="prnGetMeasureUnit")> _
        Private Shared Function prnGetMeasureUnit() As Int32
        End Function
        <DllImport("PrintCE.dll", EntryPoint:="NETprnSetLineWidth")> _
        Private Shared Sub NETprnSetLineWidth(ByRef val As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETprnGetLineWidth")> _
        Private Shared Sub NETprnGetLineWidth(ByRef width As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="prnSetLineColor")> _
        Private Shared Sub prnSetLineColor(ByVal val As Int32)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="prnGetLineColor")> _
        Private Shared Function prnGetLineColor() As Int32
        End Function
        <DllImport("PrintCE.dll", EntryPoint:="prnSetFillColor")> _
        Private Shared Sub prnSetFillColor(ByVal val As Int32)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="prnGetFillColor")> _
        Private Shared Function prnGetFillColor() As Int32
        End Function
        <DllImport("PrintCE.dll", EntryPoint:="prnSetFillStyle")> _
        Private Shared Sub prnSetFillStyle(ByVal val As Int32)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="prnGetFillStyle")> _
        Private Shared Function prnGetFillStyle() As Int32
        End Function
        <DllImport("PrintCE.dll", EntryPoint:="prnSetTextColor")> _
        Private Shared Sub prnSetTextColor(ByVal val As Int32)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="prnGetTextColor")> _
        Private Shared Function prnGetTextColor() As Int32
        End Function
        <DllImport("PrintCE.dll", EntryPoint:="prnSetFontName")> _
        Private Shared Sub prnSetFontName(ByVal name As String)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETprnGetFontName")> _
        Private Shared Sub NETprnGetFontName(ByRef name As Char)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETprnSetFontSize")> _
        Private Shared Sub NETprnSetFontSize(ByRef val As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETprnGetFontSize")> _
        Private Shared Sub NETprnGetFontSize(ByRef size As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="prnSetFontBold")> _
        Private Shared Sub prnSetFontBold(ByVal val As Boolean)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="prnGetFontBold")> _
        Private Shared Function prnGetFontBold() As Boolean
        End Function
        <DllImport("PrintCE.dll", EntryPoint:="prnSetFontItalic")> _
        Private Shared Sub prnSetFontItalic(ByVal val As Boolean)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="prnGetFontItalic")> _
        Private Shared Function prnGetFontItalic() As Boolean
        End Function
        <DllImport("PrintCE.dll", EntryPoint:="prnSetFontStrike")> _
        Private Shared Sub prnSetFontStrike(ByVal val As Boolean)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="prnGetFontStrike")> _
        Private Shared Function prnGetFontStrike() As Boolean
        End Function
        <DllImport("PrintCE.dll", EntryPoint:="prnSetFontUnderline")> _
        Private Shared Sub prnSetFontUnderline(ByVal val As Boolean)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="prnGetFontUnderline")> _
        Private Shared Function prnGetFontUnderline() As Boolean
        End Function
        <DllImport("PrintCE.dll", EntryPoint:="NETprnGetTextHeight")> _
        Private Shared Sub NETprnGetTextHeight(ByVal str As String, ByRef height As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETprnGetTextWidth")> _
        Private Shared Sub NETprnGetTextWidth(ByVal str As String, ByRef width As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETprnGetPageHeight")> _
        Private Shared Sub NETprnGetPageHeight(ByRef height As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETprnGetPageWidth")> _
        Private Shared Sub NETprnGetPageWidth(ByRef width As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETprnGetLeftMargin")> _
        Private Shared Sub NETprnGetLeftMargin(ByRef margin As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETprnSetLeftMargin")> _
        Private Shared Sub NETprnSetLeftMargin(ByRef val As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETprnGetRightMargin")> _
        Private Shared Sub NETprnGetRightMargin(ByRef margin As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETprnSetRightMargin")> _
        Private Shared Sub NETprnSetRightMargin(ByRef val As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETprnGetTopMargin")> _
        Private Shared Sub NETprnGetTopMargin(ByRef margin As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETprnSetTopMargin")> _
        Private Shared Sub NETprnSetTopMargin(ByRef val As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETprnGetBottomMargin")> _
        Private Shared Sub NETprnGetBottomMargin(ByRef margin As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETprnSetBottomMargin")> _
        Private Shared Sub NETprnSetBottomMargin(ByRef val As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="prnGetVersion")> _
        Private Shared Function prnGetVersion() As Int32
        End Function
        <DllImport("PrintCE.dll", EntryPoint:="prnSetSilentMode")> _
        Private Shared Sub prnSetSilentMode(ByVal silent As Boolean)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="prnGetSentBytes")> _
        Private Shared Function prnGetSentBytes() As Int32
        End Function
        <DllImport("PrintCE.dll", EntryPoint:="prnSetTransparentTextBgr")> _
        Private Shared Sub prnSetTransparentTextBgr(ByVal val As Boolean)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="prnSetTextHorAlign")> _
        Private Shared Sub prnSetTextHorAlign(ByVal val As Int32)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="prnSetTextVertAlign")> _
        Private Shared Sub prnSetTextVertAlign(ByVal val As Int32)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="prnSetPDFFile")> _
        Private Shared Sub prnSetPDFFile(ByVal pdf_file As String)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="prnSetLanguage")> _
        Private Shared Sub prnSetLanguage(ByVal lang_id As Int32)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="prnSetPrnParam")> _
        Private Shared Sub prnSetPrnParam(ByVal param As Int32, ByVal val As Int32)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="prnSetFontAngle")> _
        Private Shared Sub prnSetFontAngle(ByVal val As Int32)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="prnGetFontAngle")> _
        Private Shared Function prnGetFontAngle() As Int32
        End Function
        <DllImport("PrintCE.dll", EntryPoint:="NETprnDrawCodaBar")> _
        Private Shared Sub NETprnDrawCodaBar(ByVal str As String, ByRef pos_x As Double, ByRef pos_y As Double, ByVal add_text As Boolean, ByVal thickness As Int32, ByRef ret_val As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETprnDrawPostnet")> _
        Private Shared Sub NETprnDrawPostnet(ByVal str As String, ByRef pos_x As Double, ByRef pos_y As Double, ByVal add_text As Boolean, ByRef ret_val As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETprnDrawCode39")> _
        Private Shared Sub NETprnDrawCode39(ByVal str As String, ByRef pos_x As Double, ByRef pos_y As Double, ByVal checksum As Boolean, ByVal add_text As Boolean, ByVal thickness As Int32, ByRef ret_val As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETprnDrawCode93")> _
        Private Shared Sub NETprnDrawCode93(ByVal str As String, ByRef pos_x As Double, ByRef pos_y As Double, ByVal add_text As Boolean, ByVal thickness As Int32, ByRef ret_val As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETprnDrawEAN13")> _
        Private Shared Sub NETprnDrawEAN13(ByVal str As String, ByVal add_str As String, ByRef pos_x As Double, ByRef pos_y As Double, ByVal add_text As Boolean, ByVal thickness As Int32, ByRef ret_val As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETprnDrawEAN8")> _
        Private Shared Sub NETprnDrawEAN8(ByVal str As String, ByVal add_str As String, ByRef pos_x As Double, ByRef pos_y As Double, ByVal add_text As Boolean, ByVal thickness As Int32, ByRef ret_val As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETprnDrawUPCA")> _
        Private Shared Sub NETprnDrawUPCA(ByVal str As String, ByVal add_str As String, ByRef pos_x As Double, ByRef pos_y As Double, ByVal add_text As Boolean, ByVal thickness As Int32, ByRef ret_val As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETprnDrawUPCE")> _
        Private Shared Sub NETprnDrawUPCE(ByVal str As String, ByVal add_str As String, ByRef pos_x As Double, ByRef pos_y As Double, ByVal add_text As Boolean, ByVal thickness As Int32, ByRef ret_val As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETprnDraw2OF5")> _
        Private Shared Sub NETprnDraw2OF5(ByVal str As String, ByRef pos_x As Double, ByRef pos_y As Double, ByVal checksum As Boolean, ByVal add_text As Boolean, ByVal thickness As Int32, ByRef ret_val As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETprnDrawCode128")> _
        Private Shared Sub NETprnDrawCode128(ByVal str As String, ByRef pos_x As Double, ByRef pos_y As Double, ByVal add_text As Boolean, ByVal thickness As Int32, ByRef ret_val As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETprnDrawUCC128")> _
        Private Shared Sub NETprnDrawUCC128(ByVal str As String, ByRef pos_x As Double, ByRef pos_y As Double, ByVal add_text As Boolean, ByVal thickness As Int32, ByRef ret_val As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETprnDrawMSI")> _
        Private Shared Sub NETprnDrawMSI(ByVal str As String, ByRef pos_x As Double, ByRef pos_y As Double, ByVal add_text As Boolean, ByVal checksum_type As Int32, ByVal thickness As Int32, ByRef ret_val As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETprnDrawPDF417")> _
              Private Shared Sub NETprnDrawPDF417(ByVal str As String, ByRef pos_x As Double, ByRef pos_y As Double, ByVal columns As Int32, ByVal rows As Int32, ByVal trun_symbol As Boolean, ByVal add_text As Boolean, ByRef ret_val As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETSetBarCodeHeight")> _
        Private Shared Sub NETSetBarCodeHeight(ByRef height As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETGetBarCodeHeight")> _
        Private Shared Sub NETGetBarCodeHeight(ByRef height As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="NETSetBarCodeScale")> _
              Private Shared Sub NETSetBarCodeScale(ByRef scale As Double)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="prnSetBarCodeAngle")> _
              Private Shared Sub prnSetBarCodeAngle(ByVal angle As Int32)
        End Sub

        Public Property MeasureUnit() As MeasureUnit
            Get
                Return prnGetMeasureUnit()
            End Get

            Set(ByVal Value As MeasureUnit)
                prnSetMeasureUnit(Value)
            End Set
        End Property
        Public Property LineWidth() As Double
            Get
                Dim width As Double
                NETprnGetLineWidth(width)
                Return width
            End Get

            Set(ByVal Value As Double)
                NETprnSetLineWidth(Value)
            End Set
        End Property
        Public Property LineColor() As Color
            Get
                Return Color.FromArgb(prnGetLineColor())
            End Get

            Set(ByVal Value As Color)
                prnSetLineColor(ColorToBGR(Value))
            End Set
        End Property
        Public Property FillColor() As Color
            Get
                Return Color.FromArgb(prnGetFillColor())
            End Get

            Set(ByVal Value As Color)
                prnSetFillColor(ColorToBGR(Value))
            End Set
        End Property
        Public Property FillStyle() As FillStyle
            Get
                Return prnGetFillStyle()
            End Get

            Set(ByVal Value As FillStyle)
                prnSetFillStyle(Value)
            End Set
        End Property
        Public Property TextColor() As Color
            Get
                Return Color.FromArgb(prnGetTextColor())
            End Get

            Set(ByVal Value As Color)
                prnSetTextColor(ColorToBGR(Value))
            End Set
        End Property
        Public Property FontName() As String
            Get
                Dim str(100) As Char
                NETprnGetFontName(str(0))
                Return New String(str)
            End Get

            Set(ByVal Value As String)
                prnSetFontName(Value)
            End Set
        End Property
        Public Property FontSize() As Double
            Get
                Dim size As Double
                NETprnGetFontSize(size)
                Return size
            End Get

            Set(ByVal Value As Double)
                NETprnSetFontSize(Value)
            End Set
        End Property
        Public Property FontAngle() As Int32
            Get
                Return prnGetFontAngle()
            End Get

            Set(ByVal Value As Int32)
                prnSetFontAngle(Value)
            End Set
        End Property
        Public Property FontBold() As Boolean
            Get
                Return prnGetFontBold()
            End Get

            Set(ByVal Value As Boolean)
                prnSetFontBold(Value)
            End Set
        End Property
        Public Property FontItalic() As Boolean
            Get
                Return prnGetFontItalic()
            End Get

            Set(ByVal Value As Boolean)
                prnSetFontItalic(Value)
            End Set
        End Property
        Public Property FontStrike() As Boolean
            Get
                Return prnGetFontStrike()
            End Get

            Set(ByVal Value As Boolean)
                prnSetFontStrike(Value)
            End Set
        End Property
        Public Property FontUnderline() As Boolean
            Get
                Return prnGetFontUnderline()
            End Get

            Set(ByVal Value As Boolean)
                prnSetFontUnderline(Value)
            End Set
        End Property
        Public ReadOnly Property PageHeight() As Double
            Get
                Dim height As Double
                NETprnGetPageHeight(height)
                Return height
            End Get
        End Property
        Public ReadOnly Property PageWidth() As Double
            Get
                Dim width As Double
                NETprnGetPageWidth(width)
                Return width
            End Get
        End Property
        Public Property LeftMargin() As Double
            Get
                Dim margin As Double
                NETprnGetLeftMargin(margin)
                Return margin
            End Get

            Set(ByVal Value As Double)
                NETprnSetLeftMargin(Value)
            End Set
        End Property
        Public Property RightMargin() As Double
            Get
                Dim margin As Double
                NETprnGetRightMargin(margin)
                Return margin
            End Get

            Set(ByVal Value As Double)
                NETprnSetRightMargin(Value)
            End Set
        End Property
        Public Property TopMargin() As Double
            Get
                Dim margin As Double
                NETprnGetTopMargin(margin)
                Return margin
            End Get

            Set(ByVal Value As Double)
                NETprnSetTopMargin(Value)
            End Set
        End Property
        Public Property BottomMargin() As Double
            Get
                Dim margin As Double
                NETprnGetBottomMargin(margin)
                Return margin
            End Get

            Set(ByVal Value As Double)
                NETprnSetBottomMargin(Value)
            End Set
        End Property
        Public ReadOnly Property Connection() As Int32
            Get
                Return prnIsConnection()
            End Get
        End Property
        Public ReadOnly Property Version() As Int32
            Get
                Return prnGetVersion()
            End Get
        End Property
        Public WriteOnly Property SilentMode() As Boolean
            Set(ByVal Value As Boolean)
                prnSetSilentMode(Value)
            End Set
        End Property
        Public ReadOnly Property SentBytes() As Int32
            Get
                Return prnGetSentBytes()
            End Get
        End Property
        Public WriteOnly Property TransparentTextBgr() As Boolean
            Set(ByVal Value As Boolean)
                prnSetTransparentTextBgr(Value)
            End Set
        End Property
        Public WriteOnly Property TextHorAlign() As TextHorAlign
            Set(ByVal Value As TextHorAlign)
                prnSetTextHorAlign(Value)
            End Set
        End Property
        Public WriteOnly Property TextVertAlign() As TextVertAlign
            Set(ByVal Value As TextVertAlign)
                prnSetTextVertAlign(Value)
            End Set
        End Property
        Public WriteOnly Property PDFFile() As String
            Set(ByVal Value As String)
                prnSetPDFFile(Value)
            End Set
        End Property
        Public WriteOnly Property Language() As Int32
            Set(ByVal Value As Int32)
                prnSetLanguage(Value)
            End Set
        End Property
        Public ReadOnly Property State() As Int32
            Get
                Return prnGetState()
            End Get
        End Property
        Public Sub Init(ByVal szLicenseKey As String)
            prnInit(szLicenseKey)
        End Sub
        Public Sub UnInit()
            prnUnInit()
        End Sub
        Public Function SetupDlg(ByVal parent As IntPtr) As Boolean
            Return prnSetupDlg(parent)
        End Function
        Public Function StartDoc() As Int32
            Return prnStartDoc()
        End Function
        Public Function StartPage() As Int32
            Return prnStartPage()
        End Function
        Public Function EndDoc() As Int32
            Return prnEndDoc()
        End Function
        Public Function DrawTextFlow(ByVal lpString As String, ByVal x As Double, ByVal y As Double, ByVal width As Double, ByVal height As Double) As Int32
            Return NETprnDrawTextFlow(lpString, x, y, width, height)
        End Function
        Public Function GetTextFlowHeight(ByVal lpString As String, ByVal width As Double) As Double
            Dim ret_val As Double
            NETprnGetTextFlowHeight(lpString, width, ret_val)
            Return ret_val
        End Function
        Public Sub DrawText(ByVal lpString As String, ByVal x As Double, ByVal y As Double)
            NETprnDrawText(lpString, x, y)
        End Sub
        Public Sub DrawText2(ByVal lpString As String, ByVal x As Double, ByVal y As Double, ByVal color As Color)
            NETprnDrawText2(lpString, x, y, ColorToBGR(color))
        End Sub
        Public Sub DrawAlignedText(ByVal lpString As String, ByVal x As Double, ByVal y As Double, ByVal hor_align As TextHorAlign, ByVal vert_align As TextVertAlign)
            NETprnDrawAlignedText(lpString, x, y, hor_align, vert_align)
        End Sub
        Public Sub DrawEllipse(ByVal x1 As Double, ByVal y1 As Double, ByVal x2 As Double, ByVal y2 As Double)
            NETprnDrawEllipse(x1, y1, x2, y2)
        End Sub
        Public Sub DrawCircle(ByVal x1 As Double, ByVal y1 As Double, ByVal radius As Double)
            NETprnDrawCircle(x1, y1, radius)
        End Sub
        Public Sub DrawLine(ByVal x1 As Double, ByVal y1 As Double, ByVal x2 As Double, ByVal y2 As Double)
            NETprnDrawLine(x1, y1, x2, y2)
        End Sub
        Public Sub DrawRect(ByVal x1 As Double, ByVal y1 As Double, ByVal x2 As Double, ByVal y2 As Double)
            NETprnDrawRect(x1, y1, x2, y2)
        End Sub
        Public Sub DrawSolidRect(ByVal x1 As Double, ByVal y1 As Double, ByVal x2 As Double, ByVal y2 As Double, ByVal color As Color)
            NETprnDrawSolidRect(x1, y1, x2, y2, ColorToBGR(color))
        End Sub
        Public Sub DrawRoundRect(ByVal x1 As Double, ByVal y1 As Double, ByVal x2 As Double, ByVal y2 As Double, ByVal width As Double, ByVal height As Double)
            NETprnDrawRoundRect(x1, y1, x2, y2, width, height)
        End Sub
        Public Function DrawPicture(ByVal path As String, ByVal x As Double, ByVal y As Double, ByVal width As Double, ByVal height As Double, ByVal keep_aspect As Boolean) As Boolean
            Return NETprnDrawPicture(path, x, y, width, height, keep_aspect)
        End Function
        Public Function DrawBitmap(ByVal bitmap As Bitmap, ByVal x As Double, ByVal y As Double, ByVal width As Double, ByVal height As Double, ByVal keep_aspect As Boolean) As Boolean
            Dim hBmp As IntPtr
            Dim ret_val As Boolean
            hBmp = bitmap.GetHbitmap()
            ret_val = NETprnDrawBitmap(hBmp, x, y, width, height, keep_aspect)
            DeleteObject(hBmp)
            Return ret_val
        End Function

        Public Function GetPictureSize(ByVal path As String, ByRef width As Double, ByRef height As Double) As Boolean
            width = 0.0
            height = 0.0
            Return prnGetPictureSize(path, width, height)
        End Function
        Public Function ConvertValue(ByVal val As Double, ByVal from_m As MeasureUnit, ByVal to_m As MeasureUnit) As Double
            Dim ret_val As Double
            NETprnConvertValue(val, from_m, to_m, ret_val)
            Return ret_val
        End Function
        Public Function GetTextHeight(ByVal str As String) As Double
            Dim height As Double
            NETprnGetTextHeight(str, height)
            Return height
        End Function
        Public Function GetTextWidth(ByVal str As String) As Double
            Dim width As Double
            NETprnGetTextWidth(str, width)
            Return width
        End Function
        Public Function SilentPrintSetup(ByVal parent As IntPtr, ByVal info As PrintInfo) As Boolean
            Dim prn_info As PRNINFO = New PRNINFO
            prn_info.printer = info.printer
            prn_info.port = info.port
            prn_info.paper = info.paper
            prn_info.paper_size_x = info.paper_width
            prn_info.paper_size_y = info.paper_height
            prn_info.color_mode = info.color_mode
            prn_info.portrait = info.portrait
            prn_info.draft_mode = info.draft_mode
            prn_info.margin_left = info.left_margin
            prn_info.margin_right = info.right_margin
            prn_info.margin_top = info.top_margin
            prn_info.margin_bottom = info.bottom_margin
            prn_info.start_page = info.start_page
            prn_info.end_page = info.end_page
            Return prnSilentPrintSetup(parent, prn_info)
        End Function
        Public Sub GetCurrentSetup(ByRef info As PrintInfo)
            Dim prn_info As PRNINFO = New PRNINFO
            prnGetCurrentSetup(prn_info)
            info.printer = prn_info.printer
            info.port = prn_info.port
            info.paper = prn_info.paper
            info.paper_width = prn_info.paper_size_x
            info.paper_height = prn_info.paper_size_y
            info.color_mode = prn_info.color_mode
            info.portrait = prn_info.portrait
            info.draft_mode = prn_info.draft_mode
            info.left_margin = prn_info.margin_left
            info.right_margin = prn_info.margin_right
            info.top_margin = prn_info.margin_top
            info.bottom_margin = prn_info.margin_bottom
            info.start_page = prn_info.start_page
            info.end_page = prn_info.end_page
        End Sub
        Public Sub SetPrnParam(ByVal param As Int32, ByVal val As Int32)
            prnSetPrnParam(param, val)
        End Sub

        Public Function DrawCodaBar(ByVal str As String, ByVal pos_x As Double, ByVal pos_y As Double, ByVal add_text As Boolean, ByVal thickness As Int32) As Double
            Dim ret_val As Double
            NETprnDrawCodaBar(str, pos_x, pos_y, add_text, thickness, ret_val)
            Return ret_val
        End Function
        Public Function DrawPostnet(ByVal str As String, ByVal pos_x As Double, ByVal pos_y As Double, ByVal add_text As Boolean) As Double
            Dim ret_val As Double
            NETprnDrawPostnet(str, pos_x, pos_y, add_text, ret_val)
            Return ret_val
        End Function
        Public Function DrawCode39(ByVal str As String, ByVal pos_x As Double, ByVal pos_y As Double, ByVal checksum As Boolean, ByVal add_text As Boolean, ByVal thickness As Int32) As Double
            Dim ret_val As Double
            NETprnDrawCode39(str, pos_x, pos_y, checksum, add_text, thickness, ret_val)
            Return ret_val
        End Function
        Public Function DrawCode93(ByVal str As String, ByVal pos_x As Double, ByVal pos_y As Double, ByVal add_text As Boolean, ByVal thickness As Int32) As Double
            Dim ret_val As Double
            NETprnDrawCode93(str, pos_x, pos_y, add_text, thickness, ret_val)
            Return ret_val
        End Function
        Public Function DrawEAN13(ByVal str As String, ByVal add_str As String, ByVal pos_x As Double, ByVal pos_y As Double, ByVal add_text As Boolean, ByVal thickness As Int32) As Double
            Dim ret_val As Double
            NETprnDrawEAN13(str, add_str, pos_x, pos_y, add_text, thickness, ret_val)
            Return ret_val
        End Function
        Public Function DrawEAN8(ByVal str As String, ByVal add_str As String, ByVal pos_x As Double, ByVal pos_y As Double, ByVal add_text As Boolean, ByVal thickness As Int32) As Double
            Dim ret_val As Double
            NETprnDrawEAN8(str, add_str, pos_x, pos_y, add_text, thickness, ret_val)
            Return ret_val
        End Function
        Public Function DrawUPCA(ByVal str As String, ByVal add_str As String, ByVal pos_x As Double, ByVal pos_y As Double, ByVal add_text As Boolean, ByVal thickness As Int32) As Double
            Dim ret_val As Double
            NETprnDrawUPCA(str, add_str, pos_x, pos_y, add_text, thickness, ret_val)
            Return ret_val
        End Function
        Public Function DrawUPCE(ByVal str As String, ByVal add_str As String, ByVal pos_x As Double, ByVal pos_y As Double, ByVal add_text As Boolean, ByVal thickness As Int32) As Double
            Dim ret_val As Double
            NETprnDrawUPCE(str, add_str, pos_x, pos_y, add_text, thickness, ret_val)
            Return ret_val
        End Function
        Public Function Draw2OF5(ByVal str As String, ByVal pos_x As Double, ByVal pos_y As Double, ByVal checksum As Boolean, ByVal add_text As Boolean, ByVal thickness As Int32) As Double
            Dim ret_val As Double
            NETprnDraw2OF5(str, pos_x, pos_y, checksum, add_text, thickness, ret_val)
            Return ret_val
        End Function
        Public Function DrawCode128(ByVal str As String, ByVal pos_x As Double, ByVal pos_y As Double, ByVal add_text As Boolean, ByVal thickness As Int32) As Double
            Dim ret_val As Double
            NETprnDrawCode128(str, pos_x, pos_y, add_text, thickness, ret_val)
            Return ret_val
        End Function
        Public Function DrawUCC128(ByVal str As String, ByVal pos_x As Double, ByVal pos_y As Double, ByVal add_text As Boolean, ByVal thickness As Int32) As Double
            Dim ret_val As Double
            NETprnDrawUCC128(str, pos_x, pos_y, add_text, thickness, ret_val)
            Return ret_val
        End Function
        Public Function DrawMSI(ByVal str As String, ByVal pos_x As Double, ByVal pos_y As Double, ByVal add_text As Boolean, ByVal checksum_type As Int32, ByVal thickness As Int32) As Double
            Dim ret_val As Double
            NETprnDrawMSI(str, pos_x, pos_y, add_text, checksum_type, thickness, ret_val)
            Return ret_val
        End Function
        Public Function NETprnDrawPDF417(ByVal str As String, ByRef pos_x As Double, ByRef pos_y As Double, ByVal columns As Int32, ByVal rows As Int32, ByVal trun_symbol As Boolean, ByVal add_text As Boolean) As Double
            Dim ret_val As Double
            NETprnDrawPDF417(str, pos_x, pos_y, columns, rows, trun_symbol, add_text)
            Return ret_val
        End Function
        Public Property BarcodeHeight() As Double
            Set(ByVal Value As Double)
                NETSetBarCodeHeight(Value)
            End Set
            Get
                Dim ret_val As Double
                NETGetBarCodeHeight(ret_val)
                Return ret_val
            End Get
        End Property
        Public WriteOnly Property BarcodeScale() As Double
            Set(ByVal Value As Double)
                NETSetBarCodeScale(Value)
            End Set
        End Property
        Public WriteOnly Property BarcodeAngle() As Int32
            Set(ByVal Value As Int32)
                prnSetBarCodeAngle(Value)
            End Set
        End Property
        Private Function ColorToBGR(ByVal color As Color) As Int32
            Return (Convert.ToInt32(color.B) << 16) Or (Convert.ToInt32(color.G) << 8) Or color.R
        End Function
    End Class

    Public Class PrintASCII
        <DllImport("CoreDll.dll", EntryPoint:="LoadLibrary", SetLastError:=True)> _
        Private Shared Function LoadLibrary(ByVal lpFileName As String) As Int32
        End Function
        <DllImport("PrintCE.dll", EntryPoint:="ASCII_Init")> _
        Private Shared Sub ASCII_Init(ByVal szLicenseKey As String)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="ASCII_UnInit")> _
        Private Shared Sub ASCII_UnInit()
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="ASCII_SendChar")> _
        Private Shared Function ASCII_SendChar(ByVal ch As Byte) As Int32
        End Function
        <DllImport("PrintCE.dll", EntryPoint:="ASCII_SendString")> _
        Private Shared Function ASCII_SendString(ByVal str As String) As Int32
        End Function
        <DllImport("PrintCE.dll", EntryPoint:="ASCII_SendArray")> _
        Private Shared Function ASCII_SendArray(ByVal array As Byte(), ByVal size As Int32) As Int32
        End Function
        <DllImport("PrintCE.dll", EntryPoint:="ASCII_Connect")> _
        Private Shared Function ASCII_Connect(ByVal port As Int32, ByVal param As String) As Int32
        End Function
        <DllImport("PrintCE.dll", EntryPoint:="ASCII_ConnectSilent")> _
        Private Shared Function ASCII_ConnectSilent(ByVal port As Int32, ByVal param As String) As Int32
        End Function
        <DllImport("PrintCE.dll", EntryPoint:="ASCII_Disconnect")> _
        Private Shared Sub ASCII_Disconnect()
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="ASCII_GetState")> _
        Private Shared Function ASCII_GetState() As Int32
        End Function
        <DllImport("PrintCE.dll", EntryPoint:="ASCII_GetSentBytes")> _
        Private Shared Function ASCII_GetSentBytes() As Int32
        End Function
        <DllImport("PrintCE.dll", EntryPoint:="ASCII_GetVersion")> _
        Private Shared Function ASCII_GetVersion() As Int32
        End Function
        <DllImport("PrintCE.dll", EntryPoint:="ASCII_SetComPortParam")> _
        Private Shared Sub ASCII_SetComPortParam(ByVal BaudRate As Int32, ByVal fParity As Int32, ByVal Parity As Int32, ByVal StopBits As Int32, ByVal ByteSize As Int32, ByVal fOutX As Int32, ByVal fInX As Int32, ByVal fOutxCtsFlow As Int32, ByVal fOutxDsrFlow As Int32, ByVal fDtrControl As Int32, ByVal fRtsControl As Int32, ByVal fDsrSensitivity As Int32, ByVal fTXContinueOnXoff As Int32)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="ASCII_SetLanguage")> _
        Private Shared Sub ASCII_SetLanguage(ByVal lang_id As Int32)
        End Sub
        <DllImport("PrintCE.dll", EntryPoint:="ASCII_SetupPort")> _
        Private Shared Function ASCII_SetupPort(ByVal parent As IntPtr) As Int32
        End Function
        Public Sub New()
            If LoadLibrary("PrintCE.dll") = 0 Then
                Throw (New PrintCE_LoadLib_Exception)
            End If
            If ASCII_GetVersion() / 1000.0 < 2.5 Then
                Throw (New PrintCE_VersionLib_Exception)
            End If
        End Sub
        Public ReadOnly Property State() As Int32
            Get
                Return ASCII_GetState()
            End Get
        End Property
        Public ReadOnly Property SentBytes() As Int32
            Get
                Return ASCII_GetSentBytes()
            End Get
        End Property
        Public ReadOnly Property Version() As Int32
            Get
                Return ASCII_GetVersion()
            End Get
        End Property
        Public WriteOnly Property Language() As Int32
            Set(ByVal Value As Int32)
                ASCII_SetLanguage(Value)
            End Set
        End Property

        Public Sub Init(ByVal szLicenseKey As String)
            ASCII_Init(szLicenseKey)
        End Sub
        Public Sub UnInit()
            ASCII_UnInit()
        End Sub
        Public Function SendByte(ByVal val As Byte) As Boolean
            Return ASCII_SendChar(val)
        End Function
        Public Function SendString(ByVal str As String) As Boolean
            Return ASCII_SendString(str)
        End Function
        Public Function SendBytes(ByVal bytes As Byte(), ByVal count As Int32) As Boolean
            Return ASCII_SendArray(bytes, count)
        End Function
        Public Function Connect(ByVal port As ASCII_PORT, ByVal param As String) As Boolean
            Return ASCII_Connect(port, param)
        End Function
        Public Function ConnectSilent(ByVal port As ASCII_PORT, ByVal param As String) As Boolean
            Return ASCII_ConnectSilent(port, param)
        End Function
        Public Sub Disconnect()
            ASCII_Disconnect()
        End Sub
        Public Sub SetComPortParam(ByVal BaudRate As Int32, ByVal fParity As Int32, ByVal Parity As Int32, ByVal StopBits As Int32, ByVal ByteSize As Int32, ByVal fOutX As Int32, ByVal fInX As Int32, ByVal fOutxCtsFlow As Int32, ByVal fOutxDsrFlow As Int32, ByVal fDtrControl As Int32, ByVal fRtsControl As Int32, ByVal fDsrSensitivity As Int32, ByVal fTXContinueOnXoff As Int32)
            ASCII_SetComPortParam(BaudRate, fParity, Parity, StopBits, ByteSize, fOutX, fInX, fOutxCtsFlow, fOutxDsrFlow, fDtrControl, fRtsControl, fDsrSensitivity, fTXContinueOnXoff)
        End Sub
        Public Function SetupPort(ByVal parent As IntPtr) As Int32
            Return ASCII_SetupPort(parent)
        End Function
    End Class
End Namespace