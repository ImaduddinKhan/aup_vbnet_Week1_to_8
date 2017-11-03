Public Class bank

    Public Property bankName() As String

    Public Overridable Property customers() As List(Of Customer)

    Public Sub New()
        customers = New List(Of Customer)()
    End Sub

End Class
