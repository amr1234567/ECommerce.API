using ECommerce.Core.DTO.ForDB;
using ECommerce.Core.DTO.ForEndUser;

namespace ECommerce.Core.Interfaces.IUseCases.IProductUseCases
{
    public interface IGetProductsUseCase
    {
        Task<IEnumerable<ProductDtoOut>> Execute();
    }
}