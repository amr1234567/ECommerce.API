namespace ECommerce.Core.Interfaces.IUseCases.IProductUseCases
{
    public interface IMakeDiscountUseCase
    {
        Task Execute(Guid ProductId, double Discound);
    }
}