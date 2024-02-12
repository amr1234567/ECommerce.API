using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Entities
{
    public class Product : Entity
    {
        [Required(ErrorMessage = "{0} must have value")]
        [Range(0.1, double.MaxValue)]
        public double Price { get; set; }

        [Range(0.1, 100, ErrorMessage = "Out of Range")]
        public double? Discound { get; set; }

        [Range(0.1, double.MaxValue)]
        public double? OriginalPrice { get; set; }

        [Required(ErrorMessage = "{0} must have value")]
        [Range(0, double.MaxValue)]
        public int Quentity { get; set; }

        [ForeignKey("Category")]
        public Guid? CategoryId { get; set; }

        public virtual Category? Category { get; set; }

        public byte[]? Picture { get; set; }
    }
}
