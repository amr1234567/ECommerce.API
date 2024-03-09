namespace ECommerce.Core.Interfaces.IUseCases.IProductUseCases
{
    public interface IRemoveDiscountUseCase
    {
        Task Execute(Guid ProductId);
    }
}