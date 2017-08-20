namespace Gighub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addnotification1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Notifications", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notifications", "MyProperty", c => c.Int(nullable: false));
        }
    }
}
