using ECommerce.InfaStructure.Seed;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.InfaStructure.DBConfiguration
{
    public static class Seeding
    {
        public static void SeedWithData(this ModelBuilder modelBuilder)
        {
            modelBuilder.SeedCategories();
            modelBuilder.SeedProducts();
            modelBuilder.SeedRoles();
        }
    }
}
