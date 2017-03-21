using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoL.Models
{
    public class Team
    {
        [Key]
        public int ID { get; set; }
        public long matchid { get; set; }
        public int teamId { get; set; }
        public bool winner { get; set; }
        public bool firstBlood { get; set; }
        public bool firstTower { get; set; }
        public bool firstInhibitor { get; set; }
        public bool firstBaron { get; set; }
        public bool firstDragon { get; set; }
        public bool firstRiftHerald { get; set; }
        public int towerKills { get; set; }
        public int inhibitorKills { get; set; }
        public int baronKills { get; set; }
        public int dragonKills { get; set; }
        public int riftHeraldKills { get; set; }
        public int vilemawKills { get; set; }
        public int dominionVictoryScore { get; set; }
    }
}