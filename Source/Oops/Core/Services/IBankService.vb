Public Interface IBankService

    Function GetAllCustomers(ByVal bankName As String, Optional ByVal recordIndex As Integer = 0, Optional ByVal pageSize As Int32 = 100, Optional ByVal q As String = Nothing) As List(Of Customer)

End Interface
