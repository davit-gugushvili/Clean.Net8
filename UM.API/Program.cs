using FastEndpoints.Swagger;
using UM.API.OptionsSetup;
using UM.Application;
using UM.Infrastructure;
using UM.Infrastructure.Security.Jwt;
using UM.Persistence;
using UM.Persistence.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureOptions<JwtOptionsSetup>();

builder.Services.AddCors();

builder.Services.AddPersistenceServices(builder.Configuration.GetOptions<ConnectionStringOptions>());

builder.Services.AddInfrastructureServices(builder.Configuration.GetOptions<JwtOptions>());

builder.Services.AddApplicationServices();

builder.Services.AddFastEndpoints();

builder.Services.AddSwaggerDocumentation();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

app.UseDefaultExceptionHandler()
    .UseAuthentication()
    .UseAuthorization()
    .UseFastEndpoints(x =>
    {
        x.Endpoints.RoutePrefix = "api";
        x.Versioning.Prefix = "v";
    }).UseSwaggerGen();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHealthChecks("/health");

app.Run();