﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoL.Models
{
    public class Matchlist
    {
        [Key]
        public int Id { get; set; }
        public string region { get; set; }
        public string platformId { get; set; }
        public int matchId { get; set; }
        public int champion { get; set; }
        public string queue { get; set; }
        public string season { get; set; }
        public object timestamp { get; set; }
        public string lane { get; set; }
        public string role { get; set; }
    }
}