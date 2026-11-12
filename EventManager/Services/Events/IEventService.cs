using EventManager.Models.Event;

namespace EventManager.Services.Events;

/// <summary>
/// Интерфейс для работы с событиями
/// </summary>
public interface IEventService
{
    /// <summary>
    /// Метод получения всех событий
    /// </summary>
    /// <returns></returns>
    List<Event> GetAllEvents();

    /// <summary>
    /// Получение события по id
    /// </summary>
    /// <param name="id">id события</param>
    /// <returns></returns>
    Event? GetEventById(int id);

    /// <summary>
    /// Создание нового события
    /// </summary>
    /// <param name="eventRequestDto">данные для создания события</param>
    /// <returns></returns>
    Event? CreateEvent(EventRequestDto eventRequestDto);

    /// <summary>
    /// Обновление сущевствующего события
    /// </summary>
    /// <param name="id">id события</param>
    /// <param name="eventRequestDto">данные для обновления события</param>
    /// <returns></returns>
    bool UpdateEvent(int id, EventRequestDto eventRequestDto);

    /// <summary>
    /// Удаление сущевствующего события
    /// </summary>
    /// <param name="id">id события</param>
    /// <returns></returns>
    bool DeleteEvent(int id);
}