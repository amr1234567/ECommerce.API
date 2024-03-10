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
                    Id = Guid.Parse("f508d83d-0d42-49f4-8d73-c238332b8d53"),
                    Name = "Product 1",
                    Price = 300,
                    CategoryId = Guid.Parse("71707f88-4722-4df1-b34f-8df6341e806c"),
                    Quantity = 27
                },
                new Product
                {
                    Id = Guid.Parse("ec113c17-0d52-4b86-a98b-ba2e6135b639"),
                    Name = "Product 2",
                    Price = 150,
                    CategoryId = Guid.Parse("6e2fe03d-0b89-4613-921e-c7eb7b0e708a"),
                    Quantity = 10
                },
                new Product
                {
                    Id = Guid.Parse("f088a3ea-6085-4ffd-9082-2a1cd45e742c"),
                    Name = "Product 3",
                    Price = 150.5,
                    CategoryId = Guid.Parse("b41b2ba0-b99b-41d2-83b7-744dd943fc91"),
                    Quantity = 50
                },
                new Product
                {
                    Id = Guid.Parse("0cdb9ac8-d1e4-436e-9039-2ee6bd6647a9"),
                    Name = "Product 4",
                    Price = 300,
                    CategoryId = Guid.Parse("b41b2ba0-b99b-41d2-83b7-744dd943fc91"),
                    Quantity = 100
                },
                new Product
                {
                    Id = Guid.Parse("2f8206af-bc7f-4edf-8688-75cee9448329"),
                    Name = "Product 5",
                    Price = 150.9,
                    CategoryId = Guid.Parse("6e2fe03d-0b89-4613-921e-c7eb7b0e708a"),
                    Quantity = 20
                },
                new Product
                {
                    Id = Guid.Parse("83680c33-bd20-4401-b553-44e2fcc072ee"),
                    Name = "Product 6",
                    Price = 200,
                    CategoryId = Guid.Parse("71707f88-4722-4df1-b34f-8df6341e806c"),
                    Quantity = 5
                }
                );
        }
    }
}
