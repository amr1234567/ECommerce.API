using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Entities.Identity
{
    public class Address
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0} must have a value")]
        [MinLength(3, ErrorMessage = "{0} must be more than {1} Chars")]
        [MaxLength(100, ErrorMessage = "{0} must be less than {1} Chars")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} must have a value")]
        [MinLength(3, ErrorMessage = "{0} must be more than {1} Chars")]
        [MaxLength(100, ErrorMessage = "{0} must be less than {1} Chars")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "{0} must have a value")]
        [MinLength(3, ErrorMessage = "{0} must be more than {1} Chars")]
        [MaxLength(150, ErrorMessage = "{0} must be less than {1} Chars")]
        [Display(Name = "Street Name")]
        public string Street { get; set; }

        [Required(ErrorMessage = "{0} must have a value")]
        [MinLength(3, ErrorMessage = "{0} must be more than {1} Chars")]
        [MaxLength(150, ErrorMessage = "{0} must be less than {1} Chars")]
        [Display(Name = "City Name")]
        public string City { get; set; }

        [Required(ErrorMessage = "{0} must have a value")]
        [MinLength(3, ErrorMessage = "{0} must be more than {1} Chars")]
        [MaxLength(100, ErrorMessage = "{0} must be less than {1} Chars")]
        [Display(Name = "State Name")]
        public string State { get; set; }

        [Required(ErrorMessage = "{0} must have a value")]
        [MinLength(3, ErrorMessage = "{0} must be more than {1} Chars")]
        [MaxLength(150, ErrorMessage = "{0} must be less than {1} Chars")]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        public virtual WebSiteUser User { get; set; }
    }
}
