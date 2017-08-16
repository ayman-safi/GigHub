namespace Gighub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gigdeleteproperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GIgs", "IsCanceled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GIgs", "IsCanceled");
        }
    }
}
