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

            public static string apiKey = "RGAPI-62f8af2b-ced7-449e-99a2-e653783e50d5";
        }


        // GET: Data
        public ActionResult Index()
        {
            return View();
        }
    }
}