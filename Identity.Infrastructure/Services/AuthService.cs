using Application;
using AutoMapper;
using Flurl;
using Identity.Application.Interfaces;
using Identity.Domain.Entities;
using Identity.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography;
using System.Text;
namespace Identity.Infrastructure.Services
{

public class AuthService : IAuthService
{   
    private readonly ITokenService _tokenService;
    private readonly ApplicationDbcontext _mydbcontext;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    private readonly int _refreshTokenLifetime;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly  RoleManager<Role> _roleManager;
    private readonly ApplicationDbcontext _dbcontext;
    private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly ILogger<AuthService> _logger;

        public AuthService(ITokenService tokenService, ApplicationDbcontext mydbcontext, IMapper mapper, IConfiguration configuration, UserManager<ApplicationUser> userManager, RoleManager<Role> roleManager, ApplicationDbcontext dbcontext, IUrlHelperFactory urlHelperFactory)
        {
            _tokenService = tokenService;
            _mydbcontext = mydbcontext;
            _mapper = mapper;
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;
          
            _dbcontext = dbcontext;
            _urlHelperFactory = urlHelperFactory;
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
             _logger.LogWarning($"{credential.Username + "  logged in " + DateTime.Now}");
                Token token = await _tokenService.GenerateTokenAsync(user);
          bool isSuccess = await SaveRefreshToken(token.RefreshToken, user);
          return isSuccess ? new(token) : new("Failed to save refresh token");
         
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
            ApplicationUser user = new()
            {
                phone = model.phone,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                UserName=model.Username

            };
          
            var CreatedUserResult = await _userManager.CreateAsync(user, model.Password);
        
           
          
      if(!CreatedUserResult.Succeeded)
        {
                return new("user creation failed");
        }
            _logger.LogWarning($"Registered user: {model.Username} when {DateTime.Now} ");
            var Giverole = await _userManager.AddToRoleAsync(user, "userbasic");
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
        public async Task<string> UpdatePassword(string UserName, string Password, string NewPassword)
        {
            var user = await _userManager.FindByNameAsync(UserName);

            if (user != null)
            {
                var passwordCorrect = await _userManager.CheckPasswordAsync(user, Password);

                if (passwordCorrect)
                {
                    var result = await _userManager.ChangePasswordAsync(user, Password, NewPassword);

                    if (result.Succeeded)
                    {
                        _logger.LogWarning($"{UserName}'s Updated password: {NewPassword}");
                        return "Password updated successfully";
                    }
                    else
                    {
                        return "Failed to update password";
                    }
                }
                else
                {
                   
                    return "Incorrect current password";
                }
            }
            else
            {
                
                return "User not found";
            }
        }


        public async Task<string> ForgotPasswordAsync(string Phone)
        {
            var user = await _userManager.FindByNameAsync(Phone);

            if (user != null)
            {
                var urlHelper = _urlHelperFactory.GetUrlHelper(new ActionContext());

                string token = await _userManager.GeneratePasswordResetTokenAsync(user);
                string? resetLink = urlHelper.Action("ResetPassword", "Account", new { token, userId = user.Id }, protocol: "https");

                return resetLink;
            }
            else
            {
                return "User not found";
            }
        }

    }
}