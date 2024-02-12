using ECommerce.Core.DTO.ForEndUser;
using ECommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Helpers
{
    public static class ConvertListToDto
    {
        public static List<ProductDtoOut> ConvertProductsToDto(this List<Product> list)
        {
            var products = new List<ProductDtoOut>();

            foreach (var Product in list)
            {
                var ProductDto = new ProductDtoOut();
                ProductDto.ToProductDto(Product);
                products.Add(ProductDto);
            }
            return products;
        }
        public static List<CategoryDtoOut> ConvertCategoriesToDto(this List<Category> list)
        {
            var Categories = new List<CategoryDtoOut>();

            foreach (var category in list)
            {
                var ProductDto = new CategoryDtoOut();
                ProductDto.ToCategoryDto(category);
                Categories.Add(ProductDto);
            }
            return Categories;
        }
    }
}
