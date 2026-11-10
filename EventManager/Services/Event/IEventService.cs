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
    /// <param name="eventDto">данные для создания события</param>
    /// <returns></returns>
    bool CreateEvent(EventDto eventDto);
    /// <summary>
    /// Обновление сущевствующего события
    /// </summary>
    /// <param name="eventDto">данные для обновления события</param>
    /// <returns></returns>
    bool UpdateEvent(int id, EventDto eventDto);
    /// <summary>
    /// Удаление сущевствующего события
    /// </summary>
    /// <param name="id">id события</param>
    /// <returns></returns>
    bool DeleteEvent(int id);
}