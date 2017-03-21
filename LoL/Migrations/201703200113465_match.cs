namespace LoL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class match : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        matchId = c.Long(nullable: false),
                        region = c.String(),
                        platformId = c.String(),
                        matchMode = c.String(),
                        matchType = c.String(),
                        matchCreation = c.Long(nullable: false),
                        matchDuration = c.Int(nullable: false),
                        queueType = c.String(),
                        mapId = c.Int(nullable: false),
                        season = c.String(),
                        matchVersion = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ParticipantIdentities",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        matchid = c.Long(nullable: false),
                        participantId = c.Int(nullable: false),
                        playerid = c.Int(nullable: false),
                        Match_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Matches", t => t.Match_ID)
                .Index(t => t.Match_ID);
            
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        partId = c.Int(nullable: false, identity: true),
                        MatchId = c.Long(nullable: false),
                        teamId = c.Int(nullable: false),
                        spell1Id = c.Int(nullable: false),
                        spell2Id = c.Int(nullable: false),
                        championId = c.Int(nullable: false),
                        highestAchievedSeasonTier = c.String(),
                        participantId = c.Int(nullable: false),
                        Match_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.partId)
                .ForeignKey("dbo.Matches", t => t.Match_ID)
                .Index(t => t.Match_ID);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        matchid = c.Long(nullable: false),
                        teamId = c.Int(nullable: false),
                        winner = c.Boolean(nullable: false),
                        firstBlood = c.Boolean(nullable: false),
                        firstTower = c.Boolean(nullable: false),
                        firstInhibitor = c.Boolean(nullable: false),
                        firstBaron = c.Boolean(nullable: false),
                        firstDragon = c.Boolean(nullable: false),
                        firstRiftHerald = c.Boolean(nullable: false),
                        towerKills = c.Int(nullable: false),
                        inhibitorKills = c.Int(nullable: false),
                        baronKills = c.Int(nullable: false),
                        dragonKills = c.Int(nullable: false),
                        riftHeraldKills = c.Int(nullable: false),
                        vilemawKills = c.Int(nullable: false),
                        dominionVictoryScore = c.Int(nullable: false),
                        Match_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Matches", t => t.Match_ID)
                .Index(t => t.Match_ID);
            
            CreateTable(
                "dbo.ParticipantMasteries",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        participantid = c.Int(nullable: false),
                        masteryId = c.Int(nullable: false),
                        rank = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ParticipantRunes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        participantid = c.Int(nullable: false),
                        runeId = c.Int(nullable: false),
                        rank = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ParticipantStats",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        participantid = c.Int(nullable: false),
                        winner = c.Boolean(nullable: false),
                        champLevel = c.Int(nullable: false),
                        item0 = c.Int(nullable: false),
                        item1 = c.Int(nullable: false),
                        item2 = c.Int(nullable: false),
                        item3 = c.Int(nullable: false),
                        item4 = c.Int(nullable: false),
                        item5 = c.Int(nullable: false),
                        item6 = c.Int(nullable: false),
                        kills = c.Int(nullable: false),
                        doubleKills = c.Int(nullable: false),
                        tripleKills = c.Int(nullable: false),
                        quadraKills = c.Int(nullable: false),
                        pentaKills = c.Int(nullable: false),
                        unrealKills = c.Int(nullable: false),
                        largestKillingSpree = c.Int(nullable: false),
                        deaths = c.Int(nullable: false),
                        assists = c.Int(nullable: false),
                        totalDamageDealt = c.Int(nullable: false),
                        totalDamageDealtToChampions = c.Int(nullable: false),
                        totalDamageTaken = c.Int(nullable: false),
                        largestCriticalStrike = c.Int(nullable: false),
                        totalHeal = c.Int(nullable: false),
                        minionsKilled = c.Int(nullable: false),
                        neutralMinionsKilled = c.Int(nullable: false),
                        neutralMinionsKilledTeamJungle = c.Int(nullable: false),
                        neutralMinionsKilledEnemyJungle = c.Int(nullable: false),
                        goldEarned = c.Int(nullable: false),
                        goldSpent = c.Int(nullable: false),
                        combatPlayerScore = c.Int(nullable: false),
                        objectivePlayerScore = c.Int(nullable: false),
                        totalPlayerScore = c.Int(nullable: false),
                        totalScoreRank = c.Int(nullable: false),
                        magicDamageDealtToChampions = c.Int(nullable: false),
                        physicalDamageDealtToChampions = c.Int(nullable: false),
                        trueDamageDealtToChampions = c.Int(nullable: false),
                        visionWardsBoughtInGame = c.Int(nullable: false),
                        sightWardsBoughtInGame = c.Int(nullable: false),
                        magicDamageDealt = c.Int(nullable: false),
                        physicalDamageDealt = c.Int(nullable: false),
                        trueDamageDealt = c.Int(nullable: false),
                        magicDamageTaken = c.Int(nullable: false),
                        physicalDamageTaken = c.Int(nullable: false),
                        trueDamageTaken = c.Int(nullable: false),
                        firstBloodKill = c.Boolean(nullable: false),
                        firstBloodAssist = c.Boolean(nullable: false),
                        firstTowerKill = c.Boolean(nullable: false),
                        firstTowerAssist = c.Boolean(nullable: false),
                        firstInhibitorKill = c.Boolean(nullable: false),
                        firstInhibitorAssist = c.Boolean(nullable: false),
                        inhibitorKills = c.Int(nullable: false),
                        towerKills = c.Int(nullable: false),
                        wardsPlaced = c.Int(nullable: false),
                        wardsKilled = c.Int(nullable: false),
                        largestMultiKill = c.Int(nullable: false),
                        killingSprees = c.Int(nullable: false),
                        totalUnitsHealed = c.Int(nullable: false),
                        totalTimeCrowdControlDealt = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teams", "Match_ID", "dbo.Matches");
            DropForeignKey("dbo.Participants", "Match_ID", "dbo.Matches");
            DropForeignKey("dbo.ParticipantIdentities", "Match_ID", "dbo.Matches");
            DropIndex("dbo.Teams", new[] { "Match_ID" });
            DropIndex("dbo.Participants", new[] { "Match_ID" });
            DropIndex("dbo.ParticipantIdentities", new[] { "Match_ID" });
            DropTable("dbo.ParticipantStats");
            DropTable("dbo.ParticipantRunes");
            DropTable("dbo.ParticipantMasteries");
            DropTable("dbo.Teams");
            DropTable("dbo.Participants");
            DropTable("dbo.ParticipantIdentities");
            DropTable("dbo.Matches");
        }
    }
}
