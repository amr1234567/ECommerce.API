using ECommerce.Core.DTO.ForDB;
using ECommerce.Core.DTO.ForEndUser;
using ECommerce.Core.Entities;

namespace ECommerce.Core.Interfaces.IUseCases.IProductUseCases
{
    public interface IGetProductsByFiltersUseCase
    {
        Task<IEnumerable<ProductDtoOut>> Execute(params Func<Product, bool>[] filters);
    }
}