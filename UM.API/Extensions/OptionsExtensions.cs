using UM.SharedKernel.Interfaces;

namespace UM.API.Extensions
{
    public static class OptionsExtensions
    {
        public static T GetOptions<T>(this ConfigurationManager configuration) where T : IAppSettings
        {
            var result = configuration.GetSection(T.Section).Get<T>();

            return result ?? throw new ApplicationException($"{T.Section} Options Not Found");
        }
    }
}
