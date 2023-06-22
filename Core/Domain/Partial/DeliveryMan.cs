using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain;

public partial class DeliveryMan : IValidatableObject
{
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrEmpty(FirstName))
        {
            yield return new ValidationResult("First name is null");
        }

        if (string.IsNullOrEmpty(LastName))
        {
            yield return new ValidationResult("Last name is null");
        }

        if (string.IsNullOrEmpty(PhoneNumber))
        {
            yield return new ValidationResult("PhoneNumber name is null");
        }
    }
}