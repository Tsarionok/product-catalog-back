using Microsoft.EntityFrameworkCore;
using ProductCatalog.DataAccess.Context;
using ProductCatalog.DataAccess.Entities;

namespace ProductCatalog.DataAccess.Repository.Implementations;

public class CategoryRepository : ICategoryRepository
{
    private ProductCatalogContext _context;

    public CategoryRepository(ProductCatalogContext context)
    {
        _context = context;
    }

    public async Task<Category> GetByIdAsync(long id) =>
        await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<IEnumerable<Category>> GetAllAsync() =>
        await _context.Categories.ToListAsync();

    public async Task<Category> AddAsync(Category category)
    {
        var categoryResult = (await _context.Categories.AddAsync(category)).Entity;
        await _context.SaveChangesAsync();
        return categoryResult;
    }

    public async Task<Category> UpdateAsync(Category category)
    {
        _context.Entry(category).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return await GetByIdAsync(category.Id);
    }

    public async Task<Category> DeleteByIdAsync(long id)
    {
        var categoryResult = _context.Categories.Remove(await GetByIdAsync(id)).Entity;
        await _context.SaveChangesAsync();
        return categoryResult;
    }
}