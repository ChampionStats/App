using LoL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using LoL.Controllers;

namespace LoL.Controllers
{
    public class PlayerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            
            return View();
        }



        // GET: Players
        public ActionResult GetMasterPlayers()
        {
            long playerCount = 0;
            string apiKey = DataController.GameData.apiKey;

            foreach (string region in DataController.GameData.gameRegions)
            {
                string json = new WebClient().DownloadString("https://" + region + ".api.pvp.net/api/lol/" + region + "/v2.5/league/master?type=RANKED_SOLO_5x5&api_key=" + apiKey);
                string JsonString = json.ToString();
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                RootObject c = serializer.Deserialize<RootObject>(JsonString);

                foreach (Entry e in c.entries)
                {
                    LoLPlayer p = new LoLPlayer
                    {
                        //playerOrTeamId = e.playerOrTeamId,
                        //playerOrTeamName = e.playerOrTeamName,
                        rank = "Master",
                        region = region
                    };

                    db.Players.Add(p);
                    db.SaveChanges();
                    playerCount++;
                }
            }

            ViewBag.Count = playerCount;

            return View();
        }

        // GET: Players
        public ActionResult GetChallengerPlayers()
        {

            long playerCount = 0;
            string apiKey = DataController.GameData.apiKey;

            foreach (string region in DataController.GameData.gameRegions)
            {
                string json = new WebClient().DownloadString("https://" + region + ".api.pvp.net/api/lol/" + region + "/v2.5/league/challenger?type=RANKED_SOLO_5x5&api_key=" + apiKey);
                string JsonString = json.ToString();
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                RootObject c = serializer.Deserialize<RootObject>(JsonString);

                foreach (Entry e in c.entries)
                {
                    LoLPlayer p = new LoLPlayer
                    {
                        //playerOrTeamId = e.playerOrTeamId,
                        //playerOrTeamName = e.playerOrTeamName,
                        rank = "Challenger",
                        region = region
                    };

                    db.Players.Add(p);
                    db.SaveChanges();
                    playerCount++;
                }
            }

            ViewBag.Count = playerCount;

            return View();
        }



        public ActionResult ClearChallengerPlayers()
        {
            var rows = from o in db.Players
                       where o.rank == "Challenger"
                       select o;

            foreach (var row in rows)
            {
                db.Players.Remove(row);
            }
            db.SaveChanges();

            return View();
        }




        private class Entry
        {
            public string playerOrTeamId { get; set; }
            public string playerOrTeamName { get; set; }
            public string division { get; set; }
            public int leaguePoints { get; set; }
            public int wins { get; set; }
            public int losses { get; set; }
            public bool isHotStreak { get; set; }
            public bool isVeteran { get; set; }
            public bool isFreshBlood { get; set; }
            public bool isInactive { get; set; }
        }

        private class RootObject
        {
            public string name { get; set; }
            public string tier { get; set; }
            public string queue { get; set; }
            public List<Entry> entries { get; set; }
        }

    }
}