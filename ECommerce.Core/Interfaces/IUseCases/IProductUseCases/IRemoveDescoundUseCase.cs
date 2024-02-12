namespace ECommerce.Core.Interfaces.IUseCases.IProductUseCases
{
    public interface IRemoveDescoundUseCase
    {
        Task Execute(Guid ProductId);
    }
}