using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoL.Models
{
    public class MatchLanes
    {
        [Key]
        public int MatchLanesID { get; set; }

        public long matchId { get; set; }
        public int playerId { get; set; }
        public string lane { get; set; }
        public string role { get; set; }

    }
}