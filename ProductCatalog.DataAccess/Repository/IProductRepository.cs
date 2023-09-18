using ProductCatalog.DataAccess.Entities;

namespace ProductCatalog.DataAccess.Repository;

public interface IProductRepository : IRepository
{
    public Task<Product> GetByIdAsync(long id);
    
    public Task<IEnumerable<Product>> GetAllAsync();

    public Task<Product> AddAsync(Product product);

    public Task<Product> UpdateAsync(Product product);

    public Task<Product> DeleteByIdAsync(long id);
}