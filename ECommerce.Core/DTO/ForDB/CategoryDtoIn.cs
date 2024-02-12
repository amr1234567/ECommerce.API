using ECommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.DTO.ForDB
{
    public class CategoryDtoIn
    {

        [Required(ErrorMessage = "{0} must have a value")]
        [MinLength(3, ErrorMessage = "{0} must be more than {1} Chars")]
        [MaxLength(100, ErrorMessage = "{0} must be less than {1} Chars")]
        public string Name { get; set; }

        [MaxLength(200, ErrorMessage = "{0} must be less than {1} Chars")]
        public string? Description { get; set; }

        public Category ToCategory()
        {
            return new Category()
            {
                Name = Name,
                Description = Description,
            };
        }
        public void ToCategoryDto(Category category)
        {
            Name = category.Name;
            Description = category.Description;
        }
    }
}
