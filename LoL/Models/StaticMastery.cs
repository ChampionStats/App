using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoL.Models
{
    public class StaticMastery
    {
        [Key]
        public int MasteryId { get; set; }

        public List<string> description { get; set; }
        public int id { get; set; }
        public string name { get; set; }

    }
}