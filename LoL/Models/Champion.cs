using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoL.Models
{
    public class Champion
    {   
        [Key]
        public int ChampionId { get; set; }

        public int id { get; set; }

        public string title { get; set; }

        public string key { get; set; }

        public string name { get; set; }
    }
}