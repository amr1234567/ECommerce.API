using ECommerce.Core.Interfaces.IServices;
using ECommerce.Core.Interfaces.IUseCases.IProductUseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.InfaStructure.UseCases.ProductUseCases
{
    public class MakeDescoundUseCase : IMakeDescoundUseCase
    {
        private readonly IProductService _productService;

        public MakeDescoundUseCase(IProductService productService)
        {
            _productService = productService;
        }

        public async void Execute(Guid ProductId, double Discound)
        {
            await _productService.MakeDiscound(ProductId, Discound);
        }
    }
}
