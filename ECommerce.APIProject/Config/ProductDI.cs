using ECommerce.Core.Interfaces.IServices;
using ECommerce.Core.Interfaces.IUseCases.ICategoryUseCases;
using ECommerce.Core.Interfaces.IUseCases.IProductUseCases;
using ECommerce.InfaStructure.Services;
using ECommerce.InfaStructure.UseCases.CategoryUseCases;
using ECommerce.InfaStructure.UseCases.ProductUseCases;

namespace ECommerce.APIProject.Config
{
    public static class ProductDI
    {
        public static IServiceCollection AddProductsScopes(this IServiceCollection services)
        {
            //Service
            services.AddScoped<IProductService, ProductService>();

            //UseCases
            services.AddScoped<IAddProductUseCase, AddProductUseCase>();
            services.AddScoped<IUpdateProductUseCase, UpdateProductUseCase>();
            services.AddScoped<IDeleteProductUseCase, DeleteProductUseCase>();
            services.AddScoped<IGetProductByIdUseCase, GetProductByIdUseCase>();
            services.AddScoped<IGetProductsByCategoryIdUseCase, GetProductsByCategoryIdUseCase>();
            services.AddScoped<IGetProductsByFiltersUseCase, GetProductsByFiltersUseCase>();
            services.AddScoped<IGetProductsUseCase, GetProductsUseCase>();
            services.AddScoped<IMakeDiscountUseCase,MakeDescoundUseCase>();
            services.AddScoped<IRemoveDescoundUseCase,RemoveDiscountUseCase>();

            return services;
        }

        
    }
}
