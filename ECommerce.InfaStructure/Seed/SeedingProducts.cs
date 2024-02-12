using ECommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.InfaStructure.Seed
{
    public static class SeedingProducts
    {
        public static void SeedProducts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 1",
                    Price = 300,
                    CategoryId = Guid.Parse("71707f88-4722-4df1-b34f-8df6341e806c"),
                    Quentity = 27
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 2",
                    Price = 150,
                    CategoryId = Guid.Parse("6e2fe03d-0b89-4613-921e-c7eb7b0e708a"),
                    Quentity = 10
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 3",
                    Price = 150.5,
                    CategoryId = Guid.Parse("b41b2ba0-b99b-41d2-83b7-744dd943fc91"),
                    Quentity = 50
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 4",
                    Price = 300,
                    CategoryId = Guid.Parse("b41b2ba0-b99b-41d2-83b7-744dd943fc91"),
                    Quentity = 100
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 5",
                    Price = 150.9,
                    CategoryId = Guid.Parse("6e2fe03d-0b89-4613-921e-c7eb7b0e708a"),
                    Quentity = 20
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 6",
                    Price = 200,
                    CategoryId = Guid.Parse("71707f88-4722-4df1-b34f-8df6341e806c"),
                    Quentity = 5
                }
                );
        }
    }
}
