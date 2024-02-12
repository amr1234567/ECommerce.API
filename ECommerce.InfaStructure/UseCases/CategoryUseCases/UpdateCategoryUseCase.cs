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
    public class UpdateCategoryUseCase : IUpdateCategoryUseCase
    {
        private readonly ICategoryService _categoryService;

        public UpdateCategoryUseCase(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task Execute(CategoryDtoForUpdate category, Guid CategoryId)
        {
            await _categoryService.UpdateCategoryDetails(category, CategoryId);
        }
    }
}
