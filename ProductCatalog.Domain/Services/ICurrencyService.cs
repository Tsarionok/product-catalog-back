using ProductCatalog.Domain.DataTransferObjects;

namespace ProductCatalog.Domain.Services;

public interface ICurrencyService
{
    public Task<CurrencyDto> GetByIdAsync(long id);

    public Task<CurrencyDto> GetByCodeAsync(string code);

    public Task<IEnumerable<CurrencyDto>> GetAllAsync();

    public Task<CurrencyDto> AddAsync(CurrencyDto currency);

    public Task<CurrencyDto> UpdateAsync(CurrencyDto currency);

    public Task<CurrencyDto> DeleteByIdAsync(long id);

    public Task<CurrencyDto> DeleteByCodeAsync(string code);
}