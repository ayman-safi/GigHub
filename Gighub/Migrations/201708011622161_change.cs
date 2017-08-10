namespace Gighub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GIgs", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.GIgs", new[] { "Genre_Id" });
            DropColumn("dbo.GIgs", "GenreId");
            RenameColumn(table: "dbo.GIgs", name: "Genre_Id", newName: "GenreId");
            DropPrimaryKey("dbo.Genres");
            AlterColumn("dbo.Genres", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.GIgs", "GenreId", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Genres", "Id");
            CreateIndex("dbo.GIgs", "GenreId");
            AddForeignKey("dbo.GIgs", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GIgs", "GenreId", "dbo.Genres");
            DropIndex("dbo.GIgs", new[] { "GenreId" });
            DropPrimaryKey("dbo.Genres");
            AlterColumn("dbo.GIgs", "GenreId", c => c.Int());
            AlterColumn("dbo.Genres", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Genres", "Id");
            RenameColumn(table: "dbo.GIgs", name: "GenreId", newName: "Genre_Id");
            AddColumn("dbo.GIgs", "GenreId", c => c.Byte(nullable: false));
            CreateIndex("dbo.GIgs", "Genre_Id");
            AddForeignKey("dbo.GIgs", "Genre_Id", "dbo.Genres", "Id");
        }
    }
}
