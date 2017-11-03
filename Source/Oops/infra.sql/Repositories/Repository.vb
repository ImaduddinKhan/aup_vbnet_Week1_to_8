Imports Core

Public Class Repository
    Implements Core.IRepository

    Private _Messages As List(Of String)

    Private _db As BankDb
    Public ReadOnly Property db() As BankDb
        Get
            Return _db
        End Get
    End Property

    Public Property Messages As List(Of String) Implements IRepository.Messages
        Get
            Return _Messages
        End Get
        Set(value As List(Of String))
            _Messages = value
        End Set
    End Property

    Public Sub New()
        _Messages = New List(Of String)()
        _db = New BankDb()
    End Sub

End Class
