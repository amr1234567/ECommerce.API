using ECommerce.Core.DTO.ForDB;
using ECommerce.Core.Interfaces.IServices;
using ECommerce.Core.Interfaces.IUseCases.ICategoryUseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.InfaStructure.UseCases.CategoryUseCases
{
    public class AddCategoryUseCase : IAddCategoryUseCase
    {
        private readonly ICategoryService _categoryService;

        public AddCategoryUseCase(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task Excute(CategoryDtoIn category)
        {
            await _categoryService.AddCategory(category);
        }
    }
}
