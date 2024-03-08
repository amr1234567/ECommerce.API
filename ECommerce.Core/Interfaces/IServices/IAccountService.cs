using ECommerce.Core.DTO.Account;
using ECommerce.Core.DTO.ForEndUser;

namespace ECommerce.Core.Interfaces.IServices
{
    public interface IAccountService
    {
        Task<LogInReturn> LogIn(LogInDto logInUser);
        Task<bool> RegisterAsAdmin(RegisterDto registerUser);
        Task<bool> RegisterAsUser(RegisterDto registerUser);
    }
}