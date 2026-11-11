using EventManager.Models.Event;
using EventManager.Response;
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
    /// <response code="200">Возвращается JSON-структура <c><![CDATA[ApiResult<List<EventResponseDto>>]]></c> со списком событий
    /// и HTTP статус-кодом <c>200 Ok</c> в случае успеха</response>
    [HttpGet]
    [ProducesResponseType<ApiResult<List<EventResponseDto>>>(statusCode: StatusCodes.Status200OK)]
    public ActionResult<ApiResult<List<EventResponseDto>>> GetAllEvents()
    {
        return Ok(new ApiResult<List<EventResponseDto>>() { Data = _eventService.GetAllEvents().Select(e => e.ToDto()).ToList(), Message = "" });
    }

    /// <summary>
    /// Метод возвращает информацию о событии по его id
    /// </summary>
    /// <param name="id">Параметр id, для получения информации о связанном событии</param>
    /// <response code="200">Возвращается JSON-структура <c><![CDATA[ApiResult<EventResponseDto>]]></c> с информацией о событии
    /// и HTTP статус-кодом <c>200 Ok</c> в случае успеха</response>
    /// <response code="404">Возвращается JSON-структура <c><![CDATA[ApiResult<EventResponseDto>]]></c> с сообщением о том что событие не найдено
    /// и HTTP статус-кодом <c>404 NotFound</c> в случае не удачи</response>
    [HttpGet("{id}")]
    [ProducesResponseType<ApiResult<EventResponseDto>>(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType<ApiResult<EventResponseDto>>(statusCode: StatusCodes.Status404NotFound)]
    public ActionResult<ApiResult<EventResponseDto>> GetEventById(int id)
    {
        var response = new ApiResult<EventResponseDto>() { Data = _eventService.GetEventById(id)?.ToDto(), Message = "" };
        if (response.Data == null)
        {
            response.Message = $"Event with id {id} not found";
            return NotFound(response);
        }

        return Ok(response);
    }

    /// <summary>
    /// Метод создает новое событие
    /// </summary>
    /// <param name="eventRequestDto">Набор данных необходимых для создания нового события</param>
    /// <response code="201">Возвращается JSON-структура <c><![CDATA[ApiResult<bool>]]></c> с флагом создано событие или нет
    /// и HTTP статус-кодом <c>201 Created</c> в случае успеха</response>
    /// <response code="400">Возвращается JSON-структура <c><![CDATA[ApiResult<bool>]]></c> с флагом создано событие или нет
    /// и HTTP статус-кодом <c>400 BadRequest</c> в случае не удачи</response>
    [HttpPost]
    [ProducesResponseType<ApiResult<bool>>(statusCode: StatusCodes.Status201Created)]
    [ProducesResponseType<ApiResult<bool>>(statusCode: StatusCodes.Status400BadRequest)]
    public ActionResult<ApiResult<bool>> CreateEvent([FromBody] EventRequestDto eventRequestDto)
    {
        var isCreated = _eventService.CreateEvent(eventRequestDto);
        if (isCreated)
            return CreatedAtAction("CreateEvent", new ApiResult<bool>() { Data = isCreated, Message = "" });
        else
            return BadRequest(new ApiResult<bool>()
            {
                Data = isCreated,
                Message =
                    $"Event with data {{Title:{eventRequestDto.Title},Description:{eventRequestDto.Description},StartAt:{eventRequestDto.StartAt},EndAt:{eventRequestDto.EndAt}}} not created."
            });
    }

    /// <summary>
    /// Метод обновляет сущевствующее событие
    /// </summary>
    /// <param name="id">Параметр id, указывает на обновляемое событие</param>
    /// <param name="eventRequestDto">Набор данных необходимых для обновления сущевствующего события</param>
    /// <response code="200">Возвращается JSON-структура <c><![CDATA[ApiResult<bool>]]></c> с флагом обновлено событие или нет
    /// и HTTP статус-кодом <c>200 Ok</c> в случае успеха</response>
    /// <response code="404">Возвращается JSON-структура <c><![CDATA[ApiResult<bool>]]></c> с флагом обновлено событие или нет
    /// и HTTP статус-кодом <c>404 NotFound</c> в случае не удачи</response>
    [HttpPut("{id}")]
    [ProducesResponseType<ApiResult<bool>>(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType<ApiResult<bool>>(statusCode: StatusCodes.Status404NotFound)]
    public ActionResult<ApiResult<bool>> UpdateEvent([FromRoute] int id, [FromBody] EventRequestDto eventRequestDto)
    {
        var isUpdated = _eventService.UpdateEvent(id, eventRequestDto);
        if (isUpdated)
            return Ok(new ApiResult<bool>() { Data = isUpdated, Message = "" });
        else
            return NotFound(new ApiResult<bool>() { Data = isUpdated, Message = $"Event with id {id} not Found" });
    }

    /// <summary>
    /// Метод удаляет сущевствующее событие
    /// </summary>
    /// <param name="id">Индекс удаляемого события</param>
    /// <response code="200">Возвращается JSON-структура <c><![CDATA[ApiResult<bool>]]></c> с флагом обновлено событие или нет
    /// и HTTP статус-кодом <c>200 Ok</c> в случае успеха</response>
    /// <response code="404">Возвращается JSON-структура <c><![CDATA[ApiResult<bool>]]></c> с флагом обновлено событие или нет
    /// и HTTP статус-кодом <c>404 NotFound</c> в случае не удачи</response>
    [HttpDelete("{id}")]
    [ProducesResponseType<ApiResult<bool>>(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType<ApiResult<bool>>(statusCode: StatusCodes.Status404NotFound)]
    public ActionResult<ApiResult<bool>> DeleteEvent(int id)
    {
        var isDeleted = _eventService.DeleteEvent(id);
        if (isDeleted)
            return Ok(new ApiResult<bool>() { Data = isDeleted, Message = "" });
        else
            return NotFound(new ApiResult<bool>() { Data = isDeleted, Message = $"Event with id {id} not Found" });
    }
}