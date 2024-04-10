namespace UM.SharedKernel.DTOs
{
    public abstract class ResultBase(bool isSuccess, List<Error>? errors = null, List<ValidationError>? validationErrors = null)
    {
        public bool IsSuccess { get; } = isSuccess;
        public bool IsFailure => !IsSuccess;

        public List<Error> Errors { get; } = errors ?? new();
        public List<ValidationError> ValidationErrors { get; } = validationErrors ?? new();

    }

    public sealed class Result(bool isSuccess, List<Error>? errors = null, List<ValidationError>? validationErrors = null)
        : ResultBase(isSuccess, errors, validationErrors)
    {
        public static Result Success() => new Result(true);
        public static Result<T> Success<T>(T value) => new Result<T>(true, value: value);

        public static Result Failure(Error error) => Failure([error]);
        public static Result Failure(List<Error> errors) => new Result(false, errors: errors);
        public static Result Failure(List<ValidationError> errors) => new Result(false, validationErrors: errors);
        public static Result Failure<T>(Result<T> result) => new Result(result.IsSuccess, result.Errors, result.ValidationErrors);
    }

    public sealed class Result<T>(bool isSuccess, List<Error>? errors = null, List<ValidationError>? validationErrors = null, T? value = default)
        : ResultBase(isSuccess, errors, validationErrors)
    {
        public T? Value { get; init; } = value;

        public static implicit operator Result<T>(Result result) => new Result<T>(result.IsSuccess, errors: result.Errors, validationErrors: result.ValidationErrors);
    }
}