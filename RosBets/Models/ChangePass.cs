using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RosBets.Models
{
    public class ChangePass
    {
        public int Id { get; set; }

        public string Mail { get; set; }

        [Required(ErrorMessage = "Введите старый пароль")]
        [Display(Name = "Старый Пароль")]
        [NotMapped]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [Display(Name = "Новый Пароль")]
        [NotMapped]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Введите пароль снова")]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают")]
        [Display(Name = "Повторите новый пароль")]
        [NotMapped]
        public string ConfirmNewPassword { get; set; }
    }
}