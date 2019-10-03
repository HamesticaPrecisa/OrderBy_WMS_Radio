Public Class frm_DetOTTunel
    Public ott_id As Integer
    Public ott_numero As String

    Private Sub frm_DetOTTunel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Text = "OT #" + ott_numero.Trim()
    End Sub
End Class