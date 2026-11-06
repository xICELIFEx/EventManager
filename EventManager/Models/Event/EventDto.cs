using System.ComponentModel.DataAnnotations;

namespace EventManager.Models.Event;

public class EventDto
{
    public int Id { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Title is required")]
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    [Required(ErrorMessage = "Start date is required")]
    public DateTime StartAt { get; set; }
    
    [Required(ErrorMessage = "End date is required")]
    [DateGreaterThan(nameof(StartAt), ErrorMessage = "End date must be greater then StartAt.")]
    public DateTime EndAt { get; set; }
}