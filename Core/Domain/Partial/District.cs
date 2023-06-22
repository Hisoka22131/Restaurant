using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain;

public partial class District: IValidatableObject
{
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrEmpty(Name))
            yield return new ValidationResult("Name is null");
    }
}