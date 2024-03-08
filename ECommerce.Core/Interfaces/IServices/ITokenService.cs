using ECommerce.Core.Entities.Identity;
using ECommerce.InfaStructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Interfaces.IServices
{
    public interface ITokenService
    {
        RefreshToken CreateRefreshToken();
        Task<TokenModel> CreateToken(WebSiteUser user, List<string> roles, List<Claim>? Internalclaims = null);
    }
}
