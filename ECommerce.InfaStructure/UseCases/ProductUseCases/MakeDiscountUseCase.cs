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
    public class MakeDiscountUseCase : IMakeDiscountUseCase
    {
        private readonly IProductService _productService;

        public MakeDiscountUseCase(IProductService productService)
        {
            _productService = productService;
        }

        public async Task Execute(Guid ProductId, double Discount)
        {
            await _productService.MakeDiscount(ProductId, Discount);
        }
    }
}
