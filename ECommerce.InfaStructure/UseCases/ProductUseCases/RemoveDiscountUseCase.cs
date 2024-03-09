// Ignore Spelling: Infa

using ECommerce.Core.Interfaces.IServices;
using ECommerce.Core.Interfaces.IUseCases.IProductUseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.InfaStructure.UseCases.ProductUseCases
{
    public class RemoveDiscountUseCase : IRemoveDiscountUseCase
    {
        private readonly IProductService _productService;

        public RemoveDiscountUseCase(IProductService productService)
        {
            _productService = productService;
        }

        public async Task Execute(Guid ProductId)
        {
            await _productService.RemoveDiscount(ProductId);
        }
    }
}
