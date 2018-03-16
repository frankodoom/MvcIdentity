namespace MVCIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class photo_category_create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        Photo_FileId = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.Photos", t => t.Photo_FileId)
                .Index(t => t.Photo_FileId);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        FIleSize = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.FileId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "Photo_FileId", "dbo.Photos");
            DropIndex("dbo.Categories", new[] { "Photo_FileId" });
            DropTable("dbo.Photos");
            DropTable("dbo.Categories");
        }
    }
}
