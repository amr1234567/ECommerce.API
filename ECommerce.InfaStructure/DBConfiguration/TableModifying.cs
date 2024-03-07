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
    public static class TableModifying
    {
        public static void ModifyTables(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WebSiteUser>().Ignore(u => u.PhoneNumberConfirmed);
        }
    }
}
