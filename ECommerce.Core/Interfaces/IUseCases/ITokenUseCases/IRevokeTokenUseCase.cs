
namespace ECommerce.InfaStructure.UseCases.TokenUseCases
{
    public interface IRevokeTokenUseCase
    {
        Task<bool> Execute(string token);
    }
}