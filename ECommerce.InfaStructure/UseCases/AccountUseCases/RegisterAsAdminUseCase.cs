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
    public class RegisterAsAdminUseCase : IRegisterAsAdminUseCase
    {
        private readonly IAccountService _accountService;

        public RegisterAsAdminUseCase(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<bool> Execute(RegisterDto user)
        {
            return await _accountService.RegisterAsAdmin(user);
        }
    }
}
