using Application;
using Identity.Application.Interfaces;
using Identity.Domain.Entities;
using Identity.Domain.Models;
using Identity.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SP.Domain.Models;
using System.Net;

namespace Identity.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly ILogger<AuthenticationController> _logger;
    private readonly AuthService _authservice;

    public AuthenticationController(IAuthService authService, ILogger<AuthenticationController> logger, AuthService authservice)
    {
        _authService = authService;
        _logger = logger;
        _authservice = authservice;
    }
    [HttpPost]
    [Route("login")]
    public async Task<ResponseModelForall<Token>> Login(Credential model)
    {
        return await _authservice.LoginAsync(model);
    }
    [HttpPost("Registration")]
    public async Task<ResponseModelForall<(Token, ApplicationUser)>> Register(RegisteredModel model)
    {
        return await _authservice.RegisterAsync(model);
    }
    [HttpPost("RefreshToken")]
    [AllowAnonymous]
    public async Task<ResponseModelForall<Token>> RefreshToken(Token token)
    {
        return await _authservice.RefreshTokenAsync(token);
    }
}
