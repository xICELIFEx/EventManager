using System.ComponentModel.DataAnnotations;

namespace EventManager.Models.Event;

/// <summary>
/// DTO модели события
/// </summary>
public class EventDto
{
    /// <summary>
    /// Id события
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название события
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = "Title is required")]
    public required string Title { get; set; }
    
    /// <summary>
    /// Описание события
    /// </summary>
    public string? Description { get; set; }
    
    /// <summary>
    /// Начало события
    /// </summary>
    [Required(ErrorMessage = "Start date is required")]
    public DateTime StartAt { get; set; }
    
    /// <summary>
    /// Конец события
    /// </summary>
    [Required(ErrorMessage = "End date is required")]
    [DateGreaterThan(nameof(StartAt), ErrorMessage = "End date must be greater then StartAt.")]
    public DateTime EndAt { get; set; }
}