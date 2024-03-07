using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Core.Entities
{
    public class OrderItem
    {
        [Key]
        public Guid Id { get; set; }
        public Product Product { get; set; }
        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        public double PriceOfItem { get; set; }
        public int Quantity { get; set; }
    }
}