using Core.Entities.Identity;

namespace Infrastructure.Identity.Utils
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User user);
        public int? ValidateJwtToken(string token);
    }
}
