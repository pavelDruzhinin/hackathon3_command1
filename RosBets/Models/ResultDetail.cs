using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RosBets.Models
{
    public class ResultDetail
    {
        public ResultDetail()
        {
            Results = new List<Result>();
        }

        public int ResultId { get; set; }

        public string Event { get; set; }

        public ICollection<Result> Results { get; set; }

        public bool? FirstWin { get; set; }

        public bool? SecondWin { get; set; }

        public bool? Draw { get; set; }
    }
}