Module Module1

    Sub Main()
        Dim a As Integer = 0

        'Loops
        ' While Loop
        While a <= 15.0

            a += 1

            If a >= 4 And a < 6 Then
                Continue While
            End If
            Console.Write(a.ToString & ",")
            If a = 12 Then
                Exit While
            End If
        End While

        Console.WriteLine("")

        'For Loop
        For num As Double = 0 To 10

            Console.Write(num.ToString & ",")

        Next
        Console.Read()
    End Sub

End Module
