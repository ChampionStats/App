using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoL.Models
{
    public class ParticipantId
    {
        [Key]
        public int id { get; set; }
        public long matchid { get; set; }
        public int participantId { get; set; }
        public int playerid { get; set; }
    }
}