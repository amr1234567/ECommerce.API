using ECommerce.Core.Entities.Identity;
using ECommerce.Core.Interfaces.IServices;
using ECommerce.Core.Interfaces.IUseCases.ITokenUseCases;
using ECommerce.InfaStructure.Context;
using ECommerce.InfaStructure.Services;
using ECommerce.InfaStructure.UseCases.AccountUseCases;
using ECommerce.InfaStructure.UseCases.TokenUseCases;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace ECommerce.APIProject.Config
{
    public static class ContextDI
    {
        public static IServiceCollection AddContextScopes(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddIdentity<WebSiteUser, IdentityRole>()
               .AddEntityFrameworkStores<WebSiteContext>();

            services.AddDbContext<WebSiteContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DB1"));
            });

            return services;
        }
    }
}
