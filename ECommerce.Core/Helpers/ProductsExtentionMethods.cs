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
        public static void UpdateProductDetails(this Product Originalproduct ,Product newProduct)
        {
            Originalproduct.Quentity = (newProduct.Quentity == null || newProduct.Quentity == 0) ? Originalproduct.Quentity : Originalproduct.Quentity;
            Originalproduct.Picture = (newProduct.Picture == null) ? Originalproduct.Picture : Originalproduct.Picture;
            Originalproduct.Price = (newProduct.Price == null || newProduct.Price == 0) ? Originalproduct.Price : Originalproduct.Price;
            Originalproduct.CategoryId = (Guid.TryParse(newProduct.CategoryId.ToString(), out _)) ? Originalproduct.CategoryId : Originalproduct.CategoryId;
            Originalproduct.Description = (string.IsNullOrEmpty(newProduct.Description)) ? Originalproduct.Description : newProduct.Description;
        }

        public static void UpdateProductDetails(this Product Originalproduct, ProductDtoIn newProduct)
        {
            Originalproduct.Quentity = (newProduct.Quentity == null || newProduct.Quentity == 0) ? Originalproduct.Quentity : Originalproduct.Quentity;
            Originalproduct.Picture = (newProduct.Picture == null) ? Originalproduct.Picture : Originalproduct.Picture;
            Originalproduct.Price = (newProduct.Price == null || newProduct.Price == 0) ? Originalproduct.Price : Originalproduct.Price;
            Originalproduct.CategoryId = (Guid.TryParse(newProduct.CategoryId.ToString(), out _)) ? Originalproduct.CategoryId : Originalproduct.CategoryId;
            Originalproduct.Description = (string.IsNullOrEmpty(newProduct.Description)) ? Originalproduct.Description : newProduct.Description;
        }

        public static void UpdateProductDetails(this Product Originalproduct, ProductDtoForUpdate newProduct)
        {
            Originalproduct.Quentity = (newProduct.Quentity == null || newProduct.Quentity == 0) ? Originalproduct.Quentity : Originalproduct.Quentity;
            Originalproduct.Picture = (newProduct.Picture == null) ? Originalproduct.Picture : Originalproduct.Picture;
            Originalproduct.Price = (newProduct.Price == null || newProduct.Price == 0) ? Originalproduct.Price : Originalproduct.Price;
            Originalproduct.CategoryId = (Guid.TryParse(newProduct.CategoryId.ToString(), out _)) ? Originalproduct.CategoryId : Originalproduct.CategoryId;
            Originalproduct.Description = (string.IsNullOrEmpty(newProduct.Description)) ? Originalproduct.Description : newProduct.Description;
        }
    }
}
