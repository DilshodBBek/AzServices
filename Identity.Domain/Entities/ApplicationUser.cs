
using Microsoft.AspNetCore.Identity;

namespace Identity.Domain.Entities;

public class ApplicationUser : IdentityUser<int>
{ 
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string phone { get; set; }
}
