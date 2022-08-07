using WebApi.Entities.Common;

namespace WebApi.Entities.Misc
{
    public class Activity : AuditableBaseEntity
    {
        public string Name { get; set; }
        public ActivityType ActivityType { get; set; }
    }
}
