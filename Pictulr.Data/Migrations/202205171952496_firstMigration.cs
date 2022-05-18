namespace Pictulr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Node",
                c => new
                    {
                        NodeId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        NodeNameId = c.String(nullable: false),
                        ModelNumber = c.String(),
                        ClassificationTechnique = c.String(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.NodeId);
            
            CreateTable(
                "dbo.PictureClassification",
                c => new
                    {
                        ClassificationId = c.Int(nullable: false, identity: true),
                        PictureID = c.Int(),
                        Classification = c.String(),
                        NodeNameId = c.Int(),
                        ClassificationMethod = c.String(),
                        ReportTimeDuration = c.Time(nullable: false, precision: 7),
                        ReportTimeUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ClassificationId)
                .ForeignKey("dbo.Node", t => t.NodeNameId)
                .ForeignKey("dbo.Picture", t => t.PictureID)
                .Index(t => t.PictureID)
                .Index(t => t.NodeNameId);
            
            CreateTable(
                "dbo.SubjectClassification",
                c => new
                    {
                        ClassificationId = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(),
                        OwnerId = c.Guid(nullable: false),
                        Classification = c.String(),
                        NodeNameId = c.Int(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ClassificationId)
                .ForeignKey("dbo.Node", t => t.NodeNameId)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .Index(t => t.SubjectId)
                .Index(t => t.NodeNameId);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        SubjectName = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.Picture",
                c => new
                    {
                        PictureId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        SubjectName = c.Int(),
                        PictureTitle = c.String(nullable: false),
                        NodeNameId = c.Int(),
                        ImageLocation = c.String(),
                        Base64EncodedImage = c.String(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        RecievedUtc = c.DateTimeOffset(precision: 7),
                        OptionalMetadata = c.String(),
                    })
                .PrimaryKey(t => t.PictureId)
                .ForeignKey("dbo.Node", t => t.NodeNameId)
                .ForeignKey("dbo.Subject", t => t.SubjectName)
                .Index(t => t.SubjectName)
                .Index(t => t.NodeNameId);
            
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
            
            CreateTable(
                "dbo.SubjectClassificationPictureClassification",
                c => new
                    {
                        SubjectClassification_ClassificationId = c.Int(nullable: false),
                        PictureClassification_ClassificationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SubjectClassification_ClassificationId, t.PictureClassification_ClassificationId })
                .ForeignKey("dbo.SubjectClassification", t => t.SubjectClassification_ClassificationId, cascadeDelete: true)
                .ForeignKey("dbo.PictureClassification", t => t.PictureClassification_ClassificationId, cascadeDelete: true)
                .Index(t => t.SubjectClassification_ClassificationId)
                .Index(t => t.PictureClassification_ClassificationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.PictureClassification", "PictureID", "dbo.Picture");
            DropForeignKey("dbo.Picture", "SubjectName", "dbo.Subject");
            DropForeignKey("dbo.Picture", "NodeNameId", "dbo.Node");
            DropForeignKey("dbo.PictureClassification", "NodeNameId", "dbo.Node");
            DropForeignKey("dbo.SubjectClassification", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.SubjectClassification", "NodeNameId", "dbo.Node");
            DropForeignKey("dbo.SubjectClassificationPictureClassification", "PictureClassification_ClassificationId", "dbo.PictureClassification");
            DropForeignKey("dbo.SubjectClassificationPictureClassification", "SubjectClassification_ClassificationId", "dbo.SubjectClassification");
            DropIndex("dbo.SubjectClassificationPictureClassification", new[] { "PictureClassification_ClassificationId" });
            DropIndex("dbo.SubjectClassificationPictureClassification", new[] { "SubjectClassification_ClassificationId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Picture", new[] { "NodeNameId" });
            DropIndex("dbo.Picture", new[] { "SubjectName" });
            DropIndex("dbo.SubjectClassification", new[] { "NodeNameId" });
            DropIndex("dbo.SubjectClassification", new[] { "SubjectId" });
            DropIndex("dbo.PictureClassification", new[] { "NodeNameId" });
            DropIndex("dbo.PictureClassification", new[] { "PictureID" });
            DropTable("dbo.SubjectClassificationPictureClassification");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Picture");
            DropTable("dbo.Subject");
            DropTable("dbo.SubjectClassification");
            DropTable("dbo.PictureClassification");
            DropTable("dbo.Node");
        }
    }
}
