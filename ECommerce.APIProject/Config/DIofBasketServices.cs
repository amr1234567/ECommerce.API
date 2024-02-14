using ECommerce.Core.Interfaces.IServices;
using ECommerce.Core.Interfaces.IUseCases.IBasketUseCases;
using ECommerce.InfaStructure.Services;
using ECommerce.InfaStructure.UseCases.BasketUseCases;

namespace ECommerce.APIProject.Config
{
    public static class DIofBasketServices
    {
        public static IServiceCollection AddDIForBasketServices(this IServiceCollection services)
        {
            //Services
            services.AddScoped<IBasketService, BasketService>();

            //Use Cases
            services.AddScoped<ICreateOrUpdateBasketUseCase, CreateOrUpdateBasketUseCase>();
            services.AddScoped<IGetBasketUseCase,GetBasketUseCase>();
            services.AddScoped<IDeleteBasketUseCase,DeleteBasketUseCase>();


            return services;
        }
    }
}
