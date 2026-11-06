using EventManager.Models.Event;
using EventManager.Services.Events;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly IEventService _eventService;
    
    public EventsController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet]
    public IActionResult GetAllEvents()
    {
        return Ok(_eventService.GetAllEvents().Select(e => e.ToDto()).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetEventById(int id)
    {
        var eventFound = _eventService.GetEventById(id);
        if (eventFound != null) return Ok(eventFound.ToDto());
        return NotFound();
    }

    [HttpPost]
    public IActionResult CreateEvent([FromBody] EventDto eventDto)
    {
        if (_eventService.CreateEvent(eventDto)) return Ok();
        return BadRequest();
    }

    [HttpPut]
    public IActionResult UpdateEvent([FromBody] EventDto eventDto)
    {
        if (_eventService.UpdateEvent(eventDto)) return Ok();
        return NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteEvent(int id)
    {
        if (_eventService.DeleteEvent(id)) return Ok();
        return NotFound();
    }
}