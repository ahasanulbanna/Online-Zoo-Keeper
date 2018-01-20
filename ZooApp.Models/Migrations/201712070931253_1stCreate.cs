namespace ZooApp.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1stCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnimalFoods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnimalId = c.Int(nullable: false),
                        FoodId = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Animals", t => t.AnimalId, cascadeDelete: true)
                .ForeignKey("dbo.Foods", t => t.FoodId, cascadeDelete: true)
                .Index(t => t.AnimalId)
                .Index(t => t.FoodId);
            
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        Origin = c.String(nullable: false, maxLength: 40),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, name: "Ix_AnimalName")
                .Index(t => t.Origin, name: "Ix_AnimalOrigin");
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, name: "Ix_FoodName");
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AnimalFoods", "FoodId", "dbo.Foods");
            DropForeignKey("dbo.AnimalFoods", "AnimalId", "dbo.Animals");
            DropIndex("dbo.Foods", "Ix_FoodName");
            DropIndex("dbo.Animals", "Ix_AnimalOrigin");
            DropIndex("dbo.Animals", "Ix_AnimalName");
            DropIndex("dbo.AnimalFoods", new[] { "FoodId" });
            DropIndex("dbo.AnimalFoods", new[] { "AnimalId" });
            DropTable("dbo.Users");
            DropTable("dbo.Foods");
            DropTable("dbo.Animals");
            DropTable("dbo.AnimalFoods");
        }
    }
}
