using ECommerce.Core.Entities.Identity;
using ECommerce.InfaStructure.Services;
using System.Security.Claims;

namespace ECommerce.Core.Interfaces.IUseCases.ITokenUseCases
{
    public interface ICreateTokenUseCase
    {
        Task<TokenModel> Execute(WebSiteUser user, List<string> roles, List<Claim>? claims = null);
    }
}