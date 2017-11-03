Public Interface ICustomerRepository
    'CRUD opperation

    Function GetAll(Optional ByVal q As String = Nothing) As List(Of Customer)

    Function GetByID(ByVal ID As String) As Customer

    Function Insert(ByVal customer As Customer) As Boolean

    Function Delete(ByVal ID As String) As Boolean

    Function Upadate(ByVal customer As Customer) As Boolean

End Interface
