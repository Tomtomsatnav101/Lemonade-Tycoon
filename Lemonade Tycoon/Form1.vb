Public Class Form1
    Dim addstock As Integer
    Dim startcheck As Boolean = 0
    Dim counter As Integer = 0
    Public startmoney As Integer
    Public weather As Integer
    Public liquidcost As Integer
    Public reputation As Double = 0.5
    Public customers As Integer = 100
    Public sales As Integer
    Public deviation As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        addstock = 1
        Getstock(HScrollBar1.Value, 0, 0)
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        addstock = 2
        Getstock(0, HScrollBar1.Value, 0)
    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        addstock = 3
        Getstock(0, 0, HScrollBar1.Value)
    End Sub
    Sub Getstock(Pluslemons, Plussugar, plusice)
        If addstock = 1 Then

            If Label2.Text >= Pluslemons Then
                Label4.Text = CInt(Label4.Text + Pluslemons)
                Label2.Text = CInt(Label2.Text - Pluslemons)

            Else
            End If

        ElseIf addstock = 2 Then

            If Label2.Text >= Plussugar Then
                Label5.Text = CInt(Label5.Text + Plussugar)
                Label2.Text = CInt(Label2.Text - Plussugar)
            Else

            End If
        ElseIf addstock = 3 Then

            If Label2.Text >= plusice Then
                Label7.Text = CInt(Label7.Text + plusice)
                Label2.Text = CInt(Label2.Text - plusice)
            Else
            End If

        Else
            MsgBox("Error")
        End If

    End Sub
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

        Composition.Show()
        Me.Hide()

        Composition.Label4.Text = Label4.Text
        Composition.Label5.Text = Label5.Text
        Composition.Label6.Text = Label7.Text

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        startmoney = Label2.Text
        reputation = Label3.Text


        Composition.Getstar()





        Randomize()

        weather = CInt(Rnd() * 2)
        If weather = 0 Then
            PictureBox6.ImageLocation = "U:\Pictures\sunny.PNG"
            MsgBox("Sunny")
        ElseIf weather = 1 Then
            PictureBox6.ImageLocation = "U:\Pictures\cold.PNG"
            MsgBox("Cold")
        ElseIf weather = 2 Then
            PictureBox6.ImageLocation = "U:\Pictures\meh.png"
            MsgBox("Meh")
        Else

        End If

    End Sub


    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        Label2.Text += Math.Round((CInt(Label4.Text) + CInt(Label5.Text) + CInt(Label7.Text)) * 0.9)
        liquidcost = Math.Round((CInt(Label4.Text) + CInt(Label5.Text) + CInt(Label7.Text)) * 0.1)
        Label4.Text = "0"
        Label5.Text = "0"
        Label7.Text = "0"
        startmoney = Label2.Text
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        Me.Hide()
        Upgrade.Show()
        Upgrade.Label2.Text = Label2.Text
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        save()
    End Sub
    Sub save()
        Database.database(Log_in.number).money = Label2.Text
        Database.database(Log_in.number).score = Label2.Text

        Database.database(Log_in.number).customers = Composition.totalsales
        Database.database(Log_in.number).lemons = Label4.Text
        Database.database(Log_in.number).sugar = Label5.Text
        Database.database(Log_in.number).ice = Label7.Text
        Database.database(Log_in.number).profit = Label12.Text
        Database.database(Log_in.number).reputation = Label3.Text
        Database.database(Log_in.number).expected = Label6.Text


        Database.write()
        End
    End Sub
    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        Me.Hide()
        Leaderboard.Show()
    End Sub



    Private Sub HScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar1.Scroll
        Button1.Text = HScrollBar1.Value.ToString + " Lemons"
        Button6.Text = HScrollBar1.Value.ToString + " Sugar"
        Button9.Text = HScrollBar1.Value.ToString + " Ice"
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        weather = 2
        PictureBox6.ImageLocation = "U:\Pictures\meh.png"

        'Get rid of this in real game
    End Sub



    Private Sub Panel2_MouseHover(sender As Object, e As EventArgs) Handles Panel2.MouseHover
        Label8.Text = ""

    End Sub
    Private Sub Form1_MouseHover(sender As Object, e As EventArgs) Handles Me.MouseHover
        Label8.Text = ""
    End Sub
    Private Sub Panel3_MouseHover(sender As Object, e As EventArgs) Handles Panel3.MouseHover
        Label8.Text = ""
    End Sub
    Private Sub Panel1_MouseHover(sender As Object, e As EventArgs) Handles Panel1.MouseHover
        Label8.Text = ""
    End Sub



    Private Sub Label3_MouseHover(sender As Object, e As EventArgs) Handles Label3.MouseHover
        Label8.Text = "Yesterday you served " + Composition.actualsales.ToString + " people"
    End Sub
    Private Sub Label4_MouseHover(sender As Object, e As EventArgs) Handles Label4.MouseHover
        Label8.Text = "Yesterday you sold " + (CInt(Composition.actualsales) * CInt(Composition.TextBox1.Text)).ToString + " lemons"
    End Sub
    Private Sub Label5_MouseHover(sender As Object, e As EventArgs) Handles Label5.MouseHover
        Label8.Text = "Yesterday you sold " + (CInt(Composition.actualsales) * CInt(Composition.TextBox2.Text)).ToString + " sugar"
    End Sub
    Private Sub Label7_MouseHover(sender As Object, e As EventArgs) Handles Label7.MouseHover
        Label8.Text = "Yesterday you sold " + (CInt(Composition.actualsales) * CInt(Composition.TextBox3.Text)).ToString + " ice"
    End Sub

    Private Sub Button20_MouseHover(sender As Object, e As EventArgs) Handles Button20.MouseHover
        Label8.Text = "Press this button if you have accicdently bought too much stock. It will sell it all back, for a small loss, but will ensure all your customers remain happy"
    End Sub

    Private Sub Button21_MouseHover(sender As Object, e As EventArgs) Handles Button21.MouseHover
        Label8.Text = "Press this button to access the upgrade screen"
    End Sub

    Private Sub Label6_MouseHover(sender As Object, e As EventArgs) Handles Label6.MouseHover
        Label8.Text = "This number is a forcast of how many customers you will encounter today. As it is an estimate, the real number may vary, so plan accordingly"

    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        save()
    End Sub
End Class
