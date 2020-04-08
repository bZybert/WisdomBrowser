using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WisdomBrowser.API.Application.DTO;
using WisdomBrowser.API.Domain;
using WisdomBrowser.API.Domain.Interfaces;
using WisdomBrowser.API.Infrastructure.EFCore;

namespace WisdomBrowser.API.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        protected UserManager<User> UserManager { get; }
        protected SignInManager<User> SignInManager { get; }
        private EFContext _context { get; }
        public AuthRepository(UserManager<User> userManager, SignInManager<User> signInManager, EFContext context)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            _context = context;
        }
        public async Task<UserForRegisterDto> Register(UserForRegisterDto userForRegisterDto)
        {
            var user = new User(userForRegisterDto.Login) { Email = userForRegisterDto.Email };
            if (user == null) return null;
            var result = await UserManager.CreateAsync(user, userForRegisterDto.Password);
            if (!result.Succeeded)
                return null;
            else
                return userForRegisterDto;
        }
        public async Task<bool> UserExist(string userName)
        {
            bool isExist = await _context.Users.AnyAsync(x => x.UserName == userName);
            return isExist;
        }
        public async Task<User> Login(UserForLoginDto userForLoginDto)
        {
            SignInResult result = await SignInManager.PasswordSignInAsync(userForLoginDto.Login,
            userForLoginDto.Password, userForLoginDto.RememberMe, false);
            if (!result.Succeeded) return null;
            else
            {
                User user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == userForLoginDto.Login);

                return user;
            }
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                byte[] computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }

            return true;
        }
    }
}