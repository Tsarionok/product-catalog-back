using ProductCatalog.Domain.DataTransferObjects;

namespace ProductCatalog.Domain.Services;

public interface ICategoryService : IService
{
    public Task<CategoryDto> GetByIdAsync(long id);

    public Task<IEnumerable<CategoryDto>> GetAllAsync();

    public Task<CategoryDto> AddAsync(CategoryDto category);

    public Task<CategoryDto> UpdateAsync(CategoryDto category);

    public Task<CategoryDto> DeleteCascadeByIdAsync(long id);
}