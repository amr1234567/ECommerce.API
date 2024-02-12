using ECommerce.Core.Interfaces.IServices;
using ECommerce.Core.Interfaces.IUseCases.ICategoryUseCases;
using ECommerce.InfaStructure.Services;
using ECommerce.InfaStructure.UseCases.CategoryUseCases;

namespace ECommerce.APIProject.Config
{
    public static class CategoryDI
    {
        public static IServiceCollection AddCategoriesScopes(this IServiceCollection services)
        {
            //Service
            services.AddScoped<ICategoryService, CategoryService>();
            
            //UseCases
            services.AddScoped<IAddCategoryUseCase, AddCategoryUseCase>();
            services.AddScoped<IUpdateCategoryUseCase, UpdateCategoryUseCase>();
            services.AddScoped<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
            services.AddScoped<IGetCategoryByIdUseCase, GetCategoryByIdUseCase>();
            services.AddScoped<IGetCategoriesByFiltersUseCase, GetCategoriesByFiltersUseCase>();
            services.AddScoped<IGetCategoriesUseCase, GetCategoriesUseCase>();

            return services;
        }
    }
}
