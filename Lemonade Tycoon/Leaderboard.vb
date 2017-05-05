Public Class Leaderboard

    Dim order As Boolean = True


    Dim array(1000) As Integer
    Dim position As Integer = 0


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If order = True Then
            bubblesort()
            order = False
        Else
            bubblesort()
            order = True
        End If


    End Sub

    Structure highscore
        Dim score As Integer
        Dim name As String
    End Structure
    Sub bubblesort()

        Dim highscores(1000) As highscore
        Dim counter As Integer = 0

        ListBox1.Items.Clear()

        For i = 0 To Database.database.Length - 1
            If Database.database(i).money <> Nothing Then
                highscores(counter).score = Database.database(i).money
                highscores(counter).name = Database.database(i).username
                counter += 1
            End If
        Next



        For i As Integer = 0 To counter - 1
            For j As Integer = 1 To counter - 1 - i

                If order = True Then
                    If highscores(j).score > highscores(j - 1).score Then
                        Dim temp As highscore = highscores(j)
                        highscores(j) = highscores(j - 1)
                        highscores(j - 1) = temp
                    End If


                Else
                    If highscores(j).score < highscores(j - 1).score Then
                        Dim temp As highscore = highscores(j)
                        highscores(j) = highscores(j - 1)
                        highscores(j - 1) = temp
                    End If
                End If

            Next

        Next
        For i = 0 To highscores.Length - 1
            If highscores(i).score <> Nothing Then
                ListBox1.Items.Add(highscores(i).score.ToString + " : " + highscores(i).name)


            End If

        Next

    End Sub

    Private Sub Leaderboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Leaderboard_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        End
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form1.Show()
    End Sub
End Class