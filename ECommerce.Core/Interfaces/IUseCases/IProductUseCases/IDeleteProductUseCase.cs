namespace ECommerce.Core.Interfaces.IUseCases.IProductUseCases
{
    public interface IDeleteProductUseCase
    {
        Task Execute(Guid Id);
    }
}