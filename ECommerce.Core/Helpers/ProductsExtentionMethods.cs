using ECommerce.Core.DTO.ForDB;
using ECommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Helpers
{
    public static class ProductsExtentionMethods
    {
        public static void UpdateProductDetails(this Product Originalproduct, Product newProduct)
        {
            Originalproduct.Name = string.IsNullOrEmpty(newProduct.Name) ? Originalproduct.Name : newProduct.Name;

            Originalproduct.Quantity = (newProduct.Quantity == null || newProduct.Quantity == 0) ? Originalproduct.Quantity : newProduct.Quantity;
            Originalproduct.Picture = (newProduct.Picture == null) ? Originalproduct.Picture : newProduct.Picture;
            Originalproduct.Price = (newProduct.Price == null || newProduct.Price == 0) ? Originalproduct.Price : newProduct.Price;
            Originalproduct.CategoryId = (!Guid.TryParse(newProduct.CategoryId.ToString(), out _)) ? Originalproduct.CategoryId : newProduct.CategoryId;
            Originalproduct.Description = (string.IsNullOrEmpty(newProduct.Description)) ? Originalproduct.Description : newProduct.Description;
        }

        public static void UpdateProductDetails(this Product Originalproduct, ProductDtoIn newProduct)
        {
            Originalproduct.Name = string.IsNullOrEmpty(newProduct.Name) ? Originalproduct.Name : newProduct.Name;

            Originalproduct.Quantity = (newProduct.Quentity == null || newProduct.Quentity == 0) ? Originalproduct.Quantity : newProduct.Quentity;
            Originalproduct.Picture = (newProduct.Picture == null) ? Originalproduct.Picture : newProduct.Picture;
            Originalproduct.Price = (newProduct.Price == null || newProduct.Price == 0) ? Originalproduct.Price : newProduct.Price;
            Originalproduct.CategoryId = (!Guid.TryParse(newProduct.CategoryId.ToString(), out _)) ? Originalproduct.CategoryId : newProduct.CategoryId;
            Originalproduct.Description = (string.IsNullOrEmpty(newProduct.Description)) ? Originalproduct.Description : newProduct.Description;
        }

        public static void UpdateProductDetails(this Product Originalproduct, ProductDtoForUpdate newProduct)
        {
            Originalproduct.Name = string.IsNullOrEmpty(newProduct.Name) ? Originalproduct.Name : newProduct.Name;
            Originalproduct.Quantity = (newProduct.Quentity == null || newProduct.Quentity == 0) ? (int)Originalproduct.Quantity : (int)newProduct.Quentity;
            Originalproduct.Picture = (newProduct.Picture == null) ? Originalproduct.Picture : newProduct.Picture;
            Originalproduct.Price = (newProduct.Price == null || newProduct.Price == 0) ? (double)Originalproduct.Price : (double)newProduct.Price;
            Originalproduct.CategoryId = (!Guid.TryParse(newProduct.CategoryId.ToString(), out _)) ? Originalproduct.CategoryId : newProduct.CategoryId;
            Originalproduct.Description = (string.IsNullOrEmpty(newProduct.Description)) ? Originalproduct.Description : newProduct.Description;
        }
    }
}
