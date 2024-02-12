using ECommerce.Core.DTO.ForDB;
using ECommerce.Core.DTO.ForEndUser;
using ECommerce.Core.Interfaces.IServices;
using ECommerce.Core.Interfaces.IUseCases.IProductUseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.InfaStructure.UseCases.ProductUseCases
{
    public class GetProductsUseCase : IGetProductsUseCase
    {
        private readonly IProductService _productService;

        public GetProductsUseCase(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IEnumerable<ProductDtoOut>> Execute()
        {
            return await _productService.GetProducts();
        }
    }
}
