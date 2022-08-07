using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Entities.Common;
using WebApi.Entities.Events;
using WebApi.Entities.Users;

namespace WebApi.Entities.Misc
{
    public class Group : AuditableBaseEntity
    {
        public Group() 
        {
            Users = new List<User>();
        }
        
        public int EventId { get; set; }
        public Event Event { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}