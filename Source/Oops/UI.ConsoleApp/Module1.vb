Imports Core
Imports System.Linq



Module Module1

    Public bankRepository As IBankRepository
    Public customerRepository As ICustomerRepository
    Public bankAccountRepository As IBankAccountRepository
    Public bankService As IBankService

    Sub Main()

        Console.WriteLine("1 local db " & Environment.NewLine & "2 sql")

        Select Case Console.ReadLine()
            Case "1"
                bankRepository = New Infra.localData.BankRepository()
                customerRepository = New Infra.localData.CustomerRepository()
                bankAccountRepository = New Infra.localData.BankAccountRepository()
                bankService = New Infra.localData.BankService()
                Infra.localData.localDB.Seed()
            Case "2"
                bankRepository = New Infra.sql.BankRepository()
                customerRepository = New Infra.sql.CustomerRepository()
                bankAccountRepository = New Infra.sql.BankAccountRepository()
                bankService = New Infra.sql.BankService()
        End Select


        Dim banks = bankRepository.GetAll()
        Dim bank = banks.FirstOrDefault()
        bankOperationMenu(bank)

    End Sub

    Private Sub bankOperationMenu(bank As bank)

        Do While True
            Console.Clear()
            Console.WriteLine("Welcome to the bank " + bank.bankName)

            Console.WriteLine("1 new customer")
            Console.WriteLine("2 listing customer")
            Console.WriteLine("0 exit")

            Select Case Console.ReadLine()
                Case "1"
                    CreateNewCustomer(bank)
                Case "2"
                    Do While True
                        Dim bankCustomers = bankService.GetAllCustomers(bank.bankName)
                        displayCustomers(bankCustomers)

                        Dim k = Console.ReadLine()
                        If k = "0" Then
                            Exit Do
                        Else
                            Dim customer = customerRepository.GetByID(k)
                            If customer Is Nothing Then
                                Console.WriteLine("No Customer found. press 0 for back menu.")
                            Else
                                customerOperationMenu(customer)
                            End If
                        End If
                    Loop
                Case "0"
                    Console.WriteLine("Good bye.")
                    Exit Do
            End Select
        Loop
    End Sub

    Private Sub customerOperationMenu(customer As Customer)
        Do While True
            Console.Clear()
            Console.WriteLine("Customer: " + customer.Name)

            Console.WriteLine("1 New bankAccount")
            Console.WriteLine("2 List accounts")
            Console.WriteLine("0 back")

            Select Case Console.ReadLine()
                Case "1"
                    CreateNewBankAccount(customer)
                Case "2"
                    Dim bankAccounts = bankAccountRepository.GetBankAccountByCustomerID(customer.ID)

                    Do While True
                        displayCustomersAccounts(bankAccounts)

                        Dim k = Console.ReadLine()
                        If k = "0" Then
                            Exit Do
                        Else
                            Dim bankAccount = bankAccountRepository.GetByAccountNumber(k)
                            If bankAccount Is Nothing Then
                                Console.WriteLine("No Customer found. press 0 for back menu.")
                            Else
                                bankAccountOperationMenu(bankAccount)
                            End If
                        End If
                    Loop
                Case "0"
                    Exit Do
            End Select
        Loop
    End Sub

    Private Sub bankAccountOperationMenu(ByVal bankAccount As bankAccount)
        Do While True
            Console.Clear()
            Console.WriteLine("Account Number: " & bankAccount.AccountNumber + " balance:" & bankAccount.balance)

            Console.WriteLine("1 Deposit")
            Console.WriteLine("2 withdrawl")
            Console.WriteLine("0 back")

            Select Case Console.ReadLine()
                Case "1"
                    Console.Write("Please enter amount:")
                    Dim balance = bankAccount.postDeposit(Decimal.Parse(Console.ReadLine()))
                    bankAccountRepository.Upadate(bankAccount)
                Case "2"
                    Console.Write("Please enter amount:")
                    bankAccount.postWithdrawal(Decimal.Parse(Console.ReadLine()))
                    bankAccountRepository.Upadate(bankAccount)
                Case "0"
                    Exit Do
            End Select
        Loop

    End Sub

    Private Sub displayCustomers(ByVal customers As List(Of Customer))
        Console.Clear()
        For Each c In customers
            Console.WriteLine("".PadLeft(100, "-"))
            Console.WriteLine(c.ID + " " + c.Name.PadRight(50, " ") + "bank accounts: (" + CStr(bankAccountRepository.GetBankAccountByCustomerID(c.ID).Sum(Function(x) x.balance)) + ")")
        Next
        Console.WriteLine("".PadLeft(100, "-"))
        Console.WriteLine("0  back to main menu")
    End Sub

    Private Sub displayCustomersAccounts(bankAccounts As List(Of bankAccount))
        Console.Clear()
        For Each ba In bankAccounts
            Console.WriteLine("".PadLeft(100, "-"))
            Console.WriteLine(ba.AccountNumber + " " + "balance: (" + CStr(ba.balance) + ")")
        Next
        Console.WriteLine("".PadLeft(100, "-"))
        Console.WriteLine("0  back to main menu")
    End Sub

    Private Sub CreateNewCustomer(ByRef bank As bank)
        Console.Clear()
        Try
            Dim customer As Customer = New Customer()

            Console.WriteLine("insert 3 letter id")
            customer.ID = Console.ReadLine()

            Console.WriteLine("insert name")
            customer.Name = Console.ReadLine()

            customer.bankName = bank.bankName

            customer.bankAccounts = New List(Of bankAccount)

            Console.WriteLine("Customer inserted successfully.")

            customerRepository.Insert(customer)

        Catch ex As Exception
            Console.WriteLine("!!!!! Failed due to: " + ex.ToString())
        End Try

    End Sub

    Private Sub CreateNewBankAccount(customer As Customer)
        Console.Clear()
        Try
            Dim bankAccount As bankAccount = New bankAccount()

            Console.WriteLine("insert 4 letter account number")
            bankAccount.AccountNumber = Console.ReadLine()

            bankAccount.CustomerID = customer.ID

            bankAccountRepository.Insert(bankAccount)

            Console.WriteLine("Bank account created successfully.")

        Catch ex As Exception
            Console.WriteLine("!!!!! Failed due to: " + ex.ToString())
        End Try

    End Sub

End Module
