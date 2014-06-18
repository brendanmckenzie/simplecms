namespace SimpleCms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMissingTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pages", "Parent_Id", "dbo.Pages");
            DropIndex("dbo.Pages", new[] { "Parent_Id" });
            CreateTable(
                "dbo.DocumentTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Fields = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Nodes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Type = c.Int(nullable: false),
                        UrlKey = c.String(),
                        Redirect = c.String(),
                        Controller = c.String(),
                        Action = c.String(),
                        DocumentData = c.String(),
                        DocumentType_Id = c.Guid(),
                        Parent_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DocumentTypes", t => t.DocumentType_Id)
                .ForeignKey("dbo.Nodes", t => t.Parent_Id)
                .Index(t => t.DocumentType_Id)
                .Index(t => t.Parent_Id);
            
            DropTable("dbo.Pages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        UrlKey = c.String(),
                        Controller = c.String(),
                        Action = c.String(),
                        Parent_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Nodes", "Parent_Id", "dbo.Nodes");
            DropForeignKey("dbo.Nodes", "DocumentType_Id", "dbo.DocumentTypes");
            DropIndex("dbo.Nodes", new[] { "Parent_Id" });
            DropIndex("dbo.Nodes", new[] { "DocumentType_Id" });
            DropTable("dbo.Nodes");
            DropTable("dbo.DocumentTypes");
            CreateIndex("dbo.Pages", "Parent_Id");
            AddForeignKey("dbo.Pages", "Parent_Id", "dbo.Pages", "Id");
        }
    }
}
