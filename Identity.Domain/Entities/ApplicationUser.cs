
using Microsoft.AspNetCore.Identity;

namespace Identity.Domain.Entities;

public class ApplicationUser : IdentityUser<int>
{
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Username { get; set; }
    public string phone { get; set; }
}
