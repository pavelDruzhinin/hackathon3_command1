using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RosBets.Models
{
    public class Pay
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; } 
        public decimal Sum { get; set; } 
        public string Sender { get; set; } //Кошелёк отправителя
        public string Operation_Id { get; set; } // id операции в ЯД
        public decimal? Amount { get; set; } // сумма, которую заплатали с учетом комиссии
        public decimal? WithdrawAmount { get; set; } // сумма, которую заплатали без учета комиссии
        public int? UserId { get; set; }
        public User User { get; set; }

    }
}