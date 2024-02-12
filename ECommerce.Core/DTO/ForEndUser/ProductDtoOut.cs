using ECommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.DTO.ForEndUser
{
    public class ProductDtoOut
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public double Price { get; set; }

        public int Quentity { get; set; }

        public double? Discound { get; set; }

        public Guid? CategoryId { get; set; }

        public double? OriginalPrice { get; set; }

        public byte[]? Picture { get; set; }

        public void ToProductDto(Product product)
        {
            Name = product.Name;
            Description = product.Description;
            CategoryId = product.CategoryId;
            Picture = product.Picture;
            Quentity = product.Quentity;
            Discound = product.Discound;
            OriginalPrice = product.OriginalPrice;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            var product = obj as ProductDtoOut;
            return Id.Equals(product?.Id);
        }
    }
}
