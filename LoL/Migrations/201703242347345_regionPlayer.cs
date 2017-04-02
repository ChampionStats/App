namespace LoL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class regionPlayer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LoLPlayers", "region", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LoLPlayers", "region");
        }
    }
}
