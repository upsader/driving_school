using Core.Entities.Identity;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Identity;
using Infrastructure.Identity.Helpers;
using Infrastructure.Identity.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IdentityContext _context;
        private readonly IJwtUtils _jwtUtils;
        private readonly IOptions<AppSettings> _appSettings;

        public TokenService(IdentityContext context, IJwtUtils jwtUtils, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings;
        }

        public string CreateToken(User user)
        {
            return _jwtUtils.GenerateJwtToken(user);
        }

        public User GetByEmail(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }
    }
}
