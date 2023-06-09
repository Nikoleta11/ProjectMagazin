namespace Magazin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Marka = c.String(),
                        Opisanie = c.String(),
                        Price = c.Double(nullable: false),
                        Srok = c.Int(nullable: false),
                        TypesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Types", t => t.TypesId, cascadeDelete: true)
                .Index(t => t.TypesId);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "TypesId", "dbo.Types");
            DropIndex("dbo.Products", new[] { "TypesId" });
            DropTable("dbo.Types");
            DropTable("dbo.Products");
        }
    }
}
