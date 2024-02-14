using ECommerce.Core.Entities.BusketEntities;

namespace ECommerce.Core.Interfaces.IUseCases.IBasketUseCases
{
    public interface IDeleteBasketUseCase
    {
        Task<bool> Execute(string customerId);
    }
}