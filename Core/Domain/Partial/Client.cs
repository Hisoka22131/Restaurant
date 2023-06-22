using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain;

public partial class Client : IValidatableObject
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
            
        if (DiscountPercentage.Value < 0)
        {
            yield return new ValidationResult("DiscountPercentage < 0");
        }
    }
}