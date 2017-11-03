Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class init
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.banks",
                Function(c) New With
                    {
                        .bankName = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.bankName)
            
            CreateTable(
                "dbo.Customers",
                Function(c) New With
                    {
                        .ID = c.String(nullable := False, maxLength := 128),
                        .Name = c.String(),
                        .bankName = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.banks", Function(t) t.bankName) _
                .Index(Function(t) t.bankName)
            
            CreateTable(
                "dbo.bankAccounts",
                Function(c) New With
                    {
                        .AccountNumber = c.String(nullable := False, maxLength := 128),
                        .accountBalance = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .CustomerID = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.AccountNumber) _
                .ForeignKey("dbo.Customers", Function(t) t.CustomerID) _
                .Index(Function(t) t.CustomerID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.bankAccounts", "CustomerID", "dbo.Customers")
            DropForeignKey("dbo.Customers", "bankName", "dbo.banks")
            DropIndex("dbo.bankAccounts", New String() { "CustomerID" })
            DropIndex("dbo.Customers", New String() { "bankName" })
            DropTable("dbo.bankAccounts")
            DropTable("dbo.Customers")
            DropTable("dbo.banks")
        End Sub
    End Class
End Namespace
