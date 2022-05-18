namespace Pictulr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigggg : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Picture", "PictureTitle", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Picture", "PictureTitle", c => c.String(nullable: false));
        }
    }
}
