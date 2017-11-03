Imports Core

Public Class BankAccountRepository
    Inherits Repository
    Implements Core.IBankAccountRepository

    Public Function Delete(AccountNumber As String) As Boolean Implements IBankAccountRepository.Delete
        Dim a = GetByAccountNumber(AccountNumber)

        If a Is Nothing Then
            Messages.Add("no account found.")
            Return False
        Else
            db.bankAccounts.Remove(a)
            db.SaveChanges()
        End If

        Return True
    End Function

    Public Function GetBankAccountByCustomerID(customerID As String) As List(Of bankAccount) Implements IBankAccountRepository.GetBankAccountByCustomerID
        Dim accounts = From b In db.bankAccounts
                       Where b.CustomerID = customerID
                       Select b

        Return accounts.ToList()
    End Function

    Public Function GetByAccountNumber(AccountNumber As String) As bankAccount Implements IBankAccountRepository.GetByAccountNumber
        Dim accounts = From b In db.bankAccounts
                       Where b.AccountNumber = AccountNumber
                       Select b

        Return accounts.FirstOrDefault()
        'Return db.bankAccounts.FirstOrDefault(Function(x) x.AccountNumber = AccountNumber) 'lamda expression

    End Function

    Public Function Insert(bankAccount As bankAccount) As Boolean Implements IBankAccountRepository.Insert
        Dim customer = (From c In db.customers
                        Where c.ID = bankAccount.CustomerID
                        Select c).FirstOrDefault()

        If customer Is Nothing Then
            Messages.Add("no customer found.")
            Return False
        Else
            customer.bankAccounts.Add(bankAccount)
            db.bankAccounts.Add(bankAccount)
            db.SaveChanges()
        End If

        Return True
    End Function

    Public Function Upadate(bankAccount As bankAccount) As Boolean Implements IBankAccountRepository.Upadate
        Dim customer = (From c In db.customers
                        Where c.ID = bankAccount.CustomerID
                        Select c).FirstOrDefault()

        If customer Is Nothing Then

            Messages.Add("no customer found.")
            Return False
        Else
            Dim account = (From b In db.bankAccounts
                           Where b.AccountNumber = bankAccount.AccountNumber
                           Select b).FirstOrDefault()

            If account Is Nothing Then
                Messages.Add("no account found.")
                Return False
            Else
                account = bankAccount
            End If
        End If

        Return True
    End Function
End Class
