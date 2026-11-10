using EventManager.Models.Event;

namespace EventManager.Services.Events;

/// <summary>
/// Сервис работы с событиями
/// </summary>
public class EventService : IEventService
{
    // Static is temp solution for save data between requests without singleton service
    private static List<Event> _events = new ();

    /// <inheritdoc />
    public List<Event> GetAllEvents()
    {
        return _events.Select(eventModel => new Event(eventModel)).ToList();
    }

    /// <inheritdoc />
    public Event? GetEventById(int id)
    {
        return _events.FirstOrDefault(eventModel => eventModel.Id.Equals(id));
    }

    /// <inheritdoc />
    public bool CreateEvent(EventDto eventDto)
    {
        var eventModel = FindEventByFields(eventDto);
        if (eventModel == null)
        {
            // model already validated, check used for remove warnings
            if (eventDto is { StartAt: not null, EndAt: not null })
                _events.Add(new Event(eventDto.Title, eventDto.Description, eventDto.StartAt.Value, eventDto.EndAt.Value));
            return true;
        }
        return false;
    }

    /// <inheritdoc />
    public bool UpdateEvent(int id, EventDto eventDto)
    {
        var eventModel = GetEventById(id);
        // model already validated, check used for remove warnings
        if (eventModel != null && eventDto is { StartAt: not null, EndAt: not null })
        {
            eventModel.Title = eventDto.Title;
            eventModel.Description = eventDto.Description ?? "";
            eventModel.StartAt = eventDto.StartAt.Value;
            eventModel.EndAt = eventDto.EndAt.Value;
            return true;
        }
        return false;
    }

    /// <inheritdoc />
    public bool DeleteEvent(int id)
    {
        var eventModel = GetEventById(id);
        if (eventModel != null)
        {
            _events.Remove(eventModel);
            return true;
        }
        return false;
    }

    private Event? FindEventByFields(EventDto eventDto)
    {
        return _events.FirstOrDefault(eventModel => eventModel.Title.Equals(eventDto.Title) &&
                                                    eventModel.Description.Equals(eventDto.Description) && 
                                                    eventModel.StartAt.Equals(eventDto.StartAt) &&
                                                    eventModel.EndAt.Equals(eventDto.EndAt));
    }
}