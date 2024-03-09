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
    public interface IProductService
    {
        Task<ProductDtoOut> GetProductById(Guid Id);
        Task<List<ProductDtoOut>> GetProducts();
        Task<List<ProductDtoOut>> GetProductsByCategoryId(Guid CategoryId);
        Task<List<ProductDtoOut>> GetProductsByFilters(params Func<Product, bool>[] filters);
        Task DeleteProduct(Guid Id);
        Task MakeDiscount(Guid ProductId, double DiscountAmount);
        Task RemoveDiscount(Guid ProductId);
        Task UpdateProductDetails(ProductDtoForUpdate Product, Guid Id);
        Task AddProduct(ProductDtoIn Product);
    }
}
