using ECommerce.Core.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.InfaStructure.Seed
{
    public static class SeedingRoles
    {
        public static void SeedRoles(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<IdentityRole>().HasData(
                new { Id = "89cb02aa-154a-4ccf-92fd-981434b6ef31", Name = Roles.User , NormalizedName = Roles.User.ToUpper() , ConcurrencyStamp = "9752d138-83b6-4478-9d57-b186b38954ce"},
                new { Id = "9752d138-83b6-4478-9d57-b186b38954ce", Name = Roles.Admin , NormalizedName = Roles.Admin.ToUpper() , ConcurrencyStamp = "89cb02aa-154a-4ccf-92fd-981434b6ef31" }
                );
                
        }
    }
}
