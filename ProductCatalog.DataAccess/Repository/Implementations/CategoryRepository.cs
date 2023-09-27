using Microsoft.EntityFrameworkCore;
using ProductCatalog.DataAccess.Context;
using ProductCatalog.DataAccess.Entities;

namespace ProductCatalog.DataAccess.Repository.Implementations;

public class CategoryRepository : ICategoryRepository
{
    private readonly ProductCatalogDbContext _dbContext;

    public CategoryRepository(ProductCatalogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Category> GetByIdAsync(long id) =>
        await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<IEnumerable<Category>> GetAllAsync() =>
        await _dbContext.Categories.ToListAsync();

    public async Task<Category> AddAsync(Category category)
    {
        var categoryResult = (await _dbContext.Categories.AddAsync(category)).Entity;
        await _dbContext.SaveChangesAsync();
        return categoryResult;
    }

    public async Task<Category> UpdateAsync(Category category)
    {
        _dbContext.Entry(category).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return await GetByIdAsync(category.Id);
    }

    public async Task<Category> DeleteCascadeByIdAsync(long id)
    {
        var removableProducts = await _dbContext.Products.Where(x => x.CategoryId == id).ToListAsync();
        foreach (var product in removableProducts)
        {
            _dbContext.Products.Remove(product);
        }
        var categoryResult = _dbContext.Categories.Remove(await GetByIdAsync(id)).Entity;
        await _dbContext.SaveChangesAsync();
        return categoryResult;
    }
}