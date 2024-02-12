using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Entities
{
    public class Category : Entity
    {
        public IEnumerable<Product>? Products { get; set; }
    }
}
