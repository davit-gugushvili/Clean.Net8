namespace UM.Persistence.Options
{
    public sealed class ConnectionStringOptions : IAppSettings
    {
        public static string Section => "ConnectionStrings";

        public required string UserManagement { get; set; }
    }
}
