using ECommerce.Core.DTO.Account;
using ECommerce.Core.DTO.ForEndUser;

namespace ECommerce.InfaStructure.UseCases.AccountUseCases
{
    public interface ILogInUseCase
    {
        Task<LogInReturn> Execute(LogInDto logInReturn);
    }
}