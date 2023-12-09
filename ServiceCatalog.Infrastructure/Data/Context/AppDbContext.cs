using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ServiceCatalog.Domain.Entity.Playstation;
using ServiceCatalog.Domain.Entity.Stadium;

namespace ServiceCatalog.Infrastructure.Data.Contex;

public class AppDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public AppDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public AppDbContext(DbContextOptions<AppDbContext> db) : base(db) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("JavlonsDb"));

    public DbSet<PlaystationArea> Playstations { get; set; }
    public DbSet<Stadium> Stadiums { get; set; }
}
