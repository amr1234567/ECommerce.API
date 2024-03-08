using ECommerce.Core.DTO.ForEndUser;
using ECommerce.Core.Entities.Identity;
using ECommerce.Core.Interfaces.IUseCases.ITokenUseCases;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Helpers
{
    public static class RefreshTokenGenerator
    {
        public static void SetRefreshTokenInLogIn(this WebSiteUser user, ref LogInReturn response, ICreateRefreshTokenUseCase _createRefreshToken)
        {
            var refreshToken = new RefreshToken();
            if (user.RefreshTokens.Any(r => r.IsActive))
                refreshToken = user.RefreshTokens.FirstOrDefault(r => r.IsActive);
            else
            {
                refreshToken = _createRefreshToken.Execute();
                user.RefreshTokens.Add(refreshToken);
            }
            response.RefreshToken = refreshToken.Token;
            response.RefreshTokenExpiration = refreshToken.ExpiredOn;

        }
    }
}
