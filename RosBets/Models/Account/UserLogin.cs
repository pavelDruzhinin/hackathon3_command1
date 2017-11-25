using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RosBets.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Введите Почту")]
        [EmailAddress]
        public string Login { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }
    }
}