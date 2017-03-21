namespace LoL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testupdate : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Masteries", newName: "StaticMasteries");
            RenameTable(name: "dbo.Matches", newName: "MatchDatas");
            RenameTable(name: "dbo.Participants", newName: "ParticipantLists");
            RenameTable(name: "dbo.Runes", newName: "StaticRunes");
            RenameColumn(table: "dbo.ParticipantIds", name: "Match_ID", newName: "MatchData_ID");
            RenameColumn(table: "dbo.ParticipantLists", name: "Match_ID", newName: "MatchData_ID");
            RenameColumn(table: "dbo.Teams", name: "Match_ID", newName: "MatchData_ID");
            RenameIndex(table: "dbo.ParticipantIds", name: "IX_Match_ID", newName: "IX_MatchData_ID");
            RenameIndex(table: "dbo.ParticipantLists", name: "IX_Match_ID", newName: "IX_MatchData_ID");
            RenameIndex(table: "dbo.Teams", name: "IX_Match_ID", newName: "IX_MatchData_ID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Teams", name: "IX_MatchData_ID", newName: "IX_Match_ID");
            RenameIndex(table: "dbo.ParticipantLists", name: "IX_MatchData_ID", newName: "IX_Match_ID");
            RenameIndex(table: "dbo.ParticipantIds", name: "IX_MatchData_ID", newName: "IX_Match_ID");
            RenameColumn(table: "dbo.Teams", name: "MatchData_ID", newName: "Match_ID");
            RenameColumn(table: "dbo.ParticipantLists", name: "MatchData_ID", newName: "Match_ID");
            RenameColumn(table: "dbo.ParticipantIds", name: "MatchData_ID", newName: "Match_ID");
            RenameTable(name: "dbo.StaticRunes", newName: "Runes");
            RenameTable(name: "dbo.ParticipantLists", newName: "Participants");
            RenameTable(name: "dbo.MatchDatas", newName: "Matches");
            RenameTable(name: "dbo.StaticMasteries", newName: "Masteries");
        }
    }
}
