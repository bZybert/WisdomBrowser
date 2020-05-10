using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WisdomBrowser.API.Application.DTO;
using WisdomBrowser.API.Domain;
using WisdomBrowser.API.Domain.Interfaces;
using WisdomBrowser.API.Infrastructure.EFCore;

namespace WisdomBrowser.API.Application.Services
{
    public class FavouriteApplicationService : IFavouriteApplicationService
    {
        public EFContext _context { get; private set; }
        public FavouriteApplicationService(EFContext context)
        {
            _context = context;
        }


        public async Task<bool> AddNewFavouriteVideo(VideoFavouriteDto videoFavouriteDto)
        {
            Video video = new Video(videoFavouriteDto.Name, videoFavouriteDto.YouTubeId, videoFavouriteDto.UserId);            
            _context.Videos.Add(video);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RemoveVideoFromFavourite(int videoId)
        {
            List<Video> videos = await _context.Videos.ToListAsync();
            Video videoToDelete = videos.SingleOrDefault(x => x.Id == videoId);
            if (videoToDelete == null)
                return false;
            else
            {
                _context.Videos.Remove(videoToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}
