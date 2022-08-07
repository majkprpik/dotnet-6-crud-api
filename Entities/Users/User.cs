namespace WebApi.Entities.Users;

using System.Text.Json.Serialization;
using WebApi.Entities.Events;
using WebApi.Entities.Misc;

public class User
{
    public User()
    {
        Tags = new List<Tag>();
        Groups = new List<Group>();
    }
    public int Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; }
    public virtual ICollection<Tag> Tags { get; set; }  
    public virtual ICollection<Group> Groups { get; set; }

    [JsonIgnore]
    public string PasswordHash { get; set; }
}