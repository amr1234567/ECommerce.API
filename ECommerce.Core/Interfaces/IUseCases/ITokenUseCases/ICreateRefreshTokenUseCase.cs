using ECommerce.Core.Entities.Identity;

namespace ECommerce.Core.Interfaces.IUseCases.ITokenUseCases
{
    public interface ICreateRefreshTokenUseCase
    {
        RefreshToken Execute();
    }
}