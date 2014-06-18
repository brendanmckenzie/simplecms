namespace SimpleCms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTitleToNode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Nodes", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Nodes", "Title");
        }
    }
}
