using System.ComponentModel.DataAnnotations;

namespace Identity.Domain.Models;

public class LoginModel
{
    [Required(ErrorMessage = "Foydalanuvchi nomini kiriting")]
    public string? Username { get; set; }
    [Required(ErrorMessage = "Parol iritishni unutdingiz")]
    public string? Password { get; set; }
}
