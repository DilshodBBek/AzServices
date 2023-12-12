using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security;

namespace Identity.Domain.Entities
{
    public class ApplicationDbcontext : IdentityDbContext<ApplicationUser,Role,int>
    {
        public DbSet<permission> Permissions { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Role> Roles { get; set; }
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options)
        {
        }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Role>()
        //        .HasMany(r => r.Permissions)
        //        .WithOne()
        //        .HasForeignKey(rp => rp.roles)
        //        .IsRequired();
        //}
    }
}
