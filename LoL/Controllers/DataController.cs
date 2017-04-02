using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoL.Controllers
{
    public class DataController : Controller
    {
        public class GameData
        {
            public static string[] gameRegions = new string[]
            {
                        "RU",
                        "LAN",
                        "EUNE",
                        "OCE",
                        "TR",
                        "JP",
                        "KR",
                        "BR",
                        "NA",
                        "EUW",
                        "LAS"
            };

            public static string apiKey = "RGAPI-bdeef08a-76db-47d5-b0e0-33fd0d9f34ff";
        }


        // GET: Data
        public ActionResult Index()
        {
            return View();
        }
    }
}