using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net;
using WisdomBrowser.API.Domain;
using WisdomBrowser.API.Domain.Interfaces;
using WisdomBrowser.API.Infrastructure.EFCore;
using WisdomBrowser.API.Infrastructure.Helpers;
using WisdomBrowser.API.Infrastructure.Repositories;
//using Microsoft.Extensions.Hosting;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.IdentityModel.Tokens;

namespace WisdomBrowser.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EFContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<User, IdentityRole<int>>()
            .AddEntityFrameworkStores<EFContext>()
                .AddDefaultTokenProviders();
            //services.AddIdentityServer()
            //    .AddDeveloperSigningCredential()
            //    .AddInMemoryIdentityResources(Config.GetIdentityResources())
            //    .AddInMemoryApiResources(Config.GetApiResources())
            //    .AddInMemoryClients(Config.GetClients(Configuration.GetSection("HostSettings:WebAppClientUrl").Value.ToString()))
            //    .AddAspNetIdentity<ApplicationUser>();
            services.AddTransient<IAuthRepository, AuthRepository>();  
            services.AddControllers().AddNewtonsoftJson();
            services.AddCors();
            services.AddTransient<IVideoRepository, VideoRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // global exception handler, snippet from google
                app.UseExceptionHandler(builder =>
               {
                   builder.Run(async context =>
                   {
                       context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                       IExceptionHandlerFeature error = context.Features.Get<IExceptionHandlerFeature>();
                       if(error != null)
                       {
                           context.Response.AddAplicationError(error.Error.Message);
                           await context.Response.WriteAsync(error.Error.Message);
                       }
                   });
               });
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
