using System.Collections.Generic;
using WisdomBrowser.API.Domain;

namespace WisdomBrowser.API.Application.DTO
{
    public class UserForDomainDto
    {
        public int Id { get; private set; }
        public string Login { get; private set; }
        public string Email { get; private set; }
        public string Stamp { get; private set; }
        private UserForDomainDto()
        {

        }
        public UserForDomainDto(string login, string email, string stamp, int id)
        {
            Id = id;
            Login = login;
            Email = email;
            Stamp = stamp;
        }
    }
}