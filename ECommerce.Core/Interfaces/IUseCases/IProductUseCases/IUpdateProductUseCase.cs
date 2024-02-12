using ECommerce.Core.DTO.ForDB;

namespace ECommerce.Core.Interfaces.IUseCases.IProductUseCases
{
    public interface IUpdateProductUseCase
    {
        Task Execute(ProductDtoForUpdate product, Guid Id);
    }
}