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
    public class GetProductsByFiltersUseCase : IGetProductsByFiltersUseCase
    {
        private readonly IProductService _productService;

        public GetProductsByFiltersUseCase(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IEnumerable<ProductDtoOut>> Execute(params Func<Product, bool>[] filters)
        {
            return await _productService.GetProductsByFilters(filters);
        }
    }
}
