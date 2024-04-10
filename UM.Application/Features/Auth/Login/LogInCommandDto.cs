namespace UM.Application.Features.Auth.Login
{
    public record LogInCommandDto
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Role { get; set; }
        public required string AccessToken { get; set; }
        public required string RefreshToken { get; set; }
    }
}
