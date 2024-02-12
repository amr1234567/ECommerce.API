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
        public string Name { get; set; }
        public string? Description { get; set; }

        public void ToCategoryDto(Category category)
        {
            Id = category.Id;
            Name = category.Name;
            Description = category.Description;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            if (GetType() != obj.GetType())
                return false;
            var category = obj as CategoryDtoOut;
            return Id.Equals(category?.Id);
        }
    }
}
