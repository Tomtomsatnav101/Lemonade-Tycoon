Public Class Composition
    Public totalsales As Integer

    Dim multiplier As Double = 1

    Dim multiplier1 As Double = 1
    Dim multiplier2 As Double = 1

    Dim progress As Double = 0

    Dim composition(2) As Double

    Dim idealhot As Double
    Dim idealcold As Double

    Dim ideallemon As Double
    Dim idealsugar As Double
    Dim idealice As Double

    Dim profit As Double

    Dim moneymade As Integer
    Dim moneymade1 As Integer

    Public actualsales As Integer

    Dim variance As Integer


    Sub money()

        'Try

        If Form1.customers <= CInt(TextBox4.Text) Then          'Works out whether the player made enough drinks for today, and works out which one is the sales for the day 
            actualsales = Form1.customers
        Else
            actualsales = CInt(TextBox4.Text)

        End If




        Form1.Label4.Text = CInt(Form1.Label4.Text) - actualsales * CInt(TextBox1.Text)
            Form1.Label5.Text = CInt(Form1.Label5.Text) - actualsales * CInt(TextBox2.Text)
            Form1.Label7.Text = CInt(Form1.Label7.Text) - actualsales * CInt(TextBox3.Text)         'Re-calculates the stock levels based of the number of sales you have
            totalsales += actualsales   'calculates the total sales using today's sales


        progress = totalsales   'Sets the progress bar level
            composition(0) = CInt(TextBox1.Text)    'Sets the compesition array used to calculate multipliers
            composition(1) = CInt(TextBox2.Text)
            composition(2) = CInt(TextBox3.Text)


        weather()

        Getsales(progress)



        'Combines the multipliers into one multiplier to make it wasier to deal with

        multiplier = multiplier2 * Upgrade.profitx2



        'money made is equal to the surrent money plus the money made times the multiplier
        moneymade = Math.Round(CInt(Form1.Label2.Text) + (((CInt(TextBox1.Text) + CInt(TextBox2.Text) + CInt(TextBox3.Text)) * actualsales) * multiplier1))

            'money made 1 is equal to the money the plauyer has minus the money the player had at the start of the turn ie. moneymade1 is the profit from this turn
            moneymade1 = moneymade - Form1.startmoney

            'moneymade is equal to  profit times the multiplier minus 1
            moneymade += moneymade1 * (multiplier - 1)

            'moneymade1 is equal to itself times multiplier minus 1
            moneymade1 += moneymade1 * (multiplier - 1)

            'The users money is equal to moneymade
            Form1.Label2.Text = moneymade.ToString

            'The users profit is equal to moneymade1
            Form1.Label12.Text = moneymade1.ToString
            profit = Form1.Label12.Text


            If profit < 0 Then
                Form1.PictureBox5.ImageLocation = "U:\Pictures\redprofit.png"
            ElseIf profit > -1 Then
                Form1.PictureBox5.ImageLocation = "U:\Pictures\profit.png"
                'CHANGE
            End If

            Form1.startmoney = Form1.Label2.Text
            If CInt(Form1.Label12.Text) > 0 Then
                Form1.Label12.ForeColor = Color.Green
            ElseIf CInt(Form1.Label12.Text) < 0 Then
                Form1.Label12.ForeColor = Color.Red
            Else
                Form1.Label12.ForeColor = Color.Black
            End If


        'money left                                         stock                                              sales           dont change
        ' AI.aimoney = Math.Round(AI.aimoney + ((((AI.ailemon / 100) + (AI.aisugar / 100) + (AI.aiice)) * AI.aiactualcustomers) * (multiplier1 + multiplier2)))






        If Math.Log10(progress) >= 5 Then
                ProgressBar1.Value = 5
            Else
                ProgressBar1.Value = Math.Log10(progress)

            End If


            Form1.liquidcost = 0










        'Catch ex As Exception
        'MsgBox("Check your ingredients")
        'End Try



    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox(Form1.customers.ToString)
        MsgBox(Form1.customers.ToString)
        Dim num As New Random
        variance = num.Next(-10, 10)
        Form1.deviation = variance * CInt(Form1.reputation)
        Form1.customers += Form1.deviation



        If CInt(TextBox1.Text) <= 0 Or CInt(TextBox2.Text) <= 0 Or CInt(TextBox3.Text) <= 0 Or CInt(TextBox4.Text) <= 0 Then
            MsgBox("Check your Ingredients")
        Else
            If CInt(Label4.Text) >= CInt(TextBox1.Text) * CInt(TextBox4.Text) And CInt(Label5.Text) >= CInt(TextBox2.Text) * CInt(TextBox4.Text) And CInt(Label6.Text) >= CInt(TextBox3.Text) * CInt(TextBox4.Text) Then

                money()

                Randomize()



                If actualsales = Form1.customers Then
                    If Form1.reputation >= 1.5 Then
                    Else
                        Form1.reputation += 0.1
                        Form1.customers = Form1.customers * 1.1
                    End If
                Else
                    If Form1.reputation <= 0.5 Then
                    Else
                        Form1.reputation -= 0.1
                        Form1.customers = Form1.customers * 0.9
                    End If
                End If


                If multiplier2 = 2 Then
                    If Form1.reputation >= 1.5 Then
                    Else
                        Form1.reputation += 0.1
                        Form1.customers = Form1.customers * 1.1
                    End If
                ElseIf multiplier2 = 1 Then
                    If Form1.reputation <= 0.5 Then
                    Else
                        Form1.reputation -= 0.1
                        Form1.customers = Form1.customers * 0.9

                    End If
                End If

                Form1.Label3.Text = Form1.reputation.ToString
                Form1.Label6.Text = Form1.customers.ToString

                Getstar()

                Form1.weather = CInt(Rnd() * 2)
                If Form1.weather = 0 Then
                    Form1.PictureBox6.ImageLocation = "U:\Pictures\sunny.PNG"
                ElseIf Form1.weather = 1 Then
                    Form1.PictureBox6.ImageLocation = "U:\Pictures\cold.PNG"
                ElseIf Form1.weather = 2 Then
                    Form1.PictureBox6.ImageLocation = "U:\Pictures\meh.png"
                Else                                                    'CHANGE

                End If


                Me.Hide()
                Form1.Show()

                'If AIcounter = 1 Then
                '    MsgBox("A rival company has set up near you...")
                'End If

                ' AI.aitry()
            End If
        End If
    End Sub

    Sub Getsales(ByVal progress As Integer)
        'Works out the bonus based on the number of past customers
        multiplier1 = ((Math.Log10(progress)) / 100) + 1
    End Sub

    Sub weather()

        ideallemon = ((composition(0)) / (composition(0) + composition(1) + composition(2)))           'Works out the proportions of each stock item
        idealsugar = ((composition(1)) / (composition(0) + composition(1) + composition(2)))
        idealice = ((composition(2)) / (composition(0) + composition(1) + composition(2)))

        idealhot = (ideallemon + idealsugar) / idealice     'Works out how close the user is to achieving the perfect ratio for the weather
        idealcold = (ideallemon - idealice) / idealsugar

        If Form1.weather = 0 Then
            multiplier2 = 2 - (1 - Math.Abs(idealhot))      'Sets the multiplier based on how close the user is to the ideal mix for that weather
        ElseIf Form1.weather = 1 Then
            multiplier2 = 2 - Math.Abs(idealcold)           'The further off the user is, the worse the bonus, until the bonus is 1
        Else
            multiplier2 = 1
        End If


        'MEH 1 lemon, 1 ice, 1 sugar

        'SUNNY 2 lemon, 3 ice, 1 sugar

        'COLD 1 lemon, 1 ice, 2 sugar 

    End Sub

    Public Sub Getstar()
        'CHANGE

        'Works out how many stars to show based onthe reputation levels
        If Form1.reputation > 0.6 Then
            Form1.PictureBox7.ImageLocation = "U:\Pictures\Star.Png"
            If Form1.reputation > 0.8 Then
                Form1.PictureBox8.ImageLocation = "U:\Pictures\Star.Png"
                If Form1.reputation > 1 Then
                    Form1.PictureBox9.ImageLocation = "U:\Pictures\Star.Png"
                    If Form1.reputation > 1.2 Then
                        Form1.PictureBox10.ImageLocation = "U:\Pictures\Star.Png"
                        If Form1.reputation > 1.4 Then
                            Form1.PictureBox11.ImageLocation = "U:\Pictures\Star.Png"
                        Else
                            Form1.PictureBox11.ImageLocation = Nothing
                        End If
                    Else
                        Form1.PictureBox10.ImageLocation = Nothing
                    End If
                Else
                    Form1.PictureBox9.ImageLocation = Nothing
                End If
            Else
                Form1.PictureBox8.ImageLocation = Nothing
            End If
        Else
            Form1.PictureBox7.ImageLocation = Nothing
        End If
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            TextBox1.Text = CInt(TextBox1.Text + 1)
        Catch ex As Exception
            MsgBox("No")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If TextBox1.Text = 0 Then
            Else
                TextBox1.Text = CInt(TextBox1.Text - 1)
            End If
        Catch ex As Exception
            MsgBox("No")
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            TextBox2.Text = CInt(TextBox2.Text + 1)
        Catch ex As Exception
            MsgBox("No")
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            If TextBox2.Text = 0 Then
            Else
                TextBox2.Text = CInt(TextBox2.Text - 1)
            End If
        Catch ex As Exception
            MsgBox("No")
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            TextBox3.Text = CInt(TextBox3.Text + 1)
        Catch ex As Exception
            MsgBox("No")
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            If TextBox3.Text = 0 Then
            Else
                TextBox3.Text = CInt(TextBox3.Text - 1)
            End If
        Catch ex As Exception
            MsgBox("No")
        End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Try
            TextBox4.Text = CInt(TextBox4.Text + 1)
        Catch ex As Exception
            MsgBox("No")
        End Try
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Try
            If TextBox4.Text = 0 Then
            Else
                TextBox4.Text = CInt(TextBox4.Text - 1)
            End If
        Catch ex As Exception
            MsgBox("No")
        End Try
    End Sub

    Private Sub Composition_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Label4.Text = Form1.Label4.Text
        Label5.Text = Form1.Label5.Text
        Label6.Text = Form1.Label7.Text
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Me.Hide()
        Form1.Show()
    End Sub
End Class