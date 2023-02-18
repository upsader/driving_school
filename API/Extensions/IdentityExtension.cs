namespace API.Extensions
{
    using Core.Entities.Identity;
    using Infrastructure.Identity;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public static class IdentityExtension
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<IdentityContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("IdentityConnection"));
            });

            services.AddIdentityCore<User>(opt =>
            {

            })
            .AddEntityFrameworkStores<IdentityContext>()
            .AddSignInManager<SignInManager<User>>();

            services.AddAuthentication();
            services.AddAuthorization();

            return services;
        }
    }
}
