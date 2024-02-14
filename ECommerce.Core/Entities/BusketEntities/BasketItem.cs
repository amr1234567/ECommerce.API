namespace ECommerce.Core.Entities.BusketEntities
{
    public class BasketItem
    {
        public int ItemId { get; set; }
        public Guid ProductId { get; set; }
        public double ItemTotalPrice { get; set; }
        public int Quantity { get; set; 
    }
}