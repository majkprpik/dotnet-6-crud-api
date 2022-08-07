using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities.Events;
using WebApi.Entities.Misc;
using WebApi.Entities.Venues;
using WebApi.Mappings;

namespace WebApi.DTOs
{
    public class EventForUserDTO : IMapFrom<Event>
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public Venue Venue { get; set; }
        public DateTime StartTime { get; set; }
        // public DateTime? EndTime { get; set; }
        // public decimal? Price { get; set; }
        // public short MaxAttendants { get; set; }
        // public short MinAttendants { get; set; }
        // public int CurrentNoAttendants { get; set; }
        // public int UserId { get; set; }
        // public bool IsCanceled { get; set; }
        // public Group Group { get; set;}
        // public ICollection<Tag> Tags { get; set; }

        public static void Mapping(MappingProfile profile)
        {
            profile.CreateMap<Event, EventForUserDTO>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.EventName, opt => opt.MapFrom(s => s.EventName))
                .ForMember(d => d.Venue, opt => opt.MapFrom(s => s.Venue))
                .ForMember(d => d.StartTime, opt => opt.MapFrom(s => s.StartTime));
        }
    }
}