namespace SharkTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Tag", new[] { "SharkId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Tag", "SharkId");
        }
    }
}
