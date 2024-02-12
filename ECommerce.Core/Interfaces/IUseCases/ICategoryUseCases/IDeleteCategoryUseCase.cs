namespace ECommerce.Core.Interfaces.IUseCases.ICategoryUseCases
{
    public interface IDeleteCategoryUseCase
    {
        Task Execute(Guid Id);
    }
}