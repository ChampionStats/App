using LoL.Models;
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
    public class ChampionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Champion
        public ActionResult AddChampions()
        {
            int champCount = 0;

            for (int z = 1; z <= 300; z++)
            {
                try
                {
                    var json = new WebClient().DownloadString("https://global.api.pvp.net/api/lol/static-data/NA/v1.2/champion/" + champCount + "?api_key=RGAPI-bdeef08a-76db-47d5-b0e0-33fd0d9f34ff");
                    string JsonString = json.ToString();

                    JavaScriptSerializer serializer = new JavaScriptSerializer();

                    Champion c = serializer.Deserialize<Champion>(JsonString);

                    db.Champions.Add(c);
                    db.SaveChanges();

                }
                catch
                {

                }
                champCount++;

                Thread.Sleep(1200);
            }

            ViewBag.AddCount = champCount;

            return View();
        }

        public ActionResult ClearChampions()
        {
            var rows = from o in db.Champions
                       select o;

            foreach (var row in rows)
            {
                db.Champions.Remove(row);
            }
            db.SaveChanges();

            return View();
        }
    }
}