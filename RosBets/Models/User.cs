using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace RosBets.Models
{
    public class User
    {
        
        // модель пользователя базы

        public int Id { get; set;}


        [Required(ErrorMessage = "Введите имя")]
        [Display(Name = "Имя")]
        //[]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Фамилию")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Введите отчество")]
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Введите Email")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Введите телефон")]
        [Display(Name = "Телефон")]
        [Phone]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Введите город")]
        [Display(Name = "Город")]
        public string City { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Введите пароль снова")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [Display(Name = "Повторите пароль")]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        public decimal Money { get; set; }

        List<Bet> Bets { get; set; }
    }
}