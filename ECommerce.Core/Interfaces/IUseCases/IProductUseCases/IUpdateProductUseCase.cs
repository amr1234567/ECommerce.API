using ECommerce.Core.DTO.ForDB;

namespace ECommerce.Core.Interfaces.IUseCases.IProductUseCases
{
    public interface IUpdateProductUseCase
    {
        Task Execute(ProductDtoIn product, Guid Id);
    }
}