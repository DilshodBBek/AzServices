using Identity.Application.Interfaces;
using Identity.Domain.Entities;
using Identity.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CrudforMedicshop.infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _configuration = configuration;
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<(int, string)> Login(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                return (0, "invalid username");
            }
            if (!await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return (0, "invalid Password");
            }
            var userroles = await _userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            foreach (var userrole in userroles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userrole));
            }
            string token = Generatetoken(authClaims);
            return (1, token);
        }

        private string Generatetoken(IEnumerable<Claim> authClaims)
        {
            var authsigningkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTKey:Secret"]));
            var TokenExpiryTimeInHour = Convert.ToInt64(_configuration["JWTKey:TokenExpiryTimeInHour"]);
            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _configuration["JWTKey:ValidAudience"],
                Issuer = _configuration["JWTKey:ValidIssuer"],
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(authsigningkey, SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(authClaims)

            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(TokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<(int, string)> Registration(RegisteredModel model, string role)
        {
            var UserExists = await _userManager.FindByNameAsync(model.Username);

            if (UserExists != null)
            {
                return (0, "User is Already exist");
            }
            ApplicationUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
                FirstName = model.Firstname,
                LastName = model.Lastname,
            };
            var CreatedUserResult = await _userManager.CreateAsync(user, model.Password);

            Console.WriteLine(CreatedUserResult);
            if (!CreatedUserResult.Succeeded)
            {
                return (0, "UserCreation is Failed,please Check your user details and try again");
            }
            if (!await _roleManager.RoleExistsAsync(role))
            {
                await _roleManager.CreateAsync(new IdentityRole(role));
            }
            if (await _roleManager.RoleExistsAsync(role))
            {
                await _userManager.AddToRoleAsync(user, role);
            }
            return (1, "User is Created Successfully!");
        }

        public async Task Logout()
        {
             await _signInManager.SignOutAsync();
        }
    }
}
