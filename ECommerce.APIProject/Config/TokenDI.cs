using ECommerce.Core.Entities.Identity;
using ECommerce.Core.Interfaces.IServices;
using ECommerce.Core.Interfaces.IUseCases.ITokenUseCases;
using ECommerce.InfaStructure.Context;
using ECommerce.InfaStructure.Services;
using ECommerce.InfaStructure.UseCases.TokenUseCases;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.APIProject.Config
{
    public static class TokenDI
    {
        public static IServiceCollection AddTokenScopes(this IServiceCollection services)
        {
            //service
            services.AddScoped<ITokenService, TokenService>();


            //Use Cases
            services.AddScoped<ICreateTokenUseCase, CreateTokenUseCase>();
            services.AddScoped<IRefreshTokenUseCase, RefreshTokenUseCase>();
            services.AddScoped<IRevokeTokenUseCase, RevokeTokenUseCase>();
            services.AddScoped<ICreateRefreshTokenUseCase, CreateRefreshTokenUseCase>();


            return services;
        }
    }
}
