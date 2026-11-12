using EventManager.Models.Event;

namespace EventManager.Services.Events;

/// <summary>
/// Сервис работы с событиями
/// </summary>
public class EventService : IEventService
{
    // Static is temp solution for save data between requests without singleton service
    private static List<Event> _events = new();

    /// <inheritdoc />
    public List<Event> GetAllEvents()
    {
        return _events.Select(eventModel => new Event(eventModel)).ToList();
    }

    /// <inheritdoc />
    public Event? GetEventById(int id)
    {
        var eventModel = FindEventById(id);
        return eventModel != null ? new Event(eventModel) : null;
    }

    /// <inheritdoc />
    public Event? CreateEvent(EventRequestDto eventRequestDto)
    {
        var eventModel = FindEventByFields(eventRequestDto);
        if (eventModel == null)
        {
            // model already validated, check used for remove warnings
            if (eventRequestDto is { StartAt: not null, EndAt: not null })
            {
                eventModel = new Event(eventRequestDto.Title, eventRequestDto.Description, eventRequestDto.StartAt.Value,
                    eventRequestDto.EndAt.Value);
                _events.Add(eventModel);
                return eventModel;
            }
        }

        return null;
    }

    /// <inheritdoc />
    public Event? UpdateEvent(int id, EventRequestDto eventRequestDto)
    {
        var eventModel = FindEventById(id);
        // model already validated, check used for remove warnings
        if (eventModel != null && eventRequestDto is { StartAt: not null, EndAt: not null })
        {
            eventModel.Title = eventRequestDto.Title;
            eventModel.Description = eventRequestDto.Description ?? "";
            eventModel.StartAt = eventRequestDto.StartAt.Value;
            eventModel.EndAt = eventRequestDto.EndAt.Value;
            return eventModel;
        }

        return null;
    }

    /// <inheritdoc />
    public bool DeleteEvent(int id)
    {
        var eventModel = FindEventById(id);
        if (eventModel != null)
        {
            _events.Remove(eventModel);
            return true;
        }

        return false;
    }

    private Event? FindEventByFields(EventRequestDto eventRequestDto)
    {
        return _events.FirstOrDefault(eventModel => eventModel.Title.Equals(eventRequestDto.Title) &&
                                                    eventModel.Description.Equals(eventRequestDto.Description) &&
                                                    eventModel.StartAt.Equals(eventRequestDto.StartAt) &&
                                                    eventModel.EndAt.Equals(eventRequestDto.EndAt));
    }

    private Event? FindEventById(int id)
    {
        return _events.FirstOrDefault(eventModel => eventModel.Id.Equals(id));
    }
}