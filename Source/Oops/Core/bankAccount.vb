
Imports System.ComponentModel.DataAnnotations

Public Class bankAccount
    Private _accountBalance As Decimal

    Public Property accountBalance() As Decimal
        Get
            Return _accountBalance
        End Get
        Set(ByVal value As Decimal)
            _accountBalance = value
        End Set
    End Property


    Public holdOnAccount As Boolean = False
    Private _AccountNumber As String
    Public Property AccountNumber() As String
        Get
            Return _AccountNumber
        End Get
        Set(ByVal value As String)
            _AccountNumber = value
        End Set
    End Property
    Public ReadOnly Property balance() As Decimal
        Get
            Return _accountBalance
        End Get
    End Property

    ''' <summary>
    ''' This function is used for post deposit and returns balance
    ''' </summary>
    ''' <param name="amountIn"></param>
    ''' <returns></returns>
    Public Function postDeposit(ByVal amountIn As Decimal) As Decimal
        _accountBalance = _accountBalance + amountIn
        Return _accountBalance
    End Function

    Public Sub postWithdrawal(ByVal amountOut As Decimal)
        If holdOnAccount Then
            Throw New Exception("Account is on hold.")
        Else
            _accountBalance = _accountBalance - amountOut
        End If
    End Sub

    'Public CustomerID As String
    'Public customer As Customer

    Private _customerID As String
    Public Property CustomerID() As String
        Get
            Return _customerID
        End Get
        Set(ByVal value As String)
            _customerID = value
        End Set
    End Property

    Private _Customer As Customer
    Public Property customer() As Customer
        Get
            Return _Customer
        End Get
        Set(ByVal value As Customer)
            _Customer = value
        End Set
    End Property


End Class