﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace RosBets.Models
{
    public class Match
    {
        public int Id { get; set; }

        public string MatchNumber { get; set; }
        public string MatchName { get; set; }

        public string Team1Name { get; set; }

        public string Team2Name { get; set; }

        public DateTime? Date { get; set; }
        

        public bool Finished { get; set; }

        public int? Team1Score { get; set; }

        public int? Team2Score { get; set; }

        public List<BetEvent> BetEvents { get; set; }
        public List<MatchEvent> MatchEvents { get; set; }
        public int ChampionshipId { get; set; }
        public Championship Championship { get; set; }

    }
}