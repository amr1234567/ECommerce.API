using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Entities.BusketEntities
{
    [Owned]
    public class AddressDto
    {
        public string Street { get; set; }


        public string City { get; set; }

        public string District { get; set; }

        public string State { get; set; }
        public string PhoneNumber { get; set; }

        public string ZipCode { get; set; }
    }
}
