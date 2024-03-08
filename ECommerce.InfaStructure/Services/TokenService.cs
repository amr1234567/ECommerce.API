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
using Azure;

namespace ECommerce.InfaStructure.Services
{
    public class TokenService : ITokenService
    {
        private SymmetricSecurityKey _key;
        private readonly IOptions<JwtConfigModel> _config;

        public TokenService(IOptions<JwtConfigModel> config)
        {
            _key = new SymmetricSecurityKey(new byte[10]);
            _config = config;
        }

        public Task<TokenModel> CreateToken(WebSiteUser user, List<string> roles, List<Claim>? Internalclaims = null)
        {
            var claims = new List<Claim>();
            if (Internalclaims is null)
            {
                claims.Add(new Claim(ClaimTypes.Email, user.Email));
                claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            }
            else
                claims.Union(Internalclaims);


            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Value.Key));

            var Credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature);
            var ExpierdOn = DateTime.Now.AddMinutes(_config.Value.expirePeriodInMinuts);
            var SecurityToken = new JwtSecurityToken(
                issuer: _config.Value.issuer,
                audience: _config.Value.audience,
                signingCredentials: Credentials,
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


    }
}
