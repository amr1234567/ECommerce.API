using ECommerce.Core.Entities.BusketEntities;

namespace ECommerce.Core.Interfaces.IUseCases.IBasketUseCases
{
    public interface ICreateOrUpdateBasketUseCase
    {
        Task<CustomerBasket> Execute(CustomerBasket customerBasket);
    }
}