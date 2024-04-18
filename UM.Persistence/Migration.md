Migrations commands:

dotnet ef migrations add InitialCreate -s ..\UM.API\UM.API.csproj

dotnet ef database update -s ..\UM.API\UM.API.csproj

dotnet ef migrations remove -s ..\UM.API\UM.API.csproj





Note:

modelBuilder.Entity<TEntity>().HasData    does not yet support complex types so seed data is set manually in migrationBuilder.InsertData