using ECommerce.Core.DTO.ForDB;
using ECommerce.Core.DTO.ForEndUser;
using ECommerce.Core.Entities;
using ECommerce.Core.Interfaces.IServices;
using ECommerce.Core.Interfaces.IUseCases.ICategoryUseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.InfaStructure.UseCases.CategoryUseCases
{
    public class GetCategoriesByFiltersUseCase : IGetCategoriesByFiltersUseCase
    {
        private readonly ICategoryService categoryService;

        public GetCategoriesByFiltersUseCase(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public async Task<IEnumerable<CategoryDtoOut>> Execute(params Func<bool, IEnumerable<Category>>[] filters)
        {
            return await categoryService.GetCategoriesByFilters(filters);
        }
    }
}
