Module Database
    Structure account
        Dim ID As Integer
        Dim username As String
        Dim money As Integer
        Dim score As Integer
        Dim password As String
        Dim customers As Integer
        Dim lemons As Integer
        Dim sugar As Integer
        Dim ice As Integer
        Dim profit As Integer
        Dim reputation As Double
        Dim expected As Integer


    End Structure

    Public database(1000) As account
    Public usercount As Integer = 1

    Public Sub read()
        If My.Computer.FileSystem.FileExists("U:\database.txt") Then
            Dim filetext As String = My.Computer.FileSystem.ReadAllText("U:\database.txt")
            Dim records() As String = filetext.Split("▓")
            For i As Integer = 0 To records.Length - 1
                Dim fields() As String = records(i).Split("▒")
                database(usercount).ID = fields(0)
                database(usercount).username = fields(1)
                database(usercount).money = fields(2)
                database(usercount).score = fields(3)
                database(usercount).password = fields(4)
                database(usercount).customers = fields(5)
                database(usercount).lemons = fields(6)
                database(usercount).sugar = fields(7)
                database(usercount).ice = fields(8)
                database(usercount).profit = fields(9)
                database(usercount).reputation = fields(10)
                database(usercount).expected = fields(11)
                usercount += 1
            Next
        Else
            My.Computer.FileSystem.WriteAllText("U:\database.txt", "", False)
        End If
    End Sub

    Public Sub write()
        Dim filetext As String = ""
        For i As Integer = 0 To database.Length - 1
            If database(i).username <> Nothing Then
                filetext += database(i).ID.ToString + "▒"
                filetext += database(i).username + "▒"
                filetext += database(i).money.ToString + "▒"
                filetext += database(i).score.ToString + "▒"
                filetext += database(i).password + "▒"
                filetext += database(i).customers.ToString + "▒"
                filetext += database(i).lemons.ToString + "▒"
                filetext += database(i).sugar.ToString + "▒"
                filetext += database(i).ice.ToString + "▒"
                filetext += database(i).profit.ToString + "▒"
                filetext += database(i).reputation.ToString + "▒"
                filetext += database(i).expected.ToString + "▓"
            End If
        Next
        My.Computer.FileSystem.WriteAllText("U:\database.txt", filetext, False)
        'Change to U at school, C at home
    End Sub


    ' alt + 177 = ▒


    ' alt + 178 = ▓

End Module

