using ECommerce.Core.Interfaces.IServices;
using ECommerce.Core.Interfaces.IUseCases.ICategoryUseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.InfaStructure.UseCases.CategoryUseCases
{
    public class DeleteCategoryUseCase : IDeleteCategoryUseCase
    {
        private readonly ICategoryService _categoryService;

        public DeleteCategoryUseCase(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task Execute(Guid Id)
        {
            await _categoryService.DeleteCategory(Id);
        }
    }
}
