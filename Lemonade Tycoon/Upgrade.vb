Public Class Upgrade

    Public profitx2 As Integer = 1
    Public upgradecost As Integer = 0

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form1.Show()
        Form1.Label2.Text = Label2.Text

    End Sub

    Private Sub Upgrade_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Label2.Text = Form1.Label2.Text
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If CInt(Label2.Text) >= 100 Then
            Label2.Text = CInt(Label2.Text) - 100
            profitx2 = 2
            upgradecost += 100
            Button2.Visible = False
        Else
            profitx2 = 1
        End If
    End Sub
End Class