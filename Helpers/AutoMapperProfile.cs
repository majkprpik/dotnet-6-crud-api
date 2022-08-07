namespace WebApi.Helpers;

using AutoMapper;
using WebApi.DTOs;
using WebApi.Entities.Events;
using WebApi.Entities.Misc;
using WebApi.Entities.Users;
using WebApi.Models.Users;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // CreateRequest -> User
        CreateMap<CreateRequest, User>();

        // UpdateRequest -> User
        CreateMap<UpdateRequest, User>()
            .ForAllMembers(x => x.Condition(
                (src, dest, prop) =>
                {
                    // ignore both null & empty string properties
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                    // ignore null role
                    if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

                    return true;
                }
            ));

        CreateMap<Event, EventWithDetailsDTO>()
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

        CreateMap<Event, EventForUserDTO>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.EventName, opt => opt.MapFrom(s => s.EventName))
                .ForMember(d => d.Venue, opt => opt.MapFrom(s => s.Venue))
                .ForMember(d => d.StartTime, opt => opt.MapFrom(s => s.StartTime));

        // CreateMap<Tag, TagDTO>()
        //         .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
        //         .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name));
    }
}