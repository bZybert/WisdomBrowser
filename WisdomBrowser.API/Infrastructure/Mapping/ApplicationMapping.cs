using AutoMapper;
using WisdomBrowser.API.Application.DTO;
using WisdomBrowser.API.Domain;

namespace WisdomBrowser.API.Infrastructure.Mapping
{
    public class ApplicationMapping : Profile
    {
        public ApplicationMapping()
        {
            CreateMap<VideoFavouriteDto, Video>()
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.YouTubeID, opt => opt.MapFrom(src => src.YouTubeId))
                .ForMember(d => d.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForAllOtherMembers(d => d.Ignore());
        }
    }
}
