using System.Text.Json.Serialization;

namespace Core.Entities;
public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int YearOfBirth { get; set; }
    public string EmailAddress { get; set; }
    public string MobilePhone { get; set; }
    public DateTime RegistrationDate { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string? TrainingCategory { get; set; }
    public string? Mark { get; set; }

    public Role Role { get; set; }

    [JsonIgnore]
    public string PasswordHash { get; set; }
}
