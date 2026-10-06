using LibraryWebApp.Models;

namespace LibraryWebApp.Repositories;

public interface ICatalogRepository
{
    Task<CatalogItem?> GetByIdAsync(int id);
    Task<IEnumerable<CatalogItem>> GetAllAsync();
    Task<CatalogItem> CreateAsync(CatalogItem item);
    Task<bool> UpdateAsync(int id, CatalogItem item);
    Task<bool> DeleteAsync(int id);
}
