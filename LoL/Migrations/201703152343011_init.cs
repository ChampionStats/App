namespace LoL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Items");
            AddColumn("dbo.Items", "ItemId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Items", "id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Items", "ItemId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Items");
            AlterColumn("dbo.Items", "id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Items", "ItemId");
            AddPrimaryKey("dbo.Items", "id");
        }
    }
}
