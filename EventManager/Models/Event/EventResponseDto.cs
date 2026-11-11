using System.ComponentModel.DataAnnotations;
using EventManager.Validators;

namespace EventManager.Models.Event;

/// <summary>
/// DTO выходной модели события
/// </summary>
public class EventResponseDto : IValidatableObject
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
    [Required(AllowEmptyStrings = true, ErrorMessage = "Description is required")]
    public string Description { get; set; } = "";

    /// <summary>
    /// Начало события
    /// </summary>
    public DateTime? StartAt { get; set; }

    /// <summary>
    /// Конец события
    /// </summary>
    [DateGreaterThan(nameof(StartAt), ErrorMessage = "End date must be greater then StartAt.")]
    public DateTime? EndAt { get; set; }

    /// <inheritdoc />
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var validationResults = new List<ValidationResult>();
        if (StartAt == null)
        {
            validationResults.Add(new ValidationResult("Start date is required", new[] { nameof(StartAt) }));
        }

        if (EndAt == null)
        {
            validationResults.Add(new ValidationResult("End date is required", new[] { nameof(EndAt) }));
        }

        return validationResults;
    }
}