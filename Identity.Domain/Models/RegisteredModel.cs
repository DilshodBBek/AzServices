using System.ComponentModel.DataAnnotations;

namespace Identity.Domain.Models;

public class RegisteredModel
{
    [Required(ErrorMessage = "Username kiritish taklab qilinadi")]
    public string? Username { get; set; }
    [Required(ErrorMessage = "Password kiritish talab qilinadi")]
    public string? Password { get; set; }
    [Required(ErrorMessage = "Ism kiritish talab qilinadi")]
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    [EmailAddress]
    public string Email { get; set; }
}
