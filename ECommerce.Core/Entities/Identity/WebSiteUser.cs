using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Entities.Identity
{
    public class WebSiteUser : IdentityUser
    {
        public byte[]? ImageProfile { get; set; }
        
        [ForeignKey(nameof(Address))]
        public Guid? AddressId { get; set; }
        public virtual Address? Address { get; set; }
    }
}
