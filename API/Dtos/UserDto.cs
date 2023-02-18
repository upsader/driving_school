using Core.Entities.Identity;
using System.Data;

namespace API.Dtos
{
    public class UserDto
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public Role Role { get; set; }
        public UserDto(User user, string token)
        {
            Email = user.Email;
            Username = user.UserName;
            Role = user.Role;
            Token = token;
        }
        
    }
}
