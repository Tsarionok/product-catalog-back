using Microsoft.EntityFrameworkCore;
using ProductCatalog.Storage.Context;
using ProductCatalog.Storage.Entities;

namespace ProductCatalog.Storage.Repository.Implementations;

public class CurrencyRepository : ICurrencyRepository
{
    private ProductCatalogDbContext _dbContext;

    public CurrencyRepository(ProductCatalogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Currency> GetByIdAsync(long id) =>
        await _dbContext.Currencies.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<Currency> GetByCodeAsync(string code) =>
        await _dbContext.Currencies.FirstOrDefaultAsync(x => x.Code.Equals(code));

    public async Task<IEnumerable<Currency>> GetAllAsync() =>
        await _dbContext.Currencies.ToListAsync();

    public async Task<Currency> AddAsync(Currency currency)
    {
        var currencyResult = (await _dbContext.Currencies.AddAsync(currency)).Entity;
        await _dbContext.SaveChangesAsync();
        return currencyResult;
    }

    public async Task<Currency> UpdateAsync(Currency currency)
    {
        _dbContext.Entry(currency).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return await GetByIdAsync(currency.Id);
    }

    public async Task<Currency> DeleteByIdAsync(long id)
    {
        var currencyResult = _dbContext.Currencies.Remove(await GetByIdAsync(id)).Entity;
        await _dbContext.SaveChangesAsync();
        return currencyResult;
    }

    public async Task<Currency> DeleteByCodeAsync(string code)
    {
        var currencyResult = _dbContext.Currencies.Remove(await GetByCodeAsync(code)).Entity;
        await _dbContext.SaveChangesAsync();
        return currencyResult;
    }
}