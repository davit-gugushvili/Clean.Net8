namespace UM.SharedKernel.DTOs
{
    public sealed class ValidationError
    {
        public string? ErrorMessage { get; init; }
        public string? ErrorCode { get; init; }
        public string? PropertyName { get; init; }
        public string? Severity { get; init; }


        public static implicit operator ValidationError(ValidationFailure source) => new ValidationError
        {
            PropertyName = source.PropertyName,
            ErrorMessage = source.ErrorMessage,
            ErrorCode = source.ErrorCode,
            Severity = source.Severity.ToString()
        };
    }
}
