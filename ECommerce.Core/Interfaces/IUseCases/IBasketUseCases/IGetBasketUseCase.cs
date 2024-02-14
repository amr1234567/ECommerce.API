using ECommerce.Core.Entities.BusketEntities;

namespace ECommerce.Core.Interfaces.IUseCases.IBasketUseCases
{
    public interface IGetBasketUseCase
    {
        Task<CustomerBasket> Execute(string BasketId);
    }
}