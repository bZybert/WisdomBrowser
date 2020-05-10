using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WisdomBrowser.API.Application.DTO;
using WisdomBrowser.API.Domain.Interfaces;

namespace WisdomBrowser.API.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private IAuthRepository _authRepository { get; }
        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpGet("home")]
        public async Task<IActionResult> Home()
        {
            return Ok("OK");
        }
        [HttpGet("register")]
        public async Task<IActionResult> Register()
        {
            //var user = await _authRepository.Register(userForRegisterDto);
            return Ok("register form");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto userForRegisterDto)
        {
            bool isExist = await _authRepository.UserExist(userForRegisterDto.Login);
            if (isExist)
                return BadRequest("User already exist");
            else
            {
                var user = await _authRepository.Register(userForRegisterDto);
                if (user == null)
                    return BadRequest("Valid user registration");
                else
                    return Ok("User registered");
            }
        }

        [HttpGet("login")]
        public async Task<IActionResult> Login()
        {
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _authRepository.Login(userForLoginDto);
                if (user == null)
                    return Ok("User doesn't exist");
                else
                {
                    UserForDomainDto userForDomain = new UserForDomainDto(user.UserName, user.Email, user.ConcurrencyStamp, user.Id);
                    return Ok(userForDomain);
                }
            }
            else return null;
        }
    }
}