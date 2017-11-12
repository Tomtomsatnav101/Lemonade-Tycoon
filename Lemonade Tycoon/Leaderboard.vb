Public Class Leaderboard

    Dim order As Boolean = True

    Dim array(1000) As Integer
    Dim position As Integer = 0

    Dim counter As Integer = 0  ' length of the array
    Dim highscores(1000) As highscore
    Dim temp As Integer
    Dim pointer1 As Integer
    Dim pointer2 As Integer
    Dim list1() As Integer
    Dim list2() As Integer
    Dim list3() As Integer

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

    Sub mergesortsub()



        ListBox1.Items.Clear()

        For i = 0 To Database.database.Length - 1
            If Database.database(i).money <> Nothing Then
                highscores(counter).score = Database.database(i).money
                highscores(counter).name = Database.database(i).username
                counter += 1
            End If
        Next

        Dim lists(counter) As Integer


        For i As Integer = 1 To counter
            lists(i) = highscores(i).score
        Next

        'For i As Integer = 1 To counter Step 2
        '    If lists(i) > lists(i + 1) Then
        '        lists(i) = temp
        '        lists(i + 1) = lists(i)
        '        lists(i + 1) = lists(i)
        '    End If
        'Next


    End Sub
    Sub merger()
        For i As Integer = 1 To Math.Round(counter / 2)
            list1(counter) = highscores(i).score
        Next

        For i As Integer = Math.Round(counter / 2) To counter
            list2(counter) = highscores(i).score
        Next

        merge(list1, list2)
    End Sub



    Function merge(a() As Integer, b() As Integer)
        pointer1 = 1
        pointer2 = 1
        For i As Integer = 1 To (a.Length + b.Length)
            If a(pointer1) > b(pointer2) Then
                list3(i) = a(pointer1)
                pointer1 += 1

            Else
                list3(i) = b(pointer2)
                pointer2 += 1
            End If

        Next

    End Function


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