using System.ComponentModel.DataAnnotations;

namespace Identity.Domain.Models;

public class RegisteredModel
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string phone { get; set; }
    public string region { get; set; }
    public string District { get; set; }    
}
