namespace UM.Application.Features.Users.Queries.GetUserById
{
    public sealed record GetUserByIdQuery : IRequest<Result<UserDto>>
    {
        public int Id { get; set; }
    }
}
