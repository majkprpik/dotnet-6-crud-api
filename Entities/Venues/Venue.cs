using WebApi.Entities.Common;
using WebApi.Entities.Events;
using WebApi.Entities.Misc;

namespace WebApi.Entities.Venues
{
    public class Venue : AuditableBaseEntity
    {
        public Venue()
        {
            Events = new List<Event>();
        }
        public string Name { get; set; }
        public VenueType VenueType { get; set; }
        public Address Address { get; set; }
        public string TelephoneNumber { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}