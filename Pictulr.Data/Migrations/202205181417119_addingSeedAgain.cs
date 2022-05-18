namespace Pictulr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingSeedAgain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Picture", "SubjectName", "dbo.Subject");
            DropIndex("dbo.Picture", new[] { "SubjectName" });
            AddColumn("dbo.Picture", "SubjectId", c => c.Int());
            AddColumn("dbo.Picture", "NodeName", c => c.String());
            AddColumn("dbo.Picture", "AddImage", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Picture", "SubjectName", c => c.String());
            CreateIndex("dbo.Picture", "SubjectId");
            AddForeignKey("dbo.Picture", "SubjectId", "dbo.Subject", "SubjectId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Picture", "SubjectId", "dbo.Subject");
            DropIndex("dbo.Picture", new[] { "SubjectId" });
            AlterColumn("dbo.Picture", "SubjectName", c => c.Int());
            DropColumn("dbo.Picture", "AddImage");
            DropColumn("dbo.Picture", "NodeName");
            DropColumn("dbo.Picture", "SubjectId");
            CreateIndex("dbo.Picture", "SubjectName");
            AddForeignKey("dbo.Picture", "SubjectName", "dbo.Subject", "SubjectId");
        }
    }
}
