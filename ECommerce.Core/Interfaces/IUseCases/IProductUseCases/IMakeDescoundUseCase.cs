namespace ECommerce.Core.Interfaces.IUseCases.IProductUseCases
{
    public interface IMakeDescoundUseCase
    {
        Task Execute(Guid ProductId, double Discound);
    }
}