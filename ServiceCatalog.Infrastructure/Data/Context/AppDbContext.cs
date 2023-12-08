using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql.Internal.Postgres;
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
        private readonly IConfiguration _configuration;
        public AppDbContext(IConfiguration configuration)
        {
            _configuration=configuration;
        }
        public AppDbContext(DbContextOptions<AppDbContext> db) : base(db) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)=>
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("JavlonsDb"));

        public DbSet<PlaystationArea> Playstations { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
    }
}
