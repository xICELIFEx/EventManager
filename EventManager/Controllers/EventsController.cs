using EventManager.Models.Event;
using EventManager.Responce;
using EventManager.Services.Events;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.Controllers;

/// <summary>
/// Контроллер реализующий CRUD операции с Event-тами 
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly IEventService _eventService;

    /// <inheritdoc />
    public EventsController(IEventService eventService)
    {
        _eventService = eventService;
    }

    /// <summary>
    /// Метод возвращает информацию обо всех хранящихся событиях
    /// </summary>
    /// <response code="200">Возвращается JSON-структура ApiBaseResult со списком событий
    /// и HTTP статус-кодом 200 Ok в случае успеха</response>
    [HttpGet]
    public ActionResult<ApiResult<List<EventDto>>> GetAllEvents()
    {
        return Ok(new ApiResult<List<EventDto>>()
            { Data = _eventService.GetAllEvents().Select(e => e.ToDto()).ToList(), Message = "" });
    }

    /// <summary>
    /// Метод возвращает информацию о событии по его id
    /// </summary>
    /// <param name="id">Параметр id, для получения информации о связанном событии</param>
    /// <response code="200">Возвращается JSON-структура ApiBaseResult с информацией о событии
    /// и HTTP статус-кодом 200 Ok в случае успеха</response>
    [HttpGet("{id}")]
    public ActionResult<ApiResult<EventDto>> GetEventById(int id)
    {
        var responce = new ApiResult<EventDto>() { Data = _eventService.GetEventById(id)?.ToDto(), Message = "" };
        if (responce.Data == null)
        {
            responce.Message = $"Event with id {id} not found";
            return NotFound(responce);
        }

        return Ok(responce);
    }

    /// <summary>
    /// Метод создает новое событие
    /// </summary>
    /// <param name="eventDto">Набор данных необходимых для создания нового события</param>
    /// <response code="201">Возвращается JSON-структура ApiBaseResult с флагом создано событие или нет
    /// и HTTP статус-кодом 201 Created в случае успеха</response>
    [HttpPost]
    public ActionResult<ApiResult<bool>> CreateEvent([FromBody] EventDto eventDto)
    {
        var isCreated = _eventService.CreateEvent(eventDto);
        if (isCreated)
            return CreatedAtAction("CreateEvent", new ApiResult<bool>() { Data = isCreated, Message = "" });
        else
            return BadRequest(new ApiResult<bool>()
            {
                Data = isCreated,
                Message =
                    $"Event with data {{Title:{eventDto.Title},Description:{eventDto.Description},StartAt:{eventDto.StartAt},EndAt:{eventDto.EndAt}}} not created."
            });
    }

    /// <summary>
    /// Метод обновляет сущевствующее событие
    /// </summary>
    /// <param name="eventDto">Набор данных необходимых для обновления сущевствующего события</param>
    /// <response code="200">Возвращается JSON-структура ApiBaseResult с флагом обновлено событие или нет
    /// и HTTP статус-кодом 200 Ok в случае успеха</response>
    [HttpPut]
    public ActionResult<ApiResult<bool>> UpdateEvent([FromBody] EventDto eventDto)
    {
        var isUpdated = _eventService.UpdateEvent(eventDto);
        if (isUpdated)
            return Ok(new ApiResult<bool>() { Data = isUpdated, Message = "" });
        else
            return NotFound(new ApiResult<bool>() { Data = isUpdated, Message = $"Event with id {eventDto.Id} not Found" });
    }

    /// <summary>
    /// Метод удаляет сущевствующее событие
    /// </summary>
    /// <param name="id">Индекс удаляемого события</param>
    /// <response code="200">Возвращается JSON-структура ApiBaseResult с флагом удалено событие или нет
    /// и HTTP статус-кодом 200 Ok в случае успеха</response>
    [HttpDelete("{id}")]
    public ActionResult<ApiResult<bool>> DeleteEvent(int id)
    {
        var isDeleted = _eventService.DeleteEvent(id);
        if (isDeleted)
            return Ok(new ApiResult<bool>() { Data = isDeleted, Message = "" });
        else
            return NotFound(new ApiResult<bool>() { Data = isDeleted, Message = $"Event with id {id} not Found" });
    }
}