using API.Helpers;
using API.Utils;
using Core.Entities.Identity;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IJwtUtils _jwtUtils;
        private readonly IOptions<AppSettings> _appSettings;

        public TokenService(DataContext context, IJwtUtils jwtUtils, IOptions<AppSettings> appSettings)
        {
            _jwtUtils = jwtUtils;
            _appSettings = appSettings;
        }

        public string CreateToken(User user)
        {
            return _jwtUtils.GenerateJwtToken(user);
        }
    }
}
