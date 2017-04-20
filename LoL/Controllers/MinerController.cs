using LoL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace LoL.Controllers
{
    public class MinerController : Controller
    {
        // GET: Match
        public ActionResult Index()
        {
            return View();
        }

        public class Mastery
        {
            public int masteryId { get; set; }
            public int rank { get; set; }
        }

        public class Stats
        {
            public bool winner { get; set; }
            public int champLevel { get; set; }
            public int item0 { get; set; }
            public int item1 { get; set; }
            public int item2 { get; set; }
            public int item3 { get; set; }
            public int item4 { get; set; }
            public int item5 { get; set; }
            public int item6 { get; set; }
            public int kills { get; set; }
            public int doubleKills { get; set; }
            public int tripleKills { get; set; }
            public int quadraKills { get; set; }
            public int pentaKills { get; set; }
            public int unrealKills { get; set; }
            public int largestKillingSpree { get; set; }
            public int deaths { get; set; }
            public int assists { get; set; }
            public int totalDamageDealt { get; set; }
            public int totalDamageDealtToChampions { get; set; }
            public int totalDamageTaken { get; set; }
            public int largestCriticalStrike { get; set; }
            public int totalHeal { get; set; }
            public int minionsKilled { get; set; }
            public int neutralMinionsKilled { get; set; }
            public int neutralMinionsKilledTeamJungle { get; set; }
            public int neutralMinionsKilledEnemyJungle { get; set; }
            public int goldEarned { get; set; }
            public int goldSpent { get; set; }
            public int combatPlayerScore { get; set; }
            public int objectivePlayerScore { get; set; }
            public int totalPlayerScore { get; set; }
            public int totalScoreRank { get; set; }
            public int magicDamageDealtToChampions { get; set; }
            public int physicalDamageDealtToChampions { get; set; }
            public int trueDamageDealtToChampions { get; set; }
            public int visionWardsBoughtInGame { get; set; }
            public int sightWardsBoughtInGame { get; set; }
            public int magicDamageDealt { get; set; }
            public int physicalDamageDealt { get; set; }
            public int trueDamageDealt { get; set; }
            public int magicDamageTaken { get; set; }
            public int physicalDamageTaken { get; set; }
            public int trueDamageTaken { get; set; }
            public bool firstBloodKill { get; set; }
            public bool firstBloodAssist { get; set; }
            public bool firstTowerKill { get; set; }
            public bool firstTowerAssist { get; set; }
            public bool firstInhibitorKill { get; set; }
            public bool firstInhibitorAssist { get; set; }
            public int inhibitorKills { get; set; }
            public int towerKills { get; set; }
            public int wardsPlaced { get; set; }
            public int wardsKilled { get; set; }
            public int largestMultiKill { get; set; }
            public int killingSprees { get; set; }
            public int totalUnitsHealed { get; set; }
            public int totalTimeCrowdControlDealt { get; set; }
        }

        public class Rune
        {
            public int runeId { get; set; }
            public int rank { get; set; }
        }

        public class Participant
        {
            public int teamId { get; set; }
            public int spell1Id { get; set; }
            public int spell2Id { get; set; }
            public int championId { get; set; }
            public string highestAchievedSeasonTier { get; set; }
            public List<Mastery> masteries { get; set; }
            public Stats stats { get; set; }
            public int participantId { get; set; }
            public List<Rune> runes { get; set; }
        }

        public class RootObject
        {
            public long matchId { get; set; }
            public string region { get; set; }
            public string platformId { get; set; }
            public string matchMode { get; set; }
            public string matchType { get; set; }
            public long matchCreation { get; set; }
            public int matchDuration { get; set; }
            public string queueType { get; set; }
            public int mapId { get; set; }
            public string season { get; set; }
            public string matchVersion { get; set; }
            public List<Participant> participants { get; set; }
            public List<ParticipantIdentity> participantIdentities { get; set; }
            public List<Team> teams { get; set; }
        }


        public class Player
        {
            public int summonerId { get; set; }
            public string summonerName { get; set; }
            public string matchHistoryUri { get; set; }
            public int profileIcon { get; set; }
        }

        public class ParticipantIdentity
        {
            public int participantId { get; set; }
            public Player player { get; set; }
        }

        private class MatchlistQuery
        {
            public List<MatchInMatchlistQuery> matches { get; set; }
            public int startIndex { get; set; }
            public int endIndex { get; set; }
            public int totalGames { get; set; }
        }

        public class MatchInMatchlistQuery
        {
            public string region { get; set; }
            public string platformId { get; set; }
            public long matchId { get; set; }
            public int champion { get; set; }
            public string queue { get; set; }
            public string season { get; set; }
            public object timestamp { get; set; }
            public string lane { get; set; }
            public string role { get; set; }
        }



        // League Miner Crawler v 1.0
        public ActionResult Crawler()
        {
            // DB Context
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                try
                {
                    // Get player who hasn't been 'crawled'
                    LoLPlayer row = db.Players.Where(x => x.hasChecked == false).FirstOrDefault();

                    // Get matches played by that player in Ranked in patch 7.6
                    string jsonPlayerMatchlist = new WebClient().DownloadString("https://" + row.region + ".api.pvp.net/api/lol/" + row.region + "/v2.2/matchlist/by-summoner/" + row.playerOrTeamId + "?rankedQueues=TEAM_BUILDER_RANKED_SOLO&beginTime=1490324400&api_key=" + DataController.GameData.apiKey);

                    // Convert from JSON to object
                    MatchlistQuery playerMatchilist = JsonConvert.DeserializeObject<MatchlistQuery>(jsonPlayerMatchlist);
                    List<MatchInMatchlistQuery> matchesByPlayer = playerMatchilist.matches;

                    // Loop through each match by a single player
                    foreach (var match in matchesByPlayer.ToList())
                    {
                        // Add matchlanes if they don't exist for this match and player
                        if(!db.MatchLanes.Any(x=>x.matchId == match.matchId && x.playerId == row.playerOrTeamId))
                        {
                            db.MatchLanes.Add(new MatchLanes
                            {
                                matchId = match.matchId,
                                playerId = row.playerOrTeamId,
                                lane = match.lane,
                                role = match.role
                            });
                        }


                        // If match doesn't exist
                        if(!db.Matchlist.Any(x=>x.matchId == match.matchId))
                        {
                            // Add match data to db
                            db.Matchlist.Add(new Matchlist
                            {
                                matchId = match.matchId,
                                region = row.region,
                                platformId = match.platformId,
                                queue = match.queue,
                                season = match.season,
                                timestamp = match.timestamp
                            });
                            db.SaveChanges();

                            // Get match data
                            string json = new WebClient().DownloadString("https://" + row.region + ".api.pvp.net/api/lol/" + row.region + "/v2.2/match/" + match.matchId + "?api_key=" + DataController.GameData.apiKey);

                            // Convert from JSON to object
                            RootObject data = JsonConvert.DeserializeObject<RootObject>(json);

                            // Add match data to db
                            db.Match.Add(new MatchData
                            {
                                matchId = match.matchId,
                                region = data.region,
                                platformId = data.platformId,
                                matchMode = data.matchMode,
                                matchType = data.matchType,
                                matchCreation = data.matchCreation,
                                queueType = data.queueType,
                                mapId = data.mapId,
                                season = data.season,
                                matchVersion = data.matchVersion
                            });

                            // Get teams from query object
                            List<Team> teams = data.teams;

                            // Add teams to db
                            foreach (Team t in teams)
                            {
                                db.Team.Add(new Team
                                {
                                    matchid = match.matchId,
                                    teamId = t.teamId,
                                    winner = t.winner,
                                    firstBlood = t.firstBlood,
                                    firstTower = t.firstTower,
                                    firstInhibitor = t.firstInhibitor,
                                    firstBaron = t.firstBaron,
                                    firstDragon = t.firstDragon,
                                    firstRiftHerald = t.firstRiftHerald,
                                    towerKills = t.towerKills,
                                    inhibitorKills = t.inhibitorKills,
                                    baronKills = t.baronKills,
                                    dragonKills = t.dragonKills,
                                    riftHeraldKills = t.riftHeraldKills,
                                    vilemawKills = t.vilemawKills,
                                    dominionVictoryScore = t.dominionVictoryScore
                                });

                            }

                            List<ParticipantIdentity> participantIds = data.participantIdentities;
                            List<Participant> participants = data.participants;


                            // Add PI to db
                            foreach (ParticipantIdentity pi in participantIds)
                            {
                                // Check if player exists in database or not
                                if (!db.Players.Any(x => x.playerOrTeamId == pi.player.summonerId))
                                {
                                    db.Players.Add(new LoLPlayer
                                    {
                                        playerOrTeamId = pi.player.summonerId,
                                        rank = participants.Where(x => x.participantId == pi.participantId).Select(x => x.highestAchievedSeasonTier).SingleOrDefault(),
                                        region = row.region,
                                        hasChecked = false
                                    });
                                }

                                db.ParticipantIdentity.Add(new ParticipantId
                                {
                                    matchid = match.matchId,
                                    participantId = pi.participantId,
                                    playerid = pi.player.summonerId,
                                });

                            }

                            // Add Part to db
                            foreach (Participant p in participants)
                            {
                                db.Participant.Add(new ParticipantList
                                {
                                    MatchId = match.matchId,
                                    teamId = p.teamId,
                                    spell1Id = p.spell1Id,
                                    spell2Id = p.spell2Id,
                                    championId = p.championId,
                                    highestAchievedSeasonTier = p.highestAchievedSeasonTier,
                                    participantId = p.participantId

                                });


                                db.ParticipantStats.Add(new ParticipantStats
                                {
                                    participantid = p.participantId,
                                    matchid = match.matchId,
                                    winner = p.stats.winner,
                                    champLevel = p.stats.champLevel,
                                    item0 = p.stats.item0,
                                    item1 = p.stats.item1,
                                    item2 = p.stats.item2,
                                    item3 = p.stats.item3,
                                    item4 = p.stats.item4,
                                    item5 = p.stats.item5,
                                    item6 = p.stats.item6,
                                    kills = p.stats.kills,
                                    doubleKills = p.stats.doubleKills,
                                    tripleKills = p.stats.tripleKills,
                                    quadraKills = p.stats.quadraKills,
                                    pentaKills = p.stats.pentaKills,
                                    unrealKills = p.stats.unrealKills,
                                    largestKillingSpree = p.stats.largestKillingSpree,
                                    deaths = p.stats.deaths,
                                    assists = p.stats.assists,
                                    totalDamageDealt = p.stats.totalDamageDealt,
                                    totalDamageDealtToChampions = p.stats.totalDamageDealtToChampions,
                                    totalDamageTaken = p.stats.totalDamageTaken,
                                    largestCriticalStrike = p.stats.largestCriticalStrike,
                                    totalHeal = p.stats.totalHeal,
                                    minionsKilled = p.stats.minionsKilled,
                                    neutralMinionsKilled = p.stats.neutralMinionsKilled,
                                    neutralMinionsKilledTeamJungle = p.stats.neutralMinionsKilledTeamJungle,
                                    neutralMinionsKilledEnemyJungle = p.stats.neutralMinionsKilledEnemyJungle,
                                    goldEarned = p.stats.goldEarned,
                                    goldSpent = p.stats.goldSpent,
                                    combatPlayerScore = p.stats.combatPlayerScore,
                                    objectivePlayerScore = p.stats.objectivePlayerScore,
                                    totalPlayerScore = p.stats.totalPlayerScore,
                                    totalScoreRank = p.stats.totalScoreRank,
                                    magicDamageDealtToChampions = p.stats.magicDamageDealtToChampions,
                                    physicalDamageDealtToChampions = p.stats.physicalDamageDealtToChampions,
                                    trueDamageDealtToChampions = p.stats.trueDamageDealtToChampions,
                                    visionWardsBoughtInGame = p.stats.visionWardsBoughtInGame,
                                    sightWardsBoughtInGame = p.stats.sightWardsBoughtInGame,
                                    magicDamageDealt = p.stats.magicDamageDealt,
                                    physicalDamageDealt = p.stats.physicalDamageDealt,
                                    trueDamageDealt = p.stats.trueDamageDealt,
                                    magicDamageTaken = p.stats.magicDamageTaken,
                                    physicalDamageTaken = p.stats.physicalDamageTaken,
                                    trueDamageTaken = p.stats.trueDamageTaken,
                                    firstBloodKill = p.stats.firstBloodKill,
                                    firstBloodAssist = p.stats.firstBloodAssist,
                                    firstTowerKill = p.stats.firstTowerKill,
                                    firstTowerAssist = p.stats.firstTowerAssist,
                                    firstInhibitorKill = p.stats.firstInhibitorKill,
                                    firstInhibitorAssist = p.stats.firstInhibitorAssist,
                                    inhibitorKills = p.stats.inhibitorKills,
                                    towerKills = p.stats.towerKills,
                                    wardsPlaced = p.stats.wardsPlaced,
                                    wardsKilled = p.stats.wardsKilled,
                                    largestMultiKill = p.stats.largestMultiKill,
                                    killingSprees = p.stats.killingSprees,
                                    totalUnitsHealed = p.stats.totalUnitsHealed,
                                    totalTimeCrowdControlDealt = p.stats.totalTimeCrowdControlDealt
                                });


                                foreach (Rune runeData in p.runes)
                                {
                                    db.ParticipantRunes.Add(new ParticipantRunes
                                    {
                                        participantid = p.participantId,
                                        matchid = match.matchId,
                                        runeId = runeData.runeId,
                                        rank = runeData.rank
                                    });
                                }

                                foreach (Mastery masteryData in p.masteries)
                                {
                                    db.ParticipantMasteries.Add(new ParticipantMasteries
                                    {
                                        participantid = p.participantId,
                                        matchid = match.matchId,
                                        masteryId = masteryData.masteryId,
                                        rank = masteryData.rank
                                    });

                                }
                            }

                            db.SaveChanges();

                        }
                    }



                }
                catch
                {
                    // Couldn't get matchlist
                }



            }




            return View();
        }

        public ActionResult LeagueMinerCrawlerEX()
        {
            int endId = 112034;
            int startId = 38133;

            for (int i = startId; i <= endId; i++)
            {
                ApplicationDbContext db = new ApplicationDbContext();

                Matchlist row = (from o in db.Matchlist
                                 where o.Id == i
                                 select o).SingleOrDefault();

                string region = row.region;
                long matid = row.matchId;
                int id = row.Id;

                try
                {
                    Thread.Sleep(650);
                    // Get all matches played by a player in patch 7.5 in RANKED SOLO when Taric is played
                    string json = new WebClient().DownloadString("https://" + region + ".api.pvp.net/api/lol/" + region + "/v2.2/match/" + matid + "?api_key=RGAPI-bdeef08a-76db-47d5-b0e0-33fd0d9f34ff");

                    // Convert from JSON to object
                    RootObject data = JsonConvert.DeserializeObject<RootObject>(json);

                    List<Team> teams = data.teams;

                    List<ParticipantIdentity> participantIds = data.participantIdentities;

                    List<Participant> participants = data.participants;


                    // Add Match to db
                    /*MatchData m = new MatchData
                    {
                        matchId = id,
                        region = data.region,
                        platformId = data.platformId,
                        matchMode = data.matchMode,
                        matchType = data.matchType,
                        matchCreation = data.matchCreation,
                        queueType = data.queueType,
                        mapId = data.mapId,
                        season = data.season,
                        matchVersion = data.matchVersion
                    };

                    db.Match.Add(m);*/

                    db.Match.Add(new MatchData
                    {
                        matchId = id,
                        region = data.region,
                        platformId = data.platformId,
                        matchMode = data.matchMode,
                        matchType = data.matchType,
                        matchCreation = data.matchCreation,
                        queueType = data.queueType,
                        mapId = data.mapId,
                        season = data.season,
                        matchVersion = data.matchVersion
                    });



                    // Add teams to db
                    foreach (Team t in teams)
                    {
                        db.Team.Add(new Team
                        {
                            matchid = id,
                            teamId = t.teamId,
                            winner = t.winner,
                            firstBlood = t.firstBlood,
                            firstTower = t.firstTower,
                            firstInhibitor = t.firstInhibitor,
                            firstBaron = t.firstBaron,
                            firstDragon = t.firstDragon,
                            firstRiftHerald = t.firstRiftHerald,
                            towerKills = t.towerKills,
                            inhibitorKills = t.inhibitorKills,
                            baronKills = t.baronKills,
                            dragonKills = t.dragonKills,
                            riftHeraldKills = t.riftHeraldKills,
                            vilemawKills = t.vilemawKills,
                            dominionVictoryScore = t.dominionVictoryScore
                        });

                    }

                    // Add PI to db
                    foreach (ParticipantIdentity pi in participantIds)
                    {

                        db.ParticipantIdentity.Add(new ParticipantId
                        {
                            matchid = id,
                            participantId = pi.participantId,
                            playerid = pi.player.summonerId,
                        });
                    }

                    // Add Part to db
                    foreach (Participant p in participants)
                    {
                        db.Participant.Add(new ParticipantList
                        {
                            MatchId = id,
                            teamId = p.teamId,
                            spell1Id = p.spell1Id,
                            spell2Id = p.spell2Id,
                            championId = p.championId,
                            highestAchievedSeasonTier = p.highestAchievedSeasonTier,
                            participantId = p.participantId

                        });


                        db.ParticipantStats.Add(new ParticipantStats
                        {
                            participantid = p.participantId,
                            matchid = id,
                            winner = p.stats.winner,
                            champLevel = p.stats.champLevel,
                            item0 = p.stats.item0,
                            item1 = p.stats.item1,
                            item2 = p.stats.item2,
                            item3 = p.stats.item3,
                            item4 = p.stats.item4,
                            item5 = p.stats.item5,
                            item6 = p.stats.item6,
                            kills = p.stats.kills,
                            doubleKills = p.stats.doubleKills,
                            tripleKills = p.stats.tripleKills,
                            quadraKills = p.stats.quadraKills,
                            pentaKills = p.stats.pentaKills,
                            unrealKills = p.stats.unrealKills,
                            largestKillingSpree = p.stats.largestKillingSpree,
                            deaths = p.stats.deaths,
                            assists = p.stats.assists,
                            totalDamageDealt = p.stats.totalDamageDealt,
                            totalDamageDealtToChampions = p.stats.totalDamageDealtToChampions,
                            totalDamageTaken = p.stats.totalDamageTaken,
                            largestCriticalStrike = p.stats.largestCriticalStrike,
                            totalHeal = p.stats.totalHeal,
                            minionsKilled = p.stats.minionsKilled,
                            neutralMinionsKilled = p.stats.neutralMinionsKilled,
                            neutralMinionsKilledTeamJungle = p.stats.neutralMinionsKilledTeamJungle,
                            neutralMinionsKilledEnemyJungle = p.stats.neutralMinionsKilledEnemyJungle,
                            goldEarned = p.stats.goldEarned,
                            goldSpent = p.stats.goldSpent,
                            combatPlayerScore = p.stats.combatPlayerScore,
                            objectivePlayerScore = p.stats.objectivePlayerScore,
                            totalPlayerScore = p.stats.totalPlayerScore,
                            totalScoreRank = p.stats.totalScoreRank,
                            magicDamageDealtToChampions = p.stats.magicDamageDealtToChampions,
                            physicalDamageDealtToChampions = p.stats.physicalDamageDealtToChampions,
                            trueDamageDealtToChampions = p.stats.trueDamageDealtToChampions,
                            visionWardsBoughtInGame = p.stats.visionWardsBoughtInGame,
                            sightWardsBoughtInGame = p.stats.sightWardsBoughtInGame,
                            magicDamageDealt = p.stats.magicDamageDealt,
                            physicalDamageDealt = p.stats.physicalDamageDealt,
                            trueDamageDealt = p.stats.trueDamageDealt,
                            magicDamageTaken = p.stats.magicDamageTaken,
                            physicalDamageTaken = p.stats.physicalDamageTaken,
                            trueDamageTaken = p.stats.trueDamageTaken,
                            firstBloodKill = p.stats.firstBloodKill,
                            firstBloodAssist = p.stats.firstBloodAssist,
                            firstTowerKill = p.stats.firstTowerKill,
                            firstTowerAssist = p.stats.firstTowerAssist,
                            firstInhibitorKill = p.stats.firstInhibitorKill,
                            firstInhibitorAssist = p.stats.firstInhibitorAssist,
                            inhibitorKills = p.stats.inhibitorKills,
                            towerKills = p.stats.towerKills,
                            wardsPlaced = p.stats.wardsPlaced,
                            wardsKilled = p.stats.wardsKilled,
                            largestMultiKill = p.stats.largestMultiKill,
                            killingSprees = p.stats.killingSprees,
                            totalUnitsHealed = p.stats.totalUnitsHealed,
                            totalTimeCrowdControlDealt = p.stats.totalTimeCrowdControlDealt
                        });


                        foreach (Rune runeData in p.runes)
                        {
                            db.ParticipantRunes.Add(new ParticipantRunes
                            {
                                participantid = p.participantId,
                                matchid = id,
                                runeId = runeData.runeId,
                                rank = runeData.rank
                            });
                        }

                        foreach (Mastery masteryData in p.masteries)
                        {
                            db.ParticipantMasteries.Add(new ParticipantMasteries
                            {
                                participantid = p.participantId,
                                matchid = id,
                                masteryId = masteryData.masteryId,
                                rank = masteryData.rank
                            });

                        }
                    }
                    db.SaveChanges();
                }
                catch
                {

                }



            }
            return View();
        }

        /*
        public void AddMatchData(long matid, string region, int id)
        {
            
            https://na.api.pvp.net/api/lol/NA/v2.2/matchlist/by-summoner/38419742?rankedQueues=TEAM_BUILDER_RANKED_SOLO&beginTime=1489099788969&championIds=44&api_key=RGAPI-bdeef08a-76db-47d5-b0e0-33fd0d9f34ff
            

            // Get all current players (Mast and Chall)
           

            // Loop through each player in database
           
                // Try to add played matches to matchlist
              try
              {
                    // Get all matches played by a player in patch 7.5 in RANKED SOLO when Taric is played
                    string json = new WebClient().DownloadString("https://"+region+".api.pvp.net/api/lol/"+region+"/v2.2/match/" + matid + "?api_key=RGAPI-bdeef08a-76db-47d5-b0e0-33fd0d9f34ff");

                    // Convert from JSON to object
                    RootObject data = JsonConvert.DeserializeObject<RootObject>(json);               

                    List<Team> teams = data.teams;

                    List<ParticipantIdentity> participantIds = data.participantIdentities;

                    List<Participant> participants = data.participants;


                // Add Match to db
                /*MatchData m = new MatchData
                {
                    matchId = id,
                    region = data.region,
                    platformId = data.platformId,
                    matchMode = data.matchMode,
                    matchType = data.matchType,
                    matchCreation = data.matchCreation,
                    queueType = data.queueType,
                    mapId = data.mapId,
                    season = data.season,
                    matchVersion = data.matchVersion
                };

                db.Match.Add(m);

                db.Match.Add(new MatchData
                {
                    matchId = id,
                    region = data.region,
                    platformId = data.platformId,
                    matchMode = data.matchMode,
                    matchType = data.matchType,
                    matchCreation = data.matchCreation,
                    queueType = data.queueType,
                    mapId = data.mapId,
                    season = data.season,
                    matchVersion = data.matchVersion
                });
                    

                    // Add teams to db
                    foreach (Team t in teams)
                    {
                        db.Team.Add(new Team
                        {
                            matchid = id,
                            teamId = t.teamId,
                            winner = t.winner,
                            firstBlood = t.firstBlood,
                            firstTower = t.firstTower,
                            firstInhibitor = t.firstInhibitor,
                            firstBaron = t.firstBaron,
                            firstDragon = t.firstDragon,
                            firstRiftHerald = t.firstRiftHerald,
                            towerKills = t.towerKills,
                            inhibitorKills = t.inhibitorKills,
                            baronKills = t.baronKills,
                            dragonKills = t.dragonKills,
                            riftHeraldKills = t.riftHeraldKills,
                            vilemawKills = t.vilemawKills,
                            dominionVictoryScore = t.dominionVictoryScore
                        });     
                     }

                    // Add PI to db
                    foreach (ParticipantIdentity pi in participantIds)
                    { 

                        db.ParticipantIdentity.Add(new ParticipantId
                        {
                            matchid = id,
                            participantId = pi.participantId,
                            playerid = pi.player.summonerId,
                        });
                    }

                    // Add Part to db
                    foreach (Participant p in participants)
                    {
                        db.Participant.Add(new ParticipantList
                        {
                            MatchId = id,
                            teamId = p.teamId,
                            spell1Id = p.spell1Id,
                            spell2Id = p.spell2Id,
                            championId = p.championId,
                            highestAchievedSeasonTier = p.highestAchievedSeasonTier,
                            participantId = p.participantId

                        });

                        db.ParticipantStats.Add(new ParticipantStats
                        {
                            participantid = p.participantId,
                            matchid = id,
                            winner = p.stats.winner,
                            champLevel = p.stats.champLevel,
                            item0 = p.stats.item0,
                            item1 = p.stats.item1,
                            item2 = p.stats.item2,
                            item3 = p.stats.item3,
                            item4 = p.stats.item4,
                            item5 = p.stats.item5,
                            item6 = p.stats.item6,
                            kills = p.stats.kills,
                            doubleKills = p.stats.doubleKills,
                            tripleKills = p.stats.tripleKills,
                            quadraKills = p.stats.quadraKills,
                            pentaKills = p.stats.pentaKills,
                            unrealKills = p.stats.unrealKills,
                            largestKillingSpree = p.stats.largestKillingSpree,
                            deaths = p.stats.deaths,
                            assists = p.stats.assists,
                            totalDamageDealt = p.stats.totalDamageDealt,
                            totalDamageDealtToChampions = p.stats.totalDamageDealtToChampions,
                            totalDamageTaken = p.stats.totalDamageTaken,
                            largestCriticalStrike = p.stats.largestCriticalStrike,
                            totalHeal = p.stats.totalHeal,
                            minionsKilled = p.stats.minionsKilled,
                            neutralMinionsKilled = p.stats.neutralMinionsKilled,
                            neutralMinionsKilledTeamJungle = p.stats.neutralMinionsKilledTeamJungle,
                            neutralMinionsKilledEnemyJungle = p.stats.neutralMinionsKilledEnemyJungle,
                            goldEarned = p.stats.goldEarned,
                            goldSpent = p.stats.goldSpent,
                            combatPlayerScore = p.stats.combatPlayerScore,
                            objectivePlayerScore = p.stats.objectivePlayerScore,
                            totalPlayerScore = p.stats.totalPlayerScore,
                            totalScoreRank = p.stats.totalScoreRank,
                            magicDamageDealtToChampions = p.stats.magicDamageDealtToChampions,
                            physicalDamageDealtToChampions = p.stats.physicalDamageDealtToChampions,
                            trueDamageDealtToChampions = p.stats.trueDamageDealtToChampions,
                            visionWardsBoughtInGame = p.stats.visionWardsBoughtInGame,
                            sightWardsBoughtInGame = p.stats.sightWardsBoughtInGame,
                            magicDamageDealt = p.stats.magicDamageDealt,
                            physicalDamageDealt = p.stats.physicalDamageDealt,
                            trueDamageDealt = p.stats.trueDamageDealt,
                            magicDamageTaken = p.stats.magicDamageTaken,
                            physicalDamageTaken = p.stats.physicalDamageTaken,
                            trueDamageTaken = p.stats.trueDamageTaken,
                            firstBloodKill = p.stats.firstBloodKill,
                            firstBloodAssist = p.stats.firstBloodAssist,
                            firstTowerKill = p.stats.firstTowerKill,
                            firstTowerAssist = p.stats.firstTowerAssist,
                            firstInhibitorKill = p.stats.firstInhibitorKill,
                            firstInhibitorAssist = p.stats.firstInhibitorAssist,
                            inhibitorKills = p.stats.inhibitorKills,
                            towerKills = p.stats.towerKills,
                            wardsPlaced = p.stats.wardsPlaced,
                            wardsKilled = p.stats.wardsKilled,
                            largestMultiKill = p.stats.largestMultiKill,
                            killingSprees = p.stats.killingSprees,
                            totalUnitsHealed = p.stats.totalUnitsHealed,
                            totalTimeCrowdControlDealt = p.stats.totalTimeCrowdControlDealt
                        });

                        foreach (Rune runeData in p.runes)
                        {
                            db.ParticipantRunes.Add(new ParticipantRunes
                            {
                                participantid = p.participantId,
                                matchid = id,
                                runeId = runeData.runeId,
                                rank = runeData.rank
                            });
                        }

                        foreach (Mastery masteryData in p.masteries)
                        {
                            db.ParticipantMasteries.Add(new ParticipantMasteries
                            {
                                participantid = p.participantId,
                                matchid = id,
                                masteryId = masteryData.masteryId,
                                rank = masteryData.rank
                            });
                        }
                    }
           }
           catch
            {

            }
            db.SaveChanges();
        }*/
    }

}