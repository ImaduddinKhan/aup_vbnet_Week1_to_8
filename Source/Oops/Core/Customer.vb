Public Class Customer

    Private _ID As String
    Private _name As String

    Public Property ID() As String
        Get
            Return _ID
        End Get
        Set(ByVal value As String)
            If value.Length <> 3 Then
                Throw New Exception("Wrong ID assigned")
                _ID = -1
            Else
                _ID = value
            End If
        End Set
    End Property

    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    Private _bankAccounts As List(Of bankAccount)
    Public Property bankAccounts() As List(Of bankAccount)
        Get
            Return _bankAccounts
        End Get
        Set(ByVal value As List(Of bankAccount))
            _bankAccounts = value
        End Set
    End Property

    Public Sub New()
        bankAccounts = New List(Of bankAccount)()
    End Sub

    Private _bankName As String

    Public Property bankName() As String
        Get
            Return _bankName
        End Get
        Set(ByVal value As String)
            _bankName = value
        End Set
    End Property

    Private _bank As bank
    Public Property bank() As bank
        Get
            Return _bank
        End Get
        Set(ByVal value As bank)
            _bank = value
        End Set
    End Property
End Class
