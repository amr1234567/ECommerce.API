using ECommerce.Core.DTO.ForDB;
using ECommerce.Core.DTO.ForEndUser;
using ECommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Interfaces.IServices
{
    public interface ICategoryService
    {
        Task<CategoryDtoOut> GetCategoryById(Guid Id);
        Task<List<CategoryDtoOut>> GetCategories();
        Task<List<CategoryDtoOut>> GetCategoriesByFilters(params Func<Category, bool>[] filters);
        Task DeleteCategory(Guid Id);
        Task UpdateCategoryDetails(CategoryDtoIn category, Guid Id);
        Task AddCategory(CategoryDtoIn category);
    }
}
