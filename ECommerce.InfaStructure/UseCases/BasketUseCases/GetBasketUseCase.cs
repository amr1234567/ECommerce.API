using ECommerce.Core.Entities.BusketEntities;
using ECommerce.Core.Interfaces.IServices;
using ECommerce.Core.Interfaces.IUseCases.IBasketUseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.InfaStructure.UseCases.BasketUseCases
{
    public class GetBasketUseCase : IGetBasketUseCase
    {
        private readonly IBasketService _basketService;

        public GetBasketUseCase(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<CustomerBasket> Execute(string BasketId)
        {
            return await _basketService.GetBasketAsync(BasketId);
        }
    }
}
