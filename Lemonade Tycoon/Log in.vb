Public Class Log_in
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
        Else

            For i As Integer = 1 To Database.usercount
                If Database.database(i).username = TextBox1.Text And Database.database(i).password = TextBox2.Text Then

                    Form1.Label4.Text = Database.database(i).lemons.ToString
                    Form1.Label5.Text = Database.database(i).sugar.ToString
                    Form1.Label7.Text = Database.database(i).ice.ToString
                    Form1.Label12.Text = Database.database(i).profit.ToString
                    Composition.totalsales = Database.database(i).customers
                    Form1.Label2.Text = Database.database(i).money.ToString
                    Me.Hide()
                    Form1.Show()

                Else
                End If

            Next


        End If
    End Sub

    Private Sub Log_in_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Database.read()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
        Else
            Database.usercount += 1
            Database.database(Database.usercount).username = TextBox1.Text
            Database.database(Database.usercount).password = TextBox2.Text

            Form1.Label4.Text = 0
            Database.database(Database.usercount).lemons = 0
            Form1.Label5.Text = 0
            Database.database(Database.usercount).sugar = 0
            Form1.Label7.Text = 0
            Database.database(Database.usercount).ice = 0
            Form1.Label12.Text = 0
            Database.database(Database.usercount).profit = 0
            Composition.totalsales = 0
            Database.database(Database.usercount).customers = 0
            Form1.Label2.Text = 1000
            Database.database(Database.usercount).money = 1000
            Me.Hide()
            Form1.Show()
        End If
    End Sub
End Class