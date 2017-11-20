using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RosBets.Models
{
    public class User
    {
        
        // модель пользователя базы

        public int Id { get; set;}

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string MiddleName { get; set; }

        public string Mail { get; set; }

        public string Phone { get; set; }

        public string City { get; set; }

        public string Password { get; set; }

        List<Bet> Bets { get; set; }
    }
}