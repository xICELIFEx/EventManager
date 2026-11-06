using EventManager.Models.Event;

namespace EventManager.Services.Events;

public class EventService : IEventService
{
    // Static is temp solution for save data between requests without singleton service
    private static List<Event> _events = new ();
    
    public List<Event> GetAllEvents()
    {
        return _events.Select(eventModel => new Event(eventModel)).ToList();
    }

    public Event GetEventById(int id)
    {
        return _events.FirstOrDefault(eventModel => eventModel.Id.Equals(id));
    }

    public bool CreateEvent(EventDto eventDto)
    {
        var eventModel = FindEventByFields(eventDto);
        if (eventModel == null)
        {
            _events.Add(new Event(eventDto.Title, eventDto.Description, eventDto.StartAt, eventDto.EndAt));
            return true;
        }
        return false;
    }

    public bool UpdateEvent(EventDto eventDto)
    {
        var eventModel = GetEventById(eventDto.Id);
        if (eventModel != null)
        {
            eventModel.Title = eventDto.Title;
            eventModel.Description = eventDto.Description;
            eventModel.StartAt = eventDto.StartAt;
            eventModel.EndAt = eventDto.EndAt;
            return true;
        }
        return false;
    }

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