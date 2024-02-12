namespace ECommerce.Core.Interfaces.IUseCases.IProductUseCases
{
    public interface IMakeDescoundUseCase
    {
        void Execute(Guid ProductId, double Discound);
    }
}