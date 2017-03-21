using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoL.Models
{
    public class MatchData
    {
        [Key]
        public string ID { get; set; }
        public long matchId { get; set; }
        public string region { get; set; }
        public string platformId { get; set; }
        public string matchMode { get; set; }
        public string matchType { get; set; }
        public long matchCreation { get; set; }
        public int matchDuration { get; set; }
        public string queueType { get; set; }
        public int mapId { get; set; }
        public string season { get; set; }
        public string matchVersion { get; set; }
        public List<ParticipantList> participants { get; set; }
        public List<ParticipantId> participantIdentities { get; set; }
        public List<Team> teams { get; set; }
    }
}
