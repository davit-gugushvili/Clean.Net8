namespace UM.Domain.Aggregates.User.Errors
{
    public record InvalidPasswordLengthError(int minLength, int maxLength) 
        : Error("InvalidPasswordLength", $"Password length must be from {minLength} to {maxLength} characters")
    {
    }
}
