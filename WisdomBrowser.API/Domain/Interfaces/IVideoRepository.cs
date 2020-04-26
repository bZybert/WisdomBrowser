using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WisdomBrowser.API.Domain.Interfaces
{
    public interface IVideoRepository
    {
        Task<List<Video>> GetUserVideos(int userId);
        Task<bool> AddNewVideo(Video video);
        Task<bool> RemoveVideo(int videoId);

    }
}
