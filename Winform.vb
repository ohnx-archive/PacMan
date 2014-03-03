Public Class Winform
    Dim textnumber As Integer = 0

    Private Sub textTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textTimer.Tick
        If textnumber = 0 And congratsText.Text = "Congratulations" Then
            congratsText.Text = "You win!!!"
            textnumber = 1
        ElseIf textnumber = 1 And congratsText.Text = "You win!!!" Then
            congratsText.Text = "Congratulations"
            textnumber = 0
        Else
            congratsText.Text = "Glitch with program. Please Report."
        End If
    End Sub

    Private Sub retryButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles retryButton.Click
        Close()
        Form1.Show()
    End Sub

    Private Sub quitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles quitButton.Click
        Form1.Close()
        Close()
    End Sub

    Private Sub Winform_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        My.Computer.Audio.Play(My.Resources.level, AudioPlayMode.Background)
    End Sub
End Class