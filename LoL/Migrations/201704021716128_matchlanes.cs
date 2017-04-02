namespace LoL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class matchlanes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MatchLanes",
                c => new
                    {
                        MatchLanesID = c.Int(nullable: false, identity: true),
                        matchId = c.Long(nullable: false),
                        playerId = c.Int(nullable: false),
                        lane = c.String(),
                        role = c.String(),
                    })
                .PrimaryKey(t => t.MatchLanesID);
            
            AddColumn("dbo.ParticipantIds", "champion", c => c.Int(nullable: false));
            DropColumn("dbo.Matchlists", "champion");
            DropColumn("dbo.Matchlists", "lane");
            DropColumn("dbo.Matchlists", "role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Matchlists", "role", c => c.String());
            AddColumn("dbo.Matchlists", "lane", c => c.String());
            AddColumn("dbo.Matchlists", "champion", c => c.Int(nullable: false));
            DropColumn("dbo.ParticipantIds", "champion");
            DropTable("dbo.MatchLanes");
        }
    }
}
