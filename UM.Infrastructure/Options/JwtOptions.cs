namespace UM.Infrastructure.Options
{
    public sealed class JwtOptions
    {
        public static string Jwt = "Jwt";

        public string Issuer { get; set; } = string.Empty;
        public string SecretKey { get; set; } = string.Empty;
    }
}
