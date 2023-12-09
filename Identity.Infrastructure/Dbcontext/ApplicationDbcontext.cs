using Identity.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Dbcontext;

public class ApplicationDbcontext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbcontext()
    {

    }
    public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options)
    {

    }
}
