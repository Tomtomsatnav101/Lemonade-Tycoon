Module AI
    Dim population As Integer = 500
    Dim aicustomer As Integer
    Dim aireputation As Double = 0.5
    Public maxcustomers As Integer
    Dim aimaxcustomers As Integer
    Public aiactualcustomers As Integer

    Public method(5, 100) As String

    Public aistartmoney As Integer
    Public aicustomers As Integer = 100
    Public aideviation As Integer
    Public aicounter As Integer = 0

    Public ailemon As Integer = 0
    Public aisugar As Integer = 0
    Public aiice As Integer = 0
    Public aimoney As Integer = 1000

    Public aiinitialmoney As Integer
    Public aitotalsales As Integer
    Public aiprogress As Integer

    Sub main()
        If Composition.AIstart >= 1 Then
            competition()
        End If

    End Sub
    Sub competition()
        maxcustomers = population * (Form1.reputation / (Form1.reputation + aireputation))
        aimaxcustomers = population - maxcustomers

    End Sub
    Sub aitry()
        If Form1.weather = 0 Then
            method(0, aicounter) = "Sunny"
        ElseIf Form1.weather = 1 Then
            method(0, aicounter) = "Cold"
        ElseIf Form1.weather = 2 Then
            method(0, aicounter) = "Meh"
        End If


        aiinitialmoney = aimoney

        Randomize()
        Dim num1 As New Random
        Dim num2 As New Random
        Dim num3 As New Random


        ailemon += 100 * num1.Next(1, 3)
        aisugar += 100 * num2.Next(1, 3)
        aiice += 100 * num3.Next(1, 3)


        aimoney = aimoney - aiice - ailemon - aisugar

        method(1, aicounter) = ailemon / 100
        method(2, aicounter) = aisugar / 100
        method(3, aicounter) = aiice / 100


        Composition.turn = 1

        Composition.money(Composition.turn)

        method(4, aicounter) = aimoney - aiinitialmoney


        aicounter += 1



    End Sub


End Module

