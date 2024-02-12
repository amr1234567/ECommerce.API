using ECommerce.Core.DTO.ForDB;
using ECommerce.Core.DTO.ForEndUser;

namespace ECommerce.Core.Interfaces.IUseCases.IProductUseCases
{
    public interface IGetProductsByCategoryIdUseCase
    {
        Task<IEnumerable<ProductDtoOut>> Execute(Guid CategoryId);
    }
}