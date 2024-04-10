namespace UM.Application.Features.Users.Queries
{
    public sealed record UserDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required int RoleId { get; set; }
        public required string Role { get; set; }
    }
}
