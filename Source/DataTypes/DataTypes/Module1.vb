Module Module1

    Sub Main()

        Dim i = 2.2, j


        Try
            Console.Write("Input value form j = ")
            ' j = Int32.Parse(Console.ReadLine())

            If (Not Int32.TryParse(Console.ReadLine(), j)) Then
                Console.WriteLine("rora khapa k ga ma kho da kho galath wo.")
            Else

                Dim k = i + j
                Console.WriteLine(k)

            End If

        Catch ex As Exception
            Console.WriteLine("rora pechacq day pake.") ' + ex.ToString())
        End Try

        Console.ReadKey()

        'Use F9 to insert breaks
        'Use F5 to debugs
        'Use F10 & F11 for step over and into
        'Open Local window for variable details
        'ctrl+k+c for commenting & ctrl+k+u for uncomment
        'ctrl+k+d for intendation & ctrl+s

    End Sub

End Module
