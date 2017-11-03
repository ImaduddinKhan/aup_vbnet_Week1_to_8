'Using System;
'    Using System.Collections.Generic;
'    Using System.Data.Entity;
'    Using System.Linq;

Imports System
Imports System.Collections.Generic
Imports System.Data.Entity
Imports System.Linq
Imports Core

Public Class BankDb
    Inherits DbContext

    Public Sub New()
        MyBase.New("BankDb")
    End Sub

    Public Property banks() As DbSet(Of bank)
    Public Property customers() As DbSet(Of Customer)
    Public Property bankAccounts() As DbSet(Of bankAccount)

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        MyBase.OnModelCreating(modelBuilder)

        'Set the Primary Keys
        modelBuilder.Entity(Of bank).HasKey(Function(c) c.bankName)
        modelBuilder.Entity(Of Customer).HasKey(Function(c) c.ID).HasRequired(Function(b) b.bank).WithMany(Function(c) c.customers).HasForeignKey(Function(c) c.bankName).WillCascadeOnDelete(False)
        modelBuilder.Entity(Of bankAccount).HasKey(Function(c) c.AccountNumber).HasRequired(Function(b) b.customer).WithMany(Function(c) c.bankAccounts).HasForeignKey(Function(c) c.CustomerID).WillCascadeOnDelete(False)

        'Set Complex Primary Key to Identity(MS SQL Auto-Increment)
        'modelBuilder.Entity(Of Complex).Property(Function(c) c.ComplexId) _
        '.HasDatabaseGeneratedOption(ComponentModel.DataAnnotations.DatabaseGeneratedOption.Identity)
    End Sub


End Class

'https://msdn.microsoft.com/en-us/library/jj631642(v=vs.113).aspx
'https://msdn.microsoft.com/en-us/library/jj591621(v=vs.113).aspx
'https://msdn.microsoft.com/en-us/library/jj591617(v=vs.113).aspx