using ECommerce.Core.Constants;
using ECommerce.Core.Entities;
using ECommerce.Core.Entities.Identity;
using ECommerce.InfaStructure.DBConfiguration;
using ECommerce.InfaStructure.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.InfaStructure.Context
{
    public class WebSiteContext : IdentityDbContext<WebSiteUser>
    {
        public WebSiteContext(DbContextOptions<WebSiteContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Note : As always the data in seeding functions is constant, it will never be added
            builder.SeedWithData();

            builder.RenameTables();
            builder.ModifyTables();

            base.OnModelCreating(builder);
        }
    }
}
