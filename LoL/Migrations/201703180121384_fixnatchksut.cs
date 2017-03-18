namespace LoL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixnatchksut : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matchlists", "matchId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Matchlists", "matchId");
        }
    }
}
