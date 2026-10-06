namespace LibraryWebApp.Models;

// Renamed from Book to CatalogItem to use project-specific naming
public class CatalogItem
{
    public int Id { get; init; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public bool IsAvailable { get; set; } = true;
    public DateTime PublishedDate { get; set; }
}
