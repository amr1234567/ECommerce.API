using ECommerce.Core.DTO.ForDB;
using ECommerce.Core.DTO.ForEndUser;
using ECommerce.Core.Entities;
using ECommerce.Core.Helpers;
using ECommerce.Core.Interfaces.IServices;
using ECommerce.InfaStructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.InfaStructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly WebSiteContext _context;

        public CategoryService(WebSiteContext context)
        {
            _context = context;
        }

        public async Task AddCategory(CategoryDtoIn category)
        {
            var Category = category.ToCategory();
            Category.Id = Guid.NewGuid();
            await _context.Categories.AddAsync(Category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategory(Guid Id)
        {
            var Category = await _context.Categories.FindAsync(Id);
            if (Category == null)
                throw new KeyNotFoundException("Can't Find The Category With Id : " + Id.ToString());
            _context.Categories.Remove(Category);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CategoryDtoOut>> GetCategories()
        {
            var ListCategory = await _context.Categories.ToListAsync();

            return ListCategory.ConvertCategoriesToDto();
        }

        public async Task<List<CategoryDtoOut>> GetCategoriesByFilters(params Func<Category, bool>[] filters)
        {
            if (filters == null || filters.Length == 0)
                return null;
            var Categories = await _context.Categories.ToListAsync();
            foreach (var filter in filters)
                Categories = Categories.Where(filter).ToList();

            return Categories.ConvertCategoriesToDto();
        }

        public async Task<CategoryDtoOut> GetCategoryById(Guid Id)
        {
            var Category = await _context.Categories.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            if (Category == null)
                return null;
            var CategoryDto = new CategoryDtoOut();
            CategoryDto.ToCategoryDto(Category);
            return CategoryDto;
        }

        public async Task UpdateCategoryDetails(CategoryDtoForUpdate category, Guid Id)
        {
            var Category = await _context.Categories.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            if (Category == null)
                throw new KeyNotFoundException("Can't Find The Category With Id : " + Id.ToString());
            Category.UpdateDataCategory(category);
            _context.Categories.Update(Category);
            await _context.SaveChangesAsync();
        }
    }
}
