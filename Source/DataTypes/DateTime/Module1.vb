Imports System.Globalization

Module Module1

    Sub Main()
        Dim d As Date

        d = System.DateTime.Now

        Console.WriteLine("Today: " & d.ToLongDateString())
        Console.WriteLine("Tomorrow: " & d.AddDays(1))
        Console.WriteLine("Next Sunday: " & d.AddDays(7 - d.Day))
        Console.WriteLine("Custom Date: " & d.ToString("dddd MMMM dd, yyyy hh:mm:ss tt"))
        Console.WriteLine("Hijri Date: " & d.ToString("MMM dd, yyyy", New CultureInfo("ar-AE")))
        Console.WriteLine("Uk Date: " & d.ToString(CultureInfo.CreateSpecificCulture("en-NZ")))
        Console.ReadLine()


        'https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings
        'https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.80).aspx?cs-save-lang=1&cs-lang=vb#code-snippet-2
    End Sub

End Module
