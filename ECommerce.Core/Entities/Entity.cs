using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Entities
{
    public class Entity
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0} must have a value")]
        [MinLength(3, ErrorMessage = "{0} must be more than {1} Chars")]
        [MaxLength(100, ErrorMessage = "{0} must be less than {1} Chars")]
        public string Name { get; set; }

        [MaxLength(200, ErrorMessage = "{0} must be less than {1} Chars")]
        public string? Description { get; set; }
    }
}
