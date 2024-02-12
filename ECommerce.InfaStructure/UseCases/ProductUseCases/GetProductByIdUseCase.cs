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
    public class GetProductByIdUseCase : IGetProductByIdUseCase
    {
        private readonly IProductService _productService;

        public GetProductByIdUseCase(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ProductDtoOut> Execute(Guid Id)
        {
            return await _productService.GetProductById(Id);
        }
    }
}
