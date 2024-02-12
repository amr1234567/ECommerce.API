using ECommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.DTO.ForDB
{
    public class ProductDtoForUpdate
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public double? Price { get; set; }

        public int? Quentity { get; set; }

        public Guid? CategoryId { get; set; }

        public byte[]? Picture { get; set; }

        public Product ToProduct()
        {
            return new Product()
            {
                Name = Name,
                Description = Description,
                CategoryId = CategoryId,
                Picture = Picture,
                Quentity = (int)Quentity
            };
        }
        public void ToProductDto(Product product)
        {
            Name = product.Name;
            Description = product.Description;
            CategoryId = product.CategoryId;
            Picture = product.Picture;
            Quentity = product.Quentity;
        }
    }
}
