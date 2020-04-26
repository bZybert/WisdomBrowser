using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WisdomBrowser.API.Domain;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WisdomBrowser.API.Infrastructure.EFCore
{
    public class EFContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            //builder.Entity<User>()
            //.FindNavigation(nameof(User.Videos))
            //.SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        public DbSet<Video> Videos { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        //{
        //    string cs = @"Data Source=USS-Enterprise\SQLEXPRESS;Initial Catalog=webApp;Integrated Security=True";
        //    dbContextOptionsBuilder.UseSqlServer(cs, "connectionString");
        //}
       // public DbSet<User> UserList { get; set; }
    }
}
