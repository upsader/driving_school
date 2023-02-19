using Core.Entities.Identity;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Identity;
using Infrastructure.Identity.Helpers;
using Infrastructure.Identity.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtUtils _jwtUtils;
        private readonly IOptions<AppSettings> _appSettings;

        public TokenService(UserManager<User> userManager, IJwtUtils jwtUtils, IOptions<AppSettings> appSettings)
        {
            _userManager = userManager;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings;
        }

        public string CreateToken(User user)
        {
            return _jwtUtils.GenerateJwtToken(user);
        }

        public User GetByEmail(string email)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Email == email);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }
    }
}
