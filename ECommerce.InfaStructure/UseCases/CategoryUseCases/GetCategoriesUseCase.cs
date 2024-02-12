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
    public class GetCategoriesUseCase : IGetCategoriesUseCase
    {
        private readonly ICategoryService _categoryService;

        public GetCategoriesUseCase(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IEnumerable<CategoryDtoOut>> Execute()
        {
            return await _categoryService.GetCategories();
        }
    }
}
