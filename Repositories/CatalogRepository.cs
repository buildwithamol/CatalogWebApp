using LibraryWebApp.Data;
using LibraryWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApp.Repositories;

public class CatalogRepository(LibraryDbContext context) : ICatalogRepository
{
    public async Task<CatalogItem?> GetByIdAsync(int id)
    {
        return await context.CatalogItems.FindAsync(id);
    }

    public async Task<IEnumerable<CatalogItem>> GetAllAsync()
    {
        return await context.CatalogItems.ToListAsync();
    }

    public async Task<CatalogItem> CreateAsync(CatalogItem item)
    {
        context.CatalogItems.Add(item);
        await context.SaveChangesAsync();
        return item;
    }

    public async Task<bool> UpdateAsync(int id, CatalogItem item)
    {
        var existing = await GetByIdAsync(id);
        if (existing == null)
            return false;

        existing.Title = item.Title;
        existing.Author = item.Author;
        existing.IsAvailable = item.IsAvailable;
        existing.PublishedDate = item.PublishedDate;

        context.CatalogItems.Update(existing);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var item = await GetByIdAsync(id);
        if (item == null)
            return false;

        context.CatalogItems.Remove(item);
        await context.SaveChangesAsync();
        return true;
    }
}
