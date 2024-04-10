namespace UM.SharedKernel.Extensions
{
    public static class FluentValidationExtensions
    {
        public static List<ValidationError> GetValidationErrors(this ValidationResult result)
        {
            return result.Errors.Select(x => new ValidationError
            {
                ErrorCode = x.ErrorCode,
                ErrorMessage = x.ErrorMessage,
                PropertyName = x.PropertyName,
                Severity = x.Severity.ToString()
            }).ToList();
        }
    }
}
