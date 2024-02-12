using ECommerce.Core.DTO.ForDB;
using ECommerce.Core.DTO.ForEndUser;
using ECommerce.Core.Entities;
using ECommerce.Core.Interfaces.IServices;
using ECommerce.Core.Interfaces.IUseCases.IProductUseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.InfaStructure.UseCases.ProductUseCases
{
    public class GetProductsByCategoryIdUseCase : IGetProductsByCategoryIdUseCase
    {
        private readonly IProductService _productService;

        public GetProductsByCategoryIdUseCase(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IEnumerable<ProductDtoOut>> Execute(Guid CategoryId)
        {
            return await _productService.GetProductsByCategoryId(CategoryId);
        }
    }
}
