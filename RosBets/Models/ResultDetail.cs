using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RosBets.Models
{
    public class ResultDetail
    {
        public int Id { get; set; } // добавил первичный ключ / primary key 

        public int ResultId { get; set; } // это внешний ключ/foreign key
        public Result Result { get; set; }
        [MaxLength(448)]
        public string Event { get; set; }

        
        public bool? FirstWin { get; set; }

        public bool? SecondWin { get; set; }

        public bool? Draw { get; set; }
    }
}