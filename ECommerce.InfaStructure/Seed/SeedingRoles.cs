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
            var Roles = new List<IdentityRole>();
            foreach (var role in Enum.GetValues(typeof(Roles)))
                Roles.Add(new IdentityRole(role.ToString()));

            modelBuilder.Entity<IdentityRole>().HasData(Roles);
                
        }
    }
}
