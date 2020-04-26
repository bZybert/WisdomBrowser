using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WisdomBrowser.API.Application.DTO;
using WisdomBrowser.API.Domain.Interfaces;
using WisdomBrowser.API.Infrastructure.EFCore;
using WisdomBrowser.API.Infrastructure.Repositories;

namespace WisdomBrowser.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IVideoRepository _videosRepo;
        private EFContext _context;
        public UserController(IVideoRepository videoRepository, EFContext context)
        {
            _videosRepo = videoRepository;
            _context = context;
        }
        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            return Ok("200");
        }


        [HttpPost("getuser")]
        public async Task<IActionResult> GetUser([FromHeader]int userId)
        {

            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == userId);

            if (user == null)
                return BadRequest("User doesnt exist");
            else
            {
                UserForDomainDto userForDomain = new UserForDomainDto(user.UserName, user.Email, user.ConcurrencyStamp, user.Id);

                return Ok(userForDomain);
            }
        }

        [HttpPost("videos")]
        public async Task<IActionResult> GetVideos([FromHeader]string userId)
        {
            int id = int.Parse(userId);
            List<Domain.Video> videos = await _videosRepo.GetUserVideos(id);
            if (videos == null)
                return BadRequest("User doesnt exist");
            else
            {
                return Ok(videos);
            }
        }
    }
}
