using ECommerce.Core.DTO.ForEndUser;

namespace ECommerce.InfaStructure.UseCases.TokenUseCases
{
    public interface IRefreshTokenUseCase
    {
        Task<LogInReturn> Execute(string token);
    }
}