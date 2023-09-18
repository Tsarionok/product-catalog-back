using ProductCatalog.BusinessLogic.DataTransferObjects;

namespace ProductCatalog.BusinessLogic.Services;

public interface IProductService : IService
{
    public Task<ProductDto> GetByIdAsync(long id);

    public Task<IEnumerable<ProductDto>> GetAllAsync();

    public Task<ProductDto> AddAsync(ProductDto product);

    public Task<ProductDto> UpdateAsync(ProductDto product);

    public Task<ProductDto> DeleteByIdAsync(long id);
}