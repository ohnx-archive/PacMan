Imports System.Windows.Forms

Public Class YouDie
    Private Sub YouDie_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Form1.Show()
        If Form1.monstername = "monster0" Then
            monstername.Text = "Blinky"
        ElseIf Form1.monstername = "monster1" Then
            monstername.Text = "Inky"
        ElseIf Form1.monstername = "monster2" Then
            monstername.Text = "Clyde"
        ElseIf Form1.monstername = "monster3" Then
            monstername.Text = "Pinky"
        End If
    End Sub

    Private Sub retryButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles retryButton.Click
        Close()
        Form1.Show()
    End Sub

    Private Sub quitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles quitButton.Click
        Form1.Close()
        Me.Close()
    End Sub
End Class
