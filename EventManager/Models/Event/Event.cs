namespace EventManager.Models.Event;

/// <summary>
/// Модель описывающая событие
/// </summary>
public class Event
{
    private static int _nextId = 0;
    
    /// <summary>
    /// Id события
    /// </summary>
    public int Id { get; }
    /// <summary>
    /// Название события
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// Описание события
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// Начало события
    /// </summary>
    public DateTime StartAt { get; set; }
    /// <summary>
    /// Конец события
    /// </summary>
    public DateTime EndAt { get; set; }

    /// <summary>
    /// Базовый конструктор события
    /// </summary>
    /// <param name="title">Название события</param>
    /// <param name="description">Описание события</param>
    /// <param name="startAt">Начало события</param>
    /// <param name="endAt">Конец события</param>
    public Event(string title, string? description, DateTime startAt, DateTime endAt)
        : this (_nextId++, title, description ?? "", startAt, endAt) {}
    
    /// <summary>
    /// Конструктор копирования
    /// </summary>
    /// <param name="sourceEvent">источник данных</param>
    public Event(Event sourceEvent)
        : this (sourceEvent.Id, sourceEvent.Title, sourceEvent.Description, sourceEvent.StartAt, sourceEvent.EndAt) {}
    
    private Event(int id, string title, string description, DateTime startAt, DateTime endAt)
    {
        Id = id;
        Title = title;
        Description = description;
        StartAt = startAt;
        EndAt = endAt;
    }
        
    /// <summary>
    /// метод преобразования модели в DTO
    /// </summary>
    /// <returns>Заполненый DTO объект</returns>
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