using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoL.Models
{
    public class ParticipantRunes
    {
        [Key]
        public int id { get; set; }
        public long matchid { get; set; }
        public int participantid { get; set; }

        public int runeId { get; set; }
        public int rank { get; set; }

    }
}