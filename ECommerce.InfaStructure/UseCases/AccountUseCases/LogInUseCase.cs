using ECommerce.Core.DTO.Account;
using ECommerce.Core.DTO.ForEndUser;
using ECommerce.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.InfaStructure.UseCases.AccountUseCases
{
    public class LogInUseCase : ILogInUseCase
    {
        private readonly IAccountService _accountService;

        public LogInUseCase(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<LogInReturn> Execute(LogInDto logInReturn)
        {
            return await _accountService.LogIn(logInReturn);
        }
    }
}
