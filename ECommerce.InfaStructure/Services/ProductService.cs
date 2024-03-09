// Ignore Spelling: Infa

using ECommerce.Core.DTO.ForDB;
using ECommerce.Core.DTO.ForEndUser;
using ECommerce.Core.Entities;
using ECommerce.Core.Helpers;
using ECommerce.Core.Interfaces.IServices;
using ECommerce.InfaStructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.InfaStructure.Services
{
    public class ProductService : IProductService
    {
        private readonly WebSiteContext _context;

        public ProductService(WebSiteContext context)
        {
            _context = context;
        }
        public async Task AddProduct(ProductDtoIn Product)
        {
            var newProduct = Product.ToProduct();
            newProduct.Id = Guid.NewGuid();
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(Guid Id)
        {
            var Product = await FindProduct(Id);
            if (Product != null)
            {
                _context.Products.Remove(Product);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Can't Find Product With Id :" + Id.ToString());
            }
        }

        public async Task<ProductDtoOut> GetProductById(Guid Id)
        {
            var Product = await FindProduct(Id);
            if (Product != null)
            {
                var Output = new ProductDtoOut();
                Output.ToProductDto(Product);
                return Output;
            }
            return null;

        }

        public async Task<List<ProductDtoOut>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();

            return products.ConvertProductsToDto();
        }

        public async Task<List<ProductDtoOut>> GetProductsByCategoryId(Guid CategoryId)
        {
            var products = await _context.Products
                .Where(p => p.CategoryId.Equals(CategoryId))
                .Include(p => p.Category)
                .ToListAsync();

            return products == null ? null : products.ConvertProductsToDto();
        }

        public async Task<List<ProductDtoOut>> GetProductsByFilters(params Func<Product, bool>[] filters)
        {
            var products = await _context.Products.ToListAsync();
            foreach (var filter in filters)
            {
                products = products.Where(filter).ToList();
            }
            if (products == null)
                return null;

            var ProductsDto = products.ConvertProductsToDto();
            ProductsDto = ProductsDto.Distinct().ToList();
            return ProductsDto;
        }

        public async Task MakeDiscount(Guid ProductId, double DiscountAmount)
        {
            if (DiscountAmount < 0 || DiscountAmount > 100)
                throw new ArgumentOutOfRangeException("Discount must be between 0 and 100");

            var Product = await FindProduct(ProductId);
            if (Product == null)
                throw new Exception("Can't Find Product with Id : " + ProductId.ToString());

            Product.Discount = DiscountAmount;
            Product.OriginalPrice = Product.Price;
            Product.Price -= (DiscountAmount / 100) * Product.Price;
            _context.Products.Update(Product);
            await _context.SaveChangesAsync();

        }

        public async Task RemoveDiscount(Guid ProductId)
        {
            var Product = await FindProduct(ProductId);
            if (Product == null)
                throw new Exception("Can't Find Product with Id : " + ProductId.ToString());
            if (Product.Discount != null && Product.OriginalPrice != null)
            {
                Product.Price = (double)Product.OriginalPrice;
                Product.OriginalPrice = null;
                Product.Discount = 0;
                _context.Products.Update(Product);
                await _context.SaveChangesAsync();
            }

        }

        public async Task UpdateProductDetails(ProductDtoForUpdate Product, Guid Id)
        {
            var DbProduct = await FindProduct(Id);
            if (DbProduct == null)
                throw new Exception("Can't Find Product with Id : " + Id.ToString());
            DbProduct.UpdateProductDetails(Product);
            _context.Products.Update(DbProduct);
            await _context.SaveChangesAsync();
        }

        private async Task<Product?> FindProduct(Guid Id) =>
            await _context.Products.FirstOrDefaultAsync(c => c.Id.Equals(Id));
    }
}
