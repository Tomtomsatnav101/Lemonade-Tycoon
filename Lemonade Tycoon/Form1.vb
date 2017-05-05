Public Class Form1
    Dim addstock As Integer
    Dim startcheck As Boolean = 0
    Dim counter As Integer = 0
    Public startmoney As Integer
    Public weather As Integer
    Public liquidcost As Integer
    Dim repeat As Boolean = False

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        addstock = 1

        Getstock(HScrollBar1.Value, 0, 0)
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs)
        addstock = 1
        Getstock(20, 0, 0)
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs)
        addstock = 1
        Getstock(100, 0, 0)
    End Sub
    Private Sub Button11_Click(sender As Object, e As EventArgs)
        addstock = 1
        Getstock(1000, 0, 0)
    End Sub
    Private Sub Button16_Click(sender As Object, e As EventArgs)
        addstock = 1
        Getstock(10000, 0, 0)
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs)
        addstock = 1
        Getstock(100000, 0, 0)
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        addstock = 2
        Getstock(0, HScrollBar1.Value, 0)
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs)
        addstock = 2
        Getstock(0, 20, 0)
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs)
        addstock = 2
        Getstock(0, 100, 0)
    End Sub
    Private Sub Button12_Click(sender As Object, e As EventArgs)
        addstock = 2
        Getstock(0, 1000, 0)
    End Sub
    Private Sub Button15_Click(sender As Object, e As EventArgs)
        addstock = 2
        Getstock(0, 10000, 0)
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs)
        addstock = 2
        Getstock(0, 100000, 0)
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

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        addstock = 3
        Getstock(0, 0, HScrollBar1.Value)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)
        addstock = 3
        Getstock(0, 0, 20)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)
        addstock = 3
        Getstock(0, 0, 100)
    End Sub
    Private Sub Button13_Click(sender As Object, e As EventArgs)
        addstock = 3
        Getstock(0, 0, 1000)
    End Sub
    Private Sub Button14_Click(sender As Object, e As EventArgs)
        addstock = 3
        Getstock(0, 0, 10000)
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs)
        addstock = 3
        Getstock(0, 0, 100000)
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
        Randomize()

        weather = CInt(Rnd() * 2)
        If weather = 0 Then
            PictureBox6.ImageLocation = "sunny.PNG"
        ElseIf weather = 1 Then
            PictureBox6.ImageLocation = "cold.PNG"
        ElseIf weather = 2 Then
            PictureBox6.ImageLocation = "meh.png"
        Else

        End If


        Database.read()




    End Sub


    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        Label2.Text += Math.Round((CInt(Label4.Text) + CInt(Label5.Text) + CInt(Label7.Text)) * 0.9)
        liquidcost = Math.Round((CInt(Label4.Text) + CInt(Label5.Text) + CInt(Label7.Text)) * 0.1)
        Label4.Text = "0"
        Label5.Text = "0"
        Label7.Text = "0"
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        Me.Hide()
        Upgrade.Show()
        Upgrade.Label2.Text = Label2.Text
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs)
        'Label13.Text = "Meh"
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs)
        'Label2.Text = CInt(Label2.Text) + 200
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click

        For i As Integer = 1 To Database.usercount

            If TextBox1.Text = Database.database(i).username Then
                MsgBox("This username has already been taken")
                Exit Sub
            Else

            End If
        Next

        Database.database(Database.usercount).ID = Database.usercount
        Database.database(Database.usercount).username = TextBox1.Text
        Database.database(Database.usercount).money = Label2.Text
        Database.database(Database.usercount).score = Label2.Text
        Database.database(Database.usercount).password = TextBox2.Text
        Database.database(Database.usercount).customers = Composition.totalsales
        Database.database(Database.usercount).lemons = Label4.Text
        Database.database(Database.usercount).sugar = Label5.Text
        Database.database(Database.usercount).ice = Label7.Text
        Database.database(Database.usercount).profit = Label12.Text



        Database.usercount += 1
        Database.write()
        TextBox1.Text = ""
        TextBox2.Text = ""

    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        Me.Hide()
        Leaderboard.Show()
    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then

        Else


            For i As Integer = 1 To Database.usercount
            If Database.database(i).username = TextBox1.Text And Database.database(i).password = TextBox2.Text Then

                Label4.Text = Database.database(i).lemons.ToString
                Label5.Text = Database.database(i).sugar.ToString
                Label7.Text = Database.database(i).ice.ToString
                Label12.Text = Database.database(i).profit.ToString
                Composition.totalsales = Database.database(i).customers
                Label2.Text = Database.database(i).money.ToString


            End If

        Next
        TextBox2.Text = ""
            TextBox1.Text = ""

        End If
    End Sub

    Private Sub HScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar1.Scroll
        Button1.Text = HScrollBar1.Value.ToString + " Lemons"
        Button6.Text = HScrollBar1.Value.ToString + " Sugar"
        Button9.Text = HScrollBar1.Value.ToString + " Ice"
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        weather = 2
        PictureBox6.ImageLocation = "meh.png"
    End Sub
End Class
