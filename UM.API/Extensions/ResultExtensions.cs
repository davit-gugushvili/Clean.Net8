namespace UM.API.Extensions
{
    public static class ResultExtensions
    {
        public static IResult ToMinimalApiResult(this Result result)
        {
            return ToMinimalApiResult(result.IsSuccess, null, result.Errors, result.ValidationErrors);
        }

        public static IResult ToMinimalApiResult<T>(this Result<T> result)
        {
            return ToMinimalApiResult(result.IsSuccess, result.Value, result.Errors, result.ValidationErrors);
        }

        private static IResult ToMinimalApiResult(bool isSuccess, object? value, List<Error> errors, List<ValidationError> validationErrors)
        {
            if (isSuccess)
            {
                return Results.Ok(value);
            }
            else if (validationErrors.Any())
            {
                return Results.BadRequest(validationErrors);
            }
            else if (errors.Any())
            {
                return Results.BadRequest(errors);
            }

            return Results.BadRequest();
        }
    }
}
