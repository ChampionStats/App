using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoL.Models;
using System.Net;


using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;

namespace LoL.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin

        // Remove key from production
        public ActionResult ChampionsMastersInit()
        {
            /*
            var json = new WebClient().DownloadString("https://na.api.pvp.net/api/lol/na/v2.5/league/master?type=RANKED_SOLO_5x5&api_key=RGAPI-bdeef08a-76db-47d5-b0e0-33fd0d9f34ff");

            JavaScriptSerializer js = new JavaScriptSerializer();

            PlayerMasterLeague pl = js.Deserialize<PlayerMasterLeague>(json); 
            
            foreach (entries e in pl.entries)
            {
                db.Players.Add(e);
            }

            db.SaveChanges();
            */

            return View();
        }

        public ActionResult ItemsInit()
        {

            var json = new WebClient().DownloadString("https://global.api.pvp.net/api/lol/static-data/NA/v1.2/item?api_key=RGAPI-bdeef08a-76db-47d5-b0e0-33fd0d9f34ff");

            

            string JsonString = json.ToString();


            JavaScriptSerializer serializer = new JavaScriptSerializer();

            Item t = serializer.Deserialize<Item>(JsonString);

            dynamic data = JObject.Parse(json);

            dynamic data2 = JsonConvert.DeserializeObject(json);

            return View();
        }
    }
}