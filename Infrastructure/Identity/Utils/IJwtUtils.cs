using Core.Entities.Identity;

namespace API.Utils
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User user);
        public int? ValidateJwtToken(string token);
    }
}
