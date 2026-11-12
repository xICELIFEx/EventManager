namespace EventManager.Models.Event;

/// <summary>
/// DTO выходной модели события
/// </summary>
public class EventResponseDto
{
    /// <summary>
    /// Id события
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название события
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// Описание события
    /// </summary>
    public required string Description { get; set; }

    /// <summary>
    /// Начало события
    /// </summary>
    public DateTime StartAt { get; set; }

    /// <summary>
    /// Конец события
    /// </summary>
    public DateTime EndAt { get; set; }
}