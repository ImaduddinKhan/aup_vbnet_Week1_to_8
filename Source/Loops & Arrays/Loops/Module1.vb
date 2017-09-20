Module Module1

    Sub Main()
        Dim a As Integer = 0

        'Loops
        ' While Loop
        Console.WriteLine("   While Loop   ")
        While a <= 15.0

            a += 1

            If a >= 4 And a < 6 Then
                Continue While
            End If
            Console.Write(a.ToString & "  ")
            If a = 12 Then
                Exit While
            End If
        End While

        Console.WriteLine(vbCrLf & vbCrLf & "   For Loop   ")

        'For Loop
        For num = 1 To 10

            Dim ab As New System.Text.StringBuilder()

            For num1 = 5 To 0 Step -3
                ab.Append(num.ToString)
                ab.Append("test")
            Next

            Console.Write(num.ToString & "  ")

        Next
        Console.Read()
    End Sub

End Module
