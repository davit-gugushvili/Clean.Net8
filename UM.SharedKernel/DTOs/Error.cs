namespace UM.SharedKernel.DTOs
{
    public record Error(string ErrorCode, string ErrorMessage)
    {
        public static implicit operator Result(Error error) => Result.Failure(error);

        public Result ToResult() => Result.Failure(this);
    }
}
