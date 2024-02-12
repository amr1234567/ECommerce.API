using ECommerce.Core.DTO.ForDB;
using ECommerce.Core.DTO.ForEndUser;
using ECommerce.Core.Entities;

namespace ECommerce.Core.Interfaces.IUseCases.ICategoryUseCases
{
    public interface IGetCategoryByIdUseCase
    {
        Task<CategoryDtoOut> Execute(Guid Id);
    }
}