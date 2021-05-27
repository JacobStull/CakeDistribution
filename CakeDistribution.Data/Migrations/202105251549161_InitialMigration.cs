namespace CakeDistribution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        JobTitle = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            AddColumn("dbo.Customer", "OwnerId", c => c.Guid(nullable: false));
            DropColumn("dbo.Customer", "FullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "FullName", c => c.String(nullable: false));
            DropColumn("dbo.Customer", "OwnerId");
            DropTable("dbo.Employee");
        }
    }
}
