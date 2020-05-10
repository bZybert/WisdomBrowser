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
    public class UserRepository : IUserRepository
    {
        private EFContext _context { get; }
        public UserRepository(EFContext context)
        {
            _context = context;
        }

        public async Task<User> GetUser(int userId)
        {
            User user = await _context.Users.SingleOrDefaultAsync(x => x.Id == userId);
            return user;
        }
    }
}
