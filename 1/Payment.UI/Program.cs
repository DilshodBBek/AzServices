
using Payment.Aplication.Service;
using Payment.Infrastructure.Date;
using Payment.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;

namespace Payment.UI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddScoped<IUserAccountService, UserAccountService>();
			builder.Services.AddScoped<IUserTransoctionService, UserTransoctionService>();
			builder.Services.AddDbContext<PaymentDbContext>(options =>
		   options.UseNpgsql(builder.Configuration.GetConnectionString("AZServicesConfugretion")));



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