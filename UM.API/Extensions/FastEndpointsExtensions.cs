using FastEndpoints.Swagger;

namespace UM.API.Extensions
{
    public static class FastEndpointsExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {

            services.SwaggerDocument(x =>
            {
                x.MaxEndpointVersion = 1;
                x.DocumentSettings = s =>
                {
                    s.DocumentName = "Release 1.0";
                    s.Version = "v1.0";
                };
            });

            services.SwaggerDocument(x =>
            {
                x.MaxEndpointVersion = 2;
                x.DocumentSettings = s =>
                {
                    s.DocumentName = "Release 2.0";
                    s.Version = "v2.0";
                };
            });

            return services;
        }
    }
}
