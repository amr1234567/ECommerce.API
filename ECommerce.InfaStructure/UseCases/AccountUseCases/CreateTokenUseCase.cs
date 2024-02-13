using ECommerce.Core.Entities.Identity;
using ECommerce.Core.Interfaces;
using ECommerce.Core.Interfaces.IUseCases.IAccountUseCases;
using ECommerce.InfaStructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.InfaStructure.UseCases.AccountUseCases
{
    public class CreateTokenUseCase : ICreateTokenUseCase
    {
        private readonly ITokenService _tokenService;

        public CreateTokenUseCase(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public string Execute(WebSiteUser user, List<string> roles)
        {
            return _tokenService.CreateToken(user, roles);
        }
    }
}
