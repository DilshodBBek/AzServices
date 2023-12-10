using Identity.Application.Interfaces;
using Identity.Domain.Entities;
using Identity.ExceptionHandler;
using Identity.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.Text;
using Identity.Application.Mapper;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//string Connectionpath = @"../Application/Common.json";
//string connectionString = File.ReadAllText(Connectionpath);
//JObject json = JObject.Parse(connectionString);
//string defaultConnectionString = json["ConnectionStrings"]["DefaultConnection"].ToString();

builder.Services.AddDbContext<ApplicationDbcontext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<ApplicationUser, Role>().AddEntityFrameworkStores<ApplicationDbcontext>().AddDefaultTokenProviders();
builder.Services.AddScoped<IAuthService,AuthService>();
builder.Services.AddScoped<ITokenService,TokenService>();
builder.Services.addmapping();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.TokenValidationParameters = new()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWTKey:ValidIssuer"],
        ValidAudience = builder.Configuration["JWTKey:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTKey:Secret"]))
    };
    options.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
            {
                context.Response.Headers.Add("istokentExpired", "true");
            }
            return Task.CompletedTask;
        }
    };
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<ExceptionMiddlerWare>();

app.MapControllers();

app.Run();
