using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WisdomBrowser.API.Application.DTO
{
    public class UserForLoginDto
    {
        [Required]
        public string Login { get; private set; }
        [Required]
        [StringLength(10, MinimumLength = 8, ErrorMessage = "Password lenght must be between 8 to 10 characters")]
        public string Password { get; private set; }
        public bool RememberMe { get; set; }
        private UserForLoginDto()
        {

        }
        public UserForLoginDto(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
