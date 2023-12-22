using Microsoft.EntityFrameworkCore;
using SP.Domain.Entities.BookingEntity;
using SP.Domain.Entities.Categories;
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
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<BookingStatusEntity> Bookings { get; set; }
}
