
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;

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
                .File(@"C:\Users\suoki\Desktop\ForMachingLearning\log.json").MinimumLevel.Information()
                //.WriteTo.PostgreSQL("Host=::1;Port=5432;Database=postgres;User id=postgres;Password=adminadmin", "Logging", needAutoCreateTable: true).MinimumLevel
                //.Information().WriteTo
                //.Telegram(botToken: "6069174877:AAHlmFZOZQjWw3nNCQPbR34kNYWp4XCTSnU", "6318296969")
                .CreateLogger();
            // Add services to the container.

            builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

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