using Application;
using Identity.Application.Interfaces;
using Identity.Domain.Entities;
using Identity.Domain.Enums;
using Identity.Domain.Models;
using Identity.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Identity.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly GetLocationService _locationService;

    public AuthenticationController(IAuthService authService, ApplicationDbcontext dbcontext, UserManager<ApplicationUser> userManager, GetLocationService locationService)
    {
        _authService = authService;
        _userManager = userManager;
        _locationService = locationService;
    }
    [HttpPost]
    [Route("login")]
    public async Task<ResponseModelForall<Token>> Login(Credential model)
    {
        return await _authService.LoginAsync(model);
    }
    [HttpPost("Registration")]
    public async Task<ResponseModelForall<Token>> Register(RegisteredModel model)
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
    public async Task<IActionResult> YouForgotPassword([EmailAddress] string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user != null)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetPasswordLink = Url.Action("ResetPassword", "Authentication", new { token, email = user.Email }, Request.Scheme);

            return Ok(new ResponseForemailMessage { Result = "success", Message = "Password reset link:", Data = resetPasswordLink });
        }                   
        return NotFound(new ResponseForemailMessage { Result = "error", Message = "User with the provided email not found." });
    }
    [HttpGet("getlocation")]
    public async Task<string> Getlocation(int districtid, Languages languages)
    {

      var res=  await _locationService.SendRequestForDistrinctAsync(districtid,languages);
        return res;
    }
} 
public class ResponseForemailMessage
{
    public string Result { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }
}

