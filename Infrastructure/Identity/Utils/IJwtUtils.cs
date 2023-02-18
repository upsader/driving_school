using Core.Entities.Identity;

namespace Infrastructure.Identity.Utils
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User user);
        public string? ValidateJwtToken(string token);
    }
}
