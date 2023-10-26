using ProductCatalog.Domain.DataTransferObjects;

namespace ProductCatalog.Domain.Services;

public interface IProductService : IService
{
    public Task<ProductDto> GetByIdAsync(long id);

    public Task<IEnumerable<ProductDto>> GetAllAsync();

    public Task<ProductDto> AddAsync(AddProductDto product);

    public Task<ProductDto> UpdateAsync(ProductDto product);

    public Task<ProductDto> DeleteByIdAsync(long id);
}