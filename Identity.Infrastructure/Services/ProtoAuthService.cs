using Application;
using AutoMapper;
using Grpc.Core;
using Identity.Application.Interfaces;
using Identity.Domain.Entities;
using Identity.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Protos;
using System.Security.Cryptography;
using System.Text;

namespace Identity.Infrastructure.Services
{
    public class ProtoAuthService : AuthService.AuthServiceBase
    {
        private readonly ITokenService _tokenService;
        private readonly ApplicationDbcontext _mydbcontext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly int _refreshTokenLifetime;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ApplicationDbcontext _dbcontext;
        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly ILogger<AuthService1> _logger;

        public ProtoAuthService(ITokenService tokenService, ApplicationDbcontext mydbcontext, IMapper mapper, IConfiguration configuration, UserManager<ApplicationUser> userManager, RoleManager<Role> roleManager, ApplicationDbcontext dbcontext, IUrlHelperFactory urlHelperFactory, ILogger<AuthService1> logger)
        {
            _tokenService = tokenService;
            _mydbcontext = mydbcontext;
            _mapper = mapper;
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;

            _dbcontext = dbcontext;
            _urlHelperFactory = urlHelperFactory;
            _logger = logger;
        }

        public override async Task<ResponseModelForall> LoginAsync(Protos.Credential credential, ServerCallContext context)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(credential.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, credential.Password))
            {
                _logger.LogWarning($"{credential.Username + "  logged in " + DateTime.Now}");
                Domain.Models.Token token = await _tokenService.GenerateTokenAsync(user);
                Protos.Token pars = new Protos.Token()
                {
                    AccessToken = token.AccessToken,
                    RefreshToken = token.RefreshToken
                };
                bool isSuccess = await SaveRefreshToken(token.RefreshToken, user);

                return isSuccess ? new()
                {
                    Result = pars,
                    StatusCode = 200
                } : new()
                {
                    Error = "Failed to save refresh token"
                };

            }
            else
            {
                return new()
                {
                    Error = "error chiqdi"
                };
            }
        }

        //public async Task<ResponseModelForall<Protos.Token>> LoginAsync(Protos.Credential credential)
        //{
        //    ApplicationUser user = await _userManager.FindByNameAsync(credential.Username);
        //    if (user != null && await _userManager.CheckPasswordAsync(user, credential.Password))
        //    {
        //        _logger.LogWarning($"{credential.Username + "  logged in " + DateTime.Now}");
        //        Domain.Models.Token token = await _tokenService.GenerateTokenAsync(user);
        //        Protos.Token pars = new Protos.Token() { 
        //            AccessToken=token.AccessToken,
        //            RefreshToken = token.RefreshToken
        //        };
        //        bool isSuccess = await SaveRefreshToken(token.RefreshToken, user);
        //        return isSuccess ? new(pars) : new("Failed to save refresh token");

        //    }
        //    else
        //    {
        //        return new("User not found or password is incorrect", 404);
        //    }
        //}

        public string ComputeSha256hash(string input)
        {
            using (var sha256 = SHA256.Create())
            {

                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public async Task<bool> SaveRefreshToken(string refreshToken, ApplicationUser user)
        {
            if (string.IsNullOrEmpty(refreshToken))
            {
                return false;
            }
            RefreshToken? refreshTokenEntity;
            var res = _mydbcontext.RefreshTokens.Where(x => x.UserId.Equals(user.Id) && x.RefreshTokenValue.Equals(refreshToken));
            if (res.Count() == 0)
            {
                refreshTokenEntity = new()
                {
                    ExpireTime = DateTime.Now.AddMinutes(_refreshTokenLifetime),
                    UserId = user.Id,
                    RefreshTokenValue = refreshToken
                };
                await _mydbcontext.RefreshTokens.AddAsync(refreshTokenEntity);

            }
            else if (res.Count() == 1)
            {
                refreshTokenEntity = res.First();
                refreshTokenEntity.RefreshTokenValue = refreshToken;
                refreshTokenEntity.ExpireTime = DateTime.Now.AddMinutes(_refreshTokenLifetime);
                _mydbcontext.RefreshTokens.Update(refreshTokenEntity);
            }

            else
            {
                return false;
            }


            int rows = await _mydbcontext.SaveChangesAsync();
            return rows > 0;
        }
       
    }
}
