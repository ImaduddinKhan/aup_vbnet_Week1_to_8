Module Module1



    Sub Main()
        Dim myBankAccount = New bankAccount()

        myBankAccount.postDeposit(10.1)
        myBankAccount.postWithdrawal(0.1)
        Console.WriteLine(myBankAccount.balance)
        Console.ReadLine()

    End Sub

End Module
