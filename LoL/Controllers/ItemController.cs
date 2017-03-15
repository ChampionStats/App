using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using LoL.Models;

namespace LoL.Controllers
{


    public class ItemController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Item
        public ActionResult Index()
        {
            for (int z = 1001; z <= 1005; z++)
            {
                try
                {
                    var json = new WebClient().DownloadString("https://global.api.pvp.net/api/lol/static-data/NA/v1.2/item/" + z.ToString() + "?api_key=RGAPI-bdeef08a-76db-47d5-b0e0-33fd0d9f34ff");
                    string JsonString = json.ToString();

                    JavaScriptSerializer serializer = new JavaScriptSerializer();

                    Item t = serializer.Deserialize<Item>(JsonString);

                    db.Items.Add(t);
                    db.SaveChanges();

                    Thread.Sleep(1000);
                }
                catch
                {

                }     
            }

            return View();
        }
    }
}