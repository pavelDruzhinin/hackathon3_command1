using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RosBets.Models
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class Championship : EntityBase
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int SportId { get; set; }
        public Sport Sport { get; set; }

        public List<Match>  Matches { get; set; }
       

    }
}