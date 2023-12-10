using Application;
using Identity.Domain.Entities;
using Identity.Domain.Models;
using System.Net;

namespace Identity.Application.Interfaces;

public interface IAuthService
{
    Task<ResponseModelForall<(Token, ApplicationUser)>> RegisterAsync(RegisteredModel model);
    Task<ResponseModelForall<Token>> LoginAsync(Credential credential);
    Task<ResponseModelForall<Token>> RefreshTokenAsync(Token token);
    Task<bool> SaveRefreshToken(string RefreshToken, ApplicationUser user);
    Task<bool> IsValidRefreshToken(string RefreshToken, int userid);
}
