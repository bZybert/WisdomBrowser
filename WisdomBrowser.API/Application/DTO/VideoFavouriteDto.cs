using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WisdomBrowser.API.Application.DTO
{
    public class VideoFavouriteDto
    {
        public int UserId { get; set; }
        public string YouTubeId { get; set; }
        public string Name { get; set; }
    }
}
