using ProductCatalog.BusinessLogic.DataTransferObjects;

namespace ProductCatalog.BusinessLogic.Services;

public interface ICategoryService : IService
{
    public Task<CategoryDto> GetByIdAsync(long id);

    public Task<CategoryDto> AddAsync(CategoryDto category);
}