using ECommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.DTO.ForDB
{
    public class ProductDtoIn
    {
        [Required(ErrorMessage = "{0} must have a value")]
        [MinLength(3, ErrorMessage = "{0} must be more than {1} Chars")]
        [MaxLength(100, ErrorMessage = "{0} must be less than {1} Chars")]
        public string Name { get; set; }

        [MaxLength(200, ErrorMessage = "{0} must be less than {1} Chars")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "{0} must have value")]
        [Range(0.1, double.MaxValue)]
        public double Price { get; set; }

        [Required(ErrorMessage = "{0} must have value")]
        [Range(0, double.MaxValue)]
        public int Quentity { get; set; }

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
                Quantity = Quentity
            };
        }
        public void ToProductDto(Product product)
        {
            Name = product.Name;
            Description = product.Description;
            CategoryId = product.CategoryId;
            Picture = product.Picture;
            Quentity = product.Quantity;
        }
    }
}
