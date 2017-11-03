Public Interface IBankAccountRepository

    'CRUD opperation

    Function GetBankAccountByCustomerID(ByVal customerID As String) As List(Of bankAccount)

    Function GetByAccountNumber(ByVal AccountNumber As String) As bankAccount

    Function Insert(ByVal bankAccount As bankAccount) As Boolean

    Function Delete(ByVal AccountNumber As String) As Boolean

    Function Upadate(ByVal bankAccount As bankAccount) As Boolean

End Interface
