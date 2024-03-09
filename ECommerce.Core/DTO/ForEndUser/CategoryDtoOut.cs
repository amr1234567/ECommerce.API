// Ignore Spelling: Dto

using ECommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.DTO.ForEndUser
{
    public class CategoryDtoOut
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public void ToCategoryDto(Category category)
        {
            Id = category.Id;
            Name = category.Name;
            Description = category.Description;
        }
    }
}
