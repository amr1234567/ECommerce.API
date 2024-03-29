﻿using ECommerce.Core.Entities.Identity;
using ECommerce.Core.Interfaces.IServices;
using ECommerce.Core.Interfaces.IUseCases.ITokenUseCases;
using ECommerce.InfaStructure.Context;
using ECommerce.InfaStructure.Services;
using ECommerce.InfaStructure.UseCases.AccountUseCases;
using ECommerce.InfaStructure.UseCases.TokenUseCases;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;

namespace ECommerce.APIProject.Config
{
    public static class AccountDI
    {
        public static IServiceCollection AddAccountScopes(this IServiceCollection services)
        {
            //service
            services.AddScoped<IAccountService, AccountService>();

            //Use Cases
            services.AddScoped<ILogInUseCase, LogInUseCase>();
            services.AddScoped<IRegisterAsAdminUseCase, RegisterAsAdminUseCase>();
            services.AddScoped<IRegisterAsUserUseCase, RegisterAsUserUseCase>();

            return services;
        }
    }
}
