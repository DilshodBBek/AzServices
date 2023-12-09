using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Payment.Aplication.Interface;
using Payment.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure
{
	public static  class ConfigurationServices 
	{
		//public static IServiceCollection AddTransactionFramework(this IServiceCollection services, IConfiguration configuration)
		//{
		//	// Service
		//	services.AddScoped<ITransactionService, TransactionService>();

		//	// Repository
		//	services.AddScoped<IAccountSummaryRepository, AccountSummaryRepository>();
		//	services.AddScoped<IAccountTransactionRepository, AccountTransactionRepository>();

		//	// Mappers
		//	services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));

		//	// Connection String

		//	return services;
		//}
	}
}
