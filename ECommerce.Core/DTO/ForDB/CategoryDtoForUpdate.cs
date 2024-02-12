using ECommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.DTO.ForDB
{
    public class CategoryDtoForUpdate
    {
        public string? Name { get; set; }

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
