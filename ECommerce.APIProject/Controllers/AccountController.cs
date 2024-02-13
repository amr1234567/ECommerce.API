using ECommerce.Core.Constants;
using ECommerce.Core.DTO.Account;
using ECommerce.Core.DTO.ForEndUser;
using ECommerce.Core.Entities.Identity;
using ECommerce.Core.Interfaces.IUseCases.IAccountUseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<WebSiteUser> _userManager;
        private readonly ICreateTokenUseCase _createToken;

        public AccountController(UserManager<WebSiteUser> userManager,ICreateTokenUseCase createToken)
        {
            _userManager = userManager;
            _createToken = createToken;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LogInReturn>> LogIn([FromBody]LogInDto logInUser)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userManager.FindByEmailAsync(logInUser.Email);
            if (user == null)
                return BadRequest("Email Not Found");
            var check = await _userManager.CheckPasswordAsync(user, logInUser.Password);
            if (!check)
                return Unauthorized("Password or email wrong");

            var roles = await _userManager.GetRolesAsync(user);

            var token = _createToken.Execute(user, roles.ToList());

            return Ok(new LogInReturn
            {
                Email = user.Email,
                Token = token,
                UserName = user.UserName
            });
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsUser([FromBody] RegisterDto registerUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = await _userManager.FindByEmailAsync(registerUser.Email);
            if (user != null) 
                return BadRequest("Email Already Exist");
            var newUser = await _userManager.CreateAsync(registerUser.ConvertToUser(), registerUser.Password);

            if (!newUser.Succeeded)
                return BadRequest("Something went wrong, Please Try Again");

            var User = await _userManager.FindByEmailAsync(registerUser.Email);
            await _userManager.AddToRoleAsync(User, Roles.User);
            

            return Ok("U have been registered with email : " + registerUser.Email);
        }

        [HttpPost("registeradmin")]
        public async Task<ActionResult> RegisterAsAdmin([FromBody] RegisterDto registerUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = await _userManager.FindByEmailAsync(registerUser.Email);
            if (user != null)
                return BadRequest("Email Already Exist");
            var newUser = await _userManager.CreateAsync(registerUser.ConvertToUser(), registerUser.Password);

            if (!newUser.Succeeded)
                return BadRequest("Something went wrong, Please Try Again");

            var User = await _userManager.FindByEmailAsync(registerUser.Email);
            await _userManager.AddToRoleAsync(User, Roles.Admin);
            await _userManager.AddToRoleAsync(User, Roles.User);


            return Ok("U have been registered with email : " + registerUser.Email);
        }
    }
}
