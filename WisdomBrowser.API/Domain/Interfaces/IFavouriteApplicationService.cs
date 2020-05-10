using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WisdomBrowser.API.Application.DTO;

namespace WisdomBrowser.API.Domain.Interfaces
{
    public interface IFavouriteApplicationService
    {
        Task<bool> AddNewFavouriteVideo(VideoFavouriteDto videoFavouriteDto);
        Task<bool> RemoveVideoFromFavourite(int videoId);
    }
}
