namespace LoL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intplayerid : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LoLPlayers", "playerOrTeamId", c => c.Int(nullable: false));
            DropColumn("dbo.LoLPlayers", "playerOrTeamName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LoLPlayers", "playerOrTeamName", c => c.String());
            AlterColumn("dbo.LoLPlayers", "playerOrTeamId", c => c.String());
        }
    }
}
