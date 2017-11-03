Imports Core

Public Class BankRepository
    Inherits Repository
    Implements Core.IBankRepository

    Public Function GetAll() As List(Of bank) Implements IBankRepository.GetAll
        Using context As New bankdb()
            Return context.banks.ToList()
        End Using
    End Function
End Class
