namespace UM.API.OptionsSetup
{
    public class JwtOptionsSetup(IConfiguration configuration)
        : IConfigureOptions<JwtOptions>
    {
        public void Configure(JwtOptions options)
        {
            configuration.GetSection(JwtOptions.Jwt).Bind(options);
        }
    }
}
