using Serilog;
using Serilog.Core;

namespace ServiceCatalog;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        Logger logger = new LoggerConfiguration().
            WriteTo.Console().MinimumLevel
            .Information().WriteTo
            .File(@"C:\Users\suoki\Desktop\Real\ServiceCatalog\info\").MinimumLevel.Information()
            .WriteTo.PostgreSQL(builder.Configuration.GetConnectionString("ShokirsDb"), "Logging", needAutoCreateTable: true).MinimumLevel
            .Information()
            .CreateLogger();

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