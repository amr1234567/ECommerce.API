using ECommerce.Core.Entities;
using ECommerce.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.InfaStructure.DBConfiguration
{
    public static class TableRenaming
    {
        public static void RenameTables(this ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Security");

            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<WebSiteUser>().ToTable("Users");

            modelBuilder.Entity<Product>().ToTable("Products", "DB");
            modelBuilder.Entity<Category>().ToTable("Categories", "DB");
            modelBuilder.Entity<Address>().ToTable("Addresses", "DB");
        }
    }
}
