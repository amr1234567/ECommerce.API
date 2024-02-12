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
    public class UpdateProductUseCase : IUpdateProductUseCase
    {
        private readonly IProductService _productService;

        public UpdateProductUseCase(IProductService productService)
        {
            _productService = productService;
        }

        public async Task Execute(ProductDtoForUpdate product, Guid Id)
        {
            await _productService.UpdateProductDetails(product, Id);
        }
    }
}
