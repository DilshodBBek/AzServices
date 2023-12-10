using Identity.Domain.Entities;
using Identity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Interfaces
{
    public interface ITokenService
    {
        Task<Token> GenerateTokenAsync(ApplicationUser user);
        Task<string> GenerateRefreshTokenAsync();
        Task<Token> GetNewTokenFromExpiredToken(Token tokens);
        Task<ApplicationUser> GetClaimsFromExpiredToken(string accesstoken);
        string ComputeSha256hash(string input);
    }
}
