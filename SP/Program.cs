using Microsoft.EntityFrameworkCore;
using SP.Application.Services;
using SP.Domain.Entities.BookingEntity;
using SP.Domain.Entities.Categories;
using SP.Domain.Entities.LocationEntities;
using SP.Infrastructure.DataAccess;
using SP.Infrastructure.Services;

namespace SP;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddScoped<IRegionService<RegionEntity>, RegionService>();
        builder.Services.AddScoped<IDistrictService<DistrictEntity>, DistrictService>();
        builder.Services.AddScoped<ICategoryService<CategoryEntity>, CategoryService>();
        builder.Services.AddScoped<IBookingStatusService<BookingStatusEntity>, BookingStatusService>();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<StadiumDbContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("Connection")));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
