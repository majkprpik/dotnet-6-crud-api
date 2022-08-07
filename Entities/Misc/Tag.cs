using WebApi.Entities.Common;
using WebApi.Entities.Events;
using WebApi.Entities.Players;
using WebApi.Entities.Users;

namespace WebApi.Entities.Misc
{
    public class Tag : AuditableBaseEntity
    {
        public Tag() 
        {
            Events = new List<Event>();
            Users = new List<User>();
        }

        public string Name { get; set; }        
        public virtual ICollection<Event> Events { get; set; }        
        public virtual ICollection<User> Users { get; set; }    
    }
}