using ECommerce.Core.ConfigModels;
using ECommerce.Core.Entities.Identity;
using ECommerce.Core.Interfaces.IServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using ECommerce.Core.DTO.ForEndUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.InfaStructure.Services
{
    public class TokenService : ITokenService
    {
        private SymmetricSecurityKey _key;
        private readonly IOptions<JwtConfigModel> _config;
        private readonly UserManager<WebSiteUser> _userManager;

        public TokenService(IOptions<JwtConfigModel> config, UserManager<WebSiteUser> userManager)
        {
            _key = new SymmetricSecurityKey(new byte[10]);
            _config = config;
            _userManager = userManager;
        }

        public Task<TokenModel> CreateToken(WebSiteUser user, List<string> roles, List<Claim>? InternalClaims = null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            if (InternalClaims is not null)
                claims.Union(InternalClaims);


            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Value.Key));

            var ExpierdOn = DateTime.Now.AddMinutes(_config.Value.expirePeriodInMinuts);

            var SecurityToken = new JwtSecurityToken(
                issuer: _config.Value.issuer,
                audience: _config.Value.audience,
                signingCredentials: new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature),
                claims: claims,
                expires: ExpierdOn
                );

            return Task.FromResult(new TokenModel
            {
                Token = new JwtSecurityTokenHandler().WriteToken(SecurityToken),
                CreatedOn = DateTime.Now,
                ExpiredOn = ExpierdOn
            });
        }

        public RefreshToken CreateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
            }
            return new RefreshToken
            {
                CreatedOn = DateTime.UtcNow,
                ExpiredOn = DateTime.UtcNow.AddDays(_config.Value.RefreshExpiredPeriodInDays),
                Token = Convert.ToBase64String(randomNumber)
            };
        }

        public async Task<LogInReturn> RefreshToken(string refreshToken)
        {
            var response = new LogInReturn();

            var revokeCurrentToken = await RevokeToken(refreshToken);
            if (!revokeCurrentToken)
            {
                response.Message = "Invalid Token";
                return response;
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshTokens.Any(r => r.Token == refreshToken));
            if (user == null)
            {
                response.Message = "SomeThing Went Wrong";
                return response;
            }

            var newRefreshToken = CreateRefreshToken();
            user.RefreshTokens?.Add(newRefreshToken);
            response.RefreshToken = newRefreshToken.Token;
            response.RefreshTokenExpiration = newRefreshToken.ExpiredOn;


            var roles = await _userManager.GetRolesAsync(user);
            var newToken = await CreateToken(user, roles.ToList());
            response.Token = newToken.Token;
            response.TokenExpiration = newToken.ExpiredOn;

            response.Email = user.Email;
            response.UserName = user.Name;

            await _userManager.UpdateAsync(user);
            return response;
        }

        public async Task<bool> RevokeToken(string refreshToken)
        {
            if (string.IsNullOrEmpty(refreshToken))
                return false;

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshTokens.Any(r => r.Token == refreshToken));
            if (user == null)
                return false;

            var token = user.RefreshTokens?.FirstOrDefault(r => r.Token == refreshToken);
            if (token is not null && !token.IsActive)
                return false;

            token.RevokedOn = DateTime.UtcNow;
            await _userManager.UpdateAsync(user);

            return true;
        }
    }
}
