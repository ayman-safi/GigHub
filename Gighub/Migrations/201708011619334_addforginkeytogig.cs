namespace Gighub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addforginkeytogig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GIgs", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.GIgs", new[] { "Genre_Id" });
            RenameColumn(table: "dbo.GIgs", name: "Artist_Id", newName: "ArtistId");
            RenameIndex(table: "dbo.GIgs", name: "IX_Artist_Id", newName: "IX_ArtistId");
            AddColumn("dbo.GIgs", "GenreId", c => c.Byte(nullable: false));
            AlterColumn("dbo.GIgs", "Genre_Id", c => c.Int());
            CreateIndex("dbo.GIgs", "Genre_Id");
            AddForeignKey("dbo.GIgs", "Genre_Id", "dbo.Genres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GIgs", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.GIgs", new[] { "Genre_Id" });
            AlterColumn("dbo.GIgs", "Genre_Id", c => c.Int(nullable: false));
            DropColumn("dbo.GIgs", "GenreId");
            RenameIndex(table: "dbo.GIgs", name: "IX_ArtistId", newName: "IX_Artist_Id");
            RenameColumn(table: "dbo.GIgs", name: "ArtistId", newName: "Artist_Id");
            CreateIndex("dbo.GIgs", "Genre_Id");
            AddForeignKey("dbo.GIgs", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
        }
    }
}
