using ECommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.InfaStructure.Seed
{
    public static class SeedingCategories
    {
        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Category 1",
                    Description = "Description",
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Category 2",
                    Description = "Description",
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Category 3",
                    Description = "Description",
                }
                );
        }
    }
}
