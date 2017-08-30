Public Class Composition
    Public totalsales As Integer

    Dim multiplier As Double = 1

    Dim multiplier1 As Double = 1
    Dim multiplier2 As Double = 1

    Dim progress As Double = 0

    Dim composition(2) As Double

    Dim idealhot As Double
    Dim idealmeh As Double
    Dim idealcold As Double
    Dim ideallemon As Double
    Dim idealsugar As Double
    Dim idealice As Double

    Dim profit As Double

    Dim moneymade As Integer
    Dim moneymade1 As Integer

    Public actualsales As Integer

    Dim variance As Integer

    Public AIcounter As Integer = 0
    Sub money()

        Try
            If CInt(TextBox1.Text) <= 0 Or CInt(TextBox2.Text) <= 0 Or CInt(TextBox3.Text) <= 0 Or CInt(TextBox4.Text) <= 0 Then
                MsgBox("Check your Ingredients")

            Else
                If AI.maxcustomers > Form1.customers Then
                Else
                    Form1.customers = AI.maxcustomers
                End If

                If Form1.customers <= CInt(TextBox4.Text) Then
                        actualsales = Form1.customers
                    Else
                        actualsales = CInt(TextBox4.Text)

                    End If


                    If CInt(Label4.Text) >= CInt(TextBox1.Text) * CInt(TextBox4.Text) And CInt(Label5.Text) >= CInt(TextBox2.Text) * CInt(TextBox4.Text) And CInt(Label6.Text) >= CInt(TextBox3.Text) * CInt(TextBox4.Text) Then



                        Form1.Label4.Text = CInt(Form1.Label4.Text) - actualsales * CInt(TextBox1.Text)
                    Form1.Label5.Text = CInt(Form1.Label5.Text) - actualsales * CInt(TextBox2.Text)
                    Form1.Label7.Text = CInt(Form1.Label7.Text) - actualsales * CInt(TextBox3.Text)
                    totalsales += actualsales


                    progress = totalsales
                    composition(0) = CInt(TextBox1.Text)
                    composition(1) = CInt(TextBox2.Text)
                    composition(2) = CInt(TextBox3.Text)


                    weather()
                    Getsales()





                    multiplier = multiplier2 * Upgrade.profitx2


                    moneymade = Math.Round(CInt(Form1.Label2.Text) + (((CInt(TextBox1.Text) + CInt(TextBox2.Text) + CInt(TextBox3.Text)) * actualsales) * multiplier1))

                    moneymade1 = moneymade - Form1.startmoney
                    moneymade += moneymade1 * (multiplier - 1)
                    moneymade1 += moneymade1 * (multiplier - 1)


                    Form1.Label2.Text = moneymade.ToString

                    Form1.Label12.Text = moneymade1.ToString

                    profit = Form1.Label12.Text


                    If profit < 0 Then
                        Form1.PictureBox5.ImageLocation = "U:\Pictures\redprofit.png"
                    ElseIf profit > -1 Then
                        Form1.PictureBox5.ImageLocation = "U:\Pictures\profit.png"

                    End If

                    Form1.startmoney = Form1.Label2.Text
                    If CInt(Form1.Label12.Text) > 0 Then
                        Form1.Label12.ForeColor = Color.Green
                    ElseIf CInt(Form1.Label12.Text) < 0 Then
                        Form1.Label12.ForeColor = Color.Red
                    Else
                        Form1.Label12.ForeColor = Color.Black
                    End If



                    If Math.Log10(progress) >= 5 Then
                        ProgressBar1.Value = 5
                    Else
                        ProgressBar1.Value = Math.Log10(progress)


                    End If


                    Form1.liquidcost = 0
                End If








            End If
        Catch ex As Exception
            MsgBox("Check your ingredients")
        End Try



    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox(Form1.customers.ToString)
        AIcounter += 1
        AI.main()
        MsgBox(Form1.customers.ToString)
        Dim num As New Random
        variance = num.Next(-10, 10)
        Form1.deviation = variance * CInt(Form1.reputation)
        Form1.customers += Form1.deviation


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
        Else

        End If


        Me.Hide()
        Form1.Show()

        If AIcounter = 1 Then
            MsgBox("A rival company has set up near you...")
        End If

        AI.aitry()

    End Sub

    Sub Getsales()
        multiplier1 = ((Math.Log10(progress)) / 100) + 1
    End Sub

    Sub weather()

        ideallemon = ((composition(0)) / (composition(0) + composition(1) + composition(2)))
        idealsugar = ((composition(1)) / (composition(0) + composition(1) + composition(2)))
        idealice = ((composition(2)) / (composition(0) + composition(1) + composition(2)))


        If Form1.weather = 2 And (ideallemon + idealsugar + idealice) = 1 Then
            multiplier2 = 2
            MsgBox("MEHHY")
        ElseIf Form1.weather = 0 And ideallemon = 2 * idealsugar And idealice = 3 * idealsugar Then
            multiplier2 = 2
            MsgBox("SUNNY")
        ElseIf Form1.weather = 1 And ideallemon = idealice And idealsugar = (2 * idealice) Then
            multiplier2 = 2
            MsgBox("COLD")
        Else
            multiplier2 = 1
        End If

        'MEH 1 lemon, 1 ice, 1 sugar

        'SUNNY 2 lemon, 3 ice, 1 sugar

        'COLD 1 lemon, 1 ice, 2 sugar 

    End Sub

    Public Sub Getstar()

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