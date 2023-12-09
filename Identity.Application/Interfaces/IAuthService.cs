using Identity.Domain.Models;

namespace Identity.Application.Interfaces;

public interface IAuthService
{
    Task<(int, string)> Registration(RegisteredModel model, string role);
    Task<(int, string)> Login(LoginModel model);
    Task Logout();
}
