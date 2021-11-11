using System.ComponentModel.DataAnnotations;

namespace Ticketing.DTOs;

public record class CreateTicketDto : IValidatableObject
{
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrEmpty(PhoneNumber) && string.IsNullOrEmpty(Email) is false ||
            string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(PhoneNumber) is false)
        {
            string phoneNumber = nameof(PhoneNumber);
            string email = nameof(Email);
            yield return new ValidationResult($"{phoneNumber} and {email} must be either null or have value.");
        }
    }
}
