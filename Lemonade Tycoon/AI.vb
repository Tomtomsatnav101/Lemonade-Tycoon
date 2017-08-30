Module AI
    Dim population As Integer = 500
    Dim aicustomer As Integer
    Dim aireputation As Double = 0.5
    Public maxcustomers As Integer
    Dim aimaxcustomers As Integer

    Public method(5, 100) As String

    Public aistartmoney As Integer
    Public aicustomers As Integer = 100
    Public aideviation As Integer
    Public aicounter As Integer = 0

    Sub main()
        If Composition.AIcounter >= 1 Then
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
    End Sub

End Module

