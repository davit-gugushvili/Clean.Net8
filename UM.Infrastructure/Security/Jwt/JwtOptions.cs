using UM.SharedKernel.Interfaces;

namespace UM.Infrastructure.Security.Jwt
{
    public sealed class JwtOptions : IAppSettings
    {
        public static string Section => "Jwt";

        public string Issuer { get; set; } = string.Empty;
        public string SecretKey { get; set; } = string.Empty;
    }
}
