using ECommerce.Core.Entities.Identity;

namespace ECommerce.Core.Interfaces.IUseCases.IAccountUseCases
{
    public interface ICreateRefreshTokenUseCase
    {
        RefreshToken Execute();
    }
}