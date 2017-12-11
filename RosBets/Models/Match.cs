using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.AccessControl;
using System.Web;

namespace RosBets.Models
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class Match:EntityBase
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string MatchNumber { get; set; }
        [DataMember]
        public string MatchName { get; set; }
        [DataMember]
        public string Team1Name { get; set; }
        [DataMember]
        public string Team2Name { get; set; }
        [DataMember]
        public DateTime? Date { get; set; }

        [DataMember]
        public bool Finished { get; set; }
        [DataMember]
        public int? Team1Score { get; set; }
        [DataMember]
        public int? Team2Score { get; set; }

        public List<BetEvent> BetEvents { get; set; }
        public List<MatchEvent> MatchEvents { get; set; }
        [DataMember]
        public int ChampionshipId { get; set; }
        public Championship Championship { get; set; }

    }
}