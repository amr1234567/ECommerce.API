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
    public class RegisterAsUserUseCase : IRegisterAsUserUseCase
    {
        private readonly IAccountService _accountService;

        public RegisterAsUserUseCase(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<bool> Execute(RegisterDto user)
        {
            return await _accountService.RegisterAsUser(user);
        }
    }
}
