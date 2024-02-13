using ECommerce.Core.Entities.Identity;

namespace ECommerce.Core.Interfaces.IUseCases.IAccountUseCases
{
    public interface ICreateTokenUseCase
    {
        string Execute(WebSiteUser user, List<string> roles);
    }
}