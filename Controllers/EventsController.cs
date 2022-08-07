namespace WebApi.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Events;
using WebApi.Services;

[ApiController]
[Route("[controller]")]
public class EventsController : ControllerBase
{
    private IEventService _eventService;
    private IMapper _mapper;

    public EventsController(
        IEventService eventService,
        IMapper mapper)
    {
        _eventService = eventService;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("user")]
    public IActionResult GetAllForUser(int userId)
    {
        var users = _eventService.GetAllForUser(userId);
        return Ok(users);
    }

    [HttpGet]
    [Route("tags")]
    public async Task<IActionResult> GetAllForTags(IEnumerable<int> tagIds)
    {
        var events = await _eventService.GetAllForTags(tagIds);
        return Ok(events);
    }

    [HttpPost]
    [Route("join")]
    public async Task<IActionResult> JoinEvent(JoinRequest model)
    {
        bool result = await _eventService.JoinEvent(model.UserId, model.EventId);
        if (result) return Ok("User joined");
        return BadRequest("ERROR");
    }

    [HttpPost]
    [Route("drop")]
    public async Task<IActionResult> DropFromEvent(JoinRequest model)
    {
        bool result = await _eventService.DropFromEvent(model.UserId, model.EventId);
        if (result) return Ok("User droped out from event");
        return BadRequest("ERROR");
    }

    
    [HttpGet]
    [Route("user-tag")]
    public async Task<IActionResult> GetAllForUserTags(int userId)
    {
        var result = await _eventService.GetAllForUserTags(userId);
        return Ok(result);
    }

    //     [HttpGet]
    //     public IActionResult GetAll()
    //     {
    //         var users = _userService.GetAll();
    //         return Ok(users);
    //     }

    //     [HttpGet("{id}")]
    //     public IActionResult GetById(int id)
    //     {
    //         var user = _userService.GetById(id);
    //         return Ok(user);
    //     }

    //     [HttpPost]
    //     public IActionResult Create(CreateRequest model)
    //     {
    //         _userService.Create(model);
    //         return Ok(new { message = "User created" });
    //     }

    //     [HttpPut("{id}")]
    //     public IActionResult Update(int id, UpdateRequest model)
    //     {
    //         _userService.Update(id, model);
    //         return Ok(new { message = "User updated" });
    //     }

    //     [HttpDelete("{id}")]
    //     public IActionResult Delete(int id)
    //     {
    //         _userService.Delete(id);
    //         return Ok(new { message = "User deleted" });
    //     }

    //     [HttpPost]
    //     [Route("login")]
    //     public IActionResult Login(LoginRequest model)
    //     {
    //         var user = _userService.Login(model);
    //         if (user != null)
    //         {
    //             return Ok(user);
    //         }
    //         return BadRequest(new { message = "Login failed" });
    //     }
}