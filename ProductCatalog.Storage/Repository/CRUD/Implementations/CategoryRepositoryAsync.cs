using Microsoft.EntityFrameworkCore;
using ProductCatalog.Storage.Context;
using ProductCatalog.Storage.Entities;

namespace ProductCatalog.Storage.Repository.CRUD.Implementations;

public class CategoryRepositoryAsync : ICrudRepositoryAsync<Category, long>
{
    private readonly ProductCatalogDbContext _dbContext;

    public CategoryRepositoryAsync(ProductCatalogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Category> AddAsync(Category entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Category>> GetAllAsync() =>
        await _dbContext.Categories.ToListAsync();

    public async Task<Category> GetByIdAsync(long id) =>
        await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<Category> UpdateAsync(Category category)
    {
        _dbContext.Entry(category).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return await GetByIdAsync(category.Id);
    }

    public Task<Category> DeleteByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}