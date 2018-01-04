Public Class Leaderboard

    Dim order As Boolean = True

    Dim array(1000) As Integer
    Dim position As Integer = 0

    Dim counter As Integer = 0  ' length of the array
    Dim highscores(1000) As highscore
    
    
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'If order = True Then
        '    bubblesort()
        '    order = False
        'Else
        '    bubblesort()
        '    order = True
        'End If
        sort()

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

         

        Dim array(1000) As highscore
        

        ListBox1.Items.Clear()

        For i = 0 To Database.database.Length - 1
            If Database.database(i).money <> Nothing Then
                array(counter).score = Database.database(i).money
                highscarrayores(counter).name = Database.database(i).username
                            End If
        Next

            'Dim array() = {10, 44, 0, -1, 9, 100, 7, 39, 104859, -154636, 35536} 

            Dim inputLength As Integer = Database.database.length-1

  
            MergeSort(array, 0, array.Length - 1) 

            Console.ReadLine() 

            Console.Clear() 

        

  
    End Sub 
    
  

    Sub MergeSort(array() As Integer, lowIndex As Integer, highIndex As Integer) 

  

        If (lowIndex < highIndex) Then 

            Dim midIndex = Math.Floor((lowIndex + highIndex) / 2)    ' Finds midpoint 

  

            MergeSort(array, lowIndex, midIndex)                'Splits first half of list 

            MergeSort(array, midIndex + 1, highIndex)           'Splits second half of list 

  

            Merge(array, lowIndex, midIndex, highIndex) 

        End If 

  

    End Sub 

  

    Sub Merge(array() As Integer, lowIndex As Integer, midIndex As Integer, highIndex As Integer) 

  

  

        Dim Length1 = midIndex - lowIndex + 1   'length of left list 

        Dim Length2 = highIndex - midIndex      'length of right list 

  

        Dim Left(Length1) As Integer 

        Dim Right(Length2) As Integer 

  

        'creating index variable to keep track of final answer 

        Dim final As Integer = lowIndex 

  

        Dim counterI = 0 

        Dim counterJ = 0 

  

  

        While (counterI < Length1) 

            Left(counterI) = array(lowIndex + counterI)            'Transferes array contents to L 

            counterI += 1 

        End While 

  

  

        While (counterJ < Length2) 

            Right(counterJ) = array(midIndex + 1 + counterJ)        'Transferes array contents to R 

            counterJ += 1 

        End While 

  

        'Reset variables from previous usage 

        final = lowIndex 

        Dim i As Integer = 0 

        Dim j As Integer = 0 

  

        'Merge the lists into one list 

        While (i < Length1 And j < Length2) 

  

            If (Left(i) <= Right(j)) Then   'If the value on the left is less than the value on the right then add it to the list 

                array(final) = Left(i) 

                i += 1 

            Else 

                array(final) = Right(j)      'If the value on the right is less than the value on the left then add it to the list 

                j += 1 

            End If 

            final += 1 

        End While 

  

        'Sorts it out if one array is empty after merging 

        While (i < Length1) 

            array(final) = Left(i) 

            i += 1 

            final += 1 

        End While 

        While (j < Length2) 

            array(final) = Right(j) 

            j += 1 

            final += 1 

        End While 

  

        'Print our answer 

      
        For counter As Integer = 0 To array.Length - 1 

            ListBox1.Items.Add(array(i).score.ToString + " : " + array(i).name)

        Next 

    End sub

    Private Sub Leaderboard_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        End
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form1.Show()
    End Sub
End Class