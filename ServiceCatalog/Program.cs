
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using ServiceCatalog.Application.Inrefaces.Booking;
using ServiceCatalog.Application.Inrefaces.Playstation;
using ServiceCatalog.Application.Inrefaces.Stadiums;
using ServiceCatalog.Application.Profiles;
using ServiceCatalog.Application.Services.Booking;
using ServiceCatalog.Application.Services.Playstation;
using ServiceCatalog.Infrastructure.Data.Contex;
using ServiceCatalog.Infrastructure.Repositories.Booking;
using ServiceCatalog.Infrastructure.Repositories.Playstation;

namespace ServiceCatalog
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			Logger logger = new LoggerConfiguration().
				WriteTo.Console().MinimumLevel
				.Information().WriteTo
				.File(@"C:\Users\suoki\Desktop\Real\ServiceCatalog\TriggerFile\Logging.json").MinimumLevel.Information()
				.WriteTo.PostgreSQL(builder.Configuration.GetConnectionString("ShokirsDb"), "Logging", needAutoCreateTable: true).MinimumLevel
				.Information()
				.CreateLogger();

		   builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
            #region Db
            builder.Services.AddDbContext<AppDbContext>(option => option.UseNpgsql(builder.Configuration.GetConnectionString("ShokirsDb")));
            #endregion
            #region PlaystationServices
            builder.Services.AddScoped<IRepositoryPlaystationArea, PlaystationRepository>();
            builder.Services.AddScoped<IServicePlaystationArea, PlaystationService>();
			#endregion
			#region Mapper
			builder.Services.AddAutoMapper(typeof(MapProfile));
            #endregion
            #region BookingServices
            builder.Services.AddScoped<IServiceBooking, BookingService>();
            builder.Services.AddScoped<IRepositoryBooking, BookingRepository>();
            #endregion
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
}