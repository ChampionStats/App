using LoL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace LoL.Controllers
{
    public class MasteryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Item
        public ActionResult AddMasteries()
        {
            int itemCount = 0;

            for (int z = 6100; z <= 6400; z++)
            {
                try
                {
                    var json = new WebClient().DownloadString("https://global.api.pvp.net/api/lol/static-data/NA/v1.2/mastery/" + z.ToString() + "?api_key=RGAPI-bdeef08a-76db-47d5-b0e0-33fd0d9f34ff");

                    StaticMastery data = JsonConvert.DeserializeObject<StaticMastery>(json);

                    db.Masteries.Add(data);
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


        // GET: Mastery
        public ActionResult Index()
        {
            return View();
        }
    }
}