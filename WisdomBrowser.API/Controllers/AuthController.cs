using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WisdomBrowser.API.Application.DTO;
using WisdomBrowser.API.Domain;
using WisdomBrowser.API.Domain.Interfaces;
using WisdomBrowser.API.Infrastructure.EFCore;

namespace WisdomBrowser.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private EFContext _context { get; }
        private IAuthRepository _authRepository { get; }
        public AuthController(EFContext context, IAuthRepository authRepository)
        {
            _context = context;
            _authRepository = authRepository;
        }

        [HttpGet("home")]
        public async Task<IActionResult> Home()
        {
            Course course = new Course();
            course.Title = "DIY";
            
            return Ok(course);
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
            if (ModelState.IsValid)
            {
                var user = await _authRepository.Register(userForRegisterDto);
                if (user == null)
                    return BadRequest("Valid user registration");
                else
                    return Ok("201");
            }
            else return null;
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
                    return Ok(user);
                }
            }
            else return null;
        }
    }
}