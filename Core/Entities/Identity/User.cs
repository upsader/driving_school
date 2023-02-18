using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace Core.Entities.Identity;
public class User : IdentityUser
{
    public Role Role { get; set; }
}
