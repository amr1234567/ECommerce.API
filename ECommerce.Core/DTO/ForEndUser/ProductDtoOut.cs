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
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            CategoryId = product.CategoryId;
            Picture = product.Picture;
            Quentity = product.Quentity;
            Discound = product.Discound;
            OriginalPrice = product.OriginalPrice;
            Price = product.Price;
            
        }
    }
}
