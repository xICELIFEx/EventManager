using System.ComponentModel.DataAnnotations;

namespace EventManager.Validators;

/// <summary>
/// Use AI for write validation attribute
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class DateGreaterThanAttribute : ValidationAttribute
{
    private readonly string _comparisonProperty;

    /// <inheritdoc />
    public DateGreaterThanAttribute(string comparisonProperty)
    {
        _comparisonProperty = comparisonProperty;
    }

    /// <inheritdoc />
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

        if (property == null)
        {
            return new ValidationResult($"Property {_comparisonProperty} not found.");
        }

        var currentValue = value as DateTime?;
        var comparisonValue = property.GetValue(validationContext.ObjectInstance) as DateTime?;

        // If value is not setup, skip it (in this case work [Required])
        if (currentValue == null || comparisonValue == null)
        {
            return ValidationResult.Success;
        }

        if (currentValue.Value <= comparisonValue.Value)
        {
            var errorMessage = ErrorMessage ?? $"{validationContext.DisplayName} must be greater, then {_comparisonProperty}.";
            return new ValidationResult(errorMessage);
        }

        return ValidationResult.Success;
    }
}