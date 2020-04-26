using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WisdomBrowser.API.Domain;
using WisdomBrowser.API.Domain.Interfaces;
using WisdomBrowser.API.Infrastructure.EFCore;

namespace WisdomBrowser.API.Infrastructure.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        public EFContext _context { get; private set; }
        public VideoRepository(EFContext context)
        {
            _context = context;
        }

        public async Task<List<Video>> GetUserVideos(int userId)
        {
            List<Video> videoList = await _context.Videos.ToListAsync();
            List<Video> userVideos = videoList.FindAll(x => x.UserId == userId).ToList();
            return userVideos;
        }

        public async Task<bool> AddNewVideo(Video video)
        {
            _context.Videos.Add(video);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RemoveVideo(int videoId)
        {
            List<Video> videos = await _context.Videos.ToListAsync();
            Video videoToUpdate = videos.SingleOrDefault(x => x.Id == videoId);
            if (videoToUpdate == null)
                return false;
            else
            {
                videoToUpdate.SetVideoAsArchived();
                _context.Videos.Add(videoToUpdate);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}
