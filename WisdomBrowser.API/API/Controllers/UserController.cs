using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WisdomBrowser.API.Application.DTO;
using WisdomBrowser.API.Domain.Interfaces;

namespace WisdomBrowser.API.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IVideoRepository _videosRepo;
        private IUserRepository _userRepository;
        private IFavouriteApplicationService _favouriteApplicationService;
        public UserController(IVideoRepository videoRepository, IUserRepository userRepository, IFavouriteApplicationService favouriteApplicationService)
        {
            _userRepository = userRepository;
            _videosRepo = videoRepository;
            _favouriteApplicationService = favouriteApplicationService;
        }
        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            return Ok("200");
        }


        [HttpPost("getuser")]
        public async Task<IActionResult> GetUser([FromHeader]int userId)
        {

            var user = await _userRepository.GetUser(userId);

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

        [HttpPost("addFavouriteVideo")]
        public async Task<IActionResult> AddFavouriteVideo([FromHeader]VideoFavouriteDto videoFavouriteDto)
        {
            if (videoFavouriteDto == null) return BadRequest("Problem with video data"); ;

            bool isAdded = await _favouriteApplicationService.AddNewFavouriteVideo(videoFavouriteDto);
            if (!isAdded)
                return BadRequest("AddFavouriteVideo return fail");
            else
            {
                return Ok(isAdded);
            }
        }
    }
}
