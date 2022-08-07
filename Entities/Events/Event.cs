using WebApi.Entities.Common;
using WebApi.Entities.Players;
using System;
using WebApi.Entities.Misc;
using WebApi.Entities.Users;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Entities.Venues;

namespace WebApi.Entities.Events
{
    public class Event : AuditableBaseEntity
    {
        public Event() 
        {
            Tags = new List<Tag>();
        }
        public string EventName { get; set; }
        public bool IsPromoted { get; set; }
        public bool InformationOnly { get; set; }
        public Venue Venue { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal? Price { get; set; }
        public short MaxAttendants { get; set; }
        public short MinAttendants { get; set; }
        public int CurrentNoAttendants { get; set; }
        // public User Admin { get; set; }
        public bool IsCanceled { get; set; }
        public Group Group { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}