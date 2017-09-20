Module Module1

    Sub Main()

        Dim len = 4
        Dim num(len - 1) As Integer

        num(0) = 10
        num(1) = 2
        num(2) = 4
        num(3) = 1

        dispalyArray(num)

        Console.WriteLine("Press Enter to clear the screen.")
        Console.ReadLine()
        Console.Clear()

        For i = 0 To (num.Length - 1)
            num(i) = Int32.Parse(Console.ReadLine())
        Next

        dispalyArray(num)

        Console.ReadLine()

        'If code is repeated twice ignore it, if more than use functions
        'https://docs.microsoft.com/en-us/dotnet/visual-basic/programming-guide/language-features/arrays/
    End Sub

    Sub dispalyArray(ByVal num)
        Console.WriteLine("Dispalying array with length.")

        For Each n In num
            Console.WriteLine(n)
        Next
    End Sub

End Module
