using System.Threading.Tasks;
using WisdomBrowser.API.Application.DTO;

namespace WisdomBrowser.API.Domain.Interfaces
{
    public interface IAuthRepository
    {
         Task<UserForRegisterDto> Register(UserForRegisterDto userForRegisterDto);
         Task<User> Login(UserForLoginDto userForLoginDto);
         Task<bool> UserExist(string UserExist);
    }
}