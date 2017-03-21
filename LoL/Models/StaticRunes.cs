using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoL.Models
{
    public class StaticRunes
    {
        [Key]
        public int RunesId { get; set; }
        public string description { get; set; }
        public int id { get; set; }
        public string name { get; set; }

        public string tier { get; set; }
        public string type { get; set; }
        public bool isRune { get; set; }
    }
}