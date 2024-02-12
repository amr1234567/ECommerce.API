using ECommerce.Core.DTO.ForDB;

namespace ECommerce.Core.Interfaces.IUseCases.ICategoryUseCases
{
    public interface IAddCategoryUseCase
    {
        Task Excute(CategoryDtoIn category);
    }
}