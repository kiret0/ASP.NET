namespace Prodavalnik.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "SubCategories_Id", "dbo.Categories");
            DropIndex("dbo.Categories", new[] { "SubCategories_Id" });
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageName = c.String(),
                        Ad_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ads", t => t.Ad_Id)
                .Index(t => t.Ad_Id);
            
            DropColumn("dbo.Categories", "SubCategories_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "SubCategories_Id", c => c.Int());
            DropForeignKey("dbo.Images", "Ad_Id", "dbo.Ads");
            DropIndex("dbo.Images", new[] { "Ad_Id" });
            DropTable("dbo.Images");
            CreateIndex("dbo.Categories", "SubCategories_Id");
            AddForeignKey("dbo.Categories", "SubCategories_Id", "dbo.Categories", "Id");
        }
    }
}
