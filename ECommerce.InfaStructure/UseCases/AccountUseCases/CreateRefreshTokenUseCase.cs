using ECommerce.Core.Entities.Identity;
using ECommerce.Core.Interfaces.IServices;
using ECommerce.Core.Interfaces.IUseCases.IAccountUseCases;

namespace ECommerce.InfaStructure.UseCases.AccountUseCases
{
    public class CreateRefreshTokenUseCase : ICreateRefreshTokenUseCase
    {
        private readonly ITokenService _tokenService;

        public CreateRefreshTokenUseCase(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public RefreshToken Execute()
        {
            return _tokenService.CreateRefreshToken();
        }
    }
}
