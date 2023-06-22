using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.CustomException;

public sealed class RestaurantValidationException : Exception
{
    public Dictionary<object, List<ValidationResult>> Results  { get;}
    private RestaurantValidationException() : this("Errors happened during validation") { }
    private RestaurantValidationException(string message) : this(new Dictionary<object, List<ValidationResult>>(), message) { }
    public RestaurantValidationException(Dictionary<object, List<ValidationResult>> validations) : this()
    {
        Results = validations;
    }

    private RestaurantValidationException(Dictionary<object, List<ValidationResult>> validations, string message) : base(message)
    {
        Results = validations;
    }
}