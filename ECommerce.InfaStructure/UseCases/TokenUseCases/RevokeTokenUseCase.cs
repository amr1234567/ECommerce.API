using ECommerce.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.InfaStructure.UseCases.TokenUseCases
{
    public class RevokeTokenUseCase : IRevokeTokenUseCase
    {
        private readonly ITokenService _tokenService;

        public RevokeTokenUseCase(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public async Task<bool> Execute(string token)
        {
            return await _tokenService.RevokeToken(token);
        }
    }
}
