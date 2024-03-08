using ECommerce.Core.Entities.Identity;
using ECommerce.Core.Interfaces.IServices;
using ECommerce.Core.Interfaces.IUseCases.IAccountUseCases;
using ECommerce.InfaStructure.Context;
using ECommerce.InfaStructure.Services;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        public async Task<TokenModel> Execute(WebSiteUser user, List<string> roles, List<Claim>? clamis = null)
        {
            return await _tokenService.CreateToken(user, roles, clamis);
        }
    }
}
