using LoL.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace LoL.Controllers
{
    public class MatchlistController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        private class RootObject
        {
            public List<Matchlist> matches { get; set; }
            public int startIndex { get; set; }
            public int endIndex { get; set; }
            public int totalGames { get; set; }
        }



        // GET: Matchlist
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetMatches()
        {
            /*
            https://na.api.pvp.net/api/lol/NA/v2.2/matchlist/by-summoner/38419742?rankedQueues=TEAM_BUILDER_RANKED_SOLO&beginTime=1489099788969&championIds=44&api_key=RGAPI-bdeef08a-76db-47d5-b0e0-33fd0d9f34ff
            */

            // Get all current players (Mast and Chall)
            var rows = (from o in db.Players
                       select o);

            // Loop through each player in database
            foreach (var row in rows.ToList())
            {
                // Try to add played matches to matchlist

            try { 

                    Thread.Sleep(2000);
                    // Get all matches played by a player in patch 7.5+ in RANKED SOLO
                    string json = new WebClient().DownloadString("https://" + row.region + ".api.pvp.net/api/lol/" + row.region + "/v2.2/matchlist/by-summoner/" + row.playerOrTeamId + "?rankedQueues=TEAM_BUILDER_RANKED_SOLO&beginTime=1489099788969&api_key=" + DataController.GameData.apiKey);

                    // Convert from JSON to object
                    RootObject data = JsonConvert.DeserializeObject<RootObject>(json);

                    List<Matchlist> r = data.matches;

                    // Check if player has any matches
                    if (r != null)
                    {

                        // Loop through each match by a single player
                        foreach (var match in r.ToList())
                        {
                            // Get list of current matches in the matchlist
                            var currentMatches = from o in db.Matchlist
                                                 select o;

                            // Set variable back to false before looping through next current match
                            bool matchExists = false;

                            // Loop through each match currently in matchlist
                            foreach (var m in currentMatches.ToList())
                            {
                                // Check if current match of player equals a match from matchlist
                                if (match.matchId == m.matchId)
                                {
                                    matchExists = true;
                                }

                            }

                            // Check if match played by player does not exist
                            if (matchExists == false)
                            {
                                db.Matchlist.Add(match);
                                db.SaveChanges();

                            }
                        }

                    }

                 }

                catch
                {

                }



            }

            db.SaveChanges();

            return View();
        }

        public ActionResult RemoveDuplicate()
        {
            // Get all current players (Mast and Chall)
            var rows = (from o in db.Matchlist
                        select o);

            // Iterate through all matches in matchlist
            foreach (Matchlist currentMatch in rows)
            {

                // Compare one match to all other matches
                foreach (Matchlist matchToCompare in rows)
                {
                    // Check is current matchid appears anywhere else
                    if (currentMatch.matchId == matchToCompare.matchId)
                    {
                        // Test if the match record is the same
                        if (currentMatch.Id != matchToCompare.Id)
                        {
                            db.Matchlist.Remove(matchToCompare);
                        }
                    }         
                }
            }

            


            return View();
        }

    }
}
