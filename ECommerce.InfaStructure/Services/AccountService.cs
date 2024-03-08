using ECommerce.Core.Constants;
using ECommerce.Core.DTO.Account;
using ECommerce.Core.DTO.ForEndUser;
using ECommerce.Core.Entities.Identity;
using ECommerce.Core.Helpers;
using ECommerce.Core.Interfaces.IServices;
using ECommerce.Core.Interfaces.IUseCases.ITokenUseCases;
using Ganss.Xss;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.InfaStructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<WebSiteUser> _userManager;
        private readonly ICreateTokenUseCase _createToken;
        private readonly ICreateRefreshTokenUseCase _createRefreshToken;

        public AccountService(UserManager<WebSiteUser> userManager,
            ICreateTokenUseCase createToken,
            ICreateRefreshTokenUseCase createRefreshToken)
        {
            _userManager = userManager;
            _createToken = createToken;
            _createRefreshToken = createRefreshToken;
        }

        public async Task<LogInReturn> LogIn(LogInDto logInUser)
        {
            var user = await _userManager.FindByEmailAsync(new HtmlSanitizer().Sanitize(logInUser.Email));
            if (user == null)
                return new LogInReturn { Message = "Email Not Found" };

            var check = await _userManager.CheckPasswordAsync(user, logInUser.Password);
            if (!check)
                return new LogInReturn { Message = "Password or email wrong" };

            var roles = await _userManager.GetRolesAsync(user);
            var response = new LogInReturn
            {
                Email = user.Email,
                UserName = user.UserName
            };

            var token = await _createToken.Execute(user, [.. roles]);
            response.Token = token.Token;
            response.TokenExpiration = token.ExpiredOn;
            response.IsLoggedIn = true;

            user.SetRefreshTokenInLogIn(ref response, _createRefreshToken);

            await _userManager.UpdateAsync(user);
            return response;
        }


        public async Task<bool> RegisterAsUser(RegisterDto registerUser)
        {
            var user = await _userManager.FindByEmailAsync(new HtmlSanitizer().Sanitize(registerUser.Email));
            if (user != null)
                return false;

            var newUser = await _userManager.CreateAsync(registerUser.ConvertToUser(), registerUser.Password);

            if (!newUser.Succeeded)
                return false;

            var User = await _userManager.FindByEmailAsync(registerUser.Email);
            await _userManager.AddToRoleAsync(User, Roles.User);

            return true;
        }

        public async Task<bool> RegisterAsAdmin(RegisterDto registerUser)
        {
            var response = await RegisterAsUser(registerUser);
            if (!response)
                return false;

            var user = await _userManager.FindByEmailAsync(new HtmlSanitizer().Sanitize(registerUser.Email));
            await _userManager.AddToRoleAsync(user, Roles.Admin);

            return true;
        }
    }
}
