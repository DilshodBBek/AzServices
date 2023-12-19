using Application;
using Identity.Application.Interfaces;
using Identity.Domain.Entities;
using Identity.Domain.Models;
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
} 
public class ResponseForemailMessage
{
    public string Result { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }
}

