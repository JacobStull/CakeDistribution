namespace CakeDistribution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DessertMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Desserts",
                c => new
                    {
                        DessertId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        DessertName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DessertId);
            
            AddColumn("dbo.Cakes", "DessertId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cakes", "DessertId");
            AddForeignKey("dbo.Cakes", "DessertId", "dbo.Desserts", "DessertId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cakes", "DessertId", "dbo.Desserts");
            DropIndex("dbo.Cakes", new[] { "DessertId" });
            DropColumn("dbo.Cakes", "DessertId");
            DropTable("dbo.Desserts");
        }
    }
}
