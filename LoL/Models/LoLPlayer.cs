using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoL.Models
{
    public class LoLPlayer
    {
        [Key]
        public int PlayerId { get; set; }

        public string playerOrTeamId { get; set; }

        public string playerOrTeamName { get; set; }

        public string rank { get; set; }
    }
}