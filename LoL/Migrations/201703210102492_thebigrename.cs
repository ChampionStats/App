namespace LoL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thebigrename : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ParticipantIdentities", newName: "ParticipantIds");
            RenameTable(name: "dbo.Players", newName: "LoLPlayers");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.LoLPlayers", newName: "Players");
            RenameTable(name: "dbo.ParticipantIds", newName: "ParticipantIdentities");
        }
    }
}
