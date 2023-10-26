using Microsoft.EntityFrameworkCore;
using ProductCatalog.Storage.Context;
using ProductCatalog.Storage.Entities;

namespace ProductCatalog.Storage.Repository.Implementations;

public class ProductRepository : IProductRepository
{
    private readonly ProductCatalogDbContext _dbContext;

    public ProductRepository(ProductCatalogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Product> GetByIdAsync(long id) =>
        await _dbContext.Products.Include(p => p.Category).FirstOrDefaultAsync(x => x.Id == id);

    public async Task<IEnumerable<Product>> GetAllAsync() =>
        await _dbContext.Products.Include(p => p.Category).ToListAsync();

    public async Task<Product> AddAsync(Product product)
    {
        var productResult = (await _dbContext.Products.AddAsync(product)).Entity;
        await _dbContext.SaveChangesAsync();
        return productResult;
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        _dbContext.Entry(product).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return await GetByIdAsync(product.Id);
    }

    public async Task<Product> DeleteByIdAsync(long id)
    {
        var productResult = _dbContext.Products.Remove(await GetByIdAsync(id)).Entity;
        await _dbContext.SaveChangesAsync();
        return productResult;
    }
}