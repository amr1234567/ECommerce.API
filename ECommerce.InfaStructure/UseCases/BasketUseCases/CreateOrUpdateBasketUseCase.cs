using ECommerce.Core.Entities.BusketEntities;
using ECommerce.Core.Interfaces.IServices;
using ECommerce.Core.Interfaces.IUseCases.IBasketUseCases;

namespace ECommerce.InfaStructure.UseCases.BasketUseCases
{
    public class CreateOrUpdateBasketUseCase : ICreateOrUpdateBasketUseCase
    {
        private readonly IBasketService _basketService;

        public CreateOrUpdateBasketUseCase(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<CustomerBasket> Execute(CustomerBasket customerBasket)
        {
            return await _basketService.UpdateOrCreateBasketAsync(customerBasket);
        }
    }
}
