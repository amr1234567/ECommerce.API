using ECommerce.Core.Entities.Identity;
using ECommerce.Core.Interfaces.IServices;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ECommerce.InfaStructure.Services
{
    public class TokenService : ITokenService
    {
        private SymmetricSecurityKey _key;
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
            _key = new SymmetricSecurityKey(new byte[10]);
        }

        public string CreateToken(WebSiteUser user, List<string> roles)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Email, user.Email),
                new(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            foreach (var role in roles) 
                claims.Add(new Claim(ClaimTypes.Role, role));

            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            var Credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature);

            var SecurityToken = new JwtSecurityToken(
                issuer: _configuration["JWT:issuer"],
                audience: _configuration["JWT:audience"],
                signingCredentials: Credentials,
                claims: claims,
                expires: DateTime.Now.AddDays(int.Parse(_configuration["JWT:expirePeriod"])));

            return "Bearer " + new JwtSecurityTokenHandler().WriteToken(SecurityToken);
        }
    }
}
