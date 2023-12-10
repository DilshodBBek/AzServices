using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql.Internal.Postgres;
using ServiceCatalog.Domain.Entity.Booking;
using ServiceCatalog.Domain.Entity.Playstation;
using ServiceCatalog.Domain.Entity.Stadium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCatalog.Infrastructure.Data.Contex
{
    public class AppDbContext:DbContext
    {
        private readonly IConfiguration configuration;  
        public AppDbContext(DbContextOptions<AppDbContext> db,IConfiguration _conf) : base(db) { configuration = _conf; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)=>
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("ShokirsDb"));

        public DbSet<PlaystationArea> Playstations { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
    }
}
