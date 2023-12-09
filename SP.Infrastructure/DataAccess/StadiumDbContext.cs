using Microsoft.EntityFrameworkCore;
using SP.Domain.Entities.LocationEntities;

namespace SP.Infrastructure.DataAccess;

public class StadiumDbContext : DbContext
{
    public StadiumDbContext()
    {
        
    }

    public StadiumDbContext(DbContextOptions<StadiumDbContext> options)
        : base(options)
    {

    }

    public DbSet<RegionEntity> Regions { get; set; }
    public DbSet<DistrictEntity> Districts { get; set; }

    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    1 viloyat kop tuman cons
        base.OnModelCreating(modelBuilder);
    }*/
}
