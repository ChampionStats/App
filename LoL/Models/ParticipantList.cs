using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoL.Models
{
    public class ParticipantList
    {
        [Key]
        public int partId { get; set; }
        public long MatchId { get; set; }
        public int teamId { get; set; }
        public int spell1Id { get; set; }
        public int spell2Id { get; set; }
        public int championId { get; set; }
        public string highestAchievedSeasonTier { get; set; }
        public int participantId { get; set; }

    }
}