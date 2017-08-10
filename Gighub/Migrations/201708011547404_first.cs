namespace Gighub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GIgs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Venue = c.String(nullable: false, maxLength: 255),
                        Artist_Id = c.String(nullable: false, maxLength: 128),
                        Genre_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Artist_Id, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.Genre_Id, cascadeDelete: true)
                .Index(t => t.Artist_Id)
                .Index(t => t.Genre_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GIgs", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.GIgs", "Artist_Id", "dbo.AspNetUsers");
            DropIndex("dbo.GIgs", new[] { "Genre_Id" });
            DropIndex("dbo.GIgs", new[] { "Artist_Id" });
            DropTable("dbo.GIgs");
            DropTable("dbo.Genres");
        }
    }
}
