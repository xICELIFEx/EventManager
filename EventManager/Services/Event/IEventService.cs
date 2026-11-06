using EventManager.Models.Event;

namespace EventManager.Services.Events;

public interface IEventService
{
    List<Event> GetAllEvents();
    Event GetEventById(int id);
    bool CreateEvent(EventDto eventDto);
    bool UpdateEvent(EventDto eventDto);
    bool DeleteEvent(int id);
}