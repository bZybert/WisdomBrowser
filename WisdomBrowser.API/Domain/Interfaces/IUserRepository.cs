using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WisdomBrowser.API.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUser(int userId);
    }
}
