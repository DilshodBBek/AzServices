using Microsoft.AspNetCore.Identity;
namespace Identity.Domain.Entities;

public class Role : IdentityRole<int>
{
    public virtual ICollection<permission>? Permissions { get; set; }
}
