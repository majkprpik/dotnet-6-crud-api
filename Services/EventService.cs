namespace WebApi.Services;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using WebApi.DTOs;
using WebApi.Entities.Events;
using WebApi.Entities.Misc;
using WebApi.Entities.Users;
using WebApi.Helpers;
using WebApi.Models.Users;

public interface IEventService
{
    IEnumerable<EventWithDetailsDTO> GetAll();
    Task<IEnumerable<EventForUserDTO>> GetAllForUser(int userId);
    Task<IEnumerable<EventWithDetailsDTO>> GetAllForTags(IEnumerable<int> tagIds);
    Task<IEnumerable<EventWithDetailsDTO>> GetAllForUserTags(int userId);
    Event GetById(int id);
    void Create(CreateRequest model);
    void Update(int id, UpdateRequest model);
    void Delete(int id);
    Task<bool> JoinEvent(int userId, int eventId);
    Task<bool> DropFromEvent(int userId, int eventId);
}

public class EventService : IEventService
{
    private DataContext _context;
    private readonly IMapper _mapper;

    public EventService(
        DataContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<EventWithDetailsDTO> GetAll()
    {
        return new List<EventWithDetailsDTO>();
    }

    public async Task<IEnumerable<EventForUserDTO>> GetAllForUser(int userId)
    {
        List<EventForUserDTO> events = await _context.Events
            .Include(x => x.Group.Users)
            .Include(x => x.Venue)
            .Where(x => x.Group.Users.Any(x => x.Id == userId))
            .ProjectTo<EventForUserDTO>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return events;
    }

    public async Task<IEnumerable<EventWithDetailsDTO>> GetAllForTags(IEnumerable<int> tagIds)
    {
        List<EventWithDetailsDTO> events = await _context.Events
            .Include(e => e.Tags)
            .Where(e => e.Tags.Any(t => tagIds.Contains(t.Id)))
            .ProjectTo<EventWithDetailsDTO>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return events;
    }

    public async Task<IEnumerable<EventWithDetailsDTO>> GetAllForUserTags(int userId)
    {
        User user = await _context.Users
            .Include(u => u.Tags)
            .Where(u => u.Id == userId)
            .FirstOrDefaultAsync();

        if (user == null) throw new KeyNotFoundException("User not found");
        if (user.Tags.Count == 0) throw new KeyNotFoundException("User does not have any tags");

        var tagIds = user?.Tags
                    .Select(t => t.Id)
                    .ToList();

        List<EventWithDetailsDTO> events = await _context.Events
            .Include(e => e.Tags)
            .Where(e => e.Tags.Any(t => tagIds.Contains(t.Id)))
            .ProjectTo<EventWithDetailsDTO>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return events;

    }


    public Event GetById(int id)
    {
        return getEvent(id);
    }

    public void Create(CreateRequest model)
    {
        // // validate
        // if (_context.Users.Any(x => x.Email == model.Email))
        //     throw new AppException("User with the email '" + model.Email + "' already exists");

        // // map model to new user object
        // var user = _mapper.Map<User>(model);

        // // hash password
        // user.PasswordHash = BCrypt.HashPassword(model.Password);

        // // save user
        // _context.Users.Add(user);
        // _context.SaveChanges();
    }

    public void Update(int id, UpdateRequest model)
    {
        // var user = getUser(id);

        // // validate
        // if (model.Email != user.Email && _context.Users.Any(x => x.Email == model.Email))
        //     throw new AppException("User with the email '" + model.Email + "' already exists");

        // // hash password if it was entered
        // if (!string.IsNullOrEmpty(model.Password))
        //     user.PasswordHash = BCrypt.HashPassword(model.Password);

        // // copy model to user and save
        // _mapper.Map(model, user);
        // _context.Users.Update(user);
        // _context.SaveChanges();
    }

    public void Delete(int id)
    {
        // var user = getUser(id);
        // _context.Users.Remove(user);
        // _context.SaveChanges();
    }

    // helper methods

    private Event getEvent(int id)
    {
        var eventFromDb = _context.Events.Find(id);
        if (eventFromDb == null) throw new KeyNotFoundException("User not found");
        return eventFromDb;
    }

    public async Task<bool> JoinEvent(int userId, int eventId)
    {
        var eventFromDb = await _context.Events
            .Include(e => e.Group.Users)
            .Where(e => e.Id == eventId && !e.Group.Users.Any(u => u.Id == userId))
            .FirstOrDefaultAsync();

        if (eventFromDb != null && !eventFromDb.IsCanceled && eventFromDb.MaxAttendants > eventFromDb.CurrentNoAttendants)
        {
            User newAttendants = await _context.Users
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();

            if (eventFromDb.Group == null)
            {
                eventFromDb.Group = new Group();
            }

            eventFromDb.Group.Users.Add(newAttendants);

            _context.SaveChanges();

            return true;
        }
        return false;
    }

    public async Task<bool> DropFromEvent(int userId, int eventId)
    {
        // TODO check if user is admin, admin cant drop out, only remove whole event(or give admin privileges to someone else)
        var eventFromDb = await _context.Events
            .Include(e => e.Group.Users)
            .Where(e => e.Id == eventId && e.Group.Users.Any(u => u.Id == userId))
            .FirstOrDefaultAsync();

        if (eventFromDb != null && !eventFromDb.IsCanceled && eventFromDb.MaxAttendants > eventFromDb.CurrentNoAttendants)
        {

            eventFromDb.Group.Users.Remove(eventFromDb.Group.Users.Where(u => u.Id == userId).First());

            _context.SaveChanges();

            return true;
        }
        return false;
    }
}