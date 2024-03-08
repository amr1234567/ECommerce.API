using Azure;
using ECommerce.Core.Constants;
using ECommerce.Core.DTO.Account;
using ECommerce.Core.DTO.ForEndUser;
using ECommerce.Core.Entities.Identity;
using ECommerce.Core.Interfaces.IUseCases.ITokenUseCases;
using ECommerce.InfaStructure.UseCases.AccountUseCases;
using ECommerce.InfaStructure.UseCases.TokenUseCases;
using Ganss.Xss;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ECommerce.APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogInUseCase _logIn;
        private readonly IRegisterAsAdminUseCase _registerAsAdmin;
        private readonly IRegisterAsUserUseCase _registerAsUser;
        private readonly IRefreshTokenUseCase _refreshToken;

        public AccountController(ILogInUseCase logIn,
            IRegisterAsAdminUseCase registerAsAdmin,
            IRegisterAsUserUseCase registerAsUser,
            IRefreshTokenUseCase refreshToken)
        {
            _logIn = logIn;
            _registerAsAdmin = registerAsAdmin;
            _registerAsUser = registerAsUser;
            _refreshToken = refreshToken;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LogInReturn>> LogIn([FromBody] LogInDto logInUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _logIn.Execute(logInUser);
            SetRefreshTokenToCookie(response.RefreshToken, response.RefreshTokenExpiration);

            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<ActionResult<LogInReturn>> RegisterAsUser([FromBody] RegisterDto registerUser)
        {

            if (ModelState.IsValid)
            {
                var response = await _registerAsUser.Execute(registerUser);
                if (response)
                    return Ok("Account Registered Successfully");
                return BadRequest("Bad Request");
            }
            return BadRequest(ModelState);
        }

        [HttpPost("registeradmin")]
        public async Task<ActionResult<LogInReturn>> RegisterAsAdmin([FromBody] RegisterDto registerUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _registerAsAdmin.Execute(registerUser);
            if (response)
                return Ok("Account Registered Successfully");
            return BadRequest("Bad Request");
        }

        [HttpPost("refreshtoken")]
        public async Task<ActionResult<LogInReturn>> RefreshToken(string? refreshToken = null)
        {
            var token = refreshToken ?? Request.Cookies["RefreshTokent"];

            if (string.IsNullOrEmpty(token))
                return Unauthorized(new LogInReturn { Message = "Bad Token" });

            var response = await _refreshToken.Execute(token);

            if (!response.IsLoggedIn)
                return Ok(response);
            return BadRequest(response.Message);
        }

        private void SetRefreshTokenToCookie(string RefreshToken, DateTime ExpireOn)
        {
            var cookieOption = new CookieOptions
            {
                Expires = ExpireOn.ToLocalTime(),
                HttpOnly = true
            };

            Response.Cookies.Append("RefreshTokent", RefreshToken, cookieOption);
        }
    }
}
