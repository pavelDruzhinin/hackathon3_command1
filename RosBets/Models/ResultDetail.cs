using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RosBets.Models
{
    public class ResultDetail
    {
        

        public int ResultId { get; set; }
        public Result Result { get; set; }
        [MaxLength(448)]
        public string Championat { get; set; }
        public string Event { get; set; }

        
        public bool? FirstWin { get; set; }

        public bool? SecondWin { get; set; }

        public bool? Draw { get; set; }
    }
}