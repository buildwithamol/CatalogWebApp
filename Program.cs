using LibraryWebApp.Data;
using LibraryWebApp.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApp;


public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Configure Entity Framework with In-Memory Database
        // (renamed the in-memory database id to avoid default/sample naming)
        builder.Services.AddDbContext<LibraryDbContext>(options =>
            options.UseInMemoryDatabase("CatalogInMemoryDb"));

        // Register Repositories (renamed to catalog types)
        builder.Services.AddScoped<Repositories.ICatalogRepository, Repositories.CatalogRepository>();


        // Register Helper Services
        builder.Services.AddSingleton<LibraryWebApp.Helpers.MathHelper>();
        builder.Services.AddSingleton<LibraryWebApp.Helpers.StringHelper>();

        var app = builder.Build();

        // Seed the in-memory database
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<LibraryDbContext>();
            // Use the renamed data seeder to populate initial sample data
            DataSeeder.Initialize(context);
        }

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
