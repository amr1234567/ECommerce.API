using ECommerce.Core.DTO.ForEndUser;
using ECommerce.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.InfaStructure.UseCases.TokenUseCases
{
    public class RefreshTokenUseCase : IRefreshTokenUseCase
    {
        private readonly ITokenService _tokenService;

        public RefreshTokenUseCase(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public async Task<LogInReturn> Execute(string refreshtoken, string token)
        {
            return await _tokenService.RefreshToken(refreshtoken, token);
        }
    }
}
