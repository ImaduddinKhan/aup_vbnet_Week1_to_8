Imports Core

Public Class BankService
    Implements Core.IBankService

    Public Function GetAllCustomers(bankName As String, Optional recordIndex As Integer = 0, Optional pageSize As Integer = 100, Optional q As String = Nothing) As List(Of Customer) Implements IBankService.GetAllCustomers
        Dim ctx = New BankDb()

        Dim customers = From c In ctx.customers
                        Where c.bankName = bankName And (q Is Nothing Or c.ID = q Or c.Name = q)
                        Select c

        Return customers.OrderBy(Function(c) c.ID).Skip(recordIndex).Take(pageSize).ToList()

    End Function
End Class
