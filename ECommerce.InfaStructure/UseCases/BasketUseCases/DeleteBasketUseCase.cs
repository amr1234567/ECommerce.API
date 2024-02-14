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
    public class DeleteBasketUseCase : IDeleteBasketUseCase
    {
        private readonly IBasketService _basketService;

        public DeleteBasketUseCase(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<bool> Execute(string customerId)
        {
            return await _basketService.DeleteBasketAsync(customerId);
        }
    }
}
