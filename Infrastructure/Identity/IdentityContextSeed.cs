using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class IdentityContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var admin = new User()
                {
                    UserName = "admin",
                    Email = "admin@gmail.com",
                    Role = Role.Admin

                };

                var teacher = new User()
                {
                    UserName = "teacher",
                    Email = "teacher@gmail.com",
                    Role = Role.Teacher
                };

                await userManager.CreateAsync(admin, "Pa$$w0rd");
                await userManager.CreateAsync(teacher, "Pa$$w0rd");
            }
        }
    }
}
