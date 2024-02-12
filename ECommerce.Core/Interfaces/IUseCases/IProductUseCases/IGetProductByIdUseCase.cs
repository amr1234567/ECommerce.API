using ECommerce.Core.DTO.ForDB;
using ECommerce.Core.DTO.ForEndUser;

namespace ECommerce.Core.Interfaces.IUseCases.IProductUseCases
{
    public interface IGetProductByIdUseCase
    {
        Task<ProductDtoOut> Execute(Guid Id);
    }
}