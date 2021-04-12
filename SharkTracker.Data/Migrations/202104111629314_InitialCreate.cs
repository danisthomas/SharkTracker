namespace SharkTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ping",
                c => new
                    {
                        TagNumber = c.Int(nullable: false),
                        SharkId = c.Int(nullable: false),
                        PingId = c.Int(nullable: false),
                        PingLocation = c.String(nullable: false),
                        dateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.TagNumber, t.SharkId });
            
            CreateTable(
                "dbo.Shark",
                c => new
                    {
                        SharkId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Species = c.Int(nullable: false),
                        Length = c.Int(nullable: false),
                        Sex = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                        SharkName = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        Tag_TagNumber = c.Int(),
                        Tag_TagNumber1 = c.Int(),
                        Ping_TagNumber = c.Int(),
                        Ping_SharkId = c.Int(),
                    })
                .PrimaryKey(t => t.SharkId)
                .ForeignKey("dbo.Tag", t => t.Tag_TagNumber)
                .ForeignKey("dbo.Tag", t => t.Tag_TagNumber1)
                .ForeignKey("dbo.Ping", t => new { t.Ping_TagNumber, t.Ping_SharkId })
                .Index(t => t.Tag_TagNumber)
                .Index(t => t.Tag_TagNumber1)
                .Index(t => new { t.Ping_TagNumber, t.Ping_SharkId });
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        TagNumber = c.Int(nullable: false),
                        TagLocation = c.String(nullable: false),
                        TagDate = c.DateTime(nullable: false),
                        SharkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TagNumber)
                .ForeignKey("dbo.Shark", t => t.SharkId, cascadeDelete: true)
                .ForeignKey("dbo.Ping", t => new { t.TagNumber, t.SharkId }, cascadeDelete: true)
                .Index(t => new { t.TagNumber, t.SharkId })
                .Index(t => t.SharkId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Tag", new[] { "TagNumber", "SharkId" }, "dbo.Ping");
            DropForeignKey("dbo.Shark", new[] { "Ping_TagNumber", "Ping_SharkId" }, "dbo.Ping");
            DropForeignKey("dbo.Shark", "Tag_TagNumber1", "dbo.Tag");
            DropForeignKey("dbo.Shark", "Tag_TagNumber", "dbo.Tag");
            DropForeignKey("dbo.Tag", "SharkId", "dbo.Shark");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Tag", new[] { "SharkId" });
            DropIndex("dbo.Tag", new[] { "TagNumber", "SharkId" });
            DropIndex("dbo.Shark", new[] { "Ping_TagNumber", "Ping_SharkId" });
            DropIndex("dbo.Shark", new[] { "Tag_TagNumber1" });
            DropIndex("dbo.Shark", new[] { "Tag_TagNumber" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Tag");
            DropTable("dbo.Shark");
            DropTable("dbo.Ping");
        }
    }
}
