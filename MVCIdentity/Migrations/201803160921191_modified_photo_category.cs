namespace MVCIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modified_photo_category : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "Photo_FileId", "dbo.Photos");
            DropIndex("dbo.Categories", new[] { "Photo_FileId" });
            AddColumn("dbo.Photos", "FileType", c => c.String());
            DropTable("dbo.Categories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        Photo_FileId = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            DropColumn("dbo.Photos", "FileType");
            CreateIndex("dbo.Categories", "Photo_FileId");
            AddForeignKey("dbo.Categories", "Photo_FileId", "dbo.Photos", "FileId");
        }
    }
}
