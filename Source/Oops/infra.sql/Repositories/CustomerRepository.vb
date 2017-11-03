Imports Core

Public Class CustomerRepository
    Inherits Repository
    Implements Core.ICustomerRepository


    Public Function Delete(ID As String) As Boolean Implements ICustomerRepository.Delete
        Dim c = GetByID(ID)

        If c Is Nothing Then
            Messages.Add("no customer found.")
            Return False
        Else
            If c.bankAccounts.Count > 0 Then
                Return False
            Else
                db.customers.Remove(c)
                db.SaveChanges()
            End If
        End If

        Return True
    End Function

    Public Function GetAll(Optional q As String = Nothing) As List(Of Customer) Implements ICustomerRepository.GetAll
        Return (From c In db.customers
                Where q Is Nothing Or c.ID = q Or c.Name = q
                Select c).ToList()
    End Function

    Public Function GetByID(ID As String) As Customer Implements ICustomerRepository.GetByID
        Return (From c In db.customers
                Where c.ID = ID
                Select c).FirstOrDefault()
    End Function

    Public Function Insert(customer As Customer) As Boolean Implements ICustomerRepository.Insert
        db.customers.Add(customer)
        db.SaveChanges()
    End Function

    Public Function Upadate(customer As Customer) As Boolean Implements ICustomerRepository.Upadate
        Return True
    End Function
End Class
