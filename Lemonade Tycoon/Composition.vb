﻿Public Class Composition
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

    Dim reputation As Integer


    Sub money()

        Try
            If CInt(TextBox1.Text) <= 0 Or CInt(TextBox2.Text) <= 0 Or CInt(TextBox3.Text) <= 0 Or CInt(TextBox4.Text) <= 0 Then
                MsgBox("Check your Ingredients")

            Else


                If CInt(Label4.Text) >= CInt(TextBox1.Text) * CInt(TextBox4.Text) And CInt(Label5.Text) >= CInt(TextBox2.Text) * CInt(TextBox4.Text) And CInt(Label6.Text) >= CInt(TextBox3.Text) * CInt(TextBox4.Text) Then

                    Me.Hide()

                    Form1.Label4.Text = CInt(Form1.Label4.Text) - (CInt(TextBox4.Text) * CInt(TextBox1.Text))
                    Form1.Label5.Text = CInt(Form1.Label5.Text) - (CInt(TextBox4.Text) * CInt(TextBox2.Text))
                    Form1.Label7.Text = CInt(Form1.Label7.Text) - (CInt(TextBox4.Text) * CInt(TextBox3.Text))
                    totalsales = totalsales + CInt(TextBox4.Text)


                    progress = totalsales
                    composition(0) = CInt(TextBox1.Text)
                    composition(1) = CInt(TextBox2.Text)
                    composition(2) = CInt(TextBox3.Text)



                    weather()
                    Getsales()


                    Form1.Show()
                    multiplier = 0

                    'If multiplier2 = 2 Then
                    'multiplier += 2
                    'Else
                    'End If

                    'If Upgrade.profitx2 = 2 Then
                    'multiplier += 2
                    'End If

                    MsgBox("multiplier1 =" + multiplier1.ToString)
                    MsgBox("multiplier2 =" + multiplier2.ToString)

                    MsgBox("Upgrade.profitx2 =" + Upgrade.profitx2.ToString)

                    multiplier = multiplier2 * Upgrade.profitx2

                    MsgBox("multiplier!!!!!!!! = " + multiplier.ToString)


                    ' MsgBox(((((CInt(TextBox1.Text) + CInt(TextBox2.Text) + CInt(TextBox3.Text)) * CInt(TextBox4.Text)) * multiplier1) * multiplier).ToString)

                    Form1.Label2.Text = Math.Round(CInt(Form1.Label2.Text) + ((((CInt(TextBox1.Text) + CInt(TextBox2.Text) + CInt(TextBox3.Text)) * CInt(TextBox4.Text)) * multiplier1) * multiplier))

                    'Insert if statement that doubles profit


                    Form1.Label12.Text = CInt(Form1.Label2.Text) - Form1.startmoney

                    profit = Form1.Label12.Text
                    If Upgrade.upgradecost > 0 Then
                        profit += Upgrade.upgradecost
                    End If

                    If Form1.liquidcost > 0 Then
                        profit += Form1.liquidcost
                    End If
                    multiplier = 0










                    'If multiplier = 0 Then
                    'Else
                    ' Form1.Label12.Text = profit * multiplier
                    '  Form1.Label2.Text += (profit * multiplier) - profit
                    'End If


                    If profit < 0 Then
                        Form1.PictureBox5.ImageLocation = "redprofit.png"
                    ElseIf profit > -1 Then
                        Form1.PictureBox5.ImageLocation = "profit.png"

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



                    Upgrade.upgradecost = 0
                    Form1.liquidcost = 0
                End If

            End If

        Catch ex As Exception
            MsgBox("Check your ingredients")
        End Try



    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        money()
        Randomize()

        Form1.weather = CInt(Rnd() * 2)
        If Form1.weather = 0 Then
            Form1.PictureBox6.ImageLocation = "sunny.PNG"
        ElseIf Form1.weather = 1 Then
            Form1.PictureBox6.ImageLocation = "cold.PNG"
        ElseIf Form1.weather = 2 Then
            Form1.PictureBox6.ImageLocation = "meh.png"
        Else

        End If
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