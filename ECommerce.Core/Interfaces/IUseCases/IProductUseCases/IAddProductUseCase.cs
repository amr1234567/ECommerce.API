using ECommerce.Core.DTO.ForDB;

namespace ECommerce.Core.Interfaces.IUseCases.IProductUseCases
{
    public interface IAddProductUseCase
    {
        Task Execute(ProductDtoIn product);
    }
}