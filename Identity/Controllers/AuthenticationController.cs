using Application;
using Identity.Application.Interfaces;
using Identity.Domain.Entities;
using Identity.Domain.Models;
using Identity.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SP.Domain.Models;
using System.Net;

namespace Identity.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthService _authService;
   private readonly UserManager<ApplicationUser> _userManager;

    public AuthenticationController(IAuthService authService, ApplicationDbcontext dbcontext, UserManager<ApplicationUser> userManager)
    {
        _authService = authService;
        _userManager = userManager;
    }
    [HttpPost]
    [Route("login")]
    public async Task<ResponseModelForall<Token>> Login(Credential model)
    {
        return await _authService.LoginAsync(model);
    }
    [HttpPost("Registration")]
    public async Task<ResponseModelForall<(Token, ApplicationUser)>> Register(RegisteredModel model)
    {
       
        return await _authService.RegisterAsync(model);
    }
    [HttpPost("RefreshToken")]
    [AllowAnonymous]
    public async Task<ResponseModelForall<Token>> RefreshToken(Token token)
    {
        return await _authService.RefreshTokenAsync(token);
    }
    [HttpPost("UpdatePassword")]
    //[AuthefrationAttributeFilter("UpdatePassword")]
    public async Task<string> UpdatePassword(string UserName, string Password, string NewPassword)
    {
       return await _authService.UpdatePassword(UserName, Password, NewPassword);
    }
    [HttpPost("ForgotPassword")]
    //[AuthefrationAttributeFilter("ForgotPassword")]
    public async Task<string> YouForgotPassword(string Phone)
    {
        return await _authService.ForgotPasswordAsync(Phone);
    }
}
