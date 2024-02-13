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
                    Id = Guid.Parse("71707f88-4722-4df1-b34f-8df6341e806c"),
                    Name = "Category 1",
                    Description = "Description",
                },
                new Category
                {
                    Id = Guid.Parse("6e2fe03d-0b89-4613-921e-c7eb7b0e708a"),
                    Name = "Category 2",
                    Description = "Description",
                },
                new Category
                {
                    Id = Guid.Parse("b41b2ba0-b99b-41d2-83b7-744dd943fc91"),
                    Name = "Category 3",
                    Description = "Description",
                }
                );
        }
    }
}
