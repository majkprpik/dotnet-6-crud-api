using WebApi.Entities.Common;

namespace WebApi.Entities.Venues
{
    public class VenueType : AuditableBaseEntity
    {
        public VenueType()
        {
            Venues = new List<Venue>();
        }
        public string Name { get; set; }

         public ICollection<Venue> Venues { get; set; }
    }
}
