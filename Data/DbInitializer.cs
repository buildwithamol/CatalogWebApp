using LibraryWebApp.Data;
using LibraryWebApp.Models;

namespace LibraryWebApp.Data;

// Renamed and lightly modified seed logic to use project-specific example data
public static class DataSeeder
{
    public static void Initialize(LibraryDbContext context)
    {
        // If there's already data, don't reseed
        if (context.CatalogItems.Any())
        {
            return;
        }

        var items = new CatalogItem[]
        {
            new CatalogItem
            {
                Title = "Practical Microservices",
                Author = "A. Navarro",
                PublishedDate = new DateTime(2020, 4, 15),
                IsAvailable = true
            },
            new CatalogItem
            {
                Title = "Effective C# Patterns",
                Author = "J. Keller",
                PublishedDate = new DateTime(2017, 6, 5),
                IsAvailable = true
            },
            new CatalogItem
            {
                Title = "Enterprise Architecture Patterns",
                Author = "L. Anders",
                PublishedDate = new DateTime(2006, 2, 12),
                IsAvailable = false
            },
            new CatalogItem
            {
                Title = "Modern Refactoring Guide",
                Author = "S. Patel",
                PublishedDate = new DateTime(2019, 10, 9),
                IsAvailable = true
            },
            new CatalogItem
            {
                Title = "Strategic Domain Design",
                Author = "M. Cho",
                PublishedDate = new DateTime(2015, 1, 22),
                IsAvailable = true
            }
        };

        context.CatalogItems.AddRange(items);
        context.SaveChanges();
    }
}

// Keep a compatibility wrapper to avoid edit-and-continue rename issues
// and to preserve any external callers that expect the original name.
public static class DbInitializer
{
    public static void Initialize(LibraryDbContext context)
    {
        DataSeeder.Initialize(context);
    }
}
