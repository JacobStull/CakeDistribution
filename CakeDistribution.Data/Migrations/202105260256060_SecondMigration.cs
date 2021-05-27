namespace CakeDistribution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Cake", newName: "Cakes");
            RenameTable(name: "dbo.Customer", newName: "Customers");
            RenameTable(name: "dbo.Employee", newName: "Employees");
            AddColumn("dbo.Cakes", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cakes", "OwnerId");
            RenameTable(name: "dbo.Employees", newName: "Employee");
            RenameTable(name: "dbo.Customers", newName: "Customer");
            RenameTable(name: "dbo.Cakes", newName: "Cake");
        }
    }
}
