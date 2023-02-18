using API.Helpers;
using API.Utils;
using Core.Interfaces;
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

        //public async Task Invoke(HttpContext context, ITokenService tokenService, IJwtUtils jwtUtils)
        //{
        //    var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        //    var userId = jwtUtils.ValidateJwtToken(token);
        //    if (userId != null)
        //    {
        //        // attach user to context on successful jwt validation
        //        context.Items["User"] = tokenService.GetById(userId.Value);
        //    }

        //    await _next(context);
        //}
    }
}
