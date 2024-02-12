using ECommerce.Core.DTO.ForDB;
using ECommerce.Core.Interfaces.IServices;
using ECommerce.Core.Interfaces.IUseCases.IProductUseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.InfaStructure.UseCases.ProductUseCases
{
    public class AddProductUseCase : IAddProductUseCase
    {
        private readonly IProductService _productService;

        public AddProductUseCase(IProductService productService)
        {
            _productService = productService;
        }

        public async Task Execute(ProductDtoIn product)
        {
            await _productService.AddProduct(product);
        }
    }
}
