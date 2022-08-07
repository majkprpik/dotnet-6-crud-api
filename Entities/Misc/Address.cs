using WebApi.Entities.Common;
using WebApi.Entities.Venues;

namespace WebApi.Entities.Misc
{
    public class Address : AuditableBaseEntity
    {
        public Address() 
        {
            Venues = new List<Venue>();
        }

        public string Country { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string Street { get; set; }

        public string StreetNumber { get; set; }

         public ICollection<Venue> Venues { get; set; }
    }
}
