using Core.Interfaces;
using Infrastructure.Identity.Helpers;
using Infrastructure.Identity.Utils;
using Microsoft.Extensions.Options;

namespace API.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, ITokenService tokenService, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var email = jwtUtils.ValidateJwtToken(token);
            if (email != null)
            {
                context.Items["User"] = tokenService.GetByEmail(email);
            }

            await _next(context);
        }
    }
}
