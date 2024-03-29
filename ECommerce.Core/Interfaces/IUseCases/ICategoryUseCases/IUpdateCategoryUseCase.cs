﻿using ECommerce.Core.DTO.ForDB;

namespace ECommerce.Core.Interfaces.IUseCases.ICategoryUseCases
{
    public interface IUpdateCategoryUseCase
    {
        Task Execute(CategoryDtoForUpdate category, Guid CategoryId);
    }
}