Public Class Leaderboard

    Dim order As Boolean = False

    Dim position As Integer = 0

    Dim counter As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If order = True Then
            ListBox1.Items.Clear()
            sort()
            order = False
        Else
            ListBox1.Items.Clear()          'false =   smallest
            sort()                                     'largest
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

   Sub sort()



        Dim highscores(1000) As highscore


        ListBox1.Items.Clear()

        For i = 0 To Database.database.Length - 1
            If Database.database(i).money <> Nothing Then
                highscores(counter).score = Database.database(i).money
                highscores(counter).name = Database.database(i).username
                counter += 1
            End If
        Next

        'Dim array() = {10, 44, 0, -1, 9, 100, 7, 39, 104859, -154636, 35536} 

        Dim inputLength As Integer = counter - 1


        MergeSort(highscores, 0, counter - 1)






    End Sub



    Sub MergeSort(highscores() As highscore, lowIndex As Integer, highIndex As Integer)



        If (lowIndex < highIndex) Then

            Dim midIndex = Math.Floor((lowIndex + highIndex) / 2)    ' Finds midpoint 



            MergeSort(highscores, lowIndex, midIndex)                'Splits first half of list 

            MergeSort(highscores, midIndex + 1, highIndex)           'Splits second half of list 



            Merge(highscores, lowIndex, midIndex, highIndex)

        End If



    End Sub



    Sub Merge(highscores() As highscore, lowIndex As Integer, midIndex As Integer, highIndex As Integer)





        Dim Length1 = midIndex - lowIndex + 1   'length of left list 

        Dim Length2 = highIndex - midIndex      'length of right list 



        Dim Left(Length1) As Integer

        Dim Right(Length2) As Integer



        'creating index variable to keep track of final answer 

        Dim final As Integer = lowIndex



        Dim counterI = 0

        Dim counterJ = 0





        While (counterI < Length1)

            Left(counterI) = highscores(lowIndex + counterI).score            'Transferes array contents to L 

            counterI += 1

        End While





        While (counterJ < Length2)

            Right(counterJ) = highscores(midIndex + 1 + counterJ).score        'Transferes array contents to R 

            counterJ += 1

        End While



        'Reset variables from previous usage 

        final = lowIndex

        Dim i As Integer = 0

        Dim j As Integer = 0



        'Merge the lists into one list 

        While (i < Length1 And j < Length2)



            If (Left(i) <= Right(j)) Then   'If the value on the left is less than the value on the right then add it to the list 

                highscores(final).score = Left(i)

                i += 1

            Else

                highscores(final).score = Right(j)      'If the value on the right is less than the value on the left then add it to the list 

                j += 1

            End If

            final += 1

        End While



        'Sorts it out if one array is empty after merging 

        While (i < Length1)

            highscores(final).score = Left(i)

            i += 1

            final += 1

        End While

        While (j < Length2)

            highscores(final).score = Right(j)

            j += 1

            final += 1

        End While



        'Checks our answer 
        Dim kk As Boolean = True

        For countercheck As Integer = 0 To counter - 2
                If highscores(countercheck).score > highscores(countercheck + 1).score Then
                    kk = False
                End If

            Next


        For l As Integer = 1 To Database.database.Length - 1
            For m As Integer = 1 To Database.database.Length - 1
                If Database.database(m).money = highscores(l).score Then
                    highscores(l).name = Database.database(m).username
                End If
            Next
        Next



        'Outputs the result forwards or backwards
        ListBox1.Items.Clear()
        If kk = False Then
        Else
            If order = False Then

                For counterout As Integer = 0 To counter - 1
                    If highscores(counterout).name = "" Then
                    Else


                        ListBox1.Items.Add(highscores(counterout).score.ToString + " : " + highscores(counterout).name)
                    End If
                Next
            Else
                For counterout As Integer = counter - 1 To 0 Step -1
                    If highscores(counterout).name = "" Then
                    Else
                        ListBox1.Items.Add(highscores(counterout).score.ToString + " : " + highscores(counterout).name)
                    End If
                Next
            End If
        End If







    End Sub

    Private Sub Leaderboard_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        End
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form1.Show()
    End Sub
End Class