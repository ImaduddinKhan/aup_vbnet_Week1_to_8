Imports Core

Public Class BankRepository
    Inherits Repository
    Implements Core.IBankRepository

    Public Function GetAll() As List(Of bank) Implements IBankRepository.GetAll
        Return localDB.banks
    End Function
End Class
