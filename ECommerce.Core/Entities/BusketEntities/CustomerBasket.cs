namespace ECommerce.Core.Entities.BusketEntities
{
    public class CustomerBasket
    {
        public CustomerBasket()
        {
        }

        public CustomerBasket(string _BusketId)
        {
            BusketId = _BusketId;
        }

        public string BusketId { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
        public string ClientSecret { get; set; }
        public string PaymentIntentId { get; set; }
    }
}