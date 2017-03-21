using LoL.Models;
using Newtonsoft.Json;
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

    public class RuneController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private class Rune
        {
            public string tier { get; set; }
            public string type { get; set; }
            public bool isRune { get; set; }
        }

        private class RootObject
        {
            public string description { get; set; }
            public Rune rune { get; set; }
            public int id { get; set; }
            public string name { get; set; }
        }


        // GET: Item
        public ActionResult AddRunes()
        {
            int itemCount = 0;

            for (int z = 5000; z <= 10005; z++)
            {
                try
                {
                    var json = new WebClient().DownloadString("https://global.api.pvp.net/api/lol/static-data/NA/v1.2/rune/" + z.ToString() + "?api_key=RGAPI-bdeef08a-76db-47d5-b0e0-33fd0d9f34ff");

                    RootObject data = JsonConvert.DeserializeObject<RootObject>(json);

                    StaticRunes r = new StaticRunes
                    {
                        description = data.description,
                        id = data.id,
                        name = data.name,
                        tier = data.rune.tier,
                        type = data.rune.type,
                        isRune = data.rune.isRune
                    };

                    db.Runes.Add(r);
                    db.SaveChanges();


                    itemCount++;
                }
                catch
                {

                }
                Thread.Sleep(1200);
            }

            ViewBag.AddCount = itemCount;

            return View();
        }
    }
}