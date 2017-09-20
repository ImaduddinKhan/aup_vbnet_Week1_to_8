Module Module1

    Sub Main()
        Dim num(3) As Integer

        num(0) = 10
        num(1) = 2
        num(2) = 4
        num(3) = 1


        For i = 0 To num.Length - 1 Step 1
            Console.WriteLine(num(i))
        Next


        For Each n In num
            Console.WriteLine(n)
        Next

        Console.ReadLine()


    End Sub

End Module
