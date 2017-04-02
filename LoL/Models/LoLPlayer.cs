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

        public int playerOrTeamId { get; set; }

        public string rank { get; set; }

        public string region { get; set; }

        public bool hasChecked { get; set; }
    }
}