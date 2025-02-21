using FluentValidation.Results;

namespace Application.Exceptions
{
    class ValidationException : Exception
    {
        public List<string> ValidationErrors { get; set; }

        public ValidationException(ValidationResult validationResult)
        {
            ValidationErrors = [];
            ValidationErrors.AddRange(validationResult.Errors.Select(validationError => validationError.ErrorMessage));
        }
    }
}
