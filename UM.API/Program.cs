using FastEndpoints.Security;
using FastEndpoints.Swagger;
using UM.API.Auth;
using UM.API.OptionsSetup;
using UM.Application;
using UM.Application.Interfaces;
using UM.Infrastructure;
using UM.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureOptions<JwtOptionsSetup>();

builder.Services.AddCors();

builder.Services
    .AddAuthenticationJwtBearer(x => x.SigningKey = builder.Configuration.GetSection(JwtOptions.Jwt).Get<JwtOptions>()?.SecretKey)
    .AddAuthorization(x => x.AddPolicy("AdminsOnly", x => x.RequireRole("Admin")))
    .AddFastEndpoints();

builder.Services.AddSwaggerDocumentation();

builder.Services.AddScoped<ICurrentUser, CurrentUser>();

builder.Services.AddPersistenceServices(builder.Configuration.GetSection(ConnectionStringsOptions.ConnectionStrings).Get<ConnectionStringsOptions>()!);
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();

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