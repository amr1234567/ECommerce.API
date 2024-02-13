using ECommerce.Core.Entities.Identity;
using ECommerce.Core.Interfaces;
using ECommerce.Core.Interfaces.IUseCases.IAccountUseCases;
using ECommerce.InfaStructure.Services;
using ECommerce.InfaStructure.UseCases.AccountUseCases;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.APIProject.Config
{
    public static class AccountDI
    {
        public static IServiceCollection AddAccountScopes(this IServiceCollection services)
        {
            //service
            services.AddScoped<ITokenService, TokenService>();
            //services.AddIdentity<WebSiteUser, IdentityRole>();

            //Use Cases
            services.AddScoped<ICreateTokenUseCase, CreateTokenUseCase>();


            return services;
        }
    }
}
