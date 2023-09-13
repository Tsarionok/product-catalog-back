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
        (await _context.Categories.FirstOrDefaultAsync(x => x.Id == id))!;

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Category> AddAsync(Category category)
    {
        await using (_context)
        {
            var categoryResult = await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return categoryResult.Entity;
        }
    }

    public async Task<Category> UpdateAsync(Category category)
    {
        throw new NotImplementedException();
    }

    public async Task<Category> DeleteByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}