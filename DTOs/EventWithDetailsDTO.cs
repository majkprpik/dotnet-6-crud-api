using WebApi.Entities.Events;
using WebApi.Entities.Misc;
using WebApi.Entities.Venues;
using WebApi.Mappings;

namespace WebApi.DTOs
{
    public class EventWithDetailsDTO : IMapFrom<Event>
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public Venue Venue { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal? Price { get; set; }
        public short MaxAttendants { get; set; }
        public short MinAttendants { get; set; }
        public int CurrentNoAttendants { get; set; }
        // public int UserId { get; set; }
        public bool IsCanceled { get; set; }
        public Group Group { get; set; }
        public List<TagDTO> Tags { get; set; }

        public static void Mapping(MappingProfile profile)
        {
            profile.CreateMap<Event, EventWithDetailsDTO>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.EventName, opt => opt.MapFrom(s => s.EventName))
                .ForMember(d => d.Venue, opt => opt.MapFrom(s => s.Venue))
                .ForMember(d => d.StartTime, opt => opt.MapFrom(s => s.StartTime))
                .ForMember(d => d.EndTime, opt => opt.MapFrom(s => s.EndTime))
                .ForMember(d => d.Price, opt => opt.MapFrom(s => s.Price))
                .ForMember(d => d.MaxAttendants, opt => opt.MapFrom(s => s.MaxAttendants))
                .ForMember(d => d.MinAttendants, opt => opt.MapFrom(s => s.MinAttendants))
                .ForMember(d => d.CurrentNoAttendants, opt => opt.MapFrom(s => s.CurrentNoAttendants))
                .ForMember(d => d.IsCanceled, opt => opt.MapFrom(s => s.IsCanceled))
                .ForMember(d => d.Group, opt => opt.MapFrom(s => s.Group))
                .ForMember(d => d.Tags, opt => opt.MapFrom(s => s.Tags.Select(t => new TagDTO()
                {
                    Id = t.Id,
                    Name = t.Name
                }))); 
        }
    }
}