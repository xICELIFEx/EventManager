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
        return Ok(new ApiResult<List<EventResponseDto>>() { Data = _eventService.GetAllEvents().Select(e => e.ToDto()).ToList() });
    }

    /// <summary>
    /// Метод возвращает информацию о событии по его id
    /// </summary>
    /// <param name="id">Параметр id, для получения информации о связанном событии</param>
    /// <response code="200">Возвращается JSON-структура <c><![CDATA[ApiResult<EventResponseDto>]]></c> с информацией о событии
    /// и HTTP статус-кодом <c>200 Ok</c> в случае успеха</response>
    /// <response code="404">Возвращается JSON-структура <c><![CDATA[ProblemDetails]]></c> с описанием возникшей при получении события проблемы
    /// и HTTP статус-кодом <c>404 NotFound</c> в случае не удачи</response>
    [HttpGet("{id}")]
    [ProducesResponseType<ApiResult<EventResponseDto>>(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(statusCode: StatusCodes.Status404NotFound)]
    public ActionResult<ApiResult<EventResponseDto>> GetEventById(int id)
    {
        var response = new ApiResult<EventResponseDto>() { Data = _eventService.GetEventById(id)?.ToDto() };
        if (response.Data != null)
            return Ok(response);
        else
            return Problem(title: "Event not found", detail: $"Event with id {id} not Found", statusCode: StatusCodes.Status404NotFound);
    }

    /// <summary>
    /// Метод создает новое событие
    /// </summary>
    /// <param name="eventRequestDto">Набор данных необходимых для создания нового события</param>
    /// <response code="201">Возвращается JSON-структура <c><![CDATA[ApiResult<EventResponseDto>]]></c> с созданым событием
    /// и HTTP статус-кодом <c>201 Created</c> в случае успеха</response>
    /// <response code="400">Возвращается JSON-структура <c><![CDATA[ProblemDetails]]></c> с описанием проблемы
    /// и HTTP статус-кодом <c>409 Conflict</c> в случае не удачи</response>
    [HttpPost]
    [ProducesResponseType<ApiResult<EventResponseDto>>(statusCode: StatusCodes.Status201Created)]
    [ProducesResponseType<ProblemDetails>(statusCode: StatusCodes.Status409Conflict)]
    public ActionResult<ApiResult<EventResponseDto>> CreateEvent([FromBody] EventRequestDto eventRequestDto)
    {
        var createdEvent = _eventService.CreateEvent(eventRequestDto);
        if (createdEvent != null)
            return CreatedAtAction("CreateEvent", new ApiResult<EventResponseDto>() { Data = createdEvent.ToDto() });
        else
            return ValidationProblem(title: "Event not created",
                detail:
                $"Event with fields {{Title:{eventRequestDto.Title},Description:{eventRequestDto.Description},StartAt:{eventRequestDto.StartAt},EndAt:{eventRequestDto.EndAt}}} already exist.",
                statusCode: StatusCodes.Status409Conflict);
    }

    /// <summary>
    /// Метод обновляет сущевствующее событие
    /// </summary>
    /// <param name="id">Параметр id, указывает на обновляемое событие</param>
    /// <param name="eventRequestDto">Набор данных необходимых для обновления сущевствующего события</param>
    /// <response code="200">Возвращается JSON-структура <c><![CDATA[ApiResult<EventResponseDto>]]></c> с обновленным событием
    /// и HTTP статус-кодом <c>200 Ok</c> в случае успеха</response>
    /// <response code="404">Возвращается JSON-структура <c><![CDATA[ProblemDetails]]></c> с описанием возникшей при обновлении проблемы
    /// и HTTP статус-кодом <c>404 NotFound</c> в случае не удачи</response>
    [HttpPut("{id}")]
    [ProducesResponseType<ApiResult<EventResponseDto>>(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(statusCode: StatusCodes.Status404NotFound)]
    public ActionResult<ApiResult<EventResponseDto>> UpdateEvent([FromRoute] int id, [FromBody] EventRequestDto eventRequestDto)
    {
        var updateEvent = _eventService.UpdateEvent(id, eventRequestDto);
        if (updateEvent != null)
            return Ok(new ApiResult<EventResponseDto>() { Data = updateEvent.ToDto() });
        else
            return Problem(title: "Event not updated", detail: $"Event with id {id} not Found", statusCode: StatusCodes.Status404NotFound);
    }

    /// <summary>
    /// Метод удаляет сущевствующее событие
    /// </summary>
    /// <param name="id">Индекс удаляемого события</param>
    /// <response code="200">Возвращается JSON-структура <c><![CDATA[ApiResult<bool>]]></c> с флагом обновлено событие или нет
    /// и HTTP статус-кодом <c>200 Ok</c> в случае успеха</response>
    /// <response code="404">Возвращается JSON-структура <c><![CDATA[ProblemDetails]]></c> с описанием возникшей при удалении проблемы
    /// и HTTP статус-кодом <c>404 NotFound</c> в случае не удачи</response>
    [HttpDelete("{id}")]
    [ProducesResponseType<ApiResult<bool>>(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(statusCode: StatusCodes.Status404NotFound)]
    public ActionResult<ApiResult<bool>> DeleteEvent(int id)
    {
        var isDeleted = _eventService.DeleteEvent(id);
        if (isDeleted)
            return Ok(new ApiResult<bool>() { Data = isDeleted });
        else
            return Problem(title: "Event not deleted", detail: $"Event with id {id} not found", statusCode: StatusCodes.Status404NotFound);
    }
}