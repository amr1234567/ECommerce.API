using ECommerce.Core.Constants;
using ECommerce.Core.DTO.Account;
using ECommerce.Core.DTO.ForEndUser;
using ECommerce.Core.Entities.Identity;
using ECommerce.Core.Interfaces.IUseCases.IAccountUseCases;
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
        private readonly UserManager<WebSiteUser> _userManager;
        private readonly ICreateTokenUseCase _createToken;
        private readonly ICreateRefreshTokenUseCase _createRefreshToken;

        public AccountController(UserManager<WebSiteUser> userManager,
            ICreateTokenUseCase createToken,
            ICreateRefreshTokenUseCase createRefreshToken)
        {
            _userManager = userManager;
            _createToken = createToken;
            _createRefreshToken = createRefreshToken;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LogInReturn>> LogIn([FromBody] LogInDto logInUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(new HtmlSanitizer().Sanitize(logInUser.Email));
            if (user == null)
                return BadRequest("Email Not Found");
            var check = await _userManager.CheckPasswordAsync(user, logInUser.Password);
            if (!check)
                return Unauthorized("Password or email wrong");

            var roles = await _userManager.GetRolesAsync(user);
            var response = new LogInReturn
            {
                Email = user.Email,
                UserName = user.UserName
            };
            var token = await _createToken.Execute(user, [.. roles]);
            var refreshToken = new RefreshToken();
            if (user.RefreshTokens.Any(r => r.IsActive))
            {
                refreshToken = user.RefreshTokens.FirstOrDefault(r => r.IsActive);
                response.RefreshToken = refreshToken.Token;
                response.RefreshTokenExpiration = refreshToken.ExpiredOn;
            }
            else
            {
                refreshToken = _createRefreshToken.Execute();
                response.RefreshToken = refreshToken.Token;
                response.RefreshTokenExpiration = refreshToken.ExpiredOn;
                user.RefreshTokens.Add(refreshToken);
                await _userManager.UpdateAsync(user);
            }
            response.Token = token.Token;
            response.TokenExpiration = token.ExpiredOn;
            SetRefreshTokenToCookie(refreshToken.Token, refreshToken.ExpiredOn);
            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsUser([FromBody] RegisterDto registerUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = await _userManager.FindByEmailAsync(new HtmlSanitizer().Sanitize(registerUser.Email));
            if (user != null)
                return BadRequest("Email Already Exist");
            var newUser = await _userManager.CreateAsync(registerUser.ConvertToUser(), registerUser.Password);

            if (!newUser.Succeeded)
                return BadRequest("Something went wrong, Please Try Again");

            var User = await _userManager.FindByEmailAsync(user.Email);
            await _userManager.AddToRoleAsync(User, Roles.User);


            return Ok("U have been registered with email : " + User.Email);
        }

        [HttpPost("registeradmin")]
        public async Task<ActionResult> RegisterAsAdmin([FromBody] RegisterDto registerUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = await _userManager.FindByEmailAsync(new HtmlSanitizer().Sanitize(registerUser.Email));
            if (user != null)
                return BadRequest("Email Already Exist");
            var newUser = await _userManager.CreateAsync(registerUser.ConvertToUser(), registerUser.Password);

            if (!newUser.Succeeded)
                return BadRequest("Something went wrong, Please Try Again");

            var User = await _userManager.FindByEmailAsync(new HtmlSanitizer().Sanitize(registerUser.Email));
            await _userManager.AddToRoleAsync(User, Roles.Admin);
            await _userManager.AddToRoleAsync(User, Roles.User);


            return Ok("U have been registered with email : " + registerUser.Email);
        }

        private void SetRefreshTokenToCookie(string RefreshToken, DateTime ExpireOn)
        {
            Response.Cookies.Append(nameof(RefreshToken), RefreshToken, new CookieOptions
            {
                Expires = ExpireOn.ToLocalTime(),
                HttpOnly = true
            });
        }
    }
}
