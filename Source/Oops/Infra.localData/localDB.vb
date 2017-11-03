Imports Core
Imports System.Linq

Public NotInheritable Class localDB
    Public Shared banks As List(Of bank)
    Public Shared customers As List(Of Customer)
    Public Shared bankAccounts As List(Of bankAccount)

    Public Shared Sub Seed()
        banks = New List(Of bank)()
        customers = New List(Of Customer)()
        bankAccounts = New List(Of bankAccount)

        Dim _bank = New bank() With {.bankName = "Alaa Bank"}
        banks.Add(_bank)

        Dim _customer1 = New Customer() With {.ID = "123", .Name = "Madu", .bankName = _bank.bankName}
        customers.Add(_customer1)

        Dim _customer2 = New Customer() With {.ID = "124", .Name = "Bero", .bankName = _bank.bankName}
        customers.Add(_customer2)

        bankAccounts.Add(New bankAccount() With {.AccountNumber = "A123", .CustomerID = _customer1.ID})
        bankAccounts.Add(New bankAccount() With {.AccountNumber = "A234", .CustomerID = _customer1.ID})
        bankAccounts.Add(New bankAccount() With {.AccountNumber = "B134", .CustomerID = _customer2.ID})
        'bankAccounts.AddRange(_bank.customers.Select(Function(c) c.bankAccounts).ToList())
    End Sub

End Class
