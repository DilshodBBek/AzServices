using Application;
using AutoMapper;
using Identity.Application.Interfaces;
using Identity.Domain.Entities;
using Identity.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography;
using System.Text;
namespace Identity.Infrastructure.Services
{

public class AuthService : IAuthService
{   private readonly ILogger<AuthService> _logger;
    private readonly ITokenService _tokenService;
    private readonly ApplicationDbcontext _mydbcontext;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    private readonly int _refreshTokenLifetime;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly  RoleManager<Role> _roleManager;

        public AuthService(ITokenService tokenService, ApplicationDbcontext mydbcontext, IMapper mapper, IConfiguration configuration, UserManager<ApplicationUser> userManager, RoleManager<Role> roleManager, ILogger<AuthService> logger)
        {
            _tokenService = tokenService;
            _mydbcontext = mydbcontext;
            _mapper = mapper;
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        public async Task<bool> IsValidRefreshToken(string RefreshToken, int userid)
    {
        var res = _mydbcontext.RefreshTokens.Where(x => x.UserId.Equals(userid) && x.RefreshTokenValue.Equals(RefreshToken));
        RefreshToken? refreshTokenEntity;
        if (res.Count() != 1)
        {
            return false;
        }
        refreshTokenEntity = res.First();
        if (refreshTokenEntity.ExpireTime < DateTime.Now)
        {
            return false;
        }
        return true;

    }

    public async Task<ResponseModelForall<Token>> LoginAsync(Credential credential)
    {
        ApplicationUser user = await _userManager.FindByNameAsync(credential.Username);
        if (user != null && await _userManager.CheckPasswordAsync(user, credential.Password))
        {
          Token token = await _tokenService.GenerateTokenAsync(user);
          bool isSuccess = await SaveRefreshToken(token.RefreshToken, user);
          return isSuccess ? new(token) : new("Failed to save refresh token");
         _logger.LogInformation($"{credential.Username + " " + DateTime.Now}");
        }
            else
            {
                return new("User not found or password is incorrect", 404);
            }
        }

    public async Task<ResponseModelForall<Token>> RefreshTokenAsync(Token token) { 
        ApplicationUser user = await _tokenService.GetClaimsFromExpiredToken(token.AccessTokenk);
        if (!await IsValidRefreshToken(token.RefreshToken, user.Id))
        {
            return new("refresh token is invalid");
        }
        Token tokennew = await _tokenService.GenerateTokenAsync(user);
        bool issuccess = await SaveRefreshToken(tokennew.RefreshToken, user);
        return issuccess ? new(tokennew) : new("Failed");
    }

    public async Task<ResponseModelForall<(Token, ApplicationUser)>> RegisterAsync(RegisteredModel model)
    {
            ApplicationUser user = _mapper.Map<ApplicationUser>(model); 
           
        var isExistuser = _userManager.FindByNameAsync(model.Username);
        if (isExistuser! ==null)
        {
            return new("user already exist");
        }
        var CreatedUserResult = await _userManager.CreateAsync(user, model.Password);
      if(!CreatedUserResult.Succeeded)
        {
                return new("user creation failed");
        }
        Token token = await _tokenService.GenerateTokenAsync(user);
        bool issuccess = await SaveRefreshToken(token.RefreshToken, user);
        return issuccess ? new((token, user)) : new("failed");
    }
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