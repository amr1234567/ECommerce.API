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
            Originalproduct.Quentity = newProduct.Quentity;
            Originalproduct.Picture = newProduct.Picture;
            Originalproduct.Price = newProduct.Price;
            Originalproduct.CategoryId = newProduct.CategoryId;
            Originalproduct.Description = newProduct.Description;
        }

        public static void UpdateProductDetails(this Product Originalproduct, ProductDtoIn newProduct)
        {
            Originalproduct.Quentity = newProduct.Quentity;
            Originalproduct.Picture = newProduct.Picture;
            Originalproduct.Price = newProduct.Price;
            Originalproduct.CategoryId = newProduct.CategoryId;
            Originalproduct.Description = newProduct.Description;
        }
    }
}
