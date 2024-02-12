using ECommerce.Core.DTO.ForDB;
using ECommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Helpers
{
    public static class CategoriesExtentionMethods
    {
        public static void UpdateDataCategory(this Category OriginalCategory, Category NewCategory)
        {
            OriginalCategory.Description = string.IsNullOrEmpty(NewCategory.Description) ? OriginalCategory.Description : NewCategory.Description;
            OriginalCategory.Name = string.IsNullOrEmpty(NewCategory.Name) ? OriginalCategory.Name : NewCategory.Name;
        }

        public static void UpdateDataCategory(this Category OriginalCategory, CategoryDtoIn NewCategory)
        {
            OriginalCategory.Description = string.IsNullOrEmpty(NewCategory.Description) ? OriginalCategory.Description: NewCategory.Description;
            OriginalCategory.Name = string.IsNullOrEmpty(NewCategory.Name) ? OriginalCategory.Name : NewCategory.Name;
        }

        public static void UpdateDataCategory(this Category OriginalCategory, CategoryDtoForUpdate NewCategory)
        {
            OriginalCategory.Description = string.IsNullOrEmpty(NewCategory.Description) ? OriginalCategory.Description : NewCategory.Description;
            OriginalCategory.Name = string.IsNullOrEmpty(NewCategory.Name) ? OriginalCategory.Name : NewCategory.Name;
        }
    }
}
