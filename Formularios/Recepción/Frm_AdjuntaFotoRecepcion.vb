Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Data
Imports System.Configuration
Imports System.Drawing.Imaging
Imports System.Data.SqlClient
Imports System.Drawing.Image

Public Class Frm_AdjuntaFotoRecepcion

    Dim fnc As New Funciones
    Dim sqlListar As String
    Dim sqlActualizar As String
    Dim tablaListar As DataTable
    Dim buscar As String
    Public IdPrincipal As String
    Public NombrePrincipal As String
    Public resultado As String
    Public filtro As String
    Dim Temperaturas As String
    Dim Soportantes As String
    Dim promedio As Double
    Dim imagen_valida As String = "NO"

    Private Sub Frm_AdjuntaFotoRecepcion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtGuiaRecepcion.Text = filtro
        TraeImagenes()
    End Sub
    'FUNCIONES OPERATIVAS DEL USUARIO

    Function ByteArrayToImage(ByVal byteArrayIn As Byte()) As Image
        Dim ms As New MemoryStream(byteArrayIn)
        Dim myimage As Image
        myimage = New Bitmap(New MemoryStream(byteArrayIn))
        Return myimage
    End Function

    Function ImageToByteArray(ByVal imageIn As Image) As Byte()
        Dim ms As New MemoryStream()
        imageIn.Save(ms, ImageFormat.Jpeg)
        Return ms.ToArray()
    End Function

    Private Sub comprobarimagen(ByVal imageIn As Image)
        Try
            Dim ms As New MemoryStream()
            imageIn.Save(ms, ImageFormat.Jpeg)
            imagen_valida = "SI"
            Exit Sub
        Catch ex As NullReferenceException
            imagen_valida = "NO"
            Exit Sub
        End Try

    End Sub

    Public Shared Function LoadImage(ByVal imageName As String) As Bitmap
        Return New Bitmap(imageName)
    End Function
  
    Function ImageToBase64String(ByVal image As Image)
        Using memStream As New MemoryStream

            image.Save(memStream, imageFormat.Jpeg)

            Dim result As String = Convert.ToBase64String(memStream.ToArray())

            memStream.Close()

            Return result

        End Using

    End Function

    Sub ExaminaImagen(ByVal pbox As PictureBox)
        Dim file As New OpenFileDialog()
        Dim peso As Double = 0
        file.Filter = "Archivo JPG|*.jpg"
        If file.ShowDialog() = DialogResult.OK Then
            Try

                Dim f As New FileInfo(file.FileName())
                peso = Math.Round((f.Length / 1024), 2)

            Catch ex As IOException
                MsgBox("No fue posible determinar el tamaño de la imagen", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End Try

            Try
                If peso < 300 Then
                    pbox.Image = New Bitmap(file.FileName())
                Else
                    MsgBox("El tamaño de la fotografía no puede superar los 200K intente con otra", MsgBoxStyle.Critical, "Aviso")
                    Exit Sub
                End If
            Catch ex As OutOfMemoryException
                MsgBox("El tamaño de la fotografía no puede superar los 200K intente con otra", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End Try
        End If
        
    End Sub

    Sub GrabaImagen(ByVal guia As String, ByVal foto As Byte(), ByVal num As Integer, ByVal foto2 As String)
        Dim sql9 As String = "DELETE FROM receimagen WHERE rimg_rececodi = '" + guia + "' AND rimg_num = " + num.ToString()
        fnc.MovimientoSQL(sql9)

        Dim con As New SqlConnection
        Dim query As String = "INSERT INTO receimagen(rimg_imagen,rimg_rececodi,rimg_num,rimg_imagen2) VALUES(@foto,@guia,@num,Convert(Varbinary(max),Convert(varchar(MAX),@foto2)))"
        Dim cmd As New SqlCommand(query, con)

        cmd.Parameters.AddWithValue("@foto", foto)
        cmd.Parameters.AddWithValue("@foto2", foto2)
        cmd.Parameters.AddWithValue("@guia", guia)
        cmd.Parameters.Add("@num", System.Data.SqlDbType.Int).Value = num
        con.ConnectionString = ("Data Source=192.168.1.90\PRECISABD; initial catalog=PRECISA;  Uid=sa; PWD=precisa; Connection Timeout=0;")
        con.Open()


        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Sub EliminarImagen(ByVal guia As String, ByVal num As String)
        Dim sql9 As String = "DELETE FROM receimagen WHERE rimg_rececodi = '" + guia + "' AND rimg_num = " + num
        If fnc.MovimientoSQL(sql9) = 1 Then
            MsgBox("Fotografía Eliminada Exitosamente", MsgBoxStyle.Information, "Adjunta Fotografías a Recepción")
        Else
            MsgBox("Error en elimnar fotografía", MsgBoxStyle.Critical, "Adjunta Fotografías a Recepción")
        End If
    End Sub

    Sub TraeImagenes()
        Dim sql As String = "SELECT rimg_imagen,rimg_num FROM receimagen WHERE rimg_rececodi= '" + filtro + "'"
        Dim tablaimagen As DataTable = fnc.ListarTablasSQL(sql)

        If tablaimagen.Rows.Count > 0 Then
            For i As Integer = 0 To tablaimagen.Rows.Count - 1
                If tablaimagen.Rows(i)(0).ToString() <> "" Then
                    Select Case tablaimagen.Rows(i)(1)
                        Case 1
                            PictureBox1.Image = ByteArrayToImage(DirectCast(tablaimagen.Rows(i)(0), Byte()))
                            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                        Case 2
                            PictureBox2.Image = ByteArrayToImage(DirectCast(tablaimagen.Rows(i)(0), Byte()))
                            PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
                        Case 3
                            PictureBox3.Image = ByteArrayToImage(DirectCast(tablaimagen.Rows(i)(0), Byte()))
                            PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
                        Case 4
                            PictureBox4.Image = ByteArrayToImage(DirectCast(tablaimagen.Rows(i)(0), Byte()))
                            PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage
                    End Select
                End If
            Next
        End If
    End Sub

    'FUNCIONES OPERATIVAS DEL SISTEMA

    Private Sub GuardaImagen1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuardaImagen1.Click
        Dim msj = MsgBox("¿Seguro Desea Grabar Fotografía?", vbYesNo, "Adjuntar Fotografías Recepción")

        If msj = vbYes Then
            comprobarimagen(PictureBox1.Image)
            If imagen_valida = "SI" Then
                GrabaImagen(txtGuiaRecepcion.Text, ImageToByteArray(PictureBox1.Image), 1, ImageToBase64String(PictureBox1.Image))
                MsgBox("Fotografía Guardada Exitosamente", MsgBoxStyle.Information, "Adjunta Fotografías a Recepción")
            Else
                MsgBox("Debe seleccionar una fotografia primero", MsgBoxStyle.Critical, "Adjunta Fotografías a Recepción")
            End If
            
        End If
    End Sub

    Private Sub GuardaImagen2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuardaImagen2.Click
        Dim msj = MsgBox("¿Seguro Desea Grabar Fotografía?", vbYesNo, "Adjuntar Fotografías Recepción")

        If msj = vbYes Then
            comprobarimagen(PictureBox2.Image)
            If imagen_valida = "SI" Then
                GrabaImagen(txtGuiaRecepcion.Text, ImageToByteArray(PictureBox2.Image), 2, ImageToBase64String(PictureBox2.Image))
                MsgBox("Fotografía Guardada Exitosamente", MsgBoxStyle.Information, "Adjunta Fotografías a Recepción")
            Else
                MsgBox("Debe seleccionar una fotografia primero", MsgBoxStyle.Critical, "Adjunta Fotografías a Recepción")
            End If

        End If
    End Sub

    Private Sub GuardaImagen3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuardaImagen3.Click
        Dim msj = MsgBox("¿Seguro Desea Grabar Fotografía?", vbYesNo, "Adjuntar Fotografías Recepción")

        If msj = vbYes Then
            comprobarimagen(PictureBox3.Image)
            If imagen_valida = "SI" Then
                GrabaImagen(txtGuiaRecepcion.Text, ImageToByteArray(PictureBox3.Image), 3, ImageToBase64String(PictureBox3.Image))
                MsgBox("Fotografía Guardada Exitosamente", MsgBoxStyle.Information, "Adjunta Fotografías a Recepción")
            Else
                MsgBox("Debe seleccionar una fotografia primero", MsgBoxStyle.Critical, "Adjunta Fotografías a Recepción")
            End If

        End If
    End Sub

    Private Sub GuardaImagen4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuardaImagen4.Click
        Dim msj = MsgBox("¿Seguro Desea Grabar Fotografía?", vbYesNo, "Adjuntar Fotografías Recepción")

        If msj = vbYes Then
            comprobarimagen(PictureBox4.Image)
            If imagen_valida = "SI" Then
                GrabaImagen(txtGuiaRecepcion.Text, ImageToByteArray(PictureBox4.Image), 4, ImageToBase64String(PictureBox4.Image))
                MsgBox("Fotografía Guardada Exitosamente", MsgBoxStyle.Information, "Adjunta Fotografías a Recepción")
            Else
                MsgBox("Debe seleccionar una fotografia primero", MsgBoxStyle.Critical, "Adjunta Fotografías a Recepción")
            End If

        End If
    End Sub

    Private Sub btnExaminar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar1.Click
        ExaminaImagen(PictureBox1)
    End Sub

    Private Sub btnExaminar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar2.Click
        ExaminaImagen(PictureBox2)
    End Sub

    Private Sub btnExaminar3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar3.Click
        ExaminaImagen(PictureBox3)
    End Sub

    Private Sub btnExaminar4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar4.Click
        ExaminaImagen(PictureBox4)
    End Sub

    Private Sub btnBorrar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar1.Click
        Dim msj = MsgBox("¿Seguro Desea Eliminar Fotografía?", vbYesNo, "Adjuntar Fotografías Recepción")

        If msj = vbYes Then
            PictureBox1.Image = Nothing
            EliminarImagen(txtGuiaRecepcion.Text, "1")
        End If
    End Sub

    Private Sub btnBorrar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar2.Click
        Dim msj = MsgBox("¿Seguro Desea Eliminar Fotografía?", vbYesNo, "Adjuntar Fotografías Recepción")

        If msj = vbYes Then
            PictureBox2.Image = Nothing
            EliminarImagen(txtGuiaRecepcion.Text, "2")
        End If
    End Sub

    Private Sub btnBorrar3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar3.Click
        Dim msj = MsgBox("¿Seguro Desea Eliminar Fotografía?", vbYesNo, "Adjuntar Fotografías Recepción")

        If msj = vbYes Then
            PictureBox3.Image = Nothing
            EliminarImagen(txtGuiaRecepcion.Text, "3")
        End If
    End Sub

    Private Sub btnBorrar4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar4.Click
        Dim msj = MsgBox("¿Seguro Desea Eliminar Fotografía?", vbYesNo, "Adjuntar Fotografías Recepción")

        If msj = vbYes Then
            PictureBox4.Image = Nothing
            EliminarImagen(txtGuiaRecepcion.Text, "4")
        End If
    End Sub
End Class