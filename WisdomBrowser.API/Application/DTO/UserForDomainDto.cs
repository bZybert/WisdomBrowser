using System.Collections.Generic;
using WisdomBrowser.API.Domain;

namespace WisdomBrowser.API.Application.DTO
{
    public class UserForDomainDto
    {
        public string Login { get; private set; }
        public string Email { get; private set; }
        public string Stamp { get; private set; }
        public IEnumerable<Video> Videos {get; private set;}

        public UserForDomainDto(string login, string Email, string stamp, IEnumerable<Video> videos)
        {
            
        }
    }
}