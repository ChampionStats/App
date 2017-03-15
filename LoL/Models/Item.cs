using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoL.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public string plaintext { get; set; }
        public string description { get; set; }
        public int id { get; set; }
        public string name { get; set; }
    }
}