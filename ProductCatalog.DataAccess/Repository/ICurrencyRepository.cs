using ProductCatalog.DataAccess.Entities;

namespace ProductCatalog.DataAccess.Repository;

public interface ICurrencyRepository : IRepository
{
    public Task<Currency> GetByIdAsync(long id);

    public Task<Currency> GetByCodeAsync(string code);

    public Task<IEnumerable<Currency>> GetAllAsync();

    public Task<Currency> AddAsync(Currency currency);

    public Task<Currency> UpdateAsync(Currency currency);

    public Task<Currency> DeleteByIdAsync(long id);

    public Task<Currency> DeleteByCodeAsync(string code);
}