using ECommerce.Core.DTO.ForDB;
using ECommerce.Core.DTO.ForEndUser;
using ECommerce.Core.Entities;
using ECommerce.Core.Helpers;
using ECommerce.Core.Interfaces.IServices;
using ECommerce.InfaStructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var Product = await _context.Products.FindAsync(Id);
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
            var Product = await _context.Products.FindAsync(Id);
            if ( Product != null)
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

            if (products == null)
                return null;
            return products.ConvertProductsToDto();
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

        public async Task MakeDiscound(Guid ProductId, double DiscoundAmount)
        {
            if (DiscoundAmount < 0 || DiscoundAmount > 100)
                throw new ArgumentOutOfRangeException("Discound must be between 0 and 100");
            var Product = await _context.Products.FindAsync(ProductId);
            if (Product == null)
                throw new Exception("Can't Find Product with Id : " + ProductId.ToString());
            Product.Discound = DiscoundAmount;
            Product.OriginalPrice = Product.Price;
            Product.Price -= DiscoundAmount * Product.Price;
            _context.Products.Update(Product);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveDiscound(Guid ProductId)
        {
            var Product = await _context.Products.FindAsync(ProductId);
            if (Product == null)
                throw new Exception("Can't Find Product with Id : " + ProductId.ToString());
            if (Product.Discound != null && Product.OriginalPrice != null)
            {
                Product.Price = (double)Product.OriginalPrice;
                Product.OriginalPrice = null;
                Product.Discound = 0;
                _context.Products.Update(Product);
                await _context.SaveChangesAsync();
                return;
            }
            throw new Exception("Product with Id: " + ProductId.ToString() + "Doesn't have a descound amount or original price");
        }

        public async Task UpdateProductDetails(ProductDtoIn Product, Guid Id)
        {
            var DbProduct = await _context.Products.FindAsync(Id);
            if (DbProduct == null)
                throw new Exception("Can't Find Product with Id : " + Id.ToString());
            DbProduct.UpdateProductDetails(Product);
            _context.Products.Update(DbProduct);
            await _context.SaveChangesAsync();
        }
    }
}
