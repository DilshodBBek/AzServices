using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Foydalanuvchi nomini kiriting")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Parol iritishni unutdingiz")]
        public string? Password { get; set; }
    }
}
