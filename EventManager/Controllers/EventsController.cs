using System.Net;
using EventManager.Models.Event;
using EventManager.Responce;
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
    public ApiBaseResult GetAllEvents()
    {
        return new ApiResult<List<EventDto>>()
            { Data = _eventService.GetAllEvents().Select(e => e.ToDto()).ToList(), StatusCode = HttpStatusCode.OK, Message = "" };
    }

    [HttpGet("{id}")]
    public ApiBaseResult GetEventById(int id)
    {
        var responce = new ApiResult<EventDto>() { Data = _eventService.GetEventById(id)?.ToDto(), StatusCode = HttpStatusCode.OK, Message = "" };
        if (responce.Data == null)
        {
            responce.StatusCode = HttpStatusCode.NotFound;
            responce.Message = $"Event with id {id} not found";
        }

        return responce;
    }

    [HttpPost]
    public ApiBaseResult CreateEvent([FromBody] EventDto eventDto)
    {
        var isCreated = _eventService.CreateEvent(eventDto);
        return new ApiResult<bool>()
        {
            Data = isCreated, StatusCode = isCreated ? HttpStatusCode.OK : HttpStatusCode.BadRequest,
            Message = isCreated
                ? ""
                : $"Event with data {{Title:{eventDto.Title},Description:{eventDto.Description},StartAt:{eventDto.StartAt},EndAt:{eventDto.EndAt}}} not created."
        };
    }

    [HttpPut]
    public ApiBaseResult UpdateEvent([FromBody] EventDto eventDto)
    {
        var isUpdated = _eventService.UpdateEvent(eventDto);
        return new ApiResult<bool>()
        {
            Data = isUpdated, StatusCode = isUpdated ? HttpStatusCode.OK : HttpStatusCode.NotFound,
            Message = isUpdated
                ? ""
                : $"Event with id {eventDto.Id} not Found"
        };
    }

    [HttpDelete("{id}")]
    public ApiBaseResult DeleteEvent(int id)
    {
        var isDeleted = _eventService.DeleteEvent(id);
        return new ApiResult<bool>()
        {
            Data = isDeleted, StatusCode = isDeleted ? HttpStatusCode.OK : HttpStatusCode.NotFound,
            Message = isDeleted
                ? ""
                : $"Event with id {id} not Found"
        };
    }
}