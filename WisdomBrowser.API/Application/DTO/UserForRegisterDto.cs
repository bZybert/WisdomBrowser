using System.ComponentModel.DataAnnotations;

namespace WisdomBrowser.API.Application.DTO
{
    public class UserForRegisterDto
    {
        [Required]
        public string Login { get; private set; }
        [Required]
        [StringLength(10, MinimumLength = 8, ErrorMessage = "Password lenght must be between 8 to 10 characters")]
        public string Password { get; private set; }
        [EmailAddress]
        public string Email { get; private set; }
        public UserForRegisterDto(string login, string password, string email)
        {
            Login = login;
            Password = password;
            Email = email;
        }
        private UserForRegisterDto()
        {

        }
    }
}