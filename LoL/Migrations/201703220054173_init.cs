namespace LoL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Champions",
                c => new
                    {
                        ChampionId = c.Int(nullable: false, identity: true),
                        id = c.Int(nullable: false),
                        title = c.String(),
                        key = c.String(),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.ChampionId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        plaintext = c.String(),
                        description = c.String(),
                        id = c.Int(nullable: false),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.ItemId);
            
            CreateTable(
                "dbo.StaticMasteries",
                c => new
                    {
                        MasteryId = c.Int(nullable: false, identity: true),
                        id = c.Int(nullable: false),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.MasteryId);
            
            CreateTable(
                "dbo.MatchDatas",
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
                "dbo.Matchlists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        region = c.String(),
                        platformId = c.String(),
                        matchId = c.Long(nullable: false),
                        champion = c.Int(nullable: false),
                        queue = c.String(),
                        season = c.String(),
                        lane = c.String(),
                        role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ParticipantLists",
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
                    })
                .PrimaryKey(t => t.partId);
            
            CreateTable(
                "dbo.ParticipantIds",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        matchid = c.Long(nullable: false),
                        participantId = c.Int(nullable: false),
                        playerid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
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
            
            CreateTable(
                "dbo.LoLPlayers",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        playerOrTeamId = c.String(),
                        playerOrTeamName = c.String(),
                        rank = c.String(),
                    })
                .PrimaryKey(t => t.PlayerId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.StaticRunes",
                c => new
                    {
                        RunesId = c.Int(nullable: false, identity: true),
                        description = c.String(),
                        id = c.Int(nullable: false),
                        name = c.String(),
                        tier = c.String(),
                        type = c.String(),
                        isRune = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RunesId);
            
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
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Teams");
            DropTable("dbo.StaticRunes");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.LoLPlayers");
            DropTable("dbo.ParticipantStats");
            DropTable("dbo.ParticipantRunes");
            DropTable("dbo.ParticipantMasteries");
            DropTable("dbo.ParticipantIds");
            DropTable("dbo.ParticipantLists");
            DropTable("dbo.Matchlists");
            DropTable("dbo.MatchDatas");
            DropTable("dbo.StaticMasteries");
            DropTable("dbo.Items");
            DropTable("dbo.Champions");
        }
    }
}
