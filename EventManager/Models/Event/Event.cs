namespace EventManager.Models.Event;

public class Event
{
    private static int _nextId = 0;
    
    public int Id { get; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }

    public Event(string title, string description, DateTime startAt, DateTime endAt)
        : this (_nextId++, title, description, startAt, endAt) {}
    
    public Event(Event sourceEvent)
        : this (sourceEvent.Id, sourceEvent.Title, sourceEvent.Description, sourceEvent.StartAt, sourceEvent.EndAt) {}

    public Event(int id, string title, string description, DateTime startAt, DateTime endAt)
    {
        Id = id;
        Title = title;
        Description = description;
        StartAt = startAt;
        EndAt = endAt;
    }
        
    public EventDto ToDto()
    {
        return new EventDto
        {
            Id = Id,
            Title = Title,
            Description = Description,
            StartAt = StartAt,
            EndAt = EndAt,
        };
    }
}