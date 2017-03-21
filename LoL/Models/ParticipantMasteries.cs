using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoL.Models
{
    public class ParticipantMasteries
    {
        [Key]
        public int id { get; set; }
        public int participantid { get; set; }

        public int masteryId { get; set; }
        public int rank { get; set; }


    }
}