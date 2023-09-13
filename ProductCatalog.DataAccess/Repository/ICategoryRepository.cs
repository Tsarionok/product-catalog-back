using ProductCatalog.DataAccess.Entities;

namespace ProductCatalog.DataAccess.Repository;

public interface ICategoryRepository : IRepository
{
    public Task<Category> GetByIdAsync(long id);
    
    public Task<IEnumerable<Category>> GetAllAsync();

    public Task<Category> AddAsync(Category category);

    public Task<Category> UpdateAsync(Category category);

    public Task<Category> DeleteByIdAsync(long id);
}