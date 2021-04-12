namespace SharkTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changenameonDatetimeprop : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Tag", new[] { "SharkId" });
            AddColumn("dbo.Ping", "PingDateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Ping", "dateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ping", "dateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Ping", "PingDateTime");
            CreateIndex("dbo.Tag", "SharkId");
        }
    }
}
