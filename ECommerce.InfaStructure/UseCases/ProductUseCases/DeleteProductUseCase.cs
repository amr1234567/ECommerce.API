using ECommerce.Core.Interfaces.IServices;
using ECommerce.Core.Interfaces.IUseCases.IProductUseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.InfaStructure.UseCases.ProductUseCases
{
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IProductService _productService;

        public DeleteProductUseCase(IProductService productService)
        {
            _productService = productService;
        }

        public async Task Execute(Guid Id)
        {
            await _productService.DeleteProduct(Id);
        }
    }
}
